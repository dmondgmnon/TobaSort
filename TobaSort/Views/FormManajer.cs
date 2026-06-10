using System;
using System.Data;
using System.Windows.Forms;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormManajer : Form
    {
        private AkunController akun_controller;

        public FormManajer()
        {
            InitializeComponent();
            akun_controller = new AkunController();
            muat_data_akun(); // Panggil fungsi saat form pertama muncul
        }

        private void muat_data_akun()
        {
            try
            {
                dgvAkun.DataSource = akun_controller.tampil_semua_akun();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hubungkan tombol refresh ke fungsi muat_data_akun
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            muat_data_akun();
        }
    }
}