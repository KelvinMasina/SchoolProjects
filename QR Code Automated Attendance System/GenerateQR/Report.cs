using ClosedXML.Excel;
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
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;

namespace GenerateQR
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            DisplayReport();
        }

        private void DisplayReport()
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            string displayQuery = "SELECT A.Student_Id, S.Student_Name, S.Class, A.Date, A.Arrival_Time, A.Status FROM Attendance A, Students S WHERE S.Id = A.Student_Id ORDER BY A.Date, A.Arrival_Time";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvReport.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            DateTime startAtMonday = DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);

            string displayQuery = "SELECT A.Student_Id, S.Student_Name, S.Class, A.Date, A.Arrival_Time, A.Status FROM Attendance A, Students S WHERE S.Id = A.Student_Id AND A.Date = '" + startAtMonday + "' ORDER BY A.Date, A.Arrival_Time";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvReport.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

        private void bntStartCam_Click(object sender, EventArgs e)
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            var date = System.DateTime.Now.ToShortDateString();

            string displayQuery = "SELECT A.Student_Id, S.Student_Name, S.Class, A.Date, A.Arrival_Time, A.Status FROM Attendance A, Students S WHERE S.Id = A.Student_Id AND A.Date =  '" + date + "' ORDER BY A.Date, A.Arrival_Time";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvReport.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect obj = new connect();
            obj.conn.ConnectionString = obj.locate;
            obj.conn.Open();

            

            string displayQuery = "SELECT A.Student_Id, S.Student_Name, S.Class, A.Date, A.Arrival_Time, A.Status FROM Attendance A, Students S WHERE S.Id = A.Student_Id AND DATEDIFF(mm, A.Date, GETDATE()) = 0 ORDER BY A.Date, A.Arrival_Time";
            SqlDataAdapter sda = new SqlDataAdapter(displayQuery, obj.conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvReport.DataSource = ds.Tables[0];


            obj.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as Excel File";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel Files|*.xlsx";

            if(saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                //Change properties of the Workbook
                //ExcelApp.Columns.ColumnWIdth = 20;

                //Storing Header
                for (int i = 1; i < dgvReport.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvReport.Columns[i - 1].HeaderText;
                }

                //Storing each row and column value
                for(int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    for(int j = 0; j < dgvReport.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dgvReport.Rows[1].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
               
            }
        }
    }
}
