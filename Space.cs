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
        public static string FName = "";
        public static int OpSalve = 0;

        string[] linha = new string[1000];
        public Space()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            checkBox3D.Checked = true;
            buildGrafic();
            Preencher();
        }

        private void Space_Load(object sender, EventArgs e)
        {

        }
        private void Preencher()
        {
            int G = 1, P = 1;

            for (int i = 0; i < 1000; i++)
            {

                linha[0] = Convert.ToString(G);
                linha[1] = Convert.ToString(P);
                linha[2] = Convert.ToString(G);
                linha[3] = Convert.ToString(G);
                dataGridView.Rows.Add(linha);
                P += 1;
            }

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
            int spaceDiv;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);

            if(Program.greatestValueTime == 0)
            {
                graficContinuosSpace(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
            }
            if (Program.greatestValueTime == 1)
            {
                graficContinuosSpace(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
            }
            if (Program.greatestValueTime == 2)
            {
                graficContinuosSpace(Program.paper.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0);
            }
            if (Program.greatestValueTime == 3)
            {
                graficContinuosSpace(Program.vaccum.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0);
            }

        }


        private void SalveImage_Click(object sender, EventArgs e)
        {
            try
            {
                SaveImage(chartSpace);
            }
            catch
            {

            }
        }

        private void SalveTXT_Click(object sender, EventArgs e)
        {
            try
            {
                salveTxt();
            }
            catch
            {

            }
        }

        private void SalveXLS_Click(object sender, EventArgs e)
        {

        }
        private void SaveImage(Chart chart)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos de Imagem|*.png;*.jpg;*.bmp|Todos os arquivos|*.*";
            saveFileDialog.Title = "Salvar Gráfico como Imagem";

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

        public void salveTxt()
        {
            string FileLocal = dirSalvar;
            int i, j;

            try
            {
                dirSalvar = "";
                sfdSalve.FileName = FName;
                sfdSalve.Title = "Salvar Documento"; // Adicionamos um título à janela de salvar
                sfdSalve.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*"; // Adicionamos as extensões que serão salvas, .txt e .html

                if (sfdSalve.ShowDialog() == DialogResult.OK)
                {
                    // Se o resultado da caixa de diálogo for igual a Ok, retorna true e entra no IF
                    dirSalvar = sfdSalve.FileName; // FileName retorna o diretório, este valor adicionamos dentro da variável dirSalvar (c:/index.html, c:/texto.txt).

                    switch (OpSalve)
                    {
                        case 1:
                            using (StreamWriter writer = new StreamWriter(dirSalvar, false))
                            {
                                writer.Flush();
                                for (i = 0; i < 5; i++)
                                {
                                    // SelecionarPopulacao(i);
                                    for (j = 0; j < 5; j++)
                                    {
                                        writer.WriteLine("População: [" + i + "] | Indivíduo: [" + j + "] = ");
                                    }
                                }
                            }
                            break;

                        case 2:
                            using (StreamWriter writer = new StreamWriter(dirSalvar, false))
                            {
                                writer.Flush();
                                for (i = 0; i < 5; i++)
                                {
                                    // SelecionarPopulacao(i);
                                    for (j = 0; j < 5; j++)
                                    {
                                        writer.WriteLine("População: [" + i + "] | Indivíduo: [" + j + "] =  | Pontos =  | Mutação = ");
                                    }
                                }
                            }
                            break;

                        case 3:
                            using (StreamWriter writer = new StreamWriter(dirSalvar, false))
                            {
                                writer.Flush();
                                writer.WriteLine(" ----------------------------------------- ");
                                writer.WriteLine(" Orphew Algorithms - Algoritmo Genético ");
                                writer.WriteLine(" ----------------------------------------- ");
                                writer.WriteLine(" Gerações   : ");
                                writer.WriteLine(" Populações : ");
                                writer.WriteLine(" Genes      : ");
                                writer.WriteLine(" Alelo      : ");
                                writer.WriteLine(" Prob/Mut   : ");
                                writer.WriteLine(" Prob/Cru   : ");
                                writer.WriteLine(" Meta       : ");
                                writer.WriteLine(" ----------------------------------------- ");
                                writer.WriteLine(" Resultados  ");
                                writer.WriteLine(" Gerações   : ");
                                writer.WriteLine(" Indivíduos : ");
                                writer.WriteLine(" Mutações   : ");

                                if (5 == 1)
                                {
                                    // writer.WriteLine(" Encontrado : Sim");
                                }
                                else
                                {
                                    writer.WriteLine(" Encontrado : Não");
                                }

                                writer.WriteLine(" ----------------------------------------- ");
                            }
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não é possível Encriptar", "AG", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
