using System;
using System.Drawing;
using System.Windows.Forms;

namespace freeFall
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        public static string Key = " ";
        public static int planetCounter = 1; // define o 1 planeta
        public static string planetName = "Terra"; // label com o nome do planeta

        // controles de janelas
        public static int dataControl = 0;
        public static int configurePlanetControl = 0;
        public static int experimentDataControl = 0;
        public static int spaceGraficControl = 0;
        public static int speedGraficControl = 0;

        // controle das cores
        public static Color colorSimulator = Color.Cyan;

        // define se tera ou não resistencia do ar
        public static int airResistance = 1;

        // define se o papel esta massado ou não
        public static int crumpledPaper = 0;

        public static string experimentData = ""; // dados do experimento

        // define qual tem o maior tempo, corpo = 1, paper = 2, vaccum = 3
        public static int greatestValueTime;

        //  o maior velocidade
        public static double greatestValueVelocity;

        // define a quantidade de termos do maior entre corpo = 1, paper = 2, vaccum = 3
        public static int numberOfPoints = 0;

        // controla o momento que os graficos sao abertos
        public static int openGraficsControl = 0;

        // controla o eixo y
        public static int directionOfYaxis = 1;

        // controla a possibilidade de inverção em y
        public static int directionFlag = 0;

        // flag para elemento dentro da camara de vacuo 0 - ball 1 - paper
        public static int objectVaccum = 1;

        // 0 - ball, paper, vaccum 1 -  ball 2 -  ball, paper 3 -  ball, vaccum 
        public static int experimentFlag = 1;

        //flag para trackBar
        public static int simulatorTrackBarValueFlag = 0;

        // 0 - ball, paper, vaccum 1 -  ball 2 -  ball, paper 3 -  ball, vaccum 
        public static int numberOfPlanets = 4;

        public static Image ballImage;
        public static Image paperImage;
        public static Image vaccumImage;
        public static Image vaccumImageExperiment;
        public static Image planetImage;

        // controle de trackbars
        public static int colorTrackBar = 1;
        public static int planeTrackBar = 7;


        public static bool bodyOn = true;
        public static bool paperOn = false;
        public static bool vaccumOn = false;

        public static double finalVelocity = 0;
        public static double initialVelocity = 0;
        public static double gravity = 0;
        public static double height = 0;
        public static double timeExperiment = 0;
        public static double airDensity = 0;


        public static double[] timeTable;
        public static double[] ballSpaceTable;
        public static double[] paperSpaceTable;
        public static double[] vaccumSpaceTable;

        public static double ballFinalTime = 0.0;
        public static double paperFinalTime = 0.0;
        public static double vaccumFinalTime = 0.0;

        public static double[] ballFinalTimeSpace = new double[3];
        public static double[] paperFinalTimeSpace = new double[3];
        public static double[] vaccumFinalTimeSpace = new double[3];

        public static body ball = new body();
        public static body paper = new body();
        public static body vaccum = new body();

        public static void  makeTable()
        {

            if (greatestValueTime == 1)
            {
                timeTable = new double[ball.NumberOfTerms+4];
            }
            if (greatestValueTime == 2)
            {
                timeTable = new double[paper.NumberOfTerms+4];
            }
            if (greatestValueTime == 3)
            {
                timeTable = new double[vaccum.NumberOfTerms+4];
            }

            if(bodyOn)
            {
                ballSpaceTable = new double[ball.NumberOfTerms+4];
                ballFinalTime = ball.Space[ball.NumberOfTerms - 1];
                ballFinalTimeSpace[0] = ball.Space[ball.NumberOfTerms - 1];
                if(paperOn)
                {
                    ballFinalTimeSpace[1] = paper.spaceFunctionRV1(ballFinalTime, gravity, height);
                }
                if (vaccumOn)
                {
                    ballFinalTimeSpace[2] = 0;
                }
            }

            if(paperOn)
            {
                paperSpaceTable = new double[paper.NumberOfTerms+4];
                paperFinalTime = paper.Space[paper.NumberOfTerms - 1];
                paperFinalTimeSpace[1] = paper.Space[paper.NumberOfTerms - 1];
                if (bodyOn)
                {
                    paperFinalTimeSpace[0] = ball.spaceFunctionRV1(paperFinalTime, gravity, height);
                }
                if (vaccumOn)
                {
                    paperFinalTimeSpace[2] = 0;
                }
            }

            if(vaccumOn)
            {
                vaccumSpaceTable= new double[vaccum.NumberOfTerms+4];
                vaccumFinalTime = vaccum.Space[vaccum.NumberOfTerms - 1];
                vaccumFinalTimeSpace[2] = vaccum.Space[vaccum.NumberOfTerms - 1];
                if (paperOn)
                {
                    vaccumFinalTimeSpace[1] = paper.spaceFunctionRV1(vaccumFinalTime, gravity, height);
                }
                if (bodyOn)
                {
                    vaccumFinalTimeSpace[0] = ball.spaceFunctionRV1(vaccumFinalTime, gravity, height);
                }
            }
        }

        public static void vectorRealeing(double[] vector, double value)
        {
            int i;
            int status = 0;
            double[] auxiliary = new double[vector.Length+1];

            for (i=0; i<vector.Length; i++)
            {
                if(status == 0)
                {
                    auxiliary[i] = vector[i];
                }
                else
                {
                    auxiliary[i+1] = vector[i];
                }
                if (vector[i] < value)
                {
                    vector[i] = value;
                    status = 1;
                }
            }
        }


        public static double organizeData(string data)
        {
            int i, numberCount = 0, status = 0;
            char ax = 'A';
            string result = " ";
            double output = 0.0;
            try
            {
                for (i = 0; i < data.Length; i++)
                {
                    ax = data[i];
                    if (status == 1)
                    {
                        numberCount = numberCount + 1;
                    }
                    if (ax == ',' || ax == '.')
                    {
                        status = 1;
                    }
                    else
                    {
                        result += data[i];
                    }
                }
                if (status == 0)
                {
                    output = Convert.ToDouble(result);
                }
                else
                {
                    output = Convert.ToDouble(result);
                    output = output / (Math.Pow(10, numberCount));
                }
            }
            catch
            {
                MessageBox.Show("Erro! Caracteres proibidos ou números muito grandes!");
            }
            return output;
        }

        public static void planetNameReceveid(int numberName)
        {
            if (planetCounter == 1)
            {
                planetName = "Terra";

            }
            if (planetCounter == 2)
            {
                planetName = "Lua";
            }
            if (planetCounter == 3)
            {
                planetName = "Mercúrio";

            }
            if (planetCounter == 4)
            {
                planetName = "Vênus";

            }
            if (planetCounter == 5)
            {
                planetName = "Marte";

            }
            if (planetCounter == 6)
            {
                planetName = "Júpter";

            }
            if (planetCounter == 7)
            {
                planetName = "Saturno";

            }
            if (planetCounter == 8)
            {
                planetName = "Urano";

            }
            if (planetCounter == 9)
            {
                planetName = "Netuno";

            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitialView y = new InitialView();
            y.ShowDialog();
            y = null;
            if (Key == "open")
            {
                Simulator x = new Simulator();
                x.ShowDialog();
            }
        }
    }
}
