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
        public int precision = 13;
        public double velocityPoint;
        public double spacePoint;
        public double greatValueVelocity;
        public static double countTime;
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
                space[i] = height + ((initialVelocityExperiment * countTime) + (-1*gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // Velocidade
            for (i = 0; i < numberOfTerms; i++)
            {
                velocity[i] = initialVelocityExperiment + (-1*gravity * countTime);
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

        public  void CalculateWithResistenceRV1(double height, double gravity, double initialVelocity, double airDensity)
        {
            double spacePoint;
            int i, status = 0;

            term0 = Math.Round((0.5 * dragCoefficient * airDensity * crossSectionalArea), precision);
            term1 = Math.Round((term0 / mass), precision);
            terminalVelocity = gravity / term1;

            greatValueVelocity = velocityFunctionRV1(0, 0, gravity);
            timeAllExperiment = getTimeAllVR1(gravity, height);
            finalVelocity = terminalVelocity;



            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01) + 1;


            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = height - spaceFunctionRV1(countTime, gravity, height);
                if (spacePoint < 0 && status == 0)
                {
                    numberOfTerms = i;
                    status = 1;
                }
                countTime = countTime + 0.01;
            }
            countTime = 0;



            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];
            spaceTime = new double[numberOfTerms];
            countTime = 0.01;
            for (i = 1; i < numberOfTerms; i++)
            {
                velocityPoint = velocityFunctionRV1(countTime, 1, gravity);
                velocity[i] = velocityPoint;
                countTime = countTime + 0.01;
            }
            finalVelocity = velocity[velocity.Length-1];

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = height - spaceFunctionRV1(countTime, gravity, height);
                if (spacePoint < 0)
                {
                    space[i] = 0;
                }
                else
                {
                    if (spacePoint > height)
                    {
                        space[i] = height;
                    }
                    else
                    {
                        space[i] = spacePoint;
                    }
                }
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }
            space[0] = height;
            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }
            animationVector(534, height);
        }
        public  double getTimeAllVR1(double gravity, double height)
        {
            double terminalTime = 0.01;
            double timeAll = 0.0;
            double spaceFunction = 0.0;
            int breakStatus = 0;

            do
            {
                spaceFunction = spaceFunctionRV1(terminalTime, gravity, height);
                if(spaceFunction>height)
                {
                    spaceFunction= height;
                }

                if ((height - spaceFunction) < 0.0001)
                {
                    breakStatus = 1;
                }
                terminalTime += 0.01;
            } while (breakStatus == 0);
            timeAll = terminalTime;
            return timeAll;
        }

        public  double spaceFunctionRV1(double timeValue, double gravity, double height)
        {
            double spacePointFunction = 0.0;
            term2 = Math.Round(gravity / (term1 * term1), precision);
            term3 = Math.Round((-1 * term1 * timeValue), precision);
            term5 = Math.Pow(Math.E, term3);
            term4 = Math.Round((term1 * timeValue), precision);
            term6 = Math.Round((term5 + term4 - 1), precision);
            term7 = Math.Round((term2 * term6), precision);
            spacePointFunction = Math.Round(term7, precision);
            return spacePointFunction;
        }

        public  double velocityFunctionRV1(double timeValue, int op, double gravity)
        {
            double velocityPointF = 0.0;
            if (op == 0)
            {
                term2 = Math.Round((gravity / term1), precision);
                term3 = Math.Round((-1 * term1 * timeValue), precision);
                term4 = Math.Pow(Math.E, term3);
                term5 = Math.Round((1 - term4), precision);
                term6 = Math.Round((term2 * term5), precision);
                velocityPointF = term6;
            }
            else
            {
                term2 = Math.Round(gravity / term1, precision);
                term3 = Math.Round(-1 * term1 * timeValue, precision);
                term4 = Math.Pow(Math.E, term3);
                term5 = Math.Round((1 - term4), precision);
                term6 = Math.Round((term2 * term5), precision);
                velocityPointF = greatValueVelocity - term6;
            }
            return velocityPointF;
        }

        public  double timeVelocityFunctionRV1(double velocity, double gravity)
        {
            double timVelocity = 0.0;
            term2 = Math.Round((-1 / term1), precision);
            term3 = Math.Round(((velocity - greatValueVelocity) / gravity), precision);
            term4 = Math.Round((term1 * term3), precision);
            term5 = Math.Round((1 - term4), precision);
            term6 = Math.Log(term5);
            term7 = Math.Round((term2 * term6), precision);
            timVelocity = term7;
            return timVelocity;
        }

        public static double CalculateCircleArea(double circumference)
        {
            double radius = circumference / (2 * Math.PI);
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }
        // ----------------------------------------------------------------------------------------//
        public  void CalculateWithResistenceVR2(double height, double gravity, double initialVelocity, double airDensity)
        {
            double Ax;
            double spacePoint;
            int i;

            term0 = Math.Round((0.5 * dragCoefficient * airDensity * crossSectionalArea), precision);
            term1 = Math.Round(mass / term0, precision);
            Ax = gravity / term1;
            greatValueVelocity = velocityFunctionRV2(0.01, 0, gravity);
            timeAllExperiment = getTimeAllVR2(gravity, height);
            numberOfTerms = (int)Math.Ceiling(timeAllExperiment / 0.01) + 1;
            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];
            spaceTime = new double[numberOfTerms];

            countTime = 0.01;
            for (i = 1; i < numberOfTerms; i++)
            {
                velocityPoint = velocityFunctionRV2(countTime, 1, gravity);
                velocity[i] = velocityPoint;
                countTime = countTime + 0.01;
            }
            finalVelocity = velocity[velocity.Length-1];

            countTime = 0.01;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = SimpsonIntegrationMethod(0.01, countTime, 40, gravity) + height;
                if (spacePoint < 0.2)
                {
                    space[i] = 0;
                }
                else
                {
                    if (spacePoint > height)
                    {
                        space[i] = height;
                    }
                    else
                    {
                        space[i] = spacePoint;
                    }
                }
                spaceTime[i] = Math.Round(countTime, 3);
                countTime = countTime + 0.01;
            }
            space[0] = height;
            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = countTime;
                countTime = countTime + 0.01;
            }

            animationVector(534, height);
        }
        public  double getTimeAllVR2(double gravity, double height)
        {
            double terminalTime = 0.01;
            double timeAll = 0.0;
            double spaceFunction = 0.0;
            int breakStatus = 0;
            do
            {
                spaceFunction = SimpsonIntegrationMethod(0.01, terminalTime, 40, gravity);
                if ((height + spaceFunction) <= 0.0001)
                {
                    breakStatus = 1;
                }
                terminalTime += 0.01;
            } while (breakStatus == 0);
            timeAll = terminalTime;
            return timeAll;
        }
        public  double velocityFunctionRV2(double countTime, int op, double gravity)
        {
            if (op == 0)
            {
                term2 = Math.Round((gravity / term1), precision);
                term3 = Math.Sqrt(term2);
                term4 = Math.Round((term1 * gravity), precision);
                term5 = Math.Sqrt(term4);
                term6 = Math.Round((-1 * countTime * term5), precision);
                term7 = Math.Pow(Math.E, term6);
                term8 = Math.Round((1 + term7), precision);
                term9 = Math.Round((1 - term7), precision);
                term10 = Math.Round((term8 / term9), precision);
                velocityPoint = Math.Round((term10 * term3), precision);
            }
            else
            {
                term2 = Math.Round((gravity / term1), precision);
                term3 = Math.Sqrt(term2);
                term4 = Math.Round((term1 * gravity), precision);
                term5 = Math.Sqrt(term4);
                term6 = Math.Round((-1 * countTime * term5), precision);
                term7 = Math.Pow(Math.E, term6);
                term8 = Math.Round((1 + term7), precision);
                term9 = Math.Round((1 - term7), precision);
                term10 = Math.Round((term8 / term9), precision);
                velocityPoint = Math.Round((term10 * term3), precision) - greatValueVelocity;
            }
            return velocityPoint;
        }

        public  double SimpsonIntegrationMethod(double timeOne, double timeTwo, int numberDivision, double gravity)
        {
            double integration = 0.0;

            double h = (timeTwo - timeOne) / numberDivision;
            double sum = velocityFunctionRV2(timeOne, 1, gravity) + velocityFunctionRV2(timeTwo, 1, gravity);

            for (int i = 1; i < numberDivision; i++)
            {
                double x = timeOne + i * h;

                if (i % 2 == 0)
                    sum += 2 * velocityFunctionRV2(x, 1, gravity);
                else
                    sum += 4 * velocityFunctionRV2(x, 1, gravity);
            }
            integration = Math.Round(((h / 3) * sum), precision);
            return integration;
        }

        // ----------------------------------------------------------------------------------------//

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

