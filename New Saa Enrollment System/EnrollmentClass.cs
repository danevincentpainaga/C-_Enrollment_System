using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace New_Saa_Enrollment_System
{
    class EnrollmentClass : Connection
    {
        public EnrollmentClass()
        {

        }

        public void displayStudentsRecords(string student_status = null)
        {
            if (string.IsNullOrEmpty(student_status))
            {
                sqlQuery(
                            "SELECT s.*, yl.year_name, st.section_name, ay.academic_year FROM student_table s " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId "
                        );

                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, yl.year_name, st.section_name, ay.academic_year FROM student_table s " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "WHERE student_status = @student_status"
                        );

                _cmd.Parameters.AddWithValue("@student_status", student_status);
                NonQueryExe();
            }
        }

        public void getSections()
        {
            sqlQuery(
                        "SELECT st.*, yl.year_name, yl.year_level_id FROM section_table st " +
                        "INNER JOIN year_level yl ON yl.year_level_id = st.yearlevelId"
                    );
            NonQueryExe();
        }

        public void displayAcademicYears()
        {
            sqlQuery(
                        "SELECT * FROM academic_years"
                    );
            NonQueryExe();
        }

        public void displayCurrentAcademicYear()
        {
            sqlQuery(
                        "SELECT ay.*, c.current_academic_yearId FROM academic_years ay " +
                        "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = ay.academic_id"
                    );

            NonQueryExe();
        }

        public void addAcademicYears(string academic_year, DateTime date)
        {
            sqlQuery(
                        "INSERT INTO academic_years (academic_year, enrollment_start_date) VALUES (@academic_year, @enrollment_start_date); " + "SELECT LAST_INSERT_ID()"
                    );

            _cmd.Parameters.AddWithValue("@academic_year", academic_year);
            _cmd.Parameters.AddWithValue("@enrollment_start_date", date);

            var returnValue = _cmd.ExecuteScalar();
            var identity = returnValue == null ? default(long) : long.Parse(returnValue.ToString());

            sqlQuery("UPDATE current_academic_sidnumber_table SET current_academic_yearId = @current_academic_yearId");
            _cmd.Parameters.AddWithValue("@current_academic_yearId", identity);
            NonQueryExe();

            sqlQuery("UPDATE current_academic_sidnumber_table SET current_academic_yearId = @current_academic_yearId");
            _cmd.Parameters.AddWithValue("@current_academic_yearId", identity);
            NonQueryExe();

            sqlQuery("UPDATE student_table SET report_card_form138 = 'no', clearance = 'no', student_status = 'pending' WHERE student_status = 'enrolled' AND grade_levelId != 4 AND academic_yearId != @academicId");
            _cmd.Parameters.AddWithValue("@academicId", identity);
            NonQueryExe();

            sqlQuery("UPDATE student_table SET student_status = 'graduate' WHERE student_status = 'enrolled' AND grade_levelId = 4 AND academic_yearId != @academicId");
            _cmd.Parameters.AddWithValue("@academicId", identity);
            NonQueryExe();

            sqlQuery("UPDATE student_table SET student_status = 'cancelled' WHERE student_status = 'registered' AND academic_yearId != @academicId");
            _cmd.Parameters.AddWithValue("@academicId", identity);
            NonQueryExe();

            MessageBox.Show("Enrollment Process Started!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateAcademicYears(string academic_year, string academic_id)
        {
            sqlQuery(
                        "UPDATE academic_years SET academic_year = @academic_year WHERE academic_id = @academic_id"
                    );

            _cmd.Parameters.AddWithValue("@academic_id", academic_id);
            _cmd.Parameters.AddWithValue("@academic_year", academic_year);

            int result = _cmd.ExecuteNonQuery();

            if (result < 0)
            {
                MessageBox.Show("Insert Failed");
            }
            else
            {
                MessageBox.Show("Academic year Successfully Updated!");
            }
        }

        public void updateFeesPerYear(Dictionary<string, string> fee)
        {
            sqlQuery(
                        "UPDATE year_level SET tuition_fee = @tuition_fee, athletic = @athletic, laboratory = @laboratory, "+
                        "library = @library, registration = @registration, medical_dental = @medical_dental, test_materials = @test_materials, " +
                        "general_support_services = @general_support_services, adce = @adce, insurance = @insurance, nassphil = @nassphil, " +
                        "student_council_fee = @student_council_fee, ceap = @ceap " +
                        "WHERE year_level_id = @year_level_id "
                    );

            _cmd.Parameters.AddWithValue("@year_level_id", fee["year_level_id"]);
            _cmd.Parameters.AddWithValue("@tuition_fee", fee["tuition_fee"]);
            _cmd.Parameters.AddWithValue("@athletic", fee["athletic"]);
            _cmd.Parameters.AddWithValue("@laboratory", fee["laboratory"]);
            _cmd.Parameters.AddWithValue("@library", fee["library"]);
            _cmd.Parameters.AddWithValue("@registration", fee["registration"]);
            _cmd.Parameters.AddWithValue("@medical_dental", fee["medical_dental"]);
            _cmd.Parameters.AddWithValue("@test_materials", fee["test_materials"]);
            _cmd.Parameters.AddWithValue("@general_support_services", fee["general_support_services"]);
            _cmd.Parameters.AddWithValue("@adce", fee["adce"]);
            _cmd.Parameters.AddWithValue("@insurance", fee["insurance"]);
            _cmd.Parameters.AddWithValue("@nassphil", fee["nassphil"]);
            _cmd.Parameters.AddWithValue("@student_council_fee", fee["student_council_fee"]);
            _cmd.Parameters.AddWithValue("@ceap", fee["ceap"]);

            NonQueryExe();
            MessageBox.Show("Fees Amount Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public int confirmAdminUsernamePassword(string adminUsername, string adminPassword)
        {
            sqlQuery("SELECT * FROM users WHERE username = @username AND password = @password AND user_typeId = '1' AND user_status = 'Activated'");
            _cmd.Parameters.AddWithValue("@username", adminUsername);
            _cmd.Parameters.AddWithValue("@password", adminPassword);

            if (QueryExe().Rows.Count == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void countStudentsBaseOnStatus()
        {
            sqlQuery(
                        "SELECT student_id, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'enrolled') as enrolled, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'pending') as pending, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'graduate') as graduate, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'cancelled') as cancelled, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'dropped') as dropped, " +
                        "( SELECT COUNT(student_status) FROM student_table WHERE student_status = 'registered') as registered " +
                        "FROM student_table"
                    );
            NonQueryExe();
        }
    }

}
