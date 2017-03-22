using System;

namespace CSharpFundamentalsSolutions
{
    public class MythicalNumbers
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string numberAsString = number.ToString();
            double firstDigit = Char.GetNumericValue(numberAsString[0]);
            double secondDigit = Char.GetNumericValue(numberAsString[1]);
            double thirdDigit = Char.GetNumericValue(numberAsString[2]);
            double output;

            // if third digit zero
            if (thirdDigit == 0)
            {
                output = firstDigit * secondDigit;
            }
            // if between 1 and 5 incl.
            else if (1 <= thirdDigit && thirdDigit <= 5)
            {
                output = (firstDigit * secondDigit) / thirdDigit;
            }
            // if larger than 5
            else
            {
                output = (firstDigit + secondDigit) * thirdDigit;
            }

            Console.WriteLine("{0:f2}", output);
        }
    }

    public class JumpJump
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int p;
            for (int i = 0; i < input.Length;)
            {
                p = (int)Char.GetNumericValue(input[i]);

                // if zero
                if (p == 0)
                {
                    Console.WriteLine("Too drunk to go on after {0}!", i);
                    break;
                }

                // if even
                if (p % 2 == 0)
                {
                    if (i + p > input.Length - 1)
                    {
                        Console.WriteLine("Fell off the dancefloor at {0}!", i + p);
                        break;
                    }
                    else
                    {
                        i += p;
                    }
                }
                // if odd
                else
                {
                    if (i - p < 0)
                    {
                        Console.WriteLine("Fell off the dancefloor at {0}!", i - p);
                        break;
                    }
                    else
                    {
                        i -= p;
                    }
                }

                // if party symbol '^'
                if (input[i] == 94)
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", i);
                    break;
                }
            }
        }
    }

    public class HiddenMessage
    {
        public static void Main()
        {
            string output = string.Empty;
            int i = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            while (true)
            {
                if (i < 0 && s < 0)
                {
                    for (int k = text.Length + i; k >= 0; k += s)
                    {
                        output += text[k];
                    }
                }
                else if (i < 0 && s > 0)
                {
                    for (int k = text.Length + i; k < text.Length; k += s)
                    {
                        output += text[k];
                    }
                }
                else if (i > 0 && s < 0)
                {
                    for (int k = i; k >= 0; k += s)
                    {
                        output += text[k];
                    }
                }
                else
                {
                    for (int k = i; k < text.Length; k += s)
                    {
                        output += text[k];
                    }
                }

                bool isInt = int.TryParse(Console.ReadLine(), out i);
                if (!isInt)
                {
                    break;
                }

                s = int.Parse(Console.ReadLine());
                text = Console.ReadLine();
            }

            Console.WriteLine(output);
        }
    }
}
