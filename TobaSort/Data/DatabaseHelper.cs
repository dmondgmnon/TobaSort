using System;
using Npgsql;

namespace TobaSort.Data
{
    public class DatabaseHelper
    {
        // Ganti 'password_kamu' dengan password pgAdmin
        private static readonly string connectionString = "Host=localhost;Port=5432;Database=tobasort;Username=postgres;Password=Yogan1416;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}