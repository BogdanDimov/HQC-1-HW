using System;

public static class StatisticsPrinter
{
    public static void PrintStatistics(double[] array)
    {
        int count = array.Length;
        double max = double.MinValue;

        for (int i = 0; i < count; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        PrintValue(max);

        double min = double.MaxValue;

        for (int i = 0; i < count; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        PrintValue(min);

        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += array[i];
        }

        double average = sum / count;
        PrintValue(average);
    }

    private static void PrintValue(double value)
    {
        Console.WriteLine(value.ToString("F3"));
    }
}
