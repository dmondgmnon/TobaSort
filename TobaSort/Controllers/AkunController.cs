using System;
using System.Data;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Controllers
{
    public class AkunController
    {
        // Fungsi untuk mengambil data (Read) dan mengubahnya menjadi tabel agar bisa ditampilkan di UI
        public DataTable tampil_semua_akun()
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Mengambil data dari database
                    string query = "SELECT id_akun, username, role, nama_lengkap, is_aktif FROM tb_akun ORDER BY id_akun ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt); // Memasukkan hasil query ke dalam DataTable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error memuat data akun: " + ex.Message);
            }
            return dt;
        }
    }
}