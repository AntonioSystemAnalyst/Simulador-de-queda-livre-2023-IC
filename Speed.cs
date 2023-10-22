using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace freeFall
{
    public partial class Speed : Form
    {
        string[] linha = new string[5];
        string[] timeLarge;
        public Speed()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            checkBox3D.Checked = true;
            buildGrafic();
            dataGridConfigure();
            toComplete();
            colorAll();
        }

        private void Speed_Load(object sender, EventArgs e)
        {
            trackBarColors.Value = Program.colorTrackBar;
            dataGridView.CurrentCell = null;
        }

        public void closeWindo()
        {
            this.Close();
        }
        public void colorAll()
        {
            groupBoxResults.ForeColor = Program.colorSimulator;
            groupBoxSalve.ForeColor = Program.colorSimulator;
            dataGridView.GridColor = Program.colorSimulator;
            dataGridView.DefaultCellStyle.ForeColor = Program.colorSimulator;
            chartSpeed.Titles[0].ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            labelTextColor.ForeColor = Program.colorSimulator;
            checkBox3D.ForeColor = Program.colorSimulator;
            Program.simulatorTrackBarValueFlag = 1;
        }
        private void timerFocus_Tick(object sender, EventArgs e)
        {
            SalveImage.Focus();
            timerFocus.Enabled = false;
        }
        private void toComplete()
        {
            int i;

            for (i = 0; i < Program.numberOfTermsTable - 2; i++)
            {
                linha[0] = Convert.ToString(Math.Round(Program.timeTable[i], 4).ToString("0.0000"));
                if (Program.bodyOn)
                {
                    if (Program.ballSpaceTableIndex > i)
                    {
                        linha[1] = Convert.ToString(Math.Round(Program.ballVelocityTable[i], 4).ToString("0.0000"));
                    }
                    else
                    {
                        linha[1] = "-";
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paperSpaceTableIndex > i)
                    {
                        linha[2] = Convert.ToString(Math.Round(Program.paperVelocityTable[i], 4).ToString("0.0000"));
        }
                    else
                    {
                        linha[2] = "-";
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccumSpaceTableIndex > i)
                    {
                        linha[3] = Convert.ToString(Math.Round(Program.vaccumVelocityTable[i], 4).ToString("0.0000"));
                    }
                    else
                    {
                        linha[3] = "-";
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
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void graficContinuosSpeed(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            var chart = chartSpeed.ChartAreas[0];
            chartSpeed.Visible = true;
            chartSpeed.Titles.Add("Velocidade versus tempo");
            chartSpeed.Titles[0].Font = new Font(chartSpeed.Titles[0].Font.FontFamily, chartSpeed.Titles[0].Font.Size, FontStyle.Bold);
            chartSpeed.ChartAreas[0].AxisX.Title = "t ( s )";
            chartSpeed.ChartAreas[0].AxisY.Title = "v ( m / s )";
            chartSpeed.Titles[0].ForeColor = Color.Cyan;
            chartSpeed.ChartAreas[0].AxisX.TitleForeColor = Color.Cyan;
            chartSpeed.ChartAreas[0].AxisY.TitleForeColor = Color.Cyan;
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
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
                chartSpeed.Series.Add("Bola");
                chartSpeed.Series["Bola"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bola"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.ballSpaceTableIndex-1; i++)
                {
                    chartSpeed.Series["Bola"].Points.AddXY(Program.ballFinalEndTime[i], Math.Round(Program.ballVelocityTable[i], 4));
                }
            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.paperSpaceTableIndex-1; i++)
                {
                    chartSpeed.Series["Papel"].Points.AddXY(Program.paperFinalEndTime[i], Math.Round(Program.paperVelocityTable[i], 4));
                }
            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("Corpo no vácuo");
                chartSpeed.Series["Corpo no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Corpo no vácuo"].Color = Color.Purple;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.vaccumSpaceTableIndex-1; i++)
                {
                    chartSpeed.Series["Corpo no vácuo"].Points.AddXY(Program.vaccumFinalEndTime[i], Math.Round(Program.vaccumVelocityTable[i], 4));
                }
            }
        }

        public void buildGrafic()
        {
            int speedDiv, i;
            double Y = 0.0;
            double X = 0.0;
            chartSpeed.Series.Clear();
            speedDiv = Convert.ToInt32(Math.Round(Program.greatestValueVelocity, 0) / 5);
            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 3);
                graficContinuosSpeed(Program.ball.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.ball.NumberOfTerms];
                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.ball.CountTimeExperiment[i].ToString("0.0000"));
                }
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 3);
                graficContinuosSpeed(Program.ball.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.ball.NumberOfTerms];
                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.ball.CountTimeExperiment[i].ToString("0.0000"));
                }
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                graficContinuosSpeed(Program.paper.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.CountTimeExperiment[i].ToString("0.0000"));
                }
            }

            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                graficContinuosSpeed(Program.vaccum.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.vaccum.NumberOfTerms];
                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.vaccum.CountTimeExperiment[i].ToString("0.0000"));
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
            SaveImage(chartSpeed);
        }

        private void SalveTXT_Click(object sender, EventArgs e)
        {
            salveDataTxt();
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
                saveFileDialog.FileName = "Queda dos corpos.Gráfico VxT-" + dataHoraString;

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
        public void salveDataTxt()
        {
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Queda dos corpos.Resultados de velocidade-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {
                        writer.Flush();
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Simulador de queda dos corpos");
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Nome       : " + Program.planetName);
                        writer.WriteLine(" Gravidade  : " + Program.gravity + " m/s²");
                        writer.WriteLine(" Densidade  : " + Program.airDensity + " kg/m³");
                        if (Program.airResistance == 0)
                        {
                            writer.WriteLine(" Resistência atmosférica  : Não");
                        }
                        else
                        {
                            writer.WriteLine(" Resistência atmosférica  : Sim");
                        }
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Tempo para a bola               : " + Math.Round(Program.ball.TimeAllExperiment, 2) + " s");
                        writer.WriteLine(" Velocidade inicial da bola      : " + Math.Round(Program.ball.InitialVelocity, 2) + " m/s");
                        writer.WriteLine(" Velocidade final da bola        : " + Math.Round(Program.ball.FinalVelocity, 2) + " m/s");
                        writer.WriteLine(" Coeficiente de arrasto da bola  : " + Program.ball.DragCoefficient);
                        writer.WriteLine(" Área da bola                    : " + Program.ball.CrossSectionalArea + " m²");
                        writer.WriteLine(" Massa da bola                   : " + Program.ball.Mass + " kg");
                        if (Program.paperOn)
                        {
                            writer.WriteLine(" ----------------------------------------- ");
                            writer.WriteLine(" Tempo para o papel              : " + Math.Round(Program.paper.TimeAllExperiment, 2) + " s");
                            writer.WriteLine(" Velocidade inicial do papel     : " + Math.Round(Program.paper.InitialVelocity, 2) + " m/s");
                            writer.WriteLine(" Velocidade final do papel       : " + Math.Round(Program.paper.FinalVelocity, 2) + " m/s");
                            writer.WriteLine(" Coeficiente de arrasto da papel : " + Program.paper.DragCoefficient);
                            writer.WriteLine(" Área do papel                   : " + Program.paper.CrossSectionalArea + " m²");
                            writer.WriteLine(" Massa do papel                  : " + Program.paper.Mass + " kg");

                        }
                        if (Program.vaccumOn)
                        {
                            writer.WriteLine(" ----------------------------------------- ");
                            writer.WriteLine(" Tempo para o c. vácuo               : " + Math.Round(Program.vaccum.TimeAllExperiment, 2) + " s");
                            writer.WriteLine(" Velocidade inicial do c. vácuo      : " + Math.Round(Program.vaccum.InitialVelocity, 2) + " m/s");
                            writer.WriteLine(" Velocidade final do c. vácuo        : " + Math.Round(Program.vaccum.FinalVelocity, 2) + " m/s");
                            writer.WriteLine(" Coeficiente de arrasto do c. vácuo  : " + Program.vaccum.DragCoefficient);
                            writer.WriteLine(" Área do c. vácuo                    : " + Program.vaccum.CrossSectionalArea + " m²");
                            writer.WriteLine(" Massa do c. vácuo                   : " + Program.vaccum.Mass + " kg");

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

        public void salveTableTxt()
        {
            int i;
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Queda dos corpos.Tabelas de velocidade-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Documentos de texto (*.txt)|*.txt|Todos os arquivos|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {
                        writer.WriteLine(" ----------------------------------------- ");
                        writer.WriteLine(" Tabelas  ");
                        writer.WriteLine(" ----------------------------------------- ");
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($" Tempo: [{"s",-5}] | Bola: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s",-5}] | Bola: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s",-5}] | Bola: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s",-5}] | Bola: V-[{"m/s",-5}]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i];
                            if (Program.bodyOn)
                            {
                                if (Program.ball.NumberOfTerms > i)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.ballVelocityTable[i], 4).ToString("0.0000"));
                                }
                                else
                                {
                                    linha[1] = "-";
                                }
                            }
                            if (Program.paperOn)
                            {
                                if (Program.paper.NumberOfTerms > i)
                                {
                                    linha[2] = Convert.ToString(Math.Round(Program.paperVelocityTable[i], 4).ToString("0.0000"));
                                }
                                else
                                {
                                    linha[2] = "-";
                                }
                            }
                            if (Program.vaccumOn)
                            {
                                if (Program.vaccum.NumberOfTerms > i)
                                {
                                    linha[3] = Convert.ToString(Math.Round(Program.vaccumVelocityTable[i], 4).ToString("0.0000"));
                                }
                                else
                                {
                                    linha[3] = "-";
                                }
                            }
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($" Tempo: [{linha[0],-5}] | Bola: [{linha[1],-5}] | Papel: [{linha[2],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($" Tempo: [{linha[0],-5}] | Bola: [{linha[1],-5}] | Papel: [{linha[2],-5}]");
                                }
                                else
                                {
                                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                    {
                                        writer.WriteLine($" Tempo: [{linha[0],-5}] | Bola: [{linha[1],-5}] | Corpo no vácuo: [{linha[3],-5}]");
                                    }
                                    else
                                    {
                                        writer.WriteLine($" Tempo: [{linha[0],-5}] | Bola: [{linha[1],-5}]");
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
            string Auxiliary = ""; 
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Simualdor de queda dos corpos.Valores de velocidade-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {

                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($"Tempo[s];Bola-V[m/s];Papel-V[m/s];C. Vacuo-V[m/s]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($"Tempo[s];Bola-V[m/s];Papel-V[m/s]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($"Tempo[s];Bola-V[m/s];C. Vacuo-V[m/s]");
                                }
                                else
                                {
                                    writer.WriteLine($"Tempo[s];Bola-V[m/s]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfTermsTable - 2; i++)
                        {
                            Auxiliary = Math.Round(Program.timeTable[i], 4).ToString("0.0000");
                            linha[0] = Auxiliary.Replace('.', ',');
                            if (Program.bodyOn)
                            {
                                if (Program.ballSpaceTableIndex > i)
                                {
                                    Auxiliary = Math.Round(Program.ballVelocityTable[i], 4).ToString("0.0000");
                                    linha[1] = Convert.ToString(Auxiliary).Replace('.', ',');
                                }
                                else
                                {
                                    linha[1] = "";
                                }
                            }
                            if (Program.paperOn)
                            {
                                if (Program.paperSpaceTableIndex > i)
                                {
                                    Auxiliary = Math.Round(Program.paperVelocityTable[i], 4).ToString("0.0000");
                                    linha[2] = Convert.ToString(Auxiliary).Replace('.', ',');
                                }
                                else
                                {
                                    linha[2] = "";
                                }
                            }
                            if (Program.vaccumOn)
                            {
                                if (Program.vaccumSpaceTableIndex > i)
                                {
                                    Auxiliary = Math.Round(Program.vaccumVelocityTable[i], 4).ToString("0.0000");
                                    linha[3] = Convert.ToString(Auxiliary).Replace('.', ',');
                                }
                                else
                                {
                                    linha[3] = "";
                                }
                            }
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                            {
                                writer.WriteLine($"{linha[0]};{linha[1]};{linha[2]};{linha[3]}");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                                {
                                    writer.WriteLine($"{linha[0]};{linha[1]};{linha[2]}");
                                }
                                else
                                {
                                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                    {
                                        writer.WriteLine($"{linha[0]};{linha[1]};{linha[3]}");
                                    }
                                    else
                                    {
                                        writer.WriteLine($"{linha[0]};{linha[1]}");
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

        private void checkBox3D_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3D.Checked)
            {
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = false;
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
        private void Speed_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.speedGraficControl = 0;
            Program.simulatorTrackBarValueFlag = 1;
        }

        private void checkBoxGrafic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Speed_Resize(object sender, EventArgs e)
        {

        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
