using System;
using System.Windows.Forms;
using TobaSort.Models;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormTransaksi : Form
    {
        private Akun _akun_petugas;
        private PetaniController _petani_controller;
        private TransaksiController _trx_controller;

        public FormTransaksi(Akun akun_aktif)
        {
            InitializeComponent();

            // Inisialisasi melalui Controller (Pola Arsitektur Baru)
            this._akun_petugas = akun_aktif;
            this._petani_controller = new PetaniController();
            this._trx_controller = new TransaksiController();

            siapkan_pilihan_dropdown();
            muat_data_petani();
        }

        private void muat_data_petani()
        {
            try
            {
                var dtPetani = _petani_controller.tampil_semua_petani();
                cmbPetani.DataSource = dtPetani;
                cmbPetani.DisplayMember = "Nama Petani";
                cmbPetani.ValueMember = "id_petani";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data petani: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siapkan_pilihan_dropdown()
        {
            cmbWarna.Items.AddRange(new string[] { "Keemasan (25)", "Kurang merata (15)", "Kusam (5)" });
            cmbTekstur.Items.AddRange(new string[] { "Lentur/Padat (25)", "Kurang seragam (15)", "Kaku/Rapuh (5)" });
            cmbAroma.Items.AddRange(new string[] { "Harum/Gurih (20)", "Biasa (10)", "Hambar (5)" });
            cmbPosisi.Items.AddRange(new string[] { "Tengah (15)", "Atas (10)", "Bawah (5)" });
            cmbFisik.Items.AddRange(new string[] { "Utuh (15)", "Cacat Ringan (5)" });
        }

        private void CekStatusVeto(object sender, EventArgs e)
        {
            bool isVeto = chkBerjamur.Checked || chkBauAsing.Checked || chkSangatBasah.Checked;

            cmbWarna.Enabled = !isVeto;
            cmbTekstur.Enabled = !isVeto;
            cmbAroma.Enabled = !isVeto;
            cmbPosisi.Enabled = !isVeto;
            cmbFisik.Enabled = !isVeto;

            if (isVeto)
            {
                lblTotalPoin.Text = "Total Poin: 0 (Veto)";
                lblGrade.Text = "Grade: D (Afkir)";
            }
            else
            {
                lblTotalPoin.Text = "Total Poin: 0";
                lblGrade.Text = "Grade: -";
            }
        }

        private int AmbilAngkaDariTeks(string teks)
        {
            try
            {
                int startIndex = teks.IndexOf('(') + 1;
                int endIndex = teks.IndexOf(')');
                return Convert.ToInt32(teks.Substring(startIndex, endIndex - startIndex));
            }
            catch { return 0; }
        }

        private void txtBerat_TextChanged(object sender, EventArgs e)
        {
            // No-op handler to satisfy designer event wiring. Input validation is handled elsewhere.
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            if (chkBerjamur.Checked || chkBauAsing.Checked || chkSangatBasah.Checked)
            {
                lblTotalPoin.Text = "Total Poin: 0";
                lblGrade.Text = "Grade: D (Afkir)";
                return;
            }

            if (cmbWarna.SelectedIndex == -1 || cmbTekstur.SelectedIndex == -1 ||
                cmbAroma.SelectedIndex == -1 || cmbPosisi.SelectedIndex == -1 || cmbFisik.SelectedIndex == -1)
            {
                MessageBox.Show("Harap pilih semua kriteria penilaian!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalPoin = AmbilAngkaDariTeks(cmbWarna.Text) + AmbilAngkaDariTeks(cmbTekstur.Text) +
                            AmbilAngkaDariTeks(cmbAroma.Text) + AmbilAngkaDariTeks(cmbPosisi.Text) +
                            AmbilAngkaDariTeks(cmbFisik.Text);

            lblTotalPoin.Text = $"Total Poin: {totalPoin}";

            string grade = totalPoin >= 90 ? "A+ (Super)" : totalPoin >= 75 ? "A (Premium)" :
                           totalPoin >= 60 ? "B (Medium)" : totalPoin >= 45 ? "C (Standar)" : "D (Afkir)";
            lblGrade.Text = $"Grade: {grade}";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbPetani.SelectedValue == null || string.IsNullOrWhiteSpace(txtBerat.Text) || lblGrade.Text == "Grade: -")
            {
                MessageBox.Show("Lengkapi data petani, berat, dan hitung grade terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string id_trx = "TRX-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                int id_petani = Convert.ToInt32(cmbPetani.SelectedValue);
                bool veto = chkBerjamur.Checked || chkBauAsing.Checked || chkSangatBasah.Checked;

                int total_poin = veto ? 0 : int.Parse(lblTotalPoin.Text.Replace("Total Poin: ", ""));
                string id_grade = lblGrade.Text.Replace("Grade: ", "").Substring(0, 1) == "A" && lblGrade.Text.Contains("+") ? "A+" : lblGrade.Text.Replace("Grade: ", "").Substring(0, 1);

                int[] poin = veto ? new int[5] : new int[] { AmbilAngkaDariTeks(cmbWarna.Text), AmbilAngkaDariTeks(cmbTekstur.Text), AmbilAngkaDariTeks(cmbAroma.Text), AmbilAngkaDariTeks(cmbPosisi.Text), AmbilAngkaDariTeks(cmbFisik.Text) };

                bool sukses = _trx_controller.simpan_transaksi_penyortiran(id_trx, id_petani, this._akun_petugas.id, veto, total_poin, id_grade, decimal.Parse(txtBerat.Text), new string[] { "WARNA", "TEKSTUR", "AROMA", "POSISI", "FISIK" }, poin);

                if (sukses)
                {
                    MessageBox.Show("Transaksi Berhasil Disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset form... (tambahkan kode reset di sini)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}