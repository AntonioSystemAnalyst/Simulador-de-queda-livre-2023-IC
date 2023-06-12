using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace freeFall
{
    public partial class Simulator : Form
    {

        ExperimentData windowExperiment;
        Space windowSpace;
        Speed windowSpeed;

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

        public int greatestValueTime = 0;

        public int openGraficsControl = 0;

        public int spaceDiv = 0;

        private bool isPictureBoxClickedRight = false;
        private bool isPictureBoxClickedLeft = false;

        public int countVaccum = 0;
        public int countPaper = 0;
        public int countBody = 0;
        public int countGrafic = 0;

        // -- 
        DataSet ds = null;
        DataTable dt = null;
        public static string planetName, gravity, airResistence, initialVelocityBody, finalVelocityBody, experimentTimeBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper;
        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum;
        // -- 

        public static int[] Ax = new int[15];
        public Simulator()
        {
            InitializeComponent();
            Opacity = 0;
            timerEixos.Enabled = true;
            initialConfigure();

            spaceGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            speedGraphicIniti(10, 0, 150, 50, 0, 10, 0);

            calculateValues();
            receveidGreatestValueTime();
            CountDivisibleByValue(20);

            dataGridConfigure();
            loadData();
            startGrid();
            Flip();

            timerOpacity.Enabled = true;

        }
        private void closeAllWindows()
        {
            if (windowExperiment != null && !windowExperiment.IsDisposed)
            {
                windowExperiment.Close();
                windowExperiment = null;
                Program.experimentDataControl = 0;
            }
            if (windowSpace != null && !windowSpace.IsDisposed)
            {
                windowSpace.Close();
                windowSpace = null;
                openGraficsControl = 1;
            }
            if (windowSpeed != null && !windowSpeed.IsDisposed)
            {
                windowSpeed.Close();
                windowSpeed = null;
                openGraficsControl = 1;
            }
        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            rightPosition();
        }
        private void timerLeft_Tick(object sender, EventArgs e)
        {
            leftPosition();
        }
        private void Simulator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.J)
            {
                MessageBox.Show("Log Liberado!!!");
                buttonLogo.Visible = true;
            }
        }
        private void pictureBoxTimeRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPictureBoxClickedRight = true;
                timerRight.Enabled = true;
            }
        }
        private void pictureBoxTimeRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPictureBoxClickedRight = false;
                timerRight.Enabled = false;
            }
        }
        private void pictureBoxTimeLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPictureBoxClickedLeft = true;
                timerLeft.Enabled = true;
            }
        }
        private void pictureBoxTimeLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPictureBoxClickedLeft = false;
                timerLeft.Enabled = false;
            }
        }

        private void Simulator_Load(object sender, EventArgs e)
        {
            dataGridDataView.CurrentCell = null;
        }
        public void clear()
        {
            pictureBoxCorpo.Location = new Point(145, 30);
            pictureBoxCorpoPaper.Location = new Point(222, 30);
            pictureBoxVacuum.Location = new Point(16, 13);

            countVaccum = 0;
            countPaper  = 0;
            countBody   = 0;
            countGrafic = 0;

            Program.corpo.TimeAllExperiment = 0.0;
            Program.paper.TimeAllExperiment = 0.0;
            Program.vaccum.TimeAllExperiment = 0.0;
        }

        public void enabledConfigure(int Operation)
        {
            if (Operation == 1)
            {
                boxHeight.Enabled = false;
                cmbPlaneta.Enabled = false;
                comboBoxVacuum.Enabled = false;
                comboPaper.Enabled = false;
                checkBoxVacuum.Enabled = false;
                checkBoxPaper.Enabled = false;
                checkBoxResistance.Enabled = false;
                pictureBoxBack.Enabled = false;
                pictureBoxNext.Enabled = false;
                pictureBoxBack.Visible = false;
                pictureBoxNext.Visible = false;
                txtgravit.Enabled = false;
                buttonBall.Enabled = false;
            }
            else
            {
                boxHeight.Enabled = true;
                cmbPlaneta.Enabled = true;
                comboBoxVacuum.Enabled = true;
                comboPaper.Enabled = true;
                checkBoxVacuum.Enabled = true;
                checkBoxPaper.Enabled = true;
                checkBoxResistance.Enabled = true;
                pictureBoxBack.Enabled = true;
                pictureBoxNext.Enabled = true;
                pictureBoxBack.Visible = true;
                pictureBoxNext.Visible = true;
                txtgravit.Enabled = true;
                buttonBall.Enabled = true;
            }
        }
        public void animation()
        {
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                timerAnimation.Enabled = true;
                timerGrafic.Enabled = true;
                timerAnimationPaper.Enabled = true;
                timerAnimationVacuum.Enabled = true;
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    timerAnimation.Enabled = true;
                    timerGrafic.Enabled = true;
                    timerAnimationPaper.Enabled = true;
                    timerAnimationVacuum.Enabled = false;
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
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
            Program.height = Program.organizeData(boxHeight.Text);
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

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
            txtEspaco.Text = "" + Math.Round(-1 * (Math.Round(Program.corpo.Space[countBody], 3) - Program.height),2);
            txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
            if (greatestValueTime == 1 || greatestValueTime == 0)
            {
                textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
            }
            countBody = countBody + 1;
            if (countBody == Program.corpo.NumberOfTerms + 1)
            {
                timerAnimation.Enabled = false;
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    openGraficsControl = 1;
                    labelGraficDetails.Visible = true;
                    enabledConfigure(0);
                }
            }
        }
        private void timerAnimationPaper_Tick(object sender, EventArgs e)
        {
            pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
            textBoxPaperHeight.Text = "" + Math.Round(-1 * (Math.Round(Program.paper.Space[countPaper], 3)- Program.height), 2);
            textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
            if (greatestValueTime == 2)
            {
                textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
            }
            countPaper = countPaper + 1;
            if (countPaper == Program.paper.NumberOfTerms + 1)
            {
                timerAnimationPaper.Enabled = false;
                BTNIniciar.Text = "Posicionar";
                buttonStartControl = 3;
                openGraficsControl = 1;
                labelGraficDetails.Visible = true;
                enabledConfigure(0);
            }
        }

        private void timerAnimationVacuum_Tick(object sender, EventArgs e)
        {
            pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
            textBoxVaccumHeight.Text = "" + Math.Round(-1 * (Math.Round(Program.vaccum.Space[countVaccum], 3)- Program.height),2);
            textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
            if (greatestValueTime == 3)
            {
                textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
            }
            countVaccum = countVaccum + 1;
            if (countVaccum == Program.vaccum.NumberOfTerms + 1)
            {
                timerAnimationVacuum.Enabled = false;
                BTNIniciar.Text = "Posicionar";
                buttonStartControl = 3;
                openGraficsControl = 1;
                labelGraficDetails.Visible = true;
                enabledConfigure(0);
            }
        }
        public void receveidGreatestValueTime()
        {
            if (Program.corpo.TimeAllExperiment > Program.paper.TimeAllExperiment && Program.corpo.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 1;
                Program.numberOfPoints = Program.corpo.NumberOfTerms;
            }
            else if (Program.paper.TimeAllExperiment > Program.corpo.TimeAllExperiment && Program.paper.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 2;
                Program.numberOfPoints = Program.paper.NumberOfTerms;
            }
            else if (Program.vaccum.TimeAllExperiment > Program.corpo.TimeAllExperiment && Program.vaccum.TimeAllExperiment > Program.paper.TimeAllExperiment)
            {
                Program.greatestValueTime = 3;
                Program.numberOfPoints = Program.vaccum.NumberOfTerms;
            }
            else
            {
                Program.greatestValueTime = 0;
                Program.numberOfPoints = Program.corpo.NumberOfTerms;
            }
            greatestValueTime = Program.greatestValueTime;
        }
        private void timerGrafic_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                chartSpace.Invoke((MethodInvoker)delegate
                {
                    if (countGrafic % 20 == 0)
                    {

                        if (Program.bodyOn)
                        {
                            if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                            {
                                chartSpace.Series["Bóla"].Points.AddXY(countGrafic, Program.corpo.Space[countGrafic]);
                                chartSpeed.Series["Bóla"].Points.AddXY(countGrafic, Program.corpo.Velocity[countGrafic]);
                            }
                        }
                        if (Program.paperOn)
                        {
                            if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                            {
                                chartSpace.Series["Papel"].Points.AddXY(countGrafic, Program.paper.Space[countGrafic]);
                                chartSpeed.Series["Papel"].Points.AddXY(countGrafic, Program.paper.Velocity[countGrafic]);
                            }
                        }
                        if (Program.vaccumOn)
                        {
                            if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                            {
                                chartSpace.Series["Objeto no vácuo"].Points.AddXY(countGrafic, Program.vaccum.Space[countGrafic]);
                                chartSpeed.Series["Objeto no vácuo"].Points.AddXY(countGrafic, Program.vaccum.Velocity[countGrafic]);
                            }
                        }
                        Console.WriteLine("" + countGrafic);
                    }
                    countGrafic = countGrafic + 1;
                    if (countGrafic == Program.numberOfPoints)
                    {
                        timerGrafic.Enabled = false;
                    }
                });
            });
        }
        public void CountDivisibleByValue(int value)
        {
            int count = 1, contVetor = 0;

            for (int i = 0; i <= Program.numberOfPoints; i++)
            {
                if (i % value == 0)
                {
                    count++;
                }
            }
            Program.vetorCountPointGrafic = new int[count+2];
            Program.vetorCountPointGrafic[0] = 0;
            for (int i = 0; i <= Program.numberOfPoints; i++)
            {
                if (i % value == 0)
                {
                    Program.vetorCountPointGrafic[contVetor] = i;
                    contVetor++;
                }
            }

        }
        public void updateGrafic(int countGrafic, int op)
        {
            int lastIndexSpace, lastIndexSpeed, i;
            bool status = false;
            for(i=0; i<Program.vetorCountPointGrafic.Length; i++)
            {
                if(countGrafic == Program.vetorCountPointGrafic[i])
                {
                    status = true;
                }
            }
            if(status)
            {
                if (op == 0)
                {
                    if (Program.bodyOn)
                    {
                        if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            speedGraphic(countGrafic, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            Console.WriteLine("Space - countGrafic +: " + countGrafic);
                            
                        }
                    }
                    if (Program.paperOn)
                    {
                        if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                        {
                            chartSpace.Series["Papel"].Points.AddXY(countGrafic, Program.paper.Space[countGrafic]);
                            chartSpeed.Series["Papel"].Points.AddXY(countGrafic, Program.paper.Velocity[countGrafic]);

                        }
                    }
                    if (Program.vaccumOn)
                    {
                        if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                        {
                            chartSpace.Series["Objeto no vácuo"].Points.AddXY(countGrafic, Program.vaccum.Space[countGrafic]);
                            chartSpeed.Series["Objeto no vácuo"].Points.AddXY(countGrafic, Program.vaccum.Velocity[countGrafic]);

                        }
                    }
                }
                else
                {
                    if (Program.bodyOn)
                    {
                        if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            speedGraphic(countGrafic, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            Console.WriteLine("Space - countGrafic -: " + countGrafic);
                        }
                    }
                    if (Program.paperOn)
                    {
                        if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                        {
                            lastIndexSpace = chartSpace.Series["Papel"].Points.Count - 1;
                            chartSpace.Series["Papel"].Points.RemoveAt(lastIndexSpace);
                            lastIndexSpeed = chartSpeed.Series["Papel"].Points.Count - 1;
                            chartSpeed.Series["Papel"].Points.RemoveAt(lastIndexSpeed);

                        }
                    }
                    if (Program.vaccumOn)
                    {
                        if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                        {
                            lastIndexSpace = chartSpace.Series["Objeto no vácuo"].Points.Count - 1;
                            chartSpace.Series["Objeto no vácuo"].Points.RemoveAt(lastIndexSpace);
                            lastIndexSpeed = chartSpeed.Series["Objeto no vácuo"].Points.Count - 1;
                            chartSpeed.Series["Objeto no vácuo"].Points.RemoveAt(lastIndexSpeed);
                        }
                    }
                }
            }
        }

        private void timerEixos_Tick(object sender, EventArgs e)
        {
            if (checkBoxEixo.Checked)
            {
                pictureBoxSetaY.Visible = true;
                pictureBoxSetaX.Visible = true;
                pictureBoxBase.Visible  = false;
                pictureBoxAx.Visible    = true;
                labelZero.Visible       = true;
                labelY.Visible          = true;
                labelX.Visible          = true;
            }
            else
            {
                pictureBoxSetaY.Visible = false;
                pictureBoxSetaX.Visible = false;
                pictureBoxBase.Visible  = true;
                pictureBoxAx.Visible    = false;
                labelZero.Visible       = false;
                labelY.Visible          = false;
                labelX.Visible          = false;
            }
        }

        private void BTNIniciar_Click(object sender, EventArgs e)
        {

            if (buttonStartControl == 0)
            {
                clear();
                closeAllWindows();
                calculateValues();
                receveidGreatestValueTime();
                CountDivisibleByValue(20);
                enabledConfigure(1);
                loadData();
                startGrid();
                Flip();
                buildGrafic();
                animation();
                BTNIniciar.Text = "Parar";
                buttonStartControl = 1;
                openGraficsControl = 0;
                labelGraficDetails.Visible = false;
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
                    timerGrafic.Enabled = false;
                    if (greatestValueTime == 0 || greatestValueTime == 1)
                    {
                        if (Program.numberOfPoints - countBody > 3)
                        {
                            pictureBoxTimeLeft.Visible = true;
                            pictureBoxTimeRight.Visible = true;
                        }
                    }
                    else
                    {
                        if (greatestValueTime == 2)
                        {
                            if (Program.numberOfPoints - countPaper > 3)
                            {
                                pictureBoxTimeLeft.Visible = true;
                                pictureBoxTimeRight.Visible = true;
                            }
                        }
                        else
                        {
                            if (greatestValueTime == 3)
                            {
                                if (Program.numberOfPoints - countVaccum > 3)
                                {
                                    pictureBoxTimeLeft.Visible = true;
                                    pictureBoxTimeRight.Visible = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (buttonStartControl == 2)
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
                            timerGrafic.Enabled = true;
                        }
                        else
                        {
                            if (Program.paperOn = false && Program.vaccumOn)
                            {
                                timerAnimation.Enabled = true;
                                timerAnimationVacuum.Enabled = true;
                                timerGrafic.Enabled = true;
                            }
                            else
                            {
                                if (Program.vaccumOn = false && Program.paperOn)
                                {
                                    timerAnimation.Enabled = true;
                                    timerAnimationPaper.Enabled = true;
                                    timerGrafic.Enabled = true;
                                }
                                else
                                {
                                    timerAnimation.Enabled = true;
                                    timerGrafic.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (buttonStartControl == 3)
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
                windowExperiment = new ExperimentData();
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
        public void dataGridConfigure()
        {
            dataGridDataView.BackgroundColor = Color.Black;
            dataGridDataView.DefaultCellStyle.BackColor = Color.Black;
            dataGridDataView.GridColor = Color.Cyan;
            dataGridDataView.DefaultCellStyle.ForeColor = Color.Cyan;
            dataGridDataView.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridDataView.DefaultCellStyle.Font = new Font(dataGridDataView.DefaultCellStyle.Font.FontFamily, 9);
            dataGridDataView.AllowUserToResizeColumns = false;
            dataGridDataView.AllowUserToResizeRows = false;
        }
        public void initialConfigure()
        {
            cmbPlaneta.Text = "Terra";
            boxHeight.Text = "10";
            txtgravit.Text = "9,8";
            comboBoxVacuum.Text = "Folha";
            comboPaper.Text = "Aberta";
            textBoxPaperHeight.Text = " --";
            textBoxPaperVelocity.Text = " --";
            textBoxVaccumHeight.Text = " --";
            textBoxVaccumVelocity.Text = " --";
            checkBox3D.Checked = false;
            KeyPreview = true;
            KeyDown += Simulator_KeyDown;
        }
        public void buildGrafic()
        {
            chartSpace.Series.Clear();
            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 2);

            if (Program.greatestValueTime == 0)
            {
               spaceGraphic(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
               speedGraphic(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 1)
            {
                spaceGraphic(Program.corpo.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
                speedGraphic(Program.corpo.NumberOfTerms, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 2)
            {
                spaceGraphic(Program.paper.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 0);
                speedGraphic(Program.paper.NumberOfTerms, 0, Program.paper.FinalVelocity + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 0);
            }
            if (Program.greatestValueTime == 3)
            {
                spaceGraphic(Program.vaccum.NumberOfTerms, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 0);
                speedGraphic(Program.vaccum.NumberOfTerms, 0, Program.vaccum.FinalVelocity + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 0);
            }

        }
        // --------------------------------------

        // chart Configuration // n = quantidade de termos // Mm = Y minimo
        // Mm = Y minimo // MM = Y max // interY = intervalo em Y
        // interX = intervalo em X    // Max = X max // Mmx = X minimu

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
                if(op == 1)
                {
                    for (i=0; i<n; i++)
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
                chartSpace.Series.Add("Objeto no vácuo");
                chartSpace.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        chartSpace.Series["Objeto no vácuo"].Points.AddXY(i, Program.vaccum.Space[i]);
                    }
                }
            }
        }


        public void speedGraphic(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx, int op)
        {
            int i;

            var chart = chartSpeed.ChartAreas[0];
            chartSpeed.Series.Clear();
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

            chartSpeed.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpeed.Series.Add("Bóla");
                chartSpeed.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bóla"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Bóla"].Points.AddXY(0, 0);
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        chartSpeed.Series["Bóla"].Points.AddXY(i, Program.corpo.Velocity[i]);
                    }
                }

            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Papel"].Points.AddXY(0, 0);
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        chartSpeed.Series["Papel"].Points.AddXY(i, Program.paper.Velocity[i]);
                    }
                }

            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("Objeto no vácuo");
                chartSpeed.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Objeto no vácuo"].Points.AddXY(0, 0);
                if (op == 1)
                {
                    for (i = 0; i < n; i++)
                    {
                        chartSpeed.Series["Objeto no vácuo"].Points.AddXY(i, Program.vaccum.Velocity[i]);
                    }
                }
            }

        }

        public void speedGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpeed.ChartAreas[0];

            chartSpeed.Titles.Add("Velocidade pelo tempo");
            chartSpeed.ChartAreas[0].AxisX.Title = "T(s/100)";
            chartSpeed.ChartAreas[0].AxisY.Title = "V(m/s)";
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

            chartSpeed.Series.Add("teste");

            if (Program.bodyOn)
            {
                chartSpeed.Series.Add("Bóla");
                chartSpeed.Series["Bóla"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Bóla"].Color = Color.Red;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Bóla"].BorderWidth = 10;
                chartSpeed.Series["Bóla"].Points.AddXY(0, 0);

            }
            if (Program.paperOn)
            {
                chartSpeed.Series.Add("Papel");
                chartSpeed.Series["Papel"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Papel"].Color = Color.Blue;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Papel"].Points.AddXY(0, 0);

            }
            if (Program.vaccumOn)
            {
                chartSpeed.Series.Add("Objeto no vácuo");
                chartSpeed.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpeed.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpeed.Series[0].IsVisibleInLegend = false;
                chartSpeed.Series["Objeto no vácuo"].Points.AddXY(0, 0);
            }

        }
        public void spaceGraphicIniti(int n, double Mm, double MM, double InterY, double interX, double Max, double Mmx)
        {
            var chart = chartSpace.ChartAreas[0];

            chartSpace.Titles.Add("Espaço pelo tempo");
            chartSpace.ChartAreas[0].AxisX.Title = "T(s/100)";
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
                chartSpace.Series.Add("Objeto no vácuo");
                chartSpace.Series["Objeto no vácuo"].ChartType = SeriesChartType.Spline;
                chartSpace.Series["Objeto no vácuo"].Color = Color.Cyan;
                chartSpace.Series[0].IsVisibleInLegend = false;
                chartSpace.Series["Objeto no vácuo"].Points.AddXY(0, 0);
            }
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
                textBoxVaccumHeight.Text = "";
                textBoxVaccumVelocity.Text = "";
            }
            else
            {
                comboBoxVacuum.Enabled = false;
                groupBoxVacuum.Visible = false;
                pictureBoxVacuum.Visible = false;
                pictureBoxGauge.Visible = false;
                Program.vaccumOn = false;
                textBoxVaccumHeight.Text = " --";
                textBoxVaccumVelocity.Text = " --";
            }
        }

        private void checkBoxLeaf_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxPaper.Checked)
            {
                comboPaper.Enabled = true;
                pictureBoxCorpoPaper.Visible = true;
                Program.paperOn = true;
                textBoxPaperHeight.Text = "";
                textBoxPaperVelocity.Text = "";
            }
            else
            {
                comboPaper.Enabled = false;
                pictureBoxCorpoPaper.Visible = false;
                Program.paperOn = false;
                textBoxPaperHeight.Text = " --";
                textBoxPaperVelocity.Text = " --";
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
            if (comboPaper.Text == "Aberta")
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
            if (openGraficsControl == 1)
            {
                windowSpace = new Space();
                windowSpace.Show();
            }
        }
        private void chartSpeed_Click(object sender, EventArgs e)
        {
            if (openGraficsControl == 1)
            {
                windowSpeed = new Speed();
                windowSpeed.Show();
            }
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
            toolTip.SetToolTip(checkBoxPaper, "Corpo com alta resistência ao ar.");
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
            toolTip.SetToolTip(buttonBall, "Muda a imagem do corpo.");
        }

        private void buttonData_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonData, "Exibe os dados configurados do experimento.");
        }
        public void updatePosition(int countGrafic, int op, int countBody, int countPaper, int countVaccum)
        {
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                }
                pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
                Console.WriteLine(Program.paper.Pixels[countPaper]);
                textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
                textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
                countPaper = countPaper + 1;
                if (greatestValueTime == 2)
                {
                    textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
                }
                pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
                textBoxVaccumHeight.Text = "" + Math.Round(Program.vaccum.Space[countVaccum], 3);
                textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
                if (greatestValueTime == 3)
                {
                    textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
                }
                updateGrafic(countGrafic, op);
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                    txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                    txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                    if (greatestValueTime == 1 || greatestValueTime == 0)
                    {
                        textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                    }
                    pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
                    Console.WriteLine(Program.paper.Pixels[countPaper]);
                    textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
                    textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
                    countPaper = countPaper + 1;
                    if (greatestValueTime == 2)
                    {
                        textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
                    }
                    updateGrafic(countGrafic, op);
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                        txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                        txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                        if (greatestValueTime == 1 || greatestValueTime == 0)
                        {
                            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                        }
                        pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
                        textBoxVaccumHeight.Text = "" + Math.Round(Program.vaccum.Space[countVaccum], 3);
                        textBoxVaccumVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[countVaccum], 3);
                        if (greatestValueTime == 3)
                        {
                            textTempo.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[countVaccum], 3);
                        }
                        updateGrafic(countGrafic, op);
                    }
                    else
                    {
                        pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
                        txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                        txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                        if (greatestValueTime == 1 || greatestValueTime == 0)
                        {
                            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                        }
                        updateGrafic(countGrafic, op);
                    }
                }
            }
        }
        private void leftPosition()
        {
            pictureBoxTimeRight.Visible = true;
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                countBody--;
                countPaper--;
                countVaccum--;
                countGrafic--;
                updatePosition(countGrafic, 1, countBody, countPaper, countVaccum);
                if (countBody == 0 || countPaper == 0 || countVaccum == 0)
                {
                    pictureBoxTimeLeft.Visible = false;
                    timerLeft.Enabled = false;
                }
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    countBody--;
                    countPaper--;
                    countGrafic--;
                    updatePosition(countGrafic, 1, countBody, countPaper, 0);
                    if (countBody == 0 || countPaper == 0)
                    {
                        pictureBoxTimeLeft.Visible = false;
                        timerLeft.Enabled = false;
                    }
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        countBody--;
                        countVaccum--;
                        countGrafic--;
                        updatePosition(countGrafic, 1, countBody, 0, countVaccum);
                        if (countBody == 0 || countVaccum == 0)
                        {
                            pictureBoxTimeLeft.Visible = false;
                            timerLeft.Enabled = false;
                        }
                    }
                    else
                    {
                        updatePosition(countGrafic, 1, countBody, 0, 0);
                        countBody--;
                        countGrafic--;
                       
                        if (countBody == 0)
                        {
                            pictureBoxTimeLeft.Visible = false;
                            timerLeft.Enabled = false;
                        }
                    }
                }
            }
        }
        private void rightPosition()
        {
            if (isPictureBoxClickedRight)
            {
                pictureBoxTimeLeft.Visible = true;
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
                {
                    countBody++;
                    countPaper++;
                    countVaccum++;
                    countGrafic++;
                    updatePosition(countGrafic, 0, countBody, countPaper, countVaccum);
                    if (Program.numberOfPoints - 2 == countBody || Program.numberOfPoints - 2 == countPaper || Program.numberOfPoints - 2 == countVaccum)
                    {
                        pictureBoxTimeRight.Visible = false;
                        timerRight.Enabled = false;
                    }
                }
                else
                {
                    if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                    {
                        countBody++;
                        countPaper++;
                        countGrafic++;
                        updatePosition(countGrafic, 0, countBody, countPaper, 0);
                        if (Program.numberOfPoints - 2 == countBody || Program.numberOfPoints - 2 == countPaper)
                        {
                            pictureBoxTimeRight.Visible = false;
                            timerRight.Enabled = false;
                        }
                    }
                    else
                    {
                        if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                        {
                            countBody++;
                            countVaccum++;
                            countGrafic++;
                            updatePosition(countGrafic, 0, countBody, 0, countVaccum);
                            if (Program.numberOfPoints - 2 == countBody || Program.numberOfPoints - 2 == countVaccum)
                            {
                                pictureBoxTimeRight.Visible = false;
                                timerRight.Enabled = false;
                            }
                        }
                        else
                        {
                            countBody++;
                            countGrafic++;
                            updatePosition(countGrafic, 0, countBody, 0, 0);
                            if (Program.numberOfPoints - 2 == countBody)
                            {
                                pictureBoxTimeRight.Visible = false;
                                timerRight.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        private void trackBarPlanets_Scroll(object sender, EventArgs e)
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

        public void startGrid()
        {
            ds = new DataSet();
            dt = new DataTable();

            dt = GetCustomersOutAirResistence();
            ds.Tables.Add(dt);

            DataView my_DataView = ds.Tables[0].DefaultView;
            this.dataGridDataView.DataSource = my_DataView;
        }
        private void Flip()
        {
            DataSet new_ds = FlipDataSet(ds);
            DataView my_DataView = new_ds.Tables[0].DefaultView;
            this.dataGridDataView.DataSource = my_DataView;
            dataGridDataView.CurrentCell = null;
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

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            Opacity = 1;
            colorAll();
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
        public void colorAll()
        {
            groupBoxControl.ForeColor = Program.colorSimulator;
            groupBoxConfiguracao.ForeColor = Program.colorSimulator;
            groupBoxPlanetas.ForeColor = Program.colorSimulator;
            groupBoxGraficos.ForeColor = Program.colorSimulator;
            groupBoxResultados.ForeColor = Program.colorSimulator;
            groupBoxExperimento.ForeColor = Program.colorSimulator;
            cmbPlaneta.ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            boxHeight.ForeColor = Program.colorSimulator;
            txtEspaco.ForeColor = Program.colorSimulator;
            txtgravit.ForeColor = Program.colorSimulator;
            txtVelocidade.ForeColor = Program.colorSimulator;
            textBoxPaperHeight.ForeColor = Program.colorSimulator;
            textBoxPaperVelocity.ForeColor = Program.colorSimulator;
            textBoxVaccumHeight.ForeColor = Program.colorSimulator;
            textBoxVaccumVelocity.ForeColor = Program.colorSimulator;
            groupBoxData.ForeColor = Program.colorSimulator;
            dataGridDataView.ForeColor = Program.colorSimulator;
            labelTextColor.ForeColor = Program.colorSimulator;
            labelGraficDetails.ForeColor = Program.colorSimulator;
            comboPaper.ForeColor = Program.colorSimulator;
            comboBoxVacuum.ForeColor = Program.colorSimulator;
            textTempo.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpeed.Titles[0].ForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpeed.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.LabelStyle.ForeColor = Program.colorSimulator;
            chartSpace.Titles[0].ForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisX.TitleForeColor = Program.colorSimulator;
            chartSpace.ChartAreas[0].AxisY.TitleForeColor = Program.colorSimulator;
        }
        private void Altura_Click(object sender, EventArgs e)
        {

        }
        private void checkBoxVacuum_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chartSpace_Click(object sender, EventArgs e)
        {

        }

        private void timerLog_Tick(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void labelY_Click(object sender, EventArgs e)
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
        private void checkBoxLeaf_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void comboPaper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkBox3D_MouseHover(object sender, EventArgs e)
        {

        }
        private void pictureBoxTimeLeft_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxTimeRight_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxTimeRight_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
