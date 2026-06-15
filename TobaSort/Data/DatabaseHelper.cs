using System;
using Npgsql;

namespace TobaSort.Data
{
    // Pilar Abstraction & Inheritance: Class ini abstrak, hanya bisa diwariskan
    public abstract class DatabaseHelper
    {
        // Pilar Encapsulation: String koneksi dikunci rapat dari akses luar
        private readonly string connectionString = "Host=localhost;Port=5432;Database=projeks1922;Username=postgres;Password=170307;";

        // Pilar Inheritance: Fungsi ini dilindungi (protected), 
        // HANYA class di dalam folder Contexts yang bisa memanggilnya
        protected NpgsqlConnection BuatKoneksi()
        {
            return new NpgsqlConnection(connectionString);
        }

        // Fungsi statis murni untuk keperluan debugging koneksi awal aplikasi
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=tobasort1;Username=postgres;Password=Yogan1416;"))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}