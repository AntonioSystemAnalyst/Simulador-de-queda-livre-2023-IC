using System;
using System.Drawing;
using System.Windows.Forms;

namespace freeFall
{
    public partial class InitialView : Form
    {
        public int visibleAboutControl = 0;
        public int carouselCounter = 2;
        public int animationCounter = 1;
        public InitialView()
        {
            InitializeComponent();
            timerCarousel.Enabled = true;
            timerAnimationAlone.Enabled = true;
            trackBarPlanets.Value = 2;
            planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10²⁴", "9,80665", "1,23");
            Program.airDensity = 1.23;
            //richTextBoxText.Text = "QUEDA LIVRE\n\nA queda livre é um fenômeno físico que ocorre quando um corpo é liberado no ar ou vacúo, e é deixado para cair devido à gravidade.\n\nRESISTÊNCIA DO AR\n\nA resistência do ar é a força que se opõe ao movimento de um objeto pelo ar.\n\nREFERÊNCIAS\n\nImagens\n\nAs ilustrações dos horizontes dos planetas, no campo ''Experimento'', foram feitas com a inteligência artifical da Microsoft, ''Bing Image Creator'', que pode ser acessada em: https://www.bing.com/create. Acessada em 14 de maio de 2023.\n\nAs demais imagens foram retiradas da plataforma ''Pixabay'', que esta disponível no site: https://pixabay.com/pt/. Acessada em 14 de maio de 2023.\n\nCRÉDITOS\n\n";
            richTextBoxText.Text = "Este conteúdo será inserido futuramente.";
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            int rndNumber = 0;
            animationCounter += 2;
            Random rnd = new Random();
            pictureBoxCorpo.Location = new Point(50, animationCounter);

            if (animationCounter >= 359)
            {
                animationCounter = 0;
                rndNumber = rnd.Next(1, 6);
                pictureBoxCorpo.Location = new Point(50, 112);
                if (rndNumber == 1)
                {
                    pictureBoxCorpo.Image = Properties.Resources.corpoBall4;
                }
                if (rndNumber == 2)
                {
                    pictureBoxCorpo.Image = Properties.Resources.corpoBasketball;
                }
                if (rndNumber == 3)
                {
                    pictureBoxCorpo.Image = Properties.Resources.corpoBowling;
                }
                if (rndNumber == 4)
                {
                    pictureBoxCorpo.Image = Properties.Resources.corpoGolf;
                }
                if (rndNumber == 5)
                {
                    pictureBoxCorpo.Image = Properties.Resources.corpoSoccer;
                }
            }
        }
        private void timerAnimationAlone_Tick(object sender, EventArgs e)
        {
            animationCounter += 2;
            pictureBoxCorpo.Location = new Point(50, animationCounter);

            if (animationCounter >= 359)
            {
                animationCounter = 0;
                pictureBoxCorpo.Location = new Point(50, 112);
                pictureBoxCorpo.Image = Properties.Resources.corpoSoccer;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBarPlanets.Maximum = Program.numberOfPlanets;
        }

        private void buttonSimulador_Click(object sender, EventArgs e)
        {
            
            timerCarousel.Enabled = false;
            timerAnimation.Enabled = false;
            timerSetTrackPlanet.Enabled = false;
            Program.planeTrackBar = setPlanetTrackBar(carouselCounter);
            Program.Key = "open";
            this.Close();
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            if (visibleAboutControl == 0)
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


        public void planetData(string name, string equatorialRadius, string diameter, string volume, string mass, string gravity, string atmDensity)
        {
            richTextBoxPlanetsData.Text = "Astro: " + name + "\nRaio Equatorial: " +
                equatorialRadius + " km" + "\nDiâmetro: " + diameter + " km" + "\nVolume: " + volume + " km³" + "\nMassa: "
                + mass + " kg" + "\nGravidade: " + gravity + " m/s²" + "\nDensidade Atm: " + atmDensity + " kg/m³";
        }

        private void trackBarColors_Scroll(object sender, EventArgs e)
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

        public void colorAll()
        {
            richTextBoxPlanetsData.ForeColor = Program.colorSimulator;
            labelSimulador.ForeColor = Program.colorSimulator;
            richTextBoxText.ForeColor = Program.colorSimulator;
            labellogon.ForeColor = Program.colorSimulator;
            labelTextColor.ForeColor = Program.colorSimulator;
        }
        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            carouselCounter++;
            Program.planeTrackBar = carouselCounter;
            if (carouselCounter == 0)
            {
                trackBarPlanets.Value = 0;
                pictureBoxCarrocel.Image = Properties.Resources.planetMercury;
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10²³", "3,7", "0");
                Program.airDensity = 0;
            }
            if (carouselCounter == 1)
            {
                trackBarPlanets.Value = 1;
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10²⁴", "8,87", "64,8");
                Program.airDensity = 64.8;
            }
            if (carouselCounter == 2)
            {
                trackBarPlanets.Value = 2;
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10²⁴", "9,80665", "1,23");
                Program.airDensity = 1.23;
            }
            if (carouselCounter == 3)
            {
                trackBarPlanets.Value = 3;
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10²²", "1,624", "0");
                Program.airDensity = 0;
            }
            if (carouselCounter == 4)
            {
                trackBarPlanets.Value = 4;
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10²³", "3,71", "0,02");
                Program.airDensity = 0.02;
                if (Program.numberOfPlanets == 4)
                {
                  carouselCounter = -1;
                }
            }
            if (carouselCounter == 5)
            {
                trackBarPlanets.Value = 5;
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10²⁷", "24,79", "0,16");
                Program.airDensity = 0.16;
            }
            if (carouselCounter == 6)
            {
                trackBarPlanets.Value = 6;
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10²⁶", "10,4", "0,19");
                Program.airDensity = 0.19;
            }
            if (carouselCounter == 7)
            {
                trackBarPlanets.Value = 7;
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10²⁵", "8,87", "0,42");
                Program.airDensity = 0.42;
            }
            if (carouselCounter == 8)
            {
                trackBarPlanets.Value = 8;
                carouselCounter = -1;
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10²⁶", "11,15", "0,45");
                Program.airDensity = 0.45;
            }
        }
        private void trackBarPlanets_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarPlanets.Value;
            Program.planeTrackBar = i;
            if (i == 0)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMercury;
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10^²3", "3,7", "0");
                Program.airDensity = 0;
                carouselCounter = 0;
            }
            if (i == 1)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10^²4", "8,87", "64,8");
                Program.airDensity = 64.8;
                carouselCounter = 1;
            }
            if (i == 2)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10^²4", "9,80665", "1,23");
                Program.airDensity = 1.23;
                carouselCounter = 2;
            }
            if (i == 3)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10^²2", "1,624", "0");
                Program.airDensity = 0;
                carouselCounter = 3;
            }
            if (i == 4)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10^²3", "3,71", "0,02");
                Program.airDensity = 0.02;
                carouselCounter = 4;
            }
            if (i == 5)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10^²7", "24,79", "0,16");
                Program.airDensity = 0.16;
                carouselCounter = 5;
            }
            if (i == 6)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10^²6", "10,4", "0,19");
                Program.airDensity = 0.19;
                carouselCounter = 6;
            }
            if (i == 7)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10^²5", "8,87", "0,42");
                Program.airDensity = 0.42;
                carouselCounter = 7;
            }
            if (i == 8)
            {
                carouselCounter = 8;
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10^²6", "11,15", "0,45");
                Program.airDensity = 0.45;
            }
        }

        public static int setPlanetTrackBar(int carouselCounter)
        {
            int value = 0;
            if (carouselCounter == 0)
            {
                value = 3;
            }
            if (carouselCounter == 1)
            {
                value = 4;
            }
            if (carouselCounter == 2)
            {
                value = 1;
            }
            if (carouselCounter == 3)
            {
                value = 2;
            }
            if (carouselCounter == 4)
            {
                value = 5;
            }
            if (carouselCounter == 5)
            {
                value = 6;
            }
            if (carouselCounter == 6)
            {
                value = 7;
            }
            if (carouselCounter == 7)
            {
                value = 8;
            }
            if (carouselCounter == 8)
            {
                value = 9;
            }
            return value;
        }

        private void richTextBoxPlanetsData_MouseEnter(object sender, EventArgs e)
        {
        }

        private void timerSetTrackPlanet_Tick(object sender, EventArgs e)
        {

        }
    }
}
