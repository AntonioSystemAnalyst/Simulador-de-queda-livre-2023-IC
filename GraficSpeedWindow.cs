using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace freeFall
{
    public partial class GraficSpeedWindow : Form
    {
        Speed windowSpeed;

        public GraficSpeedWindow()
        {
            InitializeComponent();
        }

        public void grafic3dSpeed(int op)
        {
            if (op == 0)
            {
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }

        public void addPointCorpo(int countGrafic)
        {
            double result;
            if (Program.ball.NumberOfTerms > countGrafic)
            {
                result = (double)countGrafic / 100.0;
                chartSpeed.Series["Bóla"].Points.AddXY(result, Program.ball.Velocity[countGrafic]);
            }
        }
        public void addPointPaper(int countGrafic)
        {
            double result;
            if (Program.paper.NumberOfTerms > countGrafic)
            {
                result = (double)countGrafic / 100.0;
                chartSpeed.Series["Papel"].Points.AddXY(result, Program.paper.Velocity[countGrafic]);
            }

        }
        public void addPointVaccum(int countGrafic)
        {
            double result;
            if (Program.vaccum.NumberOfTerms > countGrafic)
            {
                result = (double)countGrafic / 100.0;
                chartSpeed.Series["vácuo"].Points.AddXY(result, Program.vaccum.Velocity[countGrafic]);
            }
        }

        public void colorAll()
        {
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.Titles[0].ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
        }

        public void buildGrafic(int op)
        {
            int speedDiv;
            double Y = 0.0;
            double X = 0.0;
            
            chartSpeed.Series.Clear();

            speedDiv = Convert.ToInt32(Math.Round((-1 * Program.greatestValueVelocity), 0) / 5);

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 2);

                speedGraphic(Program.ball.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 2);
                speedGraphic(Program.ball.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 2);
                speedGraphic(Program.paper.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, op);
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 2);
                speedGraphic(Program.vaccum.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, op);
            }
        }

        public double CalculateValueWithTenPercent(double value)
        {
            double percentage = 0.05;
            double tenPercent = value * percentage;
            double result = value + tenPercent;
            Console.WriteLine("RESULT" + result);
            return result;
        }

        public void speedGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx, int op)
        {
            int i;
            var chart = chartSpeed.ChartAreas[0];
            double result = 0.0;
            chartSpeed.Series.Clear();
            chartSpeed.Visible = true;
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

            chartSpeed.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpeed.Series.Add("Bóla");
                chartSpeed.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bóla"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        result = (double)i / 100.0;
                        chartSpeed.Series["Bóla"].Points.AddXY(result, (Program.ball.Velocity[i]));
                    }
                }
            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        result = (double)i / 100.0;
                        chartSpeed.Series["Papel"].Points.AddXY(result, (Program.paper.Velocity[i]));
                    }
                }
            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("vácuo");
                chartSpeed.Series["vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        result = (double)i / 100.0;
                        chartSpeed.Series["vácuo"].Points.AddXY(result, (Program.vaccum.Velocity[i]));
                    }
                }
            }
        }

        public void speedGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpeed.ChartAreas[0];

            chartSpeed.Titles.Add("Velocidade pelo tempo").Docking = Docking.Bottom;
            chartSpeed.Titles[0].Font = new Font(chartSpeed.Titles[0].Font.FontFamily, chartSpeed.Titles[0].Font.Size, FontStyle.Bold);
            chartSpeed.ChartAreas[0].AxisX.Title = "T(s)";
            chartSpeed.ChartAreas[0].AxisY.Title = "V(m/s)";
            chartSpeed.Visible = true;
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

            chartSpeed.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpeed.Series.Add("Bóla");
                chartSpeed.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bóla"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Bóla"].Points.AddXY(0, 0);

            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Papel"].Points.AddXY(0, 0);

            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("vácuo");
                chartSpeed.Series["vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["vácuo"].Points.AddXY(0, 0);
            }
        }

        public void closeAllWindow()
        {
            if (windowSpeed != null)
            {
                windowSpeed.Close();
                windowSpeed.Dispose();
                windowSpeed = null;
            }
        }
        public void chartSpeed_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.openGraficsControl == 1)
            {

                if (Program.speedGraficControl == 0)
                {
                    Program.speedGraficControl = 1;
                    windowSpeed = new Speed();
                    windowSpeed.Show();
                }
            }
            if (Application.OpenForms["Speed"] != null)
            {
                if (Application.OpenForms["Speed"].WindowState == FormWindowState.Minimized)
                {
                    Application.OpenForms["Speed"].WindowState = FormWindowState.Normal;
                }
                Application.OpenForms["Speed"].Focus();
            }
        }
        // ---
    }
}
