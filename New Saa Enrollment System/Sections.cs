using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class Sections : UserControl
    {
        private sectioningClass sc;
        public Sections()
        {
            InitializeComponent();
            sc = new sectioningClass();
        }

        private void Sections_Load(object sender, EventArgs e)
        {
            displayStudents("1", fyeardataGridView, fgetStdentPerSeComboBox);
            formatGrid(syeardataGridView);
            formatGrid(syeardataGridView);
            formatGrid(tyeardataGridView);
            formatGrid(ftyeardataGridView);
        }

        private void startSectioningButton_Click(object sender, EventArgs e)
        {
            StartSectioningForm st = new StartSectioningForm();
            st.ShowDialog();
        }

        private void yearlevelstabControl_SelectedIndexChanged(object sender, EventArgs e)
        {  
            int tabText = yearlevelstabControl.SelectedIndex;
            switch (tabText)
            {
                case 0:
                    displayStudents("1", fyeardataGridView, fgetStdentPerSeComboBox);
                    break;
                case 1:
                    displayStudents("2", syeardataGridView, sgetStdentPerSeComboBox);
                    break;
                case 2:
                    displayStudents("3", tyeardataGridView, tgetStdentPerSeComboBox);
                    break;
                case 3:
                    displayStudents("4", ftyeardataGridView, ftgetStdentPerSeComboBox);
                    break;
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

        private void displayStudents(string yid, DataGridView datagrid, ComboBox cbx)
        {
            try
            {
                sc.getSectionsByYear(yid);
                cbx.ValueMember = "section_id";
                cbx.DisplayMember = "section_name";
                cbx.DataSource = sc.QueryExe();
                Thread.Sleep(300);
                displayStudentsPerSections(yid, datagrid, cbx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ftgetStdentPerSeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayStudentsPerSections("4", ftyeardataGridView, ftgetStdentPerSeComboBox);
        }

        private void tgetStdentPerSeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayStudentsPerSections("3", tyeardataGridView, tgetStdentPerSeComboBox);
        }

        private void sgetStdentPerSeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayStudentsPerSections("2", syeardataGridView, sgetStdentPerSeComboBox);
        }

        private void fgetStdentPerSeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayStudentsPerSections("1", fyeardataGridView, fgetStdentPerSeComboBox);
        }

        private void displayStudentsPerSections(string yearlevelId, DataGridView datagrid, ComboBox cbx)
        {
            sc.getStudentsPerYear(yearlevelId, cbx.SelectedValue.ToString());
            datagrid.DataSource = sc.QueryExe();
        }
    }
}
