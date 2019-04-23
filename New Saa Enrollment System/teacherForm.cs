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
    public partial class address : Form
    {
        private StudentRegistration sr;
        private TeacherClass tc;

        private string teacherid;
        public address()
        {
            InitializeComponent();
            tc = new TeacherClass();
        }

        private void teacherForm2cs_Load(object sender, EventArgs e)
        {
            displayTeachers();

            teachersviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            teachersviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            teachersviewGrid.AutoResizeColumns();
            teachersviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            t_updateBtn.Hide();
            teachersviewGrid.Columns["teacher_id"].Visible = false;
        }

        private void t_newBtn_Click(object sender, EventArgs e)
        {
            enableTeacherTxtboxex(true);
        }

        private void t_saveBtn_Click(object sender, EventArgs e)
        {
            tc.addTeacher(
                            t_lastname.Text,
                            t_firstname.Text,
                            t_middlename.SelectedItem.ToString(),
                            t_contact.Text,
                            t_gendercomboBox.SelectedItem.ToString(),
                            t_birthdate.Text,
                            t_age.Text,
                            t_addressrichTextBox.Text
                         );

            tc.getTeachers();
            teachersviewGrid.DataSource = tc.QueryExe();
            t_lastname.Text = String.Empty;
            t_firstname.Text = String.Empty;
            t_middlename.SelectedIndex = -1;
            t_gendercomboBox.SelectedIndex = -1;
            t_contact.Text = String.Empty;
            t_age.Text = String.Empty;
            t_addressrichTextBox.Text = String.Empty;

            MessageBox.Show("Successfully Added!");
        }

        private void t_updateBtn_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Update Teacher Information?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                tc.updateTeacher(
                                t_lastname.Text,
                                t_firstname.Text,
                                t_middlename.SelectedItem.ToString(),
                                t_contact.Text,
                                t_gendercomboBox.SelectedItem.ToString(),
                                t_birthdate.Text,
                                t_age.Text,
                                t_addressrichTextBox.Text,
                                teacherid
                            );

                tc.getTeachers();
                teachersviewGrid.DataSource = tc.QueryExe();
                t_lastname.Text = String.Empty;
                t_firstname.Text = String.Empty;
                t_middlename.SelectedIndex = -1;
                t_gendercomboBox.SelectedIndex = -1;
                t_contact.Text = String.Empty;
                t_age.Text = String.Empty;
                t_addressrichTextBox.Text = String.Empty;
                enableTeacherTxtboxex(false);
                t_newBtn.Enabled = true;
                t_updateBtn.Hide();
                t_saveBtn.Show();

                MessageBox.Show("Teacher Information Updated!");
            }
        }

        private void t_cancelBtn_Click(object sender, EventArgs e)
        {
            teacherid = null;
            t_lastname.Text = String.Empty;
            t_firstname.Text = String.Empty;
            t_middlename.SelectedIndex = -1;
            t_gendercomboBox.SelectedIndex = -1;
            t_contact.Text = String.Empty;
            t_age.Text = String.Empty;
            t_addressrichTextBox.Text = String.Empty;
            t_updateBtn.Hide();
            t_saveBtn.Show();
            t_newBtn.Enabled = true;
            enableTeacherTxtboxex(false);
        }

        private void t_birthdate_ValueChanged(object sender, EventArgs e)
        {
            sr = new StudentRegistration();
            sr.calculateAge(t_birthdate, t_age);
        }

        private void teachersviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.teachersviewGrid.Rows[e.RowIndex];

                    t_lastname.Text = row.Cells["t_lastname"].Value.ToString();
                    t_firstname.Text = row.Cells["t_firstname"].Value.ToString();
                    t_middlename.SelectedIndex = t_middlename.FindStringExact(row.Cells["t_mi"].Value.ToString());
                    t_gendercomboBox.SelectedIndex = t_gendercomboBox.FindStringExact(row.Cells["t_gender"].Value.ToString());
                    t_contact.Text = row.Cells["t_contact"].Value.ToString();
                    t_birthdate.Text = row.Cells["t_birthdate"].Value.ToString();
                    t_age.Text = row.Cells["t_age"].Value.ToString();
                    t_addressrichTextBox.Text = row.Cells["t_address"].Value.ToString();
                    teacherid = row.Cells["teacher_id"].Value.ToString();

                    enableTeacherTxtboxex(true);
                    t_saveBtn.Hide();
                    t_updateBtn.Show();
                    t_newBtn.Enabled = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void enableTeacherTxtboxex(bool value)
        {
            t_lastname.Enabled = value;
            t_firstname.Enabled = value;
            t_middlename.Enabled = value;
            t_gendercomboBox.Enabled = value;
            t_contact.Enabled = value;
            t_birthdate.Enabled = value;
            t_addressrichTextBox.Enabled = value;
        }

        private void teacherViewScheduleBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(teacherid))
            {
                MessageBox.Show("No data selected!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new ViewTeacherScheduleForm(teacherid).ShowDialog();
            }
        }

        private void displayTeachers(string searched = null)
        {
            try
            {
                tc.getTeachers(searched);
                teachersviewGrid.DataSource = tc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void studlastnametextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            displayTeachers(studlastnametextBoxSearch.Text);
        }
    }
}
