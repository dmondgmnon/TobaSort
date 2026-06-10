using System;
using System.Windows.Forms;
using TobaSort.Models;
using TobaSort.Controllers;

namespace TobaSort.Views
{
    public partial class FormTransaksi : Form
    {
        private Akun akun_petugas;
        private PetaniController petani_controller;
        private TransaksiController trx_controller;

        public FormTransaksi(Akun akun_aktif)
        {
            InitializeComponent();
            this.akun_petugas = akun_aktif;
            this.petani_controller = new PetaniController();
            this.trx_controller = new TransaksiController();

            siapkan_pilihan_dropdown();
            muat_data_petani();
        }

        // 1. Mengambil data nama petani dari database
        private void muat_data_petani()
        {
            try
            {
                var dtPetani = petani_controller.tampil_semua_petani();
                cmbPetani.DataSource = dtPetani;
                cmbPetani.DisplayMember = "nama_petani"; // Teks yang dilihat petugas
                cmbPetani.ValueMember = "id_petani";     // Nilai ID yang disimpan ke database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data petani: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Mengisi pilihan kriteria kualitas daun
        private void siapkan_pilihan_dropdown()
        {
            cmbWarna.Items.AddRange(new string[] { "Keemasan (25)", "Kurang merata (15)", "Kusam (5)" });
            cmbTekstur.Items.AddRange(new string[] { "Lentur/Padat (25)", "Kurang seragam (15)", "Kaku/Rapuh (5)" });
            cmbAroma.Items.AddRange(new string[] { "Harum/Gurih (20)", "Biasa (10)", "Hambar (5)" });
            cmbPosisi.Items.AddRange(new string[] { "Tengah (15)", "Atas (10)", "Bawah (5)" });
            cmbFisik.Items.AddRange(new string[] { "Utuh (15)", "Cacat Ringan (5)" });
        }

        // 3. Fungsi untuk mengecek status Veto dari ketiga Checkbox
        private void CekStatusVeto(object sender, EventArgs e)
        {
            if (chkBerjamur.Checked || chkBauAsing.Checked || chkSangatBasah.Checked)
            {
                cmbWarna.Enabled = false;
                cmbTekstur.Enabled = false;
                cmbAroma.Enabled = false;
                cmbPosisi.Enabled = false;
                cmbFisik.Enabled = false;

                lblTotalPoin.Text = "Total Poin: 0 (Veto)";
                lblGrade.Text = "Grade: D (Afkir)";
            }
            else
            {
                cmbWarna.Enabled = true;
                cmbTekstur.Enabled = true;
                cmbAroma.Enabled = true;
                cmbPosisi.Enabled = true;
                cmbFisik.Enabled = true;

                lblTotalPoin.Text = "Total Poin: 0";
                lblGrade.Text = "Grade: -";
            }
        }

        // 4. Fungsi Bantuan: Untuk mengambil angka di dalam tanda kurung
        private int AmbilAngkaDariTeks(string teks)
        {
            try
            {
                int startIndex = teks.IndexOf('(') + 1;
                int endIndex = teks.IndexOf(')');
                string angkaString = teks.Substring(startIndex, endIndex - startIndex);
                return Convert.ToInt32(angkaString);
            }
            catch
            {
                return 0;
            }
        }

        // 5. Fungsi Utama untuk Tombol Hitung
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
                MessageBox.Show("Harap pilih semua kriteria penilaian (Warna, Tekstur, Aroma, Posisi, Fisik) terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int poinWarna = AmbilAngkaDariTeks(cmbWarna.Text);
            int poinTekstur = AmbilAngkaDariTeks(cmbTekstur.Text);
            int poinAroma = AmbilAngkaDariTeks(cmbAroma.Text);
            int poinPosisi = AmbilAngkaDariTeks(cmbPosisi.Text);
            int poinFisik = AmbilAngkaDariTeks(cmbFisik.Text);

            int totalPoin = poinWarna + poinTekstur + poinAroma + poinPosisi + poinFisik;
            lblTotalPoin.Text = $"Total Poin: {totalPoin}";

            string grade = "-";
            if (totalPoin >= 90) grade = "A+ (Super)";
            else if (totalPoin >= 75) grade = "A (Premium)";
            else if (totalPoin >= 60) grade = "B (Medium)";
            else if (totalPoin >= 45) grade = "C (Standar)";
            else grade = "D (Afkir)";

            lblGrade.Text = $"Grade: {grade}";
        }

        // 6. Fungsi Utama untuk Tombol Simpan Transaksi 
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // --- KODE UNTUK MENCEGAH ERROR PETANI KOSONG ---
            if (cmbPetani.SelectedValue == null)
            {
                MessageBox.Show("Harap pilih Nama Petani terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // --------------------------------------------------------------

            // Validasi Input Berat & Hitung
            if (string.IsNullOrWhiteSpace(txtBerat.Text) || lblGrade.Text == "Grade: -")
            {
                MessageBox.Show("Pastikan Berat (Kg) sudah diisi dan tombol 'Hitung' sudah ditekan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal berat_kg = 0;
            if (!decimal.TryParse(txtBerat.Text, out berat_kg) || berat_kg <= 0)
            {
                MessageBox.Show("Format berat salah! Masukkan angka yang valid (contoh: 50 atau 50.5).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Siapkan Data
                string id_trx = "TRX-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                int id_petani = Convert.ToInt32(cmbPetani.SelectedValue);
                int id_petugas = this.akun_petugas.id;

                bool veto = chkBerjamur.Checked || chkBauAsing.Checked || chkSangatBasah.Checked;

                int total_poin = 0;
                if (!veto)
                {
                    string poinStr = lblTotalPoin.Text.Replace("Total Poin: ", "").Replace("(Veto)", "").Trim();
                    int.TryParse(poinStr, out total_poin);
                }

                string id_grade = "D";
                if (lblGrade.Text.Contains("A+")) id_grade = "A+";
                else if (lblGrade.Text.Contains("A")) id_grade = "A";
                else if (lblGrade.Text.Contains("B")) id_grade = "B";
                else if (lblGrade.Text.Contains("C")) id_grade = "C";

                string[] kriteria_id = { "WARNA", "TEKSTUR", "AROMA", "POSISI", "FISIK" };
                int[] poin_kriteria = new int[5];

                if (!veto)
                {
                    poin_kriteria[0] = AmbilAngkaDariTeks(cmbWarna.Text);
                    poin_kriteria[1] = AmbilAngkaDariTeks(cmbTekstur.Text);
                    poin_kriteria[2] = AmbilAngkaDariTeks(cmbAroma.Text);
                    poin_kriteria[3] = AmbilAngkaDariTeks(cmbPosisi.Text);
                    poin_kriteria[4] = AmbilAngkaDariTeks(cmbFisik.Text);
                }

                // Panggil Controller untuk Simpan
                bool sukses = trx_controller.simpan_transaksi_penyortiran(
                    id_trx, id_petani, id_petugas, veto, total_poin, id_grade, berat_kg, kriteria_id, poin_kriteria
                );

                if (sukses)
                {
                    MessageBox.Show($"Transaksi Berhasil Disimpan!\nID Transaksi: {id_trx}\nGrade: {id_grade}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset Form
                    txtBerat.Clear();
                    chkBerjamur.Checked = false;
                    chkBauAsing.Checked = false;
                    chkSangatBasah.Checked = false;
                    cmbWarna.SelectedIndex = -1;
                    cmbTekstur.SelectedIndex = -1;
                    cmbAroma.SelectedIndex = -1;
                    cmbPosisi.SelectedIndex = -1;
                    cmbFisik.SelectedIndex = -1;
                    lblTotalPoin.Text = "Total Poin: 0";
                    lblGrade.Text = "Grade: -";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler bawaan yang kosong dari desain
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtBerat_TextChanged(object sender, EventArgs e) { }
    }
}