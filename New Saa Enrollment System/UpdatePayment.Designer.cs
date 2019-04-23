namespace New_Saa_Enrollment_System
{
    partial class UpdatePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePayment));
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.searchStudentbutton1 = new System.Windows.Forms.Button();
            this.newpaymentviewGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newpaymentFirstnameTxtbox = new System.Windows.Forms.TextBox();
            this.lastnamegroupBox16 = new System.Windows.Forms.GroupBox();
            this.newpaymentLastnameTxtbox = new System.Windows.Forms.TextBox();
            this.newpaymentlistBox = new System.Windows.Forms.ListBox();
            this.changetextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cashtextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.totalBalancestextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newpaymentviewGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.lastnamegroupBox16.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.DimGray;
            this.groupBox8.Controls.Add(this.searchStudentbutton1);
            this.groupBox8.Controls.Add(this.newpaymentviewGrid);
            this.groupBox8.Controls.Add(this.groupBox1);
            this.groupBox8.Controls.Add(this.lastnamegroupBox16);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(415, 9);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(645, 327);
            this.groupBox8.TabIndex = 103;
            this.groupBox8.TabStop = false;
            // 
            // searchStudentbutton1
            // 
            this.searchStudentbutton1.Location = new System.Drawing.Point(549, 19);
            this.searchStudentbutton1.Name = "searchStudentbutton1";
            this.searchStudentbutton1.Size = new System.Drawing.Size(89, 36);
            this.searchStudentbutton1.TabIndex = 107;
            this.searchStudentbutton1.Text = "Search";
            this.searchStudentbutton1.UseVisualStyleBackColor = true;
            // 
            // newpaymentviewGrid
            // 
            this.newpaymentviewGrid.BackgroundColor = System.Drawing.Color.White;
            this.newpaymentviewGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newpaymentviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newpaymentviewGrid.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.newpaymentviewGrid.Location = new System.Drawing.Point(6, 61);
            this.newpaymentviewGrid.Name = "newpaymentviewGrid";
            this.newpaymentviewGrid.ReadOnly = true;
            this.newpaymentviewGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.newpaymentviewGrid.Size = new System.Drawing.Size(632, 260);
            this.newpaymentviewGrid.TabIndex = 44;
            this.newpaymentviewGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.newpaymentviewGrid_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newpaymentFirstnameTxtbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(276, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 43);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firstname";
            // 
            // newpaymentFirstnameTxtbox
            // 
            this.newpaymentFirstnameTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newpaymentFirstnameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpaymentFirstnameTxtbox.Location = new System.Drawing.Point(5, 13);
            this.newpaymentFirstnameTxtbox.Multiline = true;
            this.newpaymentFirstnameTxtbox.Name = "newpaymentFirstnameTxtbox";
            this.newpaymentFirstnameTxtbox.Size = new System.Drawing.Size(254, 27);
            this.newpaymentFirstnameTxtbox.TabIndex = 13;
            // 
            // lastnamegroupBox16
            // 
            this.lastnamegroupBox16.Controls.Add(this.newpaymentLastnameTxtbox);
            this.lastnamegroupBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnamegroupBox16.ForeColor = System.Drawing.Color.White;
            this.lastnamegroupBox16.Location = new System.Drawing.Point(6, 12);
            this.lastnamegroupBox16.Name = "lastnamegroupBox16";
            this.lastnamegroupBox16.Size = new System.Drawing.Size(264, 43);
            this.lastnamegroupBox16.TabIndex = 13;
            this.lastnamegroupBox16.TabStop = false;
            this.lastnamegroupBox16.Text = "Lastname";
            // 
            // newpaymentLastnameTxtbox
            // 
            this.newpaymentLastnameTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newpaymentLastnameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpaymentLastnameTxtbox.Location = new System.Drawing.Point(5, 13);
            this.newpaymentLastnameTxtbox.Multiline = true;
            this.newpaymentLastnameTxtbox.Name = "newpaymentLastnameTxtbox";
            this.newpaymentLastnameTxtbox.Size = new System.Drawing.Size(254, 27);
            this.newpaymentLastnameTxtbox.TabIndex = 13;
            // 
            // newpaymentlistBox
            // 
            this.newpaymentlistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpaymentlistBox.FormattingEnabled = true;
            this.newpaymentlistBox.ItemHeight = 18;
            this.newpaymentlistBox.Location = new System.Drawing.Point(9, 10);
            this.newpaymentlistBox.Name = "newpaymentlistBox";
            this.newpaymentlistBox.Size = new System.Drawing.Size(397, 292);
            this.newpaymentlistBox.TabIndex = 108;
            // 
            // changetextBox
            // 
            this.changetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changetextBox.Location = new System.Drawing.Point(127, 386);
            this.changetextBox.Multiline = true;
            this.changetextBox.Name = "changetextBox";
            this.changetextBox.Size = new System.Drawing.Size(279, 37);
            this.changetextBox.TabIndex = 114;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "CHANGE:";
            // 
            // cashtextBox
            // 
            this.cashtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cashtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashtextBox.ForeColor = System.Drawing.Color.Green;
            this.cashtextBox.Location = new System.Drawing.Point(127, 348);
            this.cashtextBox.Multiline = true;
            this.cashtextBox.Name = "cashtextBox";
            this.cashtextBox.Size = new System.Drawing.Size(279, 37);
            this.cashtextBox.TabIndex = 112;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(13, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 111;
            this.label10.Text = "CASH";
            // 
            // totalBalancestextBox
            // 
            this.totalBalancestextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalBalancestextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBalancestextBox.ForeColor = System.Drawing.Color.Red;
            this.totalBalancestextBox.Location = new System.Drawing.Point(127, 308);
            this.totalBalancestextBox.Multiline = true;
            this.totalBalancestextBox.Name = "totalBalancestextBox";
            this.totalBalancestextBox.Size = new System.Drawing.Size(279, 37);
            this.totalBalancestextBox.TabIndex = 110;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 109;
            this.label9.Text = "TOTAL FEES:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(417, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 55);
            this.groupBox3.TabIndex = 115;
            this.groupBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(119, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 31);
            this.button2.TabIndex = 57;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(15, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 31);
            this.button4.TabIndex = 58;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // UpdatePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 431);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.changetextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cashtextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.totalBalancestextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.newpaymentlistBox);
            this.Controls.Add(this.groupBox8);
            this.Name = "UpdatePayment";
            this.Text = "UpdatePayment";
            this.Load += new System.EventHandler(this.UpdatePayment_Load);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newpaymentviewGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.lastnamegroupBox16.ResumeLayout(false);
            this.lastnamegroupBox16.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button searchStudentbutton1;
        private System.Windows.Forms.DataGridView newpaymentviewGrid;
        private System.Windows.Forms.GroupBox lastnamegroupBox16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox newpaymentFirstnameTxtbox;
        private System.Windows.Forms.TextBox newpaymentLastnameTxtbox;
        private System.Windows.Forms.ListBox newpaymentlistBox;
        private System.Windows.Forms.TextBox changetextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cashtextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox totalBalancestextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}