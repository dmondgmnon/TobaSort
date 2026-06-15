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
            this.lblTotalPoin = new System.Windows.Forms.Label();
            this.btnHitung = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlRingkasan = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPosisi = new System.Windows.Forms.ComboBox();
            this.cmbWarna = new System.Windows.Forms.ComboBox();
            this.cmbTekstur = new System.Windows.Forms.ComboBox();
            this.cmbAroma = new System.Windows.Forms.ComboBox();
            this.cmbFisik = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlUtama.SuspendLayout();
            this.pnlRingkasan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPetani
            // 
            this.cmbPetani.FormattingEnabled = true;
            this.cmbPetani.Location = new System.Drawing.Point(163, 49);
            this.cmbPetani.Name = "cmbPetani";
            this.cmbPetani.Size = new System.Drawing.Size(414, 24);
            this.cmbPetani.TabIndex = 0;
            // 
            // txtBerat
            // 
            this.txtBerat.Location = new System.Drawing.Point(163, 53);
            this.txtBerat.Name = "txtBerat";
            this.txtBerat.Size = new System.Drawing.Size(414, 22);
            this.txtBerat.TabIndex = 1;
            this.txtBerat.TextChanged += new System.EventHandler(this.txtBerat_TextChanged);
            // 
            // chkBerjamur
            // 
            this.chkBerjamur.AutoSize = true;
            this.chkBerjamur.Location = new System.Drawing.Point(142, 46);
            this.chkBerjamur.Name = "chkBerjamur";
            this.chkBerjamur.Size = new System.Drawing.Size(82, 20);
            this.chkBerjamur.TabIndex = 2;
            this.chkBerjamur.Text = "berjamur";
            this.chkBerjamur.UseVisualStyleBackColor = true;
            this.chkBerjamur.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
            // 
            // chkBauAsing
            // 
            this.chkBauAsing.AutoSize = true;
            this.chkBauAsing.Location = new System.Drawing.Point(460, 46);
            this.chkBauAsing.Name = "chkBauAsing";
            this.chkBauAsing.Size = new System.Drawing.Size(88, 20);
            this.chkBauAsing.TabIndex = 3;
            this.chkBauAsing.Text = "bau asing";
            this.chkBauAsing.UseVisualStyleBackColor = true;
            this.chkBauAsing.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
            // 
            // chkSangatBasah
            // 
            this.chkSangatBasah.AutoSize = true;
            this.chkSangatBasah.Location = new System.Drawing.Point(264, 46);
            this.chkSangatBasah.Name = "chkSangatBasah";
            this.chkSangatBasah.Size = new System.Drawing.Size(111, 20);
            this.chkSangatBasah.TabIndex = 4;
            this.chkSangatBasah.Text = "sangat basah";
            this.chkSangatBasah.UseVisualStyleBackColor = true;
            this.chkSangatBasah.CheckedChanged += new System.EventHandler(this.CekStatusVeto);
            // 
            // lblTotalPoin
            // 
            this.lblTotalPoin.AutoSize = true;
            this.lblTotalPoin.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoin.Location = new System.Drawing.Point(23, 26);
            this.lblTotalPoin.Name = "lblTotalPoin";
            this.lblTotalPoin.Size = new System.Drawing.Size(193, 38);
            this.lblTotalPoin.TabIndex = 10;
            this.lblTotalPoin.Text = "Total Poin: 0\"";
            // 
            // btnHitung
            // 
            this.btnHitung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHitung.Location = new System.Drawing.Point(0, 169);
            this.btnHitung.Name = "btnHitung";
            this.btnHitung.Size = new System.Drawing.Size(350, 47);
            this.btnHitung.TabIndex = 12;
            this.btnHitung.Text = "HITUNG SCORE DAN GRADE ";
            this.btnHitung.UseVisualStyleBackColor = true;
            this.btnHitung.Click += new System.EventHandler(this.btnHitung_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(945, 511);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(260, 68);
            this.btnSimpan.TabIndex = 13;
            this.btnSimpan.Text = "SIMPAN TRANSAKSI";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 28);
            this.label2.TabIndex = 15;
            this.label2.Text = "NAMA PETANI";
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.groupBox4);
            this.pnlUtama.Controls.Add(this.groupBox1);
            this.pnlUtama.Controls.Add(this.groupBox2);
            this.pnlUtama.Controls.Add(this.groupBox3);
            this.pnlUtama.Location = new System.Drawing.Point(24, 12);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(644, 567);
            this.pnlUtama.TabIndex = 16;
            // 
            // pnlRingkasan
            // 
            this.pnlRingkasan.Controls.Add(this.lblGrade);
            this.pnlRingkasan.Controls.Add(this.btnHitung);
            this.pnlRingkasan.Controls.Add(this.lblTotalPoin);
            this.pnlRingkasan.Location = new System.Drawing.Point(754, 28);
            this.pnlRingkasan.Name = "pnlRingkasan";
            this.pnlRingkasan.Size = new System.Drawing.Size(350, 233);
            this.pnlRingkasan.TabIndex = 17;
            this.pnlRingkasan.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRingkasan_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbPetani);
            this.groupBox1.Location = new System.Drawing.Point(21, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 98);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA PETANI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkBerjamur);
            this.groupBox2.Controls.Add(this.chkSangatBasah);
            this.groupBox2.Controls.Add(this.chkBauAsing);
            this.groupBox2.Location = new System.Drawing.Point(21, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UJI VETO";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBerat);
            this.groupBox3.Location = new System.Drawing.Point(21, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATA PETANI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "BERAT (KG)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "VETO";
            // 
            // cmbPosisi
            // 
            this.cmbPosisi.FormattingEnabled = true;
            this.cmbPosisi.Location = new System.Drawing.Point(11, 99);
            this.cmbPosisi.Name = "cmbPosisi";
            this.cmbPosisi.Size = new System.Drawing.Size(259, 24);
            this.cmbPosisi.TabIndex = 8;
            // 
            // cmbWarna
            // 
            this.cmbWarna.FormattingEnabled = true;
            this.cmbWarna.Location = new System.Drawing.Point(11, 49);
            this.cmbWarna.Name = "cmbWarna";
            this.cmbWarna.Size = new System.Drawing.Size(259, 24);
            this.cmbWarna.TabIndex = 5;
            // 
            // cmbTekstur
            // 
            this.cmbTekstur.FormattingEnabled = true;
            this.cmbTekstur.Location = new System.Drawing.Point(318, 130);
            this.cmbTekstur.Name = "cmbTekstur";
            this.cmbTekstur.Size = new System.Drawing.Size(259, 24);
            this.cmbTekstur.TabIndex = 6;
            // 
            // cmbAroma
            // 
            this.cmbAroma.FormattingEnabled = true;
            this.cmbAroma.Location = new System.Drawing.Point(318, 72);
            this.cmbAroma.Name = "cmbAroma";
            this.cmbAroma.Size = new System.Drawing.Size(259, 24);
            this.cmbAroma.TabIndex = 7;
            this.cmbAroma.SelectedIndexChanged += new System.EventHandler(this.cmbAroma_SelectedIndexChanged);
            // 
            // cmbFisik
            // 
            this.cmbFisik.FormattingEnabled = true;
            this.cmbFisik.Location = new System.Drawing.Point(11, 155);
            this.cmbFisik.Name = "cmbFisik";
            this.cmbFisik.Size = new System.Drawing.Size(259, 24);
            this.cmbFisik.TabIndex = 9;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(23, 93);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(119, 38);
            this.lblGrade.TabIndex = 13;
            this.lblGrade.Text = "GRADE:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cmbAroma);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cmbTekstur);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmbPosisi);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cmbWarna);
            this.groupBox4.Controls.Add(this.cmbFisik);
            this.groupBox4.Location = new System.Drawing.Point(21, 332);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(602, 210);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CIRI CIRI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "WARNA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "POSISI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "FISIK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "AROMA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(318, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "TEKSTUR";
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1282, 673);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.pnlRingkasan);
            this.Controls.Add(this.pnlUtama);
            this.Name = "FormTransaksi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTransaksi";
            this.pnlUtama.ResumeLayout(false);
            this.pnlRingkasan.ResumeLayout(false);
            this.pnlRingkasan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPetani;
        private System.Windows.Forms.TextBox txtBerat;
        private System.Windows.Forms.CheckBox chkBerjamur;
        private System.Windows.Forms.CheckBox chkBauAsing;
        private System.Windows.Forms.CheckBox chkSangatBasah;
        private System.Windows.Forms.Label lblTotalPoin;
        private System.Windows.Forms.Button btnHitung;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlRingkasan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPosisi;
        private System.Windows.Forms.ComboBox cmbAroma;
        private System.Windows.Forms.ComboBox cmbFisik;
        private System.Windows.Forms.ComboBox cmbTekstur;
        private System.Windows.Forms.ComboBox cmbWarna;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}