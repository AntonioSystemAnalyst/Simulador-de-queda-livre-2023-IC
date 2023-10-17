using System;
using System.Drawing;
using System.Windows.Forms;

namespace freeFall
{
    public partial class ExperimentData : Form
    {

        public ExperimentData()
        {
            InitializeComponent();
            Program.experimentDataControl = 1;
            colorAll();
            sizeWindo();
            loadData();
            loadImageValueInit();
            timerFocus.Enabled = true;
            timerLaodImage.Enabled = true;
        }

        public void loadImageValueInit()
        {
            pictureBoxCorpoView.Image = Program.ballImage;
            pictureBoxPaper.Image = Program.paperImage;
            pictureBoxVaccumObject.Image =Program.vaccumImage;
            pictureBoxPlanet.Image = Program.planetImage;
        }

        public void loadImageValue()
        {

            if (Program.objectVaccum == 0)
            {
                pictureBoxVaccumObject.Image = Program.vaccumImageExperiment;
            }
            pictureBoxCorpoView.Image = Program.ballImage;
        }

        public void loadData()
        {
            textBoxGravity.Text = "" + Program.gravity;
            textBoxHeight.Text = "" + Program.height;
            textBoxPlanetName.Text = "" + Program.planetName;

            if(Program.airResistance == 0)
            {
                textBoxAirDensity.Text = "--";
            }
            else
            {
                textBoxAirDensity.Text = "" + Program.airDensity;
            }
            

            textBoxCorpoTime.Text = "" + Math.Round(Program.ball.CountTimeExperiment[Program.ball.NumberOfTerms - 1], 2);
            textBoxCorpoVelocityFynal.Text = "" + Math.Round(Program.ball.Velocity[Program.ball.NumberOfTerms - 1], 2);
            txtEspacoCorpo.Text = "" + Program.height;
            txtVelocidadeCorpoInitial.Text = "" + Program.ball.InitialVelocity;
            textBoxCEBall.Text = "" + Program.ball.DragCoefficient;

            if(Program.paperOn)
            {
                textBoxPaperFynalVelocity.Text = "" + Math.Round(Program.paper.Velocity[Program.paper.NumberOfTerms - 1], 2);
                textBoxPaperInitalVelocity.Text = "" + Program.paper.InitialVelocity;
                textBoxPaperHeight.Text = "" + Program.height;
                textBoxPaperTime.Text = "" + Math.Round(Program.paper.CountTimeExperiment[Program.paper.NumberOfTerms - 1], 2);
                textBoxCEPaper.Text = "" + Program.paper.DragCoefficient;
            }

            if(Program.vaccumOn)
            {
                textBoxVaccumFynalVelocity.Text = "" + Math.Round(Program.vaccum.Velocity[Program.vaccum.NumberOfTerms - 1], 2);
                textBoxVaccumHeight.Text = "" + Program.height;
                textBoxVaccumInitialVelocity.Text = "" + Program.vaccum.InitialVelocity;
                textBoxVaccumTime.Text = "" + Math.Round(Program.vaccum.CountTimeExperiment[Program.vaccum.NumberOfTerms - 1], 2);
                textBoxCEVacuo.Text = "" + Program.vaccum.DragCoefficient;
            }

        }

        public void sizeWindo()
        {
            if (Program.experimentFlag == 0)
            {
                this.Size = new Size(1079, 260);
                groupBoxPaper.Visible = true;
                groupBoxPaper.Location = new Point(511, 0);
                groupBoxVaccum.Location = new Point(788, 0);
            }
            else
            {
                if (Program.experimentFlag == 2)
                {
                    this.Size = new Size(801, 260);
                    groupBoxPaper.Visible = true;
                    groupBoxPaper.Location = new Point(511, 0);
                    groupBoxVaccum.Location = new Point(788, 0);
                }
                else
                {
                    if (Program.experimentFlag == 3)
                    {
                        this.Size = new Size(801, 260);
                        groupBoxPaper.Visible = false;
                        groupBoxVaccum.Location = new Point(511, 0);
                    }
                    else
                    {
                        if (Program.experimentFlag == 1)
                        {
                            this.Size = new Size(524, 260);
                            groupBoxVaccum.Location = new Point(788, 0);
                        }
                    }
                }
            }
        }
        private void timerFocus_Tick(object sender, EventArgs e)
        {
            button1.Focus();
            timerFocus.Enabled = false;
        }

        private void timerLaodImage_Tick(object sender, EventArgs e)
        {
            loadImageValue();
            colorAll();
        }
        private void experimentData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.experimentDataControl = 0;
        }
        public void colorAll()
        {
            groupBoxGeneralData.ForeColor = Program.colorSimulator;
            groupBoxResultados.ForeColor = Program.colorSimulator;
            groupBoxPaper.ForeColor = Program.colorSimulator;
            groupBoxVaccum.ForeColor = Program.colorSimulator;
            textBoxPlanetName.ForeColor = Program.colorSimulator;
            textBoxHeight.ForeColor = Program.colorSimulator;
            textBoxGravity.ForeColor = Program.colorSimulator;
            txtEspacoCorpo.ForeColor = Program.colorSimulator;
            textBoxCorpoTime.ForeColor = Program.colorSimulator;
            txtVelocidadeCorpoInitial.ForeColor = Program.colorSimulator;
            textBoxCorpoVelocityFynal.ForeColor = Program.colorSimulator;
            textBoxPaperHeight.ForeColor = Program.colorSimulator;
            textBoxPaperTime.ForeColor = Program.colorSimulator;
            textBoxPaperInitalVelocity.ForeColor = Program.colorSimulator;
            textBoxPaperFynalVelocity.ForeColor = Program.colorSimulator;
            textBoxVaccumHeight.ForeColor = Program.colorSimulator;
            textBoxVaccumTime.ForeColor = Program.colorSimulator;
            textBoxVaccumInitialVelocity.ForeColor = Program.colorSimulator;
            textBoxVaccumFynalVelocity.ForeColor = Program.colorSimulator;
            labelAirDensity.ForeColor = Program.colorSimulator;
            labelAirDensityUnity.ForeColor = Program.colorSimulator;
            labelCEBall.ForeColor = Program.colorSimulator;
            labelCEPaper.ForeColor = Program.colorSimulator;
            labelCEVacuo.ForeColor = Program.colorSimulator;
            textBoxCEBall.ForeColor = Program.colorSimulator;
            textBoxCEPaper.ForeColor = Program.colorSimulator;
            textBoxCEVacuo.ForeColor= Program.colorSimulator;
        }

        private void buttonFocus_Click(object sender, EventArgs e)
        {

        }

        private void experimentData_Load(object sender, EventArgs e)
        {

        }
    }
}
