namespace New_Saa_Enrollment_System
{
    partial class StartEnrollmentConfirmationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartEnrollmentConfirmationForm));
            this.startEnrollmentBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.adminStartPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.adminStartUsernameTxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startEnrollmentBtn
            // 
            this.startEnrollmentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startEnrollmentBtn.Location = new System.Drawing.Point(290, 182);
            this.startEnrollmentBtn.Name = "startEnrollmentBtn";
            this.startEnrollmentBtn.Size = new System.Drawing.Size(134, 32);
            this.startEnrollmentBtn.TabIndex = 11;
            this.startEnrollmentBtn.Text = "START";
            this.startEnrollmentBtn.UseVisualStyleBackColor = true;
            this.startEnrollmentBtn.Click += new System.EventHandler(this.startEnrollmentBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(233, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm your username and Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Admin Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            // 
            // adminStartPasswordTxtBox
            // 
            this.adminStartPasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminStartPasswordTxtBox.Location = new System.Drawing.Point(227, 140);
            this.adminStartPasswordTxtBox.Name = "adminStartPasswordTxtBox";
            this.adminStartPasswordTxtBox.Size = new System.Drawing.Size(271, 27);
            this.adminStartPasswordTxtBox.TabIndex = 7;
            this.adminStartPasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // adminStartUsernameTxtBox
            // 
            this.adminStartUsernameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminStartUsernameTxtBox.Location = new System.Drawing.Point(227, 80);
            this.adminStartUsernameTxtBox.Name = "adminStartUsernameTxtBox";
            this.adminStartUsernameTxtBox.Size = new System.Drawing.Size(271, 27);
            this.adminStartUsernameTxtBox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 119);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // StartEnrollmentConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 235);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startEnrollmentBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adminStartPasswordTxtBox);
            this.Controls.Add(this.adminStartUsernameTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartEnrollmentConfirmationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartEnrollmentConfirmationForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startEnrollmentBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox adminStartPasswordTxtBox;
        private System.Windows.Forms.TextBox adminStartUsernameTxtBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}