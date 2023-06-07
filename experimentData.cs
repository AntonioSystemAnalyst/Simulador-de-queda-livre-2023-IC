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
        DataSet ds = null;
        DataTable dt = null;
        public static string planetName, gravity;
        public experimentData()
        {
            InitializeComponent();
            Program.experimentDataControl = 1;
            richTextBoxExperimentData.Text = Program.experimentData;
            loadData();
            startGrid();
            Flip();
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

        public void startGrid()
        {
            ds = new DataSet();
            dt = new DataTable();

            dt = GetCustomersOutAirResistence();
            ds.Tables.Add(dt);

            DataView my_DataView = ds.Tables[0].DefaultView;
            this.dataGridViewPlanets.DataSource = my_DataView;
        }
        private void Flip()
        {
            DataSet new_ds = FlipDataSet(ds); // Flip the DataSet
            DataView my_DataView = new_ds.Tables[0].DefaultView;
            this.dataGridViewPlanets.DataSource = my_DataView;
        }
        public DataSet FlipDataSet(DataSet my_DataSet)
        {
            DataSet ds = new DataSet();

            foreach (DataTable dt in my_DataSet.Tables)
            {
                DataTable table = new DataTable();

                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    table.Columns.Add(Convert.ToString(i));
                }
                DataRow r;
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    r = table.NewRow();
                    r[0] = dt.Columns[k].ToString();
                    for (int j = 1; j <= dt.Rows.Count; j++)
                        r[j] = dt.Rows[j - 1][k];
                    table.Rows.Add(r);
                }

                ds.Tables.Add(table);
            }
            return ds;
        }
        private static DataTable GetCustomersOutAirResistence()
        {
            DataTable table = new DataTable();
            table.TableName = "Customers";
            table.Columns.Add("hue", typeof(string));
            table.Columns.Add("Nome do Planeta", typeof(string));
            table.Columns.Add("Gravidade", typeof(string));
            table.Columns.Add("Tempo para o corpo", typeof(string));
            table.Columns.Add("Velcoidade inicial do corpo", typeof(string));
            table.Columns.Add("Velcoidade infinal do corpo", typeof(string));

            table.Rows.Add(new object[] { "-", planetName});

            table.AcceptChanges();

            return table;
        }
        public void loadData()
        {
            planetName = Program.planetName;
        }
     }
}
