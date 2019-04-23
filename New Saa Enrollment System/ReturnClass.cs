using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Saa_Enrollment_System
{
    class ReturnClass : Connection
    {
        public ReturnClass()
        {
            
        }

        public void getStudentPayments(string student_id)
        {
            sqlQuery(
                        "SELECT s.firstname, s.lastname, s.mi, p.* FROM student_table s "+
                        "INNER JOIN payment p ON p.studentId = s.student_id "+
                        "WHERE studentId = @student_id"
                    );

            _cmd.Parameters.AddWithValue("@student_id", student_id);
            NonQueryExe();
        }

        public void getOrNumDetails(string ornum = null, string student_id = null)
        {
            if (String.IsNullOrEmpty(ornum) || String.IsNullOrEmpty(student_id)) {
                sqlQuery(
                            "SELECT s.firstname, s.lastname, s.mi, p.* FROM student_table s " +
                            "INNER JOIN payment p ON p.studentId = s.student_id " +
                            "WHERE studentId = @student_id"
                        );
            }
            else
            {
                sqlQuery("SELECT * FROM payment WHERE reciept_number = @reciept_number AND studentId = @student_id");
            }

            _cmd.Parameters.AddWithValue("@reciept_number", ornum);
            _cmd.Parameters.AddWithValue("@student_id", student_id);
        }

        public void updatepaymentCashBalance(string ornum,  string cash, string balance, string updatedcash, string updatedbalance, string memo, DateTime dateupdated, string student_id, string userid)
        {
            sqlQuery("UPDATE payment SET cash = @updatedcash, balance = @updatedbalance WHERE reciept_number = @reciept_number AND studentId = @student_id");

            _cmd.Parameters.AddWithValue("@reciept_number", ornum);
            _cmd.Parameters.AddWithValue("@updatedcash", updatedcash);
            _cmd.Parameters.AddWithValue("@updatedbalance", updatedbalance);
            _cmd.Parameters.AddWithValue("@student_id", student_id);

            NonQueryExe();
            
            sqlQuery(
                        "INSERT INTO return_table (r_reciept_number, r_cash, r_balance, updated_cash, updated_balance, memo, date_updated, r_student_id, r_userId)" +
                        "VALUES"+
                        "(@r_reciept_number, @r_cash, @r_balance, @updated_cash, @updated_balance, @memo, @dateupdated, @student_id, @userid)"
                    );

            _cmd.Parameters.AddWithValue("@r_reciept_number", ornum);
            _cmd.Parameters.AddWithValue("@r_cash", cash);
            _cmd.Parameters.AddWithValue("@r_balance", balance);
            _cmd.Parameters.AddWithValue("@updated_cash", updatedcash);
            _cmd.Parameters.AddWithValue("@updated_balance", updatedbalance);
            _cmd.Parameters.AddWithValue("@memo", memo);
            _cmd.Parameters.AddWithValue("@dateupdated", dateupdated);
            _cmd.Parameters.AddWithValue("@student_id", student_id);
            _cmd.Parameters.AddWithValue("@userid", userid);
            NonQueryExe();
        }
    }
}
