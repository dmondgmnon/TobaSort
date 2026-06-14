using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using TobaSort.Data;
using TobaSort.Interfaces;
using TobaSort.Models;

namespace TobaSort.Contexts
{
    public class PetaniContext : DatabaseHelper, IContext<Petani>
    {
        public DataTable GetAllAsDataTable()
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                // PERBAIKAN: Menambahkan CAST agar boolean menjadi teks (menghindari error Checkbox)
                string query = @"
                    SELECT 
                        p.id_petani, 
                        p.nama_petani AS ""Nama Petani"", 
                        p.alamat AS ""Alamat"", 
                        p.no_telepon AS ""No. Telepon"", 
                        p.tanggal_daftar AS ""Tanggal Daftar"", 
                        a.username AS ""Username"", 
                        a.password AS ""Password"",
                        CAST(a.is_aktif AS varchar) AS ""Status Aktif""
                    FROM tb_petani p
                    JOIN tb_akun a ON p.id_akun = a.id_akun
                    ORDER BY p.id_petani DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }

        public bool TambahPetani(string nama_petani, string alamat, string no_telp, string username, string password)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int id_akun_baru = 0;
                        string query_akun = @"INSERT INTO tb_akun (username, password, role, nama_lengkap, is_aktif) 
                                              VALUES (@user, @pass, 'Petani', @nama, true) RETURNING id_akun;";
                        using (var cmd_akun = new NpgsqlCommand(query_akun, conn, transaction))
                        {
                            cmd_akun.Parameters.AddWithValue("@user", username);
                            cmd_akun.Parameters.AddWithValue("@pass", password);
                            cmd_akun.Parameters.AddWithValue("@nama", nama_petani);
                            id_akun_baru = Convert.ToInt32(cmd_akun.ExecuteScalar());
                        }

                        string query_petani = @"INSERT INTO tb_petani (nama_petani, alamat, no_telepon, id_akun) 
                                                VALUES (@nama, @alamat, @notelp, @id_akun);";
                        using (var cmd_petani = new NpgsqlCommand(query_petani, conn, transaction))
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
                        throw new Exception("Gagal mendaftarkan petani: " + ex.Message);
                    }
                }
            }
        }

        public bool EditPetani(int id_petani, string nama_petani, string alamat, string no_telp, string username, string password, bool status_aktif)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int id_akun_target = 0;
                        string query_cari_id = "SELECT id_akun FROM tb_petani WHERE id_petani = @id_petani";
                        using (var cmd_cari = new NpgsqlCommand(query_cari_id, conn, transaction))
                        {
                            cmd_cari.Parameters.AddWithValue("@id_petani", id_petani);
                            id_akun_target = Convert.ToInt32(cmd_cari.ExecuteScalar());
                        }

                        string query_petani = @"UPDATE tb_petani 
                                                SET nama_petani = @nama, alamat = @alamat, no_telepon = @notelp 
                                                WHERE id_petani = @id_petani";
                        using (var cmd_petani = new NpgsqlCommand(query_petani, conn, transaction))
                        {
                            cmd_petani.Parameters.AddWithValue("@nama", nama_petani);
                            cmd_petani.Parameters.AddWithValue("@alamat", alamat);
                            cmd_petani.Parameters.AddWithValue("@notelp", no_telp);
                            cmd_petani.Parameters.AddWithValue("@id_petani", id_petani);
                            cmd_petani.ExecuteNonQuery();
                        }

                        string query_akun = @"UPDATE tb_akun 
                                              SET username = @user, password = @pass, nama_lengkap = @nama, is_aktif = @status 
                                              WHERE id_akun = @id_akun";
                        using (var cmd_akun = new NpgsqlCommand(query_akun, conn, transaction))
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

        public bool UbahStatusPetani(int id_petani, bool status_baru)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"UPDATE tb_akun SET is_aktif = @status 
                                 WHERE id_akun = (SELECT id_akun FROM tb_petani WHERE id_petani = @id)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id_petani);
                    cmd.Parameters.AddWithValue("@status", status_baru);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool NonaktifkanPetani(int id_petani)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"UPDATE tb_akun SET is_aktif = false 
                                 WHERE id_akun = (SELECT id_akun FROM tb_petani WHERE id_petani = @id)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id_petani);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Petani> GetAll() { return new List<Petani>(); }
        public Petani GetById(object id) { return null; }
        public bool Insert(Petani entity) { return false; }
        public bool Update(Petani entity) { return false; }
        public bool Delete(object id) { return false; }
    }
}