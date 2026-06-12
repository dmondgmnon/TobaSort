using System;
using System.Drawing;
using System.Windows.Forms;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormDashboard : Form
    {
        private Akun akun_aktif;

        public FormDashboard(Akun akun_login)
        {
            InitializeComponent();
            this.akun_aktif = akun_login;

            atur_tampilan_berdasarkan_role();
        }

        private void atur_tampilan_berdasarkan_role()
        {
            // --- Mengisi Kartu Profil ---
            lblJudulDashboard.Text = $"Dashboard {akun_aktif.role}";
            lblValueId.Text = akun_aktif.id.ToString();
            lblValueNama.Text = akun_aktif.nama_lengkap.ToUpper();
            lblValueRole.Text = akun_aktif.role;
            lblValueStatus.Text = "● Aktif";
            lblValueStatus.ForeColor = Color.ForestGreen;

            // 2. Tutup semua akses tombol terlebih dahulu (Keamanan)
            btnMenuManajer.Visible = false;
            btnMenuPetugas.Visible = false;
            btnMenuPetani.Visible = false;
            btnKelolaPetani.Visible = false;
            btnLaporan.Visible = false;
            btnStokGudang.Visible = false;
            btnKelolaHarga.Visible = false;

            // 3. Buka akses sesuai dengan nama role ASLI di database
            if (akun_aktif.role == "Manajer")
            {
                btnMenuManajer.Visible = true;
                btnKelolaPetani.Visible = true;
                btnLaporan.Visible = true;
                btnStokGudang.Visible = true;
                btnKelolaHarga.Visible = true;
            }
            else if (akun_aktif.role == "Petugas")
            {
                btnMenuPetugas.Visible = true;
            }
            else if (akun_aktif.role == "Petani")
            {
                btnMenuPetani.Visible = true;
            }

            // Panggil fungsi merapikan tombol
            SusunUlangPosisiTombol();
        }

        private void SusunUlangPosisiTombol()
        {
            // Tentukan titik awal Y untuk tombol pertama (di bawah profil)
            int jarak_y = 200;

            // Masukkan semua tombol menu ke dalam array secara berurutan
            Button[] semua_tombol = { btnMenuManajer, btnKelolaHarga, btnKelolaPetani, btnStokGudang, btnLaporan, btnMenuPetugas, btnMenuPetani };

            foreach (Button btn in semua_tombol)
            {
                if (btn != null && btn.Visible)
                {
                    btn.Top = jarak_y; // Pindahkan ke posisi Y yang baru
                    jarak_y += btn.Height + 15; // Jarak antar tombol menu
                }
            }

            // Paksa tombol Logout berada di area paling bawah Form
            if (btnLogout != null)
            {
                btnLogout.Top = this.ClientSize.Height - btnLogout.Height - 40;
            }
        }

        // ==========================================
        // LOGIKA TOMBOL 
        // ==========================================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuManajer_Click(object sender, EventArgs e)
        {
            FormManajer form_manajer = new FormManajer();
            form_manajer.ShowDialog();
        }

        private void btnMenuPetugas_Click(object sender, EventArgs e)
        {
            FormTransaksi form_transaksi = new FormTransaksi(akun_aktif);
            form_transaksi.ShowDialog();
        }

        private void btnKelolaPetani_Click(object sender, EventArgs e)
        {
            FormPetani form_petani = new FormPetani();
            form_petani.ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporanTransaksi form_laporan = new FormLaporanTransaksi();
            form_laporan.ShowDialog();
        }

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

        private void btnKelolaHarga_Click(object sender, EventArgs e)
        {
            FormKelolaHarga form_harga = new FormKelolaHarga(akun_aktif);
            form_harga.ShowDialog();
        }

        // ==========================================
        // EVENT KOSONG (Biarkan saja agar file Designer tidak error)
        // ==========================================
        private void button4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblValueNama_Click(object sender, EventArgs e) { }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}