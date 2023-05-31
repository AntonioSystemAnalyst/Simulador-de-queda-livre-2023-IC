using freeFall.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace freeFall
{
    public partial class Simulator : Form
    {
        // define objeto para ser usado nas tooltips
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        // define o planeta para exibir os dados - errado!!!
        public int planetCounter = 1;

        // controla o botão iniciar 
        public int buttonStartControl = 0;

        public int corpoCountVetor = 0;
        public int corpoCounter = 0;

        public int countAnimation = 0;

        public double NumberTermsTime = 0.0;
        
        public int    countPixelObject = 0;

        public int countTesteAnimation = 0;


        // --------------
        public int corpoPixelCount = 0;

      
        public static int[] Ax = new int[15];
        public Simulator()
        {
            InitializeComponent();
            timerEixos.Enabled = true;
            cmbPlaneta.Text = "Terra";
            txtAltura.Text = "100";
            txtgravit.Text = "9,8";
            comboBoxVacuum.Text = "Folha";
            comboShet.Text = "Aberta";
            LoadData();
            spaceGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            speedGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            calculateValues();
            dataText();
            Console.WriteLine("oi");
        }

        public void animation()
        {
            int i;

            for (i = 0; i < 534; i++)
            {
                pictureBoxCorpo.Location = new Point(145, 30 + i);
                pictureBoxVacuum.Location = new Point(16, 30 + i);
                pictureBoxCorpoPaper.Location = new Point(222, 30 + i);
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            }
        }

        public void clear ()
        {
            countTesteAnimation = 0;
            pictureBoxCorpo.Location = new Point(145, 30);
            pictureBoxCorpoPaper.Location = new Point(222, 30);
            pictureBoxVacuum.Location = new Point(16, 13);
            countPixelObject = 0;
            corpoCountVetor = 0;
            corpoPixelCount = 0;

            //chartSpace.Series.Clear();
            //chartSpace.ChartAreas.Clear();

            //chartSpeed.Series.Clear();
            //chartSpeed.ChartAreas.Clear();

            Program.corpo.TimeExperimentObject  = 0.0;
            Program.paper.TimeExperimentObject  = 0.0;
            Program.vaccum.TimeExperimentObject = 0.0;
        }

        public void calculateValues()
        {
            Program.planetName = cmbPlaneta.Text;
            Program.height = Program.organizeData(txtAltura.Text);
            Program.gravity = Program.organizeData(txtgravit.Text);

            if (Program.airResistance == 0)
            {
                Program.corpo.calculateOutResistence(Program.height, Program.gravity, 0);
            }
            else
            {
                Program.corpo.calculateWithResistence(Program.height, Program.gravity, 0, 1);
            }
        }


        public void dataText()
        {
            string airResistence = "";
            
            if (Program.airResistance == 0)
            {
                airResistence = "Não";
            }
            else
            {
                airResistence = "Sim";
            }

            richTextBoxDados.Text = " Astro: \n " + cmbPlaneta.Text + "\n Gravidade: \n " + Program.gravity +
               "\n Velocidade inicial(m/s): \n 0\n Velocidade final(m/s): \n " + Math.Round(Program.corpo.FinalVelocityObject, 2) +
               "\n Tempo(s): \n " + Math.Round(Program.corpo.TimeExperimentObject, 2) + "\n Resistencia do ar: \n " + airResistence;

            Program.experimentData = richTextBoxDados.Text;
        }

        private void timerTeste_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpo.Location = new Point(145, 30 + countTesteAnimation);
            if (countTesteAnimation == 534)
            {
                timerTeste.Enabled = false;
            }
            countTesteAnimation += 1;
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            double tolerance = 0.01;
            //if (space - countTime <= tolerance)

            double space = Program.corpo.SpaceObjectTime[countPixelObject];
            double countTime = Math.Round(Program.corpo.CountTimeObject, 2);
            // tem hora q o valor repete
            if (space == countTime)
            {
                pictureBoxCorpo.Location = new Point(145, 30 + countPixelObject);
                countPixelObject += 1;
               
            }
            Console.WriteLine(" Sapce: " + space + "- Time:" + countTime);

            for(int i = 0; i < Program.corpo.SpaceObjectTime.Length; i++)
            {
                Console.WriteLine(" " + Program.corpo.SpaceObjectTime[i]);
            }

            if (Program.corpo.CountTimeObject >= Program.corpo.TimeExperimentObject)
            {
                timerAnimation.Enabled = false;
            }
            corpoPixelCount += 1;
            corpoCountVetor += 1;
            Program.corpo.CountTimeObject += 0.01;


            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeObject, 3);
            txtEspaco.Text = "" + Math.Round(Program.corpo.SpaceObjectPixel[corpoCountVetor], 3);
            txtVelocidade.Text = "" + Math.Round(Program.corpo.VelocityObject[corpoCountVetor], 3);
        }
        // --------------------------------------
        private void timerAnimationPaper_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpoPaper.Location = new Point(222, 30 + countAnimation);
        }

        private void timerGrafic_Tick(object sender, EventArgs e)
        {
            pictureBoxVacuum.Location = new Point(16, 13 + countAnimation);
        }
        private void timerEixos_Tick(object sender, EventArgs e)
        {
            if (checkBoxEixo.Checked)
            {
                pictureBoxSetaY.Visible = true;
                pictureBoxSetaX.Visible = true;
                pictureBoxBase.Visible = false;
            }
            else
            {
                pictureBoxSetaY.Visible = false;
                pictureBoxSetaX.Visible = false;
                pictureBoxBase.Visible = true;
            }
        }
        // --------------------------------------
        private void BTNIniciar_Click(object sender, EventArgs e)
        {
           
            if (buttonStartControl == 0)
            {
                try
                {
                    clear();
                    calculateValues();
                    dataText();
                    timerAnimation.Enabled = true;
                    BTNIniciar.Text = "Parar";
                    buttonStartControl = 1;
                    speedGraphic(10, 0, 150, 50, 0, 10, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Erro !!!\n" + ex);
                }
            }
            if(buttonStartControl == 1)
            {
                BTNIniciar.Text = "Continuar";
                buttonStartControl = 2;
            }
            if (buttonStartControl == 2)
            {
                BTNIniciar.Text = "Posicionar";
                buttonStartControl = 0;
            }
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            timerTeste.Enabled = true;
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            if (Program.experimentDataControl == 0)
            {
                experimentData windowExperiment = new experimentData();
                windowExperiment.Show();
            }
        }

        private void buttonResistencia_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    
        private void buttonPlanet_Click(object sender, EventArgs e)
        {
            if (planetCounter == 10)
            {
                if (Program.configurePlanetControl == 0)
                {
                    configurePlanet windowConfigurePlanet = new configurePlanet();
                    windowConfigurePlanet.Show();
                }
            }
            else
            {
                if (Program.dataControl == 0)
                {
                    Data windowData = new Data();
                    windowData.Show();
                }
            }
        }

        private void buttonConfigPlanet_Click(object sender, EventArgs e)
        {
            if (Program.configurePlanetControl == 0)
            {
                configurePlanet windowConfigurePlanet = new configurePlanet();
                windowConfigurePlanet.Show();
            }
        }
        private void buttonLogo_Click(object sender, EventArgs e)
        {
            programView x = new programView();
            x.Show();
        }

        // --------------------------------------

        // chart Configuration // n = quantidade de termos // Mm = Y minimo
        // Mm = Y minimo // MM = Y max // interY = intervalo em Y
        // interX = intervalo em X    // Max = X max // Mmx = X minimu

        public void spaceGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            string Serie = "Espaço";
            var chart = chartSpace.ChartAreas[0];
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
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
            chartSpace.Series.Add(Serie);
            chartSpace.Series[Serie].ChartType = SeriesChartType.Spline;
            chartSpace.Series[Serie].Color = Color.Blue;
            for (i = 0; i < n; i++)
            {
                chartSpace.Series[Serie].Points.AddXY((i), Program.corpo.Space[i]);
            }
        }

        public void speedGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            string Serie = "Espaço";
            var chart = chartSpeed.ChartAreas[0];
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
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
            chartSpeed.Series.Add(Serie);
            chartSpeed.Series[Serie].ChartType = SeriesChartType.Spline;
            chartSpeed.Series[Serie].Color = Color.Blue;
            for (i = 0; i < n; i++)
            {
                chartSpace.Series[Serie].Points.AddXY((i), Program.corpo.VelocityObject[i]);
            }
        }

        public void speedGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            string Serie = "Velocidade";
            var chart = chartSpeed.ChartAreas[0];
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
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
            chartSpeed.Series.Add(Serie);
            chartSpeed.Series[Serie].ChartType = SeriesChartType.Spline;
            chartSpeed.Series[Serie].Points.AddXY(0, 0);
        }
        public void spaceGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            string Serie = "Espaço";
            var chart = chartSpace.ChartAreas[0];
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
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
            chartSpace.Series.Add(Serie);
            chartSpace.Series[Serie].ChartType = SeriesChartType.Spline;
            chartSpace.Series[Serie].Color = Color.Blue;
            chartSpace.Series[Serie].Points.AddXY(0, 0);
        }

        private void checkBoxVacuum_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxVacuum.Checked)
            {
                comboBoxVacuum.Enabled = true;
                groupBoxVacuum.Visible = true;
                pictureBoxVacuum.Visible = true;
                pictureBoxGauge.Visible = true;
            }
            else
            {
                comboBoxVacuum.Enabled = false;
                groupBoxVacuum.Visible = false;
                pictureBoxVacuum.Visible = false;
                pictureBoxGauge.Visible = false;
            }
        }

        private void checkBoxLeaf_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxLeaf.Checked)
            {
                comboShet.Enabled = true;
                pictureBoxCorpoPaper.Visible = true;
            }
            else
            {
                comboShet.Enabled = false;
                pictureBoxCorpoPaper.Visible = false;
            }
        }

        private void comboBoxVacuum_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxVacuum.Text == "Bóla")
            {
                pictureBoxVacuum.Image = Properties.Resources.corpoSoccer;
            }
            else
            {
                pictureBoxVacuum.Image = Properties.Resources.paper2;
            }
        }

        private void comboShet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboShet.Text == "Aberta")
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper2;
            }
            else
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper3;
            }
        }

        private void checkBoxResistance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxResistance.Checked)
            {
                pictureBoxResistence.Visible = true;
                Program.airResistance = 1;
            }
            else
            {
                pictureBoxResistence.Visible = false;
                Program.airResistance = 0;
            }
        }

        public void LoadData()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Ax[i] = rnd.Next(1, 100);
            }
        }
       
        private void chartSpace_MouseClick(object sender, MouseEventArgs e)
        {
            Space windowSpace = new Space();
            windowSpace.Show();
        }

        private void chartSpeed_Click(object sender, EventArgs e)
        {
            Speed windowSpeed = new Speed();
            windowSpeed.Show();
        }
        private void checkBox3D_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            corpoCounter += 1;
            if (corpoCounter == 1)
            {
                pictureBoxCorpo.Image = Properties.Resources.pokebola;
                pictureBoxVacuum.Image = Properties.Resources.pokebola;
            }
            if (corpoCounter == 2)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBall4;
                pictureBoxVacuum.Image = Properties.Resources.corpoBall4;
            }
            if (corpoCounter == 3)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBasketball;
                pictureBoxVacuum.Image = Properties.Resources.corpoBasketball;
            }
            if (corpoCounter == 4)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBowling;
                pictureBoxVacuum.Image = Properties.Resources.corpoBowling;
            }
            if (corpoCounter == 5)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoCosmos;
                pictureBoxVacuum.Image = Properties.Resources.corpoCosmos;
            }
            if (corpoCounter == 6)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoEye;
                pictureBoxVacuum.Image = Properties.Resources.corpoEye;
            }
            if (corpoCounter == 7)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoGolf;
                pictureBoxVacuum.Image = Properties.Resources.corpoGolf;
            }
            if (corpoCounter == 8)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoMountains;
                pictureBoxVacuum.Image = Properties.Resources.corpoMountains;
            }
            if (corpoCounter == 9)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoRing;
                pictureBoxVacuum.Image = Properties.Resources.corpoRing;
            }
            if (corpoCounter == 10)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoEye;
                pictureBoxVacuum.Image = Properties.Resources.corpoEye;
            }
            if (corpoCounter == 11)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoSoccer;
                pictureBoxVacuum.Image = Properties.Resources.corpoSoccer;
            }
            if (corpoCounter == 12)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoSphere;
                pictureBoxVacuum.Image = Properties.Resources.corpoSphere;
            }
            if (corpoCounter == 13)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoSphere2;
                pictureBoxVacuum.Image = Properties.Resources.corpoSphere2;
            }
            if (corpoCounter == 14)
            {
                corpoCounter = 0;
                pictureBoxCorpo.Image = Properties.Resources.corpoBall;
                pictureBoxVacuum.Image = Properties.Resources.corpoBall;
            }
        }
        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            planetCounter += 1;
            Program.planetCounter = planetCounter;
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 1)
            {
                txtgravit.Text = "9,8";
                cmbPlaneta.Text = "Terra";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
            }
            if (planetCounter == 2)
            {
                txtgravit.Text = "1,624";
                cmbPlaneta.Text = "Lua";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMoon;
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                buttonPlanet.Text = "Lua";
            }
            if (planetCounter == 3)
            {
                txtgravit.Text = "3,7";
                cmbPlaneta.Text = "Mercúrio";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMercury;
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                buttonPlanet.Text = "Mercúrio";
            }
            if (planetCounter == 4)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Vênus";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonVenus;
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                buttonPlanet.Text = "Vênus";
            }
            if (planetCounter == 5)
            {
                txtgravit.Text = "3,71";
                cmbPlaneta.Text = "Marte";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMars;
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                buttonPlanet.Text = "Marte";
            }
            if (planetCounter == 6)
            {
                txtgravit.Text = "24,79";
                cmbPlaneta.Text = "Júpter";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonJupiter;
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                buttonPlanet.Text = "Júpter";
            }
            if (planetCounter == 7)
            {
                txtgravit.Text = "10,4";
                cmbPlaneta.Text = "Saturno";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonSaturn;
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                buttonPlanet.Text = "Saturno";
            }
            if (planetCounter == 8)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Urano";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonUranus;
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                buttonPlanet.Text = "Urano";
            }
            if (planetCounter == 9)
            {
                txtgravit.Text = "11,15";
                cmbPlaneta.Text = "Netuno";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonNeptune;
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
            }
            if (planetCounter == 10)
            {
                planetCounter = 1;
                txtgravit.Text = "9,8";
                cmbPlaneta.Text = "Terra";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";

            }
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            planetCounter -= 1;
            Program.planetCounter = planetCounter;
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 1)
            {
                txtgravit.Text = "9,8";
                cmbPlaneta.Text = "Terra";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
            }
            if (planetCounter == 2)
            {
                txtgravit.Text = "1,624";
                cmbPlaneta.Text = "Lua";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMoon;
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                buttonPlanet.Text = "Lua";
            }
            if (planetCounter == 3)
            {
                txtgravit.Text = "3,7";
                cmbPlaneta.Text = "Mercúrio";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMercury;
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                buttonPlanet.Text = "Mercúrio";
            }
            if (planetCounter == 4)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Vênus";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonVenus;
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                buttonPlanet.Text = "Vênus";
            }
            if (planetCounter == 5)
            {
                txtgravit.Text = "3,71";
                cmbPlaneta.Text = "Marte";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMars;
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                buttonPlanet.Text = "Marte";
            }
            if (planetCounter == 6)
            {
                txtgravit.Text = "24,79";
                cmbPlaneta.Text = "Júpter";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonJupiter;
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                buttonPlanet.Text = "Júpter";
            }
            if (planetCounter == 7)
            {
                txtgravit.Text = "10,4";
                cmbPlaneta.Text = "Saturno";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonSaturn;
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                buttonPlanet.Text = "Saturno";
            }
            if (planetCounter == 8)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Urano";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonUranus;
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                buttonPlanet.Text = "Urano";
            }
            if (planetCounter == 9)
            {
                txtgravit.Text = "11,15";
                cmbPlaneta.Text = "Netuno";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonNeptune;
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
            }

            if (planetCounter == 0)
            {
                planetCounter = 9;
                txtgravit.Text = "11,15";
                cmbPlaneta.Text = "Netuno";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonNeptune;
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
            }
        }
        private void cmbPlaneta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPlaneta.Text == "Terra")
            {
                txtgravit.Text = "9,8";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
                planetCounter = 1;
            }
            if (cmbPlaneta.Text == "Lua")
            {
                txtgravit.Text = "1,624";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMoon;
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                buttonPlanet.Text = "Lua";
                planetCounter = 2;
            }
            if (cmbPlaneta.Text == "Mercúrio")
            {
                txtgravit.Text = "3,7";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMercury;
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                buttonPlanet.Text = "Mercúrio";
                planetCounter = 3;
            }
            if (cmbPlaneta.Text == "Vênus")
            {
                txtgravit.Text = "8,87";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonVenus;
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                buttonPlanet.Text = "Vênus";
                planetCounter = 4;
            }
            if (cmbPlaneta.Text == "Marte")
            {
                txtgravit.Text = "3,71";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMars;
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                buttonPlanet.Text = "Marte";
                planetCounter = 5;
            }
            if (cmbPlaneta.Text == "Júpter")
            {
                txtgravit.Text = "24,79";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonJupiter;
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                buttonPlanet.Text = "Júpter";
                planetCounter = 6;
            }
            if (cmbPlaneta.Text == "Saturno")
            {
                txtgravit.Text = "10,4";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonSaturn;
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                buttonPlanet.Text = "Saturno";
                planetCounter = 7;
            }
            if (cmbPlaneta.Text == "Urano")
            {
                txtgravit.Text = "8,87";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonUranus;
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                buttonPlanet.Text = "Urano";
                planetCounter = 8;
            }
            if (cmbPlaneta.Text == "Netuno")
            {
                txtgravit.Text = "11,15";
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonNeptune;
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
                planetCounter = 9;
            }

            Program.planetCounter = planetCounter;
        }
        private void Altura_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(LbAltura, "A altura deve ser menor que 1000 metros.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(label6, "Gravidade do planeta selecionado.");
        }

        private void checkBoxVacuum_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxVacuum, "Câmara de vácuo.");
        }

        private void checkBoxLeaf_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxLeaf, "Corpo com alta resistência ao ar.");
        }

        private void checkBoxResistance_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxResistance, "Adiciona a resistência do ar ao experimênto.");
        }

        private void checkBoxGrafico_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxGrafico, "Adiciona animação aos gráficos.");
        }

        private void checkBoxEixo_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxEixo, "Exibe eixos no experimento.");
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(button1, "Muda a imagem do corpo.");
        }

        private void buttonData_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonData, "Exibe os dados configurados do experimento.");
        }
        private void trackBarPlanets_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarColors.Value;
            if (i == 2)
            {
                richTextBoxDados.ForeColor = Color.Blue;
                groupBoxDados.ForeColor = Color.Blue;
                groupBoxControl.ForeColor = Color.Blue;
                groupBoxConfiguracao.ForeColor = Color.Blue;
                groupBoxPlanetas.ForeColor = Color.Blue;
                groupBoxGraficos.ForeColor = Color.Blue;
                groupBoxResultados.ForeColor = Color.Blue;
                groupBoxExperimento.ForeColor = Color.Blue;
                cmbPlaneta.ForeColor = Color.Blue;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Blue;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Blue;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Blue;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Blue;
                txtAltura.ForeColor = Color.Blue;
                txtEspaco.ForeColor = Color.Blue;
                txtgravit.ForeColor = Color.Blue;
                txtVelocidade.ForeColor = Color.Blue;
            }
            if (i == 3)
            {
                richTextBoxDados.ForeColor = Color.Red;
                groupBoxDados.ForeColor = Color.Red;
                groupBoxControl.ForeColor = Color.Red;
                groupBoxConfiguracao.ForeColor = Color.Red;
                groupBoxPlanetas.ForeColor = Color.Red;
                groupBoxGraficos.ForeColor = Color.Red;
                groupBoxResultados.ForeColor = Color.Red;
                groupBoxExperimento.ForeColor = Color.Red;
                cmbPlaneta.ForeColor = Color.Red;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Red;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Red;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Red;
                txtAltura.ForeColor = Color.Red;
                txtEspaco.ForeColor = Color.Red;
                txtgravit.ForeColor = Color.Red;
                txtVelocidade.ForeColor = Color.Red;
            }
            if (i == 4)
            {
                richTextBoxDados.ForeColor = Color.Green;
                groupBoxDados.ForeColor = Color.Green;
                groupBoxControl.ForeColor = Color.Green;
                groupBoxConfiguracao.ForeColor = Color.Green;
                groupBoxPlanetas.ForeColor = Color.Green;
                groupBoxGraficos.ForeColor = Color.Green;
                groupBoxResultados.ForeColor = Color.Green;
                groupBoxExperimento.ForeColor = Color.Green;
                cmbPlaneta.ForeColor = Color.Green;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Green;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Green;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Green;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Green;
                txtAltura.ForeColor = Color.Green;
                txtEspaco.ForeColor = Color.Green;
                txtgravit.ForeColor = Color.Green;
                txtVelocidade.ForeColor = Color.Green;
            }
            if (i == 5)
            {
                richTextBoxDados.ForeColor = Color.Gray;
                groupBoxDados.ForeColor = Color.Gray;
                groupBoxControl.ForeColor = Color.Gray;
                groupBoxConfiguracao.ForeColor = Color.Gray;
                groupBoxPlanetas.ForeColor = Color.Gray;
                groupBoxGraficos.ForeColor = Color.Gray;
                groupBoxResultados.ForeColor = Color.Gray;
                groupBoxExperimento.ForeColor = Color.Gray;
                cmbPlaneta.ForeColor = Color.Gray;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;
                txtAltura.ForeColor = Color.Gray;
                txtEspaco.ForeColor = Color.Gray;
                txtgravit.ForeColor = Color.Gray;
                txtVelocidade.ForeColor = Color.Gray;
            }
            if (i == 6)
            {
                richTextBoxDados.ForeColor = Color.Green;
                groupBoxDados.ForeColor = Color.Green;
                groupBoxControl.ForeColor = Color.Green;
                groupBoxConfiguracao.ForeColor = Color.Green;
                groupBoxPlanetas.ForeColor = Color.Green;
                groupBoxGraficos.ForeColor = Color.Green;
                groupBoxResultados.ForeColor = Color.Green;
                groupBoxExperimento.ForeColor = Color.Green;
                cmbPlaneta.ForeColor = Color.Green;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Green;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Green;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Green;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Green;
                txtAltura.ForeColor = Color.Green;
                txtEspaco.ForeColor = Color.Green;
                txtgravit.ForeColor = Color.Green;
                txtVelocidade.ForeColor = Color.Green;
            }
            if (i == 7)
            {
                richTextBoxDados.ForeColor = Color.HotPink;
                groupBoxDados.ForeColor = Color.HotPink;
                groupBoxControl.ForeColor = Color.HotPink;
                groupBoxConfiguracao.ForeColor = Color.HotPink;
                groupBoxPlanetas.ForeColor = Color.HotPink;
                groupBoxGraficos.ForeColor = Color.HotPink;
                groupBoxResultados.ForeColor = Color.HotPink;
                groupBoxExperimento.ForeColor = Color.HotPink;
                cmbPlaneta.ForeColor = Color.HotPink;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.HotPink;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.HotPink;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.HotPink;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.HotPink;
                txtAltura.ForeColor = Color.HotPink;
                txtEspaco.ForeColor = Color.HotPink;
                txtgravit.ForeColor = Color.HotPink;
                txtVelocidade.ForeColor = Color.HotPink;
            }
            if (i == 8)
            {
                richTextBoxDados.ForeColor = Color.LightBlue;
                groupBoxDados.ForeColor = Color.LightBlue;
                groupBoxControl.ForeColor = Color.LightBlue;
                groupBoxConfiguracao.ForeColor = Color.LightBlue;
                groupBoxPlanetas.ForeColor = Color.LightBlue;
                groupBoxGraficos.ForeColor = Color.LightBlue;
                groupBoxResultados.ForeColor = Color.LightBlue;
                groupBoxExperimento.ForeColor = Color.LightBlue;
                cmbPlaneta.ForeColor = Color.LightBlue;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightBlue;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightBlue;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightBlue;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightBlue;
                txtAltura.ForeColor = Color.LightBlue;
                txtEspaco.ForeColor = Color.LightBlue;
                txtgravit.ForeColor = Color.LightBlue;
                txtVelocidade.ForeColor = Color.LightBlue;
            }
            if (i == 9)
            {
                richTextBoxDados.ForeColor = Color.LightSalmon;
                groupBoxDados.ForeColor = Color.LightSalmon;
                groupBoxControl.ForeColor = Color.LightSalmon;
                groupBoxConfiguracao.ForeColor = Color.LightSalmon;
                groupBoxPlanetas.ForeColor = Color.LightSalmon;
                groupBoxGraficos.ForeColor = Color.LightSalmon;
                groupBoxResultados.ForeColor = Color.LightSalmon;
                groupBoxExperimento.ForeColor = Color.LightSalmon;
                cmbPlaneta.ForeColor = Color.LightSalmon;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightSalmon;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightSalmon;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightSalmon;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightSalmon;
                txtAltura.ForeColor = Color.LightSalmon;
                txtEspaco.ForeColor = Color.LightSalmon;
                txtgravit.ForeColor = Color.LightSalmon;
                txtVelocidade.ForeColor = Color.LightSalmon;
            }
            if (i == 10)
            {
                richTextBoxDados.ForeColor = Color.LightPink;
                groupBoxDados.ForeColor = Color.LightPink;
                groupBoxControl.ForeColor = Color.LightPink;
                groupBoxConfiguracao.ForeColor = Color.LightPink;
                groupBoxPlanetas.ForeColor = Color.LightPink;
                groupBoxGraficos.ForeColor = Color.LightPink;
                groupBoxResultados.ForeColor = Color.LightPink;
                groupBoxExperimento.ForeColor = Color.LightPink;
                cmbPlaneta.ForeColor = Color.LightPink;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightPink;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightPink;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.LightPink;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.LightPink;
                txtAltura.ForeColor = Color.LightPink;
                txtEspaco.ForeColor = Color.LightPink;
                txtgravit.ForeColor = Color.LightPink;
                txtVelocidade.ForeColor = Color.LightPink;
            }
            if (i == 1)
            {
                richTextBoxDados.ForeColor = Color.Cyan;
                groupBoxDados.ForeColor = Color.Cyan;
                groupBoxControl.ForeColor = Color.Cyan;
                groupBoxConfiguracao.ForeColor = Color.Cyan;
                groupBoxExperimento.ForeColor = Color.Cyan;
                cmbPlaneta.ForeColor = Color.Cyan;
                chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
                chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
                chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Cyan;
                chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Cyan;
                groupBoxPlanetas.ForeColor = Color.Cyan;
                groupBoxGraficos.ForeColor = Color.Cyan;
                groupBoxResultados.ForeColor = Color.Cyan;
                txtAltura.ForeColor = Color.Cyan;
                txtEspaco.ForeColor = Color.Cyan;
                txtgravit.ForeColor = Color.Cyan;
                txtVelocidade.ForeColor = Color.Cyan;
            }
        }
        private void richTextBoxDados_TextChanged(object sender, EventArgs e)
        {

        }

        private void Altura_Click(object sender, EventArgs e)
        {

        }
        private void checkBoxVacuum_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void Simulator_Load(object sender, EventArgs e)
        {

        }
        private void pictureBoxCorpo_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxGrafico_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3D_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3D.Checked)
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chartSpace.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartSpeed.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }
    }
}
