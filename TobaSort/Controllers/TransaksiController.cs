using System;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class TransaksiController
    {
        // Fungsi ini menggunakan NpgsqlTransaction untuk memastikan keamanan data
        public bool simpan_transaksi_penyortiran(string id_transaksi, int id_petani, int id_akun_petugas,
                                                 bool status_veto, int total_point, string id_grade,
                                                 decimal berat_kg, string[] kriteria_id, int[] poin_kriteria)
        {
            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Memulai Transaction (Jika salah satu gagal, semua dibatalkan/rollback)
                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Ambil harga per kg dari tabel master_grade berdasarkan grade yang didapat
                        decimal harga_per_kg = 0;
                        string queryHarga = "SELECT harga_per_kg FROM tb_master_grade WHERE id_grade = @grade";
                        using (NpgsqlCommand cmdHarga = new NpgsqlCommand(queryHarga, conn, transaction))
                        {
                            cmdHarga.Parameters.AddWithValue("@grade", id_grade);
                            var result = cmdHarga.ExecuteScalar();
                            if (result != null) harga_per_kg = Convert.ToDecimal(result);
                        }

                        // Hitung total bayar
                        decimal total_bayar = berat_kg * harga_per_kg;

                        // 2. Insert ke tb_transaksi
                        string queryTrx = @"INSERT INTO tb_transaksi 
                                            (id_transaksi, id_petani, id_akun_petugas, status_veto, total_point, id_grade, berat_kg, harga_per_kg_saat_transaksi, total_bayar, status_transaksi) 
                                            VALUES (@id_trx, @petani, @petugas, @veto, @poin, @grade, @berat, @harga, @total, 'Selesai')";

                        using (NpgsqlCommand cmdTrx = new NpgsqlCommand(queryTrx, conn, transaction))
                        {
                            cmdTrx.Parameters.AddWithValue("@id_trx", id_transaksi);
                            cmdTrx.Parameters.AddWithValue("@petani", id_petani);
                            cmdTrx.Parameters.AddWithValue("@petugas", id_akun_petugas);
                            cmdTrx.Parameters.AddWithValue("@veto", status_veto);
                            cmdTrx.Parameters.AddWithValue("@poin", total_point);
                            cmdTrx.Parameters.AddWithValue("@grade", id_grade);
                            cmdTrx.Parameters.AddWithValue("@berat", berat_kg);
                            cmdTrx.Parameters.AddWithValue("@harga", harga_per_kg);
                            cmdTrx.Parameters.AddWithValue("@total", total_bayar);
                            cmdTrx.ExecuteNonQuery();
                        }

                        // 3. Insert ke tb_detail_penilaian (Looping sebanyak 5 kriteria)
                        // Hanya insert detail jika tidak kena Veto
                        if (!status_veto)
                        {
                            string queryDetail = "INSERT INTO tb_detail_penilaian (id_transaksi, id_kriteria, point_didapat) VALUES (@id_trx, @kriteria, @poin_kriteria)";
                            for (int i = 0; i < kriteria_id.Length; i++)
                            {
                                using (NpgsqlCommand cmdDetail = new NpgsqlCommand(queryDetail, conn, transaction))
                                {
                                    cmdDetail.Parameters.AddWithValue("@id_trx", id_transaksi);
                                    cmdDetail.Parameters.AddWithValue("@kriteria", kriteria_id[i]);
                                    cmdDetail.Parameters.AddWithValue("@poin_kriteria", poin_kriteria[i]);
                                    cmdDetail.ExecuteNonQuery();
                                }
                            }
                        }

                        // 4. Update tabel tb_gudang (Menambah stok tembakau berdasarkan grade)
                        string queryGudang = "UPDATE tb_gudang SET total_berat_kg = total_berat_kg + @berat, terakhir_di_update = CURRENT_TIMESTAMP WHERE id_grade = @grade";
                        using (NpgsqlCommand cmdGudang = new NpgsqlCommand(queryGudang, conn, transaction))
                        {
                            cmdGudang.Parameters.AddWithValue("@berat", berat_kg);
                            cmdGudang.Parameters.AddWithValue("@grade", id_grade);
                            cmdGudang.ExecuteNonQuery();
                        }

                        // JIKA SEMUA BERHASIL, SIMPAN PERMANEN (COMMIT)
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // JIKA ADA SATU SAJA YANG GAGAL, KEMBALIKAN SEPERTI SEMULA (ROLLBACK)
                        transaction.Rollback();
                        throw new Exception("Gagal menyimpan transaksi: " + ex.Message);
                    }
                }
            }
        }
    }
}
