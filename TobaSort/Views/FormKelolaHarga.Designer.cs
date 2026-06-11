namespace TobaSort.Views
{
    partial class FormKelolaHarga
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
            this.dgvGrade = new System.Windows.Forms.DataGridView();
            this.lblGradeTerpilih = new System.Windows.Forms.Label();
            this.txtHargaBaru = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrade
            // 
            this.dgvGrade.AllowUserToAddRows = false;
            this.dgvGrade.AllowUserToDeleteRows = false;
            this.dgvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrade.Location = new System.Drawing.Point(12, 12);
            this.dgvGrade.Name = "dgvGrade";
            this.dgvGrade.ReadOnly = true;
            this.dgvGrade.RowHeadersWidth = 51;
            this.dgvGrade.RowTemplate.Height = 24;
            this.dgvGrade.Size = new System.Drawing.Size(587, 150);
            this.dgvGrade.TabIndex = 0;
            this.dgvGrade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrade_CellClick);
            // 
            // lblGradeTerpilih
            // 
            this.lblGradeTerpilih.AutoSize = true;
            this.lblGradeTerpilih.Location = new System.Drawing.Point(24, 192);
            this.lblGradeTerpilih.Name = "lblGradeTerpilih";
            this.lblGradeTerpilih.Size = new System.Drawing.Size(103, 16);
            this.lblGradeTerpilih.TabIndex = 1;
            this.lblGradeTerpilih.Text = "Grade Terpilih: -";
            // 
            // txtHargaBaru
            // 
            this.txtHargaBaru.Location = new System.Drawing.Point(27, 262);
            this.txtHargaBaru.Name = "txtHargaBaru";
            this.txtHargaBaru.Size = new System.Drawing.Size(100, 22);
            this.txtHargaBaru.TabIndex = 2;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(371, 335);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Update Harga";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "harga baru";
            // 
            // FormKelolaHarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtHargaBaru);
            this.Controls.Add(this.lblGradeTerpilih);
            this.Controls.Add(this.dgvGrade);
            this.Name = "FormKelolaHarga";
            this.Text = "FormKelolaHarga";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrade;
        private System.Windows.Forms.Label lblGradeTerpilih;
        private System.Windows.Forms.TextBox txtHargaBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label1;
    }
}