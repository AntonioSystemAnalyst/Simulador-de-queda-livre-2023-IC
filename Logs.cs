using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace freeFall
{
    public partial class programView : Form
    {
        DataSet dsGeneral = null;
        DataTable dtGeneral = null;
        public static string planetName, gravity, height, airResistence, airDensity, initialVelocityBody, finalVelocityBody, experimentTimeBody, DragCoefficientBody;
        public static string initialVelocityPaper, finalVelocityPaper, experimentTimePaper, DragCoefficientPaper;
        public static string corpoVetors = "", paperVetors = "", vaccumVetors = "";
        public static string corpoAnimation = "", paperAnimation = "", vaccumAnimation = "";
        public static string corpoAnimationPixel = "", paperAnimationPixel = "", vaccumAnimationPixel = "";
        private void richTextBoxCorpoVetors_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxPaperVetors_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxVaccumVetors_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVetors_Click(object sender, EventArgs e)
        {
            logVetors x = new logVetors();
            x.Show();
            x.loadData(corpoVetors, paperVetors, vaccumVetors);
            x.loadDataAnimation(corpoAnimation, paperAnimation, paperAnimation);
            x.loadDataAnimationPixel(corpoAnimationPixel, paperAnimationPixel, vaccumAnimationPixel);
        }

        public static string initialVelocityVaccum, finalVelocityVaccum, experimentTimeVaccum, DragCoefficientVaccum;

        public programView()
        {
            InitializeComponent();
            timerFocus.Enabled = true;
            view();
            configureDataGrid();
            dataGridViewGeneral.CurrentCell = null;
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
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Console View Corpo\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " finalVelocity: " + Program.ball.FinalVelocity + "\n";
            richTextBoxCorpo.Text += " timeAllExperiment: " + Program.ball.TimeAllExperiment + "\n";
            richTextBoxCorpo.Text += " numberOfTerms: " + Program.ball.NumberOfTerms + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Calculos - Qtd Termos\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Space: " + Program.ball.Space.Length + "\n";
            richTextBoxCorpo.Text += " Speed: " + Program.ball.Velocity.Length + "\n";
            richTextBoxCorpo.Text += " countTimeExp.: " + Program.ball.CountTimeExperiment.Length + "\n";
            richTextBoxCorpo.Text += " SpaceTime: " + Program.ball.SpaceTime.Length + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Animação\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " qtdSpaceForNumberOfTermes: \n";
            richTextBoxCorpo.Text += " " + Program.ball.QtdSpaceForNumberOfTermes + "\n";
            richTextBoxCorpo.Text += " qtdSpaceForPixels: \n";
            richTextBoxCorpo.Text += " " + Program.ball.QtdSpaceForPixels + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " Qtd Termos\n";
            richTextBoxCorpo.Text += " ----------------------------\n";
            richTextBoxCorpo.Text += " animationPixel: " + Program.ball.AnimationPixel.Length + "\n";
            richTextBoxCorpo.Text += " ----------------------------\n";

            for (i = 0; i < Program.ball.NumberOfTerms; i++)
            {
                corpoVetors += "[" + i + "]->|Ts:" + Program.ball.SpaceTime[i] + "|S: " + Program.ball.Space[i] + "|V:" + Program.ball.Velocity[i]
                    + "|countTime:" + Program.ball.CountTimeExperiment[i] + "\n";
            }

            for (i = 0; i < Program.ball.AnimationPixel.Length; i++)
            {
                corpoAnimationPixel += "[" + i + "]->| Ani.Pixel: " + Program.ball.AnimationPixel[i] + "\n";
            }

            if (Program.paperOn)
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
                richTextBoxPaper.Text += " ----------------------------\n";

                for (i = 0; i < Program.paper.NumberOfTerms; i++)
                {
                    paperVetors += "[" + i + "]->|Ts:" + Program.paper.SpaceTime[i] + "|S: " + Program.paper.Space[i] + "|V:" + Program.paper.Velocity[i] + "\n";
                }

                for (i = 0; i < Program.paper.AnimationPixel.Length; i++)
                {
                    paperAnimationPixel += "[" + i + "]->| Ani.Pixel: " + Program.paper.AnimationPixel[i] + "\n";
                }

            }

            if (Program.vaccumOn)
            {
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " Console View vaccum\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " finalVelocity: " + Program.vaccum.FinalVelocity + "\n";
                richTextBoxVaccum.Text += " timeAllExperiment: " + Program.vaccum.TimeAllExperiment + "\n";
                richTextBoxVaccum.Text += " numberOfTerms: " + Program.vaccum.NumberOfTerms + "\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " Calculos - Qtd Termos\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " Space: " + Program.vaccum.Space.Length + "\n";
                richTextBoxVaccum.Text += " Speed: " + Program.vaccum.Velocity.Length + "\n";
                richTextBoxVaccum.Text += " countTimeExp.: " + Program.vaccum.CountTimeExperiment.Length + "\n";
                richTextBoxVaccum.Text += " SpaceTime: " + Program.vaccum.SpaceTime.Length + "\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " Animação\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " qtdSpaceForNumberOfTermes: \n";
                richTextBoxVaccum.Text += " " + Program.vaccum.QtdSpaceForNumberOfTermes + "\n";
                richTextBoxVaccum.Text += " qtdSpaceForPixels: \n";
                richTextBoxVaccum.Text += " " + Program.vaccum.QtdSpaceForPixels + "\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " Qtd Termos\n";
                richTextBoxVaccum.Text += " ----------------------------\n";
                richTextBoxVaccum.Text += " animationPixel: " + Program.vaccum.AnimationPixel.Length + "\n";
                richTextBoxVaccum.Text += " ----------------------------\n";

                for (i = 0; i < Program.vaccum.NumberOfTerms; i++)
                {
                    vaccumVetors += "[" + i + "]->|Ts:" + Program.vaccum.SpaceTime[i] + "|S: " + Program.vaccum.Space[i] + "|V:" + Program.vaccum.Velocity[i] + "\n";
                }

                for (i = 0; i < Program.vaccum.AnimationPixel.Length; i++)
                {
                    vaccumAnimationPixel += "[" + i + "]->|Ani.Pixel: " + Program.vaccum.AnimationPixel[i] + "\n";
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

            if (Program.airResistance == 1 || Program.airResistance == 2)
            {
                table.Columns.Add("Atm. dens.", typeof(string));
            }
            table.Columns.Add("Tempo para a bóla", typeof(string));
            table.Columns.Add("Velocidade inicial da bóla", typeof(string));
            table.Columns.Add("Velocidade final da bóla", typeof(string));
            if (Program.airResistance == 1 || Program.airResistance == 2)
            {

                table.Columns.Add("Coeficiente de arrasto corpo", typeof(string));
            }

            if (Program.paperOn)
            {
                table.Columns.Add("Tempo para o papel", typeof(string));
                table.Columns.Add("Velocidade inicial do papel", typeof(string));
                table.Columns.Add("Velocidade final do papel", typeof(string));
                if (Program.airResistance == 1 || Program.airResistance == 2)
                {

                    table.Columns.Add("Coeficiente de arrasto papel", typeof(string));
                }
            }
            if (Program.vaccumOn)
            {
                table.Columns.Add("Tempo para o vácuo", typeof(string));
                table.Columns.Add("Velocidade inicial do vácuo", typeof(string));
                table.Columns.Add("Velocidade final do vácuo", typeof(string));
                if (Program.airResistance == 1 || Program.airResistance == 2)
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
            DragCoefficientBody = "" + Program.ball.DragCoefficient;
            DragCoefficientPaper = "" + Program.paper.DragCoefficient;
            DragCoefficientVaccum = "" + Program.vaccum.DragCoefficient;
            initialVelocityBody = "" + Math.Round(Program.ball.InitialVelocity, 2) + " m/s";
            finalVelocityBody = "" + Math.Round(Program.ball.FinalVelocity, 2) + " m/s";
            if (Program.airResistance == 0)
            {
                airResistence = "Não";
                experimentTimeBody = "" + Math.Round(Program.ball.TimeAllExperiment, 2) + " s";
            }
            else
            {
                airResistence = "Sim";
                experimentTimeBody = "" + Math.Round(Program.ball.TimeAllExperiment, 2) + " s";
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
