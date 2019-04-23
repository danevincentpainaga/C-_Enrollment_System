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
    class Connection
    {
        protected string databaseName = "enrollment_system";
        protected string source = "localhost";
        protected string username =  "root";
        protected string password = "";


        protected MySqlConnection _myConnection;
        protected MySqlCommand _cmd;
        protected MySqlDataAdapter _da;
        protected DataTable _dt;
        protected MySqlDataReader _myReader;
        public Connection()
        {
           
            try { 
                _myConnection = new MySqlConnection( "datasource = " +source+ "; database = " + databaseName + "; port = 3306; Uid = " + username + "; password = " + password + "");
                _myConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void sqlQuery(string query)
        {
            _cmd = new MySqlCommand(query, _myConnection);
        }

        public DataTable QueryExe()
        {
            _da = new MySqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);
            return _dt;
        }

        public void NonQueryExe()
        {
            try {
                _cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MySqlDataReader readerExe()
        {
            _myReader = _cmd.ExecuteReader();
            return _myReader;
        }

        public void closeConn()
        {
            _myConnection.Close();
        }

        public void openCon()
        {
            _myConnection.Open();
        }

        public DataSet datasetQuery(string table)
        {
            _da = new MySqlDataAdapter(_cmd);
            DataSet ds = new DataSet();
            _da.Fill(ds, table);
            return ds;
        }
    }
}
