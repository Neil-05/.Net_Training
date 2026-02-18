using System;

namespace factory_hazard
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Factory Hazard Program");
            Console.WriteLine("Enter the Arm Precision Level:");
            double precision = Convert.ToDouble(Console.ReadLine());
            if(precision<0 || precision>1.0)
            {
                Console.WriteLine("Invalid Precision Level Arm precision must be 0.0-1.0");
                return;
            }
            Console.WriteLine("Enter the workerDensity Level:");
            double workerDensity = Convert.ToDouble(Console.ReadLine());
            if(workerDensity<0|| workerDensity>20)
            {
                Console.WriteLine("Invalid workerDensity Level Worker density must be 1-20");
                return;
            }
            Console.WriteLine("Enter the Hazard Level: 1- worn 2 - faulty 3- critical");
            int hazard = Convert.ToInt32(Console.ReadLine());
            double hazardLevel=0;
            if(hazard==1)
            {
                hazardLevel=1.3;
            }
            else if(hazard==2)
            {
                hazardLevel=2.0;
            }
            else if(hazard==3)
            {
                hazardLevel=3.0;
            }
            else
            {
                Console.WriteLine("Invalid Hazard Level");
                return;
            }
            double riskFactor = ((1.0 - precision) * 15.0) + (workerDensity * hazardLevel);
            Console.WriteLine("Risk Factor: " + riskFactor);
        }
    }
}