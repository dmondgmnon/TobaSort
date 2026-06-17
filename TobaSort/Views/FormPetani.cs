using System;
using System.Data;
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
            _controller = new PetaniController();

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

                dgvPetani.ClearSelection();
                bersihkan_form();
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
            cmbStatus.SelectedIndex = -1; 
            _id_petani_terpilih = 0;


            btnNonaktif.Text = "NONAKTIFKAN";
        }


        // TOMBOL TAMBAH (Fungsi Insert Data Baru)
        private void btnTambah_Click(object sender, EventArgs e)
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

                txtPassword.Clear(); 

                string statusDb = row.Cells["Status Aktif"].Value.ToString().ToLower();
                bool isAktif = (statusDb == "true" || statusDb == "1");

                if (isAktif)
                {
                    cmbStatus.SelectedIndex = 0; // Aktif
                    btnNonaktif.Text = "NONAKTIFKAN";
                }
                else
                {
                    cmbStatus.SelectedIndex = 1; // Non-Aktif
                    btnNonaktif.Text = "AKTIFKAN";
                }
            }
        }

        // TOMBOL SIMPAN (Fungsi Update/Edit Data)
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (_id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Nama Petani dan Username wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                bool statusDipilih = (cmbStatus.SelectedIndex == 0);

                bool sukses = _controller.edit_petani(
                    _id_petani_terpilih, txtNama.Text, txtAlamat.Text, txtNoTelp.Text,
                    txtUsername.Text, txtPassword.Text, statusDipilih
                );

                if (sukses)
                {
                    MessageBox.Show("Data profil petani berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    muat_data_tabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengedit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TOMBOL NONAKTIFKAN 
        private void btnNonaktif_Click(object sender, EventArgs e)
        {
            if (_id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool akanDiaktifkan = (btnNonaktif.Text == "AKTIFKAN");
            string pesanAksi = akanDiaktifkan ? "mengaktifkan kembali" : "menonaktifkan";

            DialogResult dialog = MessageBox.Show($"Apakah Anda yakin ingin {pesanAksi} akun petani ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    bool sukses = _controller.ubah_status_petani(_id_petani_terpilih, akanDiaktifkan);

                    if (sukses)
                    {
                        MessageBox.Show($"Selesai! Akun petani berhasil di-{pesanAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        muat_data_tabel();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TOMBOL BERSIHKAN & LAINNYA
        private void btnBersihkan_Click(object sender, EventArgs e) => bersihkan_form();

        private void btnMata_Click(object sender, EventArgs e)
        {
            if (this.Controls.Find("txtPassword", true).Length > 0)
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void lblKembali_Click(object sender, EventArgs e) => this.Close();

        private void FormPetani_Load(object sender, EventArgs e) { }

        private void dgvPetani_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Value != null)
            {
                if (dgvPetani.Columns[e.ColumnIndex].Name == "Status Aktif")
                {
                    string statusDb = e.Value.ToString().ToLower();
                    bool isAktif = (statusDb == "true" || statusDb == "1");

                    e.Value = isAktif ? "Aktif" : "Non-Aktif";
                    e.FormattingApplied = true;

                    if (isAktif)
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                        e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.DarkRed;
                        e.CellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }

                    if (e.CellStyle.Font != null)
                    {
                        e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);
                    }
                }
            }
        }
    }
}