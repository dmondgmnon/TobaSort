using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormPetani : Form
    {
        private PetaniController _controller;
        private int _id_petani_terpilih = 0;

        public FormPetani()
        {
            InitializeComponent();

            // Inisialisasi melalui Controller
            _controller = new PetaniController();

            // Menyembunyikan password saat form pertama kali dibuka
            if (this.Controls.Find("txtPassword", true).Length > 0)
            {
                txtPassword.UseSystemPasswordChar = true;
            }

            muat_data_tabel();
        }

        private void muat_data_tabel()
        {
            try
            {
                dgvPetani.DataSource = _controller.tampil_semua_petani();

                if (dgvPetani.Columns.Contains("id_petani"))
                    dgvPetani.Columns["id_petani"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bersihkan_form()
        {
            txtNama.Clear();
            txtAlamat.Clear();
            txtNoTelp.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            chkAktif.Checked = true;
            _id_petani_terpilih = 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Nama Petani, Username, dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sukses = _controller.tambah_petani(txtNama.Text, txtAlamat.Text, txtNoTelp.Text, txtUsername.Text, txtPassword.Text);
                if (sukses)
                {
                    MessageBox.Show("Data petani berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan_form();
                    muat_data_tabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPetani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPetani.Rows[e.RowIndex];
                _id_petani_terpilih = Convert.ToInt32(row.Cells["id_petani"].Value);

                txtNama.Text = row.Cells["Nama Petani"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtNoTelp.Text = row.Cells["No. Telepon"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                chkAktif.Checked = Convert.ToBoolean(row.Cells["Status Aktif"].Value);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool sukses = _controller.edit_petani(
                    _id_petani_terpilih, txtNama.Text, txtAlamat.Text, txtNoTelp.Text,
                    txtUsername.Text, txtPassword.Text, chkAktif.Checked
                );

                if (sukses)
                {
                    MessageBox.Show("Data petani berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan_form();
                    muat_data_tabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengedit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (_id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Apakah Anda yakin ingin menonaktifkan akun petani ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    bool sukses = _controller.nonaktifkan_petani(_id_petani_terpilih);
                    if (sukses)
                    {
                        MessageBox.Show("Akses login petani berhasil dinonaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bersihkan_form();
                        muat_data_tabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menonaktifkan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bersihkan_form();
        }

        // ====================================================
        // FITUR TAMBAHAN: IKON MATA & KEMBALI
        // ====================================================
        private void btnMata_Click(object sender, EventArgs e)
        {
            if (this.Controls.Find("txtPassword", true).Length > 0)
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            }
        }

        private void lblKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}