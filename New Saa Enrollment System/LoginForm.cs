using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class LoginForm : Form
    {
        private UserClass uc;
        public LoginForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        
        private void loginBtn_Click(object sender, EventArgs e)
        {
            uc = new UserClass();
            int valid = uc.login(usernameTxtBox.Text, passwordTxtBox.Text);
            if (usernameTxtBox.Text == "" && passwordTxtBox.Text == "")
            {

                MessageBox.Show("Please enter username and password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxtBox.Focus();
                return;
            }
            if (usernameTxtBox.Text == "")
            {
                MessageBox.Show("Please enter username!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxtBox.Focus();
                return;
            }
            if (passwordTxtBox.Text == "")
            {
                MessageBox.Show("Please enter password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTxtBox.Focus();
                return;
            }
        
                  
            if (valid == 1)
            {
                Form1 f1 = new Form1(this);
                f1.Show();
            }
            else if (valid > 1)
            {
                MessageBox.Show("Duplicate User Account!");
                usernameTxtBox.Focus();
            }
           
            else
            {
                MessageBox.Show("Username/Password Incorrect!");
                usernameTxtBox.Clear();
                passwordTxtBox.Clear();
                usernameTxtBox.Focus();
            
        }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(Environment.ExitCode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.time.Text = datetime.ToString();
        }

        private void passworCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passworCheckBox.Checked)
            {
                passwordTxtBox.UseSystemPasswordChar = false;

            }
            else
            {
                passwordTxtBox.UseSystemPasswordChar = true;
            }
        }
    }
}
