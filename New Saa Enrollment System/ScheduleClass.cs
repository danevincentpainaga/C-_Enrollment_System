using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class ScheduleClass : Connection
    {
        public ScheduleClass()
        {

        }

        public void displaySchedule(string yearlevelId = null)
        {
            if(yearlevelId == null)
            {
                sqlQuery(
                            "SELECT yl.year_name, st.section_name, sb.*, sc.*, r.room_name, CONCAT(`t_lastname`,', ', `t_firstname`, ', ', `t_mi`,'.') as teacherName, ay.academic_year FROM schedule_table sc " +
                            "INNER JOIN year_level yl ON sc.year_levelId = yl.year_level_id " +
                            "INNER JOIN section_table st ON st.section_id = sc.section_ref_id " +
                            "INNER JOIN teacher_table t ON t.teacher_id = sc.teacherId " +
                            "INNER JOIN subject_table sb ON sb.subject_id = sc.subjectId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = sc.academicyear_id " +
                            "INNER JOIN rooms r ON r.room_id = sc.roomId "// +
                          //  "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = sc.academicyear_id "
                         );
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                         
                                 "SELECT yl.year_name, st.section_name, sb.*, sc.*, r.room_name, CONCAT(`t_lastname`,', ', `t_firstname`, ', ', `t_mi`,'.') as teacherName, ay.academic_year FROM schedule_table sc " +
                                 "INNER JOIN year_level yl ON sc.year_levelId = yl.year_level_id "+
                                 "INNER JOIN section_table st ON st.section_id = sc.section_ref_id " +
                                 "INNER JOIN teacher_table t ON t.teacher_id = sc.teacherId "+
                                 "INNER JOIN subject_table sb ON sb.subject_id = sc.subjectId "+
                                 "INNER JOIN academic_years ay ON ay.academic_id = sc.academicyear_id "+
                                 "INNER JOIN rooms r ON r.room_id = sc.roomId " +
                                 "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = sc.academicyear_id "+
                                 "WHERE sc.year_levelId = @year_levelId"
                         );
                _cmd.Parameters.AddWithValue("@year_levelId", yearlevelId);
                NonQueryExe();
            }
        }
        public void getAcademicYears()
        {
            sqlQuery("SELECT ay.* FROM academic_years ay INNER JOIN current_academic_sidnumber_table c ON ay.academic_id = c.current_academic_yearId");
            NonQueryExe();
        }

        public void getSections(string yearlevelId = null)
        {
            if (yearlevelId != null)
            {
                sqlQuery("SELECT * FROM section_table WHERE yearlevelId = @yearlevelId");
                _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
                NonQueryExe();
            }
            else
            {
                sqlQuery("SELECT * FROM section_table");
               // _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
                NonQueryExe();
            }
        }

        public void getRooms()
        {
            sqlQuery("SELECT * FROM rooms");
        }

        public void getSubjects()
        {
            sqlQuery("SELECT * FROM subject_table");
        }

        public void getTeachers()
        {
            sqlQuery("SELECT teacher_id, CONCAT(`t_lastname`,', ', `t_firstname`, ', ', `t_mi`,'.') as teachername FROM teacher_table");
        }

        public void addSchedulePerYear(string year_levelId, string section_ref_id, string subjectId, string teacherId, string time_start, string time_end, string roomId, string day, string academicyear_id)
        {
            sqlQuery(
                        "SELECT * FROM schedule_table WHERE year_levelId = @year_levelId AND section_ref_id = @section_ref_id AND subjectId = @subjectId"
                    );
            _cmd.Parameters.AddWithValue("@year_levelId", year_levelId);
            _cmd.Parameters.AddWithValue("@section_ref_id", section_ref_id);
            _cmd.Parameters.AddWithValue("@subjectId", subjectId);

            if (QueryExe().Rows.Count == 1)
            {
                MessageBox.Show("Subject Already Exist!");
            }
            else
            {
                sqlQuery(
                            "SELECT * FROM schedule_table WHERE time_start >= @time_start AND time_end <= @time_end AND day = 'Daily' AND roomId = @roomId"
                        );
                _cmd.Parameters.AddWithValue("@time_start", time_start);
                _cmd.Parameters.AddWithValue("@time_end", time_end);
                _cmd.Parameters.AddWithValue("@roomId", roomId);
                _cmd.Parameters.AddWithValue("@day", day);

                if (QueryExe().Rows.Count == 1)
                {
                    MessageBox.Show(" Time Schedule Already Taken!");
                }
                else
                {
                    sqlQuery(
                                "INSERT INTO schedule_table (year_levelId, section_ref_id, subjectId, teacherId, time_start, time_end, roomId, day, academicyear_id)" +
                                "VALUES" +
                                "(@year_levelId, @section_ref_id, @subjectId, @teacherId, @time_start, @time_end, @roomId, @day, @academicyear_id)"
                            );

                    _cmd.Parameters.AddWithValue("@year_levelId", year_levelId);
                    _cmd.Parameters.AddWithValue("@section_ref_id", section_ref_id);
                    _cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    _cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    _cmd.Parameters.AddWithValue("@time_start", time_start);
                    _cmd.Parameters.AddWithValue("@time_end", time_end);
                    _cmd.Parameters.AddWithValue("@roomId", roomId);
                    _cmd.Parameters.AddWithValue("@day", day);
                    _cmd.Parameters.AddWithValue("@academicyear_id", academicyear_id);
                    NonQueryExe();

                    MessageBox.Show("Schedule Added");
                }
            }
            
        }

        public void updateSchedulePerYear(string year_levelId, string section_ref_id, string subjectId, string teacherId, string time_start, string time_end, string roomId, string day, string academicyear_id, string schedule_id)
        {
            if(day == "Daily")
            {
                sqlQuery(
                            "SELECT * FROM schedule_table WHERE time_start >= @time_start AND time_end <= @time_end AND roomId = @roomId AND schedule_id != @schedule_id"
                        );
                _cmd.Parameters.AddWithValue("@time_start", time_start);
                _cmd.Parameters.AddWithValue("@time_end", time_end);
                _cmd.Parameters.AddWithValue("@roomId", roomId);
                _cmd.Parameters.AddWithValue("@schedule_id", schedule_id);

                if (QueryExe().Rows.Count == 1)
                {
                    MessageBox.Show("Schedule Already Exist!");
                }
                else
                {
                    sqlQuery(
                                "UPDATE schedule_table SET year_levelId = @year_levelId, section_ref_id = @section_ref_id, subjectId = @subjectId, " +
                                "teacherId = @teacherId, time_start = @time_start, time_end = @time_end, roomId = @roomId, day = @day, academicyear_id = @academicyear_id " +
                                "WHERE schedule_id = @schedule_id"
                            );

                    _cmd.Parameters.AddWithValue("@year_levelId", year_levelId);
                    _cmd.Parameters.AddWithValue("@section_ref_id", section_ref_id);
                    _cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    _cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    _cmd.Parameters.AddWithValue("@time_start", time_start);
                    _cmd.Parameters.AddWithValue("@time_end", time_end);
                    _cmd.Parameters.AddWithValue("@roomId", roomId);
                    _cmd.Parameters.AddWithValue("@day", day);
                    _cmd.Parameters.AddWithValue("@academicyear_id", academicyear_id);
                    _cmd.Parameters.AddWithValue("@schedule_id", schedule_id);
                    NonQueryExe();
                    MessageBox.Show("Schedule Updated");
                }
            }
            else
            {
                sqlQuery(
                            "SELECT * FROM schedule_table WHERE time_start >= @time_start AND time_end <= @time_end AND day = @day AND roomId = @roomId AND schedule_id != @schedule_id"
                        );
                _cmd.Parameters.AddWithValue("@time_start", time_start);
                _cmd.Parameters.AddWithValue("@time_end", time_end);
                _cmd.Parameters.AddWithValue("@roomId", roomId);
                _cmd.Parameters.AddWithValue("@day", day);
                _cmd.Parameters.AddWithValue("@schedule_id", schedule_id);

                if (QueryExe().Rows.Count == 1)
                {
                    MessageBox.Show(" Time Schedule Already Taken!");
                }
                else
                {
                    sqlQuery(
                                "UPDATE schedule_table SET year_levelId = @year_levelId, section_ref_id = @section_ref_id, subjectId = @subjectId, " +
                                "teacherId = @teacherId, time_start = @time_start, time_end = @time_end, roomId = @roomId, day = @day, academicyear_id = @academicyear_id " +
                                "WHERE schedule_id = @schedule_id"
                            );

                    _cmd.Parameters.AddWithValue("@year_levelId", year_levelId);
                    _cmd.Parameters.AddWithValue("@section_ref_id", section_ref_id);
                    _cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    _cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    _cmd.Parameters.AddWithValue("@time_start", time_start);
                    _cmd.Parameters.AddWithValue("@time_end", time_end);
                    _cmd.Parameters.AddWithValue("@roomId", roomId);
                    _cmd.Parameters.AddWithValue("@day", day);
                    _cmd.Parameters.AddWithValue("@academicyear_id", academicyear_id);
                    _cmd.Parameters.AddWithValue("@schedule_id", schedule_id);
                    NonQueryExe();

                    MessageBox.Show("Schedule Updated");
                }
            }
        }
    }
}
