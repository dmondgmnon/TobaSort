using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormLaporanTransaksi : Form
    {
        private TransaksiController trx_controller;

        public FormLaporanTransaksi()
        {
            InitializeComponent();
            trx_controller = new TransaksiController();

            // Otomatis memuat data saat form pertama kali dibuka
            muat_laporan();
        }

        // Fungsi memanggil data dari controller
        private void muat_laporan()
        {
            try
            {
                dgvLaporan.DataSource = trx_controller.tampil_riwayat_transaksi();

                // Opsional: Merapikan tampilan kolom uang menjadi format ribuan
                if (dgvLaporan.Columns.Contains("Total Bayar (Rp)"))
                {
                    dgvLaporan.Columns["Total Bayar (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event saat tombol ditekan
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_laporan();
        }

        // Event handler for label click (wired in Designer). Kept empty to satisfy designer wiring.
        private void label1_Click(object sender, EventArgs e)
        {
            // Intentionally left blank. No action needed when label is clicked.
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                // Mengambil nilai tanggal dari kedua kalender
                DateTime tanggalAwal = dtpAwal.Value;
                DateTime tanggalAkhir = dtpAkhir.Value;

                // Pastikan tanggal awal tidak lebih besar dari tanggal akhir
                if (tanggalAwal > tanggalAkhir)
                {
                    MessageBox.Show("Tanggal awal tidak boleh melewati tanggal akhir!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Panggil fungsi filter dari controller
                dgvLaporan.DataSource = trx_controller.tampil_riwayat_berdasarkan_tanggal(tanggalAwal, tanggalAkhir);

                // Rapikan format uang
                if (dgvLaporan.Columns.Contains("Total Bayar (Rp)"))
                {
                    dgvLaporan.Columns["Total Bayar (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
