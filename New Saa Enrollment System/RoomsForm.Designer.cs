namespace New_Saa_Enrollment_System
{
    partial class RoomsForm
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
            this.roomsviewGrid = new System.Windows.Forms.DataGridView();
            this.lastnamegroupBox16 = new System.Windows.Forms.GroupBox();
            this.studlastnametextBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roomNameTxtbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.roomDescriptionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.roomSaveBtn = new System.Windows.Forms.Button();
            this.roomCancelBtn = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsviewGrid)).BeginInit();
            this.lastnamegroupBox16.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.DimGray;
            this.groupBox8.Controls.Add(this.roomsviewGrid);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(12, 65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(620, 250);
            this.groupBox8.TabIndex = 104;
            this.groupBox8.TabStop = false;
            // 
            // roomsviewGrid
            // 
            this.roomsviewGrid.AllowUserToAddRows = false;
            this.roomsviewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomsviewGrid.BackgroundColor = System.Drawing.Color.White;
            this.roomsviewGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.roomsviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomsviewGrid.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.roomsviewGrid.Location = new System.Drawing.Point(4, 10);
            this.roomsviewGrid.Name = "roomsviewGrid";
            this.roomsviewGrid.ReadOnly = true;
            this.roomsviewGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.roomsviewGrid.Size = new System.Drawing.Size(610, 236);
            this.roomsviewGrid.TabIndex = 44;
            this.roomsviewGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomsviewGrid_CellClick);
            // 
            // lastnamegroupBox16
            // 
            this.lastnamegroupBox16.Controls.Add(this.studlastnametextBoxSearch);
            this.lastnamegroupBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnamegroupBox16.ForeColor = System.Drawing.Color.Black;
            this.lastnamegroupBox16.Location = new System.Drawing.Point(12, 0);
            this.lastnamegroupBox16.Name = "lastnamegroupBox16";
            this.lastnamegroupBox16.Size = new System.Drawing.Size(313, 59);
            this.lastnamegroupBox16.TabIndex = 13;
            this.lastnamegroupBox16.TabStop = false;
            this.lastnamegroupBox16.Text = "Search";
            this.lastnamegroupBox16.UseWaitCursor = true;
            // 
            // studlastnametextBoxSearch
            // 
            this.studlastnametextBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studlastnametextBoxSearch.Location = new System.Drawing.Point(6, 22);
            this.studlastnametextBoxSearch.Multiline = true;
            this.studlastnametextBoxSearch.Name = "studlastnametextBoxSearch";
            this.studlastnametextBoxSearch.Size = new System.Drawing.Size(301, 30);
            this.studlastnametextBoxSearch.TabIndex = 14;
            this.studlastnametextBoxSearch.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomNameTxtbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(654, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 59);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Name";
            this.groupBox1.UseWaitCursor = true;
            // 
            // roomNameTxtbox
            // 
            this.roomNameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameTxtbox.Location = new System.Drawing.Point(6, 22);
            this.roomNameTxtbox.Multiline = true;
            this.roomNameTxtbox.Name = "roomNameTxtbox";
            this.roomNameTxtbox.Size = new System.Drawing.Size(301, 30);
            this.roomNameTxtbox.TabIndex = 14;
            this.roomNameTxtbox.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.roomDescriptionrichTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(654, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 112);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            this.groupBox2.UseWaitCursor = true;
            // 
            // roomDescriptionrichTextBox
            // 
            this.roomDescriptionrichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.roomDescriptionrichTextBox.Location = new System.Drawing.Point(7, 26);
            this.roomDescriptionrichTextBox.Name = "roomDescriptionrichTextBox";
            this.roomDescriptionrichTextBox.Size = new System.Drawing.Size(300, 80);
            this.roomDescriptionrichTextBox.TabIndex = 0;
            this.roomDescriptionrichTextBox.Text = "";
            // 
            // roomSaveBtn
            // 
            this.roomSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomSaveBtn.Location = new System.Drawing.Point(654, 275);
            this.roomSaveBtn.Name = "roomSaveBtn";
            this.roomSaveBtn.Size = new System.Drawing.Size(150, 36);
            this.roomSaveBtn.TabIndex = 105;
            this.roomSaveBtn.Text = "SAVE";
            this.roomSaveBtn.UseVisualStyleBackColor = true;
            this.roomSaveBtn.Click += new System.EventHandler(this.roomSaveBtn_Click);
            // 
            // roomCancelBtn
            // 
            this.roomCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomCancelBtn.Location = new System.Drawing.Point(817, 275);
            this.roomCancelBtn.Name = "roomCancelBtn";
            this.roomCancelBtn.Size = new System.Drawing.Size(150, 36);
            this.roomCancelBtn.TabIndex = 105;
            this.roomCancelBtn.Text = "CANCEL";
            this.roomCancelBtn.UseVisualStyleBackColor = true;
            this.roomCancelBtn.Click += new System.EventHandler(this.roomCancelBtn_Click);
            // 
            // RoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 326);
            this.Controls.Add(this.roomCancelBtn);
            this.Controls.Add(this.roomSaveBtn);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lastnamegroupBox16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomsForm";
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsviewGrid)).EndInit();
            this.lastnamegroupBox16.ResumeLayout(false);
            this.lastnamegroupBox16.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView roomsviewGrid;
        private System.Windows.Forms.GroupBox lastnamegroupBox16;
        private System.Windows.Forms.TextBox studlastnametextBoxSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox roomNameTxtbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button roomSaveBtn;
        private System.Windows.Forms.Button roomCancelBtn;
        private System.Windows.Forms.RichTextBox roomDescriptionrichTextBox;
    }
}