using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        // define se tera ou não resistencia do ar
        public static int airResistanceFlag = 1;

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

        public static Image experimentDataCorpoImage;
        public static Image experimentDataPaperImage;
        public static Image experimentDataVaccumImage;
        public static Image experimentPlanetVaccumImage;


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

        public static double[] ballVelocityTable;
        public static double[] paperVelocityTable;
        public static double[] vaccumVelocityTable;

        public static int timeTableIndex;
        public static int ballSpaceTableIndex;
        public static int paperSpaceTableIndex;
        public static int vaccumSpaceTableIndex;

        public static double ballFinalTime = 0.0;
        public static double paperFinalTime = 0.0;
        public static double vaccumFinalTime = 0.0;

        public static double []ballFinalEndTime;
        public static double []paperFinalEndTime;
        public static double []vaccumFinalEndTime;

        public static double[] ballFinalSpace = new double[3];
        public static double[] paperFinalSpace = new double[3];
        public static double[] vaccumFinalSpace = new double[3];
        public static int numberOfTermsTable = 0;

        public static body ball = new body();
        public static body paper = new body();
        public static body vaccum = new body();

        public static void loadExperimentData()
        {
            experimentDataCorpoImage = ballImage;
            experimentDataPaperImage = paperImage;
            experimentDataVaccumImage = vaccumImage;
            experimentPlanetVaccumImage = planetImage;
        }
        public static void makeTableOutResistence()
        {
            int i = 0;

            numberOfTermsTable = ball.NumberOfTerms + 2;
            ballSpaceTable = new double[ball.NumberOfTerms + 2];
            paperSpaceTable = new double[ball.NumberOfTerms + 2];
            vaccumSpaceTable = new double[ball.NumberOfTerms + 2];
            timeTable = new double[ball.NumberOfTerms + 2];
            ballVelocityTable = new double[ball.NumberOfTerms + 2];
            paperVelocityTable = new double[paper.NumberOfTerms + 2];
            vaccumVelocityTable = new double[vaccum.NumberOfTerms + 2];

            ballFinalEndTime = new double[ball.NumberOfTerms + 2];
            paperFinalEndTime = new double[paper.NumberOfTerms + 2];
            vaccumFinalEndTime = new double[vaccum.NumberOfTerms + 2];

            cleanTables();

            for (i = 0; i < numberOfTermsTable - 2; i++)
            {
                timeTable[i] = ball.CountTimeExperiment[i];
                ballSpaceTable[i] = ball.Space[i];
                if (paperOn)
                {
                    paperSpaceTable[i] = paper.Space[i];
                }
                if (vaccumOn)
                {
                    vaccumSpaceTable[i] = vaccum.Space[i];
                }
            }

            ballSpaceTableIndex = vectorOneZero(ballSpaceTable);
            paperSpaceTableIndex = vectorOneZero(paperSpaceTable);
            vaccumSpaceTableIndex = vectorOneZero(vaccumSpaceTable);
            timeTableIndex = vectorOneZero(timeTable);
            timeTableIndex = timeTableIndex - 1;

            for (i = 0; i < timeTable.Length-1; i++)
            {
                if (bodyOn && ballVelocityTable.Length > i)
                {
                    ballVelocityTable[i] = ball.velocityFunctionRV(0, gravity, timeTable[i]);
                    ballFinalEndTime[i] = timeTable[i];
                }
                if (paperOn && paperVelocityTable.Length > i)
                {
                    paperVelocityTable[i] = paper.velocityFunctionRV(0, gravity, timeTable[i]);
                    paperFinalEndTime[i] = timeTable[i];
                }
                if (vaccumOn && vaccumVelocityTable.Length > i)
                {
                    vaccumVelocityTable[i] = vaccum.velocityFunctionRV(0, gravity, timeTable[i]);
                    vaccumFinalEndTime[i] = timeTable[i];
                }
            }

            if(bodyOn)
            {
                ball.animationVector(534, height, ball.NumberOfTerms + 2, ballSpaceTable);
            }
            if(paperOn)
            {
                paper.animationVector(534, height, paper.NumberOfTerms + 2, paperSpaceTable);
            }
            if(vaccumOn)
            {
                vaccum.animationVector(534, height, vaccum.NumberOfTerms + 2, vaccumSpaceTable);
            }

        }
        public static void makeTableWihtResistence()
        {
            int i = 0;

            ballSpaceTable = new double[ball.NumberOfTerms + 4];
            paperSpaceTable = new double[paper.NumberOfTerms + 4];
            vaccumSpaceTable = new double[vaccum.NumberOfTerms + 4];
            ballVelocityTable = new double[ball.NumberOfTerms + 4];
            paperVelocityTable = new double[paper.NumberOfTerms + 4];
            vaccumVelocityTable = new double[vaccum.NumberOfTerms + 4];

            ballFinalEndTime = new double[ball.NumberOfTerms + 4];
            paperFinalEndTime = new double[paper.NumberOfTerms + 4];
            vaccumFinalEndTime = new double[vaccum.NumberOfTerms + 4];


            if (greatestValueTime == 0)
            {
                numberOfTermsTable = ball.NumberOfTerms + 4;
                timeTable = new double[numberOfTermsTable];
                cleanTables();
                for (i = 0; i < ball.NumberOfTerms; i++)
                {
                    timeTable[i] = ball.CountTimeExperiment[i];
                }
            }
            if (greatestValueTime == 1)
            {
                numberOfTermsTable = ball.NumberOfTerms + 4;
                timeTable = new double[numberOfTermsTable];
                cleanTables();
                for (i = 0; i < ball.NumberOfTerms; i++)
                {
                    timeTable[i] = ball.CountTimeExperiment[i];
                }
            }
            if (greatestValueTime == 2)
            {
                numberOfTermsTable = paper.NumberOfTerms + 4;
                timeTable = new double[numberOfTermsTable];
                cleanTables();
                for (i = 0; i < paper.NumberOfTerms; i++)
                {
                    timeTable[i] = paper.CountTimeExperiment[i];
                }
            }
            if (greatestValueTime == 3)
            {
                numberOfTermsTable = vaccum.NumberOfTerms + 4;
                timeTable = new double[numberOfTermsTable];
                cleanTables();
                for (i = 0; i < vaccum.NumberOfTerms; i++)
                {
                    timeTable[i] = vaccum.CountTimeExperiment[i];
                }
            }

            if (bodyOn)
            {
                for (i = 0; i < ball.NumberOfTerms; i++)
                {
                    ballSpaceTable[i] = ball.Space[i];
                }
                ballFinalTime = ball.CountTimeExperiment[ball.NumberOfTerms - 1];
                ballFinalSpace[0] = ball.Space[ball.NumberOfTerms - 1];
                if (paperOn)
                {
                    ballFinalSpace[1] = height - paper.spaceFunctionRV1(ballFinalTime, gravity, height);
                }
                if (vaccumOn)
                {
                    ballFinalSpace[2] = vaccum.spaceFunction(ballFinalTime, 0, gravity, height);
                }
            }
            if (paperOn)
            {
                for (i = 0; i < paper.NumberOfTerms; i++)
                {
                    paperSpaceTable[i] = paper.Space[i];
                }
                paperFinalTime = paper.CountTimeExperiment[paper.NumberOfTerms - 1];
                paperFinalSpace[1] = paper.Space[paper.NumberOfTerms - 1];
                if (bodyOn)
                {
                    paperFinalSpace[0] = height - ball.spaceFunctionRV1(paperFinalTime, gravity, height);
                }
                if (vaccumOn)
                {
                    paperFinalSpace[2] = vaccum.spaceFunction(ballFinalTime, 0, gravity, height);
                }
            }
            if (vaccumOn)
            {
                for (i = 0; i < vaccum.NumberOfTerms; i++)
                {
                    vaccumSpaceTable[i] = vaccum.Space[i];
                }
                vaccumFinalTime = vaccum.CountTimeExperiment[vaccum.NumberOfTerms - 1];
                vaccumFinalSpace[2] = vaccum.Space[vaccum.NumberOfTerms - 1];
                if (paperOn)
                {
                    vaccumFinalSpace[1] = height - paper.spaceFunctionRV1(vaccumFinalTime, gravity, height);
                }
                if (bodyOn)
                {
                    vaccumFinalSpace[0] = height - ball.spaceFunctionRV1(vaccumFinalTime, gravity, height);
                }
            }
            if (vaccumOn)
            {
                vectorRealeingAddPoint(timeTable, vaccumFinalTime);

                if (bodyOn)
                {
                    vectorRealeing(ballSpaceTable, vaccumFinalSpace[0]);
                }
                if (paperOn)
                {
                    vectorRealeing(paperSpaceTable, vaccumFinalSpace[1]);
                }
            }
            if (paperOn)
            {
                vectorRealeingAddPoint(timeTable, paperFinalTime);

                if (bodyOn)
                {
                    vectorRealeing(ballSpaceTable, paperFinalSpace[0]);
                }
                if (vaccumOn)
                {
                    vectorRealeing(vaccumSpaceTable, paperFinalSpace[2]);
                }
            }
            if (bodyOn)
            {
                vectorRealeingAddPoint(timeTable, ballFinalTime);

                if (paperOn)
                {
                    vectorRealeing(paperSpaceTable, ballFinalSpace[1]);

                }
                if (vaccumOn)
                {
                    vectorRealeing(vaccumSpaceTable, ballFinalSpace[2]);
                }
            }

            ballSpaceTableIndex = vectorOneZero(ballSpaceTable);
            paperSpaceTableIndex = vectorOneZero(paperSpaceTable);
            vaccumSpaceTableIndex = vectorOneZero(vaccumSpaceTable);
            timeTableIndex = vectorOneZero(timeTable);
            timeTableIndex = timeTableIndex - 1;

            for (i = 0; i < timeTable.Length-2; i++)
            {
                if (bodyOn && ballVelocityTable.Length > i)
                {
                    ballVelocityTable[i] = ball.velocityFunctionRV1(timeTable[i], 1, gravity);
                    ballFinalEndTime[i] = timeTable[i];
                }
                if (paperOn && paperVelocityTable.Length > i)
                {
                    paperVelocityTable[i] = paper.velocityFunctionRV1(timeTable[i], 1, gravity);
                    paperFinalEndTime[i] = timeTable[i];
                }
                if (vaccumOn && vaccumVelocityTable.Length > i)
                {
                    vaccumVelocityTable[i] = vaccum.velocityFunctionRV(0, gravity, timeTable[i]);
                    vaccumFinalEndTime[i] = timeTable[i];
                }
            }

            if (bodyOn)
            {
                ball.animationVector(534, height, ball.NumberOfTerms + 2, ballSpaceTable);
                ball.PaperPixels = new int[ball.NumberOfTerms + 4];
                ball.animationPaper(ball.NumberOfTerms + 4, airDensity);
            }
            if (paperOn)
            {
                paper.animationVector(534, height, paper.NumberOfTerms + 2, paperSpaceTable);
                paper.PaperPixels = new int[paper.NumberOfTerms + 4];
                paper.animationPaper(paper.NumberOfTerms + 4, airDensity);
            }
            if (vaccumOn)
            {
                vaccum.animationVector(534, height, vaccum.NumberOfTerms + 2, vaccumSpaceTable);
            }
        }

        public static void cleanTables()
        {
            int i = 0;

            timeTableIndex = 0;
            ballSpaceTableIndex = 0;
            paperSpaceTableIndex = 0;
            vaccumSpaceTableIndex = 0;

            ballFinalTime = 0.0;
            paperFinalTime = 0.0;
            vaccumFinalTime = 0.0;

            for (i = 0; i < 3; i++)
            {
                ballFinalSpace[i] = 0;
                paperFinalSpace[i] = 0;
                vaccumFinalSpace[i] = 0;
            }

            for (i = 0; i < timeTable.Length; i++)
            {
                timeTable[i] = 0;
                if (ballSpaceTable.Length > i)
                {
                    ballSpaceTable[i] = 0;
                }
                if (paperSpaceTable.Length > i)
                {
                    paperSpaceTable[i] = 0;
                }
                if (vaccumSpaceTable.Length > i)
                {
                    vaccumSpaceTable[i] = 0;
                }
            }
        }
        public static int vectorOneZero(double[] vector)
        {
            int i;
            int status = 0;
            int index = 0;
            for (i = 0; i < vector.Length; i++)
            {
                if (Math.Round(vector[i], 4) == 0 && status == 0)
                {
                    index = i + 1;
                    status = 1;
                }
            }
            return index;
        }

        public static void vectorRealeingAddPoint(double[] vector, double value)
        {
            int i;
            int status = 0;
            double[] auxiliary = new double[1];
            auxiliary = new double[vector.Length];

            for (i = 0; i < vector.Length; i++)
            {
                auxiliary[i] = vector[i];
            }
            for (i = 0; i < vector.Length; i++)
            {
                if (status == 0)
                {
                    vector[i] = auxiliary[i];
                }
                else
                {
                    if ((i + 1) < vector.Length)
                    {
                        vector[i + 1] = auxiliary[i];
                    }
                }
                if ((value < auxiliary[i]) && status == 0)
                {
                    vector[i] = value;
                    vector[i + 1] = auxiliary[i];
                    status = 1;
                }
            }
        }
        public static void vectorRealeing(double[] vector, double value)
        {
            int i;
            int status = 0;

            double[] auxiliary = new double[vector.Length];

            for (i = 0; i < vector.Length; i++)
            {
                auxiliary[i] = vector[i];
            }
            for (i = 0; i < vector.Length; i++)
            {
                if (status == 0)
                {
                    vector[i] = auxiliary[i];
                }
                else
                {
                    if ((i + 1) < vector.Length)
                    {
                        vector[i + 1] = auxiliary[i];
                    }
                }
                if ((value > auxiliary[i]) && status == 0)
                {
                    vector[i] = value;
                    vector[i + 1] = auxiliary[i];
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
