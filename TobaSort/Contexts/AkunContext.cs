using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using TobaSort.Data;
using TobaSort.Interfaces;
using TobaSort.Models;

namespace TobaSort.Contexts
{
    public class AkunContext : DatabaseHelper, IContext<Akun>
    {
        public Akun Login(string username, string password)
        {
            Akun akunAktif = null;
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"SELECT id_akun, username, role, nama_lengkap, is_aktif 
                                 FROM tb_akun 
                                 WHERE username = @user AND password = @pass AND is_aktif = true";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            akunAktif = new Akun
                            {
                                id = Convert.ToInt32(reader["id_akun"]),
                                username = reader["username"].ToString(),
                                role = reader["role"].ToString(),
                                nama_lengkap = reader["nama_lengkap"].ToString(),
                                is_aktif = Convert.ToBoolean(reader["is_aktif"])
                            };
                        }
                    }
                }
            }
            return akunAktif;
        }

        public DataTable GetAllAsDataTable()
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"SELECT id_akun, nama_lengkap AS ""Nama Lengkap"", username AS ""Username"", 
                                        password AS ""Password"", role AS ""Role"", is_aktif AS ""Status Aktif"" 
                                 FROM tb_akun 
                                 WHERE role IN ('Admin Gudang', 'Petugas Grading') 
                                 ORDER BY id_akun DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool TambahAkun(string username, string password, string nama_lengkap, string role)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = "INSERT INTO tb_akun (username, password, nama_lengkap, role, is_aktif) VALUES (@user, @pass, @nama, @role, true)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@nama", nama_lengkap);
                    cmd.Parameters.AddWithValue("@role", role);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // FUNGSI GABUNGAN: Menggunakan versi yang memiliki parameter is_aktif
        public bool UbahAkun(int id_akun, string username, string password, string nama_lengkap, string role, bool is_aktif)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = "UPDATE tb_akun SET username = @user, password = @pass, nama_lengkap = @nama, role = @role, is_aktif = @aktif WHERE id_akun = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id_akun);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@nama", nama_lengkap);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@aktif", is_aktif);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // FUNGSI BARU (SMART BUTTON): Mengubah status aktif/nonaktif saja
        public bool UbahStatusAkun(int id_akun, bool status_baru)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = "UPDATE tb_akun SET is_aktif = @status WHERE id_akun = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status_baru);
                    cmd.Parameters.AddWithValue("@id", id_akun);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // (Fungsi NONAKTIFKAN AKUN) Alternatif: Langsung set is_aktif = false 
        public bool NonaktifkanAkun(int id_akun)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = "UPDATE tb_akun SET is_aktif = false WHERE id_akun = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id_akun);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // INTERFACE IMPLEMENTATIONS (Wajib ada agar tidak error IContext)
        public List<Akun> GetAll() { return new List<Akun>(); }
        public Akun GetById(object id) { return null; }
        public bool Insert(Akun entity) { return false; }
        public bool Update(Akun entity) { return false; }
        public bool Delete(object id) { return false; }
    }
}