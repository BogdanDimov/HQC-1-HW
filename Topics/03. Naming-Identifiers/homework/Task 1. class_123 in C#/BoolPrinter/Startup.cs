using System;

public class Startup
{
    public static void Main()
    {
        BoolPrinter printer = new BoolPrinter();
        printer.PrintBoolAsString(true);
    }

    public class BoolPrinter
    {
        public void PrintBoolAsString(bool boolToPrint)
        {
            string stringifiedBool = boolToPrint.ToString();
            Console.WriteLine(stringifiedBool);
        }
    }
}