using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Contexts
{
    public class TransaksiContext : DatabaseHelper
    {
        public bool SimpanTransaksi(string id_transaksi, int id_petani, int id_akun_petugas,
                                    bool status_veto, int total_point, string id_grade,
                                    decimal berat_kg, string[] kriteria_id, int[] poin_kriteria)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // PERBAIKAN UTAMA: Tambahkan RETURNING id_transaksi di akhir query
                        string queryTrx = @"INSERT INTO tb_transaksi 
                                           (id_transaksi, id_petani, id_akun_petugas, status_veto, total_point, 
                                            id_grade, berat_kg) 
                                            VALUES (@id_trx, @petani, @petugas, @veto, @poin, @grade, @berat)
                                            RETURNING id_transaksi";

                        using (var cmdTrx = new NpgsqlCommand(queryTrx, conn, transaction))
                        {
                            cmdTrx.Parameters.AddWithValue("@id_trx", id_transaksi);
                            cmdTrx.Parameters.AddWithValue("@petani", id_petani);
                            cmdTrx.Parameters.AddWithValue("@petugas", id_akun_petugas);
                            cmdTrx.Parameters.AddWithValue("@veto", status_veto);
                            cmdTrx.Parameters.AddWithValue("@poin", total_point);
                            cmdTrx.Parameters.AddWithValue("@grade", id_grade);
                            cmdTrx.Parameters.AddWithValue("@berat", berat_kg);

                            // PERBAIKAN UTAMA: Tangkap ID yang baru saja digenerate oleh Trigger PostgreSQL
                            var idBaru = cmdTrx.ExecuteScalar();
                            if (idBaru != null)
                            {
                                id_transaksi = idBaru.ToString(); // Update variabel id_transaksi dengan ID asli (TRX-...)
                            }
                        }

                        // Sekarang id_transaksi sudah berisi ID asli, siap digunakan untuk tabel detail
                        if (!status_veto)
                        {
                            string queryDetail = "INSERT INTO tb_detail_penilaian (id_transaksi, id_kriteria, point_didapat) VALUES (@id_trx, @kriteria, @poin_kriteria)";
                            for (int i = 0; i < kriteria_id.Length; i++)
                            {
                                using (var cmdDetail = new NpgsqlCommand(queryDetail, conn, transaction))
                                {
                                    cmdDetail.Parameters.AddWithValue("@id_trx", id_transaksi);
                                    cmdDetail.Parameters.AddWithValue("@kriteria", kriteria_id[i]);
                                    cmdDetail.Parameters.AddWithValue("@poin_kriteria", poin_kriteria[i]);
                                    cmdDetail.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataTable GetRiwayat()
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"SELECT t.id_transaksi AS ""ID Transaksi"", t.waktu_transaksi AS ""Tanggal"", 
                                        p.nama_petani AS ""Nama Petani"", a.nama_lengkap AS ""Petugas"", 
                                        t.berat_kg AS ""Berat (Kg)"", t.total_point AS ""Total Poin"", 
                                        t.id_grade AS ""Grade"", t.status_veto AS ""Veto?"", t.total_bayar AS ""Total Bayar (Rp)""
                                 FROM tb_transaksi t
                                 JOIN tb_petani p ON t.id_petani = p.id_petani
                                 JOIN tb_akun a ON t.id_akun_petugas = a.id_akun
                                 ORDER BY t.waktu_transaksi DESC";
                using (var cmd = new NpgsqlCommand(query, conn)) { using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); } }
            }
            return dt;
        }

        public DataTable GetRiwayat(DateTime tglAwal, DateTime tglAkhir)
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"SELECT t.id_transaksi AS ""ID Transaksi"", t.waktu_transaksi AS ""Tanggal"",
                                        p.nama_petani AS ""Nama Petani"", a.nama_lengkap AS ""Petugas"",
                                        t.berat_kg AS ""Berat (Kg)"", t.total_point AS ""Total Poin"", 
                                        t.id_grade AS ""Grade"", t.status_veto AS ""Veto?"", t.total_bayar AS ""Total Bayar (Rp)""
                                 FROM tb_transaksi t
                                 JOIN tb_petani p ON t.id_petani = p.id_petani
                                 JOIN tb_akun a ON t.id_akun_petugas = a.id_akun
                                 WHERE DATE(t.waktu_transaksi) >= @awal AND DATE(t.waktu_transaksi) <= @akhir
                                 ORDER BY t.waktu_transaksi DESC";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@awal", tglAwal.Date);
                    cmd.Parameters.AddWithValue("@akhir", tglAkhir.Date);
                    using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }

        public DataTable GetRiwayatPetani(int idAkunLogin)
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"SELECT t.id_transaksi AS ""ID Transaksi"", t.berat_kg AS ""Berat (Kg)"", 
                                        t.total_point AS ""Total Poin"", t.id_grade AS ""Grade"", 
                                        t.status_veto AS ""Kena Veto?"", t.total_bayar AS ""Total Uang (Rp)""
                                 FROM tb_transaksi t
                                 JOIN tb_petani p ON t.id_petani = p.id_petani
                                 WHERE p.id_akun = @id_akun
                                 ORDER BY t.id_transaksi DESC";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_akun", idAkunLogin);
                    using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }
    }
}