using System;
using Task_1._Quality_Methods.Commands;
using Task_1._Quality_Methods.Enums;
using Task_1._Quality_Methods.Models;

namespace Task_1._Quality_Methods
{
    public class Startup
    {
        public static void Main()
        {
            // Find triangle area and print it.
            var triangleArea = Methods.CalculateTriangleArea(3, 4, 5);
            Console.WriteLine(triangleArea);

            // Convert digit into english word and print it.
            var digitAsWord = Methods.ConvertDigitIntoEnglishWord(5);
            Console.WriteLine(digitAsWord);

            // Find max value of int array.
            var intArray = new int[] { 5, -1, 3, 2, 14, 2, 3 };
            var maxInt = Methods.FindMaxOfArrayOfInts(intArray);
            Console.WriteLine(maxInt);

            // Print number in different formats.
            Methods.PrintNumberAs(1.3, PrintOption.AsFloatWithTwoDecimalPlaces);
            Methods.PrintNumberAs(0.75, PrintOption.AsPercent);
            Methods.PrintNumberAs(2.30, PrintOption.IndentedByEightSpaces);

            // Get distance between 2d points and print it.
            var point1 = new Point2D(3, -1);
            var point2 = new Point2D(3, 2.5);
            var distance = Methods.CalculateDistanceBetween2DPoints(point1, point2);
            Console.WriteLine(distance);

            // Check if line is horizontal or vertical and print the result.
            var isHorizontal = Methods.CheckIfLineIsHorizontal(point1, point2);
            var isVertical = Methods.CheckIfLineIsVertical(point1, point2);
            Console.WriteLine("Horizontal? " + isHorizontal.ToString() + "\nVertical? " + isVertical.ToString());

            // Check if second student is older than first one and print the result.
            var peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia....");
            var stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results...");
            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
