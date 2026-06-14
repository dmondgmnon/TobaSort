namespace TobaSort.Views
{
    partial class FormDashboard
    {
        
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnKelolaHarga = new System.Windows.Forms.Button();
            this.lblJudulDashboard = new System.Windows.Forms.Label();
            this.panelProfil = new System.Windows.Forms.Panel();
            this.lblValueStatus = new System.Windows.Forms.Label();
            this.lblValueRole = new System.Windows.Forms.Label();
            this.lblValueNama = new System.Windows.Forms.Label();
            this.lblValueId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenuManajer = new System.Windows.Forms.Button();
            this.btnKelolaPetani = new System.Windows.Forms.Button();
            this.btnMenuPetani = new System.Windows.Forms.Button();
            this.btnMenuPetugas = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnStokGudang = new System.Windows.Forms.Button();
            this.panelProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(316, 758);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(400, 60);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnKelolaHarga
            // 
            this.btnKelolaHarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnKelolaHarga.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKelolaHarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelolaHarga.Location = new System.Drawing.Point(316, 329);
            this.btnKelolaHarga.Name = "btnKelolaHarga";
            this.btnKelolaHarga.Size = new System.Drawing.Size(400, 60);
            this.btnKelolaHarga.TabIndex = 9;
            this.btnKelolaHarga.Text = "kelola harga";
            this.btnKelolaHarga.UseVisualStyleBackColor = false;
            this.btnKelolaHarga.Click += new System.EventHandler(this.btnKelolaHarga_Click);
            // 
            // lblJudulDashboard
            // 
            this.lblJudulDashboard.AutoSize = true;
            this.lblJudulDashboard.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblJudulDashboard.Location = new System.Drawing.Point(355, 9);
            this.lblJudulDashboard.Name = "lblJudulDashboard";
            this.lblJudulDashboard.Size = new System.Drawing.Size(300, 38);
            this.lblJudulDashboard.TabIndex = 10;
            this.lblJudulDashboard.Text = "DASHBOARD ADMIN";
            this.lblJudulDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProfil
            // 
            this.panelProfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.panelProfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProfil.Controls.Add(this.lblValueStatus);
            this.panelProfil.Controls.Add(this.lblValueRole);
            this.panelProfil.Controls.Add(this.lblValueNama);
            this.panelProfil.Controls.Add(this.lblValueId);
            this.panelProfil.Controls.Add(this.label4);
            this.panelProfil.Controls.Add(this.label3);
            this.panelProfil.Controls.Add(this.label2);
            this.panelProfil.Controls.Add(this.label1);
            this.panelProfil.Location = new System.Drawing.Point(274, 72);
            this.panelProfil.Name = "panelProfil";
            this.panelProfil.Size = new System.Drawing.Size(503, 150);
            this.panelProfil.TabIndex = 11;
            // 
            // lblValueStatus
            // 
            this.lblValueStatus.AutoSize = true;
            this.lblValueStatus.ForeColor = System.Drawing.Color.Green;
            this.lblValueStatus.Location = new System.Drawing.Point(305, 113);
            this.lblValueStatus.Name = "lblValueStatus";
            this.lblValueStatus.Size = new System.Drawing.Size(43, 16);
            this.lblValueStatus.TabIndex = 7;
            this.lblValueStatus.Text = "● Aktif";
            // 
            // lblValueRole
            // 
            this.lblValueRole.AutoSize = true;
            this.lblValueRole.Location = new System.Drawing.Point(23, 113);
            this.lblValueRole.Name = "lblValueRole";
            this.lblValueRole.Size = new System.Drawing.Size(45, 16);
            this.lblValueRole.TabIndex = 6;
            this.lblValueRole.Text = "Admin";
            // 
            // lblValueNama
            // 
            this.lblValueNama.AutoSize = true;
            this.lblValueNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueNama.Location = new System.Drawing.Point(162, 40);
            this.lblValueNama.Name = "lblValueNama";
            this.lblValueNama.Size = new System.Drawing.Size(60, 16);
            this.lblValueNama.TabIndex = 5;
            this.lblValueNama.Text = "SUHER";
            this.lblValueNama.Click += new System.EventHandler(this.lblValueNama_Click);
            // 
            // lblValueId
            // 
            this.lblValueId.AutoSize = true;
            this.lblValueId.Location = new System.Drawing.Point(23, 40);
            this.lblValueId.Name = "lblValueId";
            this.lblValueId.Size = new System.Drawing.Size(14, 16);
            this.lblValueId.TabIndex = 4;
            this.lblValueId.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "STATUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "NAMA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ROLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID AKUN";
            // 
            // btnMenuManajer
            // 
            this.btnMenuManajer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnMenuManajer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMenuManajer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuManajer.Location = new System.Drawing.Point(316, 263);
            this.btnMenuManajer.Name = "btnMenuManajer";
            this.btnMenuManajer.Size = new System.Drawing.Size(400, 60);
            this.btnMenuManajer.TabIndex = 12;
            this.btnMenuManajer.Text = "kelola akun";
            this.btnMenuManajer.UseVisualStyleBackColor = false;
            this.btnMenuManajer.Click += new System.EventHandler(this.btnMenuManajer_Click);
            // 
            // btnKelolaPetani
            // 
            this.btnKelolaPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnKelolaPetani.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKelolaPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelolaPetani.Location = new System.Drawing.Point(316, 395);
            this.btnKelolaPetani.Name = "btnKelolaPetani";
            this.btnKelolaPetani.Size = new System.Drawing.Size(400, 60);
            this.btnKelolaPetani.TabIndex = 13;
            this.btnKelolaPetani.Text = "kelola data petani";
            this.btnKelolaPetani.UseVisualStyleBackColor = false;
            this.btnKelolaPetani.Click += new System.EventHandler(this.btnKelolaPetani_Click);
            // 
            // btnMenuPetani
            // 
            this.btnMenuPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnMenuPetani.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMenuPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPetani.Location = new System.Drawing.Point(316, 659);
            this.btnMenuPetani.Name = "btnMenuPetani";
            this.btnMenuPetani.Size = new System.Drawing.Size(400, 60);
            this.btnMenuPetani.TabIndex = 14;
            this.btnMenuPetani.Text = "Riwayat Setoran";
            this.btnMenuPetani.UseVisualStyleBackColor = false;
            this.btnMenuPetani.Click += new System.EventHandler(this.btnMenuPetani_Click);
            // 
            // btnMenuPetugas
            // 
            this.btnMenuPetugas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnMenuPetugas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMenuPetugas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPetugas.Location = new System.Drawing.Point(316, 593);
            this.btnMenuPetugas.Name = "btnMenuPetugas";
            this.btnMenuPetugas.Size = new System.Drawing.Size(400, 60);
            this.btnMenuPetugas.TabIndex = 15;
            this.btnMenuPetugas.Text = "Input penyortiran";
            this.btnMenuPetugas.UseVisualStyleBackColor = false;
            this.btnMenuPetugas.Click += new System.EventHandler(this.btnMenuPetugas_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnLaporan.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporan.Location = new System.Drawing.Point(316, 527);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(400, 60);
            this.btnLaporan.TabIndex = 16;
            this.btnLaporan.Text = "Lihat Laporan Transaksi";
            this.btnLaporan.UseVisualStyleBackColor = false;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnStokGudang
            // 
            this.btnStokGudang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.btnStokGudang.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStokGudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokGudang.Location = new System.Drawing.Point(316, 461);
            this.btnStokGudang.Name = "btnStokGudang";
            this.btnStokGudang.Size = new System.Drawing.Size(400, 60);
            this.btnStokGudang.TabIndex = 17;
            this.btnStokGudang.Text = "Laporan StokGudang";
            this.btnStokGudang.UseVisualStyleBackColor = false;
            this.btnStokGudang.Click += new System.EventHandler(this.btnStokGudang_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1000, 850);
            this.Controls.Add(this.btnStokGudang);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnMenuPetugas);
            this.Controls.Add(this.btnMenuPetani);
            this.Controls.Add(this.btnKelolaPetani);
            this.Controls.Add(this.btnMenuManajer);
            this.Controls.Add(this.panelProfil);
            this.Controls.Add(this.lblJudulDashboard);
            this.Controls.Add(this.btnKelolaHarga);
            this.Controls.Add(this.btnLogout);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDashboard";
            this.Text = "view";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panelProfil.ResumeLayout(false);
            this.panelProfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnKelolaHarga;
        private System.Windows.Forms.Label lblJudulDashboard;
        private System.Windows.Forms.Panel panelProfil;
        private System.Windows.Forms.Label lblValueStatus;
        private System.Windows.Forms.Label lblValueRole;
        private System.Windows.Forms.Label lblValueNama;
        private System.Windows.Forms.Label lblValueId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuManajer;
        private System.Windows.Forms.Button btnKelolaPetani;
        private System.Windows.Forms.Button btnMenuPetani;
        private System.Windows.Forms.Button btnMenuPetugas;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnStokGudang;
    }
}