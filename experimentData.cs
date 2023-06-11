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
    public partial class ExperimentData : Form
    {
        DataSet ds = null;
        DataTable dt = null;
        public static string planetName, gravity, airResistence, initialVelocityBody, finalVelocityBody, experimentTimeBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper;
        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum;
        public ExperimentData()
        {
            InitializeComponent();
            Program.experimentDataControl = 1;
            richTextBoxExperimentData.Text = Program.experimentData;
            dataGridViewPlanets.BackgroundColor = Color.Black;
            dataGridViewPlanets.DefaultCellStyle.BackColor = Color.Black;
            dataGridViewPlanets.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            dataGridViewPlanets.DefaultCellStyle.Font = new Font(dataGridViewPlanets.DefaultCellStyle.Font.FontFamily, 12);
            dataGridViewPlanets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewPlanets.AllowUserToResizeColumns = false;
            dataGridViewPlanets.AllowUserToResizeRows = false;
            colorAll();
            loadData();
            startGrid();
            Flip();
        }

        private void experimentData_Load(object sender, EventArgs e)
        {
            dataGridViewPlanets.CurrentCell = null;
        }

        public void colorAll()
        {
            dataGridViewPlanets.GridColor = Program.colorSimulator;
            dataGridViewPlanets.DefaultCellStyle.ForeColor = Program.colorSimulator;
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
            DataSet new_ds = FlipDataSet(ds); 
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
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Gravidade", typeof(string));
            table.Columns.Add("Resistência do ar", typeof(string));
            table.Columns.Add("Tempo para a bóla", typeof(string));
            table.Columns.Add("Velcoidade inicial da bóla", typeof(string));
            table.Columns.Add("Velcoidade final da bóla", typeof(string));

            if (Program.paperOn)
            {
                table.Columns.Add("Tempo para o papel", typeof(string));
                table.Columns.Add("Velcoidade inicial do papel", typeof(string));
                table.Columns.Add("Velcoidade final do papel", typeof(string));

            }
            if (Program.vaccumOn)
            {
                table.Columns.Add("Tempo para o vacuo", typeof(string));
                table.Columns.Add("Velcoidade inicial do vácuo", typeof(string));
                table.Columns.Add("Velcoidade final do vácuo", typeof(string));

            }

            if(Program.paperOn && Program.vaccumOn)
            {
                table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper,
                 experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum});
            }
            else
            {
                if(Program.paperOn == false && Program.vaccumOn)
                {
                        table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                    initialVelocityBody, finalVelocityBody, experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum });
                }
                else
                {
                    if (Program.paperOn && Program.vaccumOn == false)
                    {
                                table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper });
                    }
                    else
                    {
                                table.Rows.Add(new object[] {planetName, gravity, airResistence, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody });
                    }
                }
            }

            table.AcceptChanges();
            return table;
        }
        public void loadData()
        {
            planetName = Program.planetName;
            gravity = "" + Math.Round(Program.gravity, 2) + " m/s²";
            //--
            initialVelocityBody = "" + Math.Round(Program.corpo.InitialVelocity, 2) + " m/s";
            finalVelocityBody = "" + Math.Round(Program.corpo.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                airResistence = "Não";
                experimentTimeBody = "" + Math.Round(Program.corpo.TimeAllExperiment, 2) + " s";
            }
            else
            {
                airResistence = "Sim";
                experimentTimeBody = "" + Math.Round(Program.corpo.TimeAllExperiment, 2) + " s";
            }
            //--
            initialVelocityPaper = "" + Math.Round(Program.paper.InitialVelocity, 2) + " m/s";
            finalVelocityPaper = "" + Math.Round(Program.paper.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                experimentTimePaper = "" + Math.Round(Program.paper.TimeAllExperiment, 2) + " s";
            }
            else
            {
                experimentTimePaper = "" + Math.Round(Program.paper.TimeAllExperiment, 2) + " s";
            }
            //--
            initialVelocityVaccum = "" + Math.Round(Program.vaccum.InitialVelocity, 2) + " m/s";
            finalVelocityVaccum = "" + Math.Round(Program.vaccum.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                experimentTimeVaccum = "" + Math.Round(Program.vaccum.TimeAllExperiment, 2) + " s";
            }
            else
            {
                experimentTimeVaccum = "" + Math.Round(Program.vaccum.TimeAllExperiment, 2) + " s";
            }
        }
    }
}
