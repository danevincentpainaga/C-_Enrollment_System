using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{

    public partial class StudentRegistration : UserControl
    {
        private string _goodMoral, _baptismal, clearance, nso, reportCard;
        private StudentRegistrationClass sc;

        public StudentRegistration()
        {
            InitializeComponent();
            sc = new StudentRegistrationClass();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            displayYearLevel();
            displayCurrentStudentId();
            gradeLevelComboBox.Enabled = false;
            schoolyearcomboBox.Enabled = false;
        }

        private void clearancecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sc.validateCheckBox(clearancecheckBox, clearancecheckBox.Name);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(validateEmptyOrNull().Count > 0)
            {
                MessageBox.Show("Please Complete the Forms");
            }
            else
            {
                try
                {
                    string studno = studentnotextBox.Text;
                    string saaCharCode = studno.Substring(0, studno.IndexOf("-"));
                    int startIndex = studno.IndexOf("-");
                    string new_student_no = studno.Substring(startIndex + 1);
                    int newStudId = Convert.ToInt32(new_student_no) + 1;

                    StudentInformation si = new StudentInformation()
                    {
                        student_num = saaCharCode + "-" + newStudId.ToString(),
                        academicyear = schoolyearcomboBox.SelectedValue.ToString(),
                        yearlevel = gradeLevelComboBox.SelectedValue.ToString(),
                        fname = firstnametextBox.Text,
                        lname = lastnametextBox.Text,
                        mi = middlenameComboBox.Text,
                        bdate = studentBdate.Text,
                        age = agetextBox.Text,
                        studContact = contacttextBox.Text,
                        gender = regGenderComboBox.Text,
                        studAddress = addresstextBox.Text,
                        rel = religiontextBox.Text,
                        citizen = citizenshiptextBox.Text,
                        generalAverage = genAverageTextbox.Text,
                        father_name = fatherContactTextbox.Text,
                        fatherDOB = fdateTime.Text,
                        father_age = fatherAgeTxtBox.Text,
                        fatherOccupation = fatherOccupationTextbox.Text,
                        fatherContact = fatherContactTextbox.Text,
                        fatherEducation = fatherEducationComboBox.Text,
                        motherName = motherNameTextbox.Text,
                        motherDOB = mdateTime.Text,
                        mother_age = motherAgeTxtbox.Text,
                        motherOccupation = motherOccupationTextbox.Text,
                        motherCOntact = motherContactTextbox.Text,
                        motherEducation = motherEducationCombobox.Text,
                        guardianName = guardianNameTextbox.Text,
                        guardianRelationship = guardianRelationshipComboBox.Text,
                        guardianContact = guardianContactTxtBox.Text,
                        guardianAddress = guardianAddressTextbox.Text
                    };

                    sc.registerStudentInfo(si);
                    displayCurrentStudentId();

                    clearancecheckBox.Checked = false;
                    goodMoralcheckBox.Checked = false;
                    reportCardcheckBox.Checked = false;
                    BaptismalcheckBox.Checked = false;
                    nsocheckBox.Checked = false;
                    firstnametextBox.Clear();
                    lastnametextBox.Clear();
                    agetextBox.Clear();
                    contacttextBox.Clear();
                    regGenderComboBox.SelectedIndex = -1;
                    middlenameComboBox.SelectedIndex = -1;
                    religiontextBox.SelectedIndex = -1;
                    citizenshiptextBox.Clear();
                    genAverageTextbox.Clear();
                    fatherNameTextbox.Clear();
                    fatherContactTextbox.Clear();
                    fatherAgeTxtBox.Clear();
                    fatherOccupationTextbox.Clear();
                    fatherContactTextbox.Clear();
                    fatherEducationComboBox.SelectedIndex = -1;
                    motherNameTextbox.Clear();
                    motherAgeTxtbox.Clear();
                    motherOccupationTextbox.Clear();
                    motherContactTextbox.Clear();
                    motherEducationCombobox.SelectedIndex = -1;
                    guardianNameTextbox.Clear();
                    guardianRelationshipComboBox.SelectedIndex = -1;
                    guardianContactTxtBox.Clear();
                    guardianAddressTextbox.Clear();
                    addresstextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void studentBdate_ValueChanged(object sender, EventArgs e)
        {
            calculateAge(studentBdate, agetextBox);
        }

        private void goodMoralcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sc.validateCheckBox(goodMoralcheckBox, goodMoralcheckBox.Name);
        }

        private void fdateTime_ValueChanged(object sender, EventArgs e)
        {
            calculateAge(fdateTime, fatherAgeTxtBox);
        }

        private void mdateTime_ValueChanged(object sender, EventArgs e)
        {
            calculateAge(mdateTime, motherAgeTxtbox);
        }

        private void BaptismalcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sc.validateCheckBox(BaptismalcheckBox, BaptismalcheckBox.Name);
        }

        private void lastnametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void reportCardcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sc.validateCheckBox(reportCardcheckBox, reportCardcheckBox.Name);
        }

        private void firstnametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void contacttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputNumberOnly(e);
        }

        private void nsocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sc.validateCheckBox(nsocheckBox, nsocheckBox.Name);
        }

        private void addresstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void citizenshiptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void genAverageTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputNumberOnly(e);
        }

        private void fatherNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void fatherOccupationTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void motherOccupationTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void motherContactTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputNumberOnly(e);
        }

        private void guardianNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void guardianContactTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputNumberOnly(e);
        }

        private void guardianAddressTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        public void calculateAge(DateTimePicker bdate, TextBox txtAge)
        {
            DateTime from = bdate.Value;
            DateTime to = DateTime.Now;
            TimeSpan tspan = to - from;
            double days = tspan.TotalDays;
            txtAge.Text = (days / 365).ToString("0");
        }

        private void fatherContactTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputNumberOnly(e);
        }

        private void motherNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            makeInputTextOnly(e);
        }

        private void displayCurrentStudentId()
        {
            sc.getCurrentIdAndScholYear();
            try
            {
                foreach (DataRow dr in sc.QueryExe().Rows)
                {
                    studentnotextBox.Text = dr["current_school_id"].ToString();
                    schoolyearcomboBox.ValueMember = "academic_id";
                    schoolyearcomboBox.DisplayMember = "academic_year";
                    schoolyearcomboBox.DataSource = sc.QueryExe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            firstnametextBox.Clear();
            lastnametextBox.Clear();
            middlenameComboBox.SelectedIndex = -1;
            agetextBox.Clear();
            contacttextBox.Clear();
            regGenderComboBox.SelectedIndex = -1;
            addresstextBox.Clear();
            religiontextBox.SelectedIndex = -1;
            citizenshiptextBox.Clear();
            genAverageTextbox.Clear();
            fatherNameTextbox.Clear();
            fatherContactTextbox.Clear();
            fatherAgeTxtBox.Clear();
            fatherOccupationTextbox.Clear();
            fatherContactTextbox.Clear();
            fatherEducationComboBox.SelectedIndex = -1;
            motherNameTextbox.Clear();
            motherAgeTxtbox.Clear();
            motherOccupationTextbox.Clear();
            motherContactTextbox.Clear();
            motherEducationCombobox.SelectedIndex = -1;
            guardianNameTextbox.Clear();
            guardianRelationshipComboBox.SelectedIndex = -1;
            guardianContactTxtBox.Clear();
            guardianAddressTextbox.Clear();
            clearancecheckBox.Checked = false;
            BaptismalcheckBox.Checked = false;
            reportCardcheckBox.Checked = false;
            goodMoralcheckBox.Checked = false;
            nsocheckBox.Checked = false;
        }

        public void displayYearLevel()
        {
            sc.getYearLevel();
            try
            {
                gradeLevelComboBox.ValueMember = "year_level_id";
                gradeLevelComboBox.DisplayMember = "year_name";
                gradeLevelComboBox.DataSource = sc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void makeInputTextOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 32 && e.KeyChar == (char)Keys.Oemcomma)
            {
                e.Handled = true;
            }
        }

        public void makeInputNumberOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private ArrayList validateEmptyOrNull()
        {
            ArrayList errors = new ArrayList();
            string[] textBoxes = {
                    firstnametextBox.Text,
                    lastnametextBox.Text,
                    middlenameComboBox.Text,
                    studentBdate.Text,
                    agetextBox.Text,
                    contacttextBox.Text,
                    regGenderComboBox.Text,
                    addresstextBox.Text,
                    religiontextBox.Text,
                    citizenshiptextBox.Text,
                    genAverageTextbox.Text,
                    fatherContactTextbox.Text,
                    fdateTime.Text,
                    fatherAgeTxtBox.Text,
                    fatherOccupationTextbox.Text,
                    fatherContactTextbox.Text,
                    fatherEducationComboBox.Text,
                    motherNameTextbox.Text,
                    mdateTime.Text,
                    motherAgeTxtbox.Text,
                    motherOccupationTextbox.Text,
                    motherContactTextbox.Text,
                    motherEducationCombobox.Text,
                    guardianNameTextbox.Text,
                    guardianRelationshipComboBox.Text,
                    guardianContactTxtBox.Text,
                    guardianAddressTextbox.Text
            };

            foreach (string item in textBoxes)
            {
                if (string.IsNullOrEmpty(item))
                {
                    errors.Add(item);
                }
            }

            return errors;
        }
    }
}
