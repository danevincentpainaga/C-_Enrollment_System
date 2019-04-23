namespace New_Saa_Enrollment_System
{
    partial class EnrollmentStatusReportForm
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
            this.enrollmentStatuscrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // enrollmentStatuscrystalReportViewer
            // 
            this.enrollmentStatuscrystalReportViewer.ActiveViewIndex = -1;
            this.enrollmentStatuscrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enrollmentStatuscrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.enrollmentStatuscrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enrollmentStatuscrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.enrollmentStatuscrystalReportViewer.Name = "enrollmentStatuscrystalReportViewer";
            this.enrollmentStatuscrystalReportViewer.Size = new System.Drawing.Size(1184, 708);
            this.enrollmentStatuscrystalReportViewer.TabIndex = 0;
            this.enrollmentStatuscrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // EnrollmentStatusReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 708);
            this.Controls.Add(this.enrollmentStatuscrystalReportViewer);
            this.Name = "EnrollmentStatusReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnrollmentStatusReportForm";
            this.Load += new System.EventHandler(this.EnrollmentStatusReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer enrollmentStatuscrystalReportViewer;
    }
}