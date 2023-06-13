﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace freeFall
{
    public partial class AnimationWindow : Form
    {
        public AnimationWindow()
        {
            InitializeComponent();
        }

        public void colorAll()
        {

        }

        public void animationCorpo (int countBody)
        {
            pictureBoxCorpo.Location = new Point(145, 30 + Program.corpo.Pixels[countBody]);
        }

        public void animationPaper(int countPaper)
        {
            pictureBoxCorpoPaper.Location = new Point(222, 30 + Program.paper.Pixels[countPaper]);
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
        public void picuture (int corpoCounter, int flagVaccumObject)
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
        }

        public void picuturePaper(int op)
        {
            if(op == 0)
            {
                pictureBoxCorpoPaper.Visible = true;
            }
            else
            {
                pictureBoxCorpoPaper.Visible = false;
            }
        }


        public void pictureBoxCorpoPaperSelected(int op)
        {
            if (op == 0)
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper2;
            }
            else
            {
                pictureBoxCorpoPaper.Image = Properties.Resources.paper3;
            }
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
            if(op == 0)
            {
                pictureBoxVacuum.Image = pictureBoxCorpo.Image;
            }
            else
            {
                pictureBoxVacuum.Image = Properties.Resources.paper2;
            }
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
                pictureBoxSetaY.Visible = true;
                pictureBoxSetaX.Visible = true;
                pictureBoxBase.Visible = false;
                pictureBoxAx.Visible = true;
                labelZero.Visible = true;
                labelY.Visible = true;
                labelX.Visible = true;
            }
            else
            {
                pictureBoxSetaY.Visible = false;
                pictureBoxSetaX.Visible = false;
                pictureBoxBase.Visible = true;
                pictureBoxAx.Visible = false;
                labelZero.Visible = false;
                labelY.Visible = false;
                labelX.Visible = false;
            }
        }
        public void clearPostion()
        {
            pictureBoxCorpo.Location = new Point(145, 30);
            pictureBoxCorpoPaper.Location = new Point(222, 30);
            pictureBoxVacuum.Location = new Point(16, 13);
        }
    }
}