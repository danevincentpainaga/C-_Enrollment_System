using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class sectioningClass : Connection
    {
        public sectioningClass()
        {

        }

        public void getSectionsByYear(string yearlevelId)
        {
            sqlQuery("SELECT * FROM section_table WHERE yearlevelId = @yearlevelId");
            _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
        }

        public void getAllEnrolledStudents(string yearlevelId, string searched = null)
        {
            if (string.IsNullOrEmpty(searched))
            {
                sqlQuery(
                            "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.grade_levelId, yl.year_name, ay.academic_id, ay.academic_year " +
                            "FROM student_table s " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'enrolled' AND sectionId IS NULL AND grade_levelId = @yearlevelId " +
                            "ORDER BY final_average"
                        );

                _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.grade_levelId, yl.year_name, ay.academic_id, ay.academic_year " +
                            "FROM student_table s " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname LIKE '%" + searched + "%'  AND student_status = 'enrolled' AND sectionId IS NULL AND grade_levelId = @yearlevelId"
                        );

                _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
                NonQueryExe();
            }
        }

        public void getStudentsPerYear(string yearlevelId, string sectionId)
        {
            sqlQuery(
                        "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.final_average, st.section_name, yl.year_name, ay.academic_year " +
                        "FROM student_table s " +
                        "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                        "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                        "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                        "INNER JOIN section_table st ON st.section_id = s.sectionId " +
                        "WHERE student_status = 'enrolled' AND sectionId = @sectionId AND grade_levelId = @yearlevelId " +
                        "ORDER BY final_average"
                    );
            _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
            _cmd.Parameters.AddWithValue("@sectionId", sectionId);
            NonQueryExe();
        }

        public void createSectioning(DataGridView datagridview, string sectionId, string sectionName)
        {
            foreach (DataGridViewRow row in datagridview.Rows)
            {
                sqlQuery(
                            "INSERT INTO student_records_table "+
                            "(record_studentId, record_academicYearId, record_sectionId, record_yearlevelId, "+
                            "record_schoolYearName, record_yearlevelName, record_sectionName) VALUES " +
                            "(@record_studentId, @record_academicYearId, @record_sectionId, @record_yearlevelId, " +
                            "@record_schoolYearName, @record_yearlevelName, @record_sectionName)"
                        );

                _cmd.Parameters.AddWithValue("@record_studentId", row.Cells[0].Value.ToString());
                _cmd.Parameters.AddWithValue("@record_yearlevelId", row.Cells[4].Value.ToString());
                _cmd.Parameters.AddWithValue("@record_yearlevelName", row.Cells[5].Value.ToString());
                _cmd.Parameters.AddWithValue("@record_academicYearId", row.Cells[6].Value.ToString());
                _cmd.Parameters.AddWithValue("@record_schoolYearName", row.Cells[7].Value.ToString());
                _cmd.Parameters.AddWithValue("@record_sectionId", sectionId);
                _cmd.Parameters.AddWithValue("@record_sectionName", sectionName);
                NonQueryExe();

                // Update student_table Student Sections //
                sqlQuery(
                            "UPDATE student_table SET sectionId = @sectionId WHERE student_id = @student_id"
                        );

                _cmd.Parameters.AddWithValue("@student_id", row.Cells[0].Value.ToString());
                _cmd.Parameters.AddWithValue("@sectionId", sectionId);
                NonQueryExe();
            }

            MessageBox.Show("Successfully Added to Section " + sectionName);
        }


    }
}
