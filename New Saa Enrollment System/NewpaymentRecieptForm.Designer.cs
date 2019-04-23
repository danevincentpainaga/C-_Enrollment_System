namespace New_Saa_Enrollment_System
{
    partial class NewpaymentRecieptForm
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
            this.newpaymentcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // newpaymentcrystalReportViewer
            // 
            this.newpaymentcrystalReportViewer.ActiveViewIndex = -1;
            this.newpaymentcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newpaymentcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.newpaymentcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newpaymentcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.newpaymentcrystalReportViewer.Name = "newpaymentcrystalReportViewer";
            this.newpaymentcrystalReportViewer.Size = new System.Drawing.Size(610, 711);
            this.newpaymentcrystalReportViewer.TabIndex = 0;
            this.newpaymentcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // NewpaymentRecieptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 711);
            this.Controls.Add(this.newpaymentcrystalReportViewer);
            this.Name = "NewpaymentRecieptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewpaymentRecieptForm";
            this.Load += new System.EventHandler(this.NewpaymentRecieptForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer newpaymentcrystalReportViewer;
    }
}