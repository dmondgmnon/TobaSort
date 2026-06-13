using System.Data;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class GradeController
    {
        private GradeContext _context;

        public GradeController()
        {
            _context = new GradeContext();
        }

        public DataTable tampil_semua_grade()
        {
            return _context.GetAllGrade();
        }

        public bool update_harga(string id_grade, decimal harga_baru, int id_akun_pengubah)
        {
            return _context.UpdateHarga(id_grade, harga_baru, id_akun_pengubah);
        }
    }
}