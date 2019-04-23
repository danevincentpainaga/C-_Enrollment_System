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
    public partial class StudentStatusForm : Form
    {
        private string studentId, studentStatus;
        RadioButton status;
        OldstudentRegistration or;
        public StudentStatusForm(string student_id, string student_status, RadioButton statusRadio, OldstudentRegistration old)
        {
            InitializeComponent();
            studentId = student_id;
            studentStatus = student_status;
            status = statusRadio;
            or = old;
        }

        private void StudentStatusForm_Load(object sender, EventArgs e)
        {
            if(studentStatus == "enrolled"){
                droppedStatusRadioBtn.Text = "Dropped";
                droppedStatusRadioBtn.ForeColor = Color.Red;
                labelStatus.Text = "Dropped Student?";
            }
            else
            {
                droppedStatusRadioBtn.Text = "Undropped";
                droppedStatusRadioBtn.ForeColor = Color.LimeGreen;
                labelStatus.Text = "Undropped Student?";
            }
        }

        private void statusDroppedCancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void statusDroppedSaveBtn_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Update Student Status?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                OldRegistrationClass oc = new OldRegistrationClass();
                if(droppedStatusRadioBtn.Text == "Dropped")
                {
                    oc.updateEnrolledStudentStatusToDropped(studentId, "dropped");
                    status.Text = "Dropped";
                    or.displayEnrolledstudentsToGrid();
                    status.ForeColor = Color.Orange;
                }
                else
                {
                    oc.updateEnrolledStudentStatusToDropped(studentId, "enrolled");
                    status.Text = "Enrolled";
                    or.displayDroppedStudentsToGrid();
                    status.ForeColor = Color.DeepSkyBlue;
                }
                this.Hide();
            }
        }
    }
}
