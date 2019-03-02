using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bbusb
{
    public partial class frmMain : Form
    {
        bool isForwardDown = false;
        bool isBackwardDown = false;
        int threshold = 20000;

        public enum BBStatus
        {
            UNKNOWN,
            CONNECTED,
            CALIBRATING,
            VALUES
        }

        private string buffer;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bbusbPort.DataReceived += BbusbPort_DataReceived;


            AutoConnectIfPossible(true);
        }

        private void AutoConnectIfPossible(bool firstTime = false)
        {
            if (!bbusbPort.IsOpen || firstTime)
            {
                lblDeviceStatus.Text = "Disconnected";
                lblDeviceStatus.BackColor = Color.LightGray;

                string[] ports = SerialPort.GetPortNames();
                if (ports.Contains(Properties.Settings.Default.bbusbport))
                {
                    bbusbPort.PortName = Properties.Settings.Default.bbusbport;
                    try
                    {
                        bbusbPort.Open();
                    }
                    catch
                    {

                    }
                }
            }
        }

        delegate void UpdateUIDelegate(BBStatus status, string data);
        void UpdateUI(BBStatus status, string data)
        {
            pbrCalibration.Visible = false;

            switch (status)
            {
                case BBStatus.UNKNOWN:
                    lblDeviceStatus.Text = "Unknown status";
                    lblDeviceStatus.BackColor = Color.LightGray;
                    break;
                case BBStatus.CONNECTED:
                    lblDeviceStatus.Text = "Connected";
                    lblDeviceStatus.BackColor = Color.Green;
                    break;
                case BBStatus.CALIBRATING:
                    lblDeviceStatus.Text = "Calibrating";
                    lblDeviceStatus.BackColor = Color.Yellow;
                    pbrCalibration.Value = Math.Min(100, data.Length * 2);
                    pbrCalibration.Visible = true;
                    break;
                case BBStatus.VALUES:
                    lblDeviceStatus.Text = "Receiving";
                    lblDeviceStatus.BackColor = Color.White;

                    int right, left, center;
                    string[] values = data.Split(',');

                    if (values.Length >= 3)
                    {
                        int.TryParse(values[0], out right);
                        int.TryParse(values[1], out left);
                        int.TryParse(values[2], out center);

                        if (left > pbrLeft.Maximum) pbrLeft.Maximum = left;
                        if (right > pbrRight.Maximum) pbrRight.Maximum = right;
                        pbrLeft.Value = left;
                        pbrRight.Value = right;

                        lblLeft.Text = left.ToString();
                        lblRight.Text = right.ToString();
                        lblCenter.Text = center.ToString();

                        int.TryParse(txtTreshold.Text, out threshold);

                        if (center > threshold)
                        {
                            if (!isForwardDown) InputManager.Keyboard.KeyDown(Keys.S);
                            isForwardDown = true;

                            if (isBackwardDown) InputManager.Keyboard.KeyUp(Keys.Z);
                            isBackwardDown = false;
                        }
                        else if (center < -threshold)
                        {
                            if (isForwardDown) InputManager.Keyboard.KeyUp(Keys.S);
                            isForwardDown = false;

                            if (!isBackwardDown) InputManager.Keyboard.KeyDown(Keys.Z);
                            isBackwardDown = true;
                        }
                        else
                        {
                            if (isForwardDown) InputManager.Keyboard.KeyUp(Keys.S);
                            isForwardDown = false;

                            if (isBackwardDown) InputManager.Keyboard.KeyUp(Keys.Z);
                            isBackwardDown = false;
                        }

                    }
                    break;
            }
        }

        private void BbusbPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buffer += bbusbPort.ReadExisting();

            if (buffer.StartsWith(".")) BeginInvoke(new UpdateUIDelegate(UpdateUI), BBStatus.CALIBRATING, buffer);

            if (buffer.Contains("\r\n"))
            {
                string[] splitBuffer = buffer.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string value = splitBuffer[0];

                BBStatus status = BBStatus.UNKNOWN;
                if (value.StartsWith("bbusb")) status = BBStatus.CONNECTED;
                else if (value.StartsWith(".")) status = BBStatus.CALIBRATING;
                else if (value.StartsWith("c")) status = BBStatus.CALIBRATING;
                else if (value.Contains(",")) status = BBStatus.VALUES;
                else status = BBStatus.UNKNOWN;

                BeginInvoke(new UpdateUIDelegate(UpdateUI), status, value);

                if (splitBuffer.Length > 1) buffer = splitBuffer[1];
                else buffer = "";
            }
        }

        protected override void WndProc(ref Message m)
        {
            //WM_DEVICECHANGE
            if (m.Msg == 0x219)
            {
                AutoConnectIfPossible();
            }
            base.WndProc(ref m);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bbusbPort.Close();
        }
    }
}
