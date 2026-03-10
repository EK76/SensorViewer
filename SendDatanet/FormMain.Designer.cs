namespace SendDatanet
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            labelTemp = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            smallViewToolStripMenuItem = new ToolStripMenuItem();
            normalViewToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            colorLineToolStripMenuItem = new ToolStripMenuItem();
            markerSizeToolStripMenuItem = new ToolStripMenuItem();
            size6ToolStripMenuItem = new ToolStripMenuItem();
            size8ToolStripMenuItem = new ToolStripMenuItem();
            size10ToolStripMenuItem = new ToolStripMenuItem();
            size12ToolStripMenuItem = new ToolStripMenuItem();
            size14ToolStripMenuItem = new ToolStripMenuItem();
            size16ToolStripMenuItem = new ToolStripMenuItem();
            noMarkerToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutSensorViewerToolStripMenuItem = new ToolStripMenuItem();
            chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartHum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            labelTime = new Label();
            labelHum = new Label();
            colorDialog1 = new ColorDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            maximazeToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartHum).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // labelTemp
            // 
            labelTemp.AutoSize = true;
            labelTemp.Font = new Font("Segoe UI", 14.25F);
            labelTemp.Location = new Point(12, 40);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new Size(0, 25);
            labelTemp.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1984, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { smallViewToolStripMenuItem, normalViewToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // smallViewToolStripMenuItem
            // 
            smallViewToolStripMenuItem.Name = "smallViewToolStripMenuItem";
            smallViewToolStripMenuItem.Size = new Size(180, 22);
            smallViewToolStripMenuItem.Text = "Tiny Screen";
            smallViewToolStripMenuItem.Click += smallViewToolStripMenuItem_Click;
            // 
            // normalViewToolStripMenuItem
            // 
            normalViewToolStripMenuItem.Checked = true;
            normalViewToolStripMenuItem.CheckState = CheckState.Checked;
            normalViewToolStripMenuItem.Name = "normalViewToolStripMenuItem";
            normalViewToolStripMenuItem.Size = new Size(180, 22);
            normalViewToolStripMenuItem.Text = "Normal Screen";
            normalViewToolStripMenuItem.Click += normalViewToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { colorLineToolStripMenuItem, markerSizeToolStripMenuItem, noMarkerToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // colorLineToolStripMenuItem
            // 
            colorLineToolStripMenuItem.Name = "colorLineToolStripMenuItem";
            colorLineToolStripMenuItem.Size = new Size(134, 22);
            colorLineToolStripMenuItem.Text = "Color Line";
            colorLineToolStripMenuItem.Click += colorLineToolStripMenuItem_Click;
            // 
            // markerSizeToolStripMenuItem
            // 
            markerSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { size6ToolStripMenuItem, size8ToolStripMenuItem, size10ToolStripMenuItem, size12ToolStripMenuItem, size14ToolStripMenuItem, size16ToolStripMenuItem });
            markerSizeToolStripMenuItem.Name = "markerSizeToolStripMenuItem";
            markerSizeToolStripMenuItem.Size = new Size(134, 22);
            markerSizeToolStripMenuItem.Text = "Marker Size";
            // 
            // size6ToolStripMenuItem
            // 
            size6ToolStripMenuItem.Name = "size6ToolStripMenuItem";
            size6ToolStripMenuItem.Size = new Size(86, 22);
            size6ToolStripMenuItem.Text = "6";
            size6ToolStripMenuItem.Click += size6ToolStripMenuItem_Click;
            // 
            // size8ToolStripMenuItem
            // 
            size8ToolStripMenuItem.Name = "size8ToolStripMenuItem";
            size8ToolStripMenuItem.Size = new Size(86, 22);
            size8ToolStripMenuItem.Text = "8";
            size8ToolStripMenuItem.Click += size8ToolStripMenuItem_Click;
            // 
            // size10ToolStripMenuItem
            // 
            size10ToolStripMenuItem.Checked = true;
            size10ToolStripMenuItem.CheckState = CheckState.Checked;
            size10ToolStripMenuItem.Name = "size10ToolStripMenuItem";
            size10ToolStripMenuItem.Size = new Size(86, 22);
            size10ToolStripMenuItem.Text = "10";
            size10ToolStripMenuItem.Click += size10ToolStripMenuItem_Click;
            // 
            // size12ToolStripMenuItem
            // 
            size12ToolStripMenuItem.Name = "size12ToolStripMenuItem";
            size12ToolStripMenuItem.Size = new Size(86, 22);
            size12ToolStripMenuItem.Text = "12";
            size12ToolStripMenuItem.Click += size12ToolStripMenuItem_Click;
            // 
            // size14ToolStripMenuItem
            // 
            size14ToolStripMenuItem.Name = "size14ToolStripMenuItem";
            size14ToolStripMenuItem.Size = new Size(86, 22);
            size14ToolStripMenuItem.Text = "14";
            size14ToolStripMenuItem.Click += size14ToolStripMenuItem_Click;
            // 
            // size16ToolStripMenuItem
            // 
            size16ToolStripMenuItem.Name = "size16ToolStripMenuItem";
            size16ToolStripMenuItem.Size = new Size(86, 22);
            size16ToolStripMenuItem.Text = "16";
            size16ToolStripMenuItem.Click += size16ToolStripMenuItem_Click;
            // 
            // noMarkerToolStripMenuItem
            // 
            noMarkerToolStripMenuItem.Name = "noMarkerToolStripMenuItem";
            noMarkerToolStripMenuItem.Size = new Size(134, 22);
            noMarkerToolStripMenuItem.Text = "No Marker";
            noMarkerToolStripMenuItem.Click += noMarkerToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutSensorViewerToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutSensorViewerToolStripMenuItem
            // 
            aboutSensorViewerToolStripMenuItem.Name = "aboutSensorViewerToolStripMenuItem";
            aboutSensorViewerToolStripMenuItem.Size = new Size(183, 22);
            aboutSensorViewerToolStripMenuItem.Text = "About Sensor Viewer";
            aboutSensorViewerToolStripMenuItem.Click += aboutSensorViewerToolStripMenuItem_Click;
            // 
            // chartTemp
            // 
            chartArea1.AxisX.LineColor = Color.Transparent;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 10D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisY.Maximum = 40D;
            chartArea1.AxisY.Minimum = -40D;
            chartArea1.Name = "ChartArea1";
            chartTemp.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTemp.Legends.Add(legend1);
            chartTemp.Location = new Point(12, 176);
            chartTemp.Name = "chartTemp";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.MarkerSize = 10;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Temperature";
            chartTemp.Series.Add(series1);
            chartTemp.Size = new Size(963, 473);
            chartTemp.TabIndex = 6;
            chartTemp.Text = "chart1";
            // 
            // chartHum
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.Maximum = 10D;
            chartArea2.AxisX.Minimum = 1D;
            chartArea2.AxisY.Maximum = 100D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            chartHum.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartHum.Legends.Add(legend2);
            chartHum.Location = new Point(1004, 176);
            chartHum.Name = "chartHum";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.MarkerSize = 10;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Humitidy";
            chartHum.Series.Add(series2);
            chartHum.Size = new Size(968, 473);
            chartHum.TabIndex = 7;
            chartHum.Text = "chart2";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 14.25F);
            labelTime.Location = new Point(12, 127);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(127, 25);
            labelTime.TabIndex = 8;
            labelTime.Text = "Current time: ";
            // 
            // labelHum
            // 
            labelHum.AutoSize = true;
            labelHum.Font = new Font("Segoe UI", 14.25F);
            labelHum.Location = new Point(12, 81);
            labelHum.Name = "labelHum";
            labelHum.Size = new Size(0, 25);
            labelHum.TabIndex = 9;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Ken's Sensor Data";
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { maximazeToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(128, 48);
            // 
            // maximazeToolStripMenuItem
            // 
            maximazeToolStripMenuItem.Name = "maximazeToolStripMenuItem";
            maximazeToolStripMenuItem.Size = new Size(127, 22);
            maximazeToolStripMenuItem.Text = "Maximaze";
            maximazeToolStripMenuItem.Click += maximazeToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(127, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1984, 661);
            Controls.Add(labelHum);
            Controls.Add(labelTime);
            Controls.Add(chartHum);
            Controls.Add(chartTemp);
            Controls.Add(labelTemp);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormMain";
            ShowIcon = false;
            Text = "SensorData Viewer";
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            Resize += FormMain_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartTemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartHum).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTemp;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutSensorViewerToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHum;
        private Label labelTime;
        private Label labelHum;
        private ToolStripMenuItem colorLineToolStripMenuItem;
        private ToolStripMenuItem markerSizeToolStripMenuItem;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem size6ToolStripMenuItem;
        private ToolStripMenuItem size8ToolStripMenuItem;
        private ToolStripMenuItem size10ToolStripMenuItem;
        private ToolStripMenuItem size12ToolStripMenuItem;
        private ToolStripMenuItem size14ToolStripMenuItem;
        private ToolStripMenuItem size16ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem noMarkerToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem maximazeToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem smallViewToolStripMenuItem;
        private ToolStripMenuItem normalViewToolStripMenuItem;
    }
}
