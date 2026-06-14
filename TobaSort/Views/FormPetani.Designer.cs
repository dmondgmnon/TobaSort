namespace TobaSort.Views
{
    partial class FormPetani
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblKembali = new System.Windows.Forms.Label();
            this.dgvPetani = new System.Windows.Forms.DataGridView();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkAktif = new System.Windows.Forms.CheckBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnNonaktif = new System.Windows.Forms.Button();
            this.btnBersihkan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKembali
            // 
            this.lblKembali.AutoSize = true;
            this.lblKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKembali.Location = new System.Drawing.Point(12, 9);
            this.lblKembali.Name = "lblKembali";
            this.lblKembali.Size = new System.Drawing.Size(165, 16);
            this.lblKembali.TabIndex = 0;
            this.lblKembali.Text = "← KELOLA DATA PETANI";
            // 
            // dgvPetani
            // 
            this.dgvPetani.BackgroundColor = System.Drawing.Color.White;
            this.dgvPetani.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPetani.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(227)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPetani.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPetani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPetani.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPetani.EnableHeadersVisualStyles = false;
            this.dgvPetani.Location = new System.Drawing.Point(31, 28);
            this.dgvPetani.Name = "dgvPetani";
            this.dgvPetani.RowHeadersWidth = 51;
            this.dgvPetani.RowTemplate.Height = 24;
            this.dgvPetani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPetani.Size = new System.Drawing.Size(917, 192);
            this.dgvPetani.TabIndex = 2;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(31, 251);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(100, 22);
            this.txtNama.TabIndex = 3;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(31, 302);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(100, 22);
            this.txtAlamat.TabIndex = 4;
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Location = new System.Drawing.Point(31, 345);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(100, 22);
            this.txtNoTelp.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(31, 393);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 22);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(31, 440);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "👁";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Location = new System.Drawing.Point(31, 491);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(94, 20);
            this.chkAktif.TabIndex = 9;
            this.chkAktif.Text = "Status Aktif";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(31, 535);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(94, 23);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "TAMBAH";
            this.btnTambah.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(177, 535);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(87, 23);
            this.btnSimpan.TabIndex = 11;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnNonaktif
            // 
            this.btnNonaktif.Location = new System.Drawing.Point(31, 587);
            this.btnNonaktif.Name = "btnNonaktif";
            this.btnNonaktif.Size = new System.Drawing.Size(94, 23);
            this.btnNonaktif.TabIndex = 12;
            this.btnNonaktif.Text = "NONAKTIF";
            this.btnNonaktif.UseVisualStyleBackColor = true;
            // 
            // btnBersihkan
            // 
            this.btnBersihkan.Location = new System.Drawing.Point(177, 587);
            this.btnBersihkan.Name = "btnBersihkan";
            this.btnBersihkan.Size = new System.Drawing.Size(87, 23);
            this.btnBersihkan.TabIndex = 13;
            this.btnBersihkan.Text = "BERSIHKAN";
            this.btnBersihkan.UseVisualStyleBackColor = true;
            // 
            // FormPetani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(982, 803);
            this.Controls.Add(this.btnBersihkan);
            this.Controls.Add(this.btnNonaktif);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.chkAktif);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.dgvPetani);
            this.Controls.Add(this.lblKembali);
            this.Name = "FormPetani";
            this.Text = "FormPetani";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKembali;
        private System.Windows.Forms.DataGridView dgvPetani;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkAktif;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnNonaktif;
        private System.Windows.Forms.Button btnBersihkan;
    }
}