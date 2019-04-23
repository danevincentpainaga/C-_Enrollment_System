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
    public partial class ViewTeacherScheduleForm : Form
    {
        private string teacherid;

        ReportDocument crypt = new ReportDocument();
        private TeacherClass tc;

        public ViewTeacherScheduleForm(string tid)
        {
            InitializeComponent();
            tc = new TeacherClass();
            teacherid = tid;
        }

        private void ViewTeacherScheduleForm_Load(object sender, EventArgs e)
        {
            tc.getTeachersSchedule(teacherid);
            crypt.Load(@"C:\Users\enduser\Documents\Visual Studio 2015\Projects\New Saa Enrollment System\New Saa Enrollment System\TeacherSchedCrystalReport.rpt");
            crypt.SetDataSource(tc.datasetQuery("teacher_table"));
            TeacherScheduleCrystalReportViewer.ReportSource = crypt;
            TeacherScheduleCrystalReportViewer.Refresh();
        }
    }
}
