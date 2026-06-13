using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormKelolaHarga : Form
    {
        private GradeController _controller;
        private Akun _akun_aktif;
        private string _id_grade_terpilih = "";

        public FormKelolaHarga(Akun akun_login)
        {
            InitializeComponent();

            // Inisialisasi melalui Controller (Pola Arsitektur Baru)
            _controller = new GradeController();
            _akun_aktif = akun_login;

            muat_data_tabel();
        }

        private void muat_data_tabel()
        {
            try
            {
                // Memanggil method dari Controller
                dgvGrade.DataSource = _controller.tampil_semua_grade();

                // Formatting tampilan angka
                if (dgvGrade.Columns.Contains("Harga/Kg (Rp)"))
                {
                    dgvGrade.Columns["Harga/Kg (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data grade: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrade.Rows[e.RowIndex];

                _id_grade_terpilih = row.Cells["Grade"].Value.ToString();
                string keterangan = row.Cells["Keterangan"].Value.ToString();

                lblGradeTerpilih.Text = $"Grade Terpilih: {_id_grade_terpilih} ({keterangan})";
                txtHargaBaru.Text = row.Cells["Harga/Kg (Rp)"].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_id_grade_terpilih))
            {
                MessageBox.Show("Pilih grade tembakau dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtHargaBaru.Text, out decimal harga_baru) || harga_baru < 0)
            {
                MessageBox.Show("Masukkan nominal harga yang valid (hanya angka)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Eksekusi Update melalui Controller
                bool sukses = _controller.update_harga(_id_grade_terpilih, harga_baru, _akun_aktif.id);

                if (sukses)
                {
                    MessageBox.Show("Harga berhasil di-update!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset Form
                    _id_grade_terpilih = "";
                    lblGradeTerpilih.Text = "Grade Terpilih: -";
                    txtHargaBaru.Clear();
                    muat_data_tabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}