using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormKelolaHarga : Form
    {
        private GradeController grade_controller;
        private Akun akun_manajer;
        private string id_grade_terpilih = "";

        // Constructor wajib menerima Akun login agar kita tahu siapa Manajer yang mengubah harga
        public FormKelolaHarga(Akun akun_login)
        {
            InitializeComponent();
            grade_controller = new GradeController();
            this.akun_manajer = akun_login;

            muat_data_tabel();
        }

        private void muat_data_tabel()
        {
            try
            {
                dgvGrade.DataSource = grade_controller.tampil_semua_grade();

                // Rapikan format angka uang menjadi ribuan
                if (dgvGrade.Columns.Contains("Harga/Kg (Rp)"))
                {
                    dgvGrade.Columns["Harga/Kg (Rp)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event saat tabel diklik
        private void dgvGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGrade.Rows[e.RowIndex];

                // Ambil ID Grade (Contoh: "A+") dan tampilkan ke label dan textbox
                id_grade_terpilih = row.Cells["Grade"].Value.ToString();
                string keterangan = row.Cells["Keterangan"].Value.ToString();

                lblGradeTerpilih.Text = $"Grade Terpilih: {id_grade_terpilih} ({keterangan})";
                txtHargaBaru.Text = row.Cells["Harga/Kg (Rp)"].Value.ToString();
            }
        }

        // Event saat tombol Simpan/Update ditekan
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_grade_terpilih))
            {
                MessageBox.Show("Pilih grade tembakau dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah yang diinput adalah angka yang valid
            if (!decimal.TryParse(txtHargaBaru.Text, out decimal harga_baru) || harga_baru < 0)
            {
                MessageBox.Show("Masukkan nominal harga yang valid (hanya angka)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Eksekusi update harga
                bool sukses = grade_controller.update_harga(id_grade_terpilih, harga_baru, akun_manajer.id);

                if (sukses)
                {
                    MessageBox.Show("Harga berhasil di-update!\nSistem telah mencatat log perubahan harga ini secara otomatis.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Bersihkan form
                    id_grade_terpilih = "";
                    lblGradeTerpilih.Text = "Grade Terpilih: -";
                    txtHargaBaru.Clear();
                    muat_data_tabel(); // Refresh tabel harga
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}