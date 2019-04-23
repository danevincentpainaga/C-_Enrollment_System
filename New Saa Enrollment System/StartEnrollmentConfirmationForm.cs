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
    public partial class StartEnrollmentConfirmationForm : Form
    {
        public delegate void sendTextCallBack();
        public sendTextCallBack sendTextValue;
        private string academicyear;
        private EnrollmentClass ec;
        public StartEnrollmentConfirmationForm(string academincYear)
        {
            InitializeComponent();
            ec = new EnrollmentClass();
            academicyear = academincYear;
        }

        private void startEnrollmentBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(adminStartUsernameTxtBox.Text) || string.IsNullOrEmpty(adminStartPasswordTxtBox.Text)) { 
                MessageBox.Show("Please complete the Form");
            }
            else
            {
                int confirmation = ec.confirmAdminUsernamePassword(adminStartUsernameTxtBox.Text, adminStartPasswordTxtBox.Text);
                if (confirmation == 1)
                {
                    var result = MessageBox.Show("Are you sure you want Start Enrollment Process?All Enrolled Student Status Will Change to Pending.", "Start Enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string today = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        DateTime date = DateTime.Parse(today);
                        ec.addAcademicYears(academicyear, date);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Cancelled");
                    }
                }
                else
                {
                    MessageBox.Show("Username/Password Incorrect!","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



    }
}
