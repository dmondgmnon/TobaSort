using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormRiwayatPetani : Form
    {
        private TransaksiController _controller;
        private Akun _akun_petani;
        private DataTable _dtRiwayat;

        public FormRiwayatPetani(Akun akun_login)
        {
            InitializeComponent();

            _controller = new TransaksiController();
            _akun_petani = akun_login;

            muat_riwayat();

            if (this.Controls.Find("txtCari", true).Length > 0)
            {
                TextBox txtSearch = (TextBox)this.Controls.Find("txtCari", true)[0];
                txtSearch.TextChanged += new EventHandler(txtCari_TextChanged);
            }
        }

        private void muat_riwayat()
        {
            try
            {
                _dtRiwayat = _controller.tampil_riwayat_petani(_akun_petani.id);
                dgvRiwayat.DataSource = _dtRiwayat;

                lblTotalSetoran.Text = $"{_dtRiwayat.Rows.Count} KALI";

                if (dgvRiwayat.Columns.Contains("Total Uang (Rp)"))
                {
                    dgvRiwayat.Columns["Total Uang (Rp)"].DefaultCellStyle.Format = "N0";
                    dgvRiwayat.Columns["Total Uang (Rp)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void label2_Click(object sender, EventArgs e) { }

        private void dgvRiwayat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;

            string namaKolom = dgvRiwayat.Columns[e.ColumnIndex].Name;

            // 1. Kotak Grade Berwarna
            if (namaKolom == "Grade")
            {
                string grade = e.Value.ToString();
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font(dgvRiwayat.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (grade.Contains("A"))
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (grade.Contains("B"))
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                }
            }

            // 2. Warna uang jadi hijau
            if (namaKolom == "Total Uang (Rp)")
            {
                e.CellStyle.ForeColor = Color.SeaGreen;
                e.CellStyle.Font = new Font(dgvRiwayat.Font, FontStyle.Bold);
            }

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (_dtRiwayat != null)
            {
                string kataCari = ((TextBox)sender).Text.Trim().Replace("'", "''");
                _dtRiwayat.DefaultView.RowFilter = $"[ID Transaksi] LIKE '%{kataCari}%'";
            }
        }
    }
}