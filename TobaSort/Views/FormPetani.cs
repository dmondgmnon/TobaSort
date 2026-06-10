using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormPetani : Form
    {
        private PetaniController petani_controller;
        private int id_petani_terpilih = 0; // Untuk menyimpan ID saat mengklik tabel

        public FormPetani()
        {
            InitializeComponent();
            petani_controller = new PetaniController();
            muat_data_tabel();
        }

        // 1. Fungsi memuat data ke DataGridView
        private void muat_data_tabel()
        {
            try
            {
                dgvPetani.DataSource = petani_controller.tampil_semua_petani();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Fungsi untuk membersihkan kotak input
        private void bersihkan_form()
        {
            txtNama.Clear();
            txtAlamat.Clear();
            txtNoTelp.Clear();
            id_petani_terpilih = 0; // Reset ID terpilih
        }

        // 3. Tombol Tambah Baru (Simpan)
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama Petani tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sukses = petani_controller.tambah_petani(txtNama.Text, txtAlamat.Text, txtNoTelp.Text);
            if (sukses)
            {
                MessageBox.Show("Data petani berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bersihkan_form();
                muat_data_tabel(); // Refresh tabel
            }
        }

        // 4. Memilih Data dari Tabel saat diklik (Untuk Edit/Hapus)
        private void dgvPetani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan baris yang diklik valid (bukan header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPetani.Rows[e.RowIndex];

                // Ambil ID dari kolom pertama (index 0)
                id_petani_terpilih = Convert.ToInt32(row.Cells["id_petani"].Value);

                // Isi kotak input dengan data dari tabel
                txtNama.Text = row.Cells["nama_petani"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                txtNoTelp.Text = row.Cells["no_telepon"].Value.ToString();
            }
        }

        // 5. Tombol Simpan Editan
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sukses = petani_controller.edit_petani(id_petani_terpilih, txtNama.Text, txtAlamat.Text, txtNoTelp.Text, true);
            if (sukses)
            {
                MessageBox.Show("Data petani berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bersihkan_form();
                muat_data_tabel();
            }
        }

        // 6. Tombol Nonaktifkan (Hapus)
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (id_petani_terpilih == 0)
            {
                MessageBox.Show("Pilih data petani dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Apakah Anda yakin ingin menonaktifkan petani ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                bool sukses = petani_controller.nonaktifkan_petani(id_petani_terpilih);
                if (sukses)
                {
                    MessageBox.Show("Petani berhasil dinonaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersihkan_form();
                    muat_data_tabel();
                }
            }
        }

        // 7. Tombol Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            bersihkan_form();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            // No action needed
        }
    }
}