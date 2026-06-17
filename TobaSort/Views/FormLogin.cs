using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormLogin : Form
    {
        private AuthController _controller;

        public FormLogin()
        {
            InitializeComponent();
            _controller = new AuthController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Akun akun_login = _controller.login(username, password);

                if (akun_login != null)
                {
                    FormDashboard dashboard = new FormDashboard(akun_login);

                    this.Hide();
                    dashboard.ShowDialog();
                    this.Show();

                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah, atau akun tidak aktif.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}