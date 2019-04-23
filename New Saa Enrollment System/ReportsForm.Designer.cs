namespace New_Saa_Enrollment_System
{
    partial class ReportsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.returnedPaymentsBtn = new System.Windows.Forms.Button();
            this.listOfPaymentsBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EnrollmentcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.returnedPaymentsBtn);
            this.groupBox1.Controls.Add(this.listOfPaymentsBtn);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1284, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // returnedPaymentsBtn
            // 
            this.returnedPaymentsBtn.BackColor = System.Drawing.Color.White;
            this.returnedPaymentsBtn.Location = new System.Drawing.Point(590, 19);
            this.returnedPaymentsBtn.Name = "returnedPaymentsBtn";
            this.returnedPaymentsBtn.Size = new System.Drawing.Size(187, 52);
            this.returnedPaymentsBtn.TabIndex = 0;
            this.returnedPaymentsBtn.Text = "List of Returned Payments";
            this.returnedPaymentsBtn.UseVisualStyleBackColor = false;
            this.returnedPaymentsBtn.Click += new System.EventHandler(this.returnedPaymentsBtn_Click);
            // 
            // listOfPaymentsBtn
            // 
            this.listOfPaymentsBtn.BackColor = System.Drawing.Color.White;
            this.listOfPaymentsBtn.Location = new System.Drawing.Point(397, 19);
            this.listOfPaymentsBtn.Name = "listOfPaymentsBtn";
            this.listOfPaymentsBtn.Size = new System.Drawing.Size(187, 52);
            this.listOfPaymentsBtn.TabIndex = 0;
            this.listOfPaymentsBtn.Text = "List of Payments";
            this.listOfPaymentsBtn.UseVisualStyleBackColor = false;
            this.listOfPaymentsBtn.Click += new System.EventHandler(this.listOfPaymentsBtn_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(204, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 52);
            this.button3.TabIndex = 0;
            this.button3.Text = "List of Schedules";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(11, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enrolled Students";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnrollmentcrystalReportViewer
            // 
            this.EnrollmentcrystalReportViewer.ActiveViewIndex = -1;
            this.EnrollmentcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnrollmentcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.EnrollmentcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EnrollmentcrystalReportViewer.Location = new System.Drawing.Point(0, 83);
            this.EnrollmentcrystalReportViewer.Name = "EnrollmentcrystalReportViewer";
            this.EnrollmentcrystalReportViewer.Size = new System.Drawing.Size(1284, 625);
            this.EnrollmentcrystalReportViewer.TabIndex = 1;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 708);
            this.Controls.Add(this.EnrollmentcrystalReportViewer);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports Form";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer EnrollmentcrystalReportViewer;
        private System.Windows.Forms.Button returnedPaymentsBtn;
        private System.Windows.Forms.Button listOfPaymentsBtn;
    }
}