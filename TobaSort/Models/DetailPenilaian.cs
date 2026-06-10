using System;

namespace TobaSort.Models
{
    public class DetailPenilaian
    {
        public int id_detail { get; set; }
        public string id_transaksi { get; set; }
        public string id_kriteria { get; set; }
        public int point_didapat { get; set; }
        public string catatan_kriteria { get; set; }

        public DetailPenilaian()
        {
            point_didapat = 0;
        }

        public DetailPenilaian(string id_kriteria, int point)
        {
            this.id_kriteria = id_kriteria;
            point_didapat = point;
        }
    }
}