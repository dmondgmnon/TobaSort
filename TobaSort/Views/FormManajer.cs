using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormManajer : Form
    {
        private AkunController _controller;
        private int _id_akun_terpilih = 0;

        public FormManajer()
        {
            InitializeComponent();

            // Inisialisasi controller dengan penamaan konsisten
            _controller = new AkunController();

            siapkan_dropdown();
            muat_data_akun();
        }

        private void siapkan_dropdown()
        {
            cmbRole.Items.Clear();
            // Nama role harus sama persis dengan yang ada di database dan FormDashboard
            cmbRole.Items.AddRange(new string[] { "Admin Gudang", "Petugas Grading" });
        }

        private void muat_data_akun()
        {
            try
            {
                // Mengambil data melalui controller tanpa menyentuh SQL
                dgvAkun.DataSource = _controller.tampil_semua_akun();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data akun: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Harap isi semua data (Role, Nama, Username, Password)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Melempar data ke controller
                bool sukses = _controller.tambah_akun(txtUsername.Text, txtPassword.Text, txtNama.Text, cmbRole.SelectedItem.ToString());

                if (sukses)
                {
                    MessageBox.Show("Akun berhasil dibuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Bersihkan kotak teks
                    txtNama.Clear();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    cmbRole.SelectedIndex = -1;
                    muat_data_akun(); // Refresh tabel
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan akun: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAkun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAkun.Rows[e.RowIndex];
                _id_akun_terpilih = Convert.ToInt32(row.Cells["id_akun"].Value);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (_id_akun_terpilih == 0)
            {
                MessageBox.Show("Klik salah satu akun di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Yakin ingin menonaktifkan akun ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    // Eksekusi nonaktif lewat controller
                    bool sukses = _controller.nonaktifkan_akun(_id_akun_terpilih);

                    if (sukses)
                    {
                        MessageBox.Show("Akun dinonaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _id_akun_terpilih = 0;
                        muat_data_akun();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menonaktifkan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_data_akun();
            txtNama.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
        }
    }
}