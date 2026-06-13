using System;
using System.Data;
using TobaSort.Contexts;

namespace TobaSort.Controllers
{
    public class TransaksiController
    {
        private TransaksiContext _context;

        public TransaksiController()
        {
            _context = new TransaksiContext();
        }

        public bool simpan_transaksi_penyortiran(string id_transaksi, int id_petani, int id_akun_petugas,
                                                 bool status_veto, int total_point, string id_grade,
                                                 decimal berat_kg, string[] kriteria_id, int[] poin_kriteria)
        {
            return _context.SimpanTransaksi(id_transaksi, id_petani, id_akun_petugas, status_veto,
                                            total_point, id_grade, berat_kg, kriteria_id, poin_kriteria);
        }

        public DataTable tampil_riwayat_transaksi()
        {
            return _context.GetRiwayat();
        }

        public DataTable tampil_riwayat_berdasarkan_tanggal(DateTime tgl_awal, DateTime tgl_akhir)
        {
            return _context.GetRiwayat(tgl_awal, tgl_akhir);
        }

        public DataTable tampil_riwayat_petani(int id_akun_login)
        {
            return _context.GetRiwayatPetani(id_akun_login);
        }
    }
}