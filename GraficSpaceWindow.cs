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
            if (countGrafic <= Program.corpo.NumberOfTerms)
            {
                chartSpace.Series["Bóla"].Points.AddXY(countGrafic, Program.corpo.Space[countGrafic]);
            }
        }
        public void addPointPaper(int countGrafic)
        {
            if(countGrafic <= Program.paper.NumberOfTerms)
            {
                chartSpace.Series["Papel"].Points.AddXY(countGrafic, Program.paper.Space[countGrafic]);
            }
        }
        public void addPointVaccum(int countGrafic)
        {
            if (countGrafic <= Program.vaccum.NumberOfTerms)
            {
                chartSpace.Series["vácuo"].Points.AddXY(countGrafic, Program.vaccum.Space[countGrafic]);
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
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 2);

            if (Program.greatestValueTime == 0)
            {
                spaceGraphic(Program.corpo.NumberOfTerms, 0, Program.height, spaceDiv, Convert.ToInt32(((Program.corpo.TimeAllExperiment))/4), ((Program.corpo.TimeAllExperiment)), 0, 0);
            }
            if (Program.greatestValueTime == 1)
            {
                spaceGraphic(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 2)
            {
                spaceGraphic(Program.paper.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 3)
            {
                spaceGraphic(Program.vaccum.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 0);
            }

        }

        public void spaceGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx, int op)
        {
            int i;
            var chart = chartSpace.ChartAreas[0];
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
                        chartSpace.Series["Bóla"].Points.AddXY(i, Program.corpo.Space[i]);                   
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
                        chartSpace.Series["Papel"].Points.AddXY(i, Program.paper.Space[i]);
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
                        chartSpace.Series["vácuo"].Points.AddXY(i, Program.vaccum.Space[i]);
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

        // ---
    }
}
