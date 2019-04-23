using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace New_Saa_Enrollment_System
{
    public partial class Payment : UserControl
    {
        private paymentClass pc;
        string paymentInfos = "{0,-20}{1, -30}{2, -25}{3, -30}";
        private string student_id, current_or, idnumber, student_status, totalcashpaid, tuition, totalbalance;
        private string academicyear_id, academic_year, balanceId, tuitionFee, StudentName, address;
        private bool selected = false;
        private double balance;
        private double cash = 0;

        LoadingForm lf;
        Thread t;
        ThreadStart ts;

        public delegate void updateUi();
        public delegate void updateUiDone();

        public Payment()
        {
            InitializeComponent();
            pc = new paymentClass();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            displayYearLevel();
            displayCurrenSchoolYear();
            displayCurrentOr();
            displayPaidStudentsToGrid();

            studlastnametextBoxSearch.Focus();
            cashtextBox.Enabled = false;
            saveNewStudBalanceBtn.Enabled = false;
            editStudPaymentButton.Enabled = false;
            notEnrolledViewGrid.AllowUserToAddRows = false;
            totalFeestextBox.Enabled = false;
            changetextBox.Enabled = false;
            remainingBalancetextBox.Enabled = false;
            paymentFirstnameTxtbox.ReadOnly = true;
            paymentLastnameTxtbox.ReadOnly = true;
            studentIdNumbertxtBox.ReadOnly = true;
            schoolYearComboBox.Enabled = false;
            year_levelgroupBox.Enabled = false;
            paymentMiTxtbox.Enabled = false;
            changetextBox.Text = "0.00";
            cashtextBox.BackColor = Color.White;
            totalFeestextBox.BackColor = Color.White;
            changetextBox.BackColor = Color.White;
            remainingBalancetextBox.BackColor = Color.White;

            paymentviewGrid.Columns["payment_date"].Visible = false;
            paymentviewGrid.Columns["academic_yearId"].Visible = false;
            paymentviewGrid.Columns["sectionId"].Visible = false;
            paymentviewGrid.Columns["grade_levelId"].Visible = false;
            paymentviewGrid.Columns["payment_id"].Visible = false;
            paymentviewGrid.Columns["balance"].Visible = false;
            paymentviewGrid.Columns["total"].Visible = false;
            paymentviewGrid.Columns["cash"].Visible = false;
            paymentviewGrid.Columns["studentId"].Visible = false;
            paymentviewGrid.Columns["student_id"].Visible = false;
            paymentviewGrid.Columns["good_moral_certificate"].Visible = false;
            paymentviewGrid.Columns["nso_birth_certificate"].Visible = false;
            paymentviewGrid.Columns["report_card_form138"].Visible = false;
            paymentviewGrid.Columns["baptismal_certificate"].Visible = false;
            paymentviewGrid.Columns["clearance"].Visible = false;
            paymentviewGrid.Columns["year_level_id"].Visible = false;
            paymentviewGrid.Columns["p_academic_yearId"].Visible = false;
            paymentviewGrid.Columns["reciept_number"].Visible = false;
            paymentviewGrid.Columns["userId"].Visible = false;
            paymentviewGrid.Columns["school_year"].Visible = false;
            yearlevelcomboBox.SelectedIndex = -1;

            formatDataGrid(paymentviewGrid, false);
            formatDataGrid(notEnrolledViewGrid, false);
            formatDataGrid(studentBalancePerYeardataGridView, false);
            
            paymentInfolistBox.Items.Add("\n");
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
            paymentInfolistBox.Items.Add("\n");
     

        }


        private void paymentviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editStudPaymentButton.Enabled = true;
                selected = true;
                try {
                    paymentviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    paymentInfolistBox.Items.Clear();

                    DataGridViewRow row = this.paymentviewGrid.Rows[e.RowIndex];
                    displayStudentBalance(row.Cells["studentId"].Value.ToString());

                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                    paymentInfolistBox.Items.Add("\n");

                    totalFeestextBox.Clear();
                    remainingBalancetextBox.Clear();

                    studentBalancePerYeardataGridView.Columns["firstname"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["lastname"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["mi"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["balance_id"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["academicyearid"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["bal_studentId"].Visible = false;

                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add("\n");

                    studentIdNumbertxtBox.Text = row.Cells["student_no"].Value.ToString();
                    paymentLastnameTxtbox.Text = row.Cells["lastname"].Value.ToString();
                    paymentFirstnameTxtbox.Text = row.Cells["firstname"].Value.ToString();
                    yearlevelcomboBox.SelectedIndex = yearlevelcomboBox.FindStringExact(row.Cells["year_name"].Value.ToString());
                    paymentMiTxtbox.Text = row.Cells["mi"].Value.ToString();
               
                    student_status = row.Cells["student_status"].Value.ToString();
                    student_id = row.Cells["studentId"].Value.ToString();
                    address = row.Cells["address"].Value.ToString();

                    StudentName = row.Cells["Lastname"].Value.ToString()+", "+ row.Cells["firstname"].Value.ToString()+", "+ row.Cells["mi"].Value.ToString()+".";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void searchStudentbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                pc.displayPaidStudents(studlastnametextBoxSearch.Text, studfirstnametextBoxSearch.Text);
                paymentviewGrid.DataSource = pc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newstudentPaymentButton_Click(object sender, EventArgs e)
        {
            //NewPayment up = NewPayment.getInstance(this);
            NewPayment up = new NewPayment(this);
            up.ShowDialog();
        }

        private void studentgroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void viewPaymentBtn_Click(object sender, EventArgs e)
        {
            if (selected == true)
            {
                viewPaymentBtn.Enabled = false;
                ts = new ThreadStart(threadProcess);
                t = new Thread(ts);
                t.Start();
            }
            else
            {
                MessageBox.Show("No Selected Student", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tabText = tabControl1.SelectedIndex;
            switch (tabText)
            {
                case 0:
                    displayPaidStudentsToGrid();
                    break;
                case 1:
                    pc.displayNotEnrolledStudents();
                    notEnrolledViewGrid.DataSource = pc.QueryExe();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cash = 0;
            cashtextBox.Enabled = false;
            saveNewStudBalanceBtn.Enabled = false;
            editStudPaymentButton.Enabled = false;
            selected = false;
            studentBalancePerYeardataGridView.DataSource = null;
            paymentviewGrid.ClearSelection();
            studentIdNumbertxtBox.Text = idnumber;
            yearlevelcomboBox.SelectedIndex = -1;
            totalFeestextBox.Clear();
            remainingBalancetextBox.Clear();
            cashtextBox.Clear();
            paymentLastnameTxtbox.Clear();
            paymentFirstnameTxtbox.Clear();
            paymentInfolistBox.Items.Clear();
            paymentInfolistBox.Items.Add("\n");
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
            paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
            paymentInfolistBox.Items.Add("\n");
        }

        public void UiDosome()
        {
            // Show loading Form
            loadingLabel.Text = "Loading...";
            lf = new LoadingForm();
            lf.Show();
        }

        public void UiDosomeDone()
        {
            // Show Report Form
            loadingLabel.Text = "Report Viewing...";
            viewPaymentBtn.Enabled = true;
            PaymentReportForm prf = new PaymentReportForm(lf, loadingLabel, pc.getStudentId(), student_status);
            prf.ShowDialog();
        }

        public void threadProcess()
        {
            loadingLabel.Invoke(new updateUi(UiDosome));
            Thread.Sleep(500);
            loadingLabel.Invoke(new updateUiDone(UiDosomeDone));
        }

        private void cashtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            new StudentRegistration().makeInputNumberOnly(e);
        }

        private void studlastnametextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchStudentbutton1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void studfirstnametextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchStudentbutton1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void paymentInfolistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editStudPaymentButton_Click(object sender, EventArgs e)
        {
            ReturnPaymentsForm rt = new ReturnPaymentsForm(pc.getStudentId());
            rt.ShowDialog();
        }

        private void cashtextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashtextBox.Text)) { 
                try
                {
                    double total;
                    int cashTendered = 0;
                    bool isNumeric = int.TryParse(cashtextBox.Text, out cashTendered);
                    if (isNumeric == true)
                    {
                        total = Convert.ToDouble(totalFeestextBox.Text);
                        double bal = total - cashTendered;
                        double chg = cashTendered - total;
                        double change = (chg > 0) ? chg : 0.00;
                        cash = (bal > 0) ? cashTendered : total;
                        double newbalance = (bal > 0) ? bal : 0;
                        balance = newbalance;
                        changetextBox.Text = change.ToString() + ".00";
                        remainingBalancetextBox.Text = bal.ToString();
                    }
                    else
                    {
                        total = Convert.ToDouble(totalFeestextBox.Text);
                        double bal = total - cashTendered;
                        double chg = cashTendered - total;
                        double change = (chg > 0) ? chg : 0.00;
                        cash = (bal > 0) ? cashTendered : total;
                        double newbalance = (bal > 0) ? bal : 0;
                        balance = newbalance;
                        changetextBox.Text = change.ToString()+".00";
                        remainingBalancetextBox.Text = bal.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void studentBalancePerYeardataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string totalcash = null;
            if (e.RowIndex >= 0)
            {
                cashtextBox.Enabled = true;
                saveNewStudBalanceBtn.Enabled = true;
                try
                {
                    studentBalancePerYeardataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    paymentInfolistBox.Items.Clear();
                    DataGridViewRow row = this.studentBalancePerYeardataGridView.Rows[e.RowIndex];
                    pc.getTotalAndCashInPayment(row.Cells["bal_studentId"].Value.ToString(), row.Cells["academicyearid"].Value.ToString());
                    
                    foreach (DataRow drow in pc.QueryExe().Rows)
                    {
                        tuitionFee = drow["tuition"].ToString();
                        totalcash = drow["totalcash"].ToString();

                    }
                    
                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 10}", "OR No. " + current_or, ""));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 50}", "Name", "Academic year "+ row.Cells["academic_year"].Value.ToString()));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 50}", row.Cells["firstname"].Value.ToString() + " " + row.Cells["lastname"].Value.ToString() + " " + row.Cells["mi"].Value.ToString() + ".", ""));
                  //  paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 50}", "Address", row.Cells["address"].Value.ToString()));
                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,16}{1, 52}", "Total Fee:", tuitionFee));
                    paymentInfolistBox.Items.Add(String.Format("{0,22}{1, 41}", "Total Cash Paid:", totalcash));
                    paymentInfolistBox.Items.Add(String.Format("{0,20}{1, 45}", "Total Balance:", row.Cells["bal_balance"].Value.ToString()));
                    totalFeestextBox.Text = row.Cells["bal_balance"].Value.ToString();

             
                    balanceId = row.Cells["balance_id"].Value.ToString();
                    totalcashpaid = totalcash;
                    tuition = tuitionFee;
                    totalbalance = row.Cells["bal_balance"].Value.ToString();
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void saveNewStudBalanceBtn_Click(object sender, EventArgs e)
        {
            if (cash > 0) {
                var response = MessageBox.Show("Update Remaining Balance?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    DataRowView oDataRowView = schoolYearComboBox.SelectedItem as DataRowView;
                    academic_year = oDataRowView.Row["academic_year"] as string;

                    string today = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                    DateTime newDate = DateTime.Parse(today);

                    RecieptForm rcf = new RecieptForm(
                                                        StudentName, tuitionFee,
                                                        totalcashpaid,
                                                        totalbalance,
                                                        cash.ToString(),
                                                        balance.ToString(),
                                                        address,
                                                        UserClass.loggedFullname,
                                                        changetextBox.Text
                                                     );

                    rcf.ShowDialog();

                    pc.savePaymentAndNewBalanceDetails(
                                                            student_id,
                                                            current_or,
                                                            tuitionFee,
                                                            totalbalance,
                                                            cash.ToString(),
                                                            balance.ToString(),
                                                            UserClass.userid,
                                                            schoolYearComboBox.SelectedValue.ToString(),
                                                            academic_year,
                                                            newDate,
                                                            balanceId
                                                       );
                    cash = 0;
                    displayCurrentOr();
                    displayStudentBalance(this.student_id);
                    paymentInfolistBox.Items.Clear();
                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academey"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                    totalFeestextBox.Clear();
                    cashtextBox.Clear();
                    remainingBalancetextBox.Clear();
                    changetextBox.Text = "0.00";
                }
            }
            else
            {
                MessageBox.Show("Enter Cash Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void notEnrolledViewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    notEnrolledViewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    paymentInfolistBox.Items.Clear();

                    DataGridViewRow row = this.notEnrolledViewGrid.Rows[e.RowIndex];
                    displayStudentBalance(row.Cells["studentId"].Value.ToString());

                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                    paymentInfolistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                    paymentInfolistBox.Items.Add("\n");

                    totalFeestextBox.Clear();
                    remainingBalancetextBox.Clear();

                    studentBalancePerYeardataGridView.Columns["firstname"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["lastname"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["mi"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["balance_id"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["academicyearid"].Visible = false;
                    studentBalancePerYeardataGridView.Columns["bal_studentId"].Visible = false;
                    paymentInfolistBox.Items.Add("\n");
                    paymentInfolistBox.Items.Add("\n");

                    studentIdNumbertxtBox.Text = row.Cells["student_no"].Value.ToString();
                    paymentLastnameTxtbox.Text = row.Cells["lastname"].Value.ToString();
                    paymentFirstnameTxtbox.Text = row.Cells["firstname"].Value.ToString();
                    yearlevelcomboBox.SelectedIndex = yearlevelcomboBox.FindStringExact(row.Cells["year_name"].Value.ToString());
                    paymentMiTxtbox.Text = row.Cells["mi"].Value.ToString();

                    student_status = row.Cells["student_status"].Value.ToString();
                    student_id = row.Cells["studentId"].Value.ToString();

                    StudentName = row.Cells["Lastname"].Value.ToString() + ", " + row.Cells["firstname"].Value.ToString() + ", " + row.Cells["mi"].Value.ToString() + ".";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public void displayPaidStudentsToGrid()
        {
            try
            {
                pc.displayPaidStudents();
                paymentviewGrid.DataSource = pc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatDataGrid(DataGridView datagrid, bool value)
        {
            datagrid.AllowUserToAddRows = value;
            datagrid.DefaultCellStyle.SelectionBackColor = Color.White;
            datagrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            datagrid.AutoResizeColumns();
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void displayCurrentOr()
        {
            try
            {
                pc.getCurrentOrnum();
                foreach (DataRow dr in pc.QueryExe().Rows)
                {
                    current_or = dr["setted_reciept_number"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayStudentBalance(string studentid)
        {
            pc.setStudentId(studentid);

            pc.getStudentBalancePerAcademicYear();
            studentBalancePerYeardataGridView.DataSource = pc.QueryExe();
        }

        private void displayCurrenSchoolYear()
        {
            try
            {
                pc.getCurrentIdAndScholYear();
                foreach (DataRow dr in pc.QueryExe().Rows)
                {
                    schoolYearComboBox.ValueMember = "academic_id";
                    schoolYearComboBox.DisplayMember = "academic_year";
                    schoolYearComboBox.DataSource = pc.QueryExe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayYearLevel()
        {
            try
            {
                pc.getYearLevel();
                yearlevelcomboBox.ValueMember = "year_level_id";
                yearlevelcomboBox.DisplayMember = "year_name";
                yearlevelcomboBox.DataSource = pc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
