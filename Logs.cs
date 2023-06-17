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
        DataSet dsGeneral = null;
        DataTable dtGeneral = null;
        public static string planetName, gravity, height, airResistence, airDensity, initialVelocityBody, finalVelocityBody, experimentTimeBody, DragCoefficientBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper, DragCoefficientPaper;

        private void richTextBoxCorpoVetors_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxPaperVetors_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxVaccumVetors_TextChanged(object sender, EventArgs e)
        {

        }

        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum, DragCoefficientVaccum;

        public programView()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            view();
            configureDataGrid();
            dataGridViewGeneral.CurrentCell = null;
            //colorAll();
            configureDataGrid();
            loadData();
            startGrid();
            FlipGeneral();
        }

        public void configureDataGrid()
        {
            dataGridViewGeneral.BackgroundColor = Color.Black;
            dataGridViewGeneral.DefaultCellStyle.BackColor = Color.Black;
            dataGridViewGeneral.DefaultCellStyle.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            dataGridViewGeneral.DefaultCellStyle.Font = new Font(dataGridViewGeneral.DefaultCellStyle.Font.FontFamily, 12);
            dataGridViewGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewGeneral.AllowUserToResizeColumns = false;
            dataGridViewGeneral.AllowUserToResizeRows = false;
        }

        public void view()
        {
            int i;
            string corpoVetors = "", paperVetors = "";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Console View Corpo\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " finalVelocity: " + Program.corpo.FinalVelocity + "\n";
            richTextBoxCorpo.Text += " timeAllExperiment: " + Program.corpo.TimeAllExperiment + "\n";
            richTextBoxCorpo.Text += " numberOfTerms: " + Program.corpo.NumberOfTerms + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Calculos - Qtd Termos\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Space: " + Program.corpo.Space.Length + "\n";
            richTextBoxCorpo.Text += " Speed: " + Program.corpo.Velocity.Length + "\n";
            richTextBoxCorpo.Text += " countTimeExp.: " + Program.corpo.CountTimeExperiment.Length + "\n";
            richTextBoxCorpo.Text += " SpaceTime: " + Program.corpo.SpaceTime.Length + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Animação\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " qtdSpaceForNumberOfTermes: \n";
            richTextBoxCorpo.Text += " " + Program.corpo.QtdSpaceForNumberOfTermes + "\n";
            richTextBoxCorpo.Text += " qtdSpaceForPixels: \n";
            richTextBoxCorpo.Text += " " + Program.corpo.QtdSpaceForPixels + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Qtd Termos\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " animationPixel: " + Program.corpo.AnimationPixel.Length + "\n";
            richTextBoxCorpo.Text += " animationSpace: " + Program.corpo.AnimationSpace.Length + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";

            for(i=0; i<Program.corpo.NumberOfTerms; i++)
            {
                corpoVetors += "|Ts:" + Program.corpo.SpaceTime[i] + "|S: " + Program.corpo.Space[i] + "|V:" + Program.corpo.Velocity[i] + "\n";
            }

            if(Program.paperOn)
            {
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " Console View paper\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " finalVelocity: " + Program.paper.FinalVelocity + "\n";
                richTextBoxPaper.Text += " timeAllExperiment: " + Program.paper.TimeAllExperiment + "\n";
                richTextBoxPaper.Text += " numberOfTerms: " + Program.paper.NumberOfTerms + "\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " Calculos - Qtd Termos\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " Space: " + Program.paper.Space.Length + "\n";
                richTextBoxPaper.Text += " Speed: " + Program.paper.Velocity.Length + "\n";
                richTextBoxPaper.Text += " countTimeExp.: " + Program.paper.CountTimeExperiment.Length + "\n";
                richTextBoxPaper.Text += " SpaceTime: " + Program.paper.SpaceTime.Length + "\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " Animação\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " qtdSpaceForNumberOfTermes: \n";
                richTextBoxPaper.Text += " " + Program.paper.QtdSpaceForNumberOfTermes + "\n";
                richTextBoxPaper.Text += " qtdSpaceForPixels: \n";
                richTextBoxPaper.Text += " " + Program.paper.QtdSpaceForPixels + "\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " Qtd Termos\n";
                richTextBoxPaper.Text += " ----------------------------\n";
                richTextBoxPaper.Text += " animationPixel: " + Program.paper.AnimationPixel.Length + "\n";
                richTextBoxPaper.Text += " animationSpace: " + Program.paper.AnimationSpace.Length + "\n";
                richTextBoxPaper.Text += " ----------------------------\n";

                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    paperVetors += "|Ts:" + Program.paper.SpaceTime[i] + "|S: " + Program.paper.Space[i] + "|V:" + Program.paper.Velocity[i] + "\n";
                }
            }

            if (Program.vaccumOn)
            {
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " Console View Corpo\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " finalVelocity: " + Program.corpo.FinalVelocity + "\n";
                richTextBoxCorpo.Text += " timeAllExperiment: " + Program.corpo.TimeAllExperiment + "\n";
                richTextBoxCorpo.Text += " numberOfTerms: " + Program.corpo.NumberOfTerms + "\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " Calculos - Qtd Termos\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " Space: " + Program.corpo.Space.Length + "\n";
                richTextBoxCorpo.Text += " Speed: " + Program.corpo.Velocity.Length + "\n";
                richTextBoxCorpo.Text += " countTimeExp.: " + Program.corpo.CountTimeExperiment.Length + "\n";
                richTextBoxCorpo.Text += " SpaceTime: " + Program.corpo.SpaceTime.Length + "\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " Animação\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " qtdSpaceForNumberOfTermes: \n";
                richTextBoxCorpo.Text += " " + Program.corpo.QtdSpaceForNumberOfTermes + "\n";
                richTextBoxCorpo.Text += " qtdSpaceForPixels: \n";
                richTextBoxCorpo.Text += " " + Program.corpo.QtdSpaceForPixels + "\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " Qtd Termos\n";
                richTextBoxCorpo.Text += " ----------------------------\n";
                richTextBoxCorpo.Text += " animationPixel: " + Program.corpo.AnimationPixel.Length + "\n";
                richTextBoxCorpo.Text += " animationSpace: " + Program.corpo.AnimationSpace.Length + "\n";
                richTextBoxCorpo.Text += " ----------------------------\n";

                for (i = 0; i < Program.corpo.NumberOfTerms; i++)
                {
                    corpoVetors += "|Ts:" + Program.corpo.SpaceTime[i] + "|S: " + Program.corpo.Space[i] + "|V:" + Program.corpo.Velocity[i] + "\n";
                }
            }
        }

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            dataGridViewGeneral.CurrentCell = null;
            buttonVetors.Focus();
            timerFocus.Enabled = false;
        }

        private void programView_Load(object sender, EventArgs e)
        {
            dataGridViewGeneral.CurrentCell = null;
        }
        public void startGrid()
        {
            dsGeneral = new DataSet();
            dtGeneral = new DataTable();

            dtGeneral = GetCustomersOutAirResistence();
            dsGeneral.Tables.Add(dtGeneral);

            DataView my_DataView = dsGeneral.Tables[0].DefaultView;
            this.dataGridViewGeneral.DataSource = my_DataView;
        }
        private void FlipGeneral()
        {
            DataSet new_ds = FlipDataSetGeneral(dsGeneral);
            DataView my_DataView = new_ds.Tables[0].DefaultView;
            this.dataGridViewGeneral.DataSource = my_DataView;
        }
        public DataSet FlipDataSetGeneral(DataSet my_DataSet)
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
            table.Columns.Clear();
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Gravidade", typeof(string));
            table.Columns.Add("Altura", typeof(string));
            table.Columns.Add("Resis. Ar", typeof(string));

            if (Program.airResistance == 1)
            {
                table.Columns.Add("Atm. dens.", typeof(string));
            }
            table.Columns.Add("Tempo para a bóla", typeof(string));
            table.Columns.Add("Velocidade inicial da bóla", typeof(string));
            table.Columns.Add("Velocidade final da bóla", typeof(string));
            if (Program.airResistance == 1)
            {

                table.Columns.Add("Coeficiente de arrasto corpo", typeof(string));
            }

            if (Program.paperOn)
            {
                table.Columns.Add("Tempo para o papel", typeof(string));
                table.Columns.Add("Velocidade inicial do papel", typeof(string));
                table.Columns.Add("Velocidade final do papel", typeof(string));
                if (Program.airResistance == 1)
                {

                    table.Columns.Add("Coeficiente de arrasto papel", typeof(string));
                }
            }
            if (Program.vaccumOn)
            {
                table.Columns.Add("Tempo para o vácuo", typeof(string));
                table.Columns.Add("Velocidade inicial do vácuo", typeof(string));
                table.Columns.Add("Velocidade final do vácuo", typeof(string));
                if (Program.airResistance == 1)
                {

                    table.Columns.Add("Coeficiente de arrasto vácuo", typeof(string));
                }
            }

            if (Program.paperOn && Program.vaccumOn)
            {
                if (Program.airResistance == 0)
                {
                    table.Rows.Add(new object[] {planetName, gravity, height, airResistence, experimentTimeBody,
                    initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper,
                    experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum});
                }
                else
                {
                    table.Rows.Add(new object[] {planetName, gravity, height, airResistence, airDensity, experimentTimeBody,
                    initialVelocityBody, finalVelocityBody, DragCoefficientBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper, DragCoefficientPaper,
                    experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum, DragCoefficientVaccum});
                }
            }
            else
            {
                if (Program.paperOn == false && Program.vaccumOn)
                {
                    if (Program.airResistance == 0)
                    {
                        table.Rows.Add(new object[] {planetName, gravity, height, airResistence, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody, experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum });
                    }
                    else
                    {
                        table.Rows.Add(new object[] {planetName, gravity, height, airResistence, airDensity, experimentTimeBody,
                        initialVelocityBody, finalVelocityBody, DragCoefficientBody, experimentTimeVaccum, initialVelocityVaccum, finalVelocityVaccum, DragCoefficientVaccum});
                    }
                }
                else
                {
                    if (Program.paperOn && Program.vaccumOn == false)
                    {
                        if (Program.airResistance == 0)
                        {
                            table.Rows.Add(new object[] { planetName, gravity, height, airResistence, experimentTimeBody,
                            initialVelocityBody, finalVelocityBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper });
                        }
                        else
                        {
                            table.Rows.Add(new object[] { planetName, gravity, height, airResistence, airDensity, experimentTimeBody,
                            initialVelocityBody, finalVelocityBody, DragCoefficientBody, experimentTimePaper, initialVelocityPaper, finalVelocityPaper, DragCoefficientPaper });
                        }
                    }
                    else
                    {
                        if (Program.airResistance == 0)
                        {
                            table.Rows.Add(new object[] {planetName, gravity, height, airResistence, experimentTimeBody,
                            initialVelocityBody, finalVelocityBody });
                        }
                        else
                        {
                            table.Rows.Add(new object[] {planetName, gravity, height, airResistence, airDensity, experimentTimeBody,
                            initialVelocityBody, DragCoefficientBody, finalVelocityBody });
                        }
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
            airDensity = "" + Program.airDensity;
            height = "" + Program.height + " m";
            DragCoefficientBody = "" + Program.corpo.DragCoefficient;
            DragCoefficientPaper = "" + Program.paper.DragCoefficient;
            DragCoefficientVaccum = "" + Program.vaccum.DragCoefficient;
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

        // ===
    }
}
