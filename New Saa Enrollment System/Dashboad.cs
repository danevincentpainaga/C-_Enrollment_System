using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class Dashboad : UserControl
    {
        private string enrolled, registered, pending, graduate, dropped, cancelled;
        private Panel main;
        private Panel dashboarheader;
        public Dashboad(Panel mainform, Panel header)
        {
            InitializeComponent();
            main = mainform;
            dashboarheader = header;
        }

        private void Dashboad_Load(object sender, EventArgs e)
        {
            dashboarheader.BringToFront();
            displayStatusesCountToGrahp();
            displayYearlevelCount();
        }

        private void Dashboad_ParentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Parent != null)
                {
                    dashboarheader.BringToFront();
                    displayStatusesCountToGrahp();
                    displayYearlevelCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            main.Controls.Clear();
            main.Controls.Add(um);
            dashboarheader.SendToBack();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            ScheduleForm sd = new ScheduleForm();
            main.Controls.Clear();
            main.Controls.Add(sd);
            dashboarheader.SendToBack();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            StudentRegistration sr = new StudentRegistration();
            main.Controls.Clear();
            main.Controls.Add(sr);
            dashboarheader.SendToBack();
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            Payment pm = new Payment();
            main.Controls.Clear();
            main.Controls.Add(pm);
            dashboarheader.SendToBack();
        }

        private void sectioningButton_Click(object sender, EventArgs e)
        {
            Sections s = new Sections();
            main.Controls.Clear();
            main.Controls.Add(s);
            dashboarheader.SendToBack();
        }

        private void enrollmentButton_Click(object sender, EventArgs e)
        {
            if (Form1.EnrollmentLogged == 1)
            {
                Enrollment em = new Enrollment(dashboarheader);
                main.Controls.Clear();
                main.Controls.Add(em);
            }
            else
            {
                EnrollmentConfirmationLogin ec = EnrollmentConfirmationLogin.getInstance(main, dashboarheader);
                ec.Show();
            }
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm rf = new ReportsForm();
            rf.ShowDialog();
        }

        private void OldStudentsRegistratioBtn_Click(object sender, EventArgs e)
        {
            OldstudentRegistration or = new OldstudentRegistration();
            main.Controls.Clear();
            main.Controls.Add(or);
            dashboarheader.SendToBack();
        }

        private void displayStatusesCountToGrahp()
        {
            chart1.Series[0].Points.Clear();

            EnrollmentClass ec = new EnrollmentClass();
            ec.countStudentsBaseOnStatus();
           
            foreach (DataRow dr in ec.QueryExe().Rows)
            {
                enrolled = (string.IsNullOrEmpty(dr["enrolled"].ToString())) ? "0" : dr["enrolled"].ToString();
                registered = (string.IsNullOrEmpty(dr["registered"].ToString())) ? "0" : dr["registered"].ToString();
                pending = (string.IsNullOrEmpty(dr["graduate"].ToString())) ? "0" : dr["graduate"].ToString();
                graduate = (string.IsNullOrEmpty(dr["pending"].ToString())) ? "0" : dr["pending"].ToString();
                dropped = (string.IsNullOrEmpty(dr["dropped"].ToString())) ? "0" : dr["dropped"].ToString();
                cancelled = (string.IsNullOrEmpty(dr["cancelled"].ToString())) ? "0" : dr["cancelled"].ToString();
            }

            this.chart1.Series["Total"].Points.AddXY("Enrolled", enrolled);
            this.chart1.Series["Total"].Points.AddXY("Registered", registered);
            this.chart1.Series["Total"].Points.AddXY("Pending", pending);
            this.chart1.Series["Total"].Points.AddXY("Graduates", graduate);
            this.chart1.Series["Total"].Points.AddXY("Dropped", dropped);
            this.chart1.Series["Total"].Points.AddXY("Cancelled", cancelled);
            chart1.Update();
        }

        private void displayYearlevelCount()
        {
            DashboardClass db = new DashboardClass();
            foreach (DataRow dr in db.QueryExe().Rows)
            {
                firstYearCountLabel.Text = (string.IsNullOrEmpty(dr["firstyear"].ToString())) ? "0" : dr["firstyear"].ToString();
                secondYearCountLabel.Text = (string.IsNullOrEmpty(dr["secondyear"].ToString())) ? "0" : dr["secondyear"].ToString();
                thirdYearCountLabel.Text = (string.IsNullOrEmpty(dr["thirdyear"].ToString())) ? "0" : dr["thirdyear"].ToString();
                fourthYearCountLabel.Text = (string.IsNullOrEmpty(dr["fourthyear"].ToString())) ? "0" : dr["fourthyear"].ToString();
            }
        }

    }
}
