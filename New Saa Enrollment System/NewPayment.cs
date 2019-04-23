using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace New_Saa_Enrollment_System
{
    public partial class NewPayment : Form
    {
        private int totalStandardFee, totalNonStandardFee, grandTotal;
        private string tuition, med, athletic, lab, lib, registration, test, lname, fname, mi, section, yr_level, student_no;
        private string gen, adce, ins, nass, stud, ceap;

        private StudentRegistration sr;

        public NewPayment(Payment paymentForm = null)
        {
            InitializeComponent();
            p = paymentForm;
            np = new NewPaymentClass();
            sr = new StudentRegistration();
        }

        private void UpdatePayment_Load(object sender, EventArgs e)
        {
            displayRegisteredStudentsToGrid();
            displayCurrentOrNumber();

            newpaymentviewGrid.Columns["academic_yearId"].Visible = false;
            newpaymentviewGrid.Columns["sectionId"].Visible = false;
            newpaymentviewGrid.Columns["grade_levelId"].Visible = false;
            newpaymentviewGrid.Columns["student_id"].Visible = false;
            //newpaymentviewGrid.Columns["section_id"].Visible = false;
            newpaymentviewGrid.Columns["good_moral_certificate"].Visible = false;
            newpaymentviewGrid.Columns["nso_birth_certificate"].Visible = false;
            newpaymentviewGrid.Columns["report_card_form138"].Visible = false;
            newpaymentviewGrid.Columns["baptismal_certificate"].Visible = false;
            newpaymentviewGrid.Columns["clearance"].Visible = false;
            newpaymentviewGrid.Columns["year_level_id"].Visible = false;
            // newpaymentviewGrid.Columns["max_grade"].Visible = false;
            //  newpaymentviewGrid.Columns["min_grade"].Visible = false;
            newpaymentviewGrid.Columns["medical_dental"].Visible = false;
            newpaymentviewGrid.Columns["tuition_fee"].Visible = false;
            newpaymentviewGrid.Columns["athletic"].Visible = false;
            newpaymentviewGrid.Columns["laboratory"].Visible = false;
            newpaymentviewGrid.Columns["library"].Visible = false;
            newpaymentviewGrid.Columns["registration"].Visible = false;
            newpaymentviewGrid.Columns["test_materials"].Visible = false;
            newpaymentviewGrid.Columns["general_support_services"].Visible = false;
            newpaymentviewGrid.Columns["adce"].Visible = false;
            newpaymentviewGrid.Columns["insurance"].Visible = false;
            newpaymentviewGrid.Columns["student_council_fee"].Visible = false;
            newpaymentviewGrid.Columns["ceap"].Visible = false;
            newpaymentviewGrid.Columns["nassphil"].Visible = false;
            // newpaymentviewGrid.Columns["section_limit"].Visible = false;
            // newpaymentviewGrid.Columns["adviser"].Visible = false;
            newpaymentcashtextBox.Enabled = false;
            totalPaymentTxtBox.Enabled = false;
            totalPaymentTxtBox.ForeColor = Color.Red;
            totalPaymentTxtBox.BackColor = Color.White;
            totalPaymentTxtBox.BackColor = Color.White;
            newpaymentcashtextBox.BackColor = Color.White;
            changeTxtBox.ReadOnly = true;
            newpaymentviewGrid.AllowUserToAddRows = false;
            totalPaymentTxtBox.Text = "0.00";


            newpaymentviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            newpaymentviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;

            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
        }

        private void newpaymentcashtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            new StudentRegistration().makeInputNumberOnly(e);
        }

        private void newpaymentcashtextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(newpaymentcashtextBox.Text))
            {
                try
                {
                    int cashTendered = 0;
                    bool isNumeric = int.TryParse(newpaymentcashtextBox.Text, out cashTendered);
                    if (isNumeric == true)
                    {
                        total = Convert.ToDouble(totalPaymentTxtBox.Text);
                        double bal = total - cashTendered;
                        double chg = cashTendered - total;
                        double change = (chg > 0) ? chg : 0.00;
                        cash = (bal > 0) ? cashTendered : total;
                        double newbalance = (bal > 0) ? bal : 0;
                        balance = newbalance;
                        changeTxtBox.Text = change.ToString();
                    }
                    else
                    {
                        total = Convert.ToDouble(totalPaymentTxtBox.Text);
                        double bal = total - cashTendered;
                        double chg = cashTendered - total;
                        double change = (chg > 0) ? chg : 0.00;
                        cash = (bal > 0) ? cashTendered : total;
                        double newbalance = (bal > 0) ? bal : 0;
                        balance = newbalance;
                        changeTxtBox.Text = change.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cashtextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private string student_id, current_ornum, academicyear_id, academic_year;
        private double total, balance;
        private double cash;
        private NewPaymentClass np;
        private static NewPayment instance;
        private readonly Payment p;

        /*
        public static NewPayment getInstance(Payment paymentForm)
        {
            if (instance == null || instance.IsDisposed)
                instance = new NewPayment(paymentForm);
            else
                instance.BringToFront();
            return instance;
        }
        */

        private void newpaymentviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  int totalStandardFee, totalNonStandardFee, grandTotal;
           // string tuition, med, athletic, lab, lib, registration, test, lname, fname, mi, section, yr_level, student_no;
           // string gen, adce, ins, nass, stud, ceap;
            
            if (e.RowIndex >= 0)
            {
                newpaymentcashtextBox.Enabled = true;
                newpaymentlistBox.Items.Clear();
                DataGridViewRow row = this.newpaymentviewGrid.Rows[e.RowIndex];

                totalStandardFee = Convert.ToInt32(row.Cells["medical_dental"].Value) +
                                   Convert.ToInt32(row.Cells["athletic"].Value) +
                                   Convert.ToInt32(row.Cells["laboratory"].Value) +
                                   Convert.ToInt32(row.Cells["library"].Value) +
                                   Convert.ToInt32(row.Cells["test_materials"].Value) +
                                   Convert.ToInt32(row.Cells["registration"].Value);

                totalNonStandardFee =  Convert.ToInt32(row.Cells["general_support_services"].Value) +
                                       Convert.ToInt32(row.Cells["adce"].Value) +
                                       Convert.ToInt32(row.Cells["insurance"].Value) +
                                       Convert.ToInt32(row.Cells["nassphil"].Value) +
                                       Convert.ToInt32(row.Cells["student_council_fee"].Value) +
                                       Convert.ToInt32(row.Cells["ceap"].Value);

                grandTotal = totalStandardFee + totalNonStandardFee + Convert.ToInt32(row.Cells["tuition_fee"].Value);
                totalPaymentTxtBox.Text = Convert.ToString(grandTotal)+".00";

                lname = row.Cells["lastname"].Value.ToString();
                fname = row.Cells["firstname"].Value.ToString();
                mi = row.Cells["mi"].Value.ToString();
                //section = row.Cells["section_name"].Value.ToString();
                yr_level = row.Cells["year_name"].Value.ToString();
                tuition = row.Cells["tuition_fee"].Value.ToString();
                med = row.Cells["medical_dental"].Value.ToString();
                athletic = row.Cells["athletic"].Value.ToString();
                lab = row.Cells["laboratory"].Value.ToString();
                lib = row.Cells["library"].Value.ToString();
                test = row.Cells["test_materials"].Value.ToString();
                registration = row.Cells["registration"].Value.ToString();
                gen = row.Cells["general_support_services"].Value.ToString();
                adce = row.Cells["adce"].Value.ToString();
                ins = row.Cells["insurance"].Value.ToString();
                nass = row.Cells["nassphil"].Value.ToString();
                stud = row.Cells["student_council_fee"].Value.ToString();
                ceap = row.Cells["ceap"].Value.ToString();
                student_no = row.Cells["student_no"].Value.ToString();
                student_id = row.Cells["student_id"].Value.ToString();
                academicyear_id = row.Cells["academic_yearId"].Value.ToString();
                academic_year = row.Cells["academic_year"].Value.ToString();

                newpaymentlistBox.Items.Add("\n");
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                newpaymentlistBox.Items.Add("\n");
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 10}", "OR No. "+ current_ornum, ""));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 40}", "Name", yr_level + " year"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 41}", lname+", "+fname+", "+mi+".",""));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 62}", "Fees", "Amount"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 62}", "STANDARD SCHOOL FEES", ""));
                newpaymentlistBox.Items.Add(String.Format("{0, 20}{1, 58}", "Tuition Fee", tuition));
                newpaymentlistBox.Items.Add(String.Format("{0, 25}{1, 49}", "Registration Fee", registration));
                newpaymentlistBox.Items.Add(String.Format("{0, 20}{1, 58}", "Library Fee", lib));
                newpaymentlistBox.Items.Add(String.Format("{0, 23}{1, 51}", "Laboratory Fee", lab));
                newpaymentlistBox.Items.Add(String.Format("{0, 21}{1, 57}", "Atlethic Fee", athletic));
                newpaymentlistBox.Items.Add(String.Format("{0, 27}{1, 44}", "Medical/Dental Fee", med));
                newpaymentlistBox.Items.Add(String.Format("{0, 23}{1, 52}", "Test Materials", test));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 63}", "", "___________"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 64}", "", "Php"+ totalStandardFee + ".00"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 62}", "NON-STANDARD SCHOOL FEES", ""));
                newpaymentlistBox.Items.Add(String.Format("{0, 33}{1, 34}", "General Support Services", gen));
                newpaymentlistBox.Items.Add(String.Format("{0, 13}{1, 66}", "ADCE", adce));
                newpaymentlistBox.Items.Add(String.Format("{0, 18}{1, 60}", "Insurance", ins));
                newpaymentlistBox.Items.Add(String.Format("{0, 17}{1, 58}", "NASSPHIL", nass));
                newpaymentlistBox.Items.Add(String.Format("{0, 28}{1, 43}", "Student Council Fee", stud));
                newpaymentlistBox.Items.Add(String.Format("{0, 13}{1, 66}", "CEAP", ceap));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 63}", "", "___________"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 64}", "", "Php" + totalNonStandardFee + ".00"));

                newpaymentlistBox.Items.Add("\n");
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 53}", "TOTAL FEES", "Php "+ grandTotal + ".00"));
            }
        }

        private void closeNewPaymentBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            newpaymentlistBox.Items.Clear();
            newpaymentlistBox.Items.Add("\n");
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
            totalPaymentTxtBox.Clear();
            newpaymentcashtextBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newpaymentcashtextBox.Enabled = false;
            newpaymentlistBox.Items.Clear();
            newpaymentlistBox.Items.Add("\n");
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
            newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
            totalPaymentTxtBox.Clear();
        }

        private void searchStudentbutton1_Click(object sender, EventArgs e)
        {
            displayRegisteredStudentsToGrid(newpaymentSearchNameTxtbox.Text);
        }

        private void newpaymentSearchNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            displayRegisteredStudentsToGrid(newpaymentSearchNameTxtbox.Text);
        }

        private void savePaymentBtn_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Save Payment?","",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(response == DialogResult.Yes) {
                newpaymentcashtextBox.Enabled = false;
                string today = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DateTime newDate = DateTime.Parse(today);

                Dictionary<string, string> rd = new Dictionary<string, string>();
                rd.Add("ornumber", current_ornum);
                rd.Add("tuition_fee", tuition);
                rd.Add("athletic", athletic);
                rd.Add("laboratory", lab);
                rd.Add("library", lib);
                rd.Add("registration", registration);
                rd.Add("medical_dental", med);
                rd.Add("test_materials", test);
                rd.Add("general_support_services", gen);
                rd.Add("adce", adce);
                rd.Add("insurance", ins);
                rd.Add("nassphil", nass);
                rd.Add("student_council_fee", stud);
                rd.Add("ceap", ceap);
                rd.Add("cash", cash.ToString());
                rd.Add("total", grandTotal.ToString());
                rd.Add("change", changeTxtBox.Text);
                rd.Add("balance", balance.ToString());


                new NewpaymentRecieptForm(rd).ShowDialog();
                
                np.insertPaymentDetails(
                                            student_id,
                                            current_ornum,
                                            totalPaymentTxtBox.Text,
                                            total.ToString(),
                                            cash.ToString(),
                                            balance.ToString(),
                                            UserClass.userid,
                                            academicyear_id,
                                            academic_year,
                                            newDate
                                       );
                

                displayCurrentOrNumber();
                int rowIndex = newpaymentviewGrid.CurrentCell.RowIndex;
                newpaymentviewGrid.Rows.RemoveAt(rowIndex);
                p.displayPaidStudentsToGrid();
                p.displayCurrentOr();
                newpaymentlistBox.Items.Clear();
                newpaymentlistBox.Items.Add("\n");
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "St. Augustine Academeny"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 35}", "", "TIN: 000-582-423-000-NV"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 32}", "", "OFFICIAL RECIEPT"));
                totalPaymentTxtBox.Clear();
                newpaymentcashtextBox.Clear();
     
            }
        }

        public void displayRegisteredStudentsToGrid(string studentName = null)
        {
            np = new NewPaymentClass();
            np.displayRegisteredStudents(studentName);
            try
            {
                newpaymentviewGrid.DataSource = np.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayCurrentOrNumber()
        {
            np.getCurrentOrnum();
            try
            {
                foreach (DataRow dr in np.QueryExe().Rows)
                {
                    current_ornum = dr["setted_reciept_number"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
