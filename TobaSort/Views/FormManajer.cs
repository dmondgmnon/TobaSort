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
            cmbStatus.SelectedIndex = -1;
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

                // PERBAIKAN: Baca status menggunakan Index agar kebal terhadap error teks
                string statusDb = row.Cells["Status Aktif"].Value.ToString().ToLower();
                bool isAktif = (statusDb == "true" || statusDb == "1");

                if (isAktif)
                {
                    cmbStatus.SelectedIndex = 0; // Pilih baris ke-1 (Aktif)
                    btnHapus.Text = "NONAKTIFKAN"; // Siapkan tombol untuk mematikan
                }
                else
                {
                    cmbStatus.SelectedIndex = 1; // Pilih baris ke-2 (Non-Aktif)
                    btnHapus.Text = "AKTIFKAN";    // Siapkan tombol untuk menghidupkan
                }

                btnSimpan.Text = "💾 UPDATE DATA AKUN";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Mohon lengkapi Nama, Username, Password, dan Role!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sukses = false;

                // PERBAIKAN: Cek status menggunakan Index (0 = Aktif)
                bool statusDipilih = (cmbStatus.SelectedIndex == 0);

                if (idAkunTerpilih == "")
                {
                    sukses = _controller.tambah_akun(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNama.Text.Trim(), cmbRole.Text);
                }
                else
                {
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

            // Baca aksi dari teks tombol saat ini
            bool akanDiaktifkan = (btnHapus.Text == "AKTIFKAN");
            string pesanAksi = akanDiaktifkan ? "mengaktifkan kembali" : "menonaktifkan";

            DialogResult dialog = MessageBox.Show($"Apakah Anda yakin ingin {pesanAksi} akun ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    // Eksekusi perubahan
                    bool sukses = _controller.ubah_status_akun(Convert.ToInt32(idAkunTerpilih), akanDiaktifkan);

                    if (sukses)
                    {
                        MessageBox.Show($"Selesai! Akun berhasil di-{pesanAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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