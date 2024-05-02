
namespace GenerateQR
{
    partial class QrCodeScanner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStartCam = new Guna.UI.WinForms.GunaButton();
            this.btnStopCam = new Guna.UI.WinForms.GunaButton();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtQRCode = new System.Windows.Forms.TextBox();
            this.pbCam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCam)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(191, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 50);
            this.label6.TabIndex = 16;
            this.label6.Text = "SCAN QR CODE";
            // 
            // btnStartCam
            // 
            this.btnStartCam.AnimationHoverSpeed = 0.07F;
            this.btnStartCam.AnimationSpeed = 0.03F;
            this.btnStartCam.BackColor = System.Drawing.Color.Transparent;
            this.btnStartCam.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnStartCam.BorderColor = System.Drawing.Color.Black;
            this.btnStartCam.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartCam.FocusedColor = System.Drawing.Color.Empty;
            this.btnStartCam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCam.ForeColor = System.Drawing.Color.White;
            this.btnStartCam.Image = null;
            this.btnStartCam.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStartCam.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStartCam.Location = new System.Drawing.Point(123, 564);
            this.btnStartCam.Name = "btnStartCam";
            this.btnStartCam.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnStartCam.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStartCam.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStartCam.OnHoverImage = null;
            this.btnStartCam.OnPressedColor = System.Drawing.Color.Black;
            this.btnStartCam.Radius = 20;
            this.btnStartCam.Size = new System.Drawing.Size(160, 42);
            this.btnStartCam.TabIndex = 17;
            this.btnStartCam.Text = "Start Camera";
            this.btnStartCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStartCam.Click += new System.EventHandler(this.btnStartCam_Click);
            // 
            // btnStopCam
            // 
            this.btnStopCam.AnimationHoverSpeed = 0.07F;
            this.btnStopCam.AnimationSpeed = 0.03F;
            this.btnStopCam.BackColor = System.Drawing.Color.Transparent;
            this.btnStopCam.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnStopCam.BorderColor = System.Drawing.Color.Black;
            this.btnStopCam.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStopCam.FocusedColor = System.Drawing.Color.Empty;
            this.btnStopCam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopCam.ForeColor = System.Drawing.Color.White;
            this.btnStopCam.Image = null;
            this.btnStopCam.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStopCam.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStopCam.Location = new System.Drawing.Point(354, 564);
            this.btnStopCam.Name = "btnStopCam";
            this.btnStopCam.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnStopCam.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStopCam.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStopCam.OnHoverImage = null;
            this.btnStopCam.OnPressedColor = System.Drawing.Color.Black;
            this.btnStopCam.Radius = 20;
            this.btnStopCam.Size = new System.Drawing.Size(160, 42);
            this.btnStopCam.TabIndex = 17;
            this.btnStopCam.Text = "Stop Camera";
            this.btnStopCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStopCam.Click += new System.EventHandler(this.btnStopCam_Click);
            // 
            // cbCamera
            // 
            this.cbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(123, 110);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(515, 28);
            this.cbCamera.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Camera";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtQRCode
            // 
            this.txtQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRCode.Location = new System.Drawing.Point(703, 295);
            this.txtQRCode.Multiline = true;
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(186, 89);
            this.txtQRCode.TabIndex = 24;
            // 
            // pbCam
            // 
            this.pbCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCam.Location = new System.Drawing.Point(39, 156);
            this.pbCam.Name = "pbCam";
            this.pbCam.Size = new System.Drawing.Size(647, 388);
            this.pbCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCam.TabIndex = 25;
            this.pbCam.TabStop = false;
            // 
            // QrCodeScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(927, 638);
            this.Controls.Add(this.pbCam);
            this.Controls.Add(this.txtQRCode);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStopCam);
            this.Controls.Add(this.btnStartCam);
            this.Controls.Add(this.label6);
            this.Name = "QrCodeScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QrCodeScanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QrCodeScanner_FormClosing);
            this.Load += new System.EventHandler(this.QrCodeScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaButton btnStartCam;
        private Guna.UI.WinForms.GunaButton btnStopCam;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.PictureBox pbCam;
    }
}