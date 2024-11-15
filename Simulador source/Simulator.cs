﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace freeFall
{
    public partial class Simulator : Form
    {
        ExperimentData windowExperiment;
        Space windowSpace;
        Speed windowSpeed;
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        public bool isClickable = true;
        public int planetCounter = 1;
        public int buttonStartControl = 0;
        public int animationNumberCounter = 0;
        public int corpoCounter = 0;
        public int countAnimation = 0;
        public int countFocus = 0;
        public int flagVaccumObject = 0;
        public int greatestValueTime = 0;
        public int openGraficsControl = 0;
        public int spaceDiv = 0;
        public int sound = 0; // ativa os sons
        public int countVaccum = 0;
        public int countPaper = 0;
        public int countBody = 0;
        public int countValues = 0;
        public int countGrafic = 0;
        public int flagVenus = 0;
        private bool isPictureBoxClickedLeft = false;
        private bool isPictureBoxClickedRight = false;
        public double NumberTermsTime = 0.0;
        public static string planetName, gravity, height, airResistence, airDensity, initialVelocityBody, finalVelocityBody, experimentTimeBody, DragCoefficientBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper, DragCoefficientPaper;
        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum, DragCoefficientVaccum;
        public static string paperStates = "Aberta";
        public static int[] Ax = new int[15];
        public GraficSpaceWindow spaceWindow = new GraficSpaceWindow();
        public GraficSpeedWindow speedWindow = new GraficSpeedWindow();
        public AnimationWindow animationWindow = new AnimationWindow();

        public Simulator()
        {
            InitializeComponent();
            planetCounter = Program.planeTrackBar;
            Opacity = 0;
            timerEixos.Enabled = true;
            timerColors.Enabled = true;
            timerTrackBar.Enabled = true;
            timerAirResistence.Enabled = true;
            initialConfigure();
            initiWindows();
            spaceWindow.spaceGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            speedWindow.speedGraphicIniti(10, 0, 150, 50, 0, 10, 0);
            loadinDataCorpos();
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
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Simulator_PreviewKeyDown);
        }

        private void loadinDataCorpos()
        {
            // bola da fifa - 450 gramas - 70 cm de cicurnferencia 
            // folha A4  0.06237; // amaçada 0.001341640872

            Program.gravity = 9.8;

            Program.ball.Mass = 0.45;
            Program.ball.DragCoefficient = 0.45;
            Program.ball.CrossSectionalArea = 0.03899;

            Program.paper.Mass = 0.00468;
            Program.paper.DragCoefficient = 1.17; // amassado 0.8
            Program.paper.CrossSectionalArea = 0.06237; // amassado 0.00134

            Program.vaccum.Mass = Program.paper.Mass;
            Program.vaccum.DragCoefficient = Program.paper.DragCoefficient;
            Program.vaccum.CrossSectionalArea = Program.paper.CrossSectionalArea;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showLogs();
        }
        public void showLogs()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" Logs");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" airResistence: " + Program.airResistance);
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" C. Arrasto, ball: " + Program.ball.DragCoefficient);
            Console.WriteLine(" Area, ball : " + Program.ball.CrossSectionalArea);
            Console.WriteLine(" Massa, ball: " + Program.ball.Mass);
            Console.WriteLine(" tempo, ball: " + Program.ball.TimeAllExperiment);
            Console.WriteLine(" number of T: " + Program.ball.NumberOfTerms);
            Console.WriteLine(" V. Final: " + Program.ball.FinalVelocity);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" C. Arrasto, papel: " + Program.paper.DragCoefficient);
            Console.WriteLine(" Area, papel : " + Program.paper.CrossSectionalArea);
            Console.WriteLine(" Massa, papel: " + Program.paper.Mass);
            Console.WriteLine(" tempo, papel: " + Program.paper.TimeAllExperiment);
            Console.WriteLine(" number of T: " + Program.paper.NumberOfTerms);
            Console.WriteLine(" V. Final: " + Program.paper.FinalVelocity);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" C. Arrasto, vaccum: " + Program.vaccum.DragCoefficient);
            Console.WriteLine(" Area, vaccum : " + Program.vaccum.CrossSectionalArea);
            Console.WriteLine(" Massa, vaccum: " + Program.vaccum.Mass);
            Console.WriteLine(" tempo, vaccum: " + Program.vaccum.TimeAllExperiment);
            Console.WriteLine(" number of T: " + Program.vaccum.NumberOfTerms);
            Console.WriteLine(" V. Final: " + Program.vaccum.FinalVelocity);
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" Maior valor de tempo: " + Program.greatestValueTime);
            Console.WriteLine(" Maior valor de velocidade: " + Program.greatestValueVelocity);
            Console.WriteLine("---------------------------------");
        }
        private void closeAllWindows()
        {
            if (windowExperiment != null && !windowExperiment.IsDisposed)
            {
                windowExperiment.Close();
                windowExperiment = null;
                Program.experimentDataControl = 0;
            }
            spaceWindow.closeAllWindow();
            speedWindow.closeAllWindow();
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
            trackBarColors.Value = Program.colorTrackBar;
            colorAll();
        }

        private void timerTrackBar_Tick(object sender, EventArgs e)
        {
            trackBarColors.Value = Program.colorTrackBar;
        }
        public void simulatorTrackBarValue()
        {
            trackBarColors.Value = Program.colorTrackBar;
        }
        public void clear()
        {
            animationWindow.clearPostion();

            countVaccum = 0;
            countPaper = 0;
            countBody = 0;
            countGrafic = 0;
            animationNumberCounter = 0;

            Program.ball.TimeAllExperiment = 0.0;
            Program.paper.TimeAllExperiment = 0.0;
            Program.vaccum.TimeAllExperiment = 0.0;
        }

        public void clearTextBox()
        {
            txtEspaco.Text = "";
            txtVelocidade.Text = "";
            textTempo.Text = "";

            if (Program.paperOn)
            {
                textBoxPaperHeight.Text = "";
                textBoxPaperVelocity.Text = "";
            }
            if(Program.vaccumOn)
            {
                textBoxVaccumHeight.Text = "";
                textBoxVaccumVelocity.Text = "";
            }
        }

        public void enabledConfigure(int Operation)
        {
            if (Operation == 1)
            {
                buttonData.Text = "Visualizar";
                buttonData.Enabled = false;
                boxHeight.Enabled = false;
                cmbPlaneta.Enabled = false;
                comboBoxVacuum.Enabled = false;
                comboPaper.Enabled = false;
                checkBoxVacuum.Enabled = false;
                checkBoxPaper.Enabled = false;
                checkBoxResistanceRV1.Enabled = false;
                pictureBoxBack.Enabled = false;
                pictureBoxNext.Enabled = false;
                pictureBoxBack.Visible = false;
                pictureBoxNext.Visible = false;
                txtgravit.Enabled = false;
                textBoxAirDensity.Enabled = false;
            }
            else
            {
                buttonData.Text = "Visualizar";
                buttonData.Enabled = true;
                boxHeight.Enabled = true;
                cmbPlaneta.Enabled = true;
                checkBoxPaper.Enabled = true;
                checkBoxVacuum.Enabled = true;
                checkBoxResistanceRV1.Enabled = true;
                labelTextStart.Location = new Point(17, 24);
                labelTextStart.Text = "PRONTO!";
                pictureBoxBack.Enabled = true;
                pictureBoxNext.Enabled = true;
                pictureBoxBack.Visible = true;
                pictureBoxNext.Visible = true;
                txtgravit.Enabled = true;
                textBoxAirDensity.Enabled = true;
                if (checkBoxPaper.Checked == true && Program.planetName != "Vênus")
                {
                    comboPaper.Enabled = true;
                }
                if (checkBoxVacuum.Checked == true)
                {
                    comboBoxVacuum.Enabled = true;
                }
            }
        }

        private void timerAirResistence_Tick(object sender, EventArgs e)
        {
            if (checkBoxResistanceRV1.Checked == true)
            {
                animationWindow.picutureResistence(0);
                Program.airResistance = 1;
                textBoxAirDensity.Text = "" + Program.airDensity;
            }
            if (checkBoxResistanceRV1.Checked == false)
            {
                animationWindow.picutureResistence(1);
                Program.airResistance = 0;
                textBoxAirDensity.Text = " --";
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

            if (Program.airResistance == 0 || planetCounter == 2 || planetCounter == 3)
            {
                Program.ball.CalculateOutResistence(Program.height, Program.gravity, 0);
                Program.paper.CalculateOutResistence(Program.height, Program.gravity, 0);
                Program.vaccum.CalculateOutResistence(Program.height, Program.gravity, 0);
            }
            else
            {
                if (Program.airResistance == 1)
                {
                    if (Program.bodyOn)
                    {
                        Program.ball.CalculateWithResistenceRV1(Program.height, Program.gravity, Program.airDensity);
                    }
                    if (Program.paperOn)
                    {
                        Program.paper.CalculateWithResistenceRV1(Program.height, Program.gravity, Program.airDensity);
                    }
                    if (Program.vaccumOn)
                    {
                        Program.vaccum.CalculateOutResistence(Program.height, Program.gravity, 0);
                    }
                }
            }
        }
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (countGrafic < Program.ballSpaceTableIndex)
            {
                animationWindow.animationCorpo(countGrafic);
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countGrafic], 4).ToString("0.0000"); 
                }
                txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countGrafic], 4).ToString("0.0000"); 
                txtEspaco.Text = " " + Math.Round(Program.ballSpaceTable[countGrafic], 4).ToString("0.0000"); 
            }
            countBody = countBody + 1;
            if (countBody > Program.ball.NumberOfTerms)
            {
                txtEspaco.Text = "0.0000";
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[Program.ballSpaceTableIndex-1], 4).ToString("0.0000");
                    showValueEnd();
                    stopAllTimes();
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
            if (countGrafic < Program.paperSpaceTableIndex)
            {
                animationWindow.animationPaper(countGrafic);
                if (greatestValueTime == 2)
                {
                    textTempo.Text = " " + Math.Round(Program.paperFinalEndTime[countGrafic], 4).ToString("0.0000"); 
                }
                textBoxPaperVelocity.Text = " " + Math.Round(Program.paperVelocityTable[countGrafic], 4).ToString("0.0000"); 
                textBoxPaperHeight.Text = " " + Math.Round(Program.paperSpaceTable[countGrafic], 4).ToString("0.0000"); 
            }
            countPaper = countPaper + 1;
            if (countPaper > Program.paper.NumberOfTerms)
            {
                textBoxPaperHeight.Text = "0.0000";
                if (greatestValueTime == 2)
                {
                    textTempo.Text = " " + Math.Round(Program.paperFinalEndTime[Program.paperSpaceTableIndex-1], 4).ToString("0.0000");
                    showValueEnd();
                    animationWindow.animationPaper(countGrafic+1);
                    stopAllTimes();
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    Program.openGraficsControl = 1;
                    labelGraficDetails.Visible = true;
                    enabledConfigure(0);
                }
            }
        }

        private void timerAnimationVacuum_Tick(object sender, EventArgs e)
        {
            if (countGrafic < Program.vaccumSpaceTableIndex)
            {
                animationWindow.animationVaccum(countGrafic);
                if (greatestValueTime == 3)
                {
                    textTempo.Text = " " + Math.Round(Program.vaccumFinalEndTime[countGrafic], 4).ToString("0.0000"); 
                }
                textBoxVaccumVelocity.Text = " " + Math.Round(Program.vaccumVelocityTable[countGrafic], 4).ToString("0.0000"); 
                textBoxVaccumHeight.Text = " " + Math.Round(Program.vaccumSpaceTable[countGrafic], 4).ToString("0.0000"); 
            }
            countVaccum = countVaccum + 1;
            if (countVaccum > Program.vaccum.NumberOfTerms)
            {
                textBoxVaccumHeight.Text = "0.0000";
                if (greatestValueTime == 3)
                {
                    textTempo.Text = " " + Math.Round(Program.vaccumFinalEndTime[Program.vaccumSpaceTableIndex-1], 4).ToString("0.0000");
                    showValueEnd();
                    stopAllTimes();
                    BTNIniciar.Text = "Posicionar";
                    buttonStartControl = 3;
                    Program.openGraficsControl = 1;
                    labelGraficDetails.Visible = true;
                    enabledConfigure(0);
                }
            }
        }

        public void showValueEnd()
        {
            if(Program.bodyOn)
            {
                txtEspaco.Text = "0.0000";
                txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[Program.ballSpaceTableIndex - 1], 4).ToString("0.0000");
            }
            if(Program.paperOn)
            {
                textBoxPaperHeight.Text = "0.0000";
                textBoxPaperVelocity.Text = " " + Math.Round(Program.paperVelocityTable[Program.paperSpaceTableIndex - 1], 4).ToString("0.0000");
            }
            if(Program.vaccumOn)
            {
                textBoxVaccumHeight.Text = "0.0000";
                textBoxVaccumVelocity.Text = " " + Math.Round(Program.vaccumVelocityTable[Program.vaccumSpaceTableIndex - 1], 4).ToString("0.0000");
            }
        }
        public void alignVectors()
        {
            countBody = countGrafic;
            countPaper = countGrafic;
            countVaccum = countGrafic;

            if (countGrafic < Program.vaccumSpaceTableIndex)
            {
                animationWindow.animationVaccum(countGrafic);
                if (greatestValueTime == 3)
                {
                    textTempo.Text = " " + Math.Round(Program.vaccumFinalEndTime[countGrafic], 4).ToString("0.0000");
                }
                textBoxVaccumVelocity.Text = " " + Math.Round(Program.vaccumVelocityTable[countGrafic], 4).ToString("0.0000");
                textBoxVaccumHeight.Text = " " + Math.Round(Program.vaccumSpaceTable[countGrafic], 4).ToString("0.0000");
            }
            if (countGrafic < Program.ballSpaceTableIndex)
            {
                animationWindow.animationCorpo(countGrafic);
                if (greatestValueTime == 1 || greatestValueTime == 0)
                {
                    textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countGrafic], 4).ToString("0.0000"); 
                }
                txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countGrafic], 4).ToString("0.0000"); 
                txtEspaco.Text = " " + Math.Round(Program.ballSpaceTable[countGrafic], 4).ToString("0.0000"); 
            }
            if (countGrafic < Program.paperSpaceTableIndex)
            {
                animationWindow.animationPaper(countGrafic);
                if (greatestValueTime == 2)
                {
                    textTempo.Text = " " + Math.Round(Program.paperFinalEndTime[countGrafic], 4).ToString("0.0000");
                }
                textBoxPaperVelocity.Text = " " + Math.Round(Program.paperVelocityTable[countGrafic], 4).ToString("0.0000");
                textBoxPaperHeight.Text = " " + Math.Round(Program.paperSpaceTable[countGrafic], 4).ToString("0.0000");
            }
        }
        public void stopAllTimes()
        {
            timerAnimation.Enabled = false;
            timerAnimationPaper.Enabled = false;
            timerAnimationVacuum.Enabled = false;
        }
        public void receveidGreatestValueTime()
        {
            if (Program.ball.TimeAllExperiment > Program.paper.TimeAllExperiment && Program.ball.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 1;
                Program.numberOfPoints = Program.ball.NumberOfTerms;
            }
            else if (Program.paper.TimeAllExperiment > Program.ball.TimeAllExperiment && Program.paper.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 2;
                Program.numberOfPoints = Program.paper.NumberOfTerms;
            }
            else if (Program.vaccum.TimeAllExperiment > Program.ball.TimeAllExperiment && Program.vaccum.TimeAllExperiment > Program.paper.TimeAllExperiment)
            {
                Program.greatestValueTime = 3;
                Program.numberOfPoints = Program.vaccum.NumberOfTerms;
            }
            else
            {
                Program.greatestValueTime = 0;
                Program.numberOfPoints = Program.ball.NumberOfTerms;
            }

            greatestValueTime = Program.greatestValueTime;
        }

        public void receveidGreatestValueTimeTeste()
        {
            if (Program.ball.TimeAllExperiment > Program.paper.TimeAllExperiment && Program.ball.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 1;
                Program.numberOfPoints = Program.ball.NumberOfTerms;
            }
            else if (Program.paper.TimeAllExperiment > Program.ball.TimeAllExperiment && Program.paper.TimeAllExperiment > Program.vaccum.TimeAllExperiment)
            {
                Program.greatestValueTime = 2;
                Program.numberOfPoints = Program.paper.NumberOfTerms;
            }
            else if (Program.vaccum.TimeAllExperiment > Program.ball.TimeAllExperiment && Program.vaccum.TimeAllExperiment > Program.paper.TimeAllExperiment)
            {
                Program.greatestValueTime = 3;
                Program.numberOfPoints = Program.vaccum.NumberOfTerms;
            }
            else
            {
                Program.greatestValueTime = 0;
                Program.numberOfPoints = Program.ball.NumberOfTerms;
            }

            greatestValueTime = Program.greatestValueTime;
        }

        public void receveidGreatestValueVelocity()
        {
            if (Program.airResistance == 0 || planetCounter == 2 || planetCounter == 3)
            {
                Program.greatestValueVelocity = (Program.ball.FinalVelocity * -1);
            }
            else
            {
                if (Program.ball.FinalVelocity < Program.paper.FinalVelocity && Program.ball.FinalVelocity < (-1 * Program.vaccum.FinalVelocity))
                {
                    Program.greatestValueVelocity = (Program.ball.FinalVelocity);
                }
                else if (Program.paper.FinalVelocity < Program.ball.FinalVelocity && Program.paper.FinalVelocity < (-1 * Program.vaccum.FinalVelocity))
                {
                    Program.greatestValueVelocity = (Program.paper.FinalVelocity);
                }
                else if ((-1 * Program.vaccum.FinalVelocity) < Program.ball.FinalVelocity && (-1 * Program.vaccum.FinalVelocity) < Program.paper.FinalVelocity)
                {
                    Program.greatestValueVelocity = (-1 * Program.vaccum.FinalVelocity);
                }
                else
                {
                    Program.greatestValueVelocity = (Program.ball.FinalVelocity);
                }
            }
        }
        private void timerGrafic_Tick(object sender, EventArgs e)
        {
            if (Program.bodyOn)
            {
                if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
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
            alignVectors();
            if (countGrafic == Program.numberOfPoints)
            {
                timerGrafic.Enabled = false;
            }
        }
        public void updateGrafic(int countGrafic, int op)
        {
            double spaceY;
            double spaceX = 0.0;
            double speedY = 0.0;
            double speedX = 0.0;
            double greatValueTimeForFunction = 0.0;
            int spaceDiv = 0;
            int speedDiv = 0;

            spaceDiv = Convert.ToInt32(Math.Round(Program.height, 0) / 5);
            speedDiv = Convert.ToInt32(Math.Round((-1 * Program.greatestValueVelocity), 0) / 5);

            if (Program.greatestValueTime == 1)
            {
                greatValueTimeForFunction = Program.ball.TimeAllExperiment;
            }
            else
            {
                if (Program.greatestValueTime == 2)
                {
                    greatValueTimeForFunction = Program.paper.TimeAllExperiment;
                }
                else
                {
                    if (Program.greatestValueTime == 3)
                    {
                        greatValueTimeForFunction = Program.vaccum.TimeAllExperiment;
                    }
                    else
                    {
                        if (Program.greatestValueTime == 0)
                        {
                            greatValueTimeForFunction = Program.ball.TimeAllExperiment;
                        }
                    }
                }
            }
            if (op == 0)
            {
                if (Program.bodyOn)
                {
                    if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
                    {
                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                    {
                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                    {

                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
                }
            }
            else
            {
                if (Program.bodyOn)
                {
                    if (Program.ball.NumberOfTerms <= Program.numberOfPoints)
                    {
                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
                }
                if (Program.paperOn)
                {
                    if (Program.paper.NumberOfTerms <= Program.numberOfPoints)
                    {
                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
                }
                if (Program.vaccumOn)
                {
                    if (Program.vaccum.NumberOfTerms <= Program.numberOfPoints)
                    {
                        spaceY = Math.Round(CalculateValueWithTenPercent(Program.height), 2);
                        spaceX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        spaceWindow.spaceGraphic(countGrafic, 0, spaceY, spaceDiv, 0, spaceX, 0, 1);

                        speedY = Math.Round(CalculateValueWithTenPercent(Program.greatestValueVelocity), 2);
                        speedX = Math.Round(CalculateValueWithTenPercent(greatValueTimeForFunction), 2);
                        speedWindow.speedGraphic(countGrafic, speedY, 0, speedDiv, 0, speedX, 0, 1);
                    }
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
        public void timerSound()
        {
            if (sound == 1)
            {
                byte[] audioBytes;
                using (MemoryStream stream = new MemoryStream())
                {
                    Properties.Resources.timerCronometer.CopyTo(stream);
                    audioBytes = stream.ToArray();
                }
                using (MemoryStream memoryStream = new MemoryStream(audioBytes))
                {
                    using (SoundPlayer player = new SoundPlayer(memoryStream))
                    {
                        player.Play();
                    }
                }
            }
        }
        private void timerNumerAnimationIniti_Tick(object sender, EventArgs e)
        {
            closeAllWindows();
            BTNIniciar.Enabled = false;
            enabledConfigure(1);
            buttonPlanet.Focus();
            if (animationNumberCounter == 1)
            {

                labelTextStart.Location = new Point(57, 24);
                labelTextStart.Text = "1";
                timerSound();
                timerNumerAnimationIniti.Interval = 1000;
            }
            if (animationNumberCounter == 2)
            {
                labelTextStart.Text = "2";
                timerSound();
            }
            if (animationNumberCounter == 3)
            {
                labelTextStart.Text = "3";
                timerSound();
            }
            if (animationNumberCounter == 4)
            {
                labelTextStart.Text = "";
                labelTextStart.Location = new Point(20, 24);
                labelTextStart.Text = "CAINDO!";
                BTNIniciar.Enabled = true;
                clear();
                bodysFlag();
                experimentFlag();
                objectVaccumFlag();
                Program.loadExperimentData();
                calculateValues();
                receveidGreatestValueTime();
                receveidGreatestValueVelocity();
                loadTable();
                spaceWindow.buildGrafic(0);
                speedWindow.buildGrafic(0);
                animation();
                BTNIniciar.Focus();
                BTNIniciar.Text = "Parar";
                buttonStartControl = 1;
                labelGraficDetails.Visible = false;
                animationNumberCounter = 0;
                timerNumerAnimationIniti.Enabled = false;
                timerNumerAnimationIniti.Interval = 100;
                Program.openGraficsControl = 0;
                Program.directionFlag = 1;
            }
            animationNumberCounter += 1;
        }
        public void loadTable()
        {
            if(Program.airResistance == 0 || planetCounter == 2 || planetCounter == 3)
            {
                Program.makeTableOutResistence();
            }
            else
            {
                Program.makeTableWihtResistence();
            }
        }
        public void experimentFlag()
        {
            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
            {
                Program.experimentFlag = 0;
            }
            else
            {
                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                {
                    Program.experimentFlag = 2;
                }
                else
                {
                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                    {
                        Program.experimentFlag = 3;
                    }
                    else
                    {
                        if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn == false)
                        {
                            Program.experimentFlag = 1;
                        }
                    }
                }
            }

            Program.airResistanceFlag = Program.airResistance;
        }
        public void objectVaccumFlag()
        {
            if (comboBoxVacuum.Text == "Bola")
            {
                Program.objectVaccum = 0;
            }
            else
            {
                Program.objectVaccum = 1;
            }
        }
        public void bodysFlag()
        {
            if (checkBoxPaper.Checked)
            {
                Program.paperOn = true;
            }
            else
            {
                Program.paperOn = false;
            }
            if (checkBoxVacuum.Checked)
            {
                Program.vaccumOn = true;
            }
            else
            {
                Program.vaccumOn = false;
            }
        }
        private void BTNIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                BTNIniciar.Enabled = false;
                if (buttonStartControl == 0)
                {
                    timerNumerAnimationIniti.Enabled = true;
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
                        alignVectors();
                        if (greatestValueTime == 0 || greatestValueTime == 1)
                        {
                            if (Program.numberOfPoints - countBody > 7)
                            {
                                pictureBoxTimeLeft.Visible = true;
                                pictureBoxTimeRight.Visible = true;
                            }
                        }
                        else
                        {
                            if (greatestValueTime == 2)
                            {
                                if (Program.numberOfPoints - countPaper > 7)
                                {
                                    pictureBoxTimeLeft.Visible = true;
                                    pictureBoxTimeRight.Visible = true;
                                }
                            }
                            else
                            {
                                if (greatestValueTime == 3)
                                {
                                    if (Program.numberOfPoints - countVaccum > 7)
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
                            alignVectors();
                            BTNIniciar.Text = "Parar";
                            buttonStartControl = 1;
                            pictureBoxTimeLeft.Visible = false;
                            pictureBoxTimeRight.Visible = false;
                            if (Program.paperOn && Program.vaccumOn)
                            {
                                timerAnimationVacuum.Enabled = true;
                                timerAnimation.Enabled = true;
                                timerAnimationPaper.Enabled = true;
                                timerGrafic.Enabled = true;
                            }
                            else
                            {
                                if (Program.paperOn == false && Program.vaccumOn == true)
                                {
                                    timerAnimationVacuum.Enabled = true;
                                    timerAnimation.Enabled = true;
                                    timerGrafic.Enabled = true;
                                }
                                else
                                {
                                    if (Program.vaccumOn == false && Program.paperOn == true)
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
                                receveidGreatestValueTime();
                                receveidGreatestValueVelocity();
                                clearTextBox();
                                BTNIniciar.Text = "Iniciar";
                                buttonStartControl = 0;
                            }
                        }
                    }

                }
                BTNIniciar.Focus();
                timerButton.Enabled = true;
            }
            catch
            {
                BTNIniciar.Enabled = true;
                Console.WriteLine("Erro! - Botão falhou");
            }
        }
        private void buttonData_Click(object sender, EventArgs e)
        {
            if (Program.experimentDataControl == 0)
            {
                windowExperiment = new ExperimentData();
                windowExperiment.Show();
            }

            if (Application.OpenForms["ExperimentData"] != null)
            {
                if (Application.OpenForms["ExperimentData"].WindowState == FormWindowState.Minimized)
                {
                    Application.OpenForms["ExperimentData"].WindowState = FormWindowState.Normal;
                }
                Application.OpenForms["ExperimentData"].Focus();
            }
        }
        private void buttonResistencia_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttonLogo_Click(object sender, EventArgs e)
        {
            programView x = new programView();
            x.Show();
        }
        public void initialConfigure()
        {
            labelTextStart.Location = new Point(17, 24);
            planetCounter = Program.planeTrackBar;
            planetData();
            comboBoxVacuum.Text = "Papel";
            comboPaper.Text = "Aberto";
            textBoxPaperHeight.Text = " --";
            textBoxPaperVelocity.Text = " --";
            textBoxVaccumHeight.Text = " --";
            textBoxVaccumVelocity.Text = " --";
            checkBox3D.Checked = true;
            textBoxAirDensity.Text = "" + Program.airDensity;
            checkBoxResistanceRV1.Checked = true;
            KeyPreview = true;
            KeyDown += Simulator_KeyDown;
        }

        private void checkBoxVacuum_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxVacuum.Checked)
            {
                comboBoxVacuum.Enabled = true;
                animationWindow.picutureVaccum(0);
                textBoxVaccumHeight.Text = "";
                textBoxVaccumVelocity.Text = "";
            }
            else
            {
                comboBoxVacuum.Enabled = false;
                animationWindow.picutureVaccum(1);
                textBoxVaccumHeight.Text = " --";
                textBoxVaccumVelocity.Text = " --";
            }
        }

        private void checkBoxLeaf_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxPaper.Checked)
            {
                if (cmbPlaneta.Text == "Vênus")
                {
                    comboPaper.Text = "Amassado";
                    comboPaper.Enabled = false;
                    animationWindow.picuturePaper(0);
                }
                else
                {
                    comboPaper.Enabled = true;
                    animationWindow.picuturePaper(0);
                }
                textBoxPaperHeight.Text = "";
                textBoxPaperVelocity.Text = "";
            }
            else
            {
                comboPaper.Enabled = false;
                animationWindow.picuturePaper(1);
                textBoxPaperHeight.Text = " --";
                textBoxPaperVelocity.Text = " --";
            }
        }

        private void comboBoxVacuum_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxVacuum.Text == "Bola")
            {
                animationWindow.vacuumSelectedValueChange(0);
                pictureBoxVaccumObject.Image = animationWindow.vaccumImage();
                flagVaccumObject = 1;
                Program.vaccum.DragCoefficient = Program.ball.DragCoefficient;
                Program.vaccum.CrossSectionalArea = Program.ball.CrossSectionalArea;
            }
            else
            {
                animationWindow.vacuumSelectedValueChange(1);
                pictureBoxVaccumObject.Image = Properties.Resources.paper2;
                flagVaccumObject = 0;
                Program.vaccum.DragCoefficient = 1.17;
                Program.vaccum.CrossSectionalArea = 0.04;
            }
        }

        private void comboShet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboPaper.Text == "Aberto")
            {
                animationWindow.pictureBoxCorpoPaperSelected(0);
                pictureBoxPaper.Image = Properties.Resources.paper2;
                Program.crumpledPaper = 0;
                Program.paper.DragCoefficient = 1.17;
                Program.paper.CrossSectionalArea = 0.04;
            }
            else
            {
                animationWindow.pictureBoxCorpoPaperSelected(1);
                pictureBoxPaper.Image = Properties.Resources.paper3;
                Program.crumpledPaper = 1;
                Program.paper.DragCoefficient = 0.8;
                Program.paper.CrossSectionalArea = 0.00134;
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
            if (flagVaccumObject == 1)
            {
                Program.vaccumImageExperiment = pictureBoxVaccumObject.Image;
            }
        }

        public void venusStates()
        {
            if (cmbPlaneta.Text == "Vênus")
            {
                animationWindow.pictureBoxCorpoPaperSelected(1);
                pictureBoxPaper.Image = Properties.Resources.paper3;
                Program.crumpledPaper = 1;
                Program.paper.DragCoefficient = 0.8;
                Program.paper.CrossSectionalArea = 0.00134;
                if (flagVenus == 0)
                {
                    paperStates = comboPaper.Text;
                    flagVenus = 1;
                }
                comboPaper.Text = "Amassado";
                comboPaper.Enabled = false;
                labelVenus.Visible = true;
            }
            else
            {
                if (paperStates == "Aberto")
                {
                    animationWindow.pictureBoxCorpoPaperSelected(0);
                    pictureBoxPaper.Image = Properties.Resources.paper2;
                    Program.crumpledPaper = 0;
                    Program.paper.DragCoefficient = 1.17;
                    Program.paper.CrossSectionalArea = 0.04;
                    comboPaper.Text = "Aberto";
                }
                if (checkBoxPaper.Checked == true)
                {
                    comboPaper.Enabled = true;
                }
                else
                {
                    comboPaper.Enabled = false;
                }
                labelVenus.Visible = false;
                flagVenus = 0;
            }
        }
        private void planetData()
        {
            if (planetCounter == 1)
            {
                txtgravit.Text = "9,81";
                cmbPlaneta.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 1.23;
            }
            if (planetCounter == 2)
            {
                txtgravit.Text = "1,62";
                cmbPlaneta.Text = "Lua";
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                buttonPlanet.Text = "Lua";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0;
            }
            if (planetCounter == 3)
            {
                txtgravit.Text = "3,70";
                cmbPlaneta.Text = "Mercúrio";
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                buttonPlanet.Text = "Mercúrio";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0;
                venusStates();
            }
            if (planetCounter == 4)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Vênus";
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                buttonPlanet.Text = "Vênus";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 64.8;
                venusStates();
            }
            if (planetCounter == 5)
            {
                txtgravit.Text = "3,71";
                cmbPlaneta.Text = "Marte";
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                buttonPlanet.Text = "Marte";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.02;
                venusStates();
            }
            if (planetCounter == 6)
            {
                txtgravit.Text = "24,79";
                cmbPlaneta.Text = "Júpter";
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                buttonPlanet.Text = "Júpter";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.16;
                if (Program.numberOfPlanets == 4)
                {
                    txtgravit.Text = "9,81";
                    cmbPlaneta.Text = "Terra";
                    pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                    buttonPlanet.Text = "Terra";
                    animationWindow.backgroundPicture(planetCounter);
                    Program.airDensity = 1.23;
                }
            }
            if (planetCounter == 7)
            {
                txtgravit.Text = "10,40";
                cmbPlaneta.Text = "Saturno";
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                buttonPlanet.Text = "Saturno";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.19;
            }
            if (planetCounter == 8)
            {
                txtgravit.Text = "8,87";
                cmbPlaneta.Text = "Urano";
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                buttonPlanet.Text = "Urano";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.42;
            }
            if (planetCounter == 9)
            {
                txtgravit.Text = "11,15";
                cmbPlaneta.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                buttonPlanet.Text = "Netuno";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 0.45;
            }
            if (planetCounter == 10)
            {
                txtgravit.Text = "9,81";
                cmbPlaneta.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                buttonPlanet.Text = "Terra";
                animationWindow.backgroundPicture(planetCounter);
                Program.airDensity = 1.23;
            }
            Program.planetImage = pictureBoxPlanets.Image;
            if (checkBoxResistanceRV1.Checked)
            {
                textBoxAirDensity.Text = "" + Program.airDensity;
            }
            else
            {
                textBoxAirDensity.Text = " --";
            }
        }
        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            planetCounter += 1;
            Program.planetCounter = planetCounter;
            Program.planetNameReceveid(planetCounter);
            planetData();
            if (planetCounter == Program.numberOfPlanets + 2)
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
                planetCounter = Program.numberOfPlanets + 1;
            }
            planetData();
        }
        private void buttonPlanet_Click(object sender, EventArgs e)
        {
            if (Program.dataControl == 0)
            {
                Data windowData = new Data();
                windowData.Show();
            }
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

        public string isNegative(double value)
        {
            string result = "";

            if (value <= 0)
            {
                result = "0.0000";
            }
            else
            {
                result = value.ToString("0.0000");
            }
            return result;
        }


        public void updatePosition(int countGrafic, int op, int countBody, int countPaper, int countVaccum)
        {
            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                if (countBody < Program.ballSpaceTableIndex)
                {
                    animationWindow.animationCorpo(countBody);
                    txtEspaco.Text = " " + isNegative(Math.Round(Program.ballSpaceTable[countBody], 4));
                    txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countBody], 4).ToString("0.0000");
                    if (greatestValueTime == 1 || greatestValueTime == 0)
                    {
                        textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countBody], 4).ToString("0.0000");
                    }
                }
                else
                {
                    txtEspaco.Text = "0.0000";
                }
                if (countPaper < Program.paperSpaceTableIndex)
                {
                    animationWindow.animationPaper(countPaper);
                    textBoxPaperHeight.Text = " " + isNegative(Math.Round(Program.paperSpaceTable[countPaper], 4));
                    textBoxPaperVelocity.Text = " " + Math.Round(Program.paperVelocityTable[countPaper], 4).ToString("0.0000");
                    if (greatestValueTime == 2)
                    {
                        textTempo.Text = " " + Math.Round(Program.paperFinalEndTime[countPaper], 4).ToString("0.0000");
                    }
                }
                else
                {
                    textBoxPaperHeight.Text = "0.00";
                }
                if (countVaccum < Program.vaccumSpaceTableIndex)
                {
                    animationWindow.animationVaccum(countVaccum);
                    textBoxVaccumHeight.Text = " " + isNegative(Math.Round(Program.vaccumSpaceTable[countVaccum], 4));
                    textBoxVaccumVelocity.Text = " " + Math.Round(Program.vaccumVelocityTable[countVaccum], 4).ToString("0.0000");
                    if (greatestValueTime == 3)
                    {
                        textTempo.Text = " " + Math.Round(Program.vaccumFinalEndTime[countVaccum], 4).ToString("0.0000");
                    }
                }
                else
                {
                    textBoxVaccumHeight.Text = "0.0000";
                }
                updateGrafic(countGrafic, op);
            }
            else
            {
                if (Program.paperOn && Program.bodyOn && Program.vaccumOn == false)
                {
                    if (countBody < Program.ballSpaceTableIndex)
                    {
                        animationWindow.animationCorpo(countBody);
                        txtEspaco.Text = " " + isNegative(Math.Round(Program.ballSpaceTable[countBody], 4));
                        txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countBody], 4).ToString("0.0000");
                        if (greatestValueTime == 1 || greatestValueTime == 0)
                        {
                            textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countBody], 4).ToString("0.0000");
                        }
                    }
                    else
                    {
                        txtEspaco.Text = "0.0000";
                    }
                    if (countPaper < Program.paperSpaceTableIndex)
                    {
                        animationWindow.animationPaper(countPaper);
                        textBoxPaperHeight.Text = " " + isNegative(Math.Round(Program.paperSpaceTable[countPaper], 4));
                        textBoxPaperVelocity.Text = " " + Math.Round(Program.paperVelocityTable[countPaper], 4).ToString("0.0000");
                        if (greatestValueTime == 2)
                        {
                            textTempo.Text = " " + Math.Round(Program.paperFinalEndTime[countPaper], 4).ToString("0.0000");
                        }
                    }
                    else
                    {
                        textBoxPaperHeight.Text = "0.0000";
                    }
                    updateGrafic(countGrafic, op);
                }
                else
                {
                    if (Program.paperOn == false && Program.bodyOn && Program.vaccumOn)
                    {
                        if (countBody < Program.ballSpaceTableIndex)
                        {
                            animationWindow.animationCorpo(countBody);
                            txtEspaco.Text = " " + isNegative(Math.Round(Program.ballSpaceTable[countBody], 4));
                            txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countBody], 4).ToString("0.0000");
                            if (greatestValueTime == 1 || greatestValueTime == 0)
                            {
                                textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countBody], 4).ToString("0.0000");
                            }
                        }
                        else
                        {
                            txtEspaco.Text = "0.0000";
                        }
                        if (countVaccum < Program.vaccumSpaceTableIndex)
                        {
                            animationWindow.animationVaccum(countVaccum);
                            textBoxVaccumHeight.Text = " " + isNegative(Math.Round(Program.vaccumSpaceTable[countVaccum], 4));
                            textBoxVaccumVelocity.Text = " " + Math.Round(Program.vaccumVelocityTable[countVaccum], 4).ToString("0.0000");
                            if (greatestValueTime == 3)
                            {
                                textTempo.Text = " " + Math.Round(Program.vaccumFinalEndTime[countVaccum], 4).ToString("0.0000");
                            }
                        }
                        else
                        {
                            textBoxVaccumHeight.Text = "0.0000";
                        }
                        updateGrafic(countGrafic, op);
                    }
                    else
                    {
                        if (countBody < Program.ballSpaceTableIndex)
                        {
                            animationWindow.animationCorpo(countBody);
                            txtEspaco.Text = " " + isNegative(Math.Round(Program.ballSpaceTable[countBody], 4));
                            txtVelocidade.Text = " " + Math.Round(Program.ballVelocityTable[countBody], 4).ToString("0.0000");
                            if (greatestValueTime == 1 || greatestValueTime == 0)
                            {
                                textTempo.Text = " " + Math.Round(Program.ballFinalEndTime[countBody], 4).ToString("0.0000");
                            }
                        }
                        else
                        {
                            txtEspaco.Text = "0.0000";
                        }
                        updateGrafic(countGrafic, op);
                    }
                }
            }
        }
        private int getGreatValueCount()
        {
            if (Program.greatestValueTime == 1)
            {
                return countBody;
            }
            else
            {
                if (Program.greatestValueTime == 2)
                {
                    return countPaper;
                }
                else
                {
                    if (Program.greatestValueTime == 3)
                    {
                        return countVaccum;
                    }
                    else
                    {
                        return countBody;
                    }
                }
            }
        }
        private void leftPosition()
        {
            int Auxiliary = 0;
            pictureBoxTimeRight.Visible = true;
            Auxiliary = getGreatValueCount();

            if (Program.paperOn && Program.bodyOn && Program.vaccumOn)
            {
                countBody--;
                countPaper--;
                countVaccum--;
                countGrafic--;
                updatePosition(countGrafic, 1, countBody, countPaper, countVaccum);
                if (Auxiliary == 2)
                {
                    pictureBoxTimeLeft.Visible = false;
                    timerLeft.Enabled = false;
                    updateGrafic(2, 1);
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
                    if (Auxiliary == 2)
                    {
                        pictureBoxTimeLeft.Visible = false;
                        timerLeft.Enabled = false;
                        updateGrafic(2, 1);
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
                        if (Auxiliary == 2)
                        {
                            pictureBoxTimeLeft.Visible = false;
                            timerLeft.Enabled = false;
                            updateGrafic(2, 1);
                        }
                    }
                    else
                    {
                        countBody--;
                        countGrafic--;
                        updatePosition(countGrafic, 1, countBody, 0, 0);
                        if (Auxiliary == 2)
                        {
                            pictureBoxTimeLeft.Visible = false;
                            timerLeft.Enabled = false;
                            updateGrafic(2, 1);
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
                    if (Program.numberOfPoints - 1 == countBody || Program.numberOfPoints - 1 == countPaper || Program.numberOfPoints - 1 == countVaccum)
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
                        if (Program.numberOfPoints - 1 == countBody || Program.numberOfPoints - 1 == countPaper)
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
                            if (Program.numberOfPoints - 1 == countBody || Program.numberOfPoints - 1 == countVaccum)
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
                            if (Program.numberOfPoints - 1 == countBody)
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
            Program.colorTrackBar = i;
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

        private void timerOpacity_Tick(object sender, EventArgs e)
        {
            Opacity = 1;
            colorAll();
            timerOpacity.Enabled = false;
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
            labelTextColor.ForeColor = Program.colorSimulator;
            labelGraficDetails.ForeColor = Program.colorSimulator;
            comboPaper.ForeColor = Program.colorSimulator;
            comboBoxVacuum.ForeColor = Program.colorSimulator;
            textTempo.ForeColor = Program.colorSimulator;
            labelAirAirDensity.ForeColor = Program.colorSimulator;
            textBoxAirDensity.ForeColor = Program.colorSimulator;
            labelMaskPapel.ForeColor = Program.colorSimulator;
            labelMaskVaccum.ForeColor = Program.colorSimulator;
            labelMaskAirResistence.ForeColor = Program.colorSimulator;
            groupBoxDataExperiment.ForeColor = Program.colorSimulator;
            spaceWindow.colorAll();
            speedWindow.colorAll();
            animationWindow.colorAll();
        }
        private void timerColors_Tick(object sender, EventArgs e)
        {
            colorAll();
        }
        public void resetWindows()
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
        }
        private void RestartChildWindow()
        {
            if (speedWindow != null && !speedWindow.IsDisposed)
            {
                speedWindow.Close();
                speedWindow = new GraficSpeedWindow();
            }

            if (spaceWindow != null && !spaceWindow.IsDisposed)
            {
                spaceWindow.Close();
                spaceWindow = new GraficSpaceWindow();
            }
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
        private void Altura_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(LbAltura, "A altura à qual os objetos serão soltos.");
        }
        private void label6_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(label6, "Gravidade do astro selecionado.");
        }
        private void checkBoxEixo_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBoxEixo, "Exibe eixos no experimento.");
        }
        private void buttonData_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonData, "Exibe os dados configurados do experimento.");
        }
        private void labelAirAirDensity_MouseHover_1(object sender, EventArgs e)
        {
            toolTip.SetToolTip(labelAirAirDensity, "Densidade superficial da atmosfera.");
        }
        private void checkBox3D_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(checkBox3D, "Deixa os gráficos em 3d.");
        }
        private void labelMaskPapel_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(labelMaskPapel, "Corpo com alta resistência ao ar.");
        }
        private void labelMaskVaccum_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(labelMaskVaccum, "");
        }
        private void labelMaskAirResistence_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(labelMaskAirResistence, "Adiciona a resistência do ar ao experimento.");
        }
        private void GroupBoxGraficos_MouseEnter(object sender, EventArgs e)
        {
            if (isClickable)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void GroupBoxGraficos_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void groupBoxGraficos_Enter(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
        }
        private void timerButton_Tick(object sender, EventArgs e)
        {
            BTNIniciar.Enabled = true;
            BTNIniciar.Focus();
            timerButton.Enabled = false;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {

        }
        private void checkBoxGrafic_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void timerVenus_Tick(object sender, EventArgs e)
        {

        }
        private void checkBoxResistance_CheckedChanged_1(object sender, EventArgs e)
        {
        }
        private void chartSpace_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void chartSpeed_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxFonts_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void Altura_Click(object sender, EventArgs e)
        {

        }
        private void checkBoxVacuum_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void labelTextStart_Click(object sender, EventArgs e)
        {

        }

        private void panelSpace_Paint(object sender, PaintEventArgs e)
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

        private void labelMaskVaccum_Click(object sender, EventArgs e)
        {

        }
        private void groupBoxGraficos_MouseHover(object sender, EventArgs e)
        {

        }
        private void groupBoxGraficos_Leave(object sender, EventArgs e)
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

        private void pictureBoxTimeLeft_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxTimeRight_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxTimeRight_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void timerEixos_Tick(object sender, EventArgs e)
        {

        }
        private void Simulator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
        private void checkBoxGrafic_CheckStateChanged(object sender, EventArgs e)
        {

        }
        private void checkBoxVacuum_MouseHover(object sender, EventArgs e)
        {

        }

        private void checkBoxLeaf_MouseHover(object sender, EventArgs e)
        {

        }
        private void checkBoxResistanceRV1_MouseHover_1(object sender, EventArgs e)
        {

        }
        private void checkBoxGrafic_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
