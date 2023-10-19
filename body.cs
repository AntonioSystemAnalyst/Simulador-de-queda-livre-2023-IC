using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace freeFall
{
    internal class body
    {
        // ---
        private double endTimeWithResistence = 0.0;
        private double endSpaceWithResistence = 0.0;
        // ---
        private double finalVelocity = 0.0;
        private double initialVelocity = 0.0;
        private double timeAllExperiment = 0.0;
        private double dragCoefficient = 0.0;
        private double terminalVelocity = 0.0;
        private double mass = 0.0;
        private double crossSectionalArea = 0;
        private int numberOfTerms = 0;
        // ---
        public double term0, term1, term2, term3, term4, term5;
        public double term6, term7;
        public int precision = 15;
        public double velocityPoint;
        public double greatValueVelocity;
        // --- Antimation
        double qtdSpaceForNumberOfTermes;
        double qtdSpaceForPixels;

        private double[] space;
        private double[] velocity;
        private double[] spaceTime;
        private double[] spacePixel;
        private double[] countTimeExperiment;
        private double[] animationPixel;
        private int[] pixels;
        private int[] paperPixels;
        public static double Round(double value, int decimalPlaces)
        {
            double factor = (double)Math.Pow(10, decimalPlaces);
            double roundedValue = Math.Round(value * factor) / factor;
            return roundedValue;
        }
        public void animationVector(int quantityPixel, double height)
        {
            qtdSpaceForPixels = height / quantityPixel;
            double countSpace = 0.0;
            int i = 0, k = 0;
            int status = 0;
            int start = 0;
            int end = numberOfTerms - 1;
            int[] auxiliary;
            animationPixel = new double[quantityPixel + 1];
            pixels = new int[numberOfTerms + 1];
            auxiliary = new int[numberOfTerms + 1];

            for (i = 0; i <= quantityPixel; i++)
            {
                animationPixel[i] = countSpace;
                countSpace = countSpace + qtdSpaceForPixels;
            }

            for (i = 0; i < numberOfTerms; i++)
            {
                status = 0;
                for (k = 0; k <= quantityPixel; k++)
                {
                    if ((animationPixel[k] - space[(numberOfTerms - 1) - i]) >= 0.01 && status == 0)
                    {
                        auxiliary[i] = k;
                        status = 1;
                    }
                }
            }

            for (i = 0; i < numberOfTerms; i++)
            {
                pixels[i] = -(auxiliary[i] - quantityPixel);
                if (auxiliary[i] == 0)
                {
                    pixels[i] = 0;
                }
            }

            while (start < end)
            {
                int temp = pixels[start];
                pixels[start] = pixels[end];
                pixels[end] = temp;
                start++;
                end--;
            }
            for (i = 0; i < pixels.Length; i++)
            {
                if (pixels[i] > 524)
                {
                    pixels[i] = 524;
                }
            }
            pixels[numberOfTerms - 1] = 524;
        }
        public void animationPaper(int terms, double airDensity)
        {
            int i = 0;
            double countTime = 0;
            for (i = 0; i < terms; i++)
            {
                paperPixels[i] = CalculateXVariation(countTime, airDensity);
                countTime = countTime + 0.01;
            }
        }

        public int CalculateXVariation(double timeExperiment, double density)
        {
            int maxLeft = 195;
            int maxRight = 241;
            double valueX = 0;
            double period = 30; 
            double amplitude = (maxRight - maxLeft) / 2; 

            if (density > 1)
            {
                valueX = maxLeft + amplitude + amplitude * Math.Sin(100 * Math.PI * timeExperiment / period);
            }
            else
            {
                valueX = maxLeft + amplitude + amplitude * Math.Sin(50 * Math.PI * timeExperiment / period);
            }
            return (int)Math.Round(valueX);
        }

        public void CalculateOutResistence(double height, double gravity, double initialVelocityExperiment)
        {
            double countTime = 0.0;
            double result = 0.0;
            double decimalPart = 0.0;

            int i = 0;
            int status = 0;

            finalVelocity = Math.Sqrt((initialVelocityExperiment * initialVelocityExperiment) + (2 * gravity * height));
            timeAllExperiment = Math.Round(((finalVelocity - initialVelocityExperiment) / gravity), precision);
            result = timeAllExperiment / 0.01;

            decimalPart = result - Math.Floor(result);

            if (decimalPart > 0.5)
            {
                numberOfTerms = (int)Math.Ceiling(result);
            }
            else
            {
                numberOfTerms = (int)Math.Floor(result);
            }

            numberOfTerms = numberOfTerms + 2;

            space = new double[numberOfTerms];
            velocity = new double[numberOfTerms];
            countTimeExperiment = new double[numberOfTerms];
            spaceTime = new double[numberOfTerms];
            spacePixel = new double[Convert.ToInt32(534)];

            // Espaço 
            for (i = 0; i < numberOfTerms; i++)
            {
                space[i] = height + ((initialVelocityExperiment * countTime) + (-1 * gravity * (countTime * countTime)) / 2);
                spaceTime[i] = Math.Round(countTime, precision);
                countTime = countTime + 0.01;
            }

            countTime = 0;
            // Velocidade
            for (i = 0; i < numberOfTerms; i++)
            {
                velocity[i] = initialVelocityExperiment + (-1 * gravity * countTime);
                countTime = countTime + 0.01;
            }

            countTime = 0.00001;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = Math.Round(countTime, 4);
                countTime = countTime + 0.01;
            }


            for (i = 0; i < numberOfTerms; i++)
            {
                if (countTimeExperiment[i] >= Math.Round(timeAllExperiment, 5) && status == 0)
                {
                    status = 1;
                    countTimeExperiment[i] = Math.Round(timeAllExperiment, 4);
                    space[i] = 0;
                    velocity[i] = initialVelocityExperiment + (-1 * gravity * countTimeExperiment[i]);
                    numberOfTerms = i+1;
                }
            }

            for (i=0; i<numberOfTerms; i++)
            {
                Console.WriteLine("" + countTimeExperiment[i]);
            }
            for (i = 0; i < numberOfTerms; i++)
            {
                Console.WriteLine("" + space[i]);
            }
            animationVector(534, height);
        }

        public double spaceFunction(double countTime, double initialVelocityExperiment, double gravity, double height)
        {
            return height + ((initialVelocityExperiment * countTime) + (-1 * gravity * (countTime * countTime)) / 2);
        }

        public void CalculateWithResistenceRV1(double height, double gravity, double airDensity)
        {
            double spacePoint = 0.0;
            double countTime = 0.0;
            double result = 0.0;
            double decimalPart = 0.0;
            int i, status = 0;

            term0 = Math.Round((0.5 * dragCoefficient * airDensity * crossSectionalArea), precision);
            term1 = Math.Round((term0 / mass), precision);

            terminalVelocity = (gravity / term1) * 0.001;
            greatValueVelocity = velocityFunctionRV1(0, 0, gravity);
            timeAllExperiment = getTimeAllVR1(gravity, height);

            result = timeAllExperiment / 0.01;

            decimalPart = result - Math.Floor(result);

            if (decimalPart > 0.5)
            {
                numberOfTerms = (int)Math.Ceiling(result);
            }
            else
            {
                numberOfTerms = (int)Math.Floor(result);
            }
            
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = height - spaceFunctionRV1(Math.Round(countTime, 10), gravity, height);
                if (spacePoint <= 0 && status == 0)
                {
                    numberOfTerms = i;
                    status = 1;
                }
                countTime = countTime + 0.01;
            }

            paperPixels = new int[numberOfTerms + 1];
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
            finalVelocity = velocity[velocity.Length - 1];

            countTime = 0;
            for (i = 0; i < numberOfTerms; i++)
            {
                spacePoint = height - Math.Round(spaceFunctionRV1(countTime, gravity, height), 10);
                if (spacePoint <= 0)
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
                spaceTime[i] = Math.Round(countTime, 4);
                countTime = countTime + 0.01;
            }
            
            countTime = 0;
            // time
            for (i = 0; i < numberOfTerms; i++)
            {
                countTimeExperiment[i] = Math.Round(countTime, 4);
                countTime = countTime + 0.01;
            }

            countTimeExperiment[numberOfTerms-1] = Math.Round(getEndTime(gravity, height, countTimeExperiment[numberOfTerms - 3]), 4);
            space[numberOfTerms - 1] = height - spaceFunctionRV1(Math.Round(countTimeExperiment[numberOfTerms - 1], 10), gravity, height);
            velocity[numberOfTerms - 1] = velocityFunctionRV1(countTimeExperiment[numberOfTerms - 1], 1, gravity);
            timeAllExperiment = countTimeExperiment[numberOfTerms - 1];
            animationPaper(numberOfTerms, airDensity);
            animationVector(534, height);
        }

        public double getEndTime(double gravity, double height, double time)
        {
            endTimeWithResistence = 0.0;

            double terminalTime = time;
            double spaceFunction = 0.0;
            double value = 0.0;
            int breakStatus = 0;

            do
            {
                spaceFunction = spaceFunctionRV1(Math.Round(terminalTime, 15), gravity, height);

                if (spaceFunction >= height)
                {
                    spaceFunction = height;
                }
                value = height - spaceFunction;
                if (Math.Round(value, 8) <= 0.00001)
                {
                    breakStatus = 1;
                }
                terminalTime += 0.0000001;
            } while (breakStatus == 0);

            endTimeWithResistence = terminalTime;
            return endTimeWithResistence;
        }
        public double getTimeEndVR1(double gravity, double height)
        {
            double terminalTime = 0.0;
            double spaceFunction = 0.0;
            double value = 0.0;
            int breakStatus = 0;
            do
            {
                spaceFunction = spaceFunctionRV1(Math.Round(terminalTime, 15), gravity, height);

                if (spaceFunction >= height)
                {
                    spaceFunction = height;
                }
                value = height - spaceFunction;
                if (Math.Round(value, 5) <= 0)
                {
                    breakStatus = 1;
                }
                terminalTime += 0.001;
            } while (breakStatus == 0);
            return terminalTime;
        }
        public double getTimeAllVR1(double gravity, double height)
        {
            double terminalTime = 0.0;
            double spaceFunction = 0.0;
            double value = 0.0;
            int breakStatus = 0;
            do
            {
                spaceFunction = spaceFunctionRV1(Math.Round(terminalTime, 14), gravity, height);

                if (spaceFunction >= height)
                {
                    spaceFunction = height;
                }
                value = height - spaceFunction;
                if (Math.Round(value, 14) <= 0)
                {
                    breakStatus = 1;
                }
                terminalTime += 0.01;
            } while (breakStatus == 0);
            return terminalTime;
        }
        public double spaceFunctionRV1(double timeValue, double gravity, double height)
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

        public double velocityFunctionRV1(double timeValue, int op, double gravity)
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

        public double timeVelocityFunctionRV1(double velocity, double gravity)
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

        public int[] PaperPixels
        {
            get { return paperPixels; }
            set { paperPixels = value; }
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

        public double EndTimeWithResistence
        {
            get { return endTimeWithResistence; }
            set { endTimeWithResistence = value; }
        }

        public double EndSpaceWithResistence
        {
            get { return endSpaceWithResistence; }
            set { endSpaceWithResistence = value; }
        }

    }
}

