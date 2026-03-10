using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace SendDatanet
{
    public partial class FormMain : Form
    {
        const int portNumber = 5000;
        const string serverIp = "sensordata";
        static byte[] bytesToRead;
        static int bytesRead;
        bool checkOnce = false;
        string sensorData, temp, hum;
        int addPoint = 0;
        double convertTemp, convertHum;

        List<double> xTempValue = new List<double>();
        List<double> yTempValue = new List<double>();
        List<double> xHumValue = new List<double>();
        List<double> yHumValue = new List<double>();

        public FormMain()
        {
            InitializeComponent();
        }

        TcpClient client;

        private string removeText(string value)
        {
            var allowedValue = "01234567890.,";
            return new string(value.Where(c => allowedValue.Contains(c)).ToArray());
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.GetStream().Socket.Close();
            client.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            chartTemp.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartHum.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            timer1.Start();
            try
            {
                client = new TcpClient(serverIp, portNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void colorLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                chartTemp.Series[0].MarkerColor = colorDialog1.Color;
                chartTemp.Series[0].BorderColor = colorDialog1.Color;
                chartTemp.Series[0].Color = colorDialog1.Color;
                chartHum.Series[0].MarkerColor = colorDialog1.Color;
                chartHum.Series[0].BorderColor = colorDialog1.Color;
                chartHum.Series[0].Color = colorDialog1.Color;
            }

        }

        private void size6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 6;
            chartHum.Series[0].MarkerSize = 6;
            size6ToolStripMenuItem.Checked = true;
            size8ToolStripMenuItem.Checked = false;
            size10ToolStripMenuItem.Checked = false;
            size12ToolStripMenuItem.Checked = false;
            size14ToolStripMenuItem.Checked = false;
            size16ToolStripMenuItem.Checked = false;
        }

        private void size8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 8;
            chartHum.Series[0].MarkerSize = 8;
            size6ToolStripMenuItem.Checked = false;
            size8ToolStripMenuItem.Checked = true;
            size10ToolStripMenuItem.Checked = false;
            size12ToolStripMenuItem.Checked = false;
            size14ToolStripMenuItem.Checked = false;
            size16ToolStripMenuItem.Checked = false;
        }

        private void size10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 10;
            chartHum.Series[0].MarkerSize = 10;
            size6ToolStripMenuItem.Checked = false;
            size8ToolStripMenuItem.Checked = false;
            size10ToolStripMenuItem.Checked = true;
            size12ToolStripMenuItem.Checked = false;
            size14ToolStripMenuItem.Checked = false;
            size16ToolStripMenuItem.Checked = false;
        }

        private void size12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 12;
            chartHum.Series[0].MarkerSize = 12;
            size6ToolStripMenuItem.Checked = false;
            size8ToolStripMenuItem.Checked = false;
            size10ToolStripMenuItem.Checked = false;
            size12ToolStripMenuItem.Checked = true;
            size14ToolStripMenuItem.Checked = false;
            size16ToolStripMenuItem.Checked = false;
        }

        private void size14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 14;
            chartHum.Series[0].MarkerSize = 14;
            size6ToolStripMenuItem.Checked = false;
            size8ToolStripMenuItem.Checked = false;
            size10ToolStripMenuItem.Checked = false;
            size12ToolStripMenuItem.Checked = false;
            size14ToolStripMenuItem.Checked = true;
            size16ToolStripMenuItem.Checked = false;
        }

        private void size16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 16;
            chartHum.Series[0].MarkerSize = 16;
            size6ToolStripMenuItem.Checked = false;
            size8ToolStripMenuItem.Checked = false;
            size10ToolStripMenuItem.Checked = false;
            size12ToolStripMenuItem.Checked = false;
            size14ToolStripMenuItem.Checked = false;
            size16ToolStripMenuItem.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                NetworkStream newStream = client.GetStream();
                bytesToRead = new byte[client.ReceiveBufferSize];
                bytesRead = newStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                if (checkOnce == true)
                {
                    addPoint++;
                    sensorData = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    labelTime.Text = "Current time: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    temp = sensorData;
                    hum = sensorData;
                    temp = temp.Remove(temp.Length - 10);
                    //  MessageBox.Show(temp);
                    hum = hum.Remove(0, 17);
                    temp = removeText(temp);
                    hum = removeText(hum);
                    labelTemp.Text = "Temperature: " + temp + " C";
                    labelHum.Text = "Humitidy: " + hum + " %";

                    convertTemp = double.Parse(temp);
                    yTempValue.Add(convertTemp);
                    xTempValue.Add(addPoint);

                    convertHum = double.Parse(hum);
                    yHumValue.Add(convertHum);
                    xHumValue.Add(addPoint);

                    if (addPoint > 10)
                    {
                        yTempValue.RemoveAt(0);
                        xTempValue.RemoveAt(0);
                        yHumValue.RemoveAt(0);
                        xHumValue.RemoveAt(0);
                    }
                    chartTemp.ChartAreas[0].AxisX.Minimum = xTempValue[0];
                    chartTemp.ChartAreas[0].AxisX.Maximum = addPoint;
                    chartTemp.Series[0].Points.DataBindXY(xTempValue, yTempValue);

                    chartHum.ChartAreas[0].AxisX.Minimum = xHumValue[0];
                    chartHum.ChartAreas[0].AxisX.Maximum = addPoint;
                    chartHum.Series[0].Points.DataBindXY(xHumValue, yHumValue);


                    notifyIcon1.Text = "Ken's Sensor Data" + Environment.NewLine + "Temperature: " + temp + " C" + Environment.NewLine + "Humitidy: " + hum + " %";
                }
                checkOnce = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed, " + ex.Message);
            }
        }

        private void noMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!noMarkerToolStripMenuItem.Checked)
            {
                chartTemp.Series[0].MarkerStyle = MarkerStyle.None;
                chartHum.Series[0].MarkerStyle = MarkerStyle.None;
                noMarkerToolStripMenuItem.Checked = true;
                markerSizeToolStripMenuItem.Enabled = false;
            }
            else
            {
                chartTemp.Series[0].MarkerStyle = MarkerStyle.Circle;
                chartHum.Series[0].MarkerStyle = MarkerStyle.Circle;
                noMarkerToolStripMenuItem.Checked = false;
                markerSizeToolStripMenuItem.Enabled = true;
            }
        }

        private void aboutSensorViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0" + Environment.NewLine + "Ken Ekholm, ken.ekholm@live.com" + Environment.NewLine + "All rights reserved", "Ken's SensorData");
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maximazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void smallViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.Visible = false;
            smallViewToolStripMenuItem.Checked = true;
            normalViewToolStripMenuItem.Checked = false;
            this.Width = 400;
            this.Height = 210;

        }

        private void normalViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.Visible = true;
            smallViewToolStripMenuItem.Checked = false;
            normalViewToolStripMenuItem.Checked = true;
            this.Width = 2000;
            this.Height = 700;
        }
    }
}
