using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class ReportsForm : Form
    {
        ReportDocument crypt = new ReportDocument();
        private ReportFormClass rp;
        private ScheduleClass sc;
        public ReportsForm()
        {
            InitializeComponent();
            rp = new ReportFormClass();
            sc = new ScheduleClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rp.displayEnrolledStudents();
            crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\EnrollmentCrystalReport.rpt");
            crypt.SetDataSource(rp.datasetQuery("student_table"));
            EnrollmentcrystalReportViewer.ReportSource = crypt;
            EnrollmentcrystalReportViewer.Refresh();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                sc.displaySchedule();
                crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\ListOfSchedulesCrystalReport.rpt");
                crypt.SetDataSource(sc.datasetQuery("schedule_table"));
                EnrollmentcrystalReportViewer.ReportSource = crypt;
                EnrollmentcrystalReportViewer.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void returnedPaymentsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rp.getReturnpayments();
                crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\ReturnPaymentsCrystalReport.rpt");
                crypt.SetDataSource(rp.datasetQuery("return_table"));
                EnrollmentcrystalReportViewer.ReportSource = crypt;
                EnrollmentcrystalReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listOfPaymentsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rp.getAllPayments();
                crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\ListOfPaymentsCrystalReport.rpt");
                crypt.SetDataSource(rp.datasetQuery("payment"));
                EnrollmentcrystalReportViewer.ReportSource = crypt;
                EnrollmentcrystalReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
