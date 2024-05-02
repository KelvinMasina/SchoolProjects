using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace GenerateQR
{
    public partial class QrCodeScanner : Form
    {
        SoundPlayer _soundPlayer = new SoundPlayer(@"C:\Users\FLAG\Documents\QRScanner.wav");
        SoundPlayer _soundPlayer2 = new SoundPlayer(@"C:\Users\FLAG\Documents\QRError.wav");
        public QrCodeScanner()
        {
            InitializeComponent();         
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

       
        private void QrCodeScanner_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cbCamera.Items.Add(filterInfo.Name);
                cbCamera.SelectedIndex = 0;
            }
        }

        private void QrCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbCam.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pbCam.Image);
                if (result != null)
                {
                    txtQRCode.Text = result.ToString();
                    string DecodedText = result.ToString();
                    var time = System.DateTime.Now.ToLongTimeString();
                    var date = System.DateTime.Now.ToShortDateString();
                    string Status = "Present";

                    _soundPlayer.Play();
                    //timer1.Stop();

                    try
                    {
                        connect obj = new connect();
                        obj.conn.ConnectionString = obj.locate;
                        obj.conn.Open();

                        obj.cmd.Parameters.AddWithValue("@Time", time);
                        obj.cmd.Parameters.AddWithValue("@Date", date);

                        string RecordAttendance = "insert into Attendance (Student_Id, Arrival_Time, Date, Status) values ('" + DecodedText + "', @Time, @Date, '" + Status + "')";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = RecordAttendance;
                        obj.cmd.ExecuteNonQuery();

                        obj.conn.Close();
                        MessageBox.Show("Attendance Recorded Successiful For ID: '" + DecodedText + "' ");

                    }
                    catch (SqlException)
                    {
                        _soundPlayer2.Play();
                        MessageBox.Show("Invalid QR Code");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error" + ex);
                    }

                   
                }
            }
        }

        private void btnStopCam_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }

           
        }
    }
}
