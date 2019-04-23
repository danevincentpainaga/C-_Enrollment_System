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
    public partial class ReturnPaymentsForm : Form
    {
        private string balance, student_id, ornum, total;
        private ReturnClass rc;
        public ReturnPaymentsForm(string studentid)
        {
            InitializeComponent();
            rc = new ReturnClass();
            this.student_id = studentid;
        }

        private void returnPaymentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                rc.getStudentPayments(student_id);
                returnpaymentviewGrid.DataSource = rc.QueryExe();
                returnFirstnameTxtBox.Text = rc.QueryExe().Rows[0]["firstname"].ToString();
                returnLastnameTxtBox.Text = rc.QueryExe().Rows[0]["lastname"].ToString();
                returnMicomboBox.Text = rc.QueryExe().Rows[0]["mi"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            returnpaymentviewGrid.AllowUserToAddRows = false;
            returnpaymentviewGrid.Columns["firstname"].Visible = false;
            returnpaymentviewGrid.Columns["lastname"].Visible = false;
            returnpaymentviewGrid.Columns["mi"].Visible = false;
            returnpaymentviewGrid.Columns["studentId"].Visible = false;
            returnpaymentviewGrid.Columns["userId"].Visible = false;
            returnpaymentviewGrid.Columns["p_academic_yearId"].Visible = false;
            returnpaymentviewGrid.Columns["payment_id"].Visible = false;

            returnpaymentviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            returnpaymentviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            returnpaymentviewGrid.AutoResizeColumns();
            returnpaymentviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CurrentCashTxtBox.Text = String.Empty;
            updatedcashTxtBox.Text = String.Empty;
            memorichTextBox.Text = String.Empty;
            this.Hide();
        }

        private void returnpaymentviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    saveReturnBtn.Enabled = true;
                    DataGridViewRow row = this.returnpaymentviewGrid.Rows[e.RowIndex];

                    returnFirstnameTxtBox.Text = row.Cells["firstname"].Value.ToString();
                    returnLastnameTxtBox.Text = row.Cells["lastname"].Value.ToString();
                    returnMicomboBox.Text = row.Cells["mi"].Value.ToString();
                    CurrentCashTxtBox.Text = row.Cells["cash"].Value.ToString();
                    ornum = row.Cells["reciept_number"].Value.ToString();
                    balance = row.Cells["balance"].Value.ToString();
                    total = row.Cells["total"].Value.ToString();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void searchOrNumBtn_Click(object sender, EventArgs e)
        {
            if (ornumSearchTxtBox.Text != null)
            {
                try
                {
                    rc.getOrNumDetails(ornumSearchTxtBox.Text, student_id);

                    returnpaymentviewGrid.DataSource = rc.QueryExe();
                    rc.NonQueryExe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveReturnBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(updatedcashTxtBox.Text) && !string.IsNullOrEmpty(memorichTextBox.Text)) { 

                string today = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                DateTime newDate = DateTime.Parse(today);
                int newBalance = Convert.ToInt32(total) - Convert.ToInt32(updatedcashTxtBox.Text);


                rc.updatepaymentCashBalance(
                                                ornum,
                                                CurrentCashTxtBox.Text,
                                                balance,
                                                updatedcashTxtBox.Text,
                                                newBalance.ToString(),
                                                memorichTextBox.Text,
                                                newDate,
                                                student_id,
                                                UserClass.userid
                                             );

                rc.getStudentPayments(student_id);
                returnpaymentviewGrid.DataSource = rc.QueryExe();
                CurrentCashTxtBox.Text = String.Empty;
                updatedcashTxtBox.Text = String.Empty;
                memorichTextBox.Text = String.Empty;
                MessageBox.Show("Payment Updated!");
            }
            else
            {
                MessageBox.Show("Please Complete Trancsactions");
            }
        }
    }
}
