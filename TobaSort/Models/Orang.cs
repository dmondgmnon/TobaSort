using System;

namespace TobaSort.Models
{
    public abstract class Orang
    {
        // Dikembalikan ke huruf kecil agar form lama tidak error
        public int id { get; set; }
        public string nama_lengkap { get; set; }

        public virtual string get_info()
        {
            return $"ID: {id} | Nama: {nama_lengkap}";
        }
    }
}