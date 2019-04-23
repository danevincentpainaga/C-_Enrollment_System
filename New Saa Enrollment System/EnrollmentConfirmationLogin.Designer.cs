namespace New_Saa_Enrollment_System
{
    partial class EnrollmentConfirmationLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollmentConfirmationLogin));
            this.adminusernameTxtBox = new System.Windows.Forms.TextBox();
            this.adminpasswordTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.enterEnrollmentModuleBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminusernameTxtBox
            // 
            this.adminusernameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminusernameTxtBox.Location = new System.Drawing.Point(218, 74);
            this.adminusernameTxtBox.Name = "adminusernameTxtBox";
            this.adminusernameTxtBox.Size = new System.Drawing.Size(271, 29);
            this.adminusernameTxtBox.TabIndex = 0;
            // 
            // adminpasswordTxtBox
            // 
            this.adminpasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminpasswordTxtBox.Location = new System.Drawing.Point(218, 134);
            this.adminpasswordTxtBox.Name = "adminpasswordTxtBox";
            this.adminpasswordTxtBox.Size = new System.Drawing.Size(271, 29);
            this.adminpasswordTxtBox.TabIndex = 1;
            this.adminpasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(206, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Admin Username and Admin Password";
            // 
            // enterEnrollmentModuleBtn
            // 
            this.enterEnrollmentModuleBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.enterEnrollmentModuleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterEnrollmentModuleBtn.Image = ((System.Drawing.Image)(resources.GetObject("enterEnrollmentModuleBtn.Image")));
            this.enterEnrollmentModuleBtn.Location = new System.Drawing.Point(265, 181);
            this.enterEnrollmentModuleBtn.Name = "enterEnrollmentModuleBtn";
            this.enterEnrollmentModuleBtn.Size = new System.Drawing.Size(163, 56);
            this.enterEnrollmentModuleBtn.TabIndex = 5;
            this.enterEnrollmentModuleBtn.UseVisualStyleBackColor = true;
            this.enterEnrollmentModuleBtn.Click += new System.EventHandler(this.enterEnrollmentModuleBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // EnrollmentConfirmationLogin
            // 
            this.AcceptButton = this.enterEnrollmentModuleBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 256);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.enterEnrollmentModuleBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adminpasswordTxtBox);
            this.Controls.Add(this.adminusernameTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollmentConfirmationLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox adminusernameTxtBox;
        private System.Windows.Forms.TextBox adminpasswordTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button enterEnrollmentModuleBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}