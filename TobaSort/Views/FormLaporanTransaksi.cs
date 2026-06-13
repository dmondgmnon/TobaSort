using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormLaporanTransaksi : Form
    {
        private TransaksiController _controller;

        public FormLaporanTransaksi()
        {
            InitializeComponent();

            // Inisialisasi melalui Controller (Pola Arsitektur Baru)
            _controller = new TransaksiController();

            // Otomatis memuat data saat form pertama kali dibuka
            muat_laporan();
        }

        // Fungsi memanggil data dari controller
        private void muat_laporan()
        {
            try
            {
                dgvLaporan.DataSource = _controller.tampil_riwayat_transaksi();

                // Format kolom uang menjadi format ribuan
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_laporan();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tanggalAwal = dtpAwal.Value;
                DateTime tanggalAkhir = dtpAkhir.Value;

                if (tanggalAwal > tanggalAkhir)
                {
                    MessageBox.Show("Tanggal awal tidak boleh melewati tanggal akhir!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Memanggil method Overloading dari Controller
                dgvLaporan.DataSource = _controller.tampil_riwayat_berdasarkan_tanggal(tanggalAwal, tanggalAkhir);

                // Rapikan format uang
                if (dgvLaporan.Columns.Contains("Total Bayar (Rp)"))
                {
                    dgvLaporan.Columns["Total Bayar (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mencari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event kosong untuk mencegah error wiring designer
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}