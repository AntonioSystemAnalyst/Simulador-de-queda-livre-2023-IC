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
    public partial class logVetors : Form
    {
        public logVetors()
        {
            InitializeComponent();
        }

        private void logVetors_Load(object sender, EventArgs e)
        {

        }

        public void loadData(string Corpo, string Paper, string Vaccum)
        {
            richTextBoxCorpo.Text = Corpo;
            richTextBoxPaper.Text = Paper;
            richTextBoxVaccum.Text = Vaccum;
        }

    }
}
