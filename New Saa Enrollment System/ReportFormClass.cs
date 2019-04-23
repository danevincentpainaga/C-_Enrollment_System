using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Saa_Enrollment_System
{
    class ReportFormClass : OldRegistrationClass
    {
        public void getReturnpayments()
        {
            sqlQuery("SELECT * FROM return_table");
            NonQueryExe();
        }

        public void getAllPayments()
        {
            sqlQuery(
                        "SELECT p.userId, p.reciept_number, p.total, p.cash, p.balance, p.school_year, p.payment_date, ay.*, u.* FROM payment p " +
                        "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                        "INNER JOIN users u ON u.user_id = p.userId"
                    );
            NonQueryExe();
        }
    }
}
