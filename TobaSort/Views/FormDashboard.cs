using System;
using System.Windows.Forms;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormDashboard : Form
    {
        // Variabel untuk menyimpan data user yang sedang login
        private Akun akun_aktif;

        // Constructor dimodifikasi agar menerima parameter 'Akun' dari Form Login
        public FormDashboard(Akun akun_login)
        {
            InitializeComponent();
            this.akun_aktif = akun_login;

            // Jalankan fungsi pengaturan tampilan saat form pertama kali dimuat
            atur_tampilan_berdasarkan_role();
        }

        private void atur_tampilan_berdasarkan_role()
        {
            // 1. Menampilkan sapaan dan role saat ini
            lblInfoUser.Text = $"Selamat Datang, {akun_aktif.nama_lengkap}!";
            lblRole.Text = akun_aktif.get_info();

            // 2. Tutup semua akses tombol terlebih dahulu (Keamanan)
            btnMenuManajer.Visible = false;
            btnMenuPetugas.Visible = false;
            btnMenuPetani.Visible = false;
            btnKelolaPetani.Visible = false;
            btnLaporan.Visible = false;     // <-- Tambahan keamanan untuk tombol laporan
            btnStokGudang.Visible = false;  // <-- Tambahan keamanan untuk tombol stok gudang

            // 3. Buka akses sesuai dengan nama role ASLI di database
            if (akun_aktif.role == "Manajer")
            {
                // Manajer mendapatkan hak akses menu utamanya, Kelola Petani, Laporan, dan Stok
                btnMenuManajer.Visible = true;
                btnKelolaPetani.Visible = true;
                btnLaporan.Visible = true;
                btnStokGudang.Visible = true; // <-- Tampilkan tombol stok gudang khusus Manajer
            }
            else if (akun_aktif.role == "Petugas")
            {
                // Petugas gudang murni hanya melakukan transaksi penyortiran
                btnMenuPetugas.Visible = true;
            }
            else if (akun_aktif.role == "Petani")
            {
                // Petani hanya melihat menu mereka sendiri
                btnMenuPetani.Visible = true;
            }
        }

        // Fungsi ketika tombol logout ditekan
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Menutup form dashboard ini
            this.Close();
        }

        // Fungsi membuka Form Manajer saat tombolnya ditekan
        private void btnMenuManajer_Click(object sender, EventArgs e)
        {
            // Membuka form manajer
            FormManajer form_manajer = new FormManajer();
            form_manajer.ShowDialog();
        }

        // Fungsi membuka Form Transaksi saat tombol Petugas ditekan
        private void btnMenuPetugas_Click(object sender, EventArgs e)
        {
            // Membuka form transaksi dengan membawa data akun_aktif (petugas)
            FormTransaksi form_transaksi = new FormTransaksi(akun_aktif);
            form_transaksi.ShowDialog();
        }

        // Fungsi membuka Form Kelola Petani
        private void btnKelolaPetani_Click(object sender, EventArgs e)
        {
            FormPetani form_petani = new FormPetani();
            form_petani.ShowDialog();
        }

        // Fungsi membuka Form Laporan
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporanTransaksi form_laporan = new FormLaporanTransaksi();
            form_laporan.ShowDialog();
        }

        // --- KODE BARU: Fungsi membuka Form Stok Gudang ---
        private void btnStokGudang_Click(object sender, EventArgs e)
        {
            FormStokGudang form_stok = new FormStokGudang();
            form_stok.ShowDialog();
        }

        private void btnMenuPetani_Click(object sender, EventArgs e)
        {
            FormRiwayatPetani form_riwayat = new FormRiwayatPetani(akun_aktif);
            form_riwayat.ShowDialog();
        }
    }
}