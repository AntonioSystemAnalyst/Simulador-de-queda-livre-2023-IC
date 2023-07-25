using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace freeFall
{
    public partial class GraficSpaceWindow : Form
    {
        Space windowSpace;
        public GraficSpaceWindow()
        {
            InitializeComponent();
            //colorAll();
        }
        public void grafic3dSpace(int op)
        {
            if (op == 0)
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }

        public void addPointCorpo(int countGrafic)
        {
            double resultX;
            if (countGrafic < Program.ball.NumberOfTerms)
            {
                resultX = (double)countGrafic / 100.0;
                chartSpace.Series["Bola"].Points.AddXY(resultX, Program.ball.Space[countGrafic]);
            }
        }
        public void addPointPaper(int countGrafic)
        {
            double resultX;
            if (countGrafic < Program.paper.NumberOfTerms)
            {
                resultX = (double)countGrafic / 100.0;
                chartSpace.Series["Papel"].Points.AddXY(resultX, Program.paper.Space[countGrafic]);
            }
        }
        public void addPointVaccum(int countGrafic)
        {
            double resultX;
            if (countGrafic < Program.vaccum.NumberOfTerms)
            {
                resultX = (double)countGrafic / 100.0;
                chartSpace.Series["vácuo"].Points.AddXY(resultX, Program.vaccum.Space[countGrafic]);
            }
        }

        public void colorAll()
        {
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.Titles[0].ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
        }

        public void buildGrafic(int op)
        {
            int spaceDiv;
            double Y = 0.0;
            double X = 0.0;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 2);
                spaceGraphic(Program.ball.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 2);
                spaceGraphic(Program.ball.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 2);
                spaceGraphic(Program.paper.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 2);
                spaceGraphic(Program.vaccum.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, op);
            }
        }

        double CalculateValueWithTenPercent(double value)
        {
            double percentage = 0.05;
            double tenPercent = value * percentage;
            double result = value + tenPercent;
            return result;
        }

        public void spaceGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx, int op)
        {
            int i;
            var chart = chartSpace.ChartAreas[0];
            double resultX = 0.0;
            chartSpace.Series.Clear();
            chartSpace.Visible = true;
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Minimum = Mmx;
            chart.AxisX.Maximum = Max;
            chart.AxisY.Minimum = Mm;
            chart.AxisY.Maximum = MM;
            chart.AxisY.Interval = InterY;
            chart.AxisX.Interval = interX;

            if (Program.directionOfYaxis == 0)
            {
                chart.AxisY.IsReversed = true;
            }
            else
            {
                chart.AxisY.IsReversed = false;
            }

            chartSpace.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpace.Series.Add("Bola");
                chartSpace.Series["Bola"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bola"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        resultX = (double)i / 100.0;
                        if(i < Program.ball.NumberOfTerms)
                        {
                            chartSpace.Series["Bola"].Points.AddXY(resultX, Program.ball.Space[i]);
                        }
                    }
                }
            }
            if (Program.paperOn)
            {
                chartSpace.Series.Add("Papel");
                chartSpace.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Papel"].Color = Color.Blue;
                chartSpace.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        resultX = (double)i / 100.0;
                        chartSpace.Series["Papel"].Points.AddXY(resultX, Program.paper.Space[i]);
                    }
                }
            }
            if (Program.vaccumOn)
            {
                chartSpace.Series.Add("vácuo");
                chartSpace.Series["vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        resultX = (double)i / 100.0;
                        if (i < Program.vaccum.NumberOfTerms)
                        {
                            chartSpace.Series["vácuo"].Points.AddXY(resultX, Program.vaccum.Space[i]);
                        }
                    }
                }
            }
        }

        public void spaceGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpace.ChartAreas[0];

            chartSpace.Titles.Add("Espaço versus tempo").Docking = Docking.Bottom;
            chartSpace.Titles[0].Font = new Font(chartSpace.Titles[0].Font.FontFamily, chartSpace.Titles[0].Font.Size, FontStyle.Bold);
            chartSpace.ChartAreas[0].AxisX.Title = "t(s)";
            chartSpace.ChartAreas[0].AxisY.Title = "s(m)";
            chartSpace.Visible = true;
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Minimum = Mmx;
            chart.AxisX.Maximum = Max;
            chart.AxisY.Minimum = Mm;
            chart.AxisY.Maximum = MM;
            chart.AxisY.Interval = InterY;
            chart.AxisX.Interval = interX;

            chart.AxisX.TitleFont = new Font(chart.AxisX.TitleFont, FontStyle.Bold);
            chart.AxisY.TitleFont = new Font(chart.AxisY.TitleFont, FontStyle.Bold);
            chart.AxisX.LabelStyle.Font = new Font(chart.AxisX.LabelStyle.Font, FontStyle.Bold);
            chart.AxisY.LabelStyle.Font = new Font(chart.AxisY.LabelStyle.Font, FontStyle.Bold);

            

            chartSpace.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpace.Series.Add("Bola");
                chartSpace.Series["Bola"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bola"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;
                chartSpace.Series["Bola"].Points.AddXY(0, 0);

            }
            if (Program.paperOn)
            {
                chartSpace.Series.Add("Papel");
                chartSpace.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Papel"].Color = Color.Blue;
                chartSpace.Series[0].IsVisibleInLegend = false;
                chartSpace.Series["Papel"].Points.AddXY(0, 0);

            }
            if (Program.vaccumOn)
            {
                chartSpace.Series.Add("vácuo");
                chartSpace.Series["vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;
                chartSpace.Series["vácuo"].Points.AddXY(0, 0);
            }

        }
        public void closeAllWindow()
        {
            if (windowSpace != null)
            {
                windowSpace.Close();
                windowSpace.Dispose(); 
                windowSpace = null;
            }
        }
        private void chartSpace_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.openGraficsControl == 1)
            {
                if (Program.spaceGraficControl == 0)
                {
                    Program.spaceGraficControl = 1;
                    windowSpace = new Space();
                    windowSpace.Show();
                }
                if (Application.OpenForms["Space"] != null)
                {
                    if (Application.OpenForms["Space"].WindowState == FormWindowState.Minimized)
                    {
                        Application.OpenForms["Space"].WindowState = FormWindowState.Normal;
                    }
                    Application.OpenForms["Space"].Focus();
                }
            }
        }

        private void GraficSpaceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        private void GraficSpaceWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
