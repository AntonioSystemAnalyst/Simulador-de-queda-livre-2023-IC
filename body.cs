using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private double mass = 0.0;
        public static double crossSectionalArea = 0;
        private int numberOfTerms = 0;
        

        // --- Para testes
        private double EspacoVelicidadeLimite = 0.0;
        private double TempoLimiteChao = 0.0;
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
            for (i = 0; i <= quantityPixel; i++) // passa o valor de unidade inteirando para o vetor animationPixel
            {
                animationPixel[i] = countSpace;
                countSpace = countSpace + qtdSpaceForPixels;
                //Console.WriteLine("Pixel = " + countSpace);
            }
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("aqui");
            //Console.WriteLine("-----------------------");
            for (i = 0; i < numberOfTerms; i++) // compara o espaço animationPixel e animationSpace, e passa o indice do animationPixel com valor do pixel
            {
                status = 0;
                for (k = 0; k <= quantityPixel; k++)
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

            for (i = 0; i < numberOfTerms; i++)
            {
                //Console.WriteLine("->" + i + "Pixel = " + pixels[i] + "-" + i);
            }

            //Console.WriteLine("-----------------------");
            //Console.WriteLine("-----------------------");
            //Console.WriteLine("height = "+height);
        }
        public void CalculateOutResistence(double height, double gravity, double initialVelocity)
        {
            double countTime = 0;
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * height));
            timeAllExperiment = Math.Round((finalVelocity - initialVelocity) / gravity, 3);
            //numberOfTerms = Convert.ToInt32(timeAllExperiment / 0.01);

            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01) + 1;

            space = new double[numberOfTerms + 2];
            velocity = new double[numberOfTerms + 2];
            countTimeExperiment = new double[numberOfTerms + 2];

            spaceTime = new double[numberOfTerms + 2];
            spacePixel = new double[Convert.ToInt32(534)];

            // Espaço 
            for (i = 0; i < numberOfTerms; i++)
            {
                space[i] = ((initialVelocity * countTime) + (gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            countTime = 0;

            // Velocidade
            for (i = 0; i < numberOfTerms; i++)
            {
                velocity[i] = (initialVelocity + (gravity * countTime));
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }

            animationVector(534, height);

        }

        public void CalculateWithResistence(double height, double gravity, double initialVelocity)
        {

            double countTime = 0.01;
            double term0, term1, term2, term3, term4;
            double velocityPoint;
            int i;

            space = new double[1000];
            velocity = new double[1000];

            terminalVelocity = Math.Sqrt((2 * mass * gravity) / dragCoefficient * crossSectionalArea * Program.airDensity);

            velocity[0] = 0.0;
            space[0] = 0.0 ;
            numberOfTerms = 1;
            countTime = 0.0;

            term0 = mass / (0.5 * dragCoefficient * Program.airDensity * crossSectionalArea);
            term1 = Math.Sqrt(Program.gravity / term0);

            do
            {
                term2 = -1 * (Math.Sqrt(term0 * Program.gravity) * countTime);
                term3 = Math.Pow(2.71828, term2);
                term4 = ((1 + term3) / (1 - term3));
                velocityPoint = term1 * term4;
                //velocity[i] = (-1 * terminalVelocity) + velocityPoint;
                velocity[numberOfTerms] = velocityPoint;
                space[numberOfTerms] = SimpsonIntegrationMethod(countTime, (countTime + 0.01), 4);
                countTime = countTime + 0.01;
                numberOfTerms += 1;
            } while (space[numberOfTerms - 1] >= height);
            //numberOfTerms -= 1;

            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }

            animationVector(534, height);

        }

        public double Function(double countTime)
        {
            double term0, term1, term2, term3, term4;

            double velocityPoint;
            term0 = mass / (0.5 * dragCoefficient * Program.airDensity * crossSectionalArea);
            term1 = Math.Sqrt(Program.gravity / term0);
            term2 = -1 * (Math.Sqrt(term0 * Program.gravity) * countTime);
            term3 = Math.Pow(2.71828, term2);
            term4 = ((1 + term3) / (1 - term3));
            velocityPoint = term1 * term4;
            return velocityPoint;
        }

        public double SimpsonIntegrationMethod(double timeOne, double timeTwo, int numberDivision)
        {
            double integration = 0.0;


            double h = (timeTwo - timeOne) / numberDivision;
            double sum = Function(timeOne) + Function(timeTwo);

            for (int i = 1; i < numberDivision; i++)
            {
                double x = timeOne + i * h;

                if (i % 2 == 0)
                    sum += 2 * Function(x);
                else
                    sum += 4 * Function(x);
            }
            integration = (h / 3) * sum;
            Console.WriteLine("" + integration);
            return integration;
        }

        public double trapezoidalIntegrationMethod(double timeOne, double timeTwo, int numberDivision)
        {
            double integration = 0.0;

            double h = (timeTwo - timeOne) / numberDivision;
            double sum = (Function(timeOne) + Function(timeTwo)) / 2.0;

            for (int i = 1; i < numberDivision; i++)
            {
                double x = timeOne + i * h;
                sum += Function(x);
            }
            integration = h * sum;
            return integration;
        }

        public double CrossSectionalArea
        {
            get { return crossSectionalArea; }
            set { crossSectionalArea = value; }
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

        public double Mass
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

