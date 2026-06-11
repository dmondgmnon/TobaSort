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

            // Memuat riwayat transaksi berdasarkan id_akun petani
            muat_riwayat();
        }

        private void muat_riwayat()
        {
            try
            {
                // UPDATE: Mengirimkan akun_petani.id (int) sesuai dengan TransaksiController yang baru
                dgvRiwayat.DataSource = trx_controller.tampil_riwayat_petani(akun_petani.id);

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