using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormStokGudang : Form
    {
        private GudangController _controller;

        public FormStokGudang()
        {
            InitializeComponent();

            // Inisialisasi melalui Controller (Pola Arsitektur Baru)
            _controller = new GudangController();

            muat_stok();
        }

        private void muat_stok()
        {
            try
            {
                // Memanggil method dari Controller
                dgvStok.DataSource = _controller.tampil_stok_gudang();

                // Tambahan agar kolom otomatis melar memenuhi ruang
                dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Memuat ulang data dari database
            muat_stok();

            // Menampilkan popup notifikasi
            MessageBox.Show("Data berhasil di-refresh!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}