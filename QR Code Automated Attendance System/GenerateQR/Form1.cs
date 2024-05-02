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
using QRCoder;

namespace GenerateQR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtID.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox1.Image = code.GetGraphic(5);
        }

        private void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtClass.Text = "";
            txtPNumber.Text = "";
            pictureBox1.Image = null;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Please provide all valid details");
            }
            else
            {
                connect obj = new connect();
                obj.conn.ConnectionString = obj.locate;
                obj.conn.Open();

                obj.cmd = new SqlCommand("SELECT * FROM Students WHERE Id = '" + txtID.Text + "' ", obj.conn);
                SqlDataAdapter da = new SqlDataAdapter(obj.cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;

                if(i > 0)
                {
                    MessageBox.Show("Student ID " + txtID.Text + " Already Exist. Enter Another One");
                    ds.Clear();
                }
                else
                {
                    try
                    {
                        /*connect obj = new connect();
                        obj.conn.ConnectionString = obj.locate;
                        obj.conn.Open();*/

                        var QRCode = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                        obj.cmd.Parameters.AddWithValue("@QRCode", QRCode);

                        string AddStudent = "insert into Students (Id, Student_Name, Class, Parents_Number, QR_Code)	values  ('" + txtID.Text + "', '" + txtName.Text + "', '" + txtClass.Text + "', '" + txtPNumber.Text + "', @QRCOde)";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = AddStudent;
                        obj.cmd.ExecuteNonQuery();

                        obj.conn.Close();
                        MessageBox.Show("Student Added successiful");

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error" + ex);
                    }

                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "JPG Files(*.jpg)|*.jpg";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image.Save(dlg.FileName);
                        MessageBox.Show("QR Code Saved Successifully");
                        Clear();
                    }
                }
            }
             
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";

            if (OD.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(OD.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
