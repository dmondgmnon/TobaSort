using System;
using System.Data;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormKelolaHarga : Form
    {
        private GradeController _controller;
        private Akun _akun_aktif;

        public FormKelolaHarga(Akun akun_login)
        {
            InitializeComponent();
            _controller = new GradeController();
            _akun_aktif = akun_login;

            // Langsung muat data ke kartu saat form dibuka
            muat_harga_ke_kartu();
        }

        private void muat_harga_ke_kartu()
        {
            try
            {
                // Ambil data dari database melalui controller
                DataTable dt = _controller.tampil_semua_grade();

                // Cocokkan data dari tabel ke masing-masing TextBox
                foreach (DataRow row in dt.Rows)
                {
                    string grade = row["Grade"].ToString();
                    string harga = row["Harga/Kg (Rp)"].ToString();

                    if (grade == "A+") txtHargaAPlus.Text = harga;
                    else if (grade == "A") txtHargaA.Text = harga;
                    else if (grade == "B") txtHargaB.Text = harga;
                    else if (grade == "C") txtHargaC.Text = harga;
                    else if (grade == "D") txtHargaD.Text = harga;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat harga: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpanSemua_Click(object sender, EventArgs e)
        {
            // Validasi apakah ada textbox yang kosong
            if (string.IsNullOrWhiteSpace(txtHargaAPlus.Text) || string.IsNullOrWhiteSpace(txtHargaA.Text) ||
                string.IsNullOrWhiteSpace(txtHargaB.Text) || string.IsNullOrWhiteSpace(txtHargaC.Text) ||
                string.IsNullOrWhiteSpace(txtHargaD.Text))
            {
                MessageBox.Show("Harap isi semua harga grade terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Eksekusi update secara berurutan
                _controller.update_harga("A+", decimal.Parse(txtHargaAPlus.Text), _akun_aktif.id);
                _controller.update_harga("A", decimal.Parse(txtHargaA.Text), _akun_aktif.id);
                _controller.update_harga("B", decimal.Parse(txtHargaB.Text), _akun_aktif.id);
                _controller.update_harga("C", decimal.Parse(txtHargaC.Text), _akun_aktif.id);
                _controller.update_harga("D", decimal.Parse(txtHargaD.Text), _akun_aktif.id);

                MessageBox.Show("Seluruh harga grade berhasil diperbarui!\nSistem telah mencatat log perubahan ini.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh tampilan untuk memastikan data benar-benar tersimpan
                muat_harga_ke_kartu();
            }
            catch (FormatException)
            {
                MessageBox.Show("Format angka salah! Pastikan hanya memasukkan angka (tanpa titik atau koma).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kosongkan event lama jika Visual Studio masih merekamnya (Mencegah Error CS1061)
        private void btnSimpan_Click(object sender, EventArgs e) { }
        private void dgvGrade_CellClick(object sender, DataGridViewCellEventArgs e) { }
    }
}