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
    public partial class EnrollmentStatusReportForm : Form
    {
        ReportDocument crypt = new ReportDocument();
        private string student_status;
        public EnrollmentStatusReportForm(string status)
        {
            InitializeComponent();
            student_status = status;
        }

        private void EnrollmentStatusReportForm_Load(object sender, EventArgs e)
        {
            EnrollmentClass ec = new EnrollmentClass();
            ec.displayStudentsRecords(student_status);
            crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\StudentStatusCrystalReport.rpt");
            crypt.SetDataSource(ec.datasetQuery("student_table"));
            enrollmentStatuscrystalReportViewer.ReportSource = crypt;
            enrollmentStatuscrystalReportViewer.Refresh();
        }
    }
}
