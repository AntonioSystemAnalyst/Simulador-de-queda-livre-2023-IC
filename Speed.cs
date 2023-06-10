﻿using System;
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
        }

        private void Speed_Load(object sender, EventArgs e)
        {
            dataGridView.CurrentCell = null;
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
                    if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                    {
                        linha[1] = Convert.ToString(Math.Round(Program.corpo.Velocity[i], 3));
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                    {
                        linha[2] = Convert.ToString(Math.Round(Program.paper.Velocity[i], 3));
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
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
        }

        public void graficContinuosSpeed(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            var chart = chartSpace.ChartAreas[0];

            chartSpace.Visible = true;


            chartSpace.Titles.Add("Velocidade pelo tempo");
            chartSpace.ChartAreas[0].AxisX.Title = "T(segundos/100)";
            chartSpace.ChartAreas[0].AxisY.Title = "V(metros/segundos)";

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
                    chartSpace.Series["Bóla"].Points.AddXY((i), Program.corpo.Velocity[i]);
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
                    chartSpace.Series["Papel"].Points.AddXY((i), Program.paper.Velocity[i]);
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
                    chartSpace.Series["Objeto no vácuo"].Points.AddXY((i), Program.vaccum.Velocity[i]);
                }
            }
        }

        public void buildGrafic()
        {
            int spaceDiv, i;
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);

            if (Program.greatestValueTime == 0)
            {
                graficContinuosSpeed(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 1)
            {
                graficContinuosSpeed(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.corpo.NumberOfTerms];
                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.corpo.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 2)
            {
                graficContinuosSpeed(Program.paper.NumberOfTerms, 0, Program.paper.FinalVelocity + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0);
                timeLarge = new string[Program.paper.NumberOfTerms];
                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    timeLarge[i] = Convert.ToString(Program.paper.SpaceTime[i]);
                }
            }
            if (Program.greatestValueTime == 3)
            {
                graficContinuosSpeed(Program.vaccum.NumberOfTerms, 0, Program.vaccum.FinalVelocity + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0);
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
            SaveArraysToXml();
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
                            writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                        }
                        else
                        {
                            if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                            {
                                writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: V-[{"m/s",-5}] | Papel: V-[{"m/s",-5}]");
                            }
                            else
                            {
                                if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: V-[{"m/s",-5}] | Corpo no vácuo: V-[{"m/s",-5}]");
                                }
                                else
                                {
                                    writer.WriteLine($" Tempo: [{"s/100",-5}] | Bóla: V-[{"m/s",-5}]");
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
                        Tempo.InnerText = "s/100";
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
                            Tempo.InnerText = "s/100";
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
                                Espaco_Tempo.InnerText = "s/100";
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
                                Tempo.InnerText = "s/100";
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
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }
    }
}
