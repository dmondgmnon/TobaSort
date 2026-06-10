namespace TobaSort.Views
{
    partial class FormDashboard
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
            this.lblInfoUser = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnMenuManajer = new System.Windows.Forms.Button();
            this.btnMenuPetugas = new System.Windows.Forms.Button();
            this.btnMenuPetani = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnKelolaPetani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfoUser
            // 
            this.lblInfoUser.AutoSize = true;
            this.lblInfoUser.Location = new System.Drawing.Point(74, 34);
            this.lblInfoUser.Name = "lblInfoUser";
            this.lblInfoUser.Size = new System.Drawing.Size(44, 16);
            this.lblInfoUser.TabIndex = 0;
            this.lblInfoUser.Text = "label1";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(74, 116);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(44, 16);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "label2";
            // 
            // btnMenuManajer
            // 
            this.btnMenuManajer.Location = new System.Drawing.Point(424, 254);
            this.btnMenuManajer.Name = "btnMenuManajer";
            this.btnMenuManajer.Size = new System.Drawing.Size(151, 39);
            this.btnMenuManajer.TabIndex = 2;
            this.btnMenuManajer.Text = "kelola harga dan akun";
            this.btnMenuManajer.UseVisualStyleBackColor = true;
            this.btnMenuManajer.Click += new System.EventHandler(this.btnMenuManajer_Click);
            // 
            // btnMenuPetugas
            // 
            this.btnMenuPetugas.Location = new System.Drawing.Point(424, 217);
            this.btnMenuPetugas.Name = "btnMenuPetugas";
            this.btnMenuPetugas.Size = new System.Drawing.Size(151, 31);
            this.btnMenuPetugas.TabIndex = 3;
            this.btnMenuPetugas.Text = "Input penyortiran";
            this.btnMenuPetugas.UseVisualStyleBackColor = true;
            this.btnMenuPetugas.Click += new System.EventHandler(this.btnMenuPetugas_Click);
            // 
            // btnMenuPetani
            // 
            this.btnMenuPetani.Location = new System.Drawing.Point(424, 180);
            this.btnMenuPetani.Name = "btnMenuPetani";
            this.btnMenuPetani.Size = new System.Drawing.Size(151, 31);
            this.btnMenuPetani.TabIndex = 4;
            this.btnMenuPetani.Text = "Riwayat Setoran";
            this.btnMenuPetani.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(27, 262);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(151, 31);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnKelolaPetani
            // 
            this.btnKelolaPetani.Location = new System.Drawing.Point(424, 299);
            this.btnKelolaPetani.Name = "btnKelolaPetani";
            this.btnKelolaPetani.Size = new System.Drawing.Size(151, 39);
            this.btnKelolaPetani.TabIndex = 6;
            this.btnKelolaPetani.Text = "kelola data petani";
            this.btnKelolaPetani.UseVisualStyleBackColor = true;
            this.btnKelolaPetani.Click += new System.EventHandler(this.btnKelolaPetani_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKelolaPetani);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMenuPetani);
            this.Controls.Add(this.btnMenuPetugas);
            this.Controls.Add(this.btnMenuManajer);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblInfoUser);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfoUser;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnMenuManajer;
        private System.Windows.Forms.Button btnMenuPetugas;
        private System.Windows.Forms.Button btnMenuPetani;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnKelolaPetani;
    }
}