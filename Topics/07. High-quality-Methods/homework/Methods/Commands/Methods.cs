using System;
using Task_1._Quality_Methods.Enums;
using Task_1._Quality_Methods.Models;

namespace Task_1._Quality_Methods.Commands
{
    public static class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Triangle sides should be positive.");
            }

            double semiperimeter = (a + b + c) / 2;

            // Heron's formula for finding Area of triangle by given 3 sides.
            double area = Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));
            return area;
        }

        public static string ConvertDigitIntoEnglishWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new InvalidOperationException(
                        "Invalid digit: " + digit);
            }
        }

        public static int FindMaxOfArrayOfInts(int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Elements array cannot be empty.");
            }

            var currentMax = int.MinValue;
            for (int i = 0, len = elements.Length - 1; i < len; i++)
            {
                if (elements[i] > currentMax)
                {
                    currentMax = elements[i];
                }
            }

            return currentMax;
        }

        public static void PrintNumberAs(double number, PrintOption option)
        {
            switch (option)
            {
                case PrintOption.AsFloatWithTwoDecimalPlaces:
                    PrintNumberAsFloatWithTwoDecimalPlaces(number);
                    break;
                case PrintOption.AsPercent:
                    PrintNumberAsPercent(number);
                    break;
                case PrintOption.IndentedByEightSpaces:
                    PrintNumberIndentedByEightSpaces(number);
                    break;
            }
        }

        public static double CalculateDistanceBetween2DPoints(Point2D p1, Point2D p2)
        {
            // Calculate distance with Pythagorean theorem.
            double distance = Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)));
            return distance;
        }

        public static bool CheckIfLineIsHorizontal(Point2D p1, Point2D p2)
        {
            var horizontal = p1.Y == p2.Y;
            return horizontal;
        }

        public static bool CheckIfLineIsVertical(Point2D p1, Point2D p2)
        {
            var vertical = p1.X == p2.X;
            return vertical;
        }

        private static void PrintNumberAsFloatWithTwoDecimalPlaces(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        private static void PrintNumberAsPercent(double number)
        {
            if (number > 1.0f)
            {
                throw new ArgumentException("Number cannot be greater than 1.");
            }

            Console.WriteLine("{0:p0}", number);
        }

        private static void PrintNumberIndentedByEightSpaces(double number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}
