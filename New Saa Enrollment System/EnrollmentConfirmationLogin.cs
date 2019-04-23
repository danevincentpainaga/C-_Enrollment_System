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
    public partial class EnrollmentConfirmationLogin : Form
    {
        private EnrollmentClass ec;
        private static EnrollmentConfirmationLogin instance;
        private Panel mainPanel;
        private Panel db;

        public EnrollmentConfirmationLogin(Panel panel, Panel dashboarheader)
        {
            InitializeComponent();
            ec = new EnrollmentClass();
            mainPanel = panel;
            db = dashboarheader;
        }

        
        public static EnrollmentConfirmationLogin getInstance(Panel panel, Panel dashboarheader = null)
        {
            if (instance == null || instance.IsDisposed)
                instance = new EnrollmentConfirmationLogin(panel, dashboarheader);
            else
                instance.BringToFront();
            return instance;
        }
        

        private void enterEnrollmentModuleBtn_Click(object sender, EventArgs e)
        {
            int result = ec.confirmAdminUsernamePassword(adminusernameTxtBox.Text, adminpasswordTxtBox.Text);
            if (result == 1)
            {
                Form1.EnrollmentLogged = 1;
                Enrollment em = new Enrollment(db);
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(em);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username Password Incorrect","",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
