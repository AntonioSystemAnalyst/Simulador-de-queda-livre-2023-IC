using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dataGridView.CurrentCell = null;
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
        }
        private void timerFocus_Tick(object sender, EventArgs e)
        {
            SalveImage.Focus();
            timerFocus.Enabled = false;
        }
        private void toComplete()
        {
            int i;

            for (i = 0; i < Program.numberOfPoints; i++)
            {
                linha[0] = timeLarge[i];
                if (Program.bodyOn)
                {
                    if (Program.corpo.NumberOfTerms >= Program.numberOfPoints)
                    {
                        linha[1] = Convert.ToString(Math.Round(Program.corpo.Velocity[i], 3));
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms >= Program.numberOfPoints)
                    {
                        linha[2] = Convert.ToString(Math.Round(Program.paper.Velocity[i], 3));
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms >= Program.numberOfPoints)
                    {
                        linha[3] = Convert.ToString(Math.Round(Program.vaccum.Velocity[i], 3));
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
            double result = 0.0;
            chartSpeed.Visible = true;
            chartSpeed.Titles.Add("Velocidade pelo tempo");
            chartSpeed.ChartAreas[0].AxisX.Title = "T(segundos/100)";
            chartSpeed.ChartAreas[0].AxisY.Title = "V(metros/segundos)";
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

            chartSpeed.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpeed.Series.Add("Bóla");
                chartSpeed.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bóla"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpeed.Series["Bóla"].Points.AddXY(result, Program.corpo.Velocity[i]);
                }
            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpeed.Series["Papel"].Points.AddXY(result, Program.paper.Velocity[i]);
                }
            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("Objeto no vácuo");
                chartSpeed.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;

                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    result = (double)i / 100.0;
                    chartSpeed.Series["Objeto no vácuo"].Points.AddXY(result, Program.vaccum.Velocity[i]);
                }
            }
        }

        public void buildGrafic()
        {
            int speedDiv, i;
            double Y = 0.0;
            double X = 0.0;
            chartSpeed.Series.Clear();

            if (Program.greatestValueTime == 0)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.corpo.FinalVelocity, 0) / 5);
                graficContinuosSpeed(Program.corpo.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 1)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.corpo.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.corpo.FinalVelocity, 0) / 5);
                graficContinuosSpeed(Program.corpo.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 2)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.paper.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.paper.FinalVelocity, 0) / 5);
                graficContinuosSpeed(Program.paper.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.SpaceTime[i]);
                }
            }
            
            if (Program.greatestValueTime == 3)
            {
                Y = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 3);
                X = Math.Round(CalculateValueWithTenPercent(Program.vaccum.TimeAllExperiment), 3);
                speedDiv = Convert.ToInt32(Math.Round(Program.vaccum.FinalVelocity, 0) / 5);
                graficContinuosSpeed(Program.vaccum.NumberOfTerms, Y, 0, speedDiv, 0, X, 0);
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
            SaveImage(chartSpeed);
        }

        private void SalveTXT_Click(object sender, EventArgs e)
        {
            salveTxt();
        }

        private void SalveXLS_Click(object sender, EventArgs e)
        {
            SaveArraysToXml();
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
                saveFileDialog.FileName = "Queda dos corpos.Resultados-" + dataHoraString;
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
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            writer.WriteLine($" Tempo: [{"s",-5}] | Bóla: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s",-5}] | Bóla: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s",-5}] | Bóla: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s",-5}] | Bóla: V-[{"m/s",-5}]");
                                }
                            }
                        }
                        for (i = 0; i < Program.numberOfPoints; i++)
                        {
                            linha[0] = timeLarge[i];
                            if (Program.bodyOn)
                            {
                                if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                                {
                                    linha[1] = Convert.ToString(Math.Round(Program.corpo.Velocity[i], 3));
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
                                    linha[2] = Convert.ToString(Math.Round(Program.paper.Velocity[i], 3));
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
                                    linha[3] = Convert.ToString(Math.Round(Program.vaccum.Velocity[i], 3));
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
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel efetuar a operação.");
            }
        }
        private void SaveArraysToXml()
        {
            try
            {
                DateTime dataHoraAtual = DateTime.Now;
                string dataHoraString = dataHoraAtual.ToString("yyyy-MM-dd-HH.mm.ss");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo XML|*.xml";
                saveFileDialog.Title = "Salvar Arquivo XML";
                saveFileDialog.FileName = "Queda dos corpos.Resultados-" + dataHoraString;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = saveFileDialog.FileName;

                    XmlDocument xmlDoc = new XmlDocument();

                    XmlElement rootElement = xmlDoc.CreateElement("Dados");
                    xmlDoc.AppendChild(rootElement);

                    if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                    {
                        XmlElement itemElement = xmlDoc.CreateElement("Item");
                        rootElement.AppendChild(itemElement);

                        XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                        Tempo.InnerText = "s";
                        itemElement.AppendChild(Tempo);

                        XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                        Espaco_Bola.InnerText = "m/s";
                        itemElement.AppendChild(Espaco_Bola);

                        XmlElement Espaco_Papel = xmlDoc.CreateElement("Velocidade_Papel");
                        Espaco_Papel.InnerText = "m/s";
                        itemElement.AppendChild(Espaco_Papel);

                        XmlElement Espaco_Vacuo = xmlDoc.CreateElement("Velocidade_Vacuo");
                        Espaco_Vacuo.InnerText = "m/s";
                        itemElement.AppendChild(Espaco_Vacuo);
                    }
                    else
                    {
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                        {
                            XmlElement itemElement = xmlDoc.CreateElement("Item");
                            rootElement.AppendChild(itemElement);

                            XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                            Tempo.InnerText = "s";
                            itemElement.AppendChild(Tempo);

                            XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                            Espaco_Bola.InnerText = "m/s";
                            itemElement.AppendChild(Espaco_Bola);

                            XmlElement Espaco_Papel = xmlDoc.CreateElement("EVelocidade_Papel");
                            Espaco_Papel.InnerText = "m/s";
                            itemElement.AppendChild(Espaco_Papel);
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                            {
                                XmlElement itemElement = xmlDoc.CreateElement("Item");
                                rootElement.AppendChild(itemElement);

                                XmlElement Espaco_Tempo = xmlDoc.CreateElement("Tempo");
                                Espaco_Tempo.InnerText = "s";
                                itemElement.AppendChild(Espaco_Tempo);

                                XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                                Espaco_Bola.InnerText = "m/s";
                                itemElement.AppendChild(Espaco_Bola);

                                XmlElement Espaco_Vacuo = xmlDoc.CreateElement("Velocidade_Vacuo");
                                Espaco_Vacuo.InnerText = "m/s";
                                itemElement.AppendChild(Espaco_Vacuo);
                            }
                            else
                            {
                                XmlElement itemElement = xmlDoc.CreateElement("Item");
                                rootElement.AppendChild(itemElement);

                                XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                                Tempo.InnerText = "s";
                                itemElement.AppendChild(Tempo);

                                XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                                Espaco_Bola.InnerText = "m/s";
                                itemElement.AppendChild(Espaco_Bola);
                            }
                        }
                    }

                    for (int i = 0; i < Program.numberOfPoints; i++)
                    {
                        linha[0] = timeLarge[i];
                        if (Program.bodyOn)
                        {
                            if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                            {
                                linha[1] = Convert.ToString(Math.Round(Program.corpo.Velocity[i], 3));
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
                                linha[2] = Convert.ToString(Math.Round(Program.paper.Velocity[i], 3));
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
                                linha[3] = Convert.ToString(Math.Round(Program.vaccum.Velocity[i], 3));
                            }
                            else
                            {
                                linha[3] = "-";
                            }
                        }
                        if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
                        {
                            XmlElement itemElement = xmlDoc.CreateElement("Item");
                            rootElement.AppendChild(itemElement);

                            XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                            Tempo.InnerText = linha[0];
                            itemElement.AppendChild(Tempo);

                            XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                            Espaco_Bola.InnerText = linha[1];
                            itemElement.AppendChild(Espaco_Bola);

                            XmlElement Espaco_Papel = xmlDoc.CreateElement("Velocidade_Papel");
                            Espaco_Papel.InnerText = linha[2];
                            itemElement.AppendChild(Espaco_Papel);

                            XmlElement Espaco_Vacuo = xmlDoc.CreateElement("Velocidade_Vacuo");
                            Espaco_Vacuo.InnerText = linha[3];
                            itemElement.AppendChild(Espaco_Vacuo);
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                XmlElement itemElement = xmlDoc.CreateElement("Item");
                                rootElement.AppendChild(itemElement);

                                XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                                Tempo.InnerText = linha[0];
                                itemElement.AppendChild(Tempo);

                                XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                                Espaco_Bola.InnerText = linha[1];
                                itemElement.AppendChild(Espaco_Bola);

                                XmlElement Espaco_Papel = xmlDoc.CreateElement("Velocidade_Papel");
                                Espaco_Papel.InnerText = linha[2];
                                itemElement.AppendChild(Espaco_Papel);
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    XmlElement itemElement = xmlDoc.CreateElement("Item");
                                    rootElement.AppendChild(itemElement);

                                    XmlElement Espaco_Tempo = xmlDoc.CreateElement("Tempo");
                                    Espaco_Tempo.InnerText = linha[0];
                                    itemElement.AppendChild(Espaco_Tempo);

                                    XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                                    Espaco_Bola.InnerText = linha[1];
                                    itemElement.AppendChild(Espaco_Bola);

                                    XmlElement Espaco_Vacuo = xmlDoc.CreateElement("Velocidade_Vacuo");
                                    Espaco_Vacuo.InnerText = linha[3];
                                    itemElement.AppendChild(Espaco_Vacuo);
                                }
                                else
                                {
                                    XmlElement itemElement = xmlDoc.CreateElement("Item");
                                    rootElement.AppendChild(itemElement);

                                    XmlElement Tempo = xmlDoc.CreateElement("Tempo");
                                    Tempo.InnerText = linha[0];
                                    itemElement.AppendChild(Tempo);

                                    XmlElement Espaco_Bola = xmlDoc.CreateElement("Velocidade_Bola");
                                    Espaco_Bola.InnerText = linha[1];
                                    itemElement.AppendChild(Espaco_Bola);
                                }
                            }
                        }
                    }
                    xmlDoc.Save(xmlFilePath);
                    MessageBox.Show("Arquivo XML criado com sucesso!");
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

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
