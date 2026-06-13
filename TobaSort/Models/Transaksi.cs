using System;
using System.Collections.Generic;
using TobaSort.Interfaces;

namespace TobaSort.Models
{
    public class Transaksi : IPenilaian, ICetakLaporan
    {
        public string id_transaksi { get; set; }
        public DateTime waktu_transaksi { get; set; }
        public int id_petani { get; set; }
        public int id_akun_petugas { get; set; }
        public bool status_veto { get; set; }
        public int? total_point { get; set; }
        public string id_grade { get; set; }
        public decimal berat_kg { get; set; }
        public decimal? harga_per_kg_saat_transaksi { get; set; }
        public decimal? total_bayar { get; set; }

        
        public string status_transaksi { get; set; }
        public string catatan_mutu_global { get; set; }

        public List<DetailPenilaian> daftar_penilaian { get; set; }

        public Transaksi()
        {
            waktu_transaksi = DateTime.Now;
            status_veto = false;
            status_transaksi = "Antrean";
            daftar_penilaian = new List<DetailPenilaian>();
        }

        public void hitung_total_bayar()
        {
            if (harga_per_kg_saat_transaksi.HasValue)
            {
                total_bayar = berat_kg * harga_per_kg_saat_transaksi.Value;
            }
        }

        public void hitung_total_poin()
        {
            if (status_veto)
            {
                total_point = 0;
                return;
            }

            int hitung = 0;
            foreach (var detail in daftar_penilaian)
            {
                hitung += detail.point_didapat;
            }
            total_point = hitung;
        }

        public void tentukan_grade(string grade_otomatis_veto = null)
        {
            if (status_veto && grade_otomatis_veto != null)
            {
                id_grade = grade_otomatis_veto;
                return;
            }
        }

        public string generate_teks_struk()
        {
            string teks = "================================\n";
            teks += "           TOBASORT             \n";
            teks += "    Gudang Penyortiran Utama    \n";
            teks += "================================\n";
            teks += $"No. Trx : {id_transaksi}\n";
            teks += $"Waktu   : {waktu_transaksi.ToString("dd-MMM-yyyy HH:mm")}\n";
            teks += $"Status  : {status_transaksi}\n";
            teks += "--------------------------------\n";
            teks += $"Berat   : {berat_kg} Kg\n";
            teks += $"Total   : Rp {total_bayar}\n";
            teks += "================================\n";
            return teks;
        }
    }
}