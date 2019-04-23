using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class paymentClass : Connection
    {
        private string studentId = null;
        public paymentClass()
        {

        }

        public void setStudentId(string studId)
        {
            this.studentId = studId;
        }
        public string getStudentId()
        {
            return this.studentId;
        }

        public void displayPaidStudents(string searchLname = null, string searchFname = null)
        {
            if (String.IsNullOrEmpty(searchLname) &&  String.IsNullOrEmpty(searchFname))
            {
                sqlQuery(
                            "SELECT s.student_no, s.lastname, s.firstname, s.mi, s.address, s.academic_yearId, s.sectionId, s.grade_levelId, s.student_id, s.gender, " +
                            "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, p.*, yl.year_level_id, yl.year_name, ay.academic_year, s.student_status " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN payment p ON p.studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                           // "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'enrolled' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes'"+
                            "GROUP BY p.studentId"
                        );
            }
            else
            {
                sqlQuery(
                            "SELECT s.student_no, s.lastname, s.firstname, s.mi, s.address, s.academic_yearId, s.sectionId, s.grade_levelId, s.student_id, s.gender," +
                             "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, p.*, yl.year_level_id, yl.year_name, ay.academic_year, s.student_status " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN payment p ON p.studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                            // "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searchLname + "%' AND firstname Like '%" + searchFname + "%' AND student_status = 'enrolled' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes'" +
                            "GROUP BY p.studentId"
                        );
            }
        }

        public void displayNotEnrolledStudents(string searchLname = null, string searchFname = null)
        {
            if (String.IsNullOrEmpty(searchLname) && String.IsNullOrEmpty(searchFname))
            {
                sqlQuery(
                    "SELECT s.student_no, s.lastname, s.firstname, s.mi, s.address, s.academic_yearId, s.sectionId, s.grade_levelId, s.student_id, s.gender," +
                    "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, p.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, ay.academic_year, s.student_status " +//, ay.*, c.*" +
                    "FROM student_table s " +
                    "INNER JOIN payment p ON p.studentId = s.student_id " +
                    "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                    "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId != s.academic_yearId " +
                    "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                    "WHERE student_status = 'pending' " +
                    "GROUP BY p.studentId"
                );
            }
            else
            {
                sqlQuery(
                            "SELECT s.lastname, s.firstname, s.mi, s.address, s.academic_yearId, s.sectionId, s.grade_levelId, s.student_id, s.gender," +
                            "s.good_moral_certificate, s.nso_birth_certificate, s.report_card_form138, s.baptismal_certificate, s.clearance, p.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, ay.academic_year, s.student_status " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN payment p ON p.studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId != s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searchLname + "%' AND firstname Like '%" + searchFname + "%' AND student_status = 'pending' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes'" +
                            "GROUP BY p.studentId"
                        );
            }
        }

        public void displaySeletedStudentReport(string studentid, string status)
        {

            sqlQuery(
                       "SELECT s.*, p.*, yl.*, ay.* "+
                       "FROM student_table s " +
                       "INNER JOIN payment p ON p.studentId = s.student_id " +
                       "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                      // "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                       "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                       "WHERE s.student_id = @student_id AND student_status = @student_status " +
                       "GROUP BY p.studentId"
                    );
            _cmd.Parameters.AddWithValue("@student_id", studentid);
            _cmd.Parameters.AddWithValue("@student_status", status);
        }

        public void getTotalBalanceCash()
        {
            /*
            sqlQuery(
                       "SELECT s.*, p.*, SUM(p.cash) as totalcash, SUM(yl.tuition_fee + yl.athletic + yl.laboratory + yl.library + yl.registration  + yl.medical_dental + yl.test_materials + yl.general_support_services + yl.adce + yl.insurance + yl.nassphil + yl.student_council_fee + yl.ceap ) as totalfee, yl.*, ay.* " +
                       "FROM student_table s " +
                       "INNER JOIN payment p ON p.studentId = s.student_id " +
                       "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                       "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                       "WHERE s.student_id = " + studentId + " AND student_status = 'enrolled' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes'" +
                       "LIMIT 1"
                    );
                    */
            sqlQuery(
                       "SELECT s.*, p.*, SUM(p.cash) as totalcash, SUM(yl.tuition_fee + yl.athletic + yl.laboratory + yl.library + yl.registration  + yl.medical_dental + yl.test_materials + yl.general_support_services + yl.adce + yl.insurance + yl.nassphil + yl.student_council_fee + yl.ceap ) as totalfee, yl.*, ay.*, stb.bal_balance " +
                       "FROM student_table s " +
                       "INNER JOIN payment p ON p.studentId = s.student_id " +
                       "INNER JOIN student_total_balance stb ON stb.bal_studentId = s.student_id " +
                       "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                       "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                       "WHERE s.student_id = " + studentId + " AND student_status = 'enrolled' AND good_moral_certificate = 'yes' AND nso_birth_certificate = 'yes' AND report_card_form138 = 'yes' AND baptismal_certificate = 'yes' AND clearance = 'yes'" +
                       "LIMIT 1"
                    );
        }

        public void getOldNotEnrolledTotalBalanceCash()
        {
            sqlQuery(
                       "SELECT s.*, p.*, SUM(p.cash) as totalcash, yl.*, ay.* " +
                       "FROM student_table s " +
                       "INNER JOIN payment p ON p.studentId = s.student_id " +
                       "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                       "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                       "WHERE s.student_id = " + studentId + " " +
                       "LIMIT 1"
                    );
        }

        public void getYearLevel()
        {
            sqlQuery("SELECT * FROM year_level");
        }
        public void getCurrentIdAndScholYear()
        {
            sqlQuery("SELECT c.*, ay.* FROM current_academic_sidnumber_table c INNER JOIN academic_years ay ON c.current_academic_yearId = ay.academic_id");
        }

        public void getCurrentOrnum()
        {
            sqlQuery("SELECT setted_reciept_number FROM official_reciept");
        }

        public void getStudentBalancePerAcademicYear()
        {
            /*
            sqlQuery(
                    "SELECT stb.*, s.lastname, s.firstname, s.mi, SUM(p.cash) as totalcash, p.total, yl.year_name, ay.academic_year FROM student_total_balance stb " +
                    "INNER JOIN payment p ON p.studentId = stb.bal_studentId " +
                    "INNER JOIN student_table s ON s.student_id = stb.bal_studentId " +
                    "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                    "INNER JOIN academic_years ay ON ay.academic_id = stb.academicyearid " +
                    "WHERE bal_studentId = @bal_studentId AND p_academic_yearId = stb.academicyearid"
                );*/
                    /*
            sqlQuery(
                        "SELECT stb.*, s.lastname, s.firstname, s.mi, p.total, yl.year_name, ay.academic_year FROM student_total_balance stb " +
                        "INNER JOIN payment p ON p.studentId = stb.bal_studentId " +
                        "INNER JOIN student_table s ON s.student_id = stb.bal_studentId " +
                        "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                        "INNER JOIN academic_years ay ON ay.academic_id = stb.academicyearid " +
                        "WHERE bal_studentId = @bal_studentId AND p_academic_yearId = stb.academicyearid"
                    );*/


            sqlQuery(
                        "SELECT stb.*, s.lastname, s.firstname, s.mi, ay.* FROM student_total_balance stb " +
                        "INNER JOIN student_table s ON s.student_id = stb.bal_studentId " +
                        "INNER JOIN academic_years ay ON ay.academic_id = stb.academicyearid " +
                        "WHERE bal_studentId = @bal_studentId"
                    );

            _cmd.Parameters.AddWithValue("@bal_studentId", studentId);
            NonQueryExe();
        }


        public void savePaymentAndNewBalanceDetails(string studentId, string reciept_number, string tuition, string total, string cash, string balance, string userid, string academic_id, string academic_year, DateTime paymentdate, string balance_id)
        {
            sqlQuery(
                        "UPDATE student_total_balance SET bal_balance = @bal_balance, date_updated = @date_updated " +
                        "WHERE balance_id = @balance_id"
                    );
            
            _cmd.Parameters.AddWithValue("@bal_balance", balance);
            _cmd.Parameters.AddWithValue("@date_updated", paymentdate);
            _cmd.Parameters.AddWithValue("@balance_id", balance_id);
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
                sqlQuery("UPDATE official_reciept SET setted_reciept_number = @ornum");
                _cmd.Parameters.AddWithValue("@ornum", ornum.ToString());
                NonQueryExe();
                MessageBox.Show("Payment Successful!");
            }
        }

        public void getTotalAndCashInPayment(string studentid, string academicid)
        {
            sqlQuery("SELECT *, SUM(cash) as totalcash FROM payment WHERE p_academic_yearId = @p_academic_yearId AND studentId = @studentId");
            _cmd.Parameters.AddWithValue("@studentid", studentid);
            _cmd.Parameters.AddWithValue("@p_academic_yearId", academicid);
            NonQueryExe();
        }



        /*
        public string getCurrentStudentNumber()
        {
           string currentStudNumber = null;
           sqlQuery("SELECT current_school_id FROM current_academic_sidnumber_table");
           while (readerExe().Read())
           {
              currentStudNumber = readerExe().GetValue(0).ToString();
           }
           return currentStudNumber;
        }
        */
    }
}
