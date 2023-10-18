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
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            loading();
        }

        private void Table_Load(object sender, EventArgs e)
        {

        }

        public void loading ()
        {
            int i;

            richTextBox.Text += "Hello Antony\n";
            richTextBox.Text += "\n";
            richTextBox.Text += "greatestValueTime: " + Program.greatestValueTime + "\n";
            richTextBox.Text += "numberOfTermsTable: "+ Program.numberOfTermsTable + "\n";

            richTextBox.Text += "-----------------------------" +"\n";
            richTextBox.Text += "ballFinalTime: " + Program.ballFinalTime + "\n";
            richTextBox.Text += "paperFinalTime: " + Program.paperFinalTime + "\n";
            richTextBox.Text += "vaccumFinalTime: " + Program.vaccumFinalTime + "\n";
            richTextBox.Text += "-----------------------------" +"\n";
            richTextBox.Text += "-----------------------------" + "\n";
            richTextBox.Text += "ballFinalSpace: " + Program.ballFinalSpace[0] + "\n";
            richTextBox.Text += "paperFinalSpace: " + Program.paperFinalSpace[1] + "\n";
            richTextBox.Text += "vaccumFinalSpace: " + Program.vaccumFinalSpace[2] + "\n";
            richTextBox.Text += "-----------------------------" + "\n";

            for (i=0; i<Program.numberOfTermsTable; i++)
            {
                richTextBox.Text += "["+i+"] Time: " + Program.timeTable[i] + "\n";
            }
        }
    }
}
