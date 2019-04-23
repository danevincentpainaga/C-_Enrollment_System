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
    public partial class Enrollment : UserControl
    {
        private EnrollmentClass ec;
        private Panel dashboard_header;
        private string academicId;
        
        public Enrollment(Panel dashboardheader)
        {
            InitializeComponent();
            ec = new EnrollmentClass();
            dashboard_header = dashboardheader;
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            dashboard_header.SendToBack();
            enrollmentStatuscomboBox.Items.Add("");
            enrollmentStatuscomboBox.Items.Add("pending");
            enrollmentStatuscomboBox.Items.Add("registered");
            enrollmentStatuscomboBox.Items.Add("enrolled");
            enrollmentStatuscomboBox.Items.Add("graduate");
            enrollmentStatuscomboBox.Items.Add("dropped");
            enrollmentStatuscomboBox.Items.Add("cancelled");

            string today = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            enrollmentDateTxtBox.Text = today;

            displayAllStudents();
            displayFeesPerYear();

            enrollmentGrid.Columns["student_id"].Visible = false;
            enrollmentGrid.Columns["academic_yearId"].Visible = false;
            enrollmentGrid.Columns["grade_levelId"].Visible = false;
            enrollmentGrid.Columns["sectionId"].Visible = false;
            enrollmentGrid.Columns["religion"].Visible = false;
            enrollmentGrid.Columns["citizenship"].Visible = false;
            enrollmentGrid.Columns["good_moral_certificate"].Visible = false;
            enrollmentGrid.Columns["nso_birth_certificate"].Visible = false;
            enrollmentGrid.Columns["report_card_form138"].Visible = false;
            enrollmentGrid.Columns["baptismal_certificate"].Visible = false;
            enrollmentGrid.Columns["clearance"].Visible = false;
            enrollmentGrid.Columns["birthdate"].Visible = false;

            formatGrid(enrollmentGrid);
            formatGrid(settedcurrentAcademicYeardataGridView1);
            formatGrid(academicyearGridView);

            enrollmentGrid.AllowUserToAddRows = false;
            
            ec.getSections();
            ec.QueryExe();

            displayStatusesCount();
        }

        private void enrollmentGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.enrollmentGrid.Columns[e.ColumnIndex].Name == "student_status")
            {
                if (e.Value != null)
                {
                    string stringValue = (string)e.Value;
                    stringValue = stringValue.ToLower();
                    if ((stringValue.IndexOf("pending") > -1))
                    {
                        e.CellStyle.BackColor = Color.LimeGreen;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    if ((stringValue.IndexOf("registered") > -1))
                    {
                        e.CellStyle.BackColor = Color.Pink;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    if ((stringValue.IndexOf("enrolled") > -1))
                    {
                        e.CellStyle.BackColor = Color.DeepSkyBlue;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    if ((stringValue.IndexOf("cancelled") > -1))
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    if ((stringValue.IndexOf("dropped") > -1))
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    if ((stringValue.IndexOf("graduate") > -1))
                    {
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void startEnrollmentBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(academic_yearTextbox.Text))
            {
                new StartEnrollmentConfirmationForm(academic_yearTextbox.Text).ShowDialog();
            }
            else
            {
                MessageBox.Show("Input Field Academic Year Empty", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enrollmentTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tabText = enrollmentTabControl.SelectedIndex;
            switch (tabText)
            {
                case 1:
                    displayAcademicYearsToGrid();
                    displayCurrentAcademicYearsToGrid();
                    academicyearGridView.Columns["academic_id"].Visible = false;
                    settedcurrentAcademicYeardataGridView1.Columns["academic_id"].Visible = false;
                    settedcurrentAcademicYeardataGridView1.Columns["current_academic_yearId"].Visible = false;
                    break;
            }
        }

        private void displayAcademicYearsToGrid()
        {
            ec.displayAcademicYears();
            academicyearGridView.DataSource = ec.QueryExe();
        }

        private void displayCurrentAcademicYearsToGrid()
        {
            ec.displayCurrentAcademicYear();
            settedcurrentAcademicYeardataGridView1.DataSource = ec.QueryExe();
        }

        private void cancelAcademicYearBtn_Click(object sender, EventArgs e)
        {
            addAcademicYeartxtBox.Text = String.Empty;
            academicId = null;
            addAcademicYeartxtBox.Enabled = false;
        }

        private void updateAcademicYearBtn_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(addAcademicYeartxtBox.Text))
                {
                    var res = MessageBox.Show("Update Academic Year Details?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        ec.UpdateAcademicYears(addAcademicYeartxtBox.Text, academicId);
                        addAcademicYeartxtBox.Text = String.Empty;
                        displayAcademicYearsToGrid();
                        addAcademicYeartxtBox.Enabled = false;
                    }
                }
            }

        private void settedcurrentAcademicYeardataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    addAcademicYeartxtBox.Enabled = true;
                    DataGridViewRow row = this.settedcurrentAcademicYeardataGridView1.Rows[e.RowIndex];
                    settedcurrentAcademicYeardataGridView1.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                    updateAcademicYearBtn.Text = "UPDATE";
                    academicId = row.Cells["academic_id"].Value.ToString();
                    addAcademicYeartxtBox.Text = row.Cells["academic_year"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void enrollmentStatuscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayAllStudents(enrollmentStatuscomboBox.SelectedItem.ToString());
        }

        private void displayAllStudents(string status = null)
        {
            try
            {
                ec.displayStudentsRecords(status);
                enrollmentGrid.DataSource = ec.QueryExe();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatGrid(DataGridView datagrid)
        {
            datagrid.AllowUserToAddRows = false;
            datagrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            datagrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            datagrid.AutoResizeColumns();
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void firstYearSaveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> fees = new Dictionary<string, string>();
            fees.Add("year_level_id", "1");
            fees.Add("tuition_fee", firstYearTuitionFeeTxtBox.Text );
            fees.Add("athletic", firstYearAtlethicTxtBox.Text);
            fees.Add("laboratory", firstYearLaboratoryTxtBox.Text);
            fees.Add("library", firstYearLibraryTxtBox.Text);
            fees.Add("registration", firstYearRegistrationTxtBox.Text);
            fees.Add("medical_dental", firstYearmedicalDentalTxtBox.Text);
            fees.Add("test_materials", firstYearTestMaterialsTxtBox.Text);
            fees.Add("general_support_services", firstYeargensupServicesTxtBox.Text);
            fees.Add("adce", firstYearAdceTxtbox.Text);
            fees.Add("insurance", firstYearInsuranceTxtBox.Text);
            fees.Add("nassphil", firstYearNassphilTxtBox.Text);
            fees.Add("student_council_fee", firstYearStudentCouncilTxtBox.Text);
            fees.Add("ceap", firstYearCeapTxtBox.Text);
            var result = MessageBox.Show("Are you sure you want to update fees?", "Update Fees", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ec.updateFeesPerYear(fees);
            }
        }

        private void secondYearSaveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> fees = new Dictionary<string, string>();
            fees.Add("year_level_id", "2");
            fees.Add("tuition_fee", secondYearTuitionFeeTxtBox.Text);
            fees.Add("athletic", secondYearAtlethicTxtBox.Text);
            fees.Add("laboratory", secondYearLaboratoryTxtBox.Text);
            fees.Add("library", secondYearLibraryTxtBox.Text);
            fees.Add("registration", secondYearRegistrationTxtBox.Text);
            fees.Add("medical_dental", secondYearmedicalDentalTxtBox.Text);
            fees.Add("test_materials", secondYearTestMaterialsTxtBox.Text);
            fees.Add("general_support_services", secondYeargensupServicesTxtBox.Text);
            fees.Add("adce", secondYearAdceTxtbox.Text);
            fees.Add("insurance", secondYearInsuranceTxtBox.Text);
            fees.Add("nassphil", secondYearNassphilTxtBox.Text);
            fees.Add("student_council_fee", secondYearStudentCouncilTxtBox.Text);
            fees.Add("ceap", secondYearCeapTxtBox.Text);
            var result = MessageBox.Show("Are you sure you want to update fees?", "Update Fees", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ec.updateFeesPerYear(fees);
            }
        }

        private void thirdYearSaveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> fees = new Dictionary<string, string>();
            fees.Add("year_level_id", "3");
            fees.Add("tuition_fee", thirdYearTuitionFeeTxtBox.Text);
            fees.Add("athletic", thirdYearTuitionFeeTxtBox.Text);
            fees.Add("laboratory", thirdYearLaboratoryTxtBox.Text);
            fees.Add("library", thirdYearLibraryTxtBox.Text);
            fees.Add("registration", thirdYearRegistrationTxtBox.Text);
            fees.Add("medical_dental", thirdYearmedicalDentalTxtBox.Text);
            fees.Add("test_materials", thirdYearTestMaterialsTxtBox.Text);
            fees.Add("general_support_services", thirdYeargensupServicesTxtBox.Text);
            fees.Add("adce", thirdYearAdceTxtbox.Text);
            fees.Add("insurance", thirdYearInsuranceTxtBox.Text);
            fees.Add("nassphil", thirdYearNassphilTxtBox.Text);
            fees.Add("student_council_fee", thirdYearStudentCouncilTxtBox.Text);
            fees.Add("ceap", thirdYearCeapTxtBox.Text);
            var result = MessageBox.Show("Are you sure you want to update fees?", "Update Fees", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ec.updateFeesPerYear(fees);
            }
        }

        private void fourthYearSaveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> fees = new Dictionary<string, string>();
            fees.Add("year_level_id", "4");
            fees.Add("tuition_fee", fourthYearTuitionFeeTxtBox.Text);
            fees.Add("athletic", fourthYearAtlethicTxtBox.Text);
            fees.Add("laboratory", fourthYearLaboratoryTxtBox.Text);
            fees.Add("library", fourthYearLibraryTxtBox.Text);
            fees.Add("registration", fourthYearRegistrationTxtBox.Text);
            fees.Add("medical_dental", fourthYearmedicalDentalTxtBox.Text);
            fees.Add("test_materials", fourthYearTestMaterialsTxtBox.Text);
            fees.Add("general_support_services", fourthYeargensupServicesTxtBox.Text);
            fees.Add("adce", fourthYearAdceTxtbox.Text);
            fees.Add("insurance", fourthYearInsuranceTxtBox.Text);
            fees.Add("nassphil", fourthYearNassphilTxtBox.Text);
            fees.Add("student_council_fee", fourthYearStudentCouncilTxtBox.Text);
            fees.Add("ceap", fourthYearCeapTxtBox.Text);
            var result = MessageBox.Show("Are you sure you want to update fees?", "Update Fees", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                ec.updateFeesPerYear(fees);
            }
        }

        private void displayFeesPerYear()
        {
            paymentClass pc = new paymentClass();
            pc.getYearLevel();
            foreach (DataRow dr in pc.QueryExe().Rows)
            {
                switch (dr["year_level_id"].ToString())
                {
                    case "1":
                        firstYearTuitionFeeTxtBox.Text = dr["tuition_fee"].ToString();
                        firstYearTestMaterialsTxtBox.Text = dr["test_materials"].ToString();
                        firstYearStudentCouncilTxtBox.Text = dr["student_council_fee"].ToString();
                        firstYearRegistrationTxtBox.Text = dr["registration"].ToString();
                        firstYearNassphilTxtBox.Text = dr["nassphil"].ToString();
                        firstYearLibraryTxtBox.Text = dr["library"].ToString();
                        firstYearLaboratoryTxtBox.Text = dr["laboratory"].ToString();
                        firstYearmedicalDentalTxtBox.Text = dr["medical_dental"].ToString();
                        firstYearInsuranceTxtBox.Text = dr["insurance"].ToString();
                        firstYeargensupServicesTxtBox.Text = dr["general_support_services"].ToString();
                        firstYearAdceTxtbox.Text = dr["adce"].ToString();
                        firstYearAtlethicTxtBox.Text = dr["athletic"].ToString();
                        firstYearCeapTxtBox.Text = dr["ceap"].ToString();
                        break;
                    case "2":
                        secondYearTuitionFeeTxtBox.Text = dr["tuition_fee"].ToString();
                        secondYearTestMaterialsTxtBox.Text = dr["test_materials"].ToString();
                        secondYearStudentCouncilTxtBox.Text = dr["student_council_fee"].ToString();
                        secondYearRegistrationTxtBox.Text = dr["registration"].ToString();
                        secondYearNassphilTxtBox.Text = dr["nassphil"].ToString();
                        secondYearLibraryTxtBox.Text = dr["library"].ToString();
                        secondYearLaboratoryTxtBox.Text = dr["laboratory"].ToString();
                        secondYearmedicalDentalTxtBox.Text = dr["medical_dental"].ToString();
                        secondYearInsuranceTxtBox.Text = dr["insurance"].ToString();
                        secondYeargensupServicesTxtBox.Text = dr["general_support_services"].ToString();
                        secondYearAdceTxtbox.Text = dr["adce"].ToString();
                        secondYearAtlethicTxtBox.Text = dr["athletic"].ToString();
                        secondYearCeapTxtBox.Text = dr["ceap"].ToString();
                        break;
                    case "3":
                        thirdYearTuitionFeeTxtBox.Text = dr["tuition_fee"].ToString();
                        thirdYearTestMaterialsTxtBox.Text = dr["test_materials"].ToString();
                        thirdYearStudentCouncilTxtBox.Text = dr["student_council_fee"].ToString();
                        thirdYearRegistrationTxtBox.Text = dr["registration"].ToString();
                        thirdYearNassphilTxtBox.Text = dr["nassphil"].ToString();
                        thirdYearLibraryTxtBox.Text = dr["library"].ToString();
                        thirdYearLaboratoryTxtBox.Text = dr["laboratory"].ToString();
                        thirdYearmedicalDentalTxtBox.Text = dr["medical_dental"].ToString();
                        thirdYearInsuranceTxtBox.Text = dr["insurance"].ToString();
                        thirdYeargensupServicesTxtBox.Text = dr["general_support_services"].ToString();
                        thirdYearAdceTxtbox.Text = dr["adce"].ToString();
                        thirdYearAtlethicTxtBox.Text = dr["athletic"].ToString();
                        thirdYearCeapTxtBox.Text = dr["ceap"].ToString();
                        break;
                    case "4":
                        fourthYearTuitionFeeTxtBox.Text = dr["tuition_fee"].ToString();
                        fourthYearTestMaterialsTxtBox.Text = dr["test_materials"].ToString();
                        fourthYearStudentCouncilTxtBox.Text = dr["student_council_fee"].ToString();
                        fourthYearRegistrationTxtBox.Text = dr["registration"].ToString();
                        fourthYearNassphilTxtBox.Text = dr["nassphil"].ToString();
                        fourthYearLibraryTxtBox.Text = dr["library"].ToString();
                        fourthYearLaboratoryTxtBox.Text = dr["laboratory"].ToString();
                        fourthYearmedicalDentalTxtBox.Text = dr["medical_dental"].ToString();
                        fourthYearInsuranceTxtBox.Text = dr["insurance"].ToString();
                        fourthYeargensupServicesTxtBox.Text = dr["general_support_services"].ToString();
                        fourthYearAdceTxtbox.Text = dr["adce"].ToString();
                        fourthYearAtlethicTxtBox.Text = dr["athletic"].ToString();
                        fourthYearCeapTxtBox.Text = dr["ceap"].ToString();
                        break;
                }
            }
        }
        
        private void displayStatusesCount()
        {
            ec.countStudentsBaseOnStatus();
            foreach (DataRow dr in ec.QueryExe().Rows)
            {
                enrolledLabel.Text = (string.IsNullOrEmpty(dr["enrolled"].ToString())) ? "0" : dr["enrolled"].ToString();
                registeredLabel.Text = (string.IsNullOrEmpty(dr["registered"].ToString())) ? "0" : dr["registered"].ToString();
                graduateLabel.Text = (string.IsNullOrEmpty(dr["graduate"].ToString())) ? "0" : dr["graduate"].ToString();
                pendingLabel.Text = (string.IsNullOrEmpty(dr["pending"].ToString())) ? "0" : dr["pending"].ToString();
                droppedLabel.Text = (string.IsNullOrEmpty(dr["dropped"].ToString())) ? "0" : dr["dropped"].ToString();
                cancelLabel.Text = (string.IsNullOrEmpty(dr["cancelled"].ToString())) ? "0" : dr["cancelled"].ToString();
            }
        }

        private void statusReportBtn_Click(object sender, EventArgs e)
        {
            if(enrollmentStatuscomboBox.SelectedIndex != -1)
            { 
                EnrollmentStatusReportForm er = new EnrollmentStatusReportForm(enrollmentStatuscomboBox.SelectedItem.ToString());
                er.ShowDialog();
            }
        }
    }
}
