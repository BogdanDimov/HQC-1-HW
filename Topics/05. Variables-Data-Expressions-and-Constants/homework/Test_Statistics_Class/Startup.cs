using System;

namespace Test_Statistics_Class
{
    public class Startup
    {
        public static void Main()
        {
            var doubleArray = new double[] { 4.44, 5.55, 6.66, 7.778 };
            StatisticsPrinter.PrintStatistics(doubleArray);
        }
    }
}
