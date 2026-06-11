using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class GradeController
    {
        // 1. Tampilkan semua grade dan harga saat ini
        public DataTable tampil_semua_grade()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Urutkan dari poin tertinggi (Grade Super A+) ke bawah
                    string query = @"
                        SELECT 
                            id_grade AS ""Grade"", 
                            nama_grade AS ""Keterangan"", 
                            min_point AS ""Min Poin"", 
                            max_point AS ""Max Poin"", 
                            harga_per_kg AS ""Harga/Kg (Rp)"" 
                        FROM tb_master_grade 
                        ORDER BY max_point DESC";

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
                throw new Exception("Error memuat data grade: " + ex.Message);
            }
            return dt;
        }

        // 2. Update harga per kg (Trigger database akan otomatis mencatat log-nya)
        public bool update_harga(string id_grade, decimal harga_baru, int id_akun_pengubah)
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE tb_master_grade 
                        SET harga_per_kg = @harga, id_akun_pengubah = @id_akun 
                        WHERE id_grade = @id_grade";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@harga", harga_baru);
                        cmd.Parameters.AddWithValue("@id_akun", id_akun_pengubah);
                        cmd.Parameters.AddWithValue("@id_grade", id_grade);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengupdate harga: " + ex.Message);
            }
        }
    }
}