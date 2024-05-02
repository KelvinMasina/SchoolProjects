using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQR
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            DisplayStudents();
            
        }

        private void DisplayStudents()
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            string displayQuery = "SELECT Id, Student_Name, Class, Parents_Number FROM Students";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvStudents.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            Form1 NewStudent = new Form1();
            NewStudent.Show();
        }

        int Key = 0;
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIDNumber.Text = dgvStudents.SelectedRows[0].Cells[0].Value.ToString();
            lblStudentName.Text = dgvStudents.SelectedRows[0].Cells[1].Value.ToString();
            lblClass.Text = dgvStudents.SelectedRows[0].Cells[2].Value.ToString();
            lblPNumber.Text = dgvStudents.SelectedRows[0].Cells[3].Value.ToString();

            try
            {
                connect obj = new connect();
                obj.conn.ConnectionString = obj.locate;
                obj.conn.Open();

                SqlCommand cmd = new SqlCommand("select * from Students WHERE Id = '" + lblIDNumber.Text + "'", obj.conn);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MemoryStream stream = new MemoryStream(rdr.GetSqlBytes(4).Buffer);
                    pictureBox1.Image = Image.FromStream(stream);
                }

                obj.conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }

            if (lblStudentName.Text == "")
            {
                Key = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value.ToString());                                             

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            pnlStudentInfo.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlStudentInfo.Visible = false;
        }
    }
}
