using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQR
{
    public partial class AttendanceRecords : Form
    {
        public AttendanceRecords()
        {
            InitializeComponent();
            DisplayAttendance();
        }

        private void DisplayAttendance()
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            string displayQuery = "SELECT A.AttendanceID, A.Student_Id, S.Student_Name, S.Class, A.Arrival_Time, A.Date, A.Status FROM Attendance A, Students S WHERE S.Id = A.Student_Id ORDER BY A.Date, A.Arrival_Time";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvAttendance.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

    }
}
