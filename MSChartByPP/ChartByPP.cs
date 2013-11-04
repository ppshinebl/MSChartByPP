using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace GeneratingSetMonitor
{
    public partial class ChartByPP : UserControl
    { 
        #region 图表拖动
        Double chartPositionX = 0;
        bool dragingChart = false;
        Double chartPositionY = 0;
        int mouseX = -1;
        int mouseY = -1;
        string chartName;
        #endregion
        double positionXBeforeMove = 0;
        double positionYBeforeMove = 0;
        #region 鼠标经过，突出显示
        string mouseMovePassSeries;
        #endregion
        public ChartByPP()
        {       
            InitializeComponent();
            
            chart1.MouseWheel += new MouseEventHandler(chart1_MouseWheel);

            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorX.LineWidth = 1;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.LineWidth = 1;
      
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].AxisX.Title = "X轴";
            chart1.ChartAreas[0].AxisY.Title = "Y轴";
            chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Near;
            chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;
            chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            //图表光标定位
            chart1.CursorPositionChanged += new EventHandler<CursorEventArgs>((sender, e) =>
            {
                if (e.Axis.AxisName == AxisName.X)
                {
                    //label4.Text = e.NewPosition.ToString();
                    chartPositionX = e.NewPosition;
                }
                else if (e.Axis.AxisName == AxisName.Y)
                {
                   // label5.Text = e.NewPosition.ToString(); 
                    chartPositionY = e.NewPosition;
                }
                this.toolStripStatusLabel1.Text = string.Format("当前光标位置X轴为{0}，Y轴为{1}",chartPositionX,chartPositionY);
            });      
        }
        private void chart1_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                switch (e.KeyData)
                {
                    case Keys.Enter: BtnChartBack_Click(null, null); break;
                    case Keys.Right: chart1.ChartAreas[i].AxisX.ScaleView.Position -= (int)chart1.ChartAreas[i].AxisX.ScaleView.Size / 3; break;
                    case Keys.Left: chart1.ChartAreas[i].AxisX.ScaleView.Position += (int)chart1.ChartAreas[i].AxisX.ScaleView.Size / 3; break;
                    case Keys.Up: chart1.ChartAreas[i].AxisY.ScaleView.Position -= (int)chart1.ChartAreas[i].AxisY.ScaleView.Size / 3; break;
                    case Keys.Down: chart1.ChartAreas[i].AxisY.ScaleView.Position += (int)chart1.ChartAreas[i].AxisY.ScaleView.Size / 3; break;
                }
            }
        }
        /// <summary>
        /// 使得上下左右键能作为输入被mschart控件所获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Right || e.KeyData == Keys.Left || e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        /// <summary>
        /// 鼠标右键按下，准备好拖动图表的数据；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                if (double.IsNaN(this.chart1.ChartAreas[i].AxisX.ScaleView.Size))
                    this.chart1.ChartAreas[i].AxisX.ScaleView.Size = this.chart1.ChartAreas[i].AxisX.ScaleView.ViewMaximum - this.chart1.ChartAreas[i].AxisX.ScaleView.ViewMinimum;
                if (double.IsNaN(this.chart1.ChartAreas[i].AxisY.ScaleView.Size))
                    this.chart1.ChartAreas[i].AxisY.ScaleView.Size = this.chart1.ChartAreas[i].AxisY.ScaleView.ViewMaximum - this.chart1.ChartAreas[i].AxisY.ScaleView.ViewMinimum;
            }
            if (e.Button == MouseButtons.Right)
            {
                ((Control)sender).Cursor = Cursors.SizeAll;
                this.dragingChart = true;
                this.mouseX = e.X;
                this.mouseY = e.Y;
                HitTestResult result = chart1.HitTest(e.X, e.Y);
                this.chartName = result.ChartArea.Name;
                this.positionXBeforeMove = this.chart1.ChartAreas[this.chartName].AxisX.ScaleView.Position;
                this.positionYBeforeMove = this.chart1.ChartAreas[this.chartName].AxisY.ScaleView.Position;                
            }
            else if (e.Button == MouseButtons.Left)
            {
                //HitTestResult result = chart1.HitTest(e.X, e.Y);

                //var area = result.ChartArea.Name;
                //for (int i = 0; i < chart1.ChartAreas.Count; i++) {
                //    if (area != chart1.ChartAreas[i].Name) { 
                 

                //    }
                //}

                //if (result.ChartElementType != ChartElementType.DataPoint)
                //    return;
                //var dp = (DataPoint)result.Object;
             //   this.label7.Text = string.Format("X轴：{0},Y轴：{1}", dp.XValue, dp.YValues[0]);

            }
            ValidateButtonState();
        }
        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Right)
                this.dragingChart = false;
        }
        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            this.dragingChart = false;
        }
        /// <summary>
        /// 图表拖动，重定位数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!chart1.Focused)chart1.Focus();
            if (dragingChart)
            {
                int relativX = e.X - mouseX;
                int relativY = e.Y - mouseY;
                chart1.ChartAreas[chartName].AxisX.ScaleView.Position = this.positionXBeforeMove - (int)chart1.ChartAreas[chartName].AxisX.ScaleView.Size * relativX / 1000;
                chart1.ChartAreas[chartName].AxisY.ScaleView.Position = this.positionYBeforeMove + (int)chart1.ChartAreas[chartName].AxisY.ScaleView.Size * relativY / 1000;
                var cursor = ((Control)sender).Cursor;
                if (sender != null&&!cursor.Equals(Cursors.SizeAll)) cursor = Cursors.SizeAll;
            }
            else
            {
                //Point p = ((Control)chart1).PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
               // this.toolStripStatusLabel1.Text = e.X + " " + e.Y + ";" + p.X + " " + p.Y;
                HitTestResult result = chart1.HitTest(e.X, e.Y);
                // Application.DoEvents();
                if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.LegendItem)
                {
                    if (!string.IsNullOrEmpty(this.mouseMovePassSeries))
                    {
                        chart1_SeriesSelectedNormal();
                    }
                    string seriesname;
                    if (result.ChartElementType == ChartElementType.DataPoint)
                        seriesname = ((DataPoint)(result.Object)).GetCustomProperty("SeriesName");
                    else
                        seriesname = ((LegendItem)(result.Object)).SeriesName;
                    this.mouseMovePassSeries = seriesname;
                    if (string.IsNullOrEmpty(seriesname)) return;
                    try
                    {
                        var series = this.chart1.Series.FindByName(seriesname);
                        if (series == null) return;

                        // series.Color = this.mouseMoveStressColor;
                        series.BorderWidth += 2;
                        if (series.MarkerSize > 0) series.MarkerSize += 2;
                    }
                    catch { }
                }
            }
        }
        private void chart1_SeriesSelectedNormal() {
            try
            {
                if (!string.IsNullOrEmpty(this.mouseMovePassSeries))
                {
                    if (this.chart1 == null || this.chart1.Series == null) return;
                    var seriesbf = this.chart1.Series.FindByName(this.mouseMovePassSeries);
                    if (seriesbf == null) { this.mouseMovePassSeries = null; return; }
                    seriesbf.MarkerStyle = MarkerStyle.Square;
                    if (seriesbf.BorderWidth > 2) seriesbf.BorderWidth -= 2;
                    if (seriesbf.MarkerSize > 2) seriesbf.MarkerSize -= 2;
                    this.mouseMovePassSeries = null;
                }
            }
            catch { }
        }
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.WaitCursor;
            //Win32.User.mouse_event(Win32.User.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //Thread.Sleep(50);
            //Win32.User.mouse_event(Win32.User.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //this.label1.Text = "滚轮" + e.Delta;
            this.chart1.ChartAreas[0].AxisX.ScaleView.Size = this.chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum - this.chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            this.chart1.ChartAreas[0].AxisY.ScaleView.Size = this.chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum - this.chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
            double xPercent = (this.chartPositionX - this.chart1.ChartAreas[0].AxisX.ScaleView.Position) / this.chart1.ChartAreas[0].AxisX.ScaleView.Size;
            double yPercent = (this.chartPositionY - this.chart1.ChartAreas[0].AxisY.ScaleView.Position) / this.chart1.ChartAreas[0].AxisY.ScaleView.Size;
            chart1.ChartAreas[0].AxisX.ScaleView.Size -= e.Delta / 1200.0 * chart1.ChartAreas[0].AxisX.ScaleView.Size;
            chart1.ChartAreas[0].AxisY.ScaleView.Size -= e.Delta / 1200.0 * chart1.ChartAreas[0].AxisY.ScaleView.Size;
            chart1.ChartAreas[0].AxisX.ScaleView.Position = Math.Round(this.chartPositionX - chart1.ChartAreas[0].AxisX.ScaleView.Size * xPercent);
            chart1.ChartAreas[0].AxisY.ScaleView.Position = Math.Round(this.chartPositionY - chart1.ChartAreas[0].AxisY.ScaleView.Size * yPercent);
            ValidateButtonState();
            ((Control)sender).Cursor = Cursors.Default;
        }
        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                chart1_MouseWheel(sender, new MouseEventArgs(MouseButtons.Middle, 0, e.X, e.Y, 120 * 3));
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            ValidateButtonState();
        }

        private void BtnChartBack_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            ValidateButtonState();
        }
        private void BtnChartResume_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                chart1.ChartAreas[i].AxisX.ScaleView.ZoomReset(100);
                chart1.ChartAreas[i].AxisY.ScaleView.ZoomReset(100);
                if (chart1.ChartAreas[i].AxisX.ScaleView.IsZoomed) chart1.ChartAreas[i].AxisX.ScaleView.ZoomReset(100);
                if (chart1.ChartAreas[i].AxisY.ScaleView.IsZoomed) chart1.ChartAreas[i].AxisY.ScaleView.ZoomReset(100);
            }
            //chart1.Serializer.Load(stream);
            //stream.Close();
            //stream = new MemoryStream();

            //chart1.Serializer.Content = SerializationContents.Default;
            //chart1.Serializer.Save(stream);
            ValidateButtonState();
        }
        private void BtnChartLow_Click(object sender, EventArgs e)
        {
            //this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                if (this.chart1.ChartAreas[i].AxisY.ScaleView.IsZoomed)
                {
                    var size = this.chart1.ChartAreas[i].AxisY.ScaleView.Size;
                Shorten:  this.chart1.ChartAreas[i].AxisY.ScaleView.ZoomReset();
                var afterSize = this.chart1.ChartAreas[i].AxisY.ScaleView.Size;
                if (afterSize < size) goto Shorten;
                }
            }
            ValidateButtonState();
        }
        private void BtnChartShort_Click(object sender, EventArgs e)
        {
            if (this.chart1.ChartAreas[0].AxisX.ScaleView.IsZoomed)
            {
                var size = this.chart1.ChartAreas[0].AxisX.ScaleView.Size;              
            Shorten: var afterSize = this.chart1.ChartAreas[0].AxisX.ScaleView.Size;
            this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            if (afterSize < size) goto Shorten;
                ValidateButtonState();
            }
            //this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        }

        public void ValidateButtonState()
        {
            if (this.chart1.ChartAreas[0].AxisX.ScaleView.IsZoomed || this.chart1.ChartAreas[0].AxisY.ScaleView.IsZoomed)
            {
                this.Btn_ChartBack.Enabled = true;
                this.Btn_Resume.Enabled = true;
            }
            else
            {
                this.Btn_Resume.Enabled = false;
                this.Btn_ChartBack.Enabled = false;
            }
            if (this.chart1.ChartAreas[0].AxisX.ScaleView.IsZoomed) this.Btn_ChartShort.Enabled = true;
            else this.Btn_ChartShort.Enabled = false;
            bool yzoomed=false;
            for(int i=0;i<chart1.ChartAreas.Count;i++){
            yzoomed=yzoomed||this.chart1.ChartAreas[0].AxisY.ScaleView.IsZoomed;
            }
                this.Btn_ChartLow.Enabled = yzoomed;
          
        }

        private void chart1_BindingContextChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 100;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;
            for (int i = 0; i < chart1.Series.Count; i++) {
                chart1.Series[i].ChartType = SeriesChartType.Spline;
                chart1.Series[i].BorderWidth = 2;
                this.chart1.Series[i].SetCustomProperty("SeriesName", this.chart1.Series[i].Name);
            }
            this.mouseMovePassSeries = null;
            ValidateButtonState();
        }
        private void chart1_AxisViewChanged_1(object sender, ViewEventArgs e)
        {
            ValidateButtonState();
        }
        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint) {
                DataPoint point = (DataPoint)e.HitTestResult.Object;
                e.Text = "";
            }
            //switch (e.HitTestResult.ChartElementType)
            //{
            //    case ChartElementType.Axis:
            //        e.Text = e.HitTestResult.Axis.Name;
            //        break;
            //    case ChartElementType.ScrollBarLargeDecrement:
            //        e.Text = "A scrollbar large decrement button";
            //        break;
            //    case ChartElementType.ScrollBarLargeIncrement:
            //        e.Text = "A scrollbar large increment button";
            //        break;
            //    case ChartElementType.ScrollBarSmallDecrement:
            //        e.Text = "A scrollbar small decrement button";
            //        break;
            //    case ChartElementType.ScrollBarSmallIncrement:
            //        e.Text = "A scrollbar small increment button";
            //        break;
            //    case ChartElementType.ScrollBarThumbTracker:
            //        e.Text = "A scrollbar tracking thumb";
            //        break;
            //    case ChartElementType.ScrollBarZoomReset:
            //        e.Text = "The ZoomReset button of a scrollbar";
            //        break;
            //    case ChartElementType.DataPoint:
            //        e.Text = "Data Point " + e.HitTestResult.PointIndex.ToString();
            //        break;
            //    case ChartElementType.Gridlines:
            //        e.Text = "Grid Lines";
            //        break;
            //    case ChartElementType.LegendArea:
            //        e.Text = "Legend Area";
            //        break;
            //    case ChartElementType.LegendItem:
            //        e.Text = "Legend Item";
            //        break;
            //    case ChartElementType.PlottingArea:
            //        e.Text = "Plotting Area";
            //        break;
            //    case ChartElementType.StripLines:
            //        e.Text = "Strip Lines";
            //        break;
            //    case ChartElementType.TickMarks:
            //        e.Text = "Tick Marks";
            //        break;
            //    case ChartElementType.Title:
            //        e.Text = "Title";
            //        break;
            //}

        }
        private void chart1_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
        {
         
        }
        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            this.chart1.Focus();
        }
        private void chart1_MouseHover(object sender, EventArgs e)
        {    
            //Point p = ((Control)chart1).PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            //HitTestResult result = chart1.HitTest(p.X, p.Y);
            //if (result.ChartElementType == ChartElementType.PlottingArea) return;
            //if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.LegendItem)
            //{
            //    if (!string.IsNullOrEmpty(this.mouseMovePassSeries))
            //    {
            //        chart1_SeriesSelectedNormal();
            //    }
            //    string seriesname;
            //    if (result.ChartElementType == ChartElementType.DataPoint)
            //        seriesname = ((DataPoint)(result.Object)).GetCustomProperty("SeriesName");
            //    else
            //        seriesname = ((LegendItem)(result.Object)).SeriesName;
            //    this.mouseMovePassSeries = seriesname;
            //    if (string.IsNullOrEmpty(seriesname)) return;
            //    try
            //    {
            //        var series = this.chart1.Series.FindByName(seriesname);
            //        if (series == null) return;
            //        series.BorderWidth += 2;
            //        if (series.MarkerSize > 0) series.MarkerSize += 2;
            //    }
            //    catch { }
            //}
        }
    }
}
