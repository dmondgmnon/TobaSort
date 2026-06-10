using System;
using System.IO;
using Npgsql;
using TobaSort.Models;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class AuthController
    {
        public Akun login(string input_username, string input_password)
        {
            Akun akun_aktif = null;

            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT id_akun, username, role, nama_lengkap, is_aktif 
                                     FROM tb_akun 
                                     WHERE username = @user AND password = @pass AND is_aktif = true";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", input_username);
                        cmd.Parameters.AddWithValue("@pass", input_password);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                akun_aktif = new Akun();
                                akun_aktif.id = Convert.ToInt32(reader["id_akun"]);
                                akun_aktif.username = reader["username"].ToString();
                                akun_aktif.role = reader["role"].ToString();
                                akun_aktif.nama_lengkap = reader["nama_lengkap"].ToString();
                                akun_aktif.is_aktif = Convert.ToBoolean(reader["is_aktif"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string logMessage = $"{DateTime.Now} - Error Login DB: {ex.Message} \n";
                File.AppendAllText("error_log.txt", logMessage);
                throw new Exception("Terjadi gangguan sistem database. Silakan periksa koneksi atau lapor Manajer.");
            }

            return akun_aktif;
        }
    }
}