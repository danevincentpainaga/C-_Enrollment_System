using System;
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
    public partial class OldstudentRegistration : UserControl
    {
        private string studentId;
        private bool gridEnrolled = false;
        private bool gridRegister = false;
        private bool gridDropped = false;
        private bool gridGraduate = false;

        private OldRegistrationClass oc;
        private StudentInformation si;
        public OldstudentRegistration()
        {
            InitializeComponent();
            oc = new OldRegistrationClass();
            si = new StudentInformation();
        }

        private void OldstudentRegistration_Load(object sender, EventArgs e)
        {
            schoolyearCmbx.DataSource = null;
            schoolyearCmbx.DataBindings.Clear();

            displayYearlevel();
            displayCurrentShoolYear();
            displayNotEnrolledstudentsToGrid();

            gradelevelcomboBox.SelectedIndex = 1;
            customGrid(registerOldStudentsViewGrid);
            customGrid(registeredGridview);
            customGrid(enrolledGridview);
            customGrid(graduatesdataGridView);
            customGrid(droppeddataGridView);
        }

        private void oldregistrationtabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tabText = oldregistrationtabControl.SelectedIndex;
            switch (tabText)
            {
                case 0:
                    displayNotEnrolledstudentsToGrid();
                    displayCurrentShoolYear();
                    break;
                case 1:
                    displayRegisteredStudentsToGrid();
                    break;
                case 2:
                    displayEnrolledstudentsToGrid();
                    break;
                case 3:
                    displayGraduateStudentsToGrid();
                    break;
                case 4:
                    displayDroppedStudentsToGrid();
                    break;
            }
        }

        public void customGrid(DataGridView datagrid)
        {
            datagrid.AllowUserToAddRows = false;
            datagrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            datagrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            datagrid.AutoResizeColumns();
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void registeredGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // This section is for updating Student information
                try
                {
                    DataGridViewRow row = this.registeredGridview.Rows[e.RowIndex];
                    gridRegister = true;
                    registeredGridview.DefaultCellStyle.SelectionBackColor = Color.Lavender;

                    // Creates an object and pass to setStudentDetailsObj method and be fetch by getStudentDetailsObj
                    StudentInformation si = new StudentInformation()
                    {
                        student_id = row.Cells["student_id"].Value.ToString(),
                        fname = row.Cells["firstname"].Value.ToString(),
                        lname = row.Cells["lastname"].Value.ToString(),
                        student_num = row.Cells["student_no"].Value.ToString(),
                        yearlevelId = row.Cells["year_level_id"].Value.ToString(),
                        yearlevel = row.Cells["year_name"].Value.ToString(),
                        sectionId = row.Cells["sectionId"].Value.ToString(),
                        sectionName = row.Cells["section_name"].Value.ToString(),
                        academicyear = row.Cells["academic_year"].Value.ToString(),
                        mi = row.Cells["mi"].Value.ToString(),
                        bdate = row.Cells["birthdate"].Value.ToString(),
                        age = row.Cells["age"].Value.ToString(),
                        studContact = row.Cells["contact"].Value.ToString(),
                        gender = row.Cells["gender"].Value.ToString(),
                        studAddress = row.Cells["address"].Value.ToString(),
                        rel = row.Cells["religion"].Value.ToString(),
                        citizen = row.Cells["citizenship"].Value.ToString(),
                        generalAverage = row.Cells["final_average"].Value.ToString(),
                        father_name = row.Cells["father_name"].Value.ToString(),
                        fatherDOB = row.Cells["fatherDOB"].Value.ToString(),
                        father_age = row.Cells["father_age"].Value.ToString(),
                        fatherOccupation = row.Cells["father_occupation"].Value.ToString(),
                        fatherContact = row.Cells["father_contact"].Value.ToString(),
                        fatherEducation = row.Cells["father_education"].Value.ToString(),
                        motherName = row.Cells["mother_name"].Value.ToString(),
                        motherDOB = row.Cells["motherDOB"].Value.ToString(),
                        mother_age = row.Cells["mother_age"].Value.ToString(),
                        motherOccupation = row.Cells["mother_occupation"].Value.ToString(),
                        motherCOntact = row.Cells["mother_contact"].Value.ToString(),
                        motherEducation = row.Cells["mother_education"].Value.ToString(),
                        guardianName = row.Cells["guardian_name"].Value.ToString(),
                        guardianRelationship = row.Cells["relationship"].Value.ToString(),
                        guardianContact = row.Cells["guardian_contact"].Value.ToString(),
                        guardianAddress = row.Cells["guardian_address"].Value.ToString(),
                        goodmoralCertificate = row.Cells["good_moral_certificate"].Value.ToString(),
                        nsoCertificate = row.Cells["nso_birth_certificate"].Value.ToString(),
                        reportcard = row.Cells["report_card_form138"].Value.ToString(),
                        baptismalCertificate = row.Cells["baptismal_certificate"].Value.ToString(),
                        clearanceCertificate = row.Cells["clearance"].Value.ToString(),
                        student_status = row.Cells["student_status"].Value.ToString()
                    };
                    oc.setStudentDetailsObj(si);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Open the Update Form and pass StudentDetails Object to it to display all student information
            if (gridRegister == true)
            {
                UpdateStudentProfileForm us = new UpdateStudentProfileForm(oc.getStudentDetailsObj(), false, this, "registered");
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Data Selected! Select one to view details", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enrolledGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // This section is for updating Student information
                try
                {
                    DataGridViewRow row = this.enrolledGridview.Rows[e.RowIndex];
                    gridEnrolled = true;
                    enrolledGridview.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    // Creates an object and pass to setStudentDetailsObj method and be fetch by getStudentDetailsObj
                    StudentInformation si = new StudentInformation()
                    {
                        student_id = row.Cells["student_id"].Value.ToString(),
                        fname = row.Cells["firstname"].Value.ToString(),
                        lname = row.Cells["lastname"].Value.ToString(),
                        student_num = row.Cells["student_no"].Value.ToString(),
                        yearlevelId = row.Cells["year_level_id"].Value.ToString(),
                        yearlevel = row.Cells["year_name"].Value.ToString(),
                        sectionId = row.Cells["sectionId"].Value.ToString(),
                        sectionName = row.Cells["section_name"].Value.ToString(),
                        academicyear = row.Cells["academic_year"].Value.ToString(),
                        mi = row.Cells["mi"].Value.ToString(),
                        bdate = row.Cells["birthdate"].Value.ToString(),
                        age = row.Cells["age"].Value.ToString(),
                        studContact = row.Cells["contact"].Value.ToString(),
                        gender = row.Cells["gender"].Value.ToString(),
                        studAddress = row.Cells["address"].Value.ToString(),
                        rel = row.Cells["religion"].Value.ToString(),
                        citizen = row.Cells["citizenship"].Value.ToString(),
                        generalAverage = row.Cells["final_average"].Value.ToString(),
                        father_name = row.Cells["father_name"].Value.ToString(),
                        fatherDOB = row.Cells["fatherDOB"].Value.ToString(),
                        father_age = row.Cells["father_age"].Value.ToString(),
                        fatherOccupation = row.Cells["father_occupation"].Value.ToString(),
                        fatherContact = row.Cells["father_contact"].Value.ToString(),
                        fatherEducation = row.Cells["father_education"].Value.ToString(),
                        motherName = row.Cells["mother_name"].Value.ToString(),
                        motherDOB = row.Cells["motherDOB"].Value.ToString(),
                        mother_age = row.Cells["mother_age"].Value.ToString(),
                        motherOccupation = row.Cells["mother_occupation"].Value.ToString(),
                        motherCOntact = row.Cells["mother_contact"].Value.ToString(),
                        motherEducation = row.Cells["mother_education"].Value.ToString(),
                        guardianName = row.Cells["guardian_name"].Value.ToString(),
                        guardianRelationship = row.Cells["relationship"].Value.ToString(),
                        guardianContact = row.Cells["guardian_contact"].Value.ToString(),
                        guardianAddress = row.Cells["guardian_address"].Value.ToString(),
                        goodmoralCertificate = row.Cells["good_moral_certificate"].Value.ToString(),
                        nsoCertificate = row.Cells["nso_birth_certificate"].Value.ToString(),
                        reportcard = row.Cells["report_card_form138"].Value.ToString(),
                        baptismalCertificate = row.Cells["baptismal_certificate"].Value.ToString(),
                        clearanceCertificate = row.Cells["clearance"].Value.ToString(),
                        student_status = row.Cells["student_status"].Value.ToString()
                    };
                    oc.setStudentDetailsObj(si);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void updateEnrolledBtn_Click(object sender, EventArgs e)
        {
            if (gridEnrolled == true)
            {
                UpdateStudentProfileForm us = new UpdateStudentProfileForm(oc.getStudentDetailsObj(), false, this, "enrolled");
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Data Selected! Select one to view details", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerOldStudentsViewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.registerOldStudentsViewGrid.Rows[e.RowIndex];
                    registerOldStudentsViewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;

                    si = new StudentInformation()
                    {
                        student_id = row.Cells["student_id"].Value.ToString(),
                        fname = row.Cells["firstname"].Value.ToString(),
                        lname = row.Cells["lastname"].Value.ToString(),
                        student_num = row.Cells["student_no"].Value.ToString(),
                        yearlevel = row.Cells["year_name"].Value.ToString(),
                        academicyear = row.Cells["academic_year"].Value.ToString(),
                        mi = row.Cells["mi"].Value.ToString(),
                        bdate = row.Cells["birthdate"].Value.ToString(),
                        age = row.Cells["age"].Value.ToString(),
                        studContact = row.Cells["contact"].Value.ToString(),
                        gender = row.Cells["gender"].Value.ToString(),
                        rel = row.Cells["religion"].Value.ToString(),
                        citizen = row.Cells["citizenship"].Value.ToString(),
                        generalAverage = row.Cells["final_average"].Value.ToString(),
                        father_name = row.Cells["father_name"].Value.ToString(),
                        fatherDOB = row.Cells["fatherDOB"].Value.ToString(),
                        father_age = row.Cells["father_age"].Value.ToString(),
                        fatherOccupation = row.Cells["father_occupation"].Value.ToString(),
                        fatherContact = row.Cells["father_contact"].Value.ToString(),
                        fatherEducation = row.Cells["father_education"].Value.ToString(),
                        motherName = row.Cells["mother_name"].Value.ToString(),
                        motherDOB = row.Cells["motherDOB"].Value.ToString(),
                        mother_age = row.Cells["mother_age"].Value.ToString(),
                        motherOccupation = row.Cells["mother_occupation"].Value.ToString(),
                        motherCOntact = row.Cells["mother_contact"].Value.ToString(),
                        motherEducation = row.Cells["mother_education"].Value.ToString(),
                        guardianName = row.Cells["guardian_name"].Value.ToString(),
                        guardianRelationship = row.Cells["relationship"].Value.ToString(),
                        guardianContact = row.Cells["guardian_contact"].Value.ToString(),
                        guardianAddress = row.Cells["guardian_address"].Value.ToString(),
                        goodmoralCertificate = row.Cells["good_moral_certificate"].Value.ToString(),
                        nsoCertificate = row.Cells["nso_birth_certificate"].Value.ToString(),
                        reportcard = row.Cells["report_card_form138"].Value.ToString(),
                        baptismalCertificate = row.Cells["baptismal_certificate"].Value.ToString(),
                        clearanceCertificate = row.Cells["clearance"].Value.ToString(),
                        student_status = row.Cells["student_status"].Value.ToString()
                    };

                    oc.setStudentDetailsObj(si);

                    gradelevelcomboBox.SelectedIndex = gradelevelcomboBox.FindStringExact(row.Cells["year_name"].Value.ToString()) + 1;
                    
                    firstnametextBox.Text = row.Cells["firstname"].Value.ToString();
                    lastnametextBox.Text = row.Cells["lastname"].Value.ToString();
                    middlenametextBox.Text = row.Cells["mi"].Value.ToString();
                    gendercomboBox.Text = row.Cells["gender"].Value.ToString();
                    studentNumTextBox.Text = row.Cells["student_no"].Value.ToString();
                    this.studentId = row.Cells["student_id"].Value.ToString();

                    editBtn.Enabled = true;
                    studentNumTextBox.Enabled = true;
                    updateclearancecheckBox.Enabled = true;
                    updatereportCardcheckBox.Enabled = true;
                    finalAverageTextbox.Enabled = true;
                    registerOldStudentBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void registerOldStudentBtn_Click(object sender, EventArgs e)
        {
           var result = MessageBox.Show("Register this Student?","",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result ==  DialogResult.Yes)
            {
                try
                {
                    string newYearLevelId = gradelevelcomboBox.SelectedValue.ToString();
                    string newAcademicYearId = schoolyearCmbx.SelectedValue.ToString();
                    // oc.openCon();
                    oc.registerOldstudent(newYearLevelId, newAcademicYearId, finalAverageTextbox.Text, studentId);

                    int index = registerOldStudentsViewGrid.CurrentCell.RowIndex;
                    registerOldStudentsViewGrid.Rows.RemoveAt(index);
                    studentNumTextBox.Enabled = false;
                    updateclearancecheckBox.Enabled = false;
                    updatereportCardcheckBox.Enabled = false;
                    finalAverageTextbox.Enabled = false;

                    studentNumTextBox.Text = String.Empty;
                    updateclearancecheckBox.Checked = false;
                    updatereportCardcheckBox.Checked = false;
                    finalAverageTextbox.Text = String.Empty;
                    firstnametextBox.Text = String.Empty;
                    lastnametextBox.Text = String.Empty;
                    middlenametextBox.SelectedIndex = -1;
                    gendercomboBox.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updatereportCardcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updatereportCardcheckBox, updatereportCardcheckBox.Name);
        }

        private void updateclearancecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oc.validateCheckBox(updateclearancecheckBox, updateclearancecheckBox.Name);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

            UpdateStudentProfileForm us = new UpdateStudentProfileForm(oc.getStudentDetailsObj(), true, this, "registerOld");
            us.ShowDialog();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            si.Reset();
            registerOldStudentBtn.Enabled = false;
            editBtn.Enabled = false;
            studentNumTextBox.Enabled = false;
            updateclearancecheckBox.Enabled = false;
            updatereportCardcheckBox.Enabled = false;
            finalAverageTextbox.Enabled = false;
            gradelevelcomboBox.SelectedIndex = 0;
            studentNumTextBox.Text = String.Empty;
            updateclearancecheckBox.Checked = false;
            updatereportCardcheckBox.Checked = false;
            finalAverageTextbox.Text = String.Empty;
            firstnametextBox.Text = String.Empty;
            lastnametextBox.Text = String.Empty;
            middlenametextBox.SelectedIndex = -1;
            gendercomboBox.SelectedIndex = -1;
            registerOldStudentsViewGrid.DefaultCellStyle.SelectionBackColor = Color.White;
        }

        public void displayNotEnrolledstudentsToGrid()
        {
            try
            {
                oc.displayNotEnrolledOldStudents();
                registerOldStudentsViewGrid.DataSource = oc.QueryExe();
                registerOldStudentsViewGrid.Refresh();
                si.Reset();
                registerOldStudentsViewGrid.Columns["student_status"].DefaultCellStyle.BackColor = Color.Pink;
                registerOldStudentsViewGrid.Columns["student_status"].DefaultCellStyle.ForeColor = Color.White;
                filterDisplayHeaders(registerOldStudentsViewGrid);

                registerOldStudentBtn.Enabled = false;
                editBtn.Enabled = false;
                studentNumTextBox.Enabled = false;
                updateclearancecheckBox.Enabled = false;
                updatereportCardcheckBox.Enabled = false;
                finalAverageTextbox.Enabled = false;
                studentNumTextBox.Text = String.Empty;
                updateclearancecheckBox.Checked = false;
                updatereportCardcheckBox.Checked = false;
                finalAverageTextbox.Text = String.Empty;
                firstnametextBox.Text = String.Empty;
                lastnametextBox.Text = String.Empty;
                middlenametextBox.SelectedIndex = -1;
                gendercomboBox.SelectedIndex = -1;
                gradelevelcomboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayRegisteredStudentsToGrid()
        {
            try
            {
                oc.displayRegisteredStudents();
                registeredGridview.DataSource = oc.QueryExe();
                registeredGridview.Refresh();
                si.Reset();
                gridRegister = false;
                registeredGridview.Columns["student_status"].DefaultCellStyle.BackColor = Color.LimeGreen;
                registeredGridview.Columns["student_status"].DefaultCellStyle.ForeColor = Color.White;
                filterDisplayHeaders(registeredGridview);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayEnrolledstudentsToGrid()
        {
            try
            {
                oc.displayEnrolledStudents();
                enrolledGridview.DataSource = oc.QueryExe();
                enrolledGridview.Refresh();
                si.Reset();
                gridEnrolled = false;
                enrolledGridview.Columns["student_status"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                enrolledGridview.Columns["student_status"].DefaultCellStyle.ForeColor = Color.White;
                filterDisplayHeaders(enrolledGridview);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayGraduateStudentsToGrid()
        {
            try
            {
                oc.getGraduateStudents();
                graduatesdataGridView.DataSource = oc.QueryExe();
                graduatesdataGridView.Refresh();
                si.Reset();
                gridGraduate = false;
                graduatesdataGridView.Columns["student_status"].DefaultCellStyle.BackColor = Color.Gold;
                graduatesdataGridView.Columns["student_status"].DefaultCellStyle.ForeColor = Color.White;
                //filterDisplayHeaders(graduatesdataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayDroppedStudentsToGrid()
        {
            try
            {
                oc.displayDroppedStudents(droppedSearchTxtBox.Text);
                droppeddataGridView.DataSource = oc.QueryExe();
                si.Reset();
                gridDropped = false;
                droppeddataGridView.Columns["student_status"].DefaultCellStyle.BackColor = Color.Gold;
                droppeddataGridView.Columns["student_status"].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void filterDisplayHeaders(DataGridView datagrid)
        {
            datagrid.Columns["father_name"].Visible = false;
            datagrid.Columns["fatherDOB"].Visible = false;
            datagrid.Columns["father_age"].Visible = false;
            datagrid.Columns["father_education"].Visible = false;
            datagrid.Columns["father_occupation"].Visible = false;
            datagrid.Columns["father_contact"].Visible = false;
            datagrid.Columns["mother_name"].Visible = false;
            datagrid.Columns["motherDOB"].Visible = false;
            datagrid.Columns["mother_age"].Visible = false;
            datagrid.Columns["mother_education"].Visible = false;
            datagrid.Columns["mother_occupation"].Visible = false;
            datagrid.Columns["mother_contact"].Visible = false;
            datagrid.Columns["guardian_name"].Visible = false;
            datagrid.Columns["relationship"].Visible = false;
            datagrid.Columns["guardian_address"].Visible = false;
            datagrid.Columns["guardian_contact"].Visible = false;
            datagrid.Columns["fi_studentId"].Visible = false;
            datagrid.Columns["academic_yearId"].Visible = false;
            datagrid.Columns["grade_levelId"].Visible = false;
            datagrid.Columns["sectionId"].Visible = false;
            datagrid.Columns["year_level_id"].Visible = false;
           // datagrid.Columns["current_academic_yearId"].Visible = false;
            datagrid.Columns["family_information_id"].Visible = false;
            datagrid.Columns["sid_id"].Visible = false;
            datagrid.Columns["current_school_id"].Visible = false;
            datagrid.Columns["student_id"].Visible = false;
        }

        private void updateDroppedBtn_Click(object sender, EventArgs e)
        {
            if (gridDropped == true)
            {
                UpdateStudentProfileForm us = new UpdateStudentProfileForm(oc.getStudentDetailsObj(), false, this, "dropped");
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Data Selected! Select one to view details", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void oldStudentSearchBtn_Click(object sender, EventArgs e)
        {
            oc.displayNotEnrolledOldStudents(oldStudentLastnameTxtBox.Text, oldStudentFristnameTxtBox.Text);
            registerOldStudentsViewGrid.DataSource = oc.QueryExe();
        }

        private void registeredSearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                oc.displayRegisteredStudents(registeredSearchTxtBox.Text);
                registeredGridview.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void enrolledTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                oc.displayEnrolledStudents(enrolledTxtBox.Text);
                enrolledGridview.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void graduateSearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                oc.displayGraduateStudents(graduateSearchTxtBox.Text);
                graduatesdataGridView.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void droppedSearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                oc.displayDroppedStudents(droppedSearchTxtBox.Text);
                droppeddataGridView.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void displayCurrentShoolYear()
        {
            try
            {
                oc.getCurrentIdAndScholYear();
                foreach (DataRow dr in oc.QueryExe().Rows)
                {
                    schoolyearCmbx.ValueMember = "academic_id";
                    schoolyearCmbx.DisplayMember = "academic_year";
                    schoolyearCmbx.DataSource = oc.QueryExe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayYearlevel()
        {
            try
            {
                oc.getYearLevel();
                gradelevelcomboBox.ValueMember = "year_level_id";
                gradelevelcomboBox.DisplayMember = "year_name";
                gradelevelcomboBox.DataSource = oc.QueryExe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void droppeddataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // This section is for updating Student information
                try
                {
                    DataGridViewRow row = this.droppeddataGridView.Rows[e.RowIndex];
                    gridDropped = true;
                    droppeddataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    // Creates an object and pass to setStudentDetailsObj method and be fetch by getStudentDetailsObj
                    StudentInformation si = new StudentInformation()
                    {
                        student_id = row.Cells["student_id"].Value.ToString(),
                        fname = row.Cells["firstname"].Value.ToString(),
                        lname = row.Cells["lastname"].Value.ToString(),
                        student_num = row.Cells["student_no"].Value.ToString(),
                        yearlevelId = row.Cells["year_level_id"].Value.ToString(),
                        yearlevel = row.Cells["year_name"].Value.ToString(),
                        sectionId = row.Cells["sectionId"].Value.ToString(),
                        sectionName = row.Cells["section_name"].Value.ToString(),
                        academicyear = row.Cells["academic_year"].Value.ToString(),
                        mi = row.Cells["mi"].Value.ToString(),
                        bdate = row.Cells["birthdate"].Value.ToString(),
                        age = row.Cells["age"].Value.ToString(),
                        studContact = row.Cells["contact"].Value.ToString(),
                        gender = row.Cells["gender"].Value.ToString(),
                        studAddress = row.Cells["address"].Value.ToString(),
                        rel = row.Cells["religion"].Value.ToString(),
                        citizen = row.Cells["citizenship"].Value.ToString(),
                        generalAverage = row.Cells["final_average"].Value.ToString(),
                        father_name = row.Cells["father_name"].Value.ToString(),
                        fatherDOB = row.Cells["fatherDOB"].Value.ToString(),
                        father_age = row.Cells["father_age"].Value.ToString(),
                        fatherOccupation = row.Cells["father_occupation"].Value.ToString(),
                        fatherContact = row.Cells["father_contact"].Value.ToString(),
                        fatherEducation = row.Cells["father_education"].Value.ToString(),
                        motherName = row.Cells["mother_name"].Value.ToString(),
                        motherDOB = row.Cells["motherDOB"].Value.ToString(),
                        mother_age = row.Cells["mother_age"].Value.ToString(),
                        motherOccupation = row.Cells["mother_occupation"].Value.ToString(),
                        motherCOntact = row.Cells["mother_contact"].Value.ToString(),
                        motherEducation = row.Cells["mother_education"].Value.ToString(),
                        guardianName = row.Cells["guardian_name"].Value.ToString(),
                        guardianRelationship = row.Cells["relationship"].Value.ToString(),
                        guardianContact = row.Cells["guardian_contact"].Value.ToString(),
                        guardianAddress = row.Cells["guardian_address"].Value.ToString(),
                        goodmoralCertificate = row.Cells["good_moral_certificate"].Value.ToString(),
                        nsoCertificate = row.Cells["nso_birth_certificate"].Value.ToString(),
                        reportcard = row.Cells["report_card_form138"].Value.ToString(),
                        baptismalCertificate = row.Cells["baptismal_certificate"].Value.ToString(),
                        clearanceCertificate = row.Cells["clearance"].Value.ToString(),
                        student_status = row.Cells["student_status"].Value.ToString()
                    };

                    oc.setStudentDetailsObj(si);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void graduatesdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // This section is for updating Student information
                try
                {
                    DataGridViewRow row = this.graduatesdataGridView.Rows[e.RowIndex];
                    gridGraduate = true;
                    graduatesdataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    // Creates an object and pass to setStudentDetailsObj method and be fetch by getStudentDetailsObj
                    StudentInformation si = new StudentInformation()
                    {
                        student_id = row.Cells["student_id"].Value.ToString(),
                        fname = row.Cells["firstname"].Value.ToString(),
                        lname = row.Cells["lastname"].Value.ToString(),
                        student_num = row.Cells["student_no"].Value.ToString(),
                        yearlevelId = row.Cells["year_level_id"].Value.ToString(),
                        yearlevel = row.Cells["year_name"].Value.ToString(),
                        sectionId = row.Cells["sectionId"].Value.ToString(),
                        sectionName = row.Cells["section_name"].Value.ToString(),
                        academicyear = row.Cells["academic_year"].Value.ToString(),
                        mi = row.Cells["mi"].Value.ToString(),
                        bdate = row.Cells["birthdate"].Value.ToString(),
                        age = row.Cells["age"].Value.ToString(),
                        studContact = row.Cells["contact"].Value.ToString(),
                        gender = row.Cells["gender"].Value.ToString(),
                        studAddress = row.Cells["address"].Value.ToString(),
                        rel = row.Cells["religion"].Value.ToString(),
                        citizen = row.Cells["citizenship"].Value.ToString(),
                        generalAverage = row.Cells["final_average"].Value.ToString(),
                        father_name = row.Cells["father_name"].Value.ToString(),
                        fatherDOB = row.Cells["fatherDOB"].Value.ToString(),
                        father_age = row.Cells["father_age"].Value.ToString(),
                        fatherOccupation = row.Cells["father_occupation"].Value.ToString(),
                        fatherContact = row.Cells["father_contact"].Value.ToString(),
                        fatherEducation = row.Cells["father_education"].Value.ToString(),
                        motherName = row.Cells["mother_name"].Value.ToString(),
                        motherDOB = row.Cells["motherDOB"].Value.ToString(),
                        mother_age = row.Cells["mother_age"].Value.ToString(),
                        motherOccupation = row.Cells["mother_occupation"].Value.ToString(),
                        motherCOntact = row.Cells["mother_contact"].Value.ToString(),
                        motherEducation = row.Cells["mother_education"].Value.ToString(),
                        guardianName = row.Cells["guardian_name"].Value.ToString(),
                        guardianRelationship = row.Cells["relationship"].Value.ToString(),
                        guardianContact = row.Cells["guardian_contact"].Value.ToString(),
                        guardianAddress = row.Cells["guardian_address"].Value.ToString(),
                        goodmoralCertificate = row.Cells["good_moral_certificate"].Value.ToString(),
                        nsoCertificate = row.Cells["nso_birth_certificate"].Value.ToString(),
                        reportcard = row.Cells["report_card_form138"].Value.ToString(),
                        baptismalCertificate = row.Cells["baptismal_certificate"].Value.ToString(),
                        clearanceCertificate = row.Cells["clearance"].Value.ToString(),
                        student_status = row.Cells["student_status"].Value.ToString()
                    };

                    oc.setStudentDetailsObj(si);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void updateGraduateBtn_Click(object sender, EventArgs e)
        {
            if (gridGraduate == true)
            {
                UpdateStudentProfileForm us = new UpdateStudentProfileForm(oc.getStudentDetailsObj(), false, this, "graduate");
                us.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Data Selected! Select one to view details", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void oldStudentLastnameTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                oldStudentSearchBtn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void oldStudentFristnameTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                oldStudentSearchBtn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
