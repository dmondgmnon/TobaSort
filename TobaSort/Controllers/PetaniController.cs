using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class PetaniController
    {
        // 1. READ: Menampilkan semua petani hasil JOIN dengan data akun loginnya
        public DataTable tampil_semua_petani()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.id_petani, 
                            p.nama_petani AS ""Nama Petani"", 
                            p.alamat AS ""Alamat"", 
                            p.no_telepon AS ""No. Telepon"", 
                            p.tanggal_daftar AS ""Tanggal Daftar"", 
                            a.username AS ""Username"", 
                            a.password AS ""Password"",
                            a.is_aktif AS ""Status Aktif""
                        FROM tb_petani p
                        JOIN tb_akun a ON p.id_akun = a.id_akun
                        ORDER BY p.id_petani DESC";

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

        // 2. CREATE: Menambah Petani Baru & Akun Loginnya secara bertingkat (Atomic Transaction)
        public bool tambah_petani(string nama_petani, string alamat, string no_telp, string username, string password)
        {
            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // A. Insert ke tb_akun terlebih dahulu
                        int id_akun_baru = 0;
                        string query_akun = @"
                            INSERT INTO tb_akun (username, password, role, nama_lengkap, is_aktif) 
                            VALUES (@user, @pass, 'Petani', @nama, true) 
                            RETURNING id_akun;";

                        using (NpgsqlCommand cmd_akun = new NpgsqlCommand(query_akun, conn, transaction))
                        {
                            cmd_akun.Parameters.AddWithValue("@user", username);
                            cmd_akun.Parameters.AddWithValue("@pass", password);
                            cmd_akun.Parameters.AddWithValue("@nama", nama_petani);
                            id_akun_baru = Convert.ToInt32(cmd_akun.ExecuteScalar());
                        }

                        // B. Insert ke tb_petani membawa id_akun yang baru dibuat
                        string query_petani = @"
                            INSERT INTO tb_petani (nama_petani, alamat, no_telepon, id_akun) 
                            VALUES (@nama, @alamat, @notelp, @id_akun);";

                        using (NpgsqlCommand cmd_petani = new NpgsqlCommand(query_petani, conn, transaction))
                        {
                            cmd_petani.Parameters.AddWithValue("@nama", nama_petani);
                            cmd_petani.Parameters.AddWithValue("@alamat", alamat);
                            cmd_petani.Parameters.AddWithValue("@notelp", no_telp);
                            cmd_petani.Parameters.AddWithValue("@id_akun", id_akun_baru);
                            cmd_petani.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Gagal mendaftarkan petani baru: " + ex.Message);
                    }
                }
            }
        }

        // 3. UPDATE: Mengubah Biodata dan Akun Login Petani sekaligus
        public bool edit_petani(int id_petani, string nama_petani, string alamat, string no_telp, string username, string password, bool status_aktif)
        {
            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (NpgsqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // A. Dapatkan id_akun milik petani tersebut
                        int id_akun_target = 0;
                        string query_cari_id = "SELECT id_akun FROM tb_petani WHERE id_petani = @id_petani";
                        using (NpgsqlCommand cmd_cari = new NpgsqlCommand(query_cari_id, conn, transaction))
                        {
                            cmd_cari.Parameters.AddWithValue("@id_petani", id_petani);
                            id_akun_target = Convert.ToInt32(cmd_cari.ExecuteScalar());
                        }

                        // B. Update data tb_petani
                        string query_petani = @"
                            UPDATE tb_petani 
                            SET nama_petani = @nama, alamat = @alamat, no_telepon = @notelp 
                            WHERE id_petani = @id_petani";
                        using (NpgsqlCommand cmd_petani = new NpgsqlCommand(query_petani, conn, transaction))
                        {
                            cmd_petani.Parameters.AddWithValue("@nama", nama_petani);
                            cmd_petani.Parameters.AddWithValue("@alamat", alamat);
                            cmd_petani.Parameters.AddWithValue("@notelp", no_telp);
                            cmd_petani.Parameters.AddWithValue("@id_petani", id_petani);
                            cmd_petani.ExecuteNonQuery();
                        }

                        // C. Update data tb_akun
                        string query_akun = @"
                            UPDATE tb_akun 
                            SET username = @user, password = @pass, nama_lengkap = @nama, is_aktif = @status 
                            WHERE id_akun = @id_akun";
                        using (NpgsqlCommand cmd_akun = new NpgsqlCommand(query_akun, conn, transaction))
                        {
                            cmd_akun.Parameters.AddWithValue("@user", username);
                            cmd_akun.Parameters.AddWithValue("@pass", password);
                            cmd_akun.Parameters.AddWithValue("@nama", nama_petani);
                            cmd_akun.Parameters.AddWithValue("@status", status_aktif);
                            cmd_akun.Parameters.AddWithValue("@id_akun", id_akun_target);
                            cmd_akun.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Gagal mengubah data petani: " + ex.Message);
                    }
                }
            }
        }

        // 4. SOFT DELETE: Menonaktifkan status login petani lewat tabel tb_akun
        public bool nonaktifkan_petani(int id_petani)
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE tb_akun 
                        SET is_aktif = false 
                        WHERE id_akun = (SELECT id_akun FROM tb_petani WHERE id_petani = @id);";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id_petani);
                        int baris_terdampak = cmd.ExecuteNonQuery();
                        return baris_terdampak > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal menonaktifkan akun petani: " + ex.Message);
            }
        }
    }
}