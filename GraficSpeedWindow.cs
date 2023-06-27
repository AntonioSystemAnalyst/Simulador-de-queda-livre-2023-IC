using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Program.corpo.NumberOfTerms > countGrafic)
            {
                result = (double)countGrafic / 100.0;
                chartSpeed.Series["Bóla"].Points.AddXY(result, Program.corpo.Velocity[countGrafic]);
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

        public void buildGrafic()
        {
            int speedDiv;
            double Y = 0.0;
            double X = 0.0;
            chartSpeed.Series.Clear();
           

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.corpo.FinalVelocity, 0) / 2);
                speedGraphic(Program.corpo.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.corpo.FinalVelocity, 0) / 2);
                speedGraphic(Program.corpo.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.paper.FinalVelocity, 0) / 2);

                speedGraphic(Program.paper.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.vaccum.FinalVelocity, 0) / 2);
                speedGraphic(Program.vaccum.NumberOfTerms, Y, 0, speedDiv, 0, X, 0, 0);
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
                        chartSpeed.Series["Bóla"].Points.AddXY(result, (Program.corpo.Velocity[i]));
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

            chartSpeed.Titles.Add("Velocidade pelo tempo");
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

        public void chartSpeed_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.openGraficsControl == 1)
            {
                windowSpeed = new Speed();
                windowSpeed.Show();
            }
        }

        // ---
    }
}
