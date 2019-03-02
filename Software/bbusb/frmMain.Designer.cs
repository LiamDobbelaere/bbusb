namespace bbusb
{
    partial class frmMain
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
            this.bbusbPort = new System.IO.Ports.SerialPort(this.components);
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.pbrCalibration = new System.Windows.Forms.ProgressBar();
            this.pbrLeft = new System.Windows.Forms.ProgressBar();
            this.pbrRight = new System.Windows.Forms.ProgressBar();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.txtTreshold = new System.Windows.Forms.TextBox();
            this.lblCenter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDeviceStatus.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceStatus.Location = new System.Drawing.Point(0, 0);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(331, 41);
            this.lblDeviceStatus.TabIndex = 2;
            this.lblDeviceStatus.Text = "Initializing";
            this.lblDeviceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbrCalibration
            // 
            this.pbrCalibration.BackColor = System.Drawing.SystemColors.Control;
            this.pbrCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbrCalibration.Location = new System.Drawing.Point(0, 41);
            this.pbrCalibration.Name = "pbrCalibration";
            this.pbrCalibration.Size = new System.Drawing.Size(331, 23);
            this.pbrCalibration.TabIndex = 3;
            this.pbrCalibration.Visible = false;
            // 
            // pbrLeft
            // 
            this.pbrLeft.Location = new System.Drawing.Point(6, 90);
            this.pbrLeft.Name = "pbrLeft";
            this.pbrLeft.Size = new System.Drawing.Size(100, 23);
            this.pbrLeft.TabIndex = 4;
            // 
            // pbrRight
            // 
            this.pbrRight.Location = new System.Drawing.Point(219, 90);
            this.pbrRight.Name = "pbrRight";
            this.pbrRight.Size = new System.Drawing.Size(100, 23);
            this.pbrRight.TabIndex = 5;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(3, 74);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(25, 13);
            this.lblLeft.TabIndex = 6;
            this.lblLeft.Text = "Left";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(216, 74);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(32, 13);
            this.lblRight.TabIndex = 7;
            this.lblRight.Text = "Right";
            // 
            // txtTreshold
            // 
            this.txtTreshold.Location = new System.Drawing.Point(113, 90);
            this.txtTreshold.Name = "txtTreshold";
            this.txtTreshold.Size = new System.Drawing.Size(100, 20);
            this.txtTreshold.TabIndex = 8;
            this.txtTreshold.Text = "20000";
            // 
            // lblCenter
            // 
            this.lblCenter.AutoSize = true;
            this.lblCenter.Location = new System.Drawing.Point(110, 74);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(38, 13);
            this.lblCenter.TabIndex = 9;
            this.lblCenter.Text = "Center";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 121);
            this.Controls.Add(this.lblCenter);
            this.Controls.Add(this.txtTreshold);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.pbrRight);
            this.Controls.Add(this.pbrLeft);
            this.Controls.Add(this.pbrCalibration);
            this.Controls.Add(this.lblDeviceStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "bbusb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort bbusbPort;
        private System.Windows.Forms.Label lblDeviceStatus;
        private System.Windows.Forms.ProgressBar pbrCalibration;
        private System.Windows.Forms.ProgressBar pbrLeft;
        private System.Windows.Forms.ProgressBar pbrRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.TextBox txtTreshold;
        private System.Windows.Forms.Label lblCenter;
    }
}

