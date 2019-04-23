using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    class StudentRegistrationClass : paymentClass
    {
        private string clearanceValue = "no";
        private string goodMoral = "no";
        private string baptismal = "no";
        private string reportCard = "no";
        private string nso = "no";

        public StudentRegistrationClass()
        {

        }

        public void validateCheckBox(CheckBox checkbox, string checkboxName)
        {
            switch (checkboxName)
            {
                case "clearancecheckBox":
                    clearanceValue = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "goodMoralcheckBox":
                    goodMoral = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "BaptismalcheckBox":
                    baptismal = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "reportCardcheckBox":
                    reportCard = (checkbox.Checked) ? "yes" : "no";
                    break;
                case "nsocheckBox":
                    nso = (checkbox.Checked) ? "yes" : "no";
                    break;
            }
        }


        public void registerStudentInfo(StudentInformation s)
        {
            long insertedStudentId;
            sqlQuery(
                       "INSERT INTO student_table (student_no, lastname, firstname, mi, contact, final_average, gender, address, birthdate, age, religion, " +
                       "citizenship, academic_yearId, grade_levelId, good_moral_certificate, nso_birth_certificate, report_card_form138, baptismal_certificate, clearance, student_status)" +
                       "VALUES (@student_no, @lastname, @firstname, @mi, @contact, @final_average, @gender, @address, @birthdate, @age, @religion, " +
                       "@citizenship, @academic_yearId, @grade_levelId, @good_moral_certificate, @nso_birth_certificate, @report_card_form138, @baptismal_certificate, @clearance, @student_status); "+ "SELECT LAST_INSERT_ID()"
                    );

            _cmd.Parameters.AddWithValue("@student_no", s.student_num);
            _cmd.Parameters.AddWithValue("@lastname", s.lname);
            _cmd.Parameters.AddWithValue("@firstname", s.fname);
            _cmd.Parameters.AddWithValue("@mi", s.mi);
            _cmd.Parameters.AddWithValue("@gender", s.gender);
            _cmd.Parameters.AddWithValue("@address", s.studAddress);
            _cmd.Parameters.AddWithValue("@birthdate", s.bdate);
            _cmd.Parameters.AddWithValue("@age", s.age);
            _cmd.Parameters.AddWithValue("@religion", s.rel);
            _cmd.Parameters.AddWithValue("@citizenship", s.citizen);
            _cmd.Parameters.AddWithValue("@contact", s.studContact);
            _cmd.Parameters.AddWithValue("@final_average", s.generalAverage);
            _cmd.Parameters.AddWithValue("@academic_yearId", s.academicyear);
            _cmd.Parameters.AddWithValue("@grade_levelId", s.yearlevel);
            _cmd.Parameters.AddWithValue("@good_moral_certificate", goodMoral);
            _cmd.Parameters.AddWithValue("@nso_birth_certificate", nso);
            _cmd.Parameters.AddWithValue("@report_card_form138", reportCard);
            _cmd.Parameters.AddWithValue("@baptismal_certificate", baptismal);
            _cmd.Parameters.AddWithValue("@clearance", clearanceValue);
            _cmd.Parameters.AddWithValue("@student_status", "registered");

            var returnValue = _cmd.ExecuteScalar();
            var identity = returnValue == null ? default(long) : long.Parse(returnValue.ToString());

            sqlQuery(
                    "INSERT INTO family_information_table (father_name, fatherDOB, father_age, father_education, father_occupation, "+
                    "father_contact, mother_name, motherDOB, mother_age, mother_education, mother_occupation, mother_contact, "+
                    "guardian_name, relationship, guardian_address, guardian_contact, fi_studentId)" +
                    "VALUES (@father_name, @fatherDOB, @father_age, @father_education, @father_occupation, " +
                    "@father_contact, @mother_name, @motherDOB, @mother_age, @mother_education, @mother_occupation, @mother_contact, " +
                    "@guardian_name, @relationship, @guardian_address, @guardian_contact, @fi_studentId)"
                    );

            _cmd.Parameters.AddWithValue("@father_name", s.father_name);
            _cmd.Parameters.AddWithValue("@fatherDOB", s.fatherDOB);
            _cmd.Parameters.AddWithValue("@father_age", s.father_age);
            _cmd.Parameters.AddWithValue("@father_education", s.fatherEducation);
            _cmd.Parameters.AddWithValue("@father_occupation", s.fatherOccupation);
            _cmd.Parameters.AddWithValue("@father_contact", s.fatherContact);
            _cmd.Parameters.AddWithValue("@mother_name", s.motherName);
            _cmd.Parameters.AddWithValue("@motherDOB", s.motherDOB);
            _cmd.Parameters.AddWithValue("@mother_age", s.mother_age);
            _cmd.Parameters.AddWithValue("@mother_education", s.motherOccupation);
            _cmd.Parameters.AddWithValue("@mother_occupation", s.generalAverage);
            _cmd.Parameters.AddWithValue("@mother_contact", s.motherCOntact);
            _cmd.Parameters.AddWithValue("@guardian_name", s.guardianName);
            _cmd.Parameters.AddWithValue("@relationship", s.guardianRelationship);
            _cmd.Parameters.AddWithValue("@guardian_address", s.guardianAddress);
            _cmd.Parameters.AddWithValue("@guardian_contact", s.guardianContact);
            _cmd.Parameters.AddWithValue("@fi_studentId", identity);
            NonQueryExe();

            sqlQuery("UPDATE current_academic_sidnumber_table SET current_school_id=@student_no");
            _cmd.Parameters.AddWithValue("@student_no", s.student_num);
            NonQueryExe();
            MessageBox.Show("Data Inserted!");
        }
    }

    public class StudentInformation
    {
        public StudentInformation()
        {
            
        }

        public void Reset()
        {
            this.student_id = String.Empty;
            this.fname = String.Empty;
            this.lname = String.Empty;
            this.mi = String.Empty;
            this.student_num = String.Empty;
            this.academicyear = String.Empty;
            this.sectionId = String.Empty;
            this.sectionName = String.Empty;
            this.yearlevel = String.Empty;
            this.yearlevelId = String.Empty;
            this.studContact = String.Empty;
            this.gender = String.Empty;
            this.bdate = String.Empty;
            this.age = String.Empty;
            this.studAddress = String.Empty;
            this.religion = String.Empty;
            this.citizen = String.Empty;
            this.generalAverage = String.Empty;
            this.fatherDOB = String.Empty;
            this.father_age = String.Empty;
            this.rel = String.Empty;
            this.fatherOccupation = String.Empty;
            this.fatherContact = String.Empty;
            this.fatherOccupation = String.Empty;
            this.fatherEducation = String.Empty;
            this.motherOccupation = String.Empty;
            this.motherCOntact = String.Empty;
            this.motherEducation = String.Empty;
            this.motherName = String.Empty;
            this.motherDOB = String.Empty;
            this.mother_age = String.Empty;
            this.guardianName = String.Empty;
            this.guardianRelationship = String.Empty;
            this.guardianContact = String.Empty;
            this.guardianAddress = String.Empty;
            this.goodmoralCertificate = String.Empty;
            this.nsoCertificate = String.Empty;
            this.reportcard = String.Empty;
            this.baptismalCertificate = String.Empty;
            this.clearanceCertificate = String.Empty;
            this.student_status = String.Empty;

        }

        public string student_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mi { get; set; }
        public string student_num { get; set; }
        public string academicyear { get; set; }
        public string sectionId { get; set; }
        public string sectionName { get; set; }
        public string yearlevel { get; set; }
        public string yearlevelId { get; set; }
        public string studContact { get; set; }
        public string gender { get; set; }
        public string bdate { get; set; }
        public string age { get; set; }
        public string studAddress { get; set; }
        public string religion { get; set; }
        public string citizen { get; set; }
        public string generalAverage { get; set; }
        public string father_name { get; set; }
        public string fatherDOB { get; set; }
        public string father_age { get; set; }
        public string rel { get; set; }
        public string fatherOccupation { get; set; }
        public string fatherContact { get; set; }
        public string fatherEducation { get; set; }
        public string motherOccupation { get; set; }
        public string motherCOntact { get; set; }
        public string motherEducation { get; set; }
        public string motherName { get; set; }
        public string motherDOB { get; set; }
        public string mother_age { get; set; }
        public string guardianName { get; set; }
        public string guardianRelationship { get; set; }
        public string guardianContact { get; set; }
        public string guardianAddress { get; set; }
        public string goodmoralCertificate { get; set; }
        public string nsoCertificate { get; set; }
        public string reportcard { get; set; }
        public string baptismalCertificate { get; set; }
        public string clearanceCertificate { get; set; }
        public string student_status { get; set; }
    }
}
