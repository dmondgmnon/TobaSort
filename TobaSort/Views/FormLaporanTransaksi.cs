using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormLaporanTransaksi : Form
    {
        private TransaksiController _controller;
        private DataTable _dtUtama;

        public FormLaporanTransaksi()
        {
            InitializeComponent();
            _controller = new TransaksiController();

            // TRIK OTOMATIS: Menghubungkan fungsi Enter tanpa lewat menu Petir (Designer)
            Control[] cariControls = this.Controls.Find("txtCari", true);
            if (cariControls.Length > 0)
            {
                TextBox txtCariOtomatis = (TextBox)cariControls[0];
                txtCariOtomatis.KeyPress += new KeyPressEventHandler(txtCari_KeyPress);
            }

            muat_laporan();
        }

        private void muat_laporan()
        {
            try
            {
                _dtUtama = _controller.tampil_riwayat_transaksi();
                dgvLaporan.DataSource = _dtUtama;

                if (dgvLaporan.Columns.Contains("Total Bayar (Rp)"))
                {
                    dgvLaporan.Columns["Total Bayar (Rp)"].DefaultCellStyle.Format = "N0";
                    dgvLaporan.Columns["Total Bayar (Rp)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                hitung_rekap_bawah();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hitung_rekap_bawah()
        {
            int totalBaris = dgvLaporan.Rows.Count;
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in dgvLaporan.Rows)
            {
                if (row.Cells["Total Bayar (Rp)"].Value != null && row.Cells["Total Bayar (Rp)"].Value.ToString() != "")
                {
                    grandTotal += Convert.ToDecimal(row.Cells["Total Bayar (Rp)"].Value);
                }
            }

            if (this.Controls.Find("lblTotalBaris", true).Length > 0)
                lblTotalBaris.Text = $"{totalBaris} Transactions";

            if (this.Controls.Find("lblGrandTotal", true).Length > 0)
                lblGrandTotal.Text = $"Rp {grandTotal.ToString("N0")}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (_dtUtama == null) return;

            try
            {
                // PERBAIKAN FINAL: Gunakan format AMERIKA (Bulan/Hari/Tahun) khusus untuk RowFilter
                string tglAwal = dtpAwal.Value.ToString("MM/dd/yyyy");
                string tglAkhir = dtpAkhir.Value.ToString("MM/dd/yyyy");

                // Menggunakan tanda pagar (#) agar C# tahu ini adalah tipe data Tanggal
                string filterText = $"[Tanggal] >= #{tglAwal} 00:00:00# AND [Tanggal] <= #{tglAkhir} 23:59:59#";

                if (this.Controls.Find("txtCari", true).Length > 0 && !string.IsNullOrWhiteSpace(txtCari.Text))
                {
                    string kataCari = txtCari.Text.Trim().Replace("'", "''");
                    filterText += $" AND ([ID Transaksi] LIKE '%{kataCari}%' OR [Nama Petani] LIKE '%{kataCari}%')";
                }

                _dtUtama.DefaultView.RowFilter = filterText;
                hitung_rekap_bawah();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mencari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.Controls.Find("txtCari", true).Length > 0) txtCari.Clear();
            dtpAwal.Value = DateTime.Now.AddMonths(-1);
            dtpAkhir.Value = DateTime.Now;

            if (_dtUtama != null) _dtUtama.DefaultView.RowFilter = string.Empty;
            hitung_rekap_bawah();
        }

        private void dgvLaporan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                string nilai = e.Value.ToString().ToUpper();
                string namaKolom = dgvLaporan.Columns[e.ColumnIndex].Name;

                if (namaKolom == "Grade")
                {
                    if (nilai.Contains("A") || nilai.Contains("B+")) e.CellStyle.ForeColor = Color.ForestGreen;
                    else if (nilai == "C" || nilai == "D") e.CellStyle.ForeColor = Color.OrangeRed;
                    e.CellStyle.Font = new Font(dgvLaporan.Font, FontStyle.Bold);
                }

                if (namaKolom == "Veto?")
                {
                    if (nilai == "YES" || nilai == "YA" || nilai == "TRUE")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(dgvLaporan.Font, FontStyle.Bold);
                    }
                }
            }
        }

        // FUNGSI BARU: Tekan Enter untuk mencari tanpa bunyi "ding"
        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Mematikan bunyi "ding" Windows
                btnFilter_Click(sender, e); // Langsung jalankan filter pencarian
            }
        }

        // Event Kosong Pencegah Error
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label1_Click_2(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click_3(object sender, EventArgs e) { }
        private void btnCari_Click(object sender, EventArgs e) { btnFilter_Click(sender, e); }
        private void btnRefresh_Click(object sender, EventArgs e) { btnReset_Click(sender, e); }
    }
}