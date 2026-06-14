namespace TobaSort.Views
{
    partial class FormManajer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAkun = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnMata = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkun)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(31, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 38);
            this.label5.TabIndex = 12;
            this.label5.Text = "Daftar Akun Terdaftar";
            // 
            // dgvAkun
            // 
            this.dgvAkun.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.dgvAkun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAkun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAkun.Location = new System.Drawing.Point(28, 95);
            this.dgvAkun.Name = "dgvAkun";
            this.dgvAkun.ReadOnly = true;
            this.dgvAkun.RowHeadersVisible = false;
            this.dgvAkun.RowHeadersWidth = 51;
            this.dgvAkun.RowTemplate.Height = 24;
            this.dgvAkun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAkun.Size = new System.Drawing.Size(828, 161);
            this.dgvAkun.TabIndex = 13;
            this.dgvAkun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAkun_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "⚙️ ROLE AKSES SISTEM";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin Gudang",
            "Petugas Grading"});
            this.cmbRole.Location = new System.Drawing.Point(41, 334);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(145, 24);
            this.cmbRole.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "NAMA LENGKAP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "ID PENGGUNA (USERNAME)";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(41, 398);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(266, 22);
            this.txtNama.TabIndex = 18;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(473, 345);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(266, 22);
            this.txtUsername.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "KATA SANDI KEAMANAN";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(470, 405);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(269, 22);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnMata
            // 
            this.btnMata.AutoSize = true;
            this.btnMata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMata.Location = new System.Drawing.Point(696, 408);
            this.btnMata.Name = "btnMata";
            this.btnMata.Size = new System.Drawing.Size(19, 16);
            this.btnMata.TabIndex = 22;
            this.btnMata.Text = "👁";
            this.btnMata.Click += new System.EventHandler(this.btnMata_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(740, 533);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 23);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "↻ RESET FORM";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(699, 562);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(157, 23);
            this.btnHapus.TabIndex = 24;
            this.btnHapus.Text = "TERAPKAN STATUS";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(641, 591);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(215, 23);
            this.btnSimpan.TabIndex = 25;
            this.btnSimpan.Text = "💾 SIMPAN PERUBAHAN DATA";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Non-Aktif"});
            this.cmbStatus.Location = new System.Drawing.Point(38, 484);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "STATUS AKUN";
            // 
            // FormManajer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnMata);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvAkun);
            this.Controls.Add(this.label5);
            this.Name = "FormManajer";
            this.Text = "FormManajer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvAkun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label btnMata;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
    }
}