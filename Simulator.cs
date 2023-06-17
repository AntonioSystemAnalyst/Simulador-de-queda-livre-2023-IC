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

        GraficSpaceWindow spaceWindow = new GraficSpaceWindow();
        GraficSpeedWindow speedWindow = new GraficSpeedWindow();
        AnimationWindow animationWindow = new AnimationWindow();

        public static int[] Ax = new int[15];
        public Simulator()
        {
            InitializeComponent();
            Opacity = 0;
            timerEixos.Enabled = true;
            initialConfigure();

            initiWindows();

            spaceWindow.spaceGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            speedWindow.speedGraphicIniti(10, 0, 150, 50, 0, 10, 0);

            calculateValues();
            receveidGreatestValueTime();

            dataGridConfigure();
            loadData();
            startGrid();
            Flip();

            timerOpacity.Enabled = true;

        }

        public void initiWindows()
        {
            spaceWindow.TopLevel = false;
            spaceWindow.FormBorderStyle = FormBorderStyle.None;
            spaceWindow.Dock = DockStyle.Fill;
            panelSpace.Controls.Add(spaceWindow);
            spaceWindow.Show();

            speedWindow.TopLevel = false;
            speedWindow.FormBorderStyle = FormBorderStyle.None;
            speedWindow.Dock = DockStyle.Fill;
            panelSpeed.Controls.Add(speedWindow);
            speedWindow.Show();

            animationWindow.TopLevel = false;
            animationWindow.FormBorderStyle = FormBorderStyle.None;
            animationWindow.Dock = DockStyle.Fill;
            panelAnimation.Controls.Add(animationWindow);
            animationWindow.Show();
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
                Program.openGraficsControl = 1;
            }
            if (windowSpeed != null && !windowSpeed.IsDisposed)
            {
                windowSpeed.Close();
                windowSpeed = null;
                Program.openGraficsControl = 1;
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
            animationWindow.clearPostion();

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
                if(Program.crumpledPaper == 0)
                {
                    Program.paper.DragCoefficient = 0.7;
                }
                else
                {
                    Program.paper.DragCoefficient = 0.1;
                }
                Program.corpo.CalculateWithResistence(Program.height, Program.gravity, 0);
                Program.paper.CalculateWithResistence(Program.height, Program.gravity, 0);
                Program.vaccum.CalculateOutResistence(Program.height, Program.gravity, 0);
            }
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            animationWindow.animationCorpo(countBody);
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
                    Program.openGraficsControl = 1;
                    labelGraficDetails.Visible = true;
                    enabledConfigure(0);
                }
            }
        }
        private void timerAnimationPaper_Tick(object sender, EventArgs e)
        {
            animationWindow.animationPaper(countPaper);
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
                Program.openGraficsControl = 1;
                labelGraficDetails.Visible = true;
                enabledConfigure(0);
            }
        }

        private void timerAnimationVacuum_Tick(object sender, EventArgs e)
        {
            animationWindow.animationVaccum(countVaccum);
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
                Program.openGraficsControl = 1;
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
            if (Program.bodyOn)
            {
                if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                {
                    spaceWindow.addPointCorpo(countGrafic);
                    speedWindow.addPointCorpo(countGrafic);
                }
            }
            if (Program.paperOn)
            {
                if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                {
                    spaceWindow.addPointPaper(countGrafic);
                    speedWindow.addPointPaper(countGrafic);
                }
            }
            if (Program.vaccumOn)
            {
                if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                {
                    spaceWindow.addPointVaccum(countGrafic);
                    speedWindow.addPointVaccum(countGrafic);
                }
            }
            countGrafic = countGrafic + 1;
            if (countGrafic == Program.numberOfPoints)
            {
                timerGrafic.Enabled = false;
            }
        }

        public void updateGrafic(int countGrafic, int op)
        {
                if (op == 0)
                {
                    if (Program.bodyOn)
                    {
                        if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            Console.WriteLine("Space - countGrafic +: " + countGrafic);
                            
                        }
                    }
                    if (Program.paperOn)
                    {
                        if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.paper.FinalVelocity + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 1);

                        }
                    }
                    if (Program.vaccumOn)
                    {
                        if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.vaccum.FinalVelocity + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 1);

                        }
                    }
                }
                else
                {
                    if (Program.bodyOn)
                    {
                        if (Program.corpo.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.corpo.FinalVelocity + 1, spaceDiv, 0, ((Program.corpo.TimeAllExperiment * 100) + 1), 0, 1);
                        }
                    }
                    if (Program.paperOn)
                    {
                        if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.paper.FinalVelocity + 1, spaceDiv, 0, ((Program.paper.TimeAllExperiment * 100) + 1), 0, 1);

                        }
                    }
                    if (Program.vaccumOn)
                    {
                        if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                        {
                            spaceWindow.spaceGraphic(countGrafic, 0, Program.height + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 1);
                            speedWindow.speedGraphic(countGrafic, 0, Program.vaccum.FinalVelocity + 1, spaceDiv, 0, ((Program.vaccum.TimeAllExperiment * 100) + 1), 0, 1);
                        }
                    }
                }
        }

        private void timerEixos_Tick(object sender, EventArgs e)
        {
           
        }

        private void BTNIniciar_Click(object sender, EventArgs e)
        {

            if (buttonStartControl == 0)
            {
                clear();
                closeAllWindows();
                calculateValues();
                spaceWindow.buildGrafic();
                speedWindow.buildGrafic();
                receveidGreatestValueTime();
                enabledConfigure(1);
                loadData();
                startGrid();
                Flip();
                animation();
                BTNIniciar.Text = "Parar";
                buttonStartControl = 1;
                Program.openGraficsControl = 0;
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
        
        private void checkBoxVacuum_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxVacuum.Checked)
            {
                comboBoxVacuum.Enabled = true;
                animationWindow.picutureVaccum(0);
                Program.vaccumOn = true;
                textBoxVaccumHeight.Text = "";
                textBoxVaccumVelocity.Text = "";
            }
            else
            {
                comboBoxVacuum.Enabled = false;
                animationWindow.picutureVaccum(1);
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
                animationWindow.picuturePaper(0);
                Program.paperOn = true;
                textBoxPaperHeight.Text = "";
                textBoxPaperVelocity.Text = "";
            }
            else
            {
                comboPaper.Enabled = false;
                animationWindow.picuturePaper(1);
                Program.paperOn = false;
                textBoxPaperHeight.Text = " --";
                textBoxPaperVelocity.Text = " --";
            }
        }

        private void comboBoxVacuum_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxVacuum.Text == "Bóla")
            {
                animationWindow.vacuumSelectedValueChange(0);
                pictureBoxVaccumObject.Image = animationWindow.vaccumImage();
                flagVaccumObject = 1;
            }
            else
            {
                animationWindow.vacuumSelectedValueChange(1);
                pictureBoxVaccumObject.Image = Properties.Resources.paper2;
                flagVaccumObject = 0;
            }
        }

        private void comboShet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboPaper.Text == "Aberta")
            {
                animationWindow.pictureBoxCorpoPaperSelected(0);
                pictureBoxPaper.Image = Properties.Resources.paper2;
                Program.crumpledPaper = 1;
            }
            else
            {
                animationWindow.pictureBoxCorpoPaperSelected(1);
                pictureBoxPaper.Image = Properties.Resources.paper3;
                Program.crumpledPaper = 0;
            }
        }

        private void checkBoxResistance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxResistance.Checked)
            {
                animationWindow.picutureResistence(0);
                Program.airResistance = 1;
            }
            else
            {
                animationWindow.picutureResistence(1);
                Program.airResistance = 0;
            }
        }

        private void chartSpace_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.openGraficsControl == 1)
            {
                windowSpace = new Space();
                windowSpace.Show();
            }
        }
        private void chartSpeed_Click(object sender, EventArgs e)
        {
            if (Program.openGraficsControl == 1)
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
                pictureBoxCorpoView.Image = Properties.Resources.corpoBall4;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBall4;
                }
                animationWindow.picuture(corpoCounter, flagVaccumObject);
            }
            if (corpoCounter == 2)
            {
                pictureBoxCorpoView.Image = Properties.Resources.corpoBasketball;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBasketball;
                }
                animationWindow.picuture(corpoCounter, flagVaccumObject);
            }
            if (corpoCounter == 3)
            {
                pictureBoxCorpoView.Image = Properties.Resources.corpoBowling;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoBowling;
                }
                animationWindow.picuture(corpoCounter, flagVaccumObject);
            }
            if (corpoCounter == 4)
            {
                pictureBoxCorpoView.Image = Properties.Resources.corpoGolf;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoGolf;
                }
                animationWindow.picuture(corpoCounter, flagVaccumObject);
            }
            if (corpoCounter == 5)
            {
                pictureBoxCorpoView.Image = Properties.Resources.corpoSoccer;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVaccumObject.Image = Properties.Resources.corpoSoccer;
                }
                animationWindow.picuture(corpoCounter, flagVaccumObject);
                corpoCounter = 0;
            }
        }

        private void planetData()
        {
            if (planetCounter == 1)
            {
                txtgravit.Text = "9,8";
                cmbPlaneta.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 1.225;
            }
            if (planetCounter == 2)
            {
                txtgravit.Text = "1,624";
                cmbPlaneta.Text = "Lua";
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                buttonPlanet.Text = "Lua";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0;
            }
            if (planetCounter == 3)
            {
                txtgravit.Text = "3,7";
                cmbPlaneta.Text = "Mercúrio";
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                buttonPlanet.Text = "Mercúrio";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.0054;
            }
            if (planetCounter == 4)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Vênus";
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                buttonPlanet.Text = "Vênus";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 67;
            }
            if (planetCounter == 5)
            {
                txtgravit.Text = "3,71";
                cmbPlaneta.Text = "Marte";
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                buttonPlanet.Text = "Marte";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.020;
            }
            if (planetCounter == 6)
            {
                txtgravit.Text = "24,79";
                cmbPlaneta.Text = "Júpter";
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                buttonPlanet.Text = "Júpter";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.16;
            }
            if (planetCounter == 7)
            {
                txtgravit.Text = "10,4";
                cmbPlaneta.Text = "Saturno";
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                buttonPlanet.Text = "Saturno";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.13;
            }
            if (planetCounter == 8)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Urano";
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                buttonPlanet.Text = "Urano";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.46;
            }
            if (planetCounter == 9)
            {
                txtgravit.Text = "11,15";
                cmbPlaneta.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.0054;
            }
            if (planetCounter == 10)
            {
                txtgravit.Text = "9,8";
                cmbPlaneta.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.45;
            }
        }
        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            planetCounter += 1;
            Program.planetCounter = planetCounter;
            Program.planetNameReceveid(planetCounter);
            planetData();
            if (planetCounter == 10)
            {
                planetCounter = 1;
            }
        }


        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            planetCounter -= 1;
            Program.planetCounter = planetCounter;
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 0)
            {
                planetCounter = 9;
            }
            planetData();
        }
        private void cmbPlaneta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPlaneta.Text == "Terra")
            {
                planetCounter = 1;
            }
            if (cmbPlaneta.Text == "Lua")
            {
                planetCounter = 2;
            }
            if (cmbPlaneta.Text == "Mercúrio")
            {
                planetCounter = 3;
            }
            if (cmbPlaneta.Text == "Vênus")
            {
                planetCounter = 4;
            }
            if (cmbPlaneta.Text == "Marte")
            {
                planetCounter = 5;
            }
            if (cmbPlaneta.Text == "Júpter")
            {
                planetCounter = 6;
            }
            if (cmbPlaneta.Text == "Saturno")
            {
                planetCounter = 7;
            }
            if (cmbPlaneta.Text == "Urano")
            {
                planetCounter = 8;
            }
            if (cmbPlaneta.Text == "Netuno")
            {
                planetCounter = 9;
            }
            planetData();
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
                animationWindow.animationCorpo(countBody);
                txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                }
                animationWindow.animationPaper(countPaper);
                Console.WriteLine(Program.paper.Pixels[countPaper]);
                textBoxPaperHeight.Text = "" + Math.Round(Program.paper.Space[countPaper], 3);
                textBoxPaperVelocity.Text = "" + Math.Round(Program.paper.Velocity[countPaper], 3);
                countPaper = countPaper + 1;
                if (greatestValueTime == 2)
                {
                    textTempo.Text = "" + Math.Round(Program.paper.CountTimeExperiment[countPaper], 3);
                }
                animationWindow.animationVaccum(countVaccum);
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
                    animationWindow.animationCorpo(countBody);
                    txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                    txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                    if (greatestValueTime == 1 || greatestValueTime == 0)
                    {
                        textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                    }
                    animationWindow.animationPaper(countPaper);
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
                        animationWindow.animationCorpo(countBody);
                        txtEspaco.Text = "" + Math.Round(Program.corpo.Space[countBody], 3);
                        txtVelocidade.Text = "" + Math.Round(Program.corpo.Velocity[countBody], 3);
                        if (greatestValueTime == 1 || greatestValueTime == 0)
                        {
                            textTempo.Text = "" + Math.Round(Program.corpo.CountTimeExperiment[countBody], 3);
                        }
                        animationWindow.animationVaccum(countVaccum);
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
                        animationWindow.animationCorpo(countBody);
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
                spaceWindow.grafic3dSpace(0);
                speedWindow.grafic3dSpeed(0);
            }
            else
            {
                spaceWindow.grafic3dSpace(1);
                speedWindow.grafic3dSpeed(1);
            }
        }
        public void colorAll()
        {
            groupBoxControl.ForeColor = Program.colorSimulator;
            groupBoxConfiguracao.ForeColor = Program.colorSimulator;
            groupBoxPlanetas.ForeColor = Program.colorSimulator;
            groupBoxGraficos.ForeColor = Program.colorSimulator;
            groupBoxResultados.ForeColor = Program.colorSimulator;
            cmbPlaneta.ForeColor = Program.colorSimulator;
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
            spaceWindow.colorAll();
            speedWindow.colorAll();
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

        private void checkBoxEixo_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxEixo.Checked)
            {
                animationWindow.picutureEixos(0);
            }
            else
            {
                animationWindow.picutureEixos(1);
            }
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
