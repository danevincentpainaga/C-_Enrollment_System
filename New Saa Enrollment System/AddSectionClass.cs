using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class AddSectionClass: Connection
    {
        public void getSectionsDetails(string yearlevelId = null)
        {
            if (string.IsNullOrEmpty(yearlevelId))
            {
                sqlQuery(
                    "SELECT yl.year_name, st.section_id, st.section_name, st.adviser, st.yearlevelId, teacher_id, CONCAT(`t_lastname`,', ', `t_firstname`, ', ', `t_mi`,'.') as teachername " +
                    "FROM section_table st " +
                    "INNER JOIN teacher_table t ON st.adviser = t.teacher_id " +
                    "INNER JOIN year_level yl ON yl.year_level_id = st.yearlevelId"
                );
            }
            else
            {
                sqlQuery(
                    "SELECT yl.year_name, st.section_id, st.section_name, st.adviser, st.yearlevelId, teacher_id, CONCAT(`t_lastname`,', ', `t_firstname`, ', ', `t_mi`,'.') as teachername " +
                    "FROM section_table st " +
                    "INNER JOIN teacher_table t ON st.adviser = t.teacher_id " +
                    "INNER JOIN year_level yl ON yl.year_level_id = st.yearlevelId "+
                    "WHERE yearlevelId = @yearlevelId"
                );

                _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
                NonQueryExe();
            }
        }

        public void addSections(string section_name, string yearlevelId, string adviser)
        {
            sqlQuery(
                        "INSERT INTO section_table (section_name, yearlevelId, adviser) " +
                        "VALUES "+
                        "(@section_name, @yearlevelId, @adviser)"
                    );

            _cmd.Parameters.AddWithValue("@section_name", section_name);
            _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
            _cmd.Parameters.AddWithValue("@adviser", adviser);
            NonQueryExe();
            MessageBox.Show("Section Added!");
        }

        public void updateSection(string section_id, string section_name, string yearlevelId, string adviser)
        {
            sqlQuery(
                        "UPDATE section_table SET section_name = @section_name, yearlevelId = @yearlevelId, adviser = @adviser " +
                        "WHERE section_id = @section_id"
                    );

            _cmd.Parameters.AddWithValue("@section_id", section_id);
            _cmd.Parameters.AddWithValue("@section_name", section_name);
            _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
            _cmd.Parameters.AddWithValue("@adviser", adviser);
            NonQueryExe();
            MessageBox.Show("Section Details Updated!");
        }
    }
}
