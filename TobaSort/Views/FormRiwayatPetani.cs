using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormRiwayatPetani : Form
    {
        private TransaksiController _controller;
        private Akun _akun_petani;

        public FormRiwayatPetani(Akun akun_login)
        {
            InitializeComponent();

            // Inisialisasi melalui Controller (Pola Arsitektur Baru)
            _controller = new TransaksiController();
            _akun_petani = akun_login;

            muat_riwayat();
        }

        private void muat_riwayat()
        {
            try
            {
                // Memanggil method dari Controller dengan ID petani
                dgvRiwayat.DataSource = _controller.tampil_riwayat_petani(_akun_petani.id);

                // Format angka untuk kolom uang
                if (dgvRiwayat.Columns.Contains("Total Uang (Rp)"))
                {
                    dgvRiwayat.Columns["Total Uang (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_riwayat();
        }
    }
}