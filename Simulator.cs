using freeFall.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;


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

        public int corpoCounter = 0;

        public int countAnimation = 0;

        public int countFocus = 0;

        public int flagVaccumObject = 0;

        public double NumberTermsTime = 0.0;

        public int greatestvalueTime = 0;

        public int countVaccum = 0;
        public int countPaper  = 0;
        public int countBody   = 0;
        public int countGrafic = 0;

        // -- 
        DataSet ds = null;
        DataTable dt = null;
        public static string planetName, gravity, airResistence, initialVelocityBody, finalVelocityBody, experimentTimeBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper;
        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum;
        // -- 

        public static int[] Ax = new int[15];
        public  Simulator()
        {
            InitializeComponent();
            Opacity = 0;
            timerEixos.Enabled = true;
          
            cmbPlaneta.Text = "Terra";
            txtAltura.Text = "10";
            txtgravit.Text = "9,8";
            comboBoxVacuum.Text = "Folha";
            comboShet.Text = "Aberta";
            spaceGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            speedGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            calculateValues();

            // ----
            dataGridViewPlanets.BackgroundColor = Color.Black;
            dataGridViewPlanets.DefaultCellStyle.BackColor = Color.Black;
            dataGridViewPlanets.GridColor = Color.Cyan;
            dataGridViewPlanets.DefaultCellStyle.ForeColor = Color.Cyan;
            dataGridViewPlanets.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridViewPlanets.DefaultCellStyle.Font = new Font(dataGridViewPlanets.DefaultCellStyle.Font.FontFamily,9);
            dataGridViewPlanets.AllowUserToResizeColumns = false;
            dataGridViewPlanets.AllowUserToResizeRows = false;
            // ---
           
            loadData();
            startGrid();
            Flip();

            timerOpacity.Enabled = true;

        }
        public void updatePosition(int countBody, int countPaper, int countVaccum)
        {
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                if (greatestvalueTime == 1 || greatestvalueTime == 0)
                {
                    textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                }
                if (countBody == Program.corpo.NumberOfTerms + 1)
                {
                    timerAnimation.Enabled = false;
                    if (greatestvalueTime == 1 || greatestvalueTime == 0)
                    {
                        BTNIniciar.Text = "Posicionar";
                        buttonStartControl = 3;
                        enabledConfigure(0);
                    }
                }
                pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
                Console.WriteLine(Program.paper.Pixels[countPaper]);
                textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
                textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
                countPaper = countPaper + 1;
                if (greatestvalueTime == 2)
                {
                    textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
                }
                if (countPaper == Program.paper.NumberOfTerms + 1)
                {
                    timerAnimationPaper.Enabled = false;
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    enabledConfigure(0);
                }
                pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
                textBoxVaccumHeight.Text = "" + Math.Round(Program.vaccum.Space[countVaccum], 3);
                textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
                if (greatestvalueTime == 3)
                {
                    textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
                }
                if (countVaccum == Program.vaccum.NumberOfTerms + 1)
                {
                    timerAnimationVacuum.Enabled = false;
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    enabledConfigure(0);
                }
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                    txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                    txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                    if (greatestvalueTime == 1 || greatestvalueTime == 0)
                    {
                        textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                    }
                    if (countBody == Program.corpo.NumberOfTerms + 1)
                    {
                        timerAnimation.Enabled = false;
                        if (greatestvalueTime == 1 || greatestvalueTime == 0)
                        {
                            BTNIniciar.Text = "Posicionar";
                            buttonStartControl = 3;
                            enabledConfigure(0);
                        }
                    }
                    pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
                    Console.WriteLine(Program.paper.Pixels[countPaper]);
                    textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
                    textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
                    countPaper = countPaper + 1;
                    if (greatestvalueTime == 2)
                    {
                        textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
                    }
                    if (countPaper == Program.paper.NumberOfTerms + 1)
                    {
                        timerAnimationPaper.Enabled = false;
                        BTNIniciar.Text = "Posicionar";
                        buttonStartControl = 3;
                        enabledConfigure(0);
                    }
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                        txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                        txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                        if (greatestvalueTime == 1 || greatestvalueTime == 0)
                        {
                            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                        }
                        if (countBody == Program.corpo.NumberOfTerms + 1)
                        {
                            timerAnimation.Enabled = false;
                            if (greatestvalueTime == 1 || greatestvalueTime == 0)
                            {
                                BTNIniciar.Text = "Posicionar";
                                buttonStartControl = 3;
                                enabledConfigure(0);
                            }
                        }
                        pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
                        textBoxVaccumHeight.Text = "" + Math.Round(Program.vaccum.Space[countVaccum], 3);
                        textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
                        if (greatestvalueTime == 3)
                        {
                            textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
                        }
                        if (countVaccum == Program.vaccum.NumberOfTerms + 1)
                        {
                            timerAnimationVacuum.Enabled = false;
                            BTNIniciar.Text = "Posicionar";
                            buttonStartControl = 3;
                            enabledConfigure(0);
                        }
                    }
                    else
                    {
                        pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                        txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                        txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                        if (greatestvalueTime == 1 || greatestvalueTime == 0)
                        {
                            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                        }
                        if (countBody == Program.corpo.NumberOfTerms + 1)
                        {
                            timerAnimation.Enabled = false;
                            if (greatestvalueTime == 1 || greatestvalueTime == 0)
                            {
                                BTNIniciar.Text = "Posicionar";
                                buttonStartControl = 3;
                                enabledConfigure(0);
                            }
                        }
                    }
                }
            }
        }
        private void pictureBoxTimeLeft_Click(object sender, EventArgs e)
        {
            pictureBoxTimeLeft.Visible = false;
            pictureBoxTimeRight.Visible = true;
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                countBody--;
                countPaper--;
                countVaccum--;
                updatePosition(countBody, countPaper, countVaccum);
                if (countBody == 0 ||countPaper == 0 || countVaccum == 0)
                {
                    pictureBoxTimeLeft.Visible = false;
                }
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    countBody--;
                    countPaper--;
                    updatePosition(countBody, countPaper, 0);
                    if (countBody == 0 || countPaper == 0)
                    {
                        pictureBoxTimeLeft.Visible = false;
                    }
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        countBody--;
                        countVaccum--;
                        updatePosition(countBody, 0, countVaccum);
                        if (countBody == 0 || countVaccum == 0)
                        {
                            pictureBoxTimeLeft.Visible = false;
                        }
                    }
                    else
                    {
                        countBody--;
                        updatePosition(countBody, 0, 0);
                        if (countBody == 0)
                        {
                            pictureBoxTimeLeft.Visible = false;
                        }
                    }
                }
            }
            pictureBoxTimeLeft.Visible = true;
        }

        private void pictureBoxTimeRight_Click(object sender, EventArgs e)
        {
            pictureBoxTimeRight.Visible = false;
            pictureBoxTimeLeft.Visible = true;
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                countBody++;
                countPaper++;
                countVaccum++;
                updatePosition(countBody, countPaper, countVaccum);
                if(Program.numberOfPoints == countBody || Program.numberOfPoints == countPaper || Program.numberOfPoints == countVaccum)
                {
                    pictureBoxTimeRight.Visible = false;
                }
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    countBody++;
                    countPaper++;
                    updatePosition(countBody, countPaper, 0);
                    if (Program.numberOfPoints == countBody || Program.numberOfPoints == countPaper)
                    {
                        pictureBoxTimeRight.Visible = false;
                    }
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        countBody++;
                        countVaccum++;
                        updatePosition(countBody, 0, countVaccum);
                        if (Program.numberOfPoints == countBody || Program.numberOfPoints == countVaccum)
                        {
                            pictureBoxTimeRight.Visible = false;
                        }
                    }
                    else
                    {
                        countBody++;
                        updatePosition(countBody, 0, 0);
                        if (Program.numberOfPoints == countBody)
                        {
                            pictureBoxTimeRight.Visible = false;
                        }
                    }
                }
            }
            pictureBoxTimeRight.Visible = true;
        }
        private void Simulator_Load(object sender, EventArgs e)
        {
            dataGridViewPlanets.CurrentCell = null;
        }
        public void clear ()
        {
            pictureBoxCorpo.Location = new Point(145, 30);
            pictureBoxCorpoPaper.Location = new Point(222, 30);
            pictureBoxVacuum.Location = new Point(16, 13);

            countVaccum = 0;
            countPaper  = 0;
            countBody   = 0;
            countGrafic = 0;

            Program.corpo.TimeAllExperiment  = 0.0;
            Program.paper.TimeAllExperiment  = 0.0;
            Program.vaccum.TimeAllExperiment = 0.0;
        }

        public void enabledConfigure(int Operation)
        {
            if (Operation == 1)
            {
                txtAltura.Enabled = false;
                cmbPlaneta.Enabled = false;
                comboBoxVacuum.Enabled = false;
                comboShet.Enabled = false;
                checkBoxVacuum.Enabled = false;
                checkBoxLeaf.Enabled = false;
                checkBoxResistance.Enabled = false;
                pictureBoxBack.Enabled = false;
                pictureBoxNext.Enabled = false;
                pictureBoxBack.Visible = false;
                pictureBoxNext.Visible = false;
                txtgravit.Enabled = false;
            }
            else
            {
                txtAltura.Enabled = true;
                cmbPlaneta.Enabled = true;
                comboBoxVacuum.Enabled = true;
                comboShet.Enabled = true;
                checkBoxVacuum.Enabled = true;
                checkBoxLeaf.Enabled = true;
                checkBoxResistance.Enabled = true;
                pictureBoxBack.Enabled = true;
                pictureBoxNext.Enabled = true;
                pictureBoxBack.Visible = true;
                pictureBoxNext.Visible = true;
                txtgravit.Enabled = true;
            }
        }
        public void animation ()
        {
            if(Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                timerAnimation.Enabled = true;
                timerGrafic.Enabled = true;
                timerAnimationPaper.Enabled = true;
                timerAnimationVacuum.Enabled = true;
            }
            else
            {
                if(Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    timerAnimation.Enabled = true;
                    timerGrafic.Enabled = true;
                    timerAnimationPaper.Enabled = true;
                    timerAnimationVacuum.Enabled = false;
                }
                else
                {
                    if(Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        timerAnimation.Enabled = true;
                        timerGrafic.Enabled = true;
                        timerAnimationPaper.Enabled = false;
                        timerAnimationVacuum.Enabled = true;
                    }
                    else
                    {
                        timerAnimation.Enabled = true;
                        timerGrafic.Enabled = true;
                        timerAnimationPaper.Enabled = false;
                        timerAnimationVacuum.Enabled = false;
                    }
                }
            }
        }
        public void calculateValues()
        {
            Program.planetName = cmbPlaneta.Text;
            Program.height = Program.organizeData(txtAltura.Text);
            Program.gravity = Program.organizeData(txtgravit.Text);

            if (Program.airResistance == 0)
            {
                Program.corpo.CalculateOutResistence(Program.height, Program.gravity, 0);
                Program.paper.CalculateOutResistence(Program.height, Program.gravity, 0);
                Program.vaccum.CalculateOutResistence(Program.height, Program.gravity, 0);
            }
            else
            {
                Program.corpo.CalculateWithResistence(Program.height, Program.gravity, 0, 1);
                Program.paper.CalculateWithResistence(Program.height, Program.gravity, 0, 1);
                Program.vaccum.CalculateOutResistence(Program.height, Program.gravity, 0);
            }
        }


        private void organizeGrafics()
        {
            int espacodiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);
            int velocidadediv = Convert.ToInt32(Math.Round(Program.corpo.FinalVelocity, 0) / 5);

            spaceGraphic(Program.corpo.NumberOfTerms, 0, Program.height + 20, espacodiv, 0, (Program.corpo.TimeAllExperiment * 100), 0);
            speedGraphic(Program.corpo.NumberOfTerms, 0, Convert.ToInt32(Program.corpo.FinalVelocity) + 20, velocidadediv, 0, (Program.corpo.TimeAllExperiment * 100), 0);
        }
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
            txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
            txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
            countBody = countBody + 1;
            if (greatestvalueTime == 1 || greatestvalueTime == 0)
            {
                textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
            }
            if (countBody == Program.corpo.NumberOfTerms+1)
            {
                timerAnimation.Enabled = false;
                if (greatestvalueTime == 1 || greatestvalueTime == 0)
                {
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    enabledConfigure(0);
                }
            }
        }
        private void timerAnimationPaper_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
            textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
            textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
            countPaper = countPaper + 1;
            if (greatestvalueTime == 2)
            {
                textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
            }
            if (countPaper == Program.paper.NumberOfTerms + 1)
            {
                timerAnimationPaper.Enabled = false;
                BTNIniciar.Text = "Posicionar";
                buttonStartControl = 3;
                enabledConfigure(0);
            }
        }

        private void timerAnimationVacuum_Tick(object sender, EventArgs e)
        {
            pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);           
            textBoxVaccumHeight.Text = "" + Math.Round(Program.vaccum.Space[countVaccum], 3);
            textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
            countVaccum = countVaccum + 1;
            if (greatestvalueTime == 3)
            {
                textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
            }
            if (countVaccum == Program.vaccum.NumberOfTerms + 1)
            {
                timerAnimationVacuum.Enabled = false;
                BTNIniciar.Text = "Posicionar";
                buttonStartControl = 3;
                enabledConfigure(0);
            }
        }
        public void receveidGreatestValueTime ()
        {
            if (Program.corpo.TimeAllExperiment > Program.paper.TimeAllExperiment && Program.corpo.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestvalueTime = 1;
                Program.numberOfPoints = Program.corpo.NumberOfTerms;
            }
            else if (Program.paper.TimeAllExperiment > Program.corpo.TimeAllExperiment && Program.paper.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestvalueTime = 2;
                Program.numberOfPoints = Program.corpo.NumberOfTerms;
            }
            else if (Program.vaccum.TimeAllExperiment > Program.corpo.TimeAllExperiment && Program.vaccum.TimeAllExperiment > Program.paper.TimeAllExperiment)
            {
                Program.greatestvalueTime = 3;
                Program.numberOfPoints = Program.corpo.NumberOfTerms;
            }
            else
            {
                Program.greatestvalueTime = 0;
            }
            greatestvalueTime = Program.greatestvalueTime;
        }
        private void timerGrafic_Tick(object sender, EventArgs e)
        {
           
           
            if(countGrafic/2 == 0)
            {
                chartSpace.Series["Espaço"].Points.AddXY(countGrafic, Program.corpo.Space[countGrafic]);
                chartSpeed.Series["Velocidade"].Points.AddXY(countGrafic, Program.corpo.Velocity[countGrafic]);
            }
            countGrafic += 1;
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

        private void BTNIniciar_Click(object sender, EventArgs e)
        {
           
            if (buttonStartControl == 0)
            {
                    clear();
                    calculateValues();
                    receveidGreatestValueTime();
                    enabledConfigure(1);
                    loadData();
                    startGrid();
                    Flip();
                    organizeGrafics();
                    animation();
                    BTNIniciar.Text = "Parar";
                    buttonStartControl = 1;
            }
            else
            {
                if (buttonStartControl == 1)
                {
                    BTNIniciar.Text = "Continuar";
                    buttonStartControl = 2;
                    timerAnimation.Enabled = false;
                    timerAnimationPaper.Enabled = false;
                    timerAnimationVacuum.Enabled = false;
                    pictureBoxTimeLeft.Visible = true;
                    pictureBoxTimeRight.Visible= true;
                }
                else
                {
                    if(buttonStartControl == 2)
                    {
                        BTNIniciar.Text = "Parar";
                        buttonStartControl = 1;
                        pictureBoxTimeLeft.Visible = false;
                        pictureBoxTimeRight.Visible = false;
                        if (Program.paperOn && Program.vaccumOn)
                        {
                            timerAnimation.Enabled = true;
                            timerAnimationPaper.Enabled = true;
                            timerAnimationVacuum.Enabled = true;
                        }
                        else
                        {
                            if(Program.paperOn = false && Program.vaccumOn)
                            {
                                timerAnimation.Enabled = true;
                                timerAnimationVacuum.Enabled = true;
                            }
                            else
                            {
                                if(Program.vaccumOn = false && Program.paperOn)
                                {
                                    timerAnimation.Enabled = true;
                                    timerAnimationPaper.Enabled = true;
                                }
                                else
                                {
                                    timerAnimation.Enabled = true;
                                    Console.WriteLine("hue");
                                }
                            }
                        }
                    }
                    else
                    {
                        if(buttonStartControl == 3)
                        {
                            clear();
                            calculateValues();
                            BTNIniciar.Text = "Iniciar";
                            buttonStartControl = 0;
                        }
                    }
                }
               
            }
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            if (Program.experimentDataControl == 0)
            {
                ExperimentData windowExperiment = new ExperimentData();
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
                    ConfigurePlanet windowConfigurePlanet = new ConfigurePlanet();
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
                ConfigurePlanet windowConfigurePlanet = new ConfigurePlanet();
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
            chartSpace.Series.Clear();
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
            //for (i = 0; i < n; i++)
            //{
              //  chartSpace.Series[Serie].Points.AddXY((i), Program.corpo.Space[i]);
            //}
        }

        public void speedGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            int i;
            string Serie = "Velocidade";
            var chart = chartSpeed.ChartAreas[0];
            chartSpeed.Series.Clear();
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
            chartSpeed.Series[Serie].Color = Color.Blue;
            //for (i = 0; i < n; i++)
            //{
            //    chartSpeed.Series[Serie].Points.AddXY((i), Program.corpo.Velocity[i]);
           // }
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
                Program.vaccumOn = true;
            }
            else
            {
                comboBoxVacuum.Enabled = false;
                groupBoxVacuum.Visible = false;
                pictureBoxVacuum.Visible = false;
                pictureBoxGauge.Visible = false;
                Program.vaccumOn = false;
            }
        }

        private void checkBoxLeaf_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxLeaf.Checked)
            {
                comboShet.Enabled = true;
                pictureBoxCorpoPaper.Visible = true;
                Program.paperOn = true;
            }
            else
            {
                comboShet.Enabled = false;
                pictureBoxCorpoPaper.Visible = false;
                Program.paperOn = false;
            }
        }

        private void comboBoxVacuum_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxVacuum.Text == "Bóla")
            {
                pictureBoxVacuum.Image = pictureBoxCorpo.Image;
                pictureBoxVaccumObject.Image = pictureBoxCorpo.Image;
                flagVaccumObject = 1;
            }
            else
            {
                pictureBoxVacuum.Image = Properties.Resources.paper2;
                pictureBoxVaccumObject.Image = Properties.Resources.paper2;
                flagVaccumObject = 0;
            }
        }

        private void comboShet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboShet.Text == "Aberta")
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper2;
                pictureBoxPaper.Image = Properties.Resources.paper2;
            }
            else
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper3;
                pictureBoxPaper.Image = Properties.Resources.paper3;
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
                pictureBoxCorpo.Image = Properties.Resources.corpoBall4;
                pictureBoxCorpoView.Image = Properties.Resources.corpoBall4;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBall4;
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBall4;
                }
            }
            if (corpoCounter == 2)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBasketball;
                pictureBoxCorpoView.Image = Properties.Resources.corpoBasketball;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBasketball;
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBasketball;
                }
            }
            if (corpoCounter == 3)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBowling;
                pictureBoxCorpoView.Image = Properties.Resources.corpoBowling;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBowling;
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBowling;
                }
            }
            if (corpoCounter == 4)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoGolf;
                pictureBoxCorpoView.Image = Properties.Resources.corpoGolf;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoGolf;
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoGolf;
                }
            }
            if (corpoCounter == 5)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoSoccer;
                pictureBoxCorpoView.Image = Properties.Resources.corpoSoccer;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoSoccer;
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoSoccer;
                }
                corpoCounter = 0;
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

        public void startGrid()
        {
            ds = new DataSet();
            dt = new DataTable();

            dt = GetCustomersOutAirResistence();
            ds.Tables.Add(dt);

            DataView my_DataView = ds.Tables[0].DefaultView;
            this.dataGridViewPlanets.DataSource = my_DataView;
        }
        private void Flip()
        {
            DataSet new_ds = FlipDataSet(ds); 
            DataView my_DataView = new_ds.Tables[0].DefaultView;
            this.dataGridViewPlanets.DataSource = my_DataView;
            dataGridViewPlanets.CurrentCell = null;
        }
        public DataSet FlipDataSet(DataSet my_DataSet)
        {
            DataSet ds = new DataSet();

            foreach (DataTable dt in my_DataSet.Tables)
            {
                DataTable table = new DataTable();

                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    table.Columns.Add(Convert.ToString(i));
                }
                DataRow r;
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    r = table.NewRow();
                    r[0] = dt.Columns[k].ToString();
                    for (int j = 1; j <= dt.Rows.Count; j++)
                        r[j] = dt.Rows[j - 1][k];
                    table.Rows.Add(r);
                }

                ds.Tables.Add(table);
            }
            return ds;
        }

        private void checkBoxLeaf_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            Opacity = 1;
            timerOpacity.Enabled = false;
        }



        private void dataGridViewPlanets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.experimentDataControl == 0)
            {
                ExperimentData windowExperiment = new ExperimentData();
                windowExperiment.Show();
            }
        }

        private static DataTable GetCustomersOutAirResistence()
        {
            
            DataTable table = new DataTable();
            table.TableName = "Customers";
            table.Columns.Clear();
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Gravidade", typeof(string));
            table.Columns.Add("Resis. Ar", typeof(string));
            table.Columns.Add("T.corpo", typeof(string));
            table.Columns.Add("V.ini. corpo", typeof(string));
            table.Columns.Add("V.fin. corpo", typeof(string));

            if (Program.paperOn)
            {
                table.Columns.Add("T. papel", typeof(string));
                table.Columns.Add("V.ini. papel", typeof(string));
                table.Columns.Add("V.fin. papel", typeof(string));

            }
            if (Program.vaccumOn)
            {
                table.Columns.Add("T. vacuo", typeof(string));
                table.Columns.Add("V.ini. vacuo", typeof(string));
                table.Columns.Add("V.fin. vacuo", typeof(string));

            }

            if (Program.paperOn && Program.vaccumOn)
            {
                table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper,
                 experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum});
            }
            else
            {
                if (Program.paperOn == false && Program.vaccumOn)
                {
                    table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                    initialVelocityBody, finalVelocityBody, experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum });
                }
                else
                {
                    if (Program.paperOn && Program.vaccumOn == false)
                    {
                        table.Rows.Add(new object[] { planetName, gravity, airResistence, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper });
                    }
                    else
                    {
                        table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody });
                    }
                }
            }
          
            table.AcceptChanges();
            return table;
        }

        public void loadData()
        {
            planetName = Program.planetName;
            gravity = "" + Math.Round(Program.gravity, 2) + " m/s²";

            initialVelocityBody = "" + Math.Round(Program.corpo.InitialVelocity, 2) + " m/s";
            finalVelocityBody = "" + Math.Round(Program.corpo.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                airResistence = "Não";
                experimentTimeBody = "" + Math.Round(Program.corpo.TimeAllExperiment, 2) + " s";
            }
            else
            {
                airResistence = "Sim";
                experimentTimeBody = "" + Math.Round(Program.corpo.TimeAllExperiment, 2) + " s";
            }

            initialVelocityPaper = "" + Math.Round(Program.paper.InitialVelocity, 2) + " m/s";
            finalVelocityPaper = "" + Math.Round(Program.paper.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                experimentTimePaper = "" + Math.Round(Program.paper.TimeAllExperiment, 2) + " s";
            }
            else
            {
                experimentTimePaper = "" + Math.Round(Program.paper.TimeAllExperiment, 2) + " s";
            }

            initialVelocityVaccum = "" + Math.Round(Program.vaccum.InitialVelocity, 2) + " m/s";
            finalVelocityVaccum = "" + Math.Round(Program.vaccum.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                experimentTimeVaccum = "" + Math.Round(Program.vaccum.TimeAllExperiment, 2) + " s";
            }
            else
            {
                experimentTimeVaccum = "" + Math.Round(Program.vaccum.TimeAllExperiment, 2) + " s";
            }
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
