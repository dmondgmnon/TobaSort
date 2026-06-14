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

        // Meneruskan data pembuatan akun baru ke Context
        public bool tambah_akun(string username, string password, string nama_lengkap, string role)
        {
            return _context.TambahAkun(username, password, nama_lengkap, role);
        }

        // TAMBAHAN: Meneruskan perintah ubah data akun ke Context
        public bool ubah_akun(int id_akun, string username, string password, string nama_lengkap, string role)
        {
            return _context.UbahAkun(id_akun, username, password, nama_lengkap, role);
        }

        // Meneruskan perintah nonaktifkan akun ke Context
        public bool nonaktifkan_akun(int id_akun)
        {
            return _context.NonaktifkanAkun(id_akun);
        }
    }
}