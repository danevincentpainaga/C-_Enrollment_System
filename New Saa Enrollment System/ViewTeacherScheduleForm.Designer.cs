namespace New_Saa_Enrollment_System
{
    partial class ViewTeacherScheduleForm
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
            this.TeacherScheduleCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // TeacherScheduleCrystalReportViewer
            // 
            this.TeacherScheduleCrystalReportViewer.ActiveViewIndex = -1;
            this.TeacherScheduleCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeacherScheduleCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.TeacherScheduleCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeacherScheduleCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.TeacherScheduleCrystalReportViewer.Name = "TeacherScheduleCrystalReportViewer";
            this.TeacherScheduleCrystalReportViewer.Size = new System.Drawing.Size(984, 461);
            this.TeacherScheduleCrystalReportViewer.TabIndex = 0;
            this.TeacherScheduleCrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ViewTeacherScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.TeacherScheduleCrystalReportViewer);
            this.Name = "ViewTeacherScheduleForm";
            this.Text = "ViewTeacherScheduleForm";
            this.Load += new System.EventHandler(this.ViewTeacherScheduleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer TeacherScheduleCrystalReportViewer;
    }
}