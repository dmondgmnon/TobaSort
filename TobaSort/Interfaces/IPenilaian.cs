using System;

namespace TobaSort.Interfaces
{
    public interface IPenilaian
    {
        void hitung_total_poin();
        void tentukan_grade(string grade_otomatis_veto = null);
    }
}