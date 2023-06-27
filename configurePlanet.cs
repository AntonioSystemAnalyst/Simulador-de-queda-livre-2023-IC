using System;
using System.Windows.Forms;

namespace freeFall
{
    public partial class ConfigurePlanet : Form
    {
        public ConfigurePlanet()
        {
            InitializeComponent();
            Program.configurePlanetControl = 1;
        }

        private void configurePlanet_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.configurePlanetControl = 0;
        }

        private void configurePlanet_Load(object sender, EventArgs e)
        {

        }
    }
}
