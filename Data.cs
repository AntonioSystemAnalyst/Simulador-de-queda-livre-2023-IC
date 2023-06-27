using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace freeFall
{
    public partial class Data : Form
    {
        DataSet ds = null;
        DataTable dt = null;

        public static int ControleMenu = 0;
        public static string planetName;
        public static int planetCounter;
        public static int planetCounterSave;
        public static string n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19;

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            pictureBoxNext.Focus();
            timerFocus.Enabled = false;
        }

        private void labelPlanet_Click(object sender, EventArgs e)
        {

        }

        private void Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.planetCounter = planetCounterSave;
            Program.planetName = planetName;
            Program.dataControl = 0;
        }

        private void richTextBoxPlanet_TextChanged(object sender, EventArgs e)
        {

        }

        public Data()
        {
            InitializeComponent();
            planetName = Program.planetName;
            planetCounter = Program.planetCounter;
            planetCounterSave = Program.planetCounter;
            timerFocus.Enabled = true;
            dataGridViewPlanets.BackgroundColor = Color.Black;
            dataGridViewPlanets.DefaultCellStyle.BackColor = Color.Black;
            dataGridViewPlanets.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            dataGridViewPlanets.DefaultCellStyle.Font = new Font(dataGridViewPlanets.DefaultCellStyle.Font.FontFamily, 12);
            dataGridViewPlanets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            colorAll();
            labelPlanet.Text = Program.planetName;
            Program.dataControl = 1;
            loadPlaentData(planetCounter);
            startGrid();
            Flip();
        }

        private void colorAll()
        {
            labelPlanet.ForeColor = Program.colorSimulator;
            richTextBoxPlanet.ForeColor = Program.colorSimulator;
            dataGridViewPlanets.GridColor = Program.colorSimulator;
            dataGridViewPlanets.DefaultCellStyle.ForeColor = Program.colorSimulator;
        }

        private void Data_Load(object sender, EventArgs e)
        {

        }
        private void loadPlaentData(int Planet)
        {
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 1)
            {
                labelPlanet.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 2)
            {
                labelPlanet.Text = "Lua";
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 3)
            {
                labelPlanet.Text = "Mercúrio";
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 4)
            {
                labelPlanet.Text = "Vênus";
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 5)
            {
                labelPlanet.Text = "Marte";
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 6)
            {
                labelPlanet.Text = "Júpter";
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 7)
            {
                labelPlanet.Text = "Saturno";
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 8)
            {
                labelPlanet.Text = "Urano";
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 9)
            {
                labelPlanet.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 0)
            {
                planetCounter = 9;
                labelPlanet.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
        }
        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            planetCounter -= 1;
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 1)
            {
                labelPlanet.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 2)
            {
                labelPlanet.Text = "Lua";
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 3)
            {
                labelPlanet.Text = "Mercúrio";
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 4)
            {
                labelPlanet.Text = "Vênus";
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 5)
            {
                labelPlanet.Text = "Marte";
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 6)
            {
                labelPlanet.Text = "Júpter";
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 7)
            {
                labelPlanet.Text = "Saturno";
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 8)
            {
                labelPlanet.Text = "Urano";
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 9)
            {
                labelPlanet.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 0)
            {
                planetCounter = 9;
                labelPlanet.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
        }

        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            planetCounter += 1;
            Program.planetNameReceveid(planetCounter);
            if (planetCounter == 1)
            {
                labelPlanet.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 2)
            {
                labelPlanet.Text = "Lua";
                pictureBoxPlanets.Image = Properties.Resources.planetMoon;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 3)
            {
                labelPlanet.Text = "Mercúrio";
                pictureBoxPlanets.Image = Properties.Resources.planetMercury;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 4)
            {
                labelPlanet.Text = "Vênus";
                pictureBoxPlanets.Image = Properties.Resources.planetVenus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 5)
            {
                labelPlanet.Text = "Marte";
                pictureBoxPlanets.Image = Properties.Resources.planetMars;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 6)
            {
                labelPlanet.Text = "Júpter";
                pictureBoxPlanets.Image = Properties.Resources.planetJupiter;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 7)
            {
                labelPlanet.Text = "Saturno";
                pictureBoxPlanets.Image = Properties.Resources.planetSaturn;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 8)
            {
                labelPlanet.Text = "Urano";
                pictureBoxPlanets.Image = Properties.Resources.planetUranus;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 9)
            {
                labelPlanet.Text = "Netuno";
                pictureBoxPlanets.Image = Properties.Resources.planetNeptune;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
            if (planetCounter == 10)
            {
                planetCounter = 1;
                labelPlanet.Text = "Terra";
                pictureBoxPlanets.Image = Properties.Resources.planetEarth;
                loadData(planetCounter);
                startGrid();
                Flip();
            }
        }
        public void startGrid()
        {
            ds = new DataSet();
            dt = new DataTable();

            dt = GetCustomers();
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
        private static DataTable GetCustomers()
        {
            DataTable table = new DataTable();
            table.TableName = "Customers";
            table.Columns.Add("hue", typeof(string));
            table.Columns.Add("Área da Superfície (km^2)", typeof(string));
            table.Columns.Add("Circunferência Equatorial (km)", typeof(string));
            table.Columns.Add("Raio Equatorial (km)", typeof(string));

            table.Columns.Add("Diâmetro (km)", typeof(string));
            table.Columns.Add("Distância Orbital Média (km)", typeof(string));
            table.Columns.Add("Volume (km^3)", typeof(string));
            table.Columns.Add("Massa (kg)", typeof(string));
            table.Columns.Add("Densidade (g/cm^3)", typeof(string));
            table.Columns.Add("Gravidade (m/s^2)", typeof(string));
            table.Columns.Add("Velocidade de Escape (km/h)", typeof(string));
            table.Columns.Add("Período de Rotação (Dias Terres.)", typeof(string));
            table.Columns.Add("Período de órbita (Anos Terres.)", typeof(string));

            table.Columns.Add("Velocidade Orbital (km/h)", typeof(string));
            table.Columns.Add("Excentricidade Orbital", typeof(string));
            table.Columns.Add("Inclinação da Órbita (°)", typeof(string));
            table.Columns.Add("Inclinação Equatorial (°)", typeof(string));

            table.Columns.Add("Temperatura da Superfície", typeof(string));
            table.Columns.Add("Quantidade de Luas", typeof(string));
            table.Columns.Add("Possui aneis", typeof(string));

            table.Rows.Add(new object[] { "hue", n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19 });

            table.AcceptChanges();

            return table;
        }
        public void loadData(int Planet)
        {
            richTextBoxPlanet.SelectionAlignment = HorizontalAlignment.Center;

            if (Planet == 1)
            {
                n1 = "510.064.472";
                n2 = "40.030,2";
                n3 = "6.371,00";
                n4 = "12.742";
                n5 = "149.598.262";
                n6 = "1.083.206.916.846 ";
                n7 = "5,9722 x 10^24";
                n8 = "5.513";
                n9 = "9,80665";
                n10 = "40.284";
                n11 = "1";
                n12 = "1";
                n13 = "107.218";
                n14 = "0,01671123";
                n15 = "0,00005 graus";
                n16 = "23,4393 graus";
                n17 = "-88 / 58 °C";
                n18 = "1";
                n19 = "não";
                richTextBoxPlanet.Text = " O nosso planeta, onde habitamos, possui características especiais que nos permitem viver. Isso se deve à presença da atmosfera, uma camada que nos protege da intensa radiação solar, possibilitando a existência de vida. Além disso, a localização da Terra na chamada zona habitável é um fator relevante. Até o momento, é o único lugar conhecido a abrigar seres vivos. A Terra é o maior dos quatro planetas rochosos localizados mais próximos do Sol, dentro do Cinturão de Asteroides. Seu nome, \"Terra\", deriva de uma palavra germânica que significa \"o solo\".";
            }

            if (Planet == 2)
            {
                n1 = "37.936.694,79";
                n2 = "10.917,0";
                n3 = "1737,5";
                n4 = "3.474,2";
                n5 = "384.400 ";
                n6 = "21.971.669.064 ";
                n7 = "7,3477 x 10^22 ";
                n8 = "3,344";
                n9 = "1,624";
                n10 = "8.552";
                n11 = "27,322";
                n12 = "29,5";
                n13 = "3.680,5";
                n14 = "0,0554";
                n15 = "5,2 graus";
                n16 = "6,68 graus";
                n17 = "-184 / 214 °C";
                n18 = "0";
                n19 = "não";
                richTextBoxPlanet.Text = " A Lua é o único satélite natural da Terra e a quinta maior lua do sistema solar. Sua superfície é bastante irregular, repleta de formações rochosas, e não possui gases nem recursos hídricos significativos. Como não é uma estrela, a Lua não emite luz própria. No entanto, podemos vê-la iluminada porque ela reflete a luz solar. A presença da Lua desempenha um papel importante na estabilização das oscilações do nosso planeta, o que contribui para a estabilidade do nosso clima.";
            }

            if (Planet == 3)
            {
                n1 = "74.797.000";
                n2 = "15.329,1";
                n3 = "2.439,7";
                n4 = "4.879,4";
                n5 = "57.909.227";
                n6 = "60.827.208.742 ";
                n7 = "3,3010 x 10^23 ";
                n8 = "5,427";
                n9 = "3,7";
                n10 = "15.300";
                n11 = "58,646";
                n12 = "0,2408467";
                n13 = "170.503";
                n14 = "0,20563593";
                n15 = "7 graus";
                n16 = "0 graus";
                n17 = "-173 / 427 °C ";
                n18 = "0";
                n19 = "não";
                richTextBoxPlanet.Text = " O menor planeta do Sistema Solar, bem como o mais próximo do sol, é caracterizado pela falta de estações do ano devido ao seu eixo perpendicular ao plano da órbita. Além disso, alguns locais nesse planeta não recebem a luz solar. Sua atmosfera fina é composta principalmente por átomos de árgon, néon e hélio. A superfície do planeta é relativamente semelhante à da Lua, com a presença de grandes crateras resultantes do impacto de meteoritos.";
            }

            if (Planet == 4)
            {
                n1 = "460.234.317";
                n2 = "38.024,6";
                n3 = "6.051,8";
                n4 = "12.104";
                n5 = "108.209.475";
                n6 = "928.415.345.893";
                n7 = "4,8673 x 10^24";
                n8 = "5,243";
                n9 = "8,87";
                n10 = "37.296";
                n11 = "-243,018";
                n12 = "0,61519726";
                n13 = "126.074";
                n14 = "0,00677672";
                n15 = "3,39 graus";
                n16 = "177,3 graus (R.T.) ";
                n17 = "462 °C";
                n18 = "0";
                n19 = "não";
                richTextBoxPlanet.Text = " Vênus é o segundo planeta do Sistema Solar, conhecido por ser o mais quente. Sua atmosfera é densa e tóxica, composta principalmente de dióxido de carbono, criando nuvens espessas de ácido sulfúrico que retêm o calor, resultando em um efeito estufa descontrolado. É possível observar Vênus a olho nu, pois o planeta emite uma intensa luminosidade, sendo superado apenas pela lua nesse aspecto.";
            }

            if (Planet == 5)
            {
                n1 = "144.371.391";
                n2 = "21.296,9";
                n3 = "3.389,5";
                n4 = "6.779";
                n5 = "227.943.824";
                n6 = "163.115.609.799 ";
                n7 = "6,4169 x 10^23 ";
                n8 = "3.934";
                n9 = "3,71";
                n10 = "18.108";
                n11 = "1.026";
                n12 = "1.8808476";
                n13 = "86.677";
                n14 = "0,0933941";
                n15 = "1,85 graus";
                n16 = "25,2 garus";
                n17 = "-153 / 20 °C";
                n18 = "2";
                n19 = "não";
                richTextBoxPlanet.Text = " Marte, o quarto planeta a partir do Sol, é conhecido como o \"Planeta Vermelho\" devido à predominância de óxido de ferro em sua superfície, conferindo-lhe uma aparência avermelhada. Devido às suas baixas temperaturas, não há possibilidade de existir água em estado líquido em sua superfície. Sua atmosfera é extremamente rarefeita e composta por gases como dióxido de carbono, gás carbônico, nitrogênio, argônio, néon e oxigênio.";
            }

            if (Planet == 6)
            {
                n1 = "61.418.738.571";
                n2 = "439.263,8";
                n3 = "69.911";
                n4 = "139.820";
                n5 = "778.340.821";
                n6 = "1.431.281.810.739.360 ";
                n7 = "1.8981 x 10^27 ";
                n8 = "1.326";
                n9 = "24,79";
                n10 = "216.720";
                n11 = "0,41354";
                n12 = "11,862615";
                n13 = "47.002";
                n14 = "0,04838624";
                n15 = "1,304 graus";
                n16 = "3,1 graus";
                n17 = "-110 °C";
                n18 = "79";
                n19 = "sim";
                richTextBoxPlanet.Text = " Júpiter, o quinto planeta a partir do Sol, é o maior planeta gasoso do Sistema Solar. Sua atmosfera é composta principalmente de hidrogênio e hélio. Uma das características distintas de Júpiter é a presença da Grande Mancha Vermelha, uma tempestade anticiclônica que é maior que o próprio planeta Terra.";
            }

            if (Planet == 7)
            {
                n1 = "42.612.133.285";
                n2 = "365.882,4";
                n3 = "58.232";
                n4 = "116.460";
                n5 = "1.426.666.422";
                n6 = "827.129.915.150.897 ";
                n7 = "5,6832 x 10^26 ";
                n8 = "0,687";
                n9 = "10,4";
                n10 = "129.924";
                n11 = "0,444";
                n12 = "29,447498";
                n13 = "34.701";
                n14 = "0,05386179";
                n15 = "2,49 graus";
                n16 = "26,7 graus";
                n17 = "-125 °C";
                n18 = "83";
                n19 = "sim";
                richTextBoxPlanet.Text = " Saturno é amplamente reconhecido por seus impressionantes anéis que o envolvem, compostos provavelmente por partículas provenientes de luas do planeta que foram impactadas e destruídas por asteroides. Trata-se do segundo maior planeta do nosso Sistema Solar e é classificado como um planeta gasoso, composto principalmente de hidrogênio. Saturno possui uma característica peculiar, sendo menos denso que a água. Em outras palavras, se fosse possível colocá-lo em uma bacia d'água, ele flutuaria.";
            }

            if (Planet == 8)
            {
                n1 = "8.083.079.690";
                n2 = "159.354,1";
                n3 = "25.362";
                n4 = "50.724";
                n5 = "2.870.658.186";
                n6 = "68.334.355.695.584 ";
                n7 = "8,6810 x 10^25 ";
                n8 = "1.270";
                n9 = "8,87";
                n10 = "76.968";
                n11 = "-0,718";
                n12 = "84.016846";
                n13 = "24.477";
                n14 = "0,04725744";
                n15 = "0,77 graus";
                n16 = "97,8 graus (R.T.)";
                n17 = "-197 °C";
                n18 = "27";
                n19 = "sim";
                richTextBoxPlanet.Text = " Urano, um planeta que ainda é pouco explorado, apresenta desafios devido à sua distância e dificuldades técnicas para a exploração de sua superfície, uma vez que é composta principalmente por gases, especialmente hidrogênio e hélio. Ele possui um total de 13 anéis, que não são visíveis a olho nu. Em relação ao movimento, uma peculiaridade de Urano é que o Sol nasce no oeste e se põe no leste, ao contrário dos outros planetas do Sistema Solar.";
            }

            if (Planet == 9)
            {
                n1 = "7.618.272.763";
                n2 = "154.704,6";
                n3 = "24.622";
                n4 = "49.224";
                n5 = "4.498.396.441";
                n6 = "62.525.703.987.421 ";
                n7 = "1.0241 x 10^26 ";
                n8 = "1.638";
                n9 = "11,15";
                n10 = "84.816";
                n11 = "0,671";
                n12 = "164,79132";
                n13 = "19.566";
                n14 = "0,00859048";
                n15 = "1,77 graus";
                n16 = "28,3 graus";
                n17 = "-223,15 °C";
                n18 = "14";
                n19 = "sim";
                richTextBoxPlanet.Text = " Netuno, o oitavo e mais distante planeta do nosso Sistema Solar, é o único que não pode ser visto a olho nu e foi o primeiro planeta a ser previsto matematicamente antes de sua descoberta. Em Netuno, ocorrem ventos extremamente fortes que podem atingir velocidades de aproximadamente 2.000 quilômetros por hora, devido à sua natureza como um planeta gasoso. Sua atmosfera é composta principalmente de hidrogênio e hélio, além de conter vestígios de metano e hidrocarbonetos em sua composição química.";
            }

        }
    }
}
