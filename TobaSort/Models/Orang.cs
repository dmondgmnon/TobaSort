using System;

namespace TobaSort.Models
{
    public abstract class Orang
    {
        public int id { get; set; }
        public string nama_lengkap { get; set; }

        public virtual string get_info()
        {
            return $"ID: {id} | Nama: {nama_lengkap}";
        }
    }
}