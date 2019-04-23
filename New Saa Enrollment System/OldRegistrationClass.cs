using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class OldRegistrationClass : paymentClass
    {
        private OldstudentRegistration instance;
        private string clearanceValue = "no";
        private string goodMoral = "no";
        private string baptismal = "no";
        private string reportCard = "no";
        private string nso = "no";

        private StudentInformation studinfo;
        public OldRegistrationClass()
        {

        }

        public void displayNotEnrolledOldStudents(string lname = null, string fname = null)
        {
            if (String.IsNullOrEmpty(lname) && String.IsNullOrEmpty(fname))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, yl.year_level_id, yl.year_name, ay.academic_year, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId != s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'pending' AND s.grade_levelId != 4"
                        );
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, yl.year_level_id, yl.year_name, ay.academic_year, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId != s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'pending' AND s.grade_levelId != 4 AND lastname Like '%" + lname + "%' AND firstname Like '%" + fname + "%'"
                        );
            }
        }

        public void displayRegisteredStudents(string searched = null)
        {
            if (String.IsNullOrEmpty(searched))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'registered'"
                        );
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searched + "%' AND student_status = 'registered'"
                        );
            }
        }

        public void displayEnrolledStudents(string searched = null)
        {
            if (String.IsNullOrEmpty(searched))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'enrolled' "+
                            "ORDER BY s.lastname"
                        );
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, c.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN current_academic_sidnumber_table c ON c.current_academic_yearId = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searched + "%' AND student_status = 'enrolled'"
                        );
                NonQueryExe();
            }
        }


        public void displayGraduateStudents(string searched = null)
        {
            if (String.IsNullOrEmpty(searched))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'graduate' " +
                            "ORDER BY s.lastname"
                        );
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searched + "%' AND student_status = 'graduate'"
                        );
                NonQueryExe();
            }
        }

        public void displayDroppedStudents(string searched = null)
        {
            if (String.IsNullOrEmpty(searched))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'dropped' " +
                            "ORDER BY s.lastname"
                        );
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searched + "%' AND student_status = 'dropped'"
                        );
                NonQueryExe();
            }
        }

        public void validateCheckBox(CheckBox checkbox, string checkboxName)
        {
            switch (checkboxName)
            {
                case "updateclearancecheckBox":
                    clearanceValue = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "updategoodMoralcheckBox":
                    goodMoral = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "updateBaptismalcheckBox":
                    baptismal = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "updatereportCardcheckBox":
                    reportCard = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "updatensocheckBox":
                    nso = (checkbox.Checked) ? "yes" : "no";
                    break;
            }
        }

        public void updateStudentInfo(Dictionary<string, string> sd)
        {
           
            sqlQuery(
                        "UPDATE student_table SET lastname = @lastname, firstname = @firstname, mi = @mi, contact = @contact, gender = @gender, address = @address," +
                        "age = @age, birthdate = @birthdate, religion = @religion, citizenship = @citizenship, final_average = @final_average, sectionId = @sectionId " +
                        "WHERE student_id = @student_id "
                    );

            _cmd.Parameters.AddWithValue("@student_id", sd["student_id"]);
            _cmd.Parameters.AddWithValue("@lastname", sd["lastname"]);
            _cmd.Parameters.AddWithValue("@firstname", sd["firstname"]);
            _cmd.Parameters.AddWithValue("@mi", sd["mi"]);
            _cmd.Parameters.AddWithValue("@contact", sd["contact"]);
            _cmd.Parameters.AddWithValue("@gender", sd["gender"]);
            _cmd.Parameters.AddWithValue("@address", sd["address"]);
            _cmd.Parameters.AddWithValue("@age", sd["age"]);
            _cmd.Parameters.AddWithValue("@birthdate", sd["birthdate"]);
            _cmd.Parameters.AddWithValue("@religion", sd["religion"]);
            _cmd.Parameters.AddWithValue("@citizenship", sd["citizenship"]);
            _cmd.Parameters.AddWithValue("@final_average", sd["final_average"]);
            _cmd.Parameters.AddWithValue("@sectionId", sd["sectionId"]);
            NonQueryExe();

            MessageBox.Show("Student Details Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void updateStudentRequirements(string studentid)
        {

            sqlQuery(
                       "UPDATE student_table SET good_moral_certificate = @good_moral_certificate, nso_birth_certificate = @nso_birth_certificate, "+
                       "report_card_form138 = @report_card_form138, baptismal_certificate = @baptismal_certificate, clearance = @clearance "+
                       "WHERE student_id = @student_id"
                    );

            _cmd.Parameters.AddWithValue("@student_id", studentid);
            _cmd.Parameters.AddWithValue("@good_moral_certificate",goodMoral);
            _cmd.Parameters.AddWithValue("@nso_birth_certificate", nso);
            _cmd.Parameters.AddWithValue("@report_card_form138", reportCard);
            _cmd.Parameters.AddWithValue("@baptismal_certificate", baptismal);
            _cmd.Parameters.AddWithValue("@clearance", clearanceValue);
            NonQueryExe();
            MessageBox.Show("Requirements Updated");
        }

        public void registerOldstudent(string yearlevelId, string academic_id, string average, string studentid)
        {
            sqlQuery(
                       "UPDATE student_table SET academic_yearId = @academic_yearId, report_card_form138 = @report_card_form138, clearance = @clearance, " +
                       "grade_levelId = @grade_levelId, final_average = @final_average, student_status = @student_status " +
                       "WHERE student_id = @student_id AND student_status = 'pending'"
                    );

            _cmd.Parameters.AddWithValue("@student_id", studentid);
            _cmd.Parameters.AddWithValue("@report_card_form138", reportCard);
            _cmd.Parameters.AddWithValue("@clearance", clearanceValue);
            _cmd.Parameters.AddWithValue("@grade_levelId", yearlevelId);
            _cmd.Parameters.AddWithValue("@academic_yearId", academic_id);
            _cmd.Parameters.AddWithValue("@final_average", average);
            _cmd.Parameters.AddWithValue("@student_status", "registered");
            NonQueryExe();

            MessageBox.Show("Successfully Registered!","", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void setStudentDetailsObj(StudentInformation obj)
        {
            this.studinfo = obj;
        }
        public StudentInformation getStudentDetailsObj(){
            return this.studinfo;
        }

        public void getGraduateStudents(string searchLname = null, string searchFname = null)
        {
            if (String.IsNullOrEmpty(searchLname) && String.IsNullOrEmpty(searchFname))
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "fi.*, ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN family_information_table fi ON fi.fi_studentId = s.student_id " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN academic_years ay ON ay.academic_id = s.academic_yearId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE student_status = 'graduate' " +
                            "ORDER BY s.lastname"
                        );
            }
            else
            {
                sqlQuery(
                            "SELECT s.*, " +
                            "ay.academic_year, yl.year_level_id, yl.year_name, st.* " +//, ay.*, c.*" +
                            "FROM student_table s " +
                            "INNER JOIN academic_years ay ON ay.academic_id = p.p_academic_yearId " +
                            "LEFT JOIN section_table st ON st.section_id = s.sectionId " +
                            "INNER JOIN year_level yl ON yl.year_level_id = s.grade_levelId " +
                            "WHERE lastname Like '%" + searchLname + "%' AND firstname Like '%" + searchFname + "%' AND student_status = 'graduate'"
                        );
            }
        }

        public void updateEnrolledStudentStatusToDropped(string student_id, string student_status)
        {
            sqlQuery(
                        "UPDATE student_table SET student_status = @student_status "+
                        "WHERE student_id = @student_id"
                    );

            _cmd.Parameters.AddWithValue("@student_id", student_id);
            _cmd.Parameters.AddWithValue("@student_status", student_status);
            NonQueryExe();

            MessageBox.Show("Student Status Changed to "+ student_status);
        }

        public void updateFamilyInfo(Dictionary<string, string> sd)
        {

            sqlQuery(
                        "UPDATE family_information_table SET father_name = @father_name, fatherDOB = @fatherDOB, father_age = @father_age, father_education = @father_education, father_occupation = @father_occupation, " +
                        "father_contact = @father_contact, mother_name = @mother_name, motherDOB = @motherDOB, mother_age = @mother_age, mother_education = @mother_education, " +
                        "mother_occupation = @mother_occupation, mother_contact = @mother_contact, guardian_name = @guardian_name, relationship = @relationship, guardian_address = @guardian_address, " +
                        "guardian_contact = @guardian_contact " +
                        "WHERE fi_studentId = @fi_studentId "
                    );

            _cmd.Parameters.AddWithValue("@father_name", sd["father_name"]);
            _cmd.Parameters.AddWithValue("@fatherDOB", sd["fatherDOB"]);
            _cmd.Parameters.AddWithValue("@father_age", sd["father_age"]);
            _cmd.Parameters.AddWithValue("@father_education", sd["father_education"]);
            _cmd.Parameters.AddWithValue("@father_occupation", sd["father_occupation"]);
            _cmd.Parameters.AddWithValue("@father_contact", sd["father_contact"]);
            _cmd.Parameters.AddWithValue("@mother_name", sd["mother_name"]);
            _cmd.Parameters.AddWithValue("@motherDOB", sd["motherDOB"]);
            _cmd.Parameters.AddWithValue("@mother_age", sd["mother_age"]);
            _cmd.Parameters.AddWithValue("@mother_education", sd["mother_education"]);
            _cmd.Parameters.AddWithValue("@mother_occupation", sd["mother_occupation"]);
            _cmd.Parameters.AddWithValue("@mother_contact", sd["mother_contact"]);
            _cmd.Parameters.AddWithValue("@guardian_name", sd["guardian_name"]);
            _cmd.Parameters.AddWithValue("@relationship", sd["relationship"]);
            _cmd.Parameters.AddWithValue("@guardian_address", sd["guardian_address"]);
            _cmd.Parameters.AddWithValue("@guardian_contact", sd["guardian_contact"]);
            _cmd.Parameters.AddWithValue("@fi_studentId", sd["fi_studentId"]);
            NonQueryExe();

            MessageBox.Show("Student Details Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void getSections(string yearlevelId)
        {
            sqlQuery("SELECT * FROM section_table WHERE yearlevelId = @yearlevelId");
            _cmd.Parameters.AddWithValue("@yearlevelId", yearlevelId);
            NonQueryExe();
        }
    }
}
