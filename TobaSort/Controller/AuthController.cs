using System;
using System.IO;
using TobaSort.Models;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class AuthController
    {
        private AkunContext _context;

        public AuthController()
        {
            _context = new AkunContext();
        }

        public Akun login(string input_username, string input_password)
        {
            try
            {
                return _context.Login(input_username, input_password);
            }
            catch (Exception ex)
            {
                string logMessage = $"{DateTime.Now} - Error Login: {ex.Message} \n";
                File.AppendAllText("error_log.txt", logMessage);
                throw new Exception("Terjadi gangguan sistem. Silakan periksa koneksi atau lapor Admin Gudang.");
            }
        }
    }
}