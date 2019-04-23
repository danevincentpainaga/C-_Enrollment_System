using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class SubjectsForm : Form
    {
        private SubjectsClass sb;

        private string subjectId;

        public SubjectsForm()
        {
            InitializeComponent();
            sb = new SubjectsClass();
        }

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            try {
                sb.getSubjects();
                subjectsviewGrid.DataSource = sb.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            subjectsviewGrid.AllowUserToAddRows = false;
            subjectsviewGrid.Columns["subject_id"].Visible = false;

            subjectsviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            subjectsviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            subjectsviewGrid.AutoResizeColumns();
            subjectsviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void subjectSaveUpdateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(subjectNameTxtbox.Text) || !string.IsNullOrEmpty(subjectDescriptionrichTextBox.Text))
            {
                if (subjectSaveUpdateBtn.Text == "SAVE")
                {
                    sb.addSubjects(
                                    subjectNameTxtbox.Text,
                                    subjectDescriptionrichTextBox.Text
                               );

                    subjectNameTxtbox.Text = String.Empty;
                    subjectDescriptionrichTextBox.Text = String.Empty;
                    sb.getSubjects();
                    subjectsviewGrid.DataSource = sb.QueryExe();
                }
                else
                {
                    var res = MessageBox.Show("Update Subject Details?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(res == DialogResult.Yes) { 
                        sb.updateSubjects(
                                            subjectId,
                                            subjectNameTxtbox.Text,
                                            subjectDescriptionrichTextBox.Text
                                         );
                        sb.getSubjects();
                        subjectsviewGrid.DataSource = sb.QueryExe();
                    }
                }
            }
            else
            {
                MessageBox.Show("Form is Empty!");
            }
        }

        private void subjectsviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.subjectsviewGrid.Rows[e.RowIndex];

                    subjectNameTxtbox.Text = row.Cells["subject_name"].Value.ToString();
                    subjectDescriptionrichTextBox.Text = row.Cells["description"].Value.ToString();
                    subjectId = row.Cells["subject_id"].Value.ToString();
                    subjectSaveUpdateBtn.Text = "UPDATE";

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void subjectcancelBtn_Click(object sender, EventArgs e)
        {
            subjectSaveUpdateBtn.Text = "SAVE";
            subjectNameTxtbox.Text = String.Empty;
            subjectDescriptionrichTextBox.Text = String.Empty;
        }
    }
}
