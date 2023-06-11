using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace freeFall
{
    internal class body
    {
        private double finalVelocity = 0.0;
        private double initialVelocity = 0.0;
        private double timeAllExperiment = 0.0;
        private int numberOfTerms = 0;

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
            double qtdSpaceForNumberOfTermes = height / numberOfTerms;  // altura pelo numero de termos 
            double qtdSpaceForPixels = height / quantityPixel; // altura pela quatidade de pixels
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

        public void CalculateWithResistence(double height, double gravity, double initialVelocity, double coeficiente)
        {
            double QtdTempox = Program.timeExperiment / (0.01);
            double QtdSpace = Program.height / 534;
            int timeExperiment = Convert.ToInt32(QtdTempox);
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * height));
            timeAllExperiment = (finalVelocity - initialVelocity) / gravity;

            space = new double[timeExperiment + 2];
            velocity = new double[timeExperiment + 2];

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

    }
}

