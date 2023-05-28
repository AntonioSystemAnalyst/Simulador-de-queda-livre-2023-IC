﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace freeFall
{
    public partial class InitialView : Form
    {
        public int visibleAboutControl = 0;
        public int carouselCounter = 1;
        public int animationCounter = 1;
        public InitialView()
        {
            InitializeComponent();
            timerCarousel.Enabled = true;
            timerWindowControl.Enabled = true;
            timerAnimation.Enabled = true;
            trackBarPlanets.Value = 0;
            planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10²³", "3,7");
            richTextBoxText.Text = "QUEDA LIVRE\n\nA queda livre é um fenômeno físico que ocorre quando um corpo é liberado no ar ou vacúo, e é deixado para cair devido à gravidade.\n\nRESISTÊNCIA DO AR\n\nA resistência do ar é a força que se opõe ao movimento de um objeto pelo ar.\n\nREFERÊNCIAS\n\nImagens\n\nAs ilustrações dos horizontes dos planetas, no campo ''Experimento'', foram feitas com a inteligência artifical da Microsoft, ''Bing Image Creator'', que pode ser acessada em: https://www.bing.com/create. Acessada em 14 de maio de 2023.\n\nAs demais imagens foram retiradas da plataforma ''Pixabay'', que esta disponível no site: https://pixabay.com/pt/. Acessada em 14 de maio de 2023.\n\nCRÉDITOS\n\n";


        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            animationCounter += 2;

            pictureBoxCorpo.Location = new Point(50, animationCounter);

            if (animationCounter >= 359)
            {
                animationCounter = 0;
                pictureBoxCorpo.Location = new Point(50, 112);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timerWindowControl_Tick(object sender, EventArgs e)
        {

        }

        private void buttonSimulador_Click(object sender, EventArgs e)
        {
            freeFall.Program.Key = "open";
            this.Close();
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            if(visibleAboutControl == 0)
            {
                visibleAboutControl = 1;
                richTextBoxText.Visible = true;
            }
            else
            {
                visibleAboutControl = 0;
                richTextBoxText.Visible = false;
            }
          
        }


        private void buttonFreeFall_Click(object sender, EventArgs e)
        {
            
        }
 

        public void planetData(string name, string equatorialRadius, string diameter, string volume, string mass, string gravity)
        {
            richTextBoxPlanetsData.Text = "Astro: " + name + "\nRaio Equatorial: " +
                equatorialRadius + " km" + "\nDiâmetro: " + diameter + " km" + "\nVolume: " + volume + " km³" + "\nMassa: "
                + mass + " kg" + "\nGravidade: " + gravity + " m/s²";
        }

        private void trackBarColors_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarColors.Value;
            if (i == 2)
            {
                richTextBoxPlanetsData.ForeColor = Color.Blue;
                labelSimulador.ForeColor = Color.Blue;
                richTextBoxText.ForeColor = Color.Blue;
                labellogon.ForeColor = Color.Blue;

            }
            if (i == 3)
            {
                richTextBoxPlanetsData.ForeColor = Color.Red;
                labelSimulador.ForeColor = Color.Red;
                richTextBoxText.ForeColor = Color.Red;
                labellogon.ForeColor = Color.Red;
            }
            if (i == 4)
            {

                richTextBoxPlanetsData.ForeColor = Color.Green;
                labelSimulador.ForeColor = Color.Green;
                richTextBoxText.ForeColor = Color.Green;
                labellogon.ForeColor = Color.Green;
            }
            if (i == 5)
            {

                richTextBoxPlanetsData.ForeColor = Color.Gray;
                labelSimulador.ForeColor = Color.Gray;
                richTextBoxText.ForeColor = Color.Gray;
                labellogon.ForeColor = Color.Gray;
            }
            if (i == 6)
            {

                richTextBoxPlanetsData.ForeColor = Color.White;
                labelSimulador.ForeColor = Color.White;
                richTextBoxText.ForeColor = Color.White;
                labellogon.ForeColor = Color.White;
            }
            if (i == 7)
            {

                richTextBoxPlanetsData.ForeColor = Color.HotPink;
                labelSimulador.ForeColor = Color.HotPink;
                richTextBoxText.ForeColor = Color.HotPink;
                labellogon.ForeColor = Color.HotPink;
            }
            if (i == 8)
            {

                richTextBoxPlanetsData.ForeColor = Color.LightBlue;
                labelSimulador.ForeColor = Color.LightBlue;
                richTextBoxText.ForeColor = Color.LightBlue;
                labellogon.ForeColor = Color.LightBlue;
            }
            if (i == 9)
            {

                richTextBoxPlanetsData.ForeColor = Color.LightSalmon;
                labelSimulador.ForeColor = Color.LightSalmon;
                richTextBoxText.ForeColor = Color.LightSalmon;
                labellogon.ForeColor = Color.LightSalmon;
            }
            if (i == 10)
            {

                richTextBoxPlanetsData.ForeColor = Color.LightPink;
                labelSimulador.ForeColor = Color.LightPink;
                richTextBoxText.ForeColor = Color.LightPink;
                labellogon.ForeColor = Color.LightPink;
            }
            if (i == 1)
            {

                richTextBoxPlanetsData.ForeColor = Color.Cyan;
                labelSimulador.ForeColor = Color.Cyan;
                richTextBoxText.ForeColor = Color.Cyan;
                labellogon.ForeColor = Color.Cyan;
            }
        }
        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            if (carouselCounter == 0)
            {
                trackBarPlanets.Value = 0;
                pictureBoxCarrocel.Image = Properties.Resources.planetMercury;
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10²³", "3,7");
            }
            if (carouselCounter == 1)
            {
                trackBarPlanets.Value = 1;
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10²⁴", "8,87");
            }
            if (carouselCounter == 2)
            {
                trackBarPlanets.Value = 2;
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10²⁴", "9,80665");
            }
            if (carouselCounter == 3)
            {
                trackBarPlanets.Value = 3;
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10²²", "1,624");
            }
            if (carouselCounter == 4)
            {
                trackBarPlanets.Value = 4;
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10²³", "3,71");
            }
            if (carouselCounter == 5)
            {
                trackBarPlanets.Value = 5;
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10²⁷", "24,79");
            }
            if (carouselCounter == 6)
            {
                trackBarPlanets.Value = 6;
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10²⁶", "10,4");
            }
            if (carouselCounter == 7)
            {
                trackBarPlanets.Value = 7;
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10²⁶", "11,15");
            }
            if (carouselCounter == 8)
            {
                trackBarPlanets.Value = 8;
                carouselCounter = -1;
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10²⁵", "8,87");
            }
            carouselCounter++;
        }
        private void trackBarPlanets_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarPlanets.Value;

            if (i == 0)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMercury;
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10^²3", "3,7");
                carouselCounter = 0;
            }
            if (i == 1)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10^²4", "8,87");
                carouselCounter = 1;
            }
            if (i == 2)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10^²4", "9,80665");
                carouselCounter = 2;
            }
            if (i == 3)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10^²2", "1,624");
                carouselCounter = 3;
            }
            if (i == 4)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10^²3", "3,71");
                carouselCounter = 4;
            }
            if (i == 5)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10^²7", "24,79");
                carouselCounter = 5;
            }
            if (i == 6)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10^²6", "10,4");
                carouselCounter = 6;
            }
            if (i == 7)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10^²6", "11,15");
                carouselCounter = 7;
            }
            if (i == 8)
            {
                carouselCounter = 0;
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10^²5", "8,87");
            }
        }

        private void richTextBoxPlanetsData_MouseEnter(object sender, EventArgs e)
        {
        }
    }
}
