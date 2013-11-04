namespace GeneratingSetMonitor
{
    partial class ChartByPP
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartByPP));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_ChartShort = new System.Windows.Forms.Button();
            this.Btn_ChartLow = new System.Windows.Forms.Button();
            this.Btn_Resume = new System.Windows.Forms.Button();
            this.Btn_ChartBack = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(411, 378);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart1_GetToolTipText);
            this.chart1.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart1_AxisViewChanged_1);
            this.chart1.AxisScrollBarClicked += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ScrollBarEventArgs>(this.chart1_AxisScrollBarClicked);
            this.chart1.BindingContextChanged += new System.EventHandler(this.chart1_BindingContextChanged);
            this.chart1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chart1_KeyDown);
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseEnter += new System.EventHandler(this.chart1_MouseEnter);
            this.chart1.MouseHover += new System.EventHandler(this.chart1_MouseHover);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            this.chart1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.chart1_PreviewKeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.Btn_ChartShort);
            this.groupBox3.Controls.Add(this.Btn_ChartLow);
            this.groupBox3.Controls.Add(this.Btn_Resume);
            this.groupBox3.Controls.Add(this.Btn_ChartBack);
            this.groupBox3.Location = new System.Drawing.Point(3, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(44, 179);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // Btn_ChartShort
            // 
            this.Btn_ChartShort.Enabled = false;
            this.Btn_ChartShort.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ChartShort.Image")));
            this.Btn_ChartShort.Location = new System.Drawing.Point(2, 132);
            this.Btn_ChartShort.Name = "Btn_ChartShort";
            this.Btn_ChartShort.Size = new System.Drawing.Size(39, 39);
            this.Btn_ChartShort.TabIndex = 5;
            this.Btn_ChartShort.UseVisualStyleBackColor = true;
            this.Btn_ChartShort.Click += new System.EventHandler(this.BtnChartShort_Click);
            // 
            // Btn_ChartLow
            // 
            this.Btn_ChartLow.Enabled = false;
            this.Btn_ChartLow.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ChartLow.Image")));
            this.Btn_ChartLow.Location = new System.Drawing.Point(2, 93);
            this.Btn_ChartLow.Name = "Btn_ChartLow";
            this.Btn_ChartLow.Size = new System.Drawing.Size(39, 39);
            this.Btn_ChartLow.TabIndex = 4;
            this.Btn_ChartLow.UseVisualStyleBackColor = true;
            this.Btn_ChartLow.Click += new System.EventHandler(this.BtnChartLow_Click);
            // 
            // Btn_Resume
            // 
            this.Btn_Resume.Enabled = false;
            this.Btn_Resume.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Resume.Image")));
            this.Btn_Resume.Location = new System.Drawing.Point(2, 15);
            this.Btn_Resume.Name = "Btn_Resume";
            this.Btn_Resume.Size = new System.Drawing.Size(39, 39);
            this.Btn_Resume.TabIndex = 3;
            this.Btn_Resume.UseVisualStyleBackColor = true;
            this.Btn_Resume.Click += new System.EventHandler(this.BtnChartResume_Click);
            // 
            // Btn_ChartBack
            // 
            this.Btn_ChartBack.Enabled = false;
            this.Btn_ChartBack.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ChartBack.Image")));
            this.Btn_ChartBack.Location = new System.Drawing.Point(2, 54);
            this.Btn_ChartBack.Name = "Btn_ChartBack";
            this.Btn_ChartBack.Size = new System.Drawing.Size(39, 39);
            this.Btn_ChartBack.TabIndex = 0;
            this.Btn_ChartBack.UseVisualStyleBackColor = true;
            this.Btn_ChartBack.Click += new System.EventHandler(this.BtnChartBack_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 356);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(411, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1ff ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel1.Text = "此处显示鼠标点击位置对应的值";
            // 
            // ChartByPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chart1);
            this.Name = "ChartByPP";
            this.Size = new System.Drawing.Size(411, 378);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_ChartShort;
        private System.Windows.Forms.Button Btn_ChartLow;
        private System.Windows.Forms.Button Btn_Resume;
        private System.Windows.Forms.Button Btn_ChartBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}
