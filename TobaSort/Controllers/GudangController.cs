using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class GudangController
    {
        // Fungsi untuk mengambil data stok gudang saat ini
        public DataTable tampil_stok_gudang()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Mengambil id grade dan total berat dari tabel gudang
                    string query = @"
                        SELECT 
                            id_grade AS ""Grade Tembakau"", 
                            total_berat_kg AS ""Total Stok (Kg)"",
                            terakhir_di_update AS ""Terakhir Diperbarui""
                        FROM 
                            tb_gudang 
                        ORDER BY 
                            id_grade ASC";

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
                throw new Exception("Gagal memuat data stok gudang: " + ex.Message);
            }
            return dt;
        }
    }
}