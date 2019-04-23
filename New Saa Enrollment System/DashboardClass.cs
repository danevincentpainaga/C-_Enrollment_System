using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Saa_Enrollment_System
{
    class DashboardClass : Connection
    {
        public DashboardClass()
        {
            sqlQuery(
                        "SELECT student_id, " +
                        "( SELECT COUNT(grade_levelId) FROM student_table WHERE grade_levelId = '1') as firstyear, " +
                        "( SELECT COUNT(grade_levelId) FROM student_table WHERE grade_levelId = '2') as secondyear, " +
                        "( SELECT COUNT(grade_levelId) FROM student_table WHERE grade_levelId = '3') as thirdyear, " +
                        "( SELECT COUNT(grade_levelId) FROM student_table WHERE grade_levelId = '4') as fourthyear " +
                        "FROM student_table"
                    );
            NonQueryExe();
        }
    }
}
