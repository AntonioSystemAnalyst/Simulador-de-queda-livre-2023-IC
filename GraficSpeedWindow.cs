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
        public GraficSpeedWindow()
        {
            InitializeComponent();
        }

        public void addPointCorpo(int countGrafic)
        {
            chartSpeed.Series["Bóla"].Points.AddXY(countGrafic, Program.corpo.Velocity[countGrafic]);
        }
        public void addPointPaper(int countGrafic)
        {
            chartSpeed.Series["Paper"].Points.AddXY(countGrafic, Program.corpo.Velocity[countGrafic]);
        }
        public void addPointVaccum(int countGrafic)
        {
            chartSpeed.Series["Objeto no vácuo"].Points.AddXY(countGrafic, Program.corpo.Velocity[countGrafic]);
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
            int spaceDiv;
            chartSpeed.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 2);

            if (Program.greatestValueTime == 0)
            {
                speedGraphic(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 1)
            {
                speedGraphic(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 2)
            {
                speedGraphic(Program.paper.NumberOfTerms, 0, Program.paper.FinalVelocity + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 3)
            {
                speedGraphic(Program.vaccum.NumberOfTerms, 0, Program.vaccum.FinalVelocity + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 0);
            }

        }

        public void speedGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx, int op)
        {
            int i;
            var chart = chartSpeed.ChartAreas[0];
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
                        chartSpeed.Series["Bóla"].Points.AddXY(i, Program.corpo.Velocity[i]);
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
                        chartSpeed.Series["Papel"].Points.AddXY(i, Program.paper.Velocity[i]);
                    }
                }
            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("Objeto no vácuo");
                chartSpeed.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        chartSpeed.Series["Objeto no vácuo"].Points.AddXY(i, Program.vaccum.Velocity[i]);
                    }
                }
            }
        }

        public void speedGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpeed.ChartAreas[0];

            chartSpeed.Titles.Add("Espaço pelo tempo");
            chartSpeed.ChartAreas[0].AxisX.Title = "T(s/100)";
            chartSpeed.ChartAreas[0].AxisY.Title = "S(m)";
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
                chartSpeed.Series.Add("Objeto no vácuo");
                chartSpeed.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Objeto no vácuo"].Points.AddXY(0, 0);
            }
        }

        // ---
    }
}
