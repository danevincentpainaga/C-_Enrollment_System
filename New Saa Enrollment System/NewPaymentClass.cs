using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class NewPaymentClass : paymentClass
    {
        public void displayRegisteredStudents(string studentName = null)
        {
            if (string.IsNullOrEmpty(studentName)) { 
                sqlQuery(
                            "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.academic_yearId, s.sectionId, s.grade_levelId, s.gender," +
                            "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, yl.*, ay.* " +// st.*
                            "FROM student_table s " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'registered' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes' " //+
                           // "AND NOT EXISTS (SELECT * FROM payment p WHERE s.student_id = p.studentId)"
                        );
            }
            else
            {
                sqlQuery(
                            "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.academic_yearId, s.sectionId, s.grade_levelId, s.gender," +
                            "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, yl.*, ay.* " +// st.*
                            "FROM student_table s " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'registered' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes' " +
                            "AND Concat(`lastname`, `firstname`, `mi`) LIKE '%" + studentName + "%'"//+                                                                                                                                                                                                 // "AND NOT EXISTS (SELECT * FROM payment p WHERE s.student_id = p.studentId)"
                        );
            }
            /*
            sqlQuery(
                        "SELECT s.student_id, s.student_no, s.lastname, s.firstname, s.mi, s.academic_yearId, s.sectionId, s.grade_levelId, s.gender," +
                        "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, yl.*, ay.* " +// st.*
                        "FROM student_table s " +
                        "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                        "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                        "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                        "WHERE student_status = 'pending' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes' " +
                        "AND NOT EXISTS (SELECT * FROM payment p WHERE s.student_id = p.studentId)"
                    );
                    */
        }

        public void insertPaymentDetails(string studentId, string reciept_number, string tuition, string total, string cash, string balance, string userid, string academic_id, string academic_year, DateTime paymentdate)
        {
                sqlQuery(
                            "INSERT INTO student_total_balance (bal_studentId, bal_balance, date_updated, academicyearid) " +
                            "VALUES(@bal_studentId, @bal_balance, @date_updated, @academicyearid)"
                        );

                _cmd.Parameters.AddWithValue("@bal_studentId", studentId);
                _cmd.Parameters.AddWithValue("@bal_balance", balance);
                _cmd.Parameters.AddWithValue("@date_updated", paymentdate);
                _cmd.Parameters.AddWithValue("@academicyearid", academic_id);
                NonQueryExe();

                int ornum = Convert.ToInt32(reciept_number) + 1;
                sqlQuery(
                        "INSERT INTO payment (studentId, reciept_number, total, cash, balance, tuition, userId, p_academic_yearId, school_year, payment_date) " +
                        "VALUES(@studentId, @reciept_number, @total, @cash, @balance, @tuition, @userId, @p_academic_yearId, @school_year, @payment_date)"
                        );

                _cmd.Parameters.AddWithValue("@studentId", studentId);
                _cmd.Parameters.AddWithValue("@reciept_number", ornum.ToString());
                _cmd.Parameters.AddWithValue("@total", total);
                _cmd.Parameters.AddWithValue("@cash", cash);
                _cmd.Parameters.AddWithValue("@balance", balance);
                _cmd.Parameters.AddWithValue("@tuition", tuition);
                _cmd.Parameters.AddWithValue("@userId", userid);
                _cmd.Parameters.AddWithValue("@p_academic_yearId", academic_id);
                _cmd.Parameters.AddWithValue("@school_year", academic_year);
                _cmd.Parameters.AddWithValue("@payment_date", paymentdate);
                int result = _cmd.ExecuteNonQuery();

                if (result < 0)
                {
                    MessageBox.Show("Insert Failed");
                }
                else
                {
                    sqlQuery("UPDATE student_table SET student_status = 'enrolled' WHERE student_id = @student_id");
                    _cmd.Parameters.AddWithValue("@student_id", studentId);
                    NonQueryExe();
                    sqlQuery("UPDATE official_reciept SET setted_reciept_number = @ornum");
                    _cmd.Parameters.AddWithValue("@ornum", ornum);
                    NonQueryExe();
                    MessageBox.Show("Payment Successful!");
                }
        }
    }
}
