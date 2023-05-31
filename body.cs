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
        private double timeOutAirResistence = 0.0;
        private double countTime = 0.0;


        private double[] spaceTime;
        private double[] spacePixel;
        private double[] space;
        private double[] velocity;

        public static double Round(double value, int decimalPlaces)
        {
            double factor = (double)Math.Pow(10, decimalPlaces);
            double roundedValue = Math.Round(value * factor) / factor;
            return roundedValue;
        }
        public void calculateOutResistence (double height, double gravity, double initialVelocity)
        {
           
            double QtdSpace = height / 534;
            double spaceCont = 0.0;
            double QtdTempox = Program.timeExperiment / (0.01);
            int timeExperiment = Convert.ToInt32(QtdTempox);

            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity* initialVelocity) + (2 *gravity* height));
            timeOutAirResistence = Round((finalVelocity - initialVelocity) / gravity, 2);

            space    = new double[timeExperiment + 2];
            velocity = new double[timeExperiment + 2];

            space = new double[Convert.ToInt32(534)];
            velocity = new double[Convert.ToInt32(534)];
            spaceTime = new double[Convert.ToInt32(535 + 1000)];
            spacePixel = new double[Convert.ToInt32(534)];

            // pixel for space

            for (i = 0; i < 534; i++)
            {
                spacePixel[i] = spaceCont;
                spaceCont += QtdSpace;

            }
            // time for pixel
            for (i = 0; i < 534; i++)
            {
                velocity[i] = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * spacePixel[i]));
                spaceTime[i] = Round((velocity[i] - initialVelocity) / gravity, 2);
            }
        }

        public void calculateWithResistence(double height, double gravity, double initialVelocity, double coeficiente)
        {
            double QtdTempox = Program.timeExperiment / (0.01);
            double QtdSpace = Program.height / 534;
            double spaceCont = 0.0;
            int timeExperiment = Convert.ToInt32(QtdTempox);
            int i = 0;

            finalVelocity = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * height));
            timeOutAirResistence = (finalVelocity - initialVelocity) / gravity;

            space = new double[timeExperiment + 2];
            velocity = new double[timeExperiment + 2];

            space = new double[Convert.ToInt32(534)];
            velocity = new double[Convert.ToInt32(534)];
            spaceTime = new double[Convert.ToInt32(535 + 1000)];
            spacePixel = new double[Convert.ToInt32(534)];

            // pixel for space

            for (i = 0; i < 534; i++)
            {
                spacePixel[i] = spaceCont;
                spaceCont += QtdSpace;

            }
            // time for pixel
            for (i = 0; i < 534; i++)
            {
                velocity[i] = Math.Sqrt((initialVelocity * initialVelocity) + (2 * gravity * spacePixel[i]));
                spaceTime[i] = Math.Round((velocity[i] - initialVelocity) / gravity, 3);
            }
        }


        public double CountTimeObject
        {
            get { return countTime; }
            set { countTime = value; }
        }

        public double FinalVelocityObject
        {
            get { return finalVelocity; }
            set { finalVelocity = value; }
        }

        public double InitialVelocityObject
        {
            get { return initialVelocity; }
            set { initialVelocity = value; }
        }

        public double TimeExperimentObject
        {
            get { return timeOutAirResistence; }
            set { timeOutAirResistence = value; }
        }

        public double[] SpaceObjectTime
        {
            get { return spaceTime; }
            set { spaceTime = value; }
        }

        public double[] SpaceObjectPixel
        {
            get { return spacePixel; }
            set { spacePixel = value; }
        }

        public double[] Space
        {
            get { return space; }
            set { space = value; }
        }

        public double[] VelocityObject
        {
            get { return velocity; }
            set { velocity = value; }
        }

    }
}

