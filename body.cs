using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace freeFall
{
    internal class body
    {
        private double finalVelocity = 0.0;
        private double initialVelocity = 0.0;
        private double timeAllExperiment = 0.0;
        private double dragCoefficient = 0.0;
        private double terminalVelocity = 0.0;
        private int numberOfTerms = 0;
        private int mass = 0;

        // --- Para testes
        private double EspacoVelicidadeLimite = 0.0;
        private double TempoLimiteChao        = 0.0;
        // --- Antimation
        double qtdSpaceForNumberOfTermes;
        double qtdSpaceForPixels;


        private double[] spaceTime;
        private double[] spacePixel;
        private double[] space;
        private double[] velocity;
        private double[] animationSpace;
        private double[] countTimeExperiment;
        private double[] animationPixel;
        private int[] pixels;
        public static double Round(double value, int decimalPlaces)
        {
            double factor = (double)Math.Pow(10, decimalPlaces);
            double roundedValue = Math.Round(value * factor) / factor;
            return roundedValue;
        }
        public void animationVector(int quantityPixel, double height)
        {
            qtdSpaceForNumberOfTermes = height / numberOfTerms;  // altura pelo numero de termos 
            qtdSpaceForPixels = height / quantityPixel; // altura pela quatidade de pixels
            double countSpace = 0.0; // auxilar
            int i = 0, k = 0; // para loops
            int status = 0; // para acionar o for uma unica vez

            animationPixel = new double[quantityPixel + 2]; // para receber o espaço referente ao pixel
            animationSpace = new double[numberOfTerms + 2]; // para receber o espaço referente ao numero de termos
            pixels = new int[numberOfTerms + 2]; // para receber o pixel que deve estar a cada unidade de tempo 

            //Console.WriteLine("-----------------------");
            for (i = 0; i < numberOfTerms; i++)  // passa o valor de unidade inteirando para o vetor animationSpace
            {
                animationSpace[i] = countSpace;
                countSpace = countSpace + qtdSpaceForNumberOfTermes;
                //Console.WriteLine("Space = " + countSpace);
            }
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("pixels");
            //Console.WriteLine("-----------------------");
            countSpace = 0.0;
            for (i = 0; i < quantityPixel + 1; i++) // passa o valor de unidade inteirando para o vetor animationPixel
            {
                animationPixel[i] = countSpace;
                countSpace = countSpace + qtdSpaceForPixels;
                //Console.WriteLine("Pixel = " + countSpace);
            }
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("aqui");
            //Console.WriteLine("-----------------------");
            for (i = 0; i < numberOfTerms + 1; i++) // compara o espaço animationPixel e animationSpace, e passa o indice do animationPixel com valor do pixel
            {
                status = 0;
                for (k = 0; k < quantityPixel; k++)
                {
                    if (animationPixel[k] >= animationSpace[i] && status == 0)
                    {
                        pixels[i] = k;
                        status = 1;
                        //Console.WriteLine("Pixel = " + pixels[i] + "-" + i );
                    }
                }
            }
            pixels[numberOfTerms] = quantityPixel; // garante que o ultimo pixel é igual ao ultimo valor setado 
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("height = "+height);
        }
        public void CalculateOutResistence(double height, double gravity, double initialVelocity)
        {
            double countTime = 0;
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * height));
            timeAllExperiment = Round((finalVelocity - initialVelocity) / gravity, 3);
            numberOfTerms = Convert.ToInt32(timeAllExperiment / 0.01);

            space    = new double[numberOfTerms + 2];
            velocity = new double[numberOfTerms + 2];
            countTimeExperiment = new double[numberOfTerms + 2];

            spaceTime = new double[numberOfTerms + 2];
            spacePixel = new double[Convert.ToInt32(534)];

            // Espaço 
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                space[i] = ((initialVelocity * countTime) + (gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            countTime = 0;

            // Velocidade
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                velocity[i] = (initialVelocity + (gravity * countTime));
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }

            animationVector(534, height);

        }

        public void CalculateWithResistence(double height, double gravity, double initialVelocity)
        {
            double countTime = 0;
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * height));
            timeAllExperiment = timeAllExperiment + Round((finalVelocity - initialVelocity) / gravity, 3);
            numberOfTerms = Convert.ToInt32(timeAllExperiment / 0.01);
            numberOfTerms += 150;

            space = new double[numberOfTerms + 2];
            velocity = new double[numberOfTerms + 2];
            countTimeExperiment = new double[numberOfTerms + 2];

            spaceTime = new double[numberOfTerms + 2];
            spacePixel = new double[Convert.ToInt32(534)];

            // Espaço 
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                space[i] = ((initialVelocity * countTime) + (gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            countTime = 0;

            // Velocidade
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                velocity[i] = (initialVelocity + (gravity * countTime));
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }

            animationVector(534, height);
        }

        public void CalculateWithResistenceVersao2(double height, double gravity, double initialVelocity)
        {
            int i = 0;
            double countTime = 0;
            double term1;
            double term2;
            double term3;

            // para testes
            double Ter1 = 0;
            double Ter2 = 0;
            double Ter3 = 0;

            //Velocidade limite
            Ter1 = (height * dragCoefficient) / mass;
            Ter2 = Math.Sqrt(mass / (gravity * dragCoefficient));
            Ter3 = 0.693147 + Ter1; //  ln(2)
            timeAllExperiment = Ter1 * Ter3;

            // velocidade limite:
            terminalVelocity = Math.Sqrt((2 * mass * gravity) / dragCoefficient * Program.crossSectionalArea * Program.airDensity);

            //Espaço onde o movimento é mudado
            EspacoVelicidadeLimite = ((terminalVelocity * terminalVelocity) - (initialVelocity * initialVelocity) / (2 * gravity));
            //tempo do espaço limite ao chao
            TempoLimiteChao = EspacoVelicidadeLimite * terminalVelocity;

            //timeAllExperiment = Round((finalVelocity - initialVelocity) / gravity, 3);
            numberOfTerms = Convert.ToInt32(timeAllExperiment / 0.01);

            space = new double[numberOfTerms + 200];
            velocity = new double[numberOfTerms + 200];

            // Espaço 
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                term1 = (gravity * dragCoefficient) / mass;
                term3 = Math.Cosh((countTime * (Math.Sqrt(term1))));
                Space[i] = (mass / dragCoefficient) * Math.Log(term3);
                countTime = countTime + 0.01;
            }
            countTime = 0;
            // Velocidade
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                term1 = Math.Sqrt((mass * gravity) / dragCoefficient);
                term2 = (gravity * dragCoefficient) / gravity;
                term3 = (countTime * (Math.Sqrt(term2)));
                Velocity[i] = term1 * Math.Tanh(term3);
                countTime = countTime + 0.01;
            }

            animationVector(534, height);
        }

        public void CalculateWithResistenceVersao1(double height, double gravity, double initialVelocity)
        {
            double QtdTempox = Program.timeExperiment / (0.01);
            double QtdSpace = Program.height / 534;
            int timeExperiment = Convert.ToInt32(QtdTempox);
            int i = 0;
            double countTime = 0;
            double term1;
            double term2;
            double term3;
            double term4;
            double velocityPoint;

            space = new double[timeExperiment + 2];
            velocity = new double[timeExperiment + 2];

            timeAllExperiment = Round((finalVelocity - initialVelocity) / gravity, 3);
            numberOfTerms = Convert.ToInt32(timeAllExperiment / 0.01);

            // Velocidade
            for (i = 0; i < numberOfTerms + 1; i++)
            {
                term1 = Math.Sqrt(Program.gravity / (dragCoefficient * Program.airDensity * Program.crossSectionalArea));
                term2 = -1 * (Math.Sqrt((dragCoefficient * Program.airDensity * Program.crossSectionalArea) * Program.gravity) * countTime);
                term3 = Math.Pow(2.71828, term2);
                term4 = ((1 + term3) / (1 - term3));
                velocityPoint = term1 * term4;

                velocity[i] = velocityPoint;
                countTime = countTime + 0.01;
            }
            countTime = 0;
        }

        public double CalculateIntegral(double[] valueX, double[] valueY, double[] valueYZ)
        {
            double integral = 0;
            int l = 5;
            int n = l - 1;

            if (n % 2 != 0)
            {
                n--; // Make sure we have an even number of intervals for Simpson's 1/3 rule
            }

            double h = (valueX[n] - valueY[0]) / n;

            for (int i = 1; i < n; i += 2)
            {
                integral += (h / 3) * (valueYZ[i - 1] + 4 * valueYZ[i] + valueYZ[i + 1]);
            }
            return integral;
        }

        public double QtdSpaceForNumberOfTermes
        {
            get { return qtdSpaceForNumberOfTermes; }
            set { qtdSpaceForNumberOfTermes = value; }
        }
        public double QtdSpaceForPixels
        {
            get { return qtdSpaceForPixels; }
            set { qtdSpaceForPixels = value; }
        }
        public double DragCoefficient
        {
            get { return dragCoefficient; }
            set { dragCoefficient = value; }
        }

        public int Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        public int[] Pixels
        {
            get { return pixels; }
            set { pixels = value; }
        }
        public double[] AnimationPixel
        {
            get { return animationPixel; }
            set { animationPixel = value; }
        }

        public int NumberOfTerms
        {
            get { return numberOfTerms; }
            set { numberOfTerms = value; }
        }
        public double[] CountTimeExperiment
        {
            get { return countTimeExperiment; }
            set { countTimeExperiment = value; }
        }

        public double FinalVelocity
        {
            get { return finalVelocity; }
            set { finalVelocity = value; }
        }

        public double InitialVelocity
        {
            get { return initialVelocity; }
            set { initialVelocity = value; }
        }

        public double TimeAllExperiment
        {
            get { return timeAllExperiment; }
            set { timeAllExperiment = value; }
        }

        public double[] SpaceTime
        {
            get { return spaceTime; }
            set { spaceTime = value; }
        }

        public double[] SpacePixel
        {
            get { return spacePixel; }
            set { spacePixel = value; }
        }

        public double[] Space
        {
            get { return space; }
            set { space = value; }
        }

        public double[] Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        
        public double[] AnimationSpace
        {
            get { return animationSpace; }
            set { animationSpace = value; }
        }

    }
}

