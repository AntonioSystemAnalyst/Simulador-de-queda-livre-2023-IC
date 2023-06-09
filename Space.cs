using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.LinkLabel;

namespace freeFall
{
    public partial class Space : Form
    {
        public static string dirSalvar = "";
        public static string dirAbrir = "";
        public static string TxtBar = "";
        public static int OpSalve = 0;

        string[] linha = new string[1000];
        string[] timeLarge;
        public Space()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            checkBox3D.Checked = true;
            buildGrafic();
            dataGridConfigure();
            toComplete();
        }

        private void Space_Load(object sender, EventArgs e)
        {
            dataGridView.CurrentCell = null;
        }
        private void toComplete()
        {
            int i;

            for (i = 0; i < Program.numberOfPoints; i++)
            {
                linha[0] = timeLarge[i];
                if (Program.bodyOn)
                {
                    if(Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                    {
                        linha[1] = Convert.ToString(Math.Round(Program.corpo.Space[i], 3));
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                    {
                        linha[2] = Convert.ToString(Math.Round(Program.paper.Space[i], 3));
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                    {
                        linha[3] = Convert.ToString(Math.Round(Program.vaccum.Space[i], 3));
                    }
                }

                dataGridView.Rows.Add(linha);
            }
        }
        public void dataGridConfigure()
        {
            dataGridView.BackgroundColor = Color.Black;
            dataGridView.DefaultCellStyle.BackColor = Color.Black;
            dataGridView.GridColor = Color.Cyan;
            dataGridView.DefaultCellStyle.ForeColor = Color.Cyan;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
        }

        public void graficContinuosSpace(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            var chart = chartSpace.ChartAreas[0];

            chartSpace.Visible = true;


            chartSpace.Titles.Add("Espaço pelo tempo");

            chartSpace.ChartAreas[0].AxisX.Title = "T(segundos/100)";
            chartSpace.ChartAreas[0].AxisY.Title = "S(metros)";

            chartSpace.Titles[0].ForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisX.TitleForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisY.TitleForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;

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

                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    chartSpace.Series["Bóla"].Points.AddXY((i), Program.corpo.Space[i]);
                }
            }
            if(Program.paperOn)
            {
                chartSpace.Series.Add("Papel");
                chartSpace.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Papel"].Color = Color.Blue;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    chartSpace.Series["Papel"].Points.AddXY((i), Program.paper.Space[i]);
                }
            }
            if(Program.vaccumOn)
            {
                chartSpace.Series.Add("Objeto no vácuo");
                chartSpace.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    chartSpace.Series["Objeto no vácuo"].Points.AddXY((i), Program.vaccum.Space[i]);
                }
            }
        }

        public void buildGrafic()
        {
            int spaceDiv, i;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);

            if(Program.greatestValueTime == 0)
            {
                graficContinuosSpace(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i=0; i<Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 1)
            {
                graficContinuosSpace(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 2)
            {
                graficContinuosSpace(Program.paper.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 3)
            {
                graficContinuosSpace(Program.vaccum.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.vaccum.NumberOfTerms];
                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.vaccum.SpaceTime[i]);
                }
            }
        }


        private void SalveImage_Click(object sender, EventArgs e)
        {
                SaveImage(chartSpace);
        }

        private void SalveTXT_Click(object sender, EventArgs e)
        {
                salveTxt();
        }

        private void SalveXLS_Click(object sender, EventArgs e)
        {

        }
        private void SaveImage(Chart chart)
        {
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivos de Imagem|*.png;*.jpg;*.bmp|Todos os arquivos|*.*";
                saveFileDialog.Title = "Salvar Gráfico como Imagem";
                saveFileDialog.FileName = "Queda dos corpos.Gráfico SxT-" + dataHoraString;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ChartImageFormat imageFormat;
                    string extensao = System.IO.Path.GetExtension(saveFileDialog.FileName);

                    switch (extensao.ToLower())
                    {
                        case ".png":
                            imageFormat = ChartImageFormat.Png;
                            break;
                        case ".jpg":
                        case ".jpeg":
                            imageFormat = ChartImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            imageFormat = ChartImageFormat.Bmp;
                            break;
                        default:
                            MessageBox.Show("Formato de arquivo inválido!");
                            return;
                    }

                    chart.SaveImage(saveFileDialog.FileName, imageFormat);
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }

        public void salveTxt()
        {
            string FileLocal = dirSalvar;
            int i, j;
           
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                dirSalvar = "";
                sfdSalve.FileName = "Queda dos corpos.Resultados-"+dataHoraString;
                sfdSalve.Title = "Salvar Documento"; 
                sfdSalve.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*";
                if (sfdSalve.ShowDialog() == DialogResult.OK)
                {
                    dirSalvar = sfdSalve.FileName;
                    using (StreamWriter writer = new StreamWriter(dirSalvar, false))
                    {
                        writer.Flush();
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Simulador de queda Livre");
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Nome       : " + Program.planetName);
                        writer.WriteLine(" Gravidade  : " + Program.gravity + " m/s²");
                        if(Program.airResistance == 0)
                        {
                            writer.WriteLine(" Resis. ar  : Não");
                        }
                        else 
                        {
                            writer.WriteLine(" Resis. ar  : Sim");
                        }
                       
                        writer.WriteLine(" Tempo para a bóla           : " + Program.corpo.TimeAllExperiment + " s");
                        writer.WriteLine(" Velocidade inicial da bóla  : " + Program.corpo.InitialVelocity + " m/s");
                        writer.WriteLine(" Velocidade final da bóla    : " + Program.corpo.FinalVelocity + " m/s");
                        if (Program.paperOn)
                        {
                            writer.WriteLine(" Tempo para o papel          : " + Program.paper.TimeAllExperiment + " s");
                            writer.WriteLine(" Velocidade inicial do papel : " + Program.paper.InitialVelocity + " m/s");
                            writer.WriteLine(" Velocidade final do papel   : " + Program.paper.FinalVelocity + " m/s");

                        }
                        if (Program.vaccumOn)
                        {
                            writer.WriteLine(" Tempo para o vácuo          : " + Program.vaccum.TimeAllExperiment + " s");
                            writer.WriteLine(" Velocidade inicial no vácuo : " + Program.vaccum.InitialVelocity + " m/s");
                            writer.WriteLine(" Velocidade final no vácuo   : " + Program.vaccum.FinalVelocity + " m/s");

                        }
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Resultados  ");
                        writer.WriteLine(" ----------------------------------------- ");

                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i];
                            if (Program.bodyOn)
                            {
                                if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.corpo.Space[i], 3));
                                }
                                else
                                {
                                    linha[1] = "-";
                                }
                            }
                            if (Program.paperOn)
                            {
                                if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[2] = Convert.ToString(Math.Round(Program.paper.Space[i], 3));
                                }
                                else
                                {
                                    linha[2] = "-";
                                }
                            }
                            if (Program.vaccumOn)
                            {
                                if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[3] = Convert.ToString(Math.Round(Program.vaccum.Space[i], 3));
                                }
                                else
                                {
                                    linha[3] = "-";
                                }
                            }
                            if(Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                            }
                            else
                            {
                                if(Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}]");
                                }
                                else
                                {
                                    if(Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                    {
                                        writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                                    }
                                    else
                                    {
                                        writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}]");
                                    }
                                }
                            }
                            
                        }
                        writer.WriteLine(" ----------------------------------------- ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            SalveImage.Focus();
            timerFocus.Enabled = false;
        }

        private void checkBox3D_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3D.Checked)
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }
    }
}
