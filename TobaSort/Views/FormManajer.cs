using System;
using System.Data;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormManajer : Form
    {
        private AkunController _controller;
        private string idAkunTerpilih = "";

        public FormManajer()
        {
            InitializeComponent();
            _controller = new AkunController();

            // Menyembunyikan password saat form pertama kali dibuka
            if (this.Controls.Find("txtPassword", true).Length > 0)
            {
                txtPassword.UseSystemPasswordChar = true;
            }

            MuatDataAkun();
        }

        // ====================================================
        // 1. FUNGSI TAMPIL DATA KE TABEL
        // ====================================================
        private void MuatDataAkun()
        {
            try
            {
                dgvAkun.DataSource = _controller.tampil_semua_akun();
                dgvAkun.ClearSelection();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data akun: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================
        // 2. FITUR RESET FORM
        // ====================================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        private void BersihkanForm()
        {
            idAkunTerpilih = "";
            if (this.Controls.Find("txtNama", true).Length > 0) txtNama.Clear();
            if (this.Controls.Find("txtUsername", true).Length > 0) txtUsername.Clear();
            if (this.Controls.Find("txtPassword", true).Length > 0) txtPassword.Clear();
            if (this.Controls.Find("cmbRole", true).Length > 0) cmbRole.SelectedIndex = -1;

            if (this.Controls.Find("btnSimpan", true).Length > 0) btnSimpan.Text = "💾 SIMPAN PERUBAHAN DATA";
        }

        // ====================================================
        // 3. FITUR IKON MATA (LIHAT/SEMBUNYIKAN PASSWORD)
        // ====================================================
        private void btnMata_Click(object sender, EventArgs e)
        {
            if (this.Controls.Find("txtPassword", true).Length > 0)
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            }
        }

        // ====================================================
        // 4. FITUR KLIK TABEL (MEMASUKKAN DATA KE FORM)
        // ====================================================
        private void dgvAkun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAkun.Rows[e.RowIndex];

                idAkunTerpilih = row.Cells["id_akun"].Value.ToString();
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();

                txtPassword.Clear();
                btnSimpan.Text = "💾 UPDATE DATA AKUN";
            }
        }

        // ====================================================
        // 5. FITUR SIMPAN / UPDATE DATA
        // ====================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Mohon lengkapi semua kolom (termasuk password) sebelum menyimpan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sukses = false;

                if (idAkunTerpilih == "")
                {
                    // MODE TAMBAH BARU
                    sukses = _controller.tambah_akun(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNama.Text.Trim(), cmbRole.Text);
                }
                else
                {
                    // MODE UPDATE (EDIT)
                    sukses = _controller.ubah_akun(Convert.ToInt32(idAkunTerpilih), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNama.Text.Trim(), cmbRole.Text);
                }

                if (sukses)
                {
                    MessageBox.Show("Data akun berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataAkun();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================
        // 6. FITUR HAPUS DATA (SOFT DELETE)
        // ====================================================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idAkunTerpilih == "")
            {
                MessageBox.Show("Silakan klik salah satu akun di tabel terlebih dahulu untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus akun {txtNama.Text}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool sukses = _controller.nonaktifkan_akun(Convert.ToInt32(idAkunTerpilih));
                    if (sukses)
                    {
                        MessageBox.Show("Akun berhasil dihapus (dinonaktifkan)!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MuatDataAkun();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}