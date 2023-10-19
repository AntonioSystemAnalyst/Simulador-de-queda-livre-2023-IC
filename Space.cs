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

            for (i = 0; i < Program.numberOfTermsTable-2; i++)
            {
                linha[0] = Convert.ToString(Program.timeTable[i]);
                if (Program.bodyOn)
                {
                    if (Program.ballSpaceTable.Length > i)
                    {
                        linha[1] = isNegative(Math.Round(Program.ballSpaceTable[i], 2));
                    }
                    else
                    {
                        linha[1] = "-";
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paperSpaceTable.Length > i)
                    {
                        linha[2] = isNegative(Math.Round(Program.paperSpaceTable[i], 2));
                    }
                    else
                    {
                        linha[2] = "-";
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccumSpaceTable.Length > i)
                    {
                        linha[3] = isNegative(Math.Round(Program.vaccumSpaceTable[i], 2));
                    }
                    else
                    {
                        linha[3] = "-";
                    }
                }

                dataGridView.Rows.Add(linha);
            }
        }
        public string isNegative(double value)
        {
            string result = "";

            if (value <= 0)
            {
                result = value.ToString("0.00");
            }
            else
            {
                result = value.ToString("0.00");
            }
            return result;
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
            chartSpace.Visible = true;
            chartSpace.Titles.Add("Altura versus tempo");
            chartSpace.Titles[0].Font = new Font(chartSpace.Titles[0].Font.FontFamily, chartSpace.Titles[0].Font.Size, FontStyle.Bold);
            chartSpace.ChartAreas[0].AxisX.Title = "t ( s )";
            chartSpace.ChartAreas[0].AxisY.Title = "y ( m )";
           
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
                chartSpace.Series.Add("Bola");
                chartSpace.Series["Bola"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Bola"].Color = Color.Red;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    chartSpace.Series["Bola"].Points.AddXY(Program.ball.CountTimeExperiment[i], Math.Round(Program.ball.Space[i], 4));
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
                    chartSpace.Series["Papel"].Points.AddXY(Program.paper.CountTimeExperiment[i], Math.Round(Program.paper.Space[i], 4));
                }
            }
            if (Program.vaccumOn)
            {
                chartSpace.Series.Add("Corpo no vácuo");
                chartSpace.Series["Corpo no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Corpo no vácuo"].Color = Color.Purple;
                chartSpace.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    chartSpace.Series["Corpo no vácuo"].Points.AddXY(Program.vaccum.CountTimeExperiment[i], Math.Round(Program.vaccum.Space[i], 4));
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
                    timeLarge[i] = Convert.ToString(Program.ball.CountTimeExperiment[i].ToString("0.00"));
                }
                timeLarge[Program.ball.NumberOfTerms-1] = Convert.ToString(Program.ball.CountTimeExperiment[Program.ball.NumberOfTerms - 1].ToString("0.0000"));
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.ball.TimeAllExperiment), 3);
                graficContinuosSpace(Program.ball.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.ball.NumberOfTerms];
                for (i = 0; i < Program.ball.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.ball.CountTimeExperiment[i].ToString("0.00"));
                }
                timeLarge[Program.ball.NumberOfTerms-1] = Convert.ToString(Program.ball.CountTimeExperiment[i].ToString("0.0000"));
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                graficContinuosSpace(Program.paper.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.CountTimeExperiment[i].ToString("0.00"));
                }
                timeLarge[timeLarge.Length- 1] = Convert.ToString(Program.paper.CountTimeExperiment[timeLarge.Length - 1].ToString("0.0000"));
            }
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.height), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                graficContinuosSpace(Program.vaccum.NumberOfTerms, 0, Y, spaceDiv, 0, X, 0);
                timeLarge = new string[Program.vaccum.NumberOfTerms];
                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.vaccum.CountTimeExperiment[i].ToString("0.00"));
                }
                timeLarge[Program.vaccum.NumberOfTerms-1] = Convert.ToString(Program.vaccum.CountTimeExperiment[i].ToString("0.0000"));
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
                            writer.WriteLine($" Tempo: [{"s/100",-5}] | Bola: y-[{"m",-5}] | Papel: y-[{"m",-5}] | Corpo no vácuo: y-[{"m",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s/100",-5}] | Bola: y-[{"m",-5}] | Papel: y-[{"m",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bola: y-[{"m",-5}] | Corpo no vácuo: y-[{"m",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bola: y-[{"m",-5}]");
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
                                    linha[1] = Convert.ToString(Math.Round(Program.ball.Space[i], 2).ToString("0.00"));
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
                                    linha[2] = Convert.ToString(Math.Round(Program.paper.Space[i], 2).ToString("0.00"));
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
                                    linha[3] = Convert.ToString(Math.Round(Program.vaccum.Space[i], 2).ToString("0.00"));
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
            string Auxiliary = " "; 
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Simulador de queda dos corpos.Valores de espaço-" + dataHoraString;
                saveFileDialog.Title = "Salvar Documento";
                saveFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(xmlFilePath, false))
                    {

                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($"Tempo[s];Bola-y[m];Papel-y[m];C. Vacuo-y[m]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($"Tempo[s];Bola-y[m];Papel-y[m]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($"Tempo[s];Bola-y[m];C. Vacuo-y[m]");
                                }
                                else
                                {
                                    writer.WriteLine($"Tempo[s];Bola-y[m]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfTermsTable-2; i++)
                        {
                            Auxiliary = Math.Round(Program.timeTable[i], 4).ToString("0.0000");
                            linha[0] = Auxiliary.Replace('.', ',');
                            if (Program.bodyOn)
                            {
                                if (Program.ballSpaceTable.Length > i)
                                {
                                    Auxiliary = Math.Round(Program.ballSpaceTable[i], 4).ToString("0.0000");
                                    linha[1] = Convert.ToString(Auxiliary.Replace('.', ','));
                                }
                                else
                                {
                                    linha[1] = "";
                                }
                            }
                            if (Program.paperOn)
                            {
                                if (Program.paperSpaceTable.Length > i)
                                {
                                    Auxiliary = Math.Round(Program.paperSpaceTable[i], 4).ToString("0.0000");
                                    linha[2] = Convert.ToString(Auxiliary.Replace('.', ','));
                                }
                                else
                                {
                                    linha[2] = "";
                                }
                            }
                            if (Program.vaccumOn)
                            {
                                if (Program.vaccumSpaceTable.Length > i)
                                {
                                    Auxiliary = Math.Round(Program.vaccumSpaceTable[i], 4).ToString("0.0000");
                                    linha[3] = Convert.ToString(Auxiliary.Replace('.', ','));
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
