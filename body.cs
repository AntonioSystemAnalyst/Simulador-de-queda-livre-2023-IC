using System;
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
        public double crossSectionalArea = 0;
        private int numberOfTerms = 0;

        // ---
        public double term0, term1, term2, term3, term4, term5;
        public double term6, term7, term8, term9, term10;
        public int precision = 5;
        public double velocityPoint;
        public double spacePoint;

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
        public void CalculateOutResistence(double height, double gravity, double initialVelocityExperiment)
        {
            double countTime = 0;
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocityExperiment * initialVelocityExperiment) + (2 * gravity * height));
            timeAllExperiment = Math.Round((finalVelocity - initialVelocityExperiment) / gravity, 3);

            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01);

            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];


            spaceTime = new double[numberOfTerms];
            spacePixel = new double[Convert.ToInt32(534)];

            // Espaço 
            for (i = 0; i < numberOfTerms; i++)
            {
                space[i] = height + ((initialVelocityExperiment * countTime) + (-gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // Velocidade
            for (i = 0; i < numberOfTerms; i++)
            {
                velocity[i] = initialVelocityExperiment + (-gravity * countTime);
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

        public void CalculateWithResistence(double height, double gravity, double initialVelocityExperiment)
        {
            double Ax;
            double countTime;
            int i;

            term0 = Math.Round((0.5 * dragCoefficient * Program.airDensity * crossSectionalArea), precision);
            term1 = Math.Round(mass / term0);


            Ax = (2*mass*gravity) / (dragCoefficient * Program.airDensity * crossSectionalArea);
            
            terminalVelocity = Math.Sqrt(Ax);
            finalVelocity = terminalVelocity;

            timeAllExperiment = getTimeAllRV2();

            finalVelocity = terminalVelocity;

            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01) + 1;

            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];

            spaceTime = new double[numberOfTerms + 2];
            spacePixel = new double[Convert.ToInt32(534)];

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                velocityPoint = Function(countTime);
                velocity[i] = -velocityPoint;
                countTime = countTime + 0.01;
            }

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = SimpsonIntegrationMethod(0.01, countTime, 40);
                space[i] = spacePoint;
                countTime = countTime + 0.01;
            }

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            initialVelocity = -velocity[0];

            Program.height = space[space.Length - 1];

            for (i = 0; i < numberOfTerms; i++)
            {
                space[i] = (Program.height - space[i]);
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("dragCoefficient ->" + dragCoefficient);
            Console.WriteLine("Program.airDensity ->" + Program.airDensity);
            Console.WriteLine("crossSectionalArea ->" + crossSectionalArea);
            Console.WriteLine("term1 ->" + term1);
            Console.WriteLine("terminalVelocity ->" + terminalVelocity);
            Console.WriteLine("timeAllExperiment-> " + timeAllExperiment);
            Console.WriteLine("numberOfTerms-> " + numberOfTerms);
            Console.WriteLine("----------------------------------------------------------");

            animationVector(534, height);
        }


        public void CalculateWithResistenceRV2(double height, double gravity, double initialVelocityExperiment)
        {
            double Ax;
            double countTime;
            int i;

            term0 = Math.Round((0.5 * dragCoefficient * Program.airDensity * crossSectionalArea), precision);
            term1 = Math.Round(mass / term0);


            Ax = gravity / term1;
            terminalVelocity = Math.Sqrt(Ax);
            finalVelocity = terminalVelocity;
            timeAllExperiment = getTimeAllRV2();

            finalVelocity = terminalVelocity;

            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01) + 1;

            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];

            spaceTime = new double[numberOfTerms + 2];
            spacePixel = new double[Convert.ToInt32(534)];

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                velocityPoint = Function(countTime);
                velocity[i] = -velocityPoint;
                countTime = countTime + 0.01;
            }

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = SimpsonIntegrationMethod(0.01, countTime, 40);
                space[i] = spacePoint;
                countTime = countTime + 0.01;
            }

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            initialVelocity = -velocity[0];

            Program.height = space[space.Length - 1];

            for (i = 0; i < numberOfTerms; i++)
            {
                space[i] = (Program.height - space[i]);
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("dragCoefficient ->" + dragCoefficient);
            Console.WriteLine("Program.airDensity ->" + Program.airDensity);
            Console.WriteLine("crossSectionalArea ->" + crossSectionalArea);
            Console.WriteLine("term1 ->" + term1);
            Console.WriteLine("terminalVelocity ->" + terminalVelocity);
            Console.WriteLine("timeAllExperiment-> " + timeAllExperiment);
            Console.WriteLine("numberOfTerms-> " + numberOfTerms);
            Console.WriteLine("----------------------------------------------------------");

            animationVector(534, height);
        }


        public double CalculateCircleArea(double circumference)
        {
            double radius = circumference / (2 * Math.PI);
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        public double getTimeAllRV2()
        {
            double velocityTerminalTime = 0.01;
            double velocityInTime;
            double timeAll = 0.0;
            double spaceTerminal = 0.0;
            double spaceTravel = 0.0;
            double timeTravel = 0.0;
            int breakStatus = 0;
            do
            {
                velocityInTime = Function(velocityTerminalTime);
                velocityTerminalTime += 0.01;
                if ((velocityInTime - terminalVelocity) < 0.008)
                {
                    breakStatus = 1;
                    Console.WriteLine(" veloctyTerminal = " + velocityTerminalTime);
                }
            } while (breakStatus == 0);

            spaceTerminal = SimpsonIntegrationMethod(0.01, velocityTerminalTime, 40);
            spaceTravel = Program.height - spaceTerminal;
            timeTravel = spaceTravel / terminalVelocity;
            timeAll = timeTravel + velocityTerminalTime;

            Console.WriteLine(" ------------------------------------");
            Console.WriteLine(" spaceTermial = " + spaceTerminal);
            Console.WriteLine(" spaceTravel = " + spaceTravel);
            Console.WriteLine(" timeTravel = " + timeTravel);
            Console.WriteLine(" totalTime = " + timeAll);
            Console.WriteLine(" ------------------------------------");
            return timeAll;
        }

        public double Function(double countTime)
        {

            term2 = Math.Round((Program.gravity / term1), precision);
            term3 = Math.Sqrt(term2);
            term4 = Math.Round((term1 * Program.gravity), precision);
            term5 = Math.Sqrt(term4);
            term6 = Math.Round((-1 * countTime * term5), precision);
            term7 = Math.Pow(Math.E, term6);
            term8 = Math.Round((1 + term7), precision);
            term9 = Math.Round((1 - term7), precision);
            term10 = Math.Round((term8 / term9), precision);
            velocityPoint = Math.Round((term10 * term3), precision);
            return velocityPoint;
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
            integration = Math.Round((h * sum), precision);
            return integration;
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
            integration = Math.Round(((h / 3) * sum), precision);
            return integration;
        }

        public double TerminalVelocity
        {
            get { return terminalVelocity; }
            set { terminalVelocity = value; }
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

