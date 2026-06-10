using System;

namespace TobaSort.Models
{
    // Menginduk ke class Orang
    public class Petani : Orang
    {
        // Menyembunyikan/override properti nama_lengkap dari induk 
        // agar sinkron dengan kolom 'nama_petani' di database
        public new string nama_lengkap { get; set; }

        public string alamat { get; set; }
        public string no_telepon { get; set; }
        public DateTime tanggal_daftar { get; set; }
        public bool is_aktif { get; set; }

        public Petani()
        {
            tanggal_daftar = DateTime.Now;
            is_aktif = true;
        }

        public override string get_info()
        {
            return $"ID: {id} | Nama Petani: {nama_lengkap} | Telp: {no_telepon} | Terdaftar: {tanggal_daftar.ToString("dd-MMM-yyyy")}";
        }
    }
}