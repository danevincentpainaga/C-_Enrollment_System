using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class SubjectsClass : Connection
    {
        public SubjectsClass()
        {

        }

        public void getSubjects()
        {
            sqlQuery("SELECT * FROM subject_table");
            NonQueryExe();
        }

        public void addSubjects(string subject_name, string description)
        {
            sqlQuery(
                        "INSERT INTO subject_table (subject_name, description) " +
                        "VALUES (@subject_name, @description)"
                    );

            _cmd.Parameters.AddWithValue("@subject_name", subject_name);
            _cmd.Parameters.AddWithValue("@description", description);
            NonQueryExe();
            MessageBox.Show("Subject Added!");
        }

        public void updateSubjects(string subject_id, string subject_name, string description)
        {
            sqlQuery(
                        "UPDATE subject_table SET subject_name = @subject_name, description = @description " +
                        "WHERE subject_id = @subject_id"
                    );

            _cmd.Parameters.AddWithValue("@subject_id", subject_id);
            _cmd.Parameters.AddWithValue("@subject_name", subject_name);
            _cmd.Parameters.AddWithValue("@description", description);
            NonQueryExe();
            MessageBox.Show("Subject Details Updated!");
        }
    }
}
