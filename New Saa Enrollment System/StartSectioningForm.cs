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
    public partial class StartSectioningForm : Form
    {
        private string yearlevelid;
        private static int count = 0;
        private sectioningClass sc;
        private ScheduleClass sd;
        public StartSectioningForm()
        {
            InitializeComponent();
            sc = new sectioningClass();
            sd = new ScheduleClass();
        }

        private void StartSectioningForm_Load(object sender, EventArgs e)
        {
            sectionSearchStudentsTxtBox.Enabled = false;
            cancelSectioningBtn.Enabled = false;
            sectioningStartBtn.Enabled = false;
            sectionsComboBox.Enabled = false;
            selectedStudentsdataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            selectedStudentsdataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            selectedStudentsdataGridView.AutoResizeColumns();
            selectedStudentsdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void allStudentsdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0 && e.RowIndex != -1)
            if (e.RowIndex >=0 ) {
                try
                {
                    allStudentsdataGridView.SelectedRows[0].Cells[0].Value = ((bool)allStudentsdataGridView.SelectedRows[0].Cells[0].Value == false) ? true : false;

                    if ((bool)allStudentsdataGridView.SelectedRows[0].Cells[0].Value == true)
                    {
                        selectedStudentsdataGridView.Rows.Add();
                        selectedStudentsdataGridView.Rows[count].Cells[0].Value = allStudentsdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[1].Value = allStudentsdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[2].Value = allStudentsdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[3].Value = allStudentsdataGridView.SelectedRows[0].Cells[4].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[4].Value = allStudentsdataGridView.SelectedRows[0].Cells[5].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[5].Value = allStudentsdataGridView.SelectedRows[0].Cells[6].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[6].Value = allStudentsdataGridView.SelectedRows[0].Cells[7].Value.ToString();
                        selectedStudentsdataGridView.Rows[count].Cells[7].Value = allStudentsdataGridView.SelectedRows[0].Cells[8].Value.ToString();
                        count += 1;
                    }
                    else
                    {
                        count = (count > 0) ? count - 1 : 0;
                        for (int i = 0; i < selectedStudentsdataGridView.Rows.Count; i++)
                        {
                            if(selectedStudentsdataGridView.Rows[i].Cells[0].Value.ToString() == allStudentsdataGridView.SelectedRows[0].Cells[1].Value.ToString())
                            {
                                selectedStudentsdataGridView.Rows.RemoveAt(selectedStudentsdataGridView.Rows[i].Cells[0].RowIndex);
                            }
                        }
                    }

                    selectedCountlabel.Text = count.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void displaySections(string yid)
        {
            try
            {
                sectionsComboBox.DataSource = null;
                sectionsComboBox.Items.Clear();
                sd.getSections(yid);
                sectionsComboBox.ValueMember = "section_id";
                sectionsComboBox.DisplayMember = "section_name";
                sectionsComboBox.DataSource = sd.QueryExe();
       
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void firstyearRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (firstyearRadioBtn.Checked == true)
            {
                displaySections("1");
                this.yearlevelid = "1";
                sectionsComboBox.Enabled = true;
                sectionsComboBox.SelectedIndex = -1;
                cancelSectioningBtn.Enabled = true;
            }
        }

        private void secondyearRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (secondyearRadioBtn.Checked == true)
            {
                displaySections("2");
                this.yearlevelid = "2";
                sectionsComboBox.Enabled = true;
                sectionsComboBox.SelectedIndex = -1;
                cancelSectioningBtn.Enabled = true;
            }
        }

        private void thirdyearRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (thirdyearRadioBtn.Checked == true)
            {
                displaySections("3");
                this.yearlevelid = "3";
                sectionsComboBox.Enabled = true;
                sectionsComboBox.SelectedIndex = -1;
                cancelSectioningBtn.Enabled = true;
            }
        }

        private void fourthyearRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (fourthyearRadioBtn.Checked == true)
            {
                displaySections("4");
                this.yearlevelid = "4";
                sectionsComboBox.Enabled = true;
                sectionsComboBox.SelectedIndex = -1;
                cancelSectioningBtn.Enabled = true;
            }
        }

        private void sectionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectioningStartBtn.Enabled = (sectionsComboBox.SelectedIndex == -1) ? false : true ;
        }

        private void sectioningStartBtn_Click(object sender, EventArgs e)
        {
            sectionSearchStudentsTxtBox.Enabled = true;
            sectioningStartBtn.Enabled = false;
            firstyearRadioBtn.Enabled = false;
            secondyearRadioBtn.Enabled = false;
            thirdyearRadioBtn.Enabled = false;
            fourthyearRadioBtn.Enabled = false;
            sectionsComboBox.Enabled = false;
            displayAllStudentsToGrid(yearlevelid);
            MessageBox.Show("Sectioning Enable", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CanceSectioningBtn_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to cancel sectioning?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(response == DialogResult.Yes) {
                selectedCountlabel.Text = "0";
                sectionSearchStudentsTxtBox.Enabled = false;
                cancelSectioningBtn.Enabled = false;
                sectionsComboBox.Enabled = false;
                sectioningStartBtn.Enabled = false;
                firstyearRadioBtn.Enabled = true;
                secondyearRadioBtn.Enabled = true;
                thirdyearRadioBtn.Enabled = true;
                fourthyearRadioBtn.Enabled = true;
                firstyearRadioBtn.Checked = false;
                secondyearRadioBtn.Checked = false;
                thirdyearRadioBtn.Checked = false;
                fourthyearRadioBtn.Checked = false;
                selectedStudentsdataGridView.Rows.Clear();
                allStudentsdataGridView.Rows.Clear();
                sectionsComboBox.DataSource = null;
                sectionsComboBox.Items.Clear();
                count = 0;
                MessageBox.Show("Sectioning Cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sectioningSaveBtn_Click(object sender, EventArgs e)
        {
            if(count > 0) { 
            var response = MessageBox.Show("Save Details?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    try
                    {
                        DataRowView oDataRowView = sectionsComboBox.SelectedItem as DataRowView;
                        string sectioName = oDataRowView.Row["section_name"] as string;

                        sc.createSectioning(
                                                selectedStudentsdataGridView,
                                                sectionsComboBox.SelectedValue.ToString(),
                                                sectioName
                                           );

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selected Table Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allStudentsdataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    e.PaintBackground(e.CellBounds, true);
                    ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
                        e.CellBounds.Width - 2, e.CellBounds.Height - 2,
                        (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Flat);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void sectionSearchStudentsTxtBox_TextChanged(object sender, EventArgs e)
        {
            displayAllStudentsToGrid(yearlevelid, sectionSearchStudentsTxtBox.Text);
            try
            {
                if (allStudentsdataGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < allStudentsdataGridView.Rows.Count; i++)
                    {
                        allStudentsdataGridView.Rows[i].Cells[0].Value = checkIfExist(allStudentsdataGridView.Rows[i].Cells[1].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void displayAllStudentsToGrid(string yearlevel_id, string searched = null)
        {
            sc.getAllEnrolledStudents(yearlevel_id, searched);
            allStudentsdataGridView.Rows.Clear();

            if (sc.QueryExe() != null)
            {
                foreach (DataRow item in sc.QueryExe().Rows)
                {
                    int n = allStudentsdataGridView.Rows.Add();
                    allStudentsdataGridView.Rows[n].Cells[0].Value = false;
                    allStudentsdataGridView.Rows[n].Cells[1].Value = item["student_id"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[2].Value = item["lastname"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[3].Value = item["firstname"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[4].Value = item["mi"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[5].Value = item["grade_levelId"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[6].Value = item["year_name"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[7].Value = item["academic_id"].ToString();
                    allStudentsdataGridView.Rows[n].Cells[8].Value = item["academic_year"].ToString();
                }

                allStudentsdataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
                allStudentsdataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
                allStudentsdataGridView.AutoResizeColumns();
                allStudentsdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                allStudentsdataGridView.AllowUserToAddRows = false;
                // allStudentsdataGridView.Columns["academic_id"].Visible = false;
            }
        }

        private bool checkIfExist(string rowValue)
        {
            bool value = false;
            for (int i = 0; i < selectedStudentsdataGridView.Rows.Count; i++)
            {
                if (rowValue == selectedStudentsdataGridView.Rows[i].Cells[0].Value.ToString())
                {
                    value = true;
                }
            }
            return value;
        }

    }
}
