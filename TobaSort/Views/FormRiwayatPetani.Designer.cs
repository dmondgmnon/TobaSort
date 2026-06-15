namespace TobaSort.Views
{
    partial class FormRiwayatPetani
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSetoran = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dgvRiwayat = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTotalSetoran);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "TOTAL SETORAN";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTotalSetoran
            // 
            this.lblTotalSetoran.AutoSize = true;
            this.lblTotalSetoran.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSetoran.Location = new System.Drawing.Point(58, 41);
            this.lblTotalSetoran.Name = "lblTotalSetoran";
            this.lblTotalSetoran.Size = new System.Drawing.Size(69, 22);
            this.lblTotalSetoran.TabIndex = 4;
            this.lblTotalSetoran.Text = "0 KALI";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCari);
            this.panel2.Location = new System.Drawing.Point(22, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 22);
            this.panel2.TabIndex = 4;
            // 
            // txtCari
            // 
            this.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCari.Location = new System.Drawing.Point(0, 3);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(100, 15);
            this.txtCari.TabIndex = 0;
            // 
            // dgvRiwayat
            // 
            this.dgvRiwayat.BackgroundColor = System.Drawing.Color.White;
            this.dgvRiwayat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRiwayat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(61)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRiwayat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayat.EnableHeadersVisualStyles = false;
            this.dgvRiwayat.GridColor = System.Drawing.Color.LightGray;
            this.dgvRiwayat.Location = new System.Drawing.Point(22, 162);
            this.dgvRiwayat.Name = "dgvRiwayat";
            this.dgvRiwayat.RowHeadersVisible = false;
            this.dgvRiwayat.RowHeadersWidth = 51;
            this.dgvRiwayat.RowTemplate.Height = 24;
            this.dgvRiwayat.Size = new System.Drawing.Size(766, 150);
            this.dgvRiwayat.TabIndex = 5;
            this.dgvRiwayat.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRiwayat_CellFormatting);
            // 
            // FormRiwayatPetani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRiwayat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormRiwayatPetani";
            this.Text = "FormRiwayatPetani";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSetoran;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.DataGridView dgvRiwayat;
    }
}