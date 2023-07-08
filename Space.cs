using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace freeFall
{
    public partial class Space : Form
    {

        string[] linha = new string[5];
        string[] timeLarge;
        public Space()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            checkBox3D.Checked = true;
            buildGrafic();
            dataGridConfigure();
            toComplete();
            colorAll();
        }
        public void closeWindo()
        {
            this.Close();
        }
        private void Space_Load(object sender, EventArgs e)
        {
            trackBarColors.Value = Program.colorTrackBar;
            dataGridView.CurrentCell = null;
        }
        public void colorAll()
        {
            groupBoxResults.ForeColor = Program.colorSimulator;
            groupBoxSalve.ForeColor = Program.colorSimulator;
            dataGridView.GridColor = Program.colorSimulator;
            dataGridView.DefaultCellStyle.ForeColor = Program.colorSimulator;
            chartSpace.Titles[0].ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            labelTextColor.ForeColor = Program.colorSimulator;
            checkBox3D.ForeColor = Program.colorSimulator;
            Program.simulatorTrackBarValueFlag = 1;
        }
        private void toComplete()
        {
            int i;

            for (i = 0; i < Program.numberOfPoints; i++)
            {
                linha[0] = timeLarge[i];
                if (Program.bodyOn)
                {
                    if (Program.ball.NumberOfTerms > i)
                    {
                        linha[1] = Convert.ToString(Math.Round(Program.ball.Space[i], 3));
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms > i)
                    {
                        linha[2] = Convert.ToString(Math.Round(Program.paper.Space[i], 3));
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms > i)
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
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void graficContinuosSpace(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            var chart = chartSpace.ChartAreas[0];
            double result = 0.0;
            chartSpace.Visible = true;
            chartSpace.Titles.Add("Espaço pelo tempo");
            chartSpace.Titles[0].Font = new Font(chartSpace.Titles[0].Font.FontFamily, chartSpace.Titles[0].Font.Size, FontStyle.Bold);
            chartSpace.ChartAreas[0].AxisX.Title = "T(segundos)";
            chartSpace.ChartAreas[0].AxisY.Title = "S(metros)";
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

            if (Program.directionOfYaxis == 0)
            {
                chart.AxisY.IsReversed = true;
            }
            else
            {
                chart.AxisY.IsReversed = false;
            }

            if (Program.bodyOn)
            {
                chartSpace.Series.Add("Bóla");
                chartSpace.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bóla"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpace.Series["Bóla"].Points.AddXY(result, Program.ball.Space[i]);
                }
            }
            if (Program.paperOn)
            {
                chartSpace.Series.Add("Papel");
                chartSpace.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Papel"].Color = Color.Blue;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpace.Series["Papel"].Points.AddXY(result, Program.paper.Space[i]);
                }
            }
            if (Program.vaccumOn)
            {
                chartSpace.Series.Add("Objeto no vácuo");
                chartSpace.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpace.Series["Objeto no vácuo"].Points.AddXY(result, Program.vaccum.Space[i]);
                }
            }
        }

        public void buildGrafic()
        {
            int spaceDiv, i;
            double Y = 0.0;
            double X = 0.0;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 3);
                graficContinuosSpace(Program.ball.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.ball.NumberOfTerms];
                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.ball.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 3);
                graficContinuosSpace(Program.ball.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.ball.NumberOfTerms];
                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.ball.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                graficContinuosSpace(Program.paper.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                graficContinuosSpace(Program.vaccum.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.vaccum.NumberOfTerms];
                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.vaccum.SpaceTime[i]);
                }
            }
        }
        double CalculateValueWithTenPercent(double value)
        {
            double percentage = 0.05;
            double tenPercent = value * percentage;
            double result = value + tenPercent;
            return result;
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
            salveTableTxt();
        }
        private void buttonTableForDot_Click(object sender, EventArgs e)
        {
            salveTableTxtDot();
        }
        private void SaveImage(Chart chart)
        {
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.png;*.bmp|Todos os arquivos|*.*";
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
                    MessageBox.Show("Salvo com sucesso!");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }

        public void salveTxt()
        {
            int i;
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Queda dos corpos.Resultados de espaço-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {
                        writer.Flush();
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Simulador de queda Livre");
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Nome       : " + Program.planetName);
                        writer.WriteLine(" Gravidade  : " + Program.gravity + " m/s²");
                        if (Program.airResistance == 0)
                        {
                            writer.WriteLine(" Resis. ar  : Não");
                        }
                        else
                        {
                            writer.WriteLine(" Resis. ar  : Sim");
                        }
                        writer.WriteLine(" Tempo para a bóla           : " + Program.ball.TimeAllExperiment + " s");
                        writer.WriteLine(" Velocidade inicial da bóla  : " + Program.ball.InitialVelocity + " m/s");
                        writer.WriteLine(" Velocidade final da bóla    : " + Program.ball.FinalVelocity + " m/s");
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
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Papel: S-[{"m",-5}] | Corpo no vácuo: S-[{"m",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Papel: S-[{"m",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Corpo no vácuo: S-[{"m",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i];
                            if (Program.bodyOn)
                            {
                                if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.ball.Space[i], 3));
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
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}]");
                                }
                                else
                                {
                                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
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
                    MessageBox.Show("Salvo com sucesso!");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }
        private void salveTableTxt()
        {
            int i;
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Queda dos corpos.Resultados de espaço-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {
                        writer.Flush();
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Tabelas  ");
                        writer.WriteLine(" ----------------------------------------- ");
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Papel: S-[{"m",-5}] | Corpo no vácuo: S-[{"m",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Papel: S-[{"m",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}] | Corpo no vácuo: S-[{"m",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: S-[{"m",-5}]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i];
                            if (Program.bodyOn)
                            {
                                if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.ball.Space[i], 3));
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
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($" Tempo: [{linha[0],-5}] | Bóla: [{linha[1],-5}] | Papel: [{linha[2],-5}]");
                                }
                                else
                                {
                                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
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
                    MessageBox.Show("Salvo com sucesso!");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }
        public void salveTableTxtDot()
        {
            int i;
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Queda dos corpos.Valores de espaço-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {

                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($"Tempo[s],Bola-S[m],Papel-S[m/s],Vacuo-S[m]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($"Tempo[s],Bola-S[m],Papel-S[m]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($"Tempo[s],Bola-S[m],Vacuo-S[m]");
                                }
                                else
                                {
                                    writer.WriteLine($"Tempo[s],Bola-S[m]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i].Replace(',', '.');
                            if (Program.bodyOn)
                            {
                                if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.ball.Space[i], 3)).Replace(',', '.');
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
                                    linha[2] = Convert.ToString(Math.Round(Program.paper.Space[i], 3)).Replace(',', '.');
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
                                    linha[3] = Convert.ToString(Math.Round(Program.vaccum.Space[i], 3)).Replace(',', '.');
                                }
                                else
                                {
                                    linha[3] = "-";
                                }
                            }
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($"{linha[0]},{linha[1]},{linha[2]},{linha[3]}");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($"{linha[0]},{linha[1]},{linha[2]}");
                                }
                                else
                                {
                                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                    {
                                        writer.WriteLine($"{linha[0]},{linha[1]},{linha[3]}");
                                    }
                                    else
                                    {
                                        writer.WriteLine($"{linha[0]},{linha[1]}");
                                    }
                                }
                            }

                        }
                    }
                    MessageBox.Show("Salvo com sucesso!");
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

        private void trackBarColors_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarColors.Value;
            if (i == 2)
            {
                Program.colorSimulator = Color.Blue;
                colorAll();
            }
            if (i == 3)
            {
                Program.colorSimulator = Color.Red;
                colorAll();
            }
            if (i == 4)
            {
                Program.colorSimulator = Color.Green;
                colorAll();
            }
            if (i == 5)
            {
                Program.colorSimulator = Color.Gray;
                colorAll();
            }
            if (i == 6)
            {
                Program.colorSimulator = Color.White;
                colorAll();
            }
            if (i == 7)
            {
                Program.colorSimulator = Color.HotPink;
                colorAll();
            }
            if (i == 8)
            {
                Program.colorSimulator = Color.LightBlue;
                colorAll();
            }
            if (i == 9)
            {
                Program.colorSimulator = Color.LightSalmon;
                colorAll();
            }
            if (i == 10)
            {
                Program.colorSimulator = Color.LightPink;
                colorAll();
            }
            if (i == 1)
            {
                Program.colorSimulator = Color.Cyan;
                colorAll();
            }
        }

        private void Space_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.simulatorTrackBarValueFlag = 1;
            Program.spaceGraficControl = 0;
        }

        private void Space_Resize(object sender, EventArgs e)
        {

        }
    }
}
