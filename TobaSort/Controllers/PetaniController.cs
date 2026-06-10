using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class PetaniController
    {
        // 1. READ: Menampilkan semua petani (Untuk dropdown dan tabel)
        public DataTable tampil_semua_petani()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Mengambil data petani (termasuk yang non-aktif untuk riwayat)
                    string query = "SELECT id_petani, nama_petani, alamat, no_telepon, tanggal_daftar, is_aktif FROM tb_petani ORDER BY id_petani DESC";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error memuat data petani: " + ex.Message);
            }
            return dt;
        }

        // 2. CREATE: Menambah Petani Baru
        public bool tambah_petani(string nama, string alamat, string no_telp)
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO tb_petani (nama_petani, alamat, no_telepon, is_aktif) VALUES (@nama, @alamat, @notelp, true)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@alamat", alamat);
                        cmd.Parameters.AddWithValue("@notelp", no_telp);
                        int baris_terdampak = cmd.ExecuteNonQuery();
                        return baris_terdampak > 0; // Mengembalikan true jika berhasil
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal menambah petani: " + ex.Message);
            }
        }

        // 3. UPDATE: Mengubah Data Petani
        public bool edit_petani(int id, string nama, string alamat, string no_telp, bool status_aktif)
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE tb_petani SET nama_petani = @nama, alamat = @alamat, no_telepon = @notelp, is_aktif = @status WHERE id_petani = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@alamat", alamat);
                        cmd.Parameters.AddWithValue("@notelp", no_telp);
                        cmd.Parameters.AddWithValue("@status", status_aktif);
                        cmd.Parameters.AddWithValue("@id", id);
                        int baris_terdampak = cmd.ExecuteNonQuery();
                        return baris_terdampak > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengubah data petani: " + ex.Message);
            }
        }

        // 4. DELETE (Soft Delete): Menonaktifkan Petani agar tidak muncul di dropdown transaksi, 
        // tapi datanya tetap ada untuk histori laporan.
        public bool nonaktifkan_petani(int id)
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE tb_petani SET is_aktif = false WHERE id_petani = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int baris_terdampak = cmd.ExecuteNonQuery();
                        return baris_terdampak > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal menonaktifkan petani: " + ex.Message);
            }
        }
    }
}