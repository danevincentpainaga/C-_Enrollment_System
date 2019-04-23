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
    public partial class NewpaymentRecieptForm : Form
    {
        Dictionary<string, string> rc;
        public NewpaymentRecieptForm(Dictionary<string, string> rd)
        {
            InitializeComponent();
            rc = rd;
        }

        private void NewpaymentRecieptForm_Load(object sender, EventArgs e)
        {
            NewpaymentRecieptCrystalReport ncp = new NewpaymentRecieptCrystalReport();

            ncp.SetParameterValue("ornumber", rc["ornumber"]);
            ncp.SetParameterValue("tuition_fee", rc["tuition_fee"]);
            ncp.SetParameterValue("athletic", rc["athletic"]);
            ncp.SetParameterValue("laboratory", rc["laboratory"]);
            ncp.SetParameterValue("library", rc["library"]);
            ncp.SetParameterValue("registration", rc["registration"]);
            ncp.SetParameterValue("medical_dental", rc["medical_dental"]);
            ncp.SetParameterValue("test_materials", rc["test_materials"]);
            ncp.SetParameterValue("general_support_services", rc["general_support_services"]);
            ncp.SetParameterValue("adce", rc["adce"]);
            ncp.SetParameterValue("insurance", rc["insurance"]);
            ncp.SetParameterValue("nassphil", rc["nassphil"]);
            ncp.SetParameterValue("student_council_fee", rc["student_council_fee"]);
            ncp.SetParameterValue("ceap", rc["ceap"]);
            ncp.SetParameterValue("total", rc["total"]);
            ncp.SetParameterValue("cash", rc["cash"]);
            ncp.SetParameterValue("change", rc["change"]);
            ncp.SetParameterValue("balance", rc["balance"]);
            newpaymentcrystalReportViewer.ReportSource = ncp;
            newpaymentcrystalReportViewer.ShowCloseButton = false;
            newpaymentcrystalReportViewer.ShowCopyButton = false;
            newpaymentcrystalReportViewer.ShowExportButton = false;
            newpaymentcrystalReportViewer.ShowRefreshButton = false;
            newpaymentcrystalReportViewer.Refresh();
        }
    }
}
