using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Contexts
{
    public class GradeContext : DatabaseHelper
    {
        public DataTable GetAllGrade()
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        id_grade AS ""Grade"", 
                        nama_grade AS ""Keterangan"", 
                        min_point AS ""Min Poin"", 
                        max_point AS ""Max Poin"", 
                        harga_per_kg AS ""Harga/Kg (Rp)"" 
                    FROM tb_master_grade 
                    ORDER BY max_point DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }

        public bool UpdateHarga(string id_grade, decimal harga_baru, int id_akun_pengubah)
        {
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"
                    UPDATE tb_master_grade 
                    SET harga_per_kg = @harga, id_akun_pengubah = @id_akun 
                    WHERE id_grade = @id_grade";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@harga", harga_baru);
                    cmd.Parameters.AddWithValue("@id_akun", id_akun_pengubah);
                    cmd.Parameters.AddWithValue("@id_grade", id_grade);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}