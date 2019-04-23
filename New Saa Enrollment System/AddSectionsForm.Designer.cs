namespace New_Saa_Enrollment_System
{
    partial class AddSectionsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.sectionsdataGridView = new System.Windows.Forms.DataGridView();
            this.sectionNameTxtBox = new System.Windows.Forms.TextBox();
            this.yearLevelComboBox = new System.Windows.Forms.ComboBox();
            this.addSectionBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelSectionBtn = new System.Windows.Forms.Button();
            this.sectionAdviserComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filterYearLevelComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sectionsdataGridView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 247);
            this.panel1.TabIndex = 0;
            // 
            // sectionsdataGridView
            // 
            this.sectionsdataGridView.BackgroundColor = System.Drawing.Color.White;
            this.sectionsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sectionsdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionsdataGridView.Location = new System.Drawing.Point(0, 0);
            this.sectionsdataGridView.Name = "sectionsdataGridView";
            this.sectionsdataGridView.ReadOnly = true;
            this.sectionsdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sectionsdataGridView.Size = new System.Drawing.Size(461, 247);
            this.sectionsdataGridView.TabIndex = 0;
            this.sectionsdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sectionsdataGridView_CellClick);
            // 
            // sectionNameTxtBox
            // 
            this.sectionNameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionNameTxtBox.Location = new System.Drawing.Point(515, 133);
            this.sectionNameTxtBox.Name = "sectionNameTxtBox";
            this.sectionNameTxtBox.Size = new System.Drawing.Size(324, 26);
            this.sectionNameTxtBox.TabIndex = 1;
            // 
            // yearLevelComboBox
            // 
            this.yearLevelComboBox.BackColor = System.Drawing.Color.White;
            this.yearLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearLevelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLevelComboBox.FormattingEnabled = true;
            this.yearLevelComboBox.Location = new System.Drawing.Point(515, 75);
            this.yearLevelComboBox.Name = "yearLevelComboBox";
            this.yearLevelComboBox.Size = new System.Drawing.Size(324, 28);
            this.yearLevelComboBox.TabIndex = 2;
            // 
            // addSectionBtn
            // 
            this.addSectionBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addSectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSectionBtn.Location = new System.Drawing.Point(515, 243);
            this.addSectionBtn.Name = "addSectionBtn";
            this.addSectionBtn.Size = new System.Drawing.Size(324, 33);
            this.addSectionBtn.TabIndex = 3;
            this.addSectionBtn.Text = "ADD";
            this.addSectionBtn.UseVisualStyleBackColor = false;
            this.addSectionBtn.Click += new System.EventHandler(this.addSectionBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year Level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(512, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Section Name:";
            // 
            // cancelSectionBtn
            // 
            this.cancelSectionBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelSectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelSectionBtn.Location = new System.Drawing.Point(515, 282);
            this.cancelSectionBtn.Name = "cancelSectionBtn";
            this.cancelSectionBtn.Size = new System.Drawing.Size(324, 33);
            this.cancelSectionBtn.TabIndex = 6;
            this.cancelSectionBtn.Text = "CANCEL";
            this.cancelSectionBtn.UseVisualStyleBackColor = false;
            this.cancelSectionBtn.Click += new System.EventHandler(this.cancelSectionBtn_Click);
            // 
            // sectionAdviserComboBox
            // 
            this.sectionAdviserComboBox.BackColor = System.Drawing.Color.White;
            this.sectionAdviserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionAdviserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionAdviserComboBox.FormattingEnabled = true;
            this.sectionAdviserComboBox.Location = new System.Drawing.Point(515, 194);
            this.sectionAdviserComboBox.Name = "sectionAdviserComboBox";
            this.sectionAdviserComboBox.Size = new System.Drawing.Size(324, 28);
            this.sectionAdviserComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(512, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adviser";
            // 
            // filterYearLevelComboBox
            // 
            this.filterYearLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterYearLevelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterYearLevelComboBox.FormattingEnabled = true;
            this.filterYearLevelComboBox.Location = new System.Drawing.Point(6, 18);
            this.filterYearLevelComboBox.Name = "filterYearLevelComboBox";
            this.filterYearLevelComboBox.Size = new System.Drawing.Size(227, 28);
            this.filterYearLevelComboBox.TabIndex = 9;
            this.filterYearLevelComboBox.SelectedIndexChanged += new System.EventHandler(this.filterYearLevelComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.filterYearLevelComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 52);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // AddSectionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 336);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sectionAdviserComboBox);
            this.Controls.Add(this.cancelSectionBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addSectionBtn);
            this.Controls.Add(this.yearLevelComboBox);
            this.Controls.Add(this.sectionNameTxtBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSectionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Sections";
            this.Load += new System.EventHandler(this.AddSectionsForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sectionsdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox sectionNameTxtBox;
        private System.Windows.Forms.ComboBox yearLevelComboBox;
        private System.Windows.Forms.Button addSectionBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelSectionBtn;
        private System.Windows.Forms.DataGridView sectionsdataGridView;
        private System.Windows.Forms.ComboBox sectionAdviserComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox filterYearLevelComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}