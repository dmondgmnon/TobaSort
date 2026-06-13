namespace TobaSort.Views
{
    partial class FormTransaksi
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
            this.cmbPetani = new System.Windows.Forms.ComboBox();
            this.txtBerat = new System.Windows.Forms.TextBox();
            this.chkBerjamur = new System.Windows.Forms.CheckBox();
            this.chkBauAsing = new System.Windows.Forms.CheckBox();
            this.chkSangatBasah = new System.Windows.Forms.CheckBox();
            this.cmbWarna = new System.Windows.Forms.ComboBox();
            this.cmbTekstur = new System.Windows.Forms.ComboBox();
            this.cmbAroma = new System.Windows.Forms.ComboBox();
            this.cmbPosisi = new System.Windows.Forms.ComboBox();
            this.cmbFisik = new System.Windows.Forms.ComboBox();
            this.lblTotalPoin = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.btnHitung = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
           
            this.cmbPetani.FormattingEnabled = true;
            this.cmbPetani.Location = new System.Drawing.Point(426, 35);
            this.cmbPetani.Name = "cmbPetani";
            this.cmbPetani.Size = new System.Drawing.Size(121, 24);
            this.cmbPetani.TabIndex = 0;
             
            this.txtBerat.Location = new System.Drawing.Point(128, 301);
            this.txtBerat.Name = "txtBerat";
            this.txtBerat.Size = new System.Drawing.Size(100, 22);
            this.txtBerat.TabIndex = 1;
            this.txtBerat.TextChanged += new System.EventHandler(this.txtBerat_TextChanged);
            
            this.chkBerjamur.AutoSize = true;
            this.chkBerjamur.Location = new System.Drawing.Point(454, 102);
            this.chkBerjamur.Name = "chkBerjamur";
            this.chkBerjamur.Size = new System.Drawing.Size(82, 20);
            this.chkBerjamur.TabIndex = 2;
            this.chkBerjamur.Text = "berjamur";
            this.chkBerjamur.UseVisualStyleBackColor = true;
            this.chkBerjamur.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
            
            this.chkBauAsing.AutoSize = true;
            this.chkBauAsing.Location = new System.Drawing.Point(454, 141);
            this.chkBauAsing.Name = "chkBauAsing";
            this.chkBauAsing.Size = new System.Drawing.Size(88, 20);
            this.chkBauAsing.TabIndex = 3;
            this.chkBauAsing.Text = "bau asing";
            this.chkBauAsing.UseVisualStyleBackColor = true;
            this.chkBauAsing.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
             
            this.chkSangatBasah.AutoSize = true;
            this.chkSangatBasah.Location = new System.Drawing.Point(455, 182);
            this.chkSangatBasah.Name = "chkSangatBasah";
            this.chkSangatBasah.Size = new System.Drawing.Size(111, 20);
            this.chkSangatBasah.TabIndex = 4;
            this.chkSangatBasah.Text = "sangat basah";
            this.chkSangatBasah.UseVisualStyleBackColor = true;
            this.chkSangatBasah.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
             
            this.cmbWarna.FormattingEnabled = true;
            this.cmbWarna.Location = new System.Drawing.Point(36, 26);
            this.cmbWarna.Name = "cmbWarna";
            this.cmbWarna.Size = new System.Drawing.Size(192, 24);
            this.cmbWarna.TabIndex = 5;
            
            this.cmbTekstur.FormattingEnabled = true;
            this.cmbTekstur.Location = new System.Drawing.Point(36, 78);
            this.cmbTekstur.Name = "cmbTekstur";
            this.cmbTekstur.Size = new System.Drawing.Size(192, 24);
            this.cmbTekstur.TabIndex = 6;
             
            this.cmbAroma.FormattingEnabled = true;
            this.cmbAroma.Location = new System.Drawing.Point(36, 132);
            this.cmbAroma.Name = "cmbAroma";
            this.cmbAroma.Size = new System.Drawing.Size(192, 24);
            this.cmbAroma.TabIndex = 7;
            
            this.cmbPosisi.FormattingEnabled = true;
            this.cmbPosisi.Location = new System.Drawing.Point(36, 184);
            this.cmbPosisi.Name = "cmbPosisi";
            this.cmbPosisi.Size = new System.Drawing.Size(192, 24);
            this.cmbPosisi.TabIndex = 8;
           
            this.cmbFisik.FormattingEnabled = true;
            this.cmbFisik.Location = new System.Drawing.Point(36, 247);
            this.cmbFisik.Name = "cmbFisik";
            this.cmbFisik.Size = new System.Drawing.Size(192, 24);
            this.cmbFisik.TabIndex = 9;
             
            this.lblTotalPoin.AutoSize = true;
            this.lblTotalPoin.Location = new System.Drawing.Point(451, 290);
            this.lblTotalPoin.Name = "lblTotalPoin";
            this.lblTotalPoin.Size = new System.Drawing.Size(86, 16);
            this.lblTotalPoin.TabIndex = 10;
            this.lblTotalPoin.Text = "Total Poin: 0\"";
             
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(451, 247);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(55, 16);
            this.lblGrade.TabIndex = 11;

            
            this.btnHitung.Location = new System.Drawing.Point(36, 347);
            this.btnHitung.Name = "btnHitung";
            this.btnHitung.Size = new System.Drawing.Size(192, 43);
            this.btnHitung.TabIndex = 12;
            this.btnHitung.Text = "Hitung score dan grade";
            this.btnHitung.UseVisualStyleBackColor = true;
            this.btnHitung.Click += new System.EventHandler(this.btnHitung_Click);
            
            this.btnSimpan.Location = new System.Drawing.Point(426, 352);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(147, 33);
            this.btnSimpan.TabIndex = 13;
            this.btnSimpan.Text = "simpan transaksi ";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "berat (kg)";
            
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "nama petani";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnHitung);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblTotalPoin);
            this.Controls.Add(this.cmbFisik);
            this.Controls.Add(this.cmbPosisi);
            this.Controls.Add(this.cmbAroma);
            this.Controls.Add(this.cmbTekstur);
            this.Controls.Add(this.cmbWarna);
            this.Controls.Add(this.chkSangatBasah);
            this.Controls.Add(this.chkBauAsing);
            this.Controls.Add(this.chkBerjamur);
            this.Controls.Add(this.txtBerat);
            this.Controls.Add(this.cmbPetani);
            this.Name = "FormTransaksi";
            this.Text = "FormTransaksi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPetani;
        private System.Windows.Forms.TextBox txtBerat;
        private System.Windows.Forms.CheckBox chkBerjamur;
        private System.Windows.Forms.CheckBox chkBauAsing;
        private System.Windows.Forms.CheckBox chkSangatBasah;
        private System.Windows.Forms.ComboBox cmbWarna;
        private System.Windows.Forms.ComboBox cmbTekstur;
        private System.Windows.Forms.ComboBox cmbAroma;
        private System.Windows.Forms.ComboBox cmbPosisi;
        private System.Windows.Forms.ComboBox cmbFisik;
        private System.Windows.Forms.Label lblTotalPoin;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Button btnHitung;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}