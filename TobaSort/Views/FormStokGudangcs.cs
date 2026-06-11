using System;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormStokGudang : Form
    {
        private GudangController gudang_controller;

        public FormStokGudang()
        {
            InitializeComponent();
            gudang_controller = new GudangController();
            muat_stok();
        }

        private void muat_stok()
        {
            try
            {
                dgvStok.DataSource = gudang_controller.tampil_stok_gudang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_stok();
        }
    }
}