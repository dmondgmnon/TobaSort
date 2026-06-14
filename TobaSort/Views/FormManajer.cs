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

            if (this.Controls.Find("txtPassword", true).Length > 0)
                txtPassword.UseSystemPasswordChar = true;

            MuatDataAkun();
        }

        private void MuatDataAkun()
        {
            try
            {
                dgvAkun.DataSource = _controller.tampil_semua_akun();
                if (dgvAkun.Columns.Contains("id_akun")) dgvAkun.Columns["id_akun"].Visible = false;
                dgvAkun.ClearSelection();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BersihkanForm()
        {
            idAkunTerpilih = "";
            txtNama.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1; // Reset agar validasi berjalan
            btnSimpan.Text = "💾 SIMPAN PERUBAHAN DATA";
            btnHapus.Text = "NONAKTIFKAN";
        }

        private void dgvAkun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAkun.Rows[e.RowIndex];
                idAkunTerpilih = row.Cells["id_akun"].Value.ToString();

                txtNama.Text = row.Cells["Nama Lengkap"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
                txtPassword.Clear();

                // Sinkronisasi status ke ComboBox
                string statusDb = row.Cells["Status Aktif"].Value.ToString().ToLower();
                cmbStatus.Text = (statusDb == "true" || statusDb == "1") ? "Aktif" : "Non-Aktif";

                // Smart Button Logic: Tombol menyesuaikan diri
                btnHapus.Text = (cmbStatus.Text == "Aktif") ? "NONAKTIFKAN" : "AKTIFKAN";
                btnSimpan.Text = "💾 UPDATE DATA AKUN";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi hanya untuk kolom profil (tidak wajib cek ComboBox status lagi)
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Mohon lengkapi Nama, Username, Password, dan Role!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sukses = false;

                // Membaca teks di ComboBox (mendukung huruf kapital maupun kecil)
                bool statusDipilih = (cmbStatus.Text == "Aktif" || cmbStatus.Text == "aktif");

                if (idAkunTerpilih == "")
                {
                    // Tambah baru
                    sukses = _controller.tambah_akun(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNama.Text.Trim(), cmbRole.Text);
                }
                else
                {
                    // Update profil dengan tetap mengirimkan status terakhir yang ada di ComboBox
                    sukses = _controller.ubah_akun(Convert.ToInt32(idAkunTerpilih), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNama.Text.Trim(), cmbRole.Text, statusDipilih);
                }

                if (sukses)
                {
                    MessageBox.Show("Data profil akun berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataAkun();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idAkunTerpilih))
            {
                MessageBox.Show("Silakan klik salah satu akun di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PERBAIKAN LOGIKA: Gunakan teks tombol saat ini untuk menentukan aksi
            bool akanDiaktifkan = (btnHapus.Text == "AKTIFKAN");
            string pesanAksi = akanDiaktifkan ? "mengaktifkan kembali" : "menonaktifkan";

            DialogResult dialog = MessageBox.Show($"Apakah Anda yakin ingin {pesanAksi} akun ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    // Kirim perintah boolean yang benar ke Jembatan (Controller)
                    bool sukses = _controller.ubah_status_akun(Convert.ToInt32(idAkunTerpilih), akanDiaktifkan);

                    if (sukses)
                    {
                        MessageBox.Show($"Selesai! Akun berhasil di-{pesanAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh data di tabel dan bersihkan form
                        MuatDataAkun();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => BersihkanForm();

        private void btnMata_Click(object sender, EventArgs e) => txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
    }
}