using System.Data;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class PetaniController
    {
        private PetaniContext _context;

        public PetaniController()
        {
            _context = new PetaniContext();
        }

        public DataTable tampil_semua_petani()
        {
            return _context.GetAllAsDataTable();
        }

        public bool tambah_petani(string nama_petani, string alamat, string no_telp, string username, string password)
        {
            return _context.TambahPetani(nama_petani, alamat, no_telp, username, password);
        }

        public bool edit_petani(int id_petani, string nama_petani, string alamat, string no_telp, string username, string password, bool status_aktif)
        {
            return _context.EditPetani(id_petani, nama_petani, alamat, no_telp, username, password, status_aktif);
        }

        // ====================================================
        // FUNGSI BARU: Untuk fitur Smart Toggle (Aktif/Nonaktif)
        // ====================================================
        public bool ubah_status_petani(int id_petani, bool status_baru)
        {
            return _context.UbahStatusPetani(id_petani, status_baru);
        }

        public bool nonaktifkan_petani(int id_petani)
        {
            return _context.NonaktifkanPetani(id_petani);
        }
    }
}