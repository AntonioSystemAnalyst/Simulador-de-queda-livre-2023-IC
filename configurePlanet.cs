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
    public partial class configurePlanet : Form
    {
        public configurePlanet()
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
