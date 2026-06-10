using System;

namespace TobaSort.Models
{
    public class Akun : Orang
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool is_aktif { get; set; }

        public Akun()
        {
            is_aktif = true;
        }

        public override string get_info()
        {
            return base.get_info() + $" | Role: {role} | Status Aktif: {is_aktif}";
        }
    }
}