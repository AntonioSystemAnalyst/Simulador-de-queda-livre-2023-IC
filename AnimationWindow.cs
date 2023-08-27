using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace freeFall
{
    public partial class AnimationWindow : Form
    {
        public AnimationWindow()
        {
            InitializeComponent();
            vacuumSelectedValueChange(1);
            picutureEixos(1);
            colorAll();
            addImageValue();
        }

        public void addImageValue()
        {
            Program.ballImage = pictureBoxCorpo.Image;
            Program.paperImage = pictureBoxPaper.Image;
            Program.vaccumImage = pictureBoxVacuum.Image;
        }

        public void colorAll()
        {
            groupBoxExperimento.ForeColor = Program.colorSimulator;
            labelY.ForeColor = Program.colorSimulator;
            labelX.ForeColor = Program.colorSimulator;
            labelZero.ForeColor = Program.colorSimulator;
            pictureBoxAxesY.BackColor = Program.colorSimulator;
            pictureBoxAxesX.BackColor = Program.colorSimulator;
            labelArrow2.ForeColor = Program.colorSimulator;
            labelArrow1.ForeColor = Program.colorSimulator;
        }

        public Image vaccumImage()
        {
            addImageValue();
            return pictureBoxCorpo.Image;
        }

        public void animationCorpo(int countBody)
        {
            pictureBoxCorpo.Location = new Point(145, 30 + Program.ball.Pixels[countBody]);
        }

        public void animationPaper(int countPaper)
        {
            pictureBoxPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
        }

        public void animationVaccum(int countVaccum)
        {
            pictureBoxVacuum.Location = new Point(16, 13 + Program.vaccum.Pixels[countVaccum]);
        }

        public void backgroundPicture(int planetCounter)
        {
            if (planetCounter == 1)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
            }
            if (planetCounter == 2)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMoon;
            }
            if (planetCounter == 3)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMercury;
            }
            if (planetCounter == 4)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonVenus;
            }
            if (planetCounter == 5)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonMars;
            }
            if (planetCounter == 6)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonJupiter;
            }
            if (planetCounter == 7)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonSaturn;
            }
            if (planetCounter == 8)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonUranus;
            }
            if (planetCounter == 9)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonNeptune;
            }
            if (planetCounter == 10)
            {
                groupBoxExperimento.BackgroundImage = Properties.Resources.horizonEarth;
            }
        }
        public void picuture(int corpoCounter, int flagVaccumObject)
        {
            if (corpoCounter == 1)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBall4;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBall4;
                }
            }
            if (corpoCounter == 2)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBasketball;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBasketball;
                }
            }
            if (corpoCounter == 3)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoBowling;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoBowling;
                }
            }
            if (corpoCounter == 4)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoGolf;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoGolf;
                }
            }
            if (corpoCounter == 5)
            {
                pictureBoxCorpo.Image = Properties.Resources.corpoSoccer;
                if (flagVaccumObject == 1)
                {
                    pictureBoxVacuum.Image = Properties.Resources.corpoSoccer;
                }
            }
            addImageValue();
        }

        public void picuturePaper(int op)
        {
            if (op == 0)
            {
                pictureBoxPaper.Visible = true;
            }
            else
            {
                pictureBoxPaper.Visible = false;
            }
        }


        public void pictureBoxCorpoPaperSelected(int op)
        {
            if (op == 0)
            {
                pictureBoxPaper.Image = Properties.Resources.paper2;
            }
            else
            {
                pictureBoxPaper.Image = Properties.Resources.paper3;
            }
            addImageValue();
        }
        public void picutureVaccum(int op)
        {
            if (op == 0)
            {
                groupBoxVacuum.Visible = true;
                pictureBoxVacuum.Visible = true;
                pictureBoxGauge.Visible = true;
            }
            else
            {
                groupBoxVacuum.Visible = false;
                pictureBoxVacuum.Visible = false;
                pictureBoxGauge.Visible = false;
            }
        }

        public void vacuumSelectedValueChange(int op)
        {
            if (op == 0)
            {
                pictureBoxVacuum.Image = pictureBoxCorpo.Image;
                Program.vaccumImageExperiment = pictureBoxCorpo.Image;
            }
            else
            {
                pictureBoxVacuum.Image = Properties.Resources.paper2;
            }
            addImageValue();
        }

        public void picutureResistence(int op)
        {
            if (op == 0)
            {
                pictureBoxResistence.Visible = true;
            }
            else
            {
                pictureBoxResistence.Visible = false;
            }
        }

        public void picutureEixos(int op)
        {
            if (op == 0)
            {
                labelZero.Visible = true;
                labelY.Visible = true;
                labelX.Visible = true;
                pictureBoxBackY.Visible = true;
                pictureBoxBackX.Visible = true;
                pictureBoxAxesY.Visible = true;
                pictureBoxAxesX.Visible = true;
                pictureBoxBase.Visible  = false;
                labelArrow2.Visible = true;
                labelArrow1.Visible = true;
            }
            else
            {
                labelZero.Visible = false;
                labelY.Visible = false;
                labelX.Visible = false;
                pictureBoxBackY.Visible = false;
                pictureBoxBackX.Visible = false;
                pictureBoxAxesY.Visible = false;
                pictureBoxAxesX.Visible = false;
                pictureBoxBase.Visible = true;
                labelArrow2.Visible = false;
                labelArrow1.Visible = false;
            }
        }
        public void clearPostion()
        {
            pictureBoxCorpo.Location = new Point(145, 30);
            pictureBoxPaper.Location = new Point(222, 30);
            pictureBoxVacuum.Location = new Point(16, 13);
        }
    }
}
