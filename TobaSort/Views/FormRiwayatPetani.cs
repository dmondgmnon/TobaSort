using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormRiwayatPetani : Form
    {
        private TransaksiController trx_controller;
        private Akun akun_petani;

        // Constructor menerima data akun yang sedang login
        public FormRiwayatPetani(Akun akun_login)
        {
            InitializeComponent();
            trx_controller = new TransaksiController();
            this.akun_petani = akun_login;

            // Panggil data langsung menggunakan nama lengkap dari akun
            muat_riwayat();
        }

        private void muat_riwayat()
        {
            try
            {
                dgvRiwayat.DataSource = trx_controller.tampil_riwayat_petani(akun_petani.nama_lengkap);

                if (dgvRiwayat.Columns.Contains("Total Uang (Rp)"))
                {
                    dgvRiwayat.Columns["Total Uang (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_riwayat();
        }
    }
}