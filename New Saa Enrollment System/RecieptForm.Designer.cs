namespace New_Saa_Enrollment_System
{
    partial class RecieptForm
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
            this.RecieptcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RecieptcrystalReportViewer
            // 
            this.RecieptcrystalReportViewer.ActiveViewIndex = -1;
            this.RecieptcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecieptcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecieptcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecieptcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.RecieptcrystalReportViewer.Name = "RecieptcrystalReportViewer";
            this.RecieptcrystalReportViewer.Size = new System.Drawing.Size(534, 711);
            this.RecieptcrystalReportViewer.TabIndex = 0;
            this.RecieptcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RecieptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 711);
            this.Controls.Add(this.RecieptcrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RecieptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecieptForm";
            this.Load += new System.EventHandler(this.RecieptForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RecieptcrystalReportViewer;
    }
}