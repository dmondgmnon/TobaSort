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
            lblJudulDashboard.Text = $"Dashboard {akun_aktif.role}";
            lblValueId.Text = akun_aktif.id.ToString();
            lblValueNama.Text = akun_aktif.nama_lengkap.ToUpper();
            lblValueRole.Text = akun_aktif.role;
            lblValueStatus.Text = "● Aktif";
            lblValueStatus.ForeColor = Color.ForestGreen;

            // Tutup semua akses tombol terlebih dahulu (Keamanan)
            btnMenuManajer.Visible = false;
            btnMenuPetugas.Visible = false;
            btnMenuPetani.Visible = false;
            btnKelolaPetani.Visible = false;
            btnLaporan.Visible = false;
            btnStokGudang.Visible = false;
            btnKelolaHarga.Visible = false;

            // SESUAIKAN DENGAN NAMA ROLE DI DATABASE ANDA
            if (akun_aktif.role == "Admin Gudang")
            {
                btnMenuManajer.Visible = true;
                btnKelolaPetani.Visible = true;
                btnLaporan.Visible = true;
                btnStokGudang.Visible = true;
                btnKelolaHarga.Visible = true;
            }
            else if (akun_aktif.role == "Petugas Grading")
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
            int jarak_y = 200;
            Button[] semua_tombol = { btnMenuManajer, btnKelolaHarga, btnKelolaPetani, btnStokGudang, btnLaporan, btnMenuPetugas, btnMenuPetani };

            foreach (Button btn in semua_tombol)
            {
                if (btn != null && btn.Visible)
                {
                    btn.Top = jarak_y;
                    jarak_y += btn.Height + 15;
                }
            }

            if (btnLogout != null)
            {
                btnLogout.Top = this.ClientSize.Height - btnLogout.Height - 40;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuManajer_Click(object sender, EventArgs e) { new FormManajer().ShowDialog(); }
        private void btnMenuPetugas_Click(object sender, EventArgs e) { new FormTransaksi(akun_aktif).ShowDialog(); }
        private void btnKelolaPetani_Click(object sender, EventArgs e) { new FormPetani().ShowDialog(); }
        private void btnLaporan_Click(object sender, EventArgs e) { new FormLaporanTransaksi().ShowDialog(); }
        private void btnStokGudang_Click(object sender, EventArgs e) { new FormStokGudang().ShowDialog(); }
        private void btnMenuPetani_Click(object sender, EventArgs e) { new FormRiwayatPetani(akun_aktif).ShowDialog(); }
        private void btnKelolaHarga_Click(object sender, EventArgs e) { new FormKelolaHarga(akun_aktif).ShowDialog(); }

        private void button4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblValueNama_Click(object sender, EventArgs e) { }
        private void FormDashboard_Load(object sender, EventArgs e) { }
    }
}