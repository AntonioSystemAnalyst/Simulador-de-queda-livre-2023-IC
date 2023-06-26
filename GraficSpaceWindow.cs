using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void GraficSpaceWindow_Load(object sender, EventArgs e)
        {

        }

        public void grafic3dSpace(int op)
        {
            if(op == 0)
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
            int resultY;
            if (countGrafic <= Program.corpo.NumberOfTerms && countGrafic != 0)
            {
                resultX = (double)countGrafic / 100.0;
                resultY = Program.corpo.Space.Length - countGrafic;
                chartSpace.Series["Bóla"].Points.AddXY(resultX, Program.corpo.Space[resultY]);
            }
        }
        public void addPointPaper(int countGrafic)
        {
            double resultX;
            int resultY;
            if (countGrafic <= Program.paper.NumberOfTerms && countGrafic != 0)
            {
                resultX = (double)countGrafic / 100.0;
                resultY = Program.paper.Space.Length - countGrafic;
                chartSpace.Series["Papel"].Points.AddXY(resultX, Program.paper.Space[resultY]);
            }
        }
        public void addPointVaccum(int countGrafic)
        {
            double resultX;
            int resultY;
            if (countGrafic <= Program.vaccum.NumberOfTerms && countGrafic != 0)
            {
                resultX = (double)countGrafic / 100.0;
                resultY = Program.vaccum.Space.Length - countGrafic;
                chartSpace.Series["vácuo"].Points.AddXY(resultX, Program.vaccum.Space[resultY]);
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

        public void buildGrafic()
        {
            int spaceDiv;
            double Y = 0.0;
            double X = 0.0;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 2);

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                spaceGraphic(Program.corpo.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                spaceGraphic(Program.corpo.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                spaceGraphic(Program.paper.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, 0);
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                spaceGraphic(Program.vaccum.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0, 0);
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
            int resultY = 0;
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

            chartSpace.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpace.Series.Add("Bóla");
                chartSpace.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bóla"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        resultX = (double)i/ 100.0;
                        resultY = Program.corpo.Space.Length - i;
                        chartSpace.Series["Bóla"].Points.AddXY(resultX, Program.corpo.Space[resultY]);
                      
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
                        chartSpace.Series["Papel"].Points.AddXY(resultX, Program.paper.Space[Program.paper.Space.Length-i]);
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
                        chartSpace.Series["vácuo"].Points.AddXY(resultX, Program.vaccum.Space[Program.vaccum.Space.Length-i]);
                    }
                }
            }
        }

        public void spaceGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpace.ChartAreas[0];

            chartSpace.Titles.Add("Espaço pelo tempo");
            chartSpace.ChartAreas[0].AxisX.Title = "T(s)";
            chartSpace.ChartAreas[0].AxisY.Title = "S(m)";
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

            chartSpace.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpace.Series.Add("Bóla");
                chartSpace.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bóla"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;
                chartSpace.Series["Bóla"].Points.AddXY(0, 0);

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

        private void chartSpace_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.openGraficsControl == 1)
            {
                windowSpace = new Space();
                windowSpace.Show();
            }
        }
    }
}
