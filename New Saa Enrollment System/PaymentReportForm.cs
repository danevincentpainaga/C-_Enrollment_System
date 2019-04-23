using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class PaymentReportForm : Form
    {
        Label lbl;
        LoadingForm lform;
        ReportDocument crypt = new ReportDocument();
        private paymentClass pc;
        private string sid, status;
        public PaymentReportForm(LoadingForm loadingform, Label lb, string stud_id, string studentStatus)
        {
            InitializeComponent();
            lform = loadingform;
            this.sid = stud_id;
            this.status = studentStatus;
            lbl = lb;
        }

        private void PaymentReportForm_Load(object sender, EventArgs e)
        {
            try
            {
               pc = new paymentClass();
               pc.displaySeletedStudentReport(sid, status);
               crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\StudentPaymentCrystalReport.rpt");
               crypt.SetDataSource(pc.datasetQuery("student_table"));
               crystalReportViewer1.ReportSource = crypt;
               crystalReportViewer1.Refresh();
                
               // Hides the loading form
               lform.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            lbl.Text = String.Empty;
        }
    }
}
