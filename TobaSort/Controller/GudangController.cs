using System.Data;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class GudangController
    {
        private GudangContext _context;

        public GudangController()
        {
            _context = new GudangContext();
        }

        public DataTable tampil_stok_gudang()
        {
            return _context.GetAllStok();
        }
    }
}