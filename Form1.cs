using System;
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
    public partial class Form1 : Form
    {
        public int carouselCounter = 1;
        public Form1()
        {
            InitializeComponent();
            timerCarousel.Enabled = true;
            timerWindowControl.Enabled = true;
            trackBarPlanets.Value = 0;
            planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10^23", "3,7");
            textSet(0);
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
            textSet(1);
        }

        private void buttonReferences_Click(object sender, EventArgs e)
        {
            textSet(2);
        }

        private void buttonAirResistance_Click(object sender, EventArgs e)
        {
            textSet(3);
        }

        private void buttonGravitation_Click(object sender, EventArgs e)
        {
            textSet(4);
        }

        private void buttonFreeFall_Click(object sender, EventArgs e)
        {
            textSet(0);
        }
        public void textSet(int text)
        {
            if (text == 0)
            {
                richTextBoxText.Text = "QUEDA LIVRE\n\nA queda livre é um fenômeno físico que ocorre quando um corpo é liberado no ar e é deixado para cair devido à gravidade. Durante a queda livre, o corpo cai em direção à Terra com uma aceleração constante de cerca de 9,8 metros por segundo ao quadrado (m/s²), que é a aceleração da gravidade. Esse valor pode variar ligeiramente dependendo da localização na Terra, da altitude e de outros fatores, mas geralmente é considerado constante em níveis normais de altitude.\r\n\r\nDurante a queda livre, a única força que age sobre o corpo é a força da gravidade. Essa força é o que acelera o corpo em direção ao solo. Quando o corpo é lançado ou solto, ele começa a cair em direção à Terra e sua velocidade aumenta continuamente. No entanto, a força do ar também começa a agir sobre o corpo, retardando sua velocidade. Isso é conhecido como resistência do ar, e é por isso que um objeto pequeno, como uma pena, leva mais tempo para cair do que um objeto maior e mais denso, como uma pedra.\r\n\r\nO tempo que um objeto leva para cair depende da altura de queda e da gravidade. A equação básica para calcular o tempo de queda é: t = raiz quadrada de 2h/g, onde t é o tempo de queda, h é a altura da queda e g é a aceleração da gravidade. Por exemplo, se um objeto for deixado cair de uma altura de 20 metros, o tempo que ele levará para atingir o solo é de cerca de 2,02 segundos.\r\n\r\nA queda livre é um conceito importante na física e tem muitas aplicações práticas. É usado em esportes como paraquedismo e bungee jumping, bem como em experimentos científicos para estudar a gravidade e a aceleração. A queda livre também é um componente importante da física dos corpos em movimento e é usado para calcular a trajetória de objetos em queda livre, como meteoritos ou satélites artificiais.\r\n\r\nEm resumo, a queda livre é um fenômeno físico importante que ocorre quando um corpo é deixado cair no ar e é acelerado em direção à Terra devido à força da gravidade. É um conceito importante na física e tem muitas aplicações práticas em esportes e experimentos científicos.";
            }
            if (text == 1)
            {
                richTextBoxText.Text = "CRÉDITOS\n\nOrientador:Prof. Dr. Antonio Augusto Soares.\n\nGraduando em Física: José Antonio de A. Silva.";
            }
            if (text == 2)
            {
                richTextBoxText.Text = "REFERÊNCIAS\n\nLivros\n\nImagens\n\nAs ilustrações dos horizontes dos planetas, no campo ''Experimento'', foram feitas com a inteligência artifical da Microsoft, ''Bing Image Creator'', que pode ser acessada em: https://www.bing.com/create. Acessada em 14 de maio de 2023.\n\nAs demais imagens foram retiradas da plataforma ''Pixabay'', que esta disponível no site: https://pixabay.com/pt/. Acessada em 14 de maio de 2023.";
            }
            if (text == 3)
            {
                richTextBoxText.Text = "RESISTÊNCIA ATMOSFÉRICA\n\nResistência do ar";
            }
            if (text == 4)
            {
                richTextBoxText.Text = "GRAVITAÇÃO\n\nGravitação.";
            }
        }

        public void planetData(string name, string equatorialRadius, string diameter, string volume, string mass, string gravity)
        {
            richTextBoxPlanetsData.Text = "Astro: " + name + "\nRaio Equatorial (km): " +
                equatorialRadius + "\nDiâmetro (km): " + diameter + "\nVolume (km^3): " + volume + "\nMassa (kg): "
                + mass + "\nGravidade (m/s^2): " + gravity;
        }

        private void trackBarColors_Scroll(object sender, EventArgs e)
        {
            int i;
            i = trackBarColors.Value;
            if (i == 2)
            {
                richTextBoxText.ForeColor = Color.Blue;
                richTextBoxPlanetsData.ForeColor = Color.Blue;
                labelSimulador.ForeColor = Color.Blue;
            }
            if (i == 3)
            {
                richTextBoxText.ForeColor = Color.Red;
                richTextBoxPlanetsData.ForeColor = Color.Red;
                labelSimulador.ForeColor = Color.Red;
            }
            if (i == 4)
            {
                richTextBoxText.ForeColor = Color.Green;
                richTextBoxPlanetsData.ForeColor = Color.Green;
                labelSimulador.ForeColor = Color.Green;
            }
            if (i == 5)
            {
                richTextBoxText.ForeColor = Color.Gray;
                richTextBoxPlanetsData.ForeColor = Color.Gray;
                labelSimulador.ForeColor = Color.Gray;
            }
            if (i == 6)
            {
                richTextBoxText.ForeColor = Color.Green;
                richTextBoxPlanetsData.ForeColor = Color.Green;
                labelSimulador.ForeColor = Color.Green;
            }
            if (i == 7)
            {
                richTextBoxText.ForeColor = Color.HotPink;
                richTextBoxPlanetsData.ForeColor = Color.HotPink;
                labelSimulador.ForeColor = Color.HotPink;
            }
            if (i == 8)
            {
                richTextBoxText.ForeColor = Color.LightBlue;
                richTextBoxPlanetsData.ForeColor = Color.LightBlue;
                labelSimulador.ForeColor = Color.LightBlue;
            }
            if (i == 9)
            {
                richTextBoxText.ForeColor = Color.LightSalmon;
                richTextBoxPlanetsData.ForeColor = Color.LightSalmon;
                labelSimulador.ForeColor = Color.LightSalmon;
            }
            if (i == 10)
            {
                richTextBoxText.ForeColor = Color.LightPink;
                richTextBoxPlanetsData.ForeColor = Color.LightPink;
                labelSimulador.ForeColor = Color.LightPink;
            }
            if (i == 1)
            {
                richTextBoxText.ForeColor = Color.Cyan;
                richTextBoxPlanetsData.ForeColor = Color.Cyan;
                labelSimulador.ForeColor = Color.Cyan;
            }
        }
        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            if (carouselCounter == 0)
            {
                trackBarPlanets.Value = 0;
                pictureBoxCarrocel.Image = Properties.Resources.planetMercury;
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10^23", "3,7");
            }
            if (carouselCounter == 1)
            {
                trackBarPlanets.Value = 1;
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10^24", "8,87");
            }
            if (carouselCounter == 2)
            {
                trackBarPlanets.Value = 2;
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10^24", "9,80665");
            }
            if (carouselCounter == 3)
            {
                trackBarPlanets.Value = 3;
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10^22", "1,624");
            }
            if (carouselCounter == 4)
            {
                trackBarPlanets.Value = 4;
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10^23", "3,71");
            }
            if (carouselCounter == 5)
            {
                trackBarPlanets.Value = 5;
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10^27", "24,79");
            }
            if (carouselCounter == 6)
            {
                trackBarPlanets.Value = 6;
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10^26", "10,4");
            }
            if (carouselCounter == 7)
            {
                trackBarPlanets.Value = 7;
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10^26", "11,15");
            }
            if (carouselCounter == 8)
            {
                trackBarPlanets.Value = 8;
                carouselCounter = -1;
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10^25", "8,87");
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
                planetData("Mercurio", "2.439,7", "4.879,4", "60.827.208.742 ", "3,3010 x 10^23", "3,7");
                carouselCounter = 0;
            }
            if (i == 1)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetVenus;
                planetData("Venus", "6.051,8", "12.104", "928.415.345.893", "4,8673 x 10^24", "8,87");
                carouselCounter = 1;
            }
            if (i == 2)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetEarth;
                planetData("Terra", "6.371,00", "12.742", "1.083.206.916.846", "5,9722 x 10^24", "9,80665");
                carouselCounter = 2;
            }
            if (i == 3)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMoon;
                planetData("Lua", "1737,5 ", "3.474,2", "21.971.669.064", "7,3477 x 10^22", "1,624");
                carouselCounter = 3;
            }
            if (i == 4)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetMars;
                planetData("Marte", "3.389,5", "6.779", "163.115.609.799", "6,4169 x 10^23", "3,71");
                carouselCounter = 4;
            }
            if (i == 5)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetJupiter;
                planetData("Júpiter", "69.911", "139.820", "1.431.281.810.739.360", "1.8981 x 10^27", "24,79");
                carouselCounter = 5;
            }
            if (i == 6)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetSaturn;
                planetData("Saturno", "58.232", "116.460", "827.129.915.150.897", "5,6832 x 10^26", "10,4");
                carouselCounter = 6;
            }
            if (i == 7)
            {
                pictureBoxCarrocel.Image = Properties.Resources.planetNeptune;
                planetData("Netuno", "24.622", "49.224", "62.525.703.987.421", "1.0241 x 10^26", "11,15");
                carouselCounter = 7;
            }
            if (i == 8)
            {
                carouselCounter = 0;
                pictureBoxCarrocel.Image = Properties.Resources.planetUranus;
                planetData("Urâno", "25.362", "50.724", "68.334.355.695.584", "8,6810 x 10^25", "8,87");
            }
        }

        private void richTextBoxPlanetsData_MouseEnter(object sender, EventArgs e)
        {
        }
    }
}
