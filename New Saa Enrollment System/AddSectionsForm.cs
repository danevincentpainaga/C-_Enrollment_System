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
    public partial class AddSectionsForm : Form
    {
        private string sectionId;
        private ScheduleClass sc;
        private AddSectionClass ac;
        public AddSectionsForm()
        {
            InitializeComponent();
            sc = new ScheduleClass();
            ac = new AddSectionClass();
        }

        private void AddSectionsForm_Load(object sender, EventArgs e)
        {
            displayYearLevel();
            displayTeachers();
            displaySections();
            customGrid();
        }

        private void displaySections(string yearlevelId = null)
        {
            try
            {
                ac.getSectionsDetails(yearlevelId);
                sectionsdataGridView.DataSource = ac.QueryExe();
                sectionsdataGridView.Refresh();
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
                paymentClass pc = new paymentClass();
                pc.getYearLevel();
                yearLevelComboBox.ValueMember = "year_level_id";
                yearLevelComboBox.DisplayMember = "year_name";
                yearLevelComboBox.DataSource = pc.QueryExe();
                filterYearLevelComboBox.ValueMember = "year_level_id";
                filterYearLevelComboBox.DisplayMember = "year_name";
                filterYearLevelComboBox.DataSource = pc.QueryExe();
                filterYearLevelComboBox.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void displayTeachers()
        {
            sc.getTeachers();
            sectionAdviserComboBox.ValueMember = "teacher_id";
            sectionAdviserComboBox.DisplayMember = "teachername";
            sectionAdviserComboBox.DataSource = sc.QueryExe();
        }

        private void cancelSectionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                addSectionBtn.Text = "ADD";
                yearLevelComboBox.SelectedIndex = -1;
                sectionAdviserComboBox.SelectedIndex = -1;
                sectionNameTxtBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addSectionBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sectionNameTxtBox.Text) || yearLevelComboBox.SelectedIndex == -1 || sectionAdviserComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Complete the Form");
            }
            else
            {
                string btnValue = addSectionBtn.Text;
                switch (btnValue)
                {
                    case "ADD":
                        ac.addSections(
                                          sectionNameTxtBox.Text,
                                          yearLevelComboBox.SelectedValue.ToString(),
                                          sectionAdviserComboBox.SelectedValue.ToString()
                                      );

                        displaySections();
                        break;

                    case "UPDATE":
                        ac.updateSection(
                                          sectionId,
                                          sectionNameTxtBox.Text,
                                          yearLevelComboBox.SelectedValue.ToString(),
                                          sectionAdviserComboBox.SelectedValue.ToString()
                                        );

                        displaySections();
                        break;
                }
            }
        }

        private void customGrid()
        {
            sectionsdataGridView.AllowUserToAddRows = false;
            sectionsdataGridView.Columns["section_id"].Visible = false;
            sectionsdataGridView.Columns["teacher_id"].Visible = false;
            sectionsdataGridView.Columns["teacher_id"].Visible = false;
            sectionsdataGridView.Columns["adviser"].Visible = false;
            sectionsdataGridView.Columns["yearlevelId"].Visible = false;
            sectionsdataGridView.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            sectionsdataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            sectionsdataGridView.AutoResizeColumns();
            sectionsdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void sectionsdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    addSectionBtn.Text = "UPDATE";
                    DataGridViewRow row = this.sectionsdataGridView.Rows[e.RowIndex];
                    sectionNameTxtBox.Text = row.Cells["section_name"].Value.ToString();
                    sectionId = row.Cells["section_id"].Value.ToString();
                    yearLevelComboBox.SelectedIndex = yearLevelComboBox.FindStringExact(row.Cells["year_name"].Value.ToString());
                    sectionAdviserComboBox.SelectedIndex = sectionAdviserComboBox.FindStringExact(row.Cells["teachername"].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void filterYearLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySections(filterYearLevelComboBox.SelectedValue.ToString());
        }
    }
}
