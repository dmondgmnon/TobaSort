using System;
using System.Windows.Forms;
using TobaSort.Controllers;
using TobaSort.Models;

namespace TobaSort.Views
{
    public partial class FormLogin : Form
    {
        private AuthController auth_controller;

        public FormLogin()
        {
            InitializeComponent();
            auth_controller = new AuthController();
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
                Akun akun_login = auth_controller.login(username, password);

                if (akun_login != null)
                {
                    MessageBox.Show($"Selamat datang, {akun_login.nama_lengkap}!\nRole Anda: {akun_login.role}", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- KODE BARU: PINDAH KE DASHBOARD ---
                    FormDashboard dashboard = new FormDashboard(akun_login); // Kirim data akun ke dashboard
                    this.Hide();            // Sembunyikan form login
                    dashboard.ShowDialog(); // Tampilkan dashboard (sistem berhenti di sini sampai dashboard ditutup)
                    this.Show();            // Munculkan form login kembali setelah pengguna menekan tombol logout

                    // Bersihkan isian agar siap digunakan login orang lain
                    txtUsername.Clear();
                    txtPassword.Clear();
                    // --------------------------------------
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