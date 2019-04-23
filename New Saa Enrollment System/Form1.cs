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
    public partial class Form1 : Form
    {
        Thread t;
        ThreadStart ts;

        private Dashboad db;
        private UserManagement um;
        private ScheduleForm sd;
        private StudentRegistration sr;
        private OldstudentRegistration osr;
        private Payment pm;
        private ReportsForm rf;
        private Sections s;

        public static int EnrollmentLogged = 0;

        public Form1(LoginForm lf)
        {
            Thread splash = new Thread(new ThreadStart(startSplashForm));
            splash.Start();
            lf.Hide();
            InitializeComponent();
            timer1.Start();
            db = new Dashboad(mainPanel, dashboarHeaderPanel);
            um = new UserManagement();
            sd = new ScheduleForm();
            sr = new StudentRegistration();
            osr = new OldstudentRegistration();
            pm = new Payment();
            rf = new ReportsForm();
            s = new Sections();
            splash.Abort();
        }

        public void startSplashForm()
        {
            Application.Run(new SplashForm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Username.Text = UserClass.loggedFullname;
            userposition.Text = UserClass.usertype;
            mainPanel.Controls.Clear();
            int loggedid = Convert.ToInt32(UserClass.usertypeId);
            switch (loggedid)
            {
                case 1:
                    mainPanel.Controls.Add(db);
                    break;
                case 2:
                    mainPanel.Controls.Add(osr);
                    registrarRole();
                    break;
                case 3:
                    mainPanel.Controls.Add(pm);
                    cashierRole();
                    break;
            }
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(db);
            dashboarHeaderPanel.BringToFront();
        }

        private void usermanagementBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(um);
        }

        private void newregistrationBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(sr);
        }

        private void oldregistrationBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(osr);
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(pm);
        }

        private void enrollmentBTn_Click(object sender, EventArgs e)
        {
            if (EnrollmentLogged == 1)
            {
                Enrollment em = new Enrollment(dashboarHeaderPanel);
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(em);
            }
            else
            {
                //  new EnrollmentConfirmationLogin(this.mainPanel).ShowDialog();
                EnrollmentConfirmationLogin ec = EnrollmentConfirmationLogin.getInstance(this.mainPanel, dashboarHeaderPanel);
                ec.Show();
            }
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(sd);
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            rf.ShowDialog();
        }

        private void sectioningBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(s);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //System.Environment.Exit(1);
                // Application.Exit();
                this.Hide();
                new LoginForm().Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.TimetoolStripStatusLabel1.Text = datetime.ToString();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //System.Environment.Exit(1);
                // Application.Exit();
                this.Hide();
                new LoginForm().Show();
            }
        }

        private void cashierRole()
        {
            paymentBtn.Location = new Point(0, 1);
            paymentpictureBox.Location = new Point(10, 10);
            dashboardpictureBox.Hide();
            userpictureBox.Hide();
            newregpictureBox.Hide();
            oldregpictureBox.Hide();
            enrollmentpictureBox.Hide();
            reportspictureBox.Hide();
            sectionspictureBox.Hide();
            scheduelpictureBox.Hide();
            dashboardBtn.Hide();
            usermanagementBtn.Hide();
            newregistrationBtn.Hide();
            oldregistrationBtn.Hide();
            enrollmentBTn.Hide();
            scheduleBtn.Hide();
            reportsBtn.Hide();
            sectioningBtn.Hide();
        }

        private void registrarRole()
        {
            newregistrationBtn.Location = new Point(0, 1);
            newregpictureBox.Location = new Point(10, 10);
            oldregistrationBtn.Location = new Point(117, 1);
            oldregpictureBox.Location = new Point(124, 9);
            scheduleBtn.Location = new Point(234, 1);
            scheduelpictureBox.Location = new Point(241, 9);
            reportsBtn.Location = new Point(352, 1);
            reportspictureBox.Location = new Point(358, 9);
            sectioningBtn.Location = new Point(470, 1);
            sectionspictureBox.Location = new Point(476, 10);

            dashboardpictureBox.Hide();
            userpictureBox.Hide();
            enrollmentpictureBox.Hide();
            dashboardBtn.Hide();
            usermanagementBtn.Hide();
            enrollmentBTn.Hide();
        }
    }
}
