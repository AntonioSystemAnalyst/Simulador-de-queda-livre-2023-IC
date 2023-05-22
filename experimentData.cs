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
    public partial class experimentData : Form
    {
        public experimentData()
        {
            InitializeComponent();
            Program.experimentDataControl = 1;
            richTextBoxExperimentData.Text = Program.experimentData;
        }

        private void experimentData_Load(object sender, EventArgs e)
        {

        }

        private void experimentData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.experimentDataControl = 0;
        }

        private void richTextBoxExperimentData_CursorChanged(object sender, EventArgs e)
        {
            Cursor= Cursors.No;
        }

        private void buttonFocus_Click(object sender, EventArgs e)
        {

        }
    }
}
