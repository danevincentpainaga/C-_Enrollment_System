using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace New_Saa_Enrollment_System
{
    class UserClass : Connection
    {
        public static string userid, loggedUsername, usertype, usertypeId, loggedFullname;
        private string username;
        private string position;
        public UserClass()
        {
            
        }

        public void getUsertTypes()
        {
            sqlQuery("SELECT * FROM usertypes");
            NonQueryExe();
        }

        public int login(string username, string password)
        {
            sqlQuery(   
                        "SELECT u.*, ut.* FROM users u INNER JOIN usertypes ut ON u.user_typeId = ut.user_type_id "+
                        "WHERE username = @username AND password = @password AND user_status = 'Activated' LIMIT 1"
                    );

            _cmd.Parameters.AddWithValue("@username", username);
            _cmd.Parameters.AddWithValue("@password", password);

            if (QueryExe().Rows.Count == 1)
            {
                foreach (DataRow dr in QueryExe().Rows)
                {
                    userid = dr["user_id"].ToString();
                    usertypeId = dr["user_type_id"].ToString();
                    loggedUsername = dr["username"].ToString();
                    usertype = dr["user_type"].ToString();
                    loggedFullname = dr["firstname"].ToString()+" "+ dr["mi"].ToString()+". "+ dr["lastname"].ToString();
                }
                return 1;
            }
            else
            {
                return 0;
            }
            NonQueryExe();
        }

        public void displayUsers(string Param = null)
        {
            if (Param == null)
            {
                sqlQuery("SELECT u.*, ut.* FROM users u INNER JOIN usertypes ut ON u.user_typeId = ut.user_type_id");
                NonQueryExe();
            }
            else
            {
                sqlQuery(
                            "SELECT u.*, ut.* FROM users u INNER JOIN usertypes ut ON u.user_typeId = ut.user_type_id " +
                            "WHERE Concat(`lastname`,`mi`,`firstname`,`username`) LIKE '%" + Param + "%'"
                         );
                NonQueryExe();
            }
        }

        public void insertUser(string lname, string fname, string mi, string gender, string bdate, string age, string address, string pos, string uname, string pass, object utypeid, string userstatus)
        {
            sqlQuery(
                        "INSERT INTO users (lastname, firstname, mi, gender, birthdate, age, address, position, username, password, user_typeId, user_status) " +
                        "VALUES (@lastname, @firstname, @mi, @gender, @birthdate, @age, @address, @position, @username, @password, @user_typeId, @user_status)"
                    );

            _cmd.Parameters.AddWithValue("@lastname", lname);
            _cmd.Parameters.AddWithValue("@firstname", fname);
            _cmd.Parameters.AddWithValue("@mi", mi);
            _cmd.Parameters.AddWithValue("@gender", gender);
            _cmd.Parameters.AddWithValue("@birthdate", bdate);
            _cmd.Parameters.AddWithValue("@age", age);
            _cmd.Parameters.AddWithValue("@address", address);
            _cmd.Parameters.AddWithValue("@position", pos);
            _cmd.Parameters.AddWithValue("@username", uname);
            _cmd.Parameters.AddWithValue("@password", pass);
            _cmd.Parameters.AddWithValue("@user_typeId", utypeid);
            _cmd.Parameters.AddWithValue("@user_status", userstatus);
            MessageBox.Show("User Successfully created!");
            NonQueryExe();
        }

        public void updateUser(string lname, string fname, string mi, string gender, string bdate, string age, string address, string pos, string uname, string pass, object utypeid, string userstatus, string user_id)
        {
            sqlQuery(
                        "UPDATE users SET lastname = @lastname, firstname = @firstname, mi = @mi, gender = @gender, birthdate = @birthdate, "+
                        "age = @age, address = @address, position = @position, username = @username, password = @password, "+
                        "user_typeId = @user_typeId, user_status = @user_status "+
                        "WHERE user_id = @user_id"
                    );

            _cmd.Parameters.AddWithValue("@lastname", lname);
            _cmd.Parameters.AddWithValue("@firstname", fname);
            _cmd.Parameters.AddWithValue("@mi", mi);
            _cmd.Parameters.AddWithValue("@gender", gender);
            _cmd.Parameters.AddWithValue("@birthdate", bdate);
            _cmd.Parameters.AddWithValue("@age", age);
            _cmd.Parameters.AddWithValue("@address", address);
            _cmd.Parameters.AddWithValue("@position", pos);
            _cmd.Parameters.AddWithValue("@username", uname);
            _cmd.Parameters.AddWithValue("@password", pass);
            _cmd.Parameters.AddWithValue("@user_typeId", utypeid);
            _cmd.Parameters.AddWithValue("@user_status", userstatus);
            _cmd.Parameters.AddWithValue("@user_id", user_id);
            NonQueryExe();

            MessageBox.Show("User Successfully Updated!");
            NonQueryExe();
        }

    }
}
