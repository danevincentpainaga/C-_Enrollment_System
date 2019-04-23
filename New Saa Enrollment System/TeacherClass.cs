using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Saa_Enrollment_System
{
    class TeacherClass : Connection
    {
        public TeacherClass()
        {

        }

        public void getTeachers(string searched = null)
        {
            if (string.IsNullOrEmpty(searched))
            {
                sqlQuery("SELECT * FROM teacher_table");
                NonQueryExe();
            }
            else
            {
                sqlQuery("SELECT * FROM teacher_table WHERE t_lastname LIKE '%" +searched+ "%'");
                NonQueryExe();
            }
        }

        public void getTeachersSchedule(string teacher_id)
        {
            sqlQuery(
                        "SELECT t.*, st.*, r.*, yl.* " +
                        "FROM teacher_table t " +
                        "INNER JOIN schedule_table st ON st.teacherId = t.teacher_id " +
                        "INNER JOIN rooms r ON r.room_id = st.roomId " +
                        "INNER JOIN year_level yl ON yl.year_level_id = st.year_levelId " +
                        "WHERE teacher_id = @teacher_id GROUP BY teacher_id"
                    );
            _cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
            NonQueryExe();
        }

        public void addTeacher(string t_lastname, string t_firstname, string t_mi, string t_contact, string t_gender, string t_birthdate, string t_age, string t_address)
        {
            sqlQuery(
                        "INSERT INTO teacher_table (t_lastname, t_firstname, t_mi, t_contact, t_gender, t_birthdate, t_age, t_address) "+
                        "VALUES (@t_lastname, @t_firstname, @t_mi, @t_contact, @t_gender, @t_birthdate, @t_age, @t_address)"
                    );
            _cmd.Parameters.AddWithValue("@t_lastname", t_lastname);
            _cmd.Parameters.AddWithValue("@t_firstname", t_firstname);
            _cmd.Parameters.AddWithValue("@t_mi", t_mi);
            _cmd.Parameters.AddWithValue("@t_contact", t_contact);
            _cmd.Parameters.AddWithValue("@t_gender", t_gender);
            _cmd.Parameters.AddWithValue("@t_birthdate", t_birthdate);
            _cmd.Parameters.AddWithValue("@t_age", t_age);
            _cmd.Parameters.AddWithValue("@t_address", t_address);
            NonQueryExe();
        }

        public void updateTeacher(string t_lastname, string t_firstname, string t_mi, string t_contact, string t_gender, string t_birthdate, string t_age, string t_address, string teacher_id)
        {
            sqlQuery(
                        "UPDATE teacher_table SET t_lastname = @t_lastname, t_firstname = @t_firstname, t_mi = @t_mi, " +
                        "t_contact = @t_contact, t_gender = @t_gender, t_birthdate = @t_birthdate, t_age = @t_age, t_address = @t_address "+
                        "WHERE teacher_id = @teacher_id"
                    );
            _cmd.Parameters.AddWithValue("@t_lastname", t_lastname);
            _cmd.Parameters.AddWithValue("@t_firstname", t_firstname);
            _cmd.Parameters.AddWithValue("@t_mi", t_mi);
            _cmd.Parameters.AddWithValue("@t_contact", t_contact);
            _cmd.Parameters.AddWithValue("@t_gender", t_gender);
            _cmd.Parameters.AddWithValue("@t_birthdate", t_birthdate);
            _cmd.Parameters.AddWithValue("@t_age", t_age);
            _cmd.Parameters.AddWithValue("@t_address", t_address);
            _cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
            NonQueryExe();
        }
    }
}
