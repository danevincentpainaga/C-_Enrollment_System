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
    public partial class UpdatePayment : Form
    {
        public UpdatePayment()
        {
            InitializeComponent();
        }

        private void UpdatePayment_Load(object sender, EventArgs e)
        {
            string constring = "datasource = localhost; database = enrollment_system; port = 3306; Uid = root; password = ";
            
            string query = "SELECT s.student_id, s.lastname, s.firstname, s.mi, s.academic_yearId, s.sectionId, s.grade_levelId, s.gender," +
                            "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, yl.*, st.*" +
                            "FROM student_table s " +
                            "INNER JOIN section_table st ON s.sectionId = st.section_id " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'pending' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes' "+
                            "AND NOT EXISTS (SELECT * FROM payment p WHERE s.student_id = p.studentId)";

            //string query = "SELECT s.*, yl.*, st.* FROM student_table s INNER JOIN section_table st ON s.sectionId = st.section_id INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId WHERE NOT EXISTS (SELECT * FROM payment p WHERE s.student_id = p.studentId )";
            MySqlConnection myConnection = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand(query, myConnection);

            {
                try
                {
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(myCmd);
                    myAdapter.SelectCommand = myCmd;
                    DataTable dT = new DataTable();
                    myAdapter.Fill(dT);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dT;
                    newpaymentviewGrid.DataSource = bsource;
                    myAdapter.Update(dT);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            newpaymentviewGrid.Columns["academic_yearId"].Visible = false;
            newpaymentviewGrid.Columns["sectionId"].Visible = false;
            newpaymentviewGrid.Columns["grade_levelId"].Visible = false;
            newpaymentviewGrid.Columns["student_id"].Visible = false;
            newpaymentviewGrid.Columns["section_id"].Visible = false;
            newpaymentviewGrid.Columns["good_moral_certificate"].Visible = false;
            newpaymentviewGrid.Columns["nso_birth_certificate"].Visible = false;
            newpaymentviewGrid.Columns["report_card_form138"].Visible = false;
            newpaymentviewGrid.Columns["baptismal_certificate"].Visible = false;
            newpaymentviewGrid.Columns["clearance"].Visible = false;
            newpaymentviewGrid.Columns["year_level_id"].Visible = false;
            newpaymentviewGrid.Columns["max_grade"].Visible = false;
            newpaymentviewGrid.Columns["min_grade"].Visible = false;
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
            newpaymentviewGrid.Columns["section_limit"].Visible = false;
            newpaymentviewGrid.AllowUserToAddRows = false;



            newpaymentviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            newpaymentviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;


            newpaymentlistBox.Items.Add(String.Format("Fees", "Amount"));


        }

        private void newpaymentviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tuition, misc, athletic, lab, lib, registration, lname, fname, mi, section, yr_level;
            if (e.RowIndex >= 0)
            {
                newpaymentlistBox.Items.Clear();
                DataGridViewRow row = this.newpaymentviewGrid.Rows[e.RowIndex];

                lname = row.Cells["lastname"].Value.ToString();
                fname = row.Cells["firstname"].Value.ToString();
                mi = row.Cells["mi"].Value.ToString();
                section = row.Cells["section_name"].Value.ToString();
                yr_level = row.Cells["year_name"].Value.ToString();
                tuition = row.Cells["tuition_fee"].Value.ToString();
                misc = row.Cells["medical_dental"].Value.ToString();
                athletic = row.Cells["athletic"].Value.ToString();
                lab = row.Cells["laboratory"].Value.ToString();
                lib = row.Cells["library"].Value.ToString();
                registration = row.Cells["registration"].Value.ToString();
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 30}","", "St. Augustine Academeny"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 40}", "Name", "Year & Section"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 41}", lname+", "+fname+", "+mi+".",yr_level+" year - "+section));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 62}", "Fees", "Amount"));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 58}", "Tuition Fee", tuition));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 55}", "Medical/Dental Fee", misc));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 61}", "Atlethic Fee", athletic));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 58}", "Laboratory Fee", lab));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 61}", "Library Fee", lib));
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 58}", "Registration Fee", registration));
                newpaymentlistBox.Items.Add("________________________________________________");
                newpaymentlistBox.Items.Add(String.Format("{0,-20}{1, 55}", "Total balance:", 1000));

            }
        }
    }
}
