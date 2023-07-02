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
            timerFocus.Enabled = true;
            timerLoadImage.Enabled = true;
        }

        public void loadImageValue()
        {
            pictureBoxCorpoView.Image = Program.ballImage;
            pictureBoxPaper.Image = Program.paperImage;
            pictureBoxVaccumObject.Image =Program.vaccumImage;
            pictureBoxPlanet.Image = Program.planetImage;
        }

        public void loadData()
        {
            textBoxGravity.Text = "" + Program.gravity;
            textBoxHeight.Text = "" + Program.height;
            textBoxPlanetName.Text = "" + Program.planetName;

            textBoxCorpoTime.Text = "" + Program.ball.TimeAllExperiment;
            textBoxCorpoVelocityFynal.Text = "" + Program.ball.FinalVelocity;
            txtEspacoCorpo.Text = "" + Program.height;
            txtVelocidadeCorpoInitial.Text = "" + Program.ball.InitialVelocity;


            textBoxPaperFynalVelocity.Text = "" + Program.paper.FinalVelocity; 
            textBoxPaperInitalVelocity.Text = "" + Program.paper.InitialVelocity; 
            textBoxPaperHeight.Text = "" + Program.height;
            textBoxPaperTime.Text = "" + Program.paper.TimeAllExperiment;


            textBoxVaccumFynalVelocity.Text = "" + Program.vaccum.FinalVelocity; 
            textBoxVaccumHeight.Text = "" + Program.height;
            textBoxVaccumInitialVelocity.Text = "" + Program.vaccum.InitialVelocity; 
            textBoxVaccumTime.Text = "" + Program.vaccum.TimeAllExperiment;
        }
        public void sizeWindo()
        {


            if (Program.bodyOn && Program.paperOn && Program.vaccumOn)
            {
                this.Size = new Size(1079, 260);
                groupBoxPaper.Visible = true;
                groupBoxPaper.Location = new Point(511, 0);
                groupBoxVaccum.Location = new Point(788, 0);
            }
            else
            {
                if (Program.bodyOn && Program.paperOn && Program.vaccumOn == false)
                {
                    this.Size = new Size(801, 260);
                    groupBoxPaper.Visible = true;
                    groupBoxPaper.Location = new Point(511, 0);
                    groupBoxVaccum.Location = new Point(788, 0);
                }
                else
                {
                    if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn)
                    {
                        this.Size = new Size(801, 260);
                        groupBoxPaper.Visible = false;
                        groupBoxVaccum.Location = new Point(511, 0);
                    }
                    else
                    {
                        if (Program.bodyOn && Program.paperOn == false && Program.vaccumOn == false)
                        {
                            this.Size = new Size(524, 260);
                            groupBoxVaccum.Location = new Point(788, 0);
                        }
                    }
                }
            }
        }

        private void experimentData_Load(object sender, EventArgs e)
        {

        }

        public void colorAll()
        {

        }
        private void experimentData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.experimentDataControl = 0;
        }

        private void buttonFocus_Click(object sender, EventArgs e)
        {

        }

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            button1.Focus();
            timerFocus.Enabled = false;
        }

        private void timerLoadImage_Tick(object sender, EventArgs e)
        {
            loadImageValue();
            loadData();
            sizeWindo();
        }
    }
}
