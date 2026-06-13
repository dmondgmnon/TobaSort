using System;
using System.Data;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class AkunController
    {
        private AkunContext _context;

        public AkunController()
        {
            _context = new AkunContext();
        }

        public DataTable tampil_semua_akun()
        {
            try
            {
                return _context.GetAllAsDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("Error memuat data akun: " + ex.Message);
            }
        }

        // Tambahan: Meneruskan data pembuatan akun baru ke Context
        public bool tambah_akun(string username, string password, string nama_lengkap, string role)
        {
            return _context.TambahAkun(username, password, nama_lengkap, role);
        }

        // Tambahan: Meneruskan perintah nonaktifkan akun ke Context
        public bool nonaktifkan_akun(int id_akun)
        {
            return _context.NonaktifkanAkun(id_akun);
        }
    }
}