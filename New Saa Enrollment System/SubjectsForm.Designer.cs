namespace New_Saa_Enrollment_System
{
    partial class SubjectsForm
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.subjectsviewGrid = new System.Windows.Forms.DataGridView();
            this.lastnamegroupBox16 = new System.Windows.Forms.GroupBox();
            this.studlastnametextBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subjectNameTxtbox = new System.Windows.Forms.TextBox();
            this.subjectDescriptionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.subjectSaveUpdateBtn = new System.Windows.Forms.Button();
            this.subjectcancelBtn = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsviewGrid)).BeginInit();
            this.lastnamegroupBox16.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.DimGray;
            this.groupBox8.Controls.Add(this.subjectsviewGrid);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(3, 77);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(604, 348);
            this.groupBox8.TabIndex = 104;
            this.groupBox8.TabStop = false;
            // 
            // subjectsviewGrid
            // 
            this.subjectsviewGrid.AllowUserToAddRows = false;
            this.subjectsviewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectsviewGrid.BackgroundColor = System.Drawing.Color.White;
            this.subjectsviewGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subjectsviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsviewGrid.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.subjectsviewGrid.Location = new System.Drawing.Point(6, 9);
            this.subjectsviewGrid.Name = "subjectsviewGrid";
            this.subjectsviewGrid.ReadOnly = true;
            this.subjectsviewGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectsviewGrid.Size = new System.Drawing.Size(592, 333);
            this.subjectsviewGrid.TabIndex = 44;
            this.subjectsviewGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.subjectsviewGrid_CellClick);
            // 
            // lastnamegroupBox16
            // 
            this.lastnamegroupBox16.Controls.Add(this.studlastnametextBoxSearch);
            this.lastnamegroupBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnamegroupBox16.ForeColor = System.Drawing.Color.Black;
            this.lastnamegroupBox16.Location = new System.Drawing.Point(3, 12);
            this.lastnamegroupBox16.Name = "lastnamegroupBox16";
            this.lastnamegroupBox16.Size = new System.Drawing.Size(343, 59);
            this.lastnamegroupBox16.TabIndex = 105;
            this.lastnamegroupBox16.TabStop = false;
            this.lastnamegroupBox16.Text = "Lastname";
            // 
            // studlastnametextBoxSearch
            // 
            this.studlastnametextBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studlastnametextBoxSearch.Location = new System.Drawing.Point(6, 22);
            this.studlastnametextBoxSearch.Multiline = true;
            this.studlastnametextBoxSearch.Name = "studlastnametextBoxSearch";
            this.studlastnametextBoxSearch.Size = new System.Drawing.Size(331, 30);
            this.studlastnametextBoxSearch.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subjectNameTxtbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(639, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 59);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subject Name";
            // 
            // subjectNameTxtbox
            // 
            this.subjectNameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectNameTxtbox.Location = new System.Drawing.Point(6, 22);
            this.subjectNameTxtbox.Multiline = true;
            this.subjectNameTxtbox.Name = "subjectNameTxtbox";
            this.subjectNameTxtbox.Size = new System.Drawing.Size(331, 30);
            this.subjectNameTxtbox.TabIndex = 14;
            // 
            // subjectDescriptionrichTextBox
            // 
            this.subjectDescriptionrichTextBox.Location = new System.Drawing.Point(6, 25);
            this.subjectDescriptionrichTextBox.Name = "subjectDescriptionrichTextBox";
            this.subjectDescriptionrichTextBox.Size = new System.Drawing.Size(331, 65);
            this.subjectDescriptionrichTextBox.TabIndex = 106;
            this.subjectDescriptionrichTextBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.subjectDescriptionrichTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(639, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 97);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // subjectSaveUpdateBtn
            // 
            this.subjectSaveUpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectSaveUpdateBtn.Location = new System.Drawing.Point(645, 333);
            this.subjectSaveUpdateBtn.Name = "subjectSaveUpdateBtn";
            this.subjectSaveUpdateBtn.Size = new System.Drawing.Size(343, 41);
            this.subjectSaveUpdateBtn.TabIndex = 106;
            this.subjectSaveUpdateBtn.Text = "SAVE";
            this.subjectSaveUpdateBtn.UseVisualStyleBackColor = true;
            this.subjectSaveUpdateBtn.Click += new System.EventHandler(this.subjectSaveUpdateBtn_Click);
            // 
            // subjectcancelBtn
            // 
            this.subjectcancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectcancelBtn.Location = new System.Drawing.Point(645, 380);
            this.subjectcancelBtn.Name = "subjectcancelBtn";
            this.subjectcancelBtn.Size = new System.Drawing.Size(343, 41);
            this.subjectcancelBtn.TabIndex = 106;
            this.subjectcancelBtn.Text = "CANCEL";
            this.subjectcancelBtn.UseVisualStyleBackColor = true;
            this.subjectcancelBtn.Click += new System.EventHandler(this.subjectcancelBtn_Click);
            // 
            // SubjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 439);
            this.Controls.Add(this.subjectcancelBtn);
            this.Controls.Add(this.subjectSaveUpdateBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lastnamegroupBox16);
            this.Controls.Add(this.groupBox8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subjects Form";
            this.Load += new System.EventHandler(this.SubjectsForm_Load);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subjectsviewGrid)).EndInit();
            this.lastnamegroupBox16.ResumeLayout(false);
            this.lastnamegroupBox16.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView subjectsviewGrid;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox studlastnametextBoxSearch;
        private System.Windows.Forms.GroupBox lastnamegroupBox16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox subjectNameTxtbox;
        private System.Windows.Forms.RichTextBox subjectDescriptionrichTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button subjectSaveUpdateBtn;
        private System.Windows.Forms.Button subjectcancelBtn;
    }
}