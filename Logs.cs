using System;
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
    public partial class programView : Form
    {
        public programView()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            view();

        }

        public void view()
        {
            int i;
            string spaceObjectTime = "";

            for (i=0; i<534; i++)
            {
                spaceObjectTime += "Pixel: " + i + " - ";
                spaceObjectTime += Program.corpo.SpacePixel[i];
                spaceObjectTime += " - ";
                spaceObjectTime += Program.corpo.SpaceTime[i];
                spaceObjectTime += "\n";

            }

            richTextBoxConsoleView.Text += " ------------------------------------------------------\n";
            richTextBoxConsoleView.Text += " Console view\n";
            richTextBoxConsoleView.Text += " ------------------------------------------------------\n";
            richTextBoxConsoleView.Text += " Dados calculados e obtidos das combobox: \n";
            richTextBoxConsoleView.Text += " Nome do Planeta: " + Program.planetName + "\n";
            richTextBoxConsoleView.Text += " Altura: " + Program.height + "\n";
            richTextBoxConsoleView.Text += " Gravidade: " + Program.gravity + "\n";
            richTextBoxConsoleView.Text += " Velocidade final objeto: " + Program.corpo.FinalVelocity + "\n";
            richTextBoxConsoleView.Text += " Tempo total: " + Program.corpo.TimeOutAirResistence + "\n";
            richTextBoxConsoleView.Text += " ------------------------------------------------------\n";
            richTextBoxConsoleView.Text += spaceObjectTime;
        }

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            buttonFocus.Focus();
            timerFocus.Enabled = false;
        }

        private void programView_Load(object sender, EventArgs e)
        {

        }
    }
}
