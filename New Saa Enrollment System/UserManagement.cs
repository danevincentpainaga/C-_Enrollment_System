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

namespace New_Saa_Enrollment_System
{
    public partial class UserManagement : UserControl
    {

        private UserClass con;
        private string userId;
        public UserManagement()
        {
            InitializeComponent();
            con = new UserClass();
        }
        

        private void UserManagement_Load(object sender, EventArgs e)
        {
            userstatuscomboBox.Items.Add("");
            userstatuscomboBox.Items.Add("Activated");
            userstatuscomboBox.Items.Add("Deactivated");

            displayUserToGrid();
            displayUserTypes();

            userviewGrid.AutoResizeColumns();
            userviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            userviewGrid.AllowUserToAddRows = false;
            userviewGrid.Columns[0].Visible = false;
            userviewGrid.Columns["user_type_id"].Visible = false;
            userviewGrid.Columns["user_typeId"].Visible = false;
            lastnameTxtbox.Enabled = false;
            firstnameTxtbox.Enabled = false;
            miTxtbox.Enabled = false;
            gendercomboBox.Enabled = false;
            ageTxtbox.Enabled = false;
            addressTxtbox.Enabled = false;
            usernameTxtbox.Enabled = false;
            passwordTxtbox.Enabled = false;
            retypepasswordTxtbox.Enabled = false;
            passwordcheckBox.Enabled = false;
            positionTxtbox.Enabled = false;
            usertypecmbx.Enabled = false;
            userstatuscomboBox.Enabled = false;
            birthdateTimePicker1.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            editBtn.Enabled = false;
            usertypecmbx.SelectedIndex = -1;
            userviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            userviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void usertypecmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView oDataRowView = usertypecmbx.SelectedItem as DataRowView;
            string sValue = string.Empty;

            if (oDataRowView != null)
            {
                sValue = oDataRowView.Row["user_type"] as string;
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            lastnameTxtbox.Clear();
            firstnameTxtbox.Clear();
            ageTxtbox.Clear();
            addressTxtbox.Clear();
            positionTxtbox.Clear();
            usernameTxtbox.Clear();
            passwordTxtbox.Clear();
            userviewGrid.Enabled = false;
            userviewGrid.DefaultCellStyle.BackColor = SystemColors.Control;
            userviewGrid.DefaultCellStyle.ForeColor = SystemColors.GrayText;
            userviewGrid.BackgroundColor = SystemColors.Control;
            userviewGrid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            userviewGrid.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
            userviewGrid.CurrentCell = null;

            lastnameTxtbox.Enabled = true;
            firstnameTxtbox.Enabled = true;
            miTxtbox.Enabled = true;
            gendercomboBox.Enabled = true;
            ageTxtbox.Enabled = true;
            addressTxtbox.Enabled = true;
            usernameTxtbox.Enabled = true;
            passwordTxtbox.Enabled = true;
            retypepasswordTxtbox.Enabled = true;
            passwordcheckBox.Enabled = true;
            positionTxtbox.Enabled = true;
            usertypecmbx.Enabled = true;
            userstatuscomboBox.Enabled = true;
            birthdateTimePicker1.Enabled = true;
            saveBtn.Enabled = true;
            updateBtn.Enabled = false;
            cancelBtn.Enabled = true;
            newBtn.Enabled = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            updateBtn.SendToBack();
            updateBtn.Enabled = false;
            editBtn.Enabled = false;
            lastnameTxtbox.Clear();
            firstnameTxtbox.Clear();
            ageTxtbox.Clear();
            addressTxtbox.Clear();
            positionTxtbox.Clear();
            usernameTxtbox.Clear();
            passwordTxtbox.Clear();
            retypepasswordTxtbox.Clear();
            userstatuscomboBox.SelectedIndex = -1;
            usertypecmbx.SelectedIndex = -1;
            gendercomboBox.SelectedIndex = -1;
            miTxtbox.SelectedIndex = -1;

            lastnameTxtbox.Enabled = false;
            firstnameTxtbox.Enabled = false;
            miTxtbox.Enabled = false;
            gendercomboBox.Enabled = false;
            ageTxtbox.Enabled = false;
            addressTxtbox.Enabled = false;
            usernameTxtbox.Enabled = false;
            passwordTxtbox.Enabled = false;
            retypepasswordTxtbox.Enabled = false;
            passwordcheckBox.Enabled = false;
            positionTxtbox.Enabled = false;
            usertypecmbx.Enabled = false;
            userstatuscomboBox.Enabled = false;
            birthdateTimePicker1.Enabled = false;
            saveBtn.Enabled = false;
            updateBtn.Enabled = false;
            newBtn.Enabled = true;

            userviewGrid.DefaultCellStyle.ForeColor = Color.Black;
            userviewGrid.BackgroundColor = Color.White;
            userviewGrid.DefaultCellStyle.BackColor = Color.White;
            userviewGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            userviewGrid.Enabled = true;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            con.displayUsers(textBoxSearch.Text);
            try
            {
                userviewGrid.DataSource = con.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void birthdateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = birthdateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tspan = to - from;
            double days = tspan.TotalDays;
            ageTxtbox.Text = (days / 365).ToString("0");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if(retypepasswordTxtbox.Text == passwordTxtbox.Text) { 
                try {
                    // UserClass uc = new UserClass();
                     
                     con.insertUser(
                                    lastnameTxtbox.Text,
                                    firstnameTxtbox.Text,
                                    miTxtbox.Text,
                                    gendercomboBox.SelectedItem.ToString(),
                                    birthdateTimePicker1.Text,
                                    ageTxtbox.Text,
                                    addressTxtbox.Text,
                                    positionTxtbox.Text,
                                    usernameTxtbox.Text,
                                    passwordTxtbox.Text,
                                    usertypecmbx.SelectedValue,
                                    userstatuscomboBox.SelectedItem.ToString()
                                  );

                    MessageBox.Show("User Inserted!");
                    con.displayUsers();
                    userviewGrid.DataSource = con.QueryExe();
                    displayUserToGrid();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Not Matched!");
            }
            updateBtn.SendToBack();
            updateBtn.Enabled = false;
            editBtn.Enabled = false;
            lastnameTxtbox.Clear();
            firstnameTxtbox.Clear();
            ageTxtbox.Clear();
            addressTxtbox.Clear();
            positionTxtbox.Clear();
            usernameTxtbox.Clear();
            passwordTxtbox.Clear();
            retypepasswordTxtbox.Clear();
            userstatuscomboBox.SelectedIndex = -1;
            usertypecmbx.SelectedIndex = -1;
            gendercomboBox.SelectedIndex = -1;
            miTxtbox.SelectedIndex = -1;

            lastnameTxtbox.Enabled = false;
            firstnameTxtbox.Enabled = false;
            miTxtbox.Enabled = false;
            gendercomboBox.Enabled = false;
            ageTxtbox.Enabled = false;
            addressTxtbox.Enabled = false;
            usernameTxtbox.Enabled = false;
            passwordTxtbox.Enabled = false;
            retypepasswordTxtbox.Enabled = false;
            passwordcheckBox.Enabled = false;
            positionTxtbox.Enabled = false;
            usertypecmbx.Enabled = false;
            userstatuscomboBox.Enabled = false;
            birthdateTimePicker1.Enabled = false;
            saveBtn.Enabled = false;
            updateBtn.Enabled = false;
            newBtn.Enabled = true;
        }


        private void userviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editBtn.Enabled = true;
                gendercomboBox.SelectedIndex = 1;
                userstatuscomboBox.SelectedIndex = 1;
                DataGridViewRow row = this.userviewGrid.Rows[e.RowIndex];

                lastnameTxtbox.Text = row.Cells["lastname"].Value.ToString();
                firstnameTxtbox.Text = row.Cells["firstname"].Value.ToString();
                miTxtbox.Text = row.Cells["mi"].Value.ToString();
                gendercomboBox.SelectedValue = gendercomboBox.Items.IndexOf(row.Cells["gender"].Value.ToString());
                birthdateTimePicker1.Text = row.Cells["birthdate"].Value.ToString();
                ageTxtbox.Text = row.Cells["age"].Value.ToString();
                addressTxtbox.Text = row.Cells["address"].Value.ToString();
                positionTxtbox.Text = row.Cells["position"].Value.ToString();
                usernameTxtbox.Text = row.Cells["username"].Value.ToString();
                passwordTxtbox.Text = row.Cells["password"].Value.ToString();
                positionTxtbox.Text = row.Cells["position"].Value.ToString();
                usertypecmbx.SelectedIndex = usertypecmbx.FindStringExact(row.Cells["user_type"].Value.ToString());
                userstatuscomboBox.Text = row.Cells["user_status"].Value.ToString();
                userId = row.Cells["user_id"].Value.ToString();

                newBtn.Enabled = false;
                updateBtn.Enabled = true;
                cancelBtn.Enabled = true;

            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (retypepasswordTxtbox.Text == passwordTxtbox.Text)
            {
                try
                {

                    con.updateUser(
                                        lastnameTxtbox.Text,
                                        firstnameTxtbox.Text,
                                        miTxtbox.Text,
                                        gendercomboBox.SelectedItem.ToString(),
                                        birthdateTimePicker1.Text,
                                        ageTxtbox.Text,
                                        addressTxtbox.Text,
                                        positionTxtbox.Text,
                                        usernameTxtbox.Text,
                                        passwordTxtbox.Text,
                                        usertypecmbx.SelectedValue,
                                        userstatuscomboBox.SelectedItem.ToString(),
                                        userId
                                       
                                   );

                    displayUserToGrid();
                    userviewGrid.Enabled = true;
                    updateBtn.Enabled=false;
                    updateBtn.SendToBack();
                    lastnameTxtbox.Enabled = false;
                    firstnameTxtbox.Enabled = false;
                    miTxtbox.Enabled = false;
                    gendercomboBox.Enabled = false;
                    ageTxtbox.Enabled = false;
                    addressTxtbox.Enabled = false;
                    usernameTxtbox.Enabled = false;
                    passwordTxtbox.Enabled = false;
                    retypepasswordTxtbox.Enabled = false;
                    passwordcheckBox.Enabled = false;
                    positionTxtbox.Enabled = false;
                    usertypecmbx.Enabled = false;
                    userstatuscomboBox.Enabled = false;
                    birthdateTimePicker1.Enabled = false;
                    saveBtn.Enabled = false;
                    cancelBtn.Enabled = true;
                    editBtn.Enabled = false;
                    newBtn.Enabled=true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Not Matched!");
            }
        }

        private void userviewGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.userviewGrid.Columns[e.ColumnIndex].Name == "user_status")
            {
                if (e.Value != null)
                {
                    string stringValue = (string)e.Value;
                    if ((stringValue.IndexOf("Activated") > -1))
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    if ((stringValue.IndexOf("Deactivated") > -1))
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            editBtn.Enabled = false;
            updateBtn.Enabled = true;
            updateBtn.BringToFront();
            lastnameTxtbox.Enabled = true;
            firstnameTxtbox.Enabled = true;
            miTxtbox.Enabled = true;
            gendercomboBox.Enabled = true;
            ageTxtbox.Enabled = true;
            addressTxtbox.Enabled = true;
            usernameTxtbox.Enabled = true;
            passwordTxtbox.Enabled = true;
            retypepasswordTxtbox.Enabled = true;
            passwordcheckBox.Enabled = true;
            positionTxtbox.Enabled = true;
            usertypecmbx.Enabled = true;
            userstatuscomboBox.Enabled = true;
            birthdateTimePicker1.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            newBtn.Enabled = false;
            userviewGrid.Enabled = false;
        }

        private void displayUserToGrid()
        {
            con.displayUsers();
            try
            {
                userviewGrid.DataSource = con.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void passwordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtbox.UseSystemPasswordChar = (passwordcheckBox.Checked) ? true : false;
            retypepasswordTxtbox.UseSystemPasswordChar = (passwordcheckBox.Checked) ? true : false;
        }

        private void displayUserTypes()
        {
            con.getUsertTypes();
            try
            {
                usertypecmbx.ValueMember = "user_type_id";
                usertypecmbx.DisplayMember = "user_type";
                usertypecmbx.DataSource = con.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userviewGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
