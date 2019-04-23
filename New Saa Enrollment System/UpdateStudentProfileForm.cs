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
    public partial class UpdateStudentProfileForm : Form
    {
       // public delegate void sendTextCallBack();
       // public sendTextCallBack sendTextValue;
        private string gridname;
        private StudentInformation studentinfo;
        private OldRegistrationClass oc;
        private OldstudentRegistration or;
        private StudentRegistration sr;
        private bool hideRequirementsTab;

        public UpdateStudentProfileForm(StudentInformation sobj, bool hideTab, OldstudentRegistration oldRegistrationClass, string gridName)
        {
            InitializeComponent();
            oc = new OldRegistrationClass();
            sr = new StudentRegistration();
            studentinfo = sobj;
            hideRequirementsTab = hideTab;
            or = oldRegistrationClass;
            this.gridname = gridName;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStudentProfileForm_Load(object sender, EventArgs e)
        {
            checkSectionIsNull(studentinfo.sectionId);
            displayYearLevel();
            displaySections();
            setRadioBtnStatus(studentinfo.student_status);

            updatestudentnotextBox.Text = studentinfo.student_num;
            updateLastnametextBox.Text = studentinfo.lname;
            updateFirstnametextBox.Text = studentinfo.fname;
            updatestudentBdate.Text = studentinfo.bdate;
            updateagetextBox.Text = studentinfo.age;
            updatecitizenshiptextBox.Text = studentinfo.citizen;
            updatecontacttextBox.Text = studentinfo.studContact;
            updatemiddlenametextBox.Text = studentinfo.mi;
            updateGenderComboBox.Text = studentinfo.gender;
            updateAddressTextBox.Text = studentinfo.studAddress;
            updatestudentBdate.Text = studentinfo.bdate;
            updatereligiontextBox.SelectedIndex = updatereligiontextBox.FindStringExact(studentinfo.rel);
            updategenAverageTextbox.Text = studentinfo.generalAverage;
            updateschoolyearcomboBox.Items.Add(studentinfo.academicyear);
            updategradeLevelComboBox.SelectedIndex = updategradeLevelComboBox.FindStringExact(studentinfo.yearlevel);
            sectionComboBox.SelectedIndex = sectionComboBox.FindStringExact(studentinfo.sectionName);

            if (studentinfo.goodmoralCertificate == "yes") { 
                updategoodMoralcheckBox.Checked = true;
            }
            if (studentinfo.nsoCertificate == "yes")
            {
                updatensocheckBox.Checked = true;
            }
            if (studentinfo.reportcard == "yes")
            {
                updatereportCardcheckBox.Checked = true;
            }
            if (studentinfo.baptismalCertificate == "yes")
            {
                updateBaptismalcheckBox.Checked = true;
            }
            if (studentinfo.clearanceCertificate == "yes")
            {
                updateclearancecheckBox.Checked = true;
            }

            updatefatherNameTextbox.Text = studentinfo.father_name;
            updatefatherOccupationTextbox.Text = studentinfo.fatherOccupation;
            updatefatherContactTextbox.Text = studentinfo.fatherContact;
            updatefatherEducationComboBox.Text = studentinfo.fatherEducation;
            updatefatherBdate.Text = studentinfo.fatherDOB;
            updatefatherAgeTxtBox.Text = studentinfo.father_age;

            updatemotherNameTextbox.Text = studentinfo.motherName;
            updatemotherOccupationTextbox.Text = studentinfo.motherOccupation;
            updatemotherContactTextbox.Text = studentinfo.motherCOntact;
            updatemotherEducationComboBox.Text = studentinfo.motherEducation;
            updatemotherBdate.Text = studentinfo.motherDOB;
            updatemotherAgeTxtbox.Text = studentinfo.mother_age;

            updateguardianNameTextbox.Text = studentinfo.guardianName;
            updateguardianRelationship.Text = studentinfo.guardianRelationship;
            updateguardianContactTxtBox.Text = studentinfo.guardianContact;
            updateguadianAddress.Text = studentinfo.guardianAddress;

            if(hideRequirementsTab == true) { 
                tabControl1.TabPages.Remove(requirementsTab);
            }

            updateschoolyearcomboBox.SelectedIndex = 1;
        }

        private void updateStudBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedStudentDetails = new Dictionary<string, string>();
            updatedStudentDetails.Add("student_id", studentinfo.student_id);
            updatedStudentDetails.Add("lastname", updateLastnametextBox.Text);
            updatedStudentDetails.Add("firstname", updateFirstnametextBox.Text);
            updatedStudentDetails.Add("mi", updatemiddlenametextBox.Text);
            updatedStudentDetails.Add("contact", updatecontacttextBox.Text);
            updatedStudentDetails.Add("gender", updateGenderComboBox.Text);
            updatedStudentDetails.Add("address", updateAddressTextBox.Text);
            updatedStudentDetails.Add("birthdate", updatestudentBdate.Text);
            updatedStudentDetails.Add("age", updateagetextBox.Text);
            updatedStudentDetails.Add("religion", updatereligiontextBox.SelectedItem.ToString());
            updatedStudentDetails.Add("citizenship", updatecitizenshiptextBox.Text);
            updatedStudentDetails.Add("final_average", updategenAverageTextbox.Text);
            updatedStudentDetails.Add("sectionId", checkSectionId(studentinfo.sectionId));

           

            oc.updateStudentInfo(updatedStudentDetails);

            switch (gridname)
            {
                case "registerOld":
                    or.displayNotEnrolledstudentsToGrid();
                    break;
                case "registered":
                    or.displayRegisteredStudentsToGrid();
                    break;
                case "enrolled":
                    or.displayEnrolledstudentsToGrid();
                    break;
                case "graduate":
                    or.displayGraduateStudentsToGrid();
                    break;
                case "dropped":
                    or.displayDroppedStudentsToGrid();
                    break;
            }
             //   this.sendTextValue += new sendTextCallBack(or.displayNotEnrolledstudentsToGrid);
             // sendTextValue();
        }

        private void updatestudentBdate_ValueChanged(object sender, EventArgs e)
        {
            sr.calculateAge(updatestudentBdate, updateagetextBox);
        }

        private void updategoodMoralcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updategoodMoralcheckBox, updategoodMoralcheckBox.Name);
        }

        private void updateBaptismalcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updateBaptismalcheckBox, updateBaptismalcheckBox.Name);
        }

        private void updateclearancecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updateclearancecheckBox, updateclearancecheckBox.Name);
        }

        private void updatereportCardcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updatereportCardcheckBox, updatereportCardcheckBox.Name);
        }

        private void updatensocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updatensocheckBox, updatensocheckBox.Name);
        }

        private void updateRequirementsBtn_Click(object sender, EventArgs e)
        {
            oc.updateStudentRequirements(studentinfo.student_id);
            or.displayRegisteredStudentsToGrid();
            or.displayNotEnrolledstudentsToGrid();
            or.displayEnrolledstudentsToGrid();
        }

        private void enableUpdateBtn_Click(object sender, EventArgs e)
        {
            if (enableStudentInfoBtn.Text == "ENABLE")
            {
                enableStudentInfoBtn.Text = "DISABLE";
                EnableDisableStudInfo(true);
            }
            else if(enableStudentInfoBtn.Text == "DISABLE")
            {
                enableStudentInfoBtn.Text = "ENABLE";
                EnableDisableStudInfo(false);
            }
        }

        private void enableFamilyInfoBtn_Click(object sender, EventArgs e)
        {
            if (enableFamilyInfoBtn.Text == "ENABLE")
            {
                enableFamilyInfoBtn.Text = "DISABLE";
                EnableDisableFaminfo(true);
            }
            else if(enableFamilyInfoBtn.Text == "DISABLE")
            {
                enableFamilyInfoBtn.Text = "ENABLE";
                EnableDisableFaminfo(false);
            }
        }

        private void EnableDisableStudInfo(bool value)
        {
            updateAddressTextBox.Enabled = value;
            updateagetextBox.Enabled = value;
            updatecitizenshiptextBox.Enabled = value;
            updatecontacttextBox.Enabled = value;
            updatereligiontextBox.Enabled = value;
            updateFirstnametextBox.Enabled = value;
            updateLastnametextBox.Enabled = value;
            updategenAverageTextbox.Enabled = value;
            updatemiddlenametextBox.Enabled = value;
            updateGenderComboBox.Enabled = value;
            updatestudentBdate.Enabled = value;
            sectionComboBox.Enabled = value;
        }

        private void EnableDisableFaminfo(bool value)
        {
            updatefatherNameTextbox.Enabled = value;
            updatefatherOccupationTextbox.Enabled = value;
            updatefatherContactTextbox.Enabled = value;
            updatefatherEducationComboBox.Enabled = value;
            updatefatherBdate.Enabled = value;
            updatefatherAgeTxtBox.Enabled = value;

            updatemotherNameTextbox.Enabled = value;
            updatemotherOccupationTextbox.Enabled = value;
            updatemotherContactTextbox.Enabled = value;
            updatemotherEducationComboBox.Enabled = value;
            updatemotherBdate.Enabled = value;
            updatemotherAgeTxtbox.Enabled = value;

            updateguardianNameTextbox.Enabled = value;
            updateguardianRelationship.Enabled = value;
            updateguardianContactTxtBox.Enabled = value;
            updateguadianAddress.Enabled = value;
        }

        private void updatefatherBdate_ValueChanged(object sender, EventArgs e)
        {
            sr.calculateAge(updatefatherBdate, updatefatherAgeTxtBox);
        }

        private void updatemotherBdate_ValueChanged(object sender, EventArgs e)
        {
            sr.calculateAge(updatemotherBdate, updatemotherAgeTxtbox);
        }

        private void updateStatusDroppedBtn_Click(object sender, EventArgs e)
        {
            new StudentStatusForm(studentinfo.student_id, studentinfo.student_status, studentStatusRadioButton, or).ShowDialog();
        }

        private void setRadioBtnStatus(string status)
        {
            switch (status)
            {
                case "pending":
                    studentStatusRadioButton.Text = "Pending";
                    studentStatusRadioButton.ForeColor = Color.Pink;
                    studentStatusRadioButton.Checked = true;
                    updateStatusDroppedBtn.Hide();
                    break;
                case "registered":
                    studentStatusRadioButton.Text = "Registered";
                    studentStatusRadioButton.ForeColor = Color.LimeGreen;
                    studentStatusRadioButton.Checked = true;
                    updateStatusDroppedBtn.Hide();
                    break;
                case "enrolled":
                    studentStatusRadioButton.Text = "Enrolled";
                    studentStatusRadioButton.ForeColor = Color.DeepSkyBlue;
                    studentStatusRadioButton.Checked = true;
                    updateStatusDroppedBtn.Text = "Dropped Student";
                    updateStatusDroppedBtn.Show();
                    break;
                case "graduate":
                    studentStatusRadioButton.Text = "Graduate";
                    studentStatusRadioButton.ForeColor = Color.Gold;
                    studentStatusRadioButton.Checked = true;
                    updateStatusDroppedBtn.Hide();
                    break;
                case "dropped":
                    studentStatusRadioButton.Text = "Dropped";
                    studentStatusRadioButton.ForeColor = Color.Orange;
                    studentStatusRadioButton.Checked = true;
                    updateStatusDroppedBtn.Text = "UnDropped Student";
                    updateStatusDroppedBtn.Show();
                    break;
            }
        }

        private void updateFamilyInfoBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> familyInfo = new Dictionary<string, string>();
            familyInfo.Add("fi_studentId", studentinfo.student_id);
            familyInfo.Add("father_name", updatefatherNameTextbox.Text);
            familyInfo.Add("fatherDOB", updatefatherBdate.Text);
            familyInfo.Add("father_age", updatefatherAgeTxtBox.Text);
            familyInfo.Add("father_education", updatefatherEducationComboBox.Text);
            familyInfo.Add("father_occupation", updatefatherOccupationTextbox.Text);
            familyInfo.Add("father_contact", updatefatherContactTextbox.Text);
            familyInfo.Add("mother_name", updatemotherNameTextbox.Text);
            familyInfo.Add("motherDOB", updatemotherBdate.Text);
            familyInfo.Add("mother_age", updatemotherAgeTxtbox.Text);
            familyInfo.Add("mother_education", updatemotherEducationComboBox.Text);
            familyInfo.Add("mother_occupation", updatemotherOccupationTextbox.Text);
            familyInfo.Add("mother_contact", updatemotherContactTextbox.Text);
            familyInfo.Add("guardian_name", updateguardianNameTextbox.Text);
            familyInfo.Add("relationship", updateguardianRelationship.Text);
            familyInfo.Add("guardian_address", updateguadianAddress.Text);
            familyInfo.Add("guardian_contact", updateguardianContactTxtBox.Text);

            oc.updateFamilyInfo(familyInfo);

            switch (gridname)
            {
                case "registerOld":
                    or.displayNotEnrolledstudentsToGrid();
                    break;
                case "registered":
                    or.displayRegisteredStudentsToGrid();
                    break;
                case "enrolled":
                    or.displayEnrolledstudentsToGrid();
                    break;
                case "graduate":
                    or.displayGraduateStudentsToGrid();
                    break;
                case "dropped":
                    or.displayDroppedStudentsToGrid();
                    break;
            }
        }

        private void updatefatherNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updatemotherNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updatefatherOccupationTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updatemotherOccupationTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updateguardianNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updateguadianAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updatefatherContactTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private void updatemotherContactTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private void updateguardianContactTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private void updateLastnametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updateFirstnametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updatecitizenshiptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updateAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputTextOnly(e);
        }

        private void updategenAverageTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private void updatecontacttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sr.makeInputNumberOnly(e);
        }

        private void displayYearLevel()
        {
            try
            {
                oc.getYearLevel();
                updategradeLevelComboBox.ValueMember = "year_level_id";
                updategradeLevelComboBox.DisplayMember = "year_name";
                updategradeLevelComboBox.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displaySections()
        {
            try
            {
                oc.getSections(studentinfo.yearlevelId);
                sectionComboBox.ValueMember = "section_id";
                sectionComboBox.DisplayMember = "section_name";
                sectionComboBox.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkSectionIsNull(string sectionId)
        {
            if (string.IsNullOrEmpty(sectionId))
            {
                sectionComboBox.Hide();
                sectionLabel.Hide();
                sectionId = null;
            }
        }

        private string checkSectionId(string sectionId)
        {
            string section = null;
            if (string.IsNullOrEmpty(sectionId))
            {
                sectionId = null;
            }
            else
            {
                section = sectionComboBox.SelectedValue.ToString();
            }

            return section;
        }
    }
}
