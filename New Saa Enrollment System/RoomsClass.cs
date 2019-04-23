using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace New_Saa_Enrollment_System
{
    class RoomsClass : Connection
    {
        public RoomsClass()
        {
           
        }

        public void getRooms()
        {
            sqlQuery("SELECT * FROM rooms");
            NonQueryExe();
        }

        public void addRooms(string room_name, string room_description)
        {
            sqlQuery(
                        "INSERT INTO rooms (room_name, room_description) " +
                        "VALUES (@room_name, @room_description)"
                    );

            _cmd.Parameters.AddWithValue("@room_name", room_name);
            _cmd.Parameters.AddWithValue("@room_description", room_description);
            NonQueryExe();
            MessageBox.Show("Room Added!");
        }

        public void updateRooms(string room_id, string room_name, string room_description)
        {
            sqlQuery(
                        "UPDATE rooms SET room_name = @room_name, room_description = @room_description "+
                        "WHERE room_id = @room_id"
                    );

            _cmd.Parameters.AddWithValue("@room_id", room_id);
            _cmd.Parameters.AddWithValue("@room_name", room_name);
            _cmd.Parameters.AddWithValue("@room_description", room_description);
            NonQueryExe();
            MessageBox.Show("Room Details Updated!");
        }
    }
}
