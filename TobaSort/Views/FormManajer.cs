using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using TobaSort.Data;

namespace TobaSort.Views
{
    public partial class FormManajer : Form
    {
        private int id_akun_terpilih = 0;

        public FormManajer()
        {
            InitializeComponent();
            siapkan_dropdown();
            muat_data_akun();
        }

        // 1. Mengisi Pilihan Role di ComboBox (HANYA UNTUK INTERNAL)
        private void siapkan_dropdown()
        {
            cmbRole.Items.Clear();
            // Hanya ada Manajer dan Petugas (Petani dikelola di FormPetani)
            cmbRole.Items.AddRange(new string[] { "Manajer", "Petugas" });
        }

        // 2. Fungsi Menampilkan Daftar Akun ke DataGridView (DIFILTER)
        private void muat_data_akun()
        {
            try
            {
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Query difilter menggunakan WHERE role IN ('Manajer', 'Petugas')
                    string query = "SELECT id_akun, nama_lengkap AS \"Nama\", username AS \"Username\", role AS \"Role\", is_aktif AS \"Status Aktif\" FROM tb_akun WHERE role IN ('Manajer', 'Petugas') ORDER BY id_akun DESC";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAkun.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data akun: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Tombol SIMPAN / TAMBAH AKUN BARU
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
                using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO tb_akun (username, password, nama_lengkap, role, is_aktif) VALUES (@user, @pass, @nama, @role, true)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Akun berhasil dibuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bersihkan kotak teks
                txtNama.Clear(); txtUsername.Clear(); txtPassword.Clear(); cmbRole.SelectedIndex = -1;
                muat_data_akun(); // Refresh tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan akun: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Memilih Akun dari Tabel saat diklik (Untuk Dihapus)
        private void dgvAkun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAkun.Rows[e.RowIndex];
                id_akun_terpilih = Convert.ToInt32(row.Cells["id_akun"].Value);
            }
        }

        // 5. Tombol HAPUS / NONAKTIFKAN AKUN
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (id_akun_terpilih == 0)
            {
                MessageBox.Show("Klik salah satu akun di tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("Yakin ingin menonaktifkan akun ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE tb_akun SET is_aktif = false WHERE id_akun = @id";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id_akun_terpilih);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Akun dinonaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_akun_terpilih = 0;
                    muat_data_akun();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. Tombol REFRESH
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_data_akun();
            txtNama.Clear(); txtUsername.Clear(); txtPassword.Clear(); cmbRole.SelectedIndex = -1;
        }
    }
}