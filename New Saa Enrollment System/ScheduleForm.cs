using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace New_Saa_Enrollment_System
{
    public partial class ScheduleForm : UserControl
    {
        address tf = null;
        private ScheduleClass sd;
        private paymentClass pc;

        string sValue = string.Empty;
        private string scheduleId;

        public ScheduleForm()
        {
            InitializeComponent();
            sd = new ScheduleClass();
            pc = new paymentClass();
        }

        private void tpictureBox_Click(object sender, EventArgs e)
        {
            if (tf == null)
            {
                tf = new address();
            }
            tf.ShowDialog();
            tf.BringToFront();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

            try
            {
                sd.getAcademicYears();
                schoolyearcomboBox.ValueMember = "academic_id";
                schoolyearcomboBox.DisplayMember = "academic_year";
                schoolyearcomboBox.DataSource = sd.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                pc.getYearLevel();
                schedGradeLevelcomboBox.ValueMember = "year_level_id";
                schedGradeLevelcomboBox.DisplayMember = "year_name";
                schedGradeLevelcomboBox.DataSource = pc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                sd.getSubjects();
                schedsubjectcomboBox.ValueMember = "subject_id";
                schedsubjectcomboBox.DisplayMember = "subject_name";
                schedsubjectcomboBox.DataSource = sd.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                sd.getTeachers();
                schedinstructorcomboBox.ValueMember = "teacher_id";
                schedinstructorcomboBox.DisplayMember = "teachername";
                schedinstructorcomboBox.DataSource = sd.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                sd.getRooms();
                schedroomcomboBox.ValueMember = "room_id";
                schedroomcomboBox.DisplayMember = "room_name";
                schedroomcomboBox.DataSource = sd.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            scheduleviewGrid.AllowUserToAddRows = false;

            scheduleviewGrid.Columns["year_levelId"].Visible = false;
            scheduleviewGrid.Columns["section_ref_id"].Visible = false;
            scheduleviewGrid.Columns["subjectId"].Visible = false;
            scheduleviewGrid.Columns["teacherId"].Visible = false;
            scheduleviewGrid.Columns["roomId"].Visible = false;
            scheduleviewGrid.Columns["academicyear_id"].Visible = false;
            scheduleviewGrid.Columns["schedule_id"].Visible = false;
            scheduleviewGrid.Columns["subject_id"].Visible = false;
            savebutton.Enabled = false;

            scheduleviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            scheduleviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            scheduleviewGrid.AutoResizeColumns();
            scheduleviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void spictureBox_Click(object sender, EventArgs e)
        {
            SubjectsForm sf = new SubjectsForm();
            sf.ShowDialog();
        }

        private void rpictureBox_Click(object sender, EventArgs e)
        {
            RoomsForm rf = new RoomsForm();
            rf.ShowDialog();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            try
            {
                sd.addSchedulePerYear(
                                        schedGradeLevelcomboBox.SelectedValue.ToString(),
                                        schedsectioncomboBox.SelectedValue.ToString(),
                                        schedsubjectcomboBox.SelectedValue.ToString(),
                                        schedinstructorcomboBox.SelectedValue.ToString(),
                                        schedstartcomboBox.SelectedItem.ToString(),
                                        schedendcomboBox.SelectedItem.ToString(),
                                        schedroomcomboBox.SelectedValue.ToString(),
                                        scheddaycomboBox.SelectedItem.ToString(),
                                        schoolyearcomboBox.SelectedValue.ToString()
                                     );

                sd.displaySchedule(sValue);
                scheduleviewGrid.DataSource = sd.QueryExe();
                scheddaycomboBox.SelectedIndex = -1;
                schedroomcomboBox.SelectedIndex = - 1;
                schedinstructorcomboBox.SelectedIndex = -1;
                schedstartcomboBox.SelectedIndex = -1;
                schedendcomboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void schedGradeLevelcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (schedGradeLevelcomboBox.SelectedValue.ToString() != null)
            {
                sValue = schedGradeLevelcomboBox.SelectedValue.ToString();
                try
                {
                    sd.getSections(sValue);
                    schedsectioncomboBox.ValueMember = "section_id";
                    schedsectioncomboBox.DisplayMember = "section_name";
                    schedsectioncomboBox.DataSource = sd.QueryExe();
                  
                    sd.displaySchedule(sValue);
                    scheduleviewGrid.DataSource = sd.QueryExe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void newbutton_Click(object sender, EventArgs e)
        {
            schedGradeLevelcomboBox.Enabled = true;
            schedsectioncomboBox.Enabled = true;
            schedsubjectcomboBox.Enabled = true;
            schedinstructorcomboBox.Enabled = true;
            schedstartcomboBox.Enabled = true;
            schedendcomboBox.Enabled = true;
            schedroomcomboBox.Enabled = true;
            scheddaycomboBox.Enabled = true;
            savebutton.Enabled = true;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Update Schedule?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                sd.updateSchedulePerYear(
                                    schedGradeLevelcomboBox.SelectedValue.ToString(),
                                    schedsectioncomboBox.SelectedValue.ToString(),
                                    schedsubjectcomboBox.SelectedValue.ToString(),
                                    schedinstructorcomboBox.SelectedValue.ToString(),
                                    schedstartcomboBox.SelectedItem.ToString(),
                                    schedendcomboBox.SelectedItem.ToString(),
                                    schedroomcomboBox.SelectedValue.ToString(),
                                    scheddaycomboBox.SelectedItem.ToString(),
                                    schoolyearcomboBox.SelectedValue.ToString(),
                                    scheduleId
                                 );
            
                sd.displaySchedule(sValue);
                scheduleviewGrid.DataSource = sd.QueryExe();
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            schedGradeLevelcomboBox.Enabled = false;
            schedsectioncomboBox.Enabled = false;
            schedsubjectcomboBox.Enabled = false;
            schedinstructorcomboBox.Enabled = false;
            schedstartcomboBox.Enabled = false;
            schedendcomboBox.Enabled = false;
            schedroomcomboBox.Enabled = false;
            scheddaycomboBox.Enabled = false;
            schoolyearcomboBox.Enabled = false;
            savebutton.Enabled = false;
            savebutton.Show();
            updatebtn.Hide();
            newbutton.Enabled = true;

            schedGradeLevelcomboBox.SelectedIndex = 0;
            schedsectioncomboBox.SelectedIndex = 0;
            schedsubjectcomboBox.SelectedIndex = 0;
            schedinstructorcomboBox.SelectedIndex = 0;
            schedstartcomboBox.SelectedIndex = -1;
            schedendcomboBox.SelectedIndex = -1;
            schedroomcomboBox.SelectedIndex = 0;
            scheddaycomboBox.SelectedIndex = -1;
        }

        private void scheduleviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.scheduleviewGrid.Rows[e.RowIndex];
                    schedGradeLevelcomboBox.SelectedIndex = schedGradeLevelcomboBox.FindStringExact(row.Cells["year_name"].Value.ToString());
                    schedsectioncomboBox.SelectedIndex = schedsectioncomboBox.FindStringExact(row.Cells["section_name"].Value.ToString());
                    
                    schedsubjectcomboBox.SelectedIndex = schedsubjectcomboBox.FindStringExact(row.Cells["subject_name"].Value.ToString());
                    schedinstructorcomboBox.SelectedIndex = schedinstructorcomboBox.FindStringExact(row.Cells["teacherName"].Value.ToString());
                    schedstartcomboBox.SelectedIndex = schedstartcomboBox.FindStringExact(row.Cells["time_start"].Value.ToString());
                    schedendcomboBox.SelectedIndex = schedendcomboBox.FindStringExact(row.Cells["time_end"].Value.ToString());
                    schedroomcomboBox.SelectedIndex = schedroomcomboBox.FindStringExact(row.Cells["room_name"].Value.ToString());
                    scheddaycomboBox.SelectedIndex = scheddaycomboBox.FindStringExact(row.Cells["day"].Value.ToString());
                    schoolyearcomboBox.SelectedIndex = schoolyearcomboBox.FindStringExact(row.Cells["academic_year"].Value.ToString());
                    scheduleId = row.Cells["schedule_id"].Value.ToString();

                    schedsectioncomboBox.Enabled = true;
                    schedsubjectcomboBox.Enabled = true;
                    schedinstructorcomboBox.Enabled = true;
                    schedstartcomboBox.Enabled = true;
                    schedendcomboBox.Enabled = true;
                    schedroomcomboBox.Enabled = true;
                    scheddaycomboBox.Enabled = true;
                    savebutton.Enabled = true;
                    savebutton.Enabled = false;
                    savebutton.Hide();
                    updatebtn.Show();
                    newbutton.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void secpictureBox_Click(object sender, EventArgs e)
        {
            new AddSectionsForm().ShowDialog();
        }

        private void scheduletextBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}