using ReadTemp;
using Sensordevice;
using SimpleTCP;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SendDatanet
{
    public partial class Main : Form
    {
        int portNumber = 5000;
        string serverIp = "sensordevice";
        string sensorData, temp, hum;
        int addPoint = 0, checkPoint = 20;
        decimal convertTemp, convertHum;

        List<int> xTempValue = new List<int>();
        List<decimal> yTempValue = new List<decimal>();
        List<int> xHumValue = new List<int>();
        List<decimal> yHumValue = new List<decimal>();
        SimpleTcpClient client;

        public Main()
        {
            InitializeComponent();
        }

        private string removeText(string value)
        {
            var allowedValue = "01234567890.,";
            return new string(value.Where(c => allowedValue.Contains(c)).ToArray());
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            chartTemp.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartHum.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            try
            {
                client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                client.Connect(serverIp, portNumber);
                client.DataReceived += dataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed, " + ex.Message);
            }
        }



        private void dataReceived(object sender, SimpleTCP.Message e)
        {
            try
            {
                addPoint++;
                sensorData = Encoding.UTF8.GetString(e.Data);
                labelTime.Invoke((MethodInvoker)(() => labelTime.Text = "Current time: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                temp = sensorData;
                hum = sensorData;
                temp = temp.Remove(temp.Length - 10);
                hum = hum.Remove(0, 17);
                temp = removeText(temp);
                temp = temp.Replace(".", ",");
                hum = removeText(hum);
                hum = hum.Replace(".", ",");
                labelTemp.Invoke((MethodInvoker)(() => labelTemp.Text = "Temperature: " + temp + " C"));
                labelHum.Invoke((MethodInvoker)(() => labelHum.Text = "Humitidy: " + hum + " %"));
                convertTemp = decimal.Parse(temp);
                yTempValue.Add(convertTemp);
                xTempValue.Add(addPoint);

                convertHum = decimal.Parse(hum);
                yHumValue.Add(convertHum);
                xHumValue.Add(addPoint);

                if (addPoint > checkPoint)
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

                labelAvg.Invoke((MethodInvoker)(() => labelAvg.Text = "Temperature medium value: " + Math.Round(yTempValue.Average(), 1).ToString() + " °C | Humitidy medium value:" + Math.Round(yHumValue.Average(), 1).ToString() + " %"));
                labelMin.Invoke((MethodInvoker)(() => labelMin.Text = "Temperature min value: " + yTempValue.Min().ToString() + " °C      | Humitidy max value: " + yHumValue.Min().ToString() + " %"));
                labelMax.Invoke((MethodInvoker)(() => labelMax.Text = "Temperature max value: " + yTempValue.Max().ToString() + " °C      | Humitidy max value: " + yHumValue.Max().ToString() + " %"));

                notifyIcon1.Text = "Ken's Sensor Data" + Environment.NewLine + "Temperature: " + temp + " C" + Environment.NewLine + "Humitidy: " + hum + " %";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed, " + ex.Message);
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
            FormAbout about = new FormAbout();
            about.ShowDialog();
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

        private void lightBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightBackToolStripMenuItem.Checked = true;
            mediumBackToolStripMenuItem.Checked = false;
            darkBackToolStripMenuItem.Checked = false;
            chartTemp.BackColor = Color.White;
            chartTemp.ChartAreas[0].BackColor = Color.White;
            chartTemp.Legends[0].BackColor = Color.White;
            chartHum.BackColor = Color.White;
            chartHum.ChartAreas[0].BackColor = Color.White;
            chartHum.Legends[0].BackColor = Color.White;
        }

        private void mediumBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightBackToolStripMenuItem.Checked = false;
            mediumBackToolStripMenuItem.Checked = true;
            darkBackToolStripMenuItem.Checked = false;
            chartTemp.BackColor = Color.LightGray;
            chartTemp.ChartAreas[0].BackColor = Color.LightGray;
            chartTemp.Legends[0].BackColor = Color.LightGray;
            chartHum.BackColor = Color.LightGray;
            chartHum.ChartAreas[0].BackColor = Color.LightGray;
            chartHum.Legends[0].BackColor = Color.LightGray;
        }

        private void darkBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightBackToolStripMenuItem.Checked = false;
            mediumBackToolStripMenuItem.Checked = false;
            darkBackToolStripMenuItem.Checked = true;
            chartTemp.BackColor = Color.Gray;
            chartTemp.ChartAreas[0].BackColor = Color.Gray;
            chartTemp.Legends[0].BackColor = Color.Gray;
            chartHum.BackColor = Color.Gray;
            chartHum.ChartAreas[0].BackColor = Color.Gray;
            chartHum.Legends[0].BackColor = Color.Gray;
        }

        private void hardwareInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTechnicalInfo hardware = new FormTechnicalInfo();
            hardware.ShowDialog();
        }


        private void setIntervalToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkPoint = int.Parse(setIntervalToolStripComboBox.SelectedItem.ToString());
            toolStripStatusLabelinterval.Text = "Show interval: " + checkPoint.ToString();
            chartTemp.Series[0].Points.Clear();
            chartTemp.Update();
            chartHum.Series[0].Points.Clear();
            chartHum.Update();
            addPoint = 0;
        }
    }
}
