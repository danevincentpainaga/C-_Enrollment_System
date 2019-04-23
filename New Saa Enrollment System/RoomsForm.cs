using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class RoomsForm : Form
    {
        private RoomsClass rc;

        private string roomId;
        public RoomsForm()
        {
            InitializeComponent();
            rc = new RoomsClass();
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            rc.getRooms();
            roomsviewGrid.DataSource = rc.QueryExe();

            roomsviewGrid.DefaultCellStyle.SelectionBackColor = Color.Lavender;
            roomsviewGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            roomsviewGrid.AutoResizeColumns();
            roomsviewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void roomSaveBtn_Click(object sender, EventArgs e)
        {
            if(roomSaveBtn.Text == "SAVE") { 
                rc.addRooms(
                                roomNameTxtbox.Text,
                                roomDescriptionrichTextBox.Text
                           );

                roomNameTxtbox.Text = String.Empty;
                roomDescriptionrichTextBox.Text = String.Empty;
            }
            else
            {
                var res = MessageBox.Show("Update Room Details?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    rc.updateRooms(
                                    roomId,
                                    roomNameTxtbox.Text,
                                    roomDescriptionrichTextBox.Text
                              );
                }
            }
            rc.getRooms();
            roomsviewGrid.DataSource = rc.QueryExe();
        }

        private void roomsviewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.roomsviewGrid.Rows[e.RowIndex];
                    
                    roomNameTxtbox.Text = row.Cells["room_name"].Value.ToString();
                    roomDescriptionrichTextBox.Text = row.Cells["room_description"].Value.ToString();
                    roomId = row.Cells["room_id"].Value.ToString();
                    roomSaveBtn.Text = "UPDATE";
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void roomCancelBtn_Click(object sender, EventArgs e)
        {
            roomSaveBtn.Text = "SAVE";
            roomNameTxtbox.Text = String.Empty;
            roomDescriptionrichTextBox.Text = String.Empty;
        }
    }
}
