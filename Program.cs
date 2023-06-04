using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // define se tera ou não resistencia do ar
        public static int airResistance = 0;

        public static string experimentData = ""; // dados do experimento

        public static bool bodyOn = true;
        public static bool paperOn = false;
        public static bool vaccumOn = false;

        public static double finalVelocity = 0;
        public static double initialVelocity = 0;
        public static double gravity = 0;
        public static double height = 0;
        public static double timeExperiment = 0;
        
        public static body corpo  = new body();
        public static body paper  = new body();
        public static body vaccum = new body();



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
                    Console.WriteLine(" -----------------------------------------------");
                    Console.WriteLine(" Function organizeData (string data) LOGS: ");
                    Console.WriteLine(" -----------------------------------------------");
                    output = Convert.ToDouble(result); 
                    Console.WriteLine("Number   -> " + output);
                    output = output / (Math.Pow(10, numberCount)); 
                    Console.WriteLine("Number Count   -> " + numberCount);
                    Console.WriteLine("Divide by -> " + (Math.Pow(10, numberCount)));
                    Console.WriteLine("Result     -> " + output);
                    Console.WriteLine(" -----------------------------------------------");
                }
            }
            catch
            {
                MessageBox.Show("Error! Forbidden characters or very large numbers!");
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
            Simulator x = new Simulator();
            y.ShowDialog();
            y = null;
            if (Key == "open")
            {
                x.ShowDialog();
            }
        }
    }
}
