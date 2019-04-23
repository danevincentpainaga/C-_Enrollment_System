namespace New_Saa_Enrollment_System
{
    partial class StudentStatusForm
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
            this.droppedStatusRadioBtn = new System.Windows.Forms.RadioButton();
            this.statusDroppedSaveBtn = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.statusDroppedCancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // droppedStatusRadioBtn
            // 
            this.droppedStatusRadioBtn.AutoSize = true;
            this.droppedStatusRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.droppedStatusRadioBtn.ForeColor = System.Drawing.Color.Red;
            this.droppedStatusRadioBtn.Location = new System.Drawing.Point(145, 76);
            this.droppedStatusRadioBtn.Name = "droppedStatusRadioBtn";
            this.droppedStatusRadioBtn.Size = new System.Drawing.Size(150, 28);
            this.droppedStatusRadioBtn.TabIndex = 0;
            this.droppedStatusRadioBtn.TabStop = true;
            this.droppedStatusRadioBtn.Text = "droppedStatus";
            this.droppedStatusRadioBtn.UseVisualStyleBackColor = true;
            // 
            // statusDroppedSaveBtn
            // 
            this.statusDroppedSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDroppedSaveBtn.Location = new System.Drawing.Point(86, 141);
            this.statusDroppedSaveBtn.Name = "statusDroppedSaveBtn";
            this.statusDroppedSaveBtn.Size = new System.Drawing.Size(118, 36);
            this.statusDroppedSaveBtn.TabIndex = 2;
            this.statusDroppedSaveBtn.Text = "Save";
            this.statusDroppedSaveBtn.UseVisualStyleBackColor = true;
            this.statusDroppedSaveBtn.Click += new System.EventHandler(this.statusDroppedSaveBtn_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(136, 19);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(159, 20);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Undropped Student?";
            // 
            // statusDroppedCancelBtn
            // 
            this.statusDroppedCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDroppedCancelBtn.Location = new System.Drawing.Point(210, 141);
            this.statusDroppedCancelBtn.Name = "statusDroppedCancelBtn";
            this.statusDroppedCancelBtn.Size = new System.Drawing.Size(118, 36);
            this.statusDroppedCancelBtn.TabIndex = 2;
            this.statusDroppedCancelBtn.Text = "Close";
            this.statusDroppedCancelBtn.UseVisualStyleBackColor = true;
            this.statusDroppedCancelBtn.Click += new System.EventHandler(this.statusDroppedCancelBtn_Click);
            // 
            // StudentStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 204);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.statusDroppedCancelBtn);
            this.Controls.Add(this.statusDroppedSaveBtn);
            this.Controls.Add(this.droppedStatusRadioBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Status to Dropped";
            this.Load += new System.EventHandler(this.StudentStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton droppedStatusRadioBtn;
        private System.Windows.Forms.Button statusDroppedSaveBtn;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button statusDroppedCancelBtn;
    }
}