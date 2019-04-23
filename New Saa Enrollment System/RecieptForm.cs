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
    public partial class RecieptForm : Form
    {
        private string studentName, tuitionFee, cash, balance, address, userFullname, change, totalcashpaid, totalbalance;
        public RecieptForm(string studname, string tuitionFee, string totalcashpaid, string totalbalance, string cash, string balance, string address, string userFullname, string change)
        {
            InitializeComponent();
            this.studentName = studname;
            this.tuitionFee = tuitionFee;
            this.cash = cash;
            this.balance = balance;
            this.address = address;
            this.userFullname = userFullname;
            this.change = change;
            this.totalcashpaid = totalcashpaid;
            this.totalbalance = totalbalance;
        }

        private void RecieptForm_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime newDate = DateTime.Parse(today);

            RecieptCrystalReport rcp = new RecieptCrystalReport();
            rcp.SetParameterValue("Name", studentName);
            rcp.SetParameterValue("address", address);
            rcp.SetParameterValue("tuitionfee", tuitionFee);
            rcp.SetParameterValue("cash", cash);
            rcp.SetParameterValue("change", change);
            rcp.SetParameterValue("balance", balance);
            rcp.SetParameterValue("userFullname", userFullname);
            rcp.SetParameterValue("totalcashpaid", totalcashpaid);
            rcp.SetParameterValue("totalbalance", totalbalance);
            rcp.SetParameterValue("date", newDate);
            RecieptcrystalReportViewer.ReportSource = rcp;
            RecieptcrystalReportViewer.ShowCloseButton = false;
            RecieptcrystalReportViewer.ShowCopyButton = false;
            RecieptcrystalReportViewer.ShowExportButton = false;
            RecieptcrystalReportViewer.ShowRefreshButton = false;
            RecieptcrystalReportViewer.Refresh();
        }
    }
}
