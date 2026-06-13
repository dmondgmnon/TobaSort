using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Contexts
{
    public class GudangContext : DatabaseHelper
    {
        public DataTable GetAllStok()
        {
            DataTable dt = new DataTable();
            using (var conn = BuatKoneksi())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        id_grade AS ""Grade Tembakau"", 
                        total_berat_kg AS ""Total Stok (Kg)"",
                        terakhir_di_update AS ""Terakhir Diperbarui""
                    FROM tb_gudang 
                    ORDER BY id_grade ASC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var da = new NpgsqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }
    }
}