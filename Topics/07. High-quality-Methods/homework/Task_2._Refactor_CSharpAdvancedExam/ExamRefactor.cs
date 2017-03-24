using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_2._Refactor_CSharpAdvancedExam
{
    public class Task1
    {
        public static void Main()
        {
            string[] digits = { "otsirh", "ohsot", "ohsep", "rofotsirh", "dalv", "ipmalarah", "oroz", "rimidalv" };
            var input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                char[] reverse = input[i].ToString().ToCharArray();
                Array.Reverse(reverse);
                input[i] = new string(reverse);

                for (int j = 0; j < digits.Length; j++)
                {
                    if (input[i].Contains("rofotsirh"))
                    {
                        input[i] = input[i].Replace("rofotsirh", "3");
                    }
                    else if (input[i].Contains("rimidalv"))
                    {
                        input[i] = input[i].Replace("rimidalv", "7");
                    }
                    else
                    {
                        input[i] = input[i].Replace(digits[j], j.ToString());
                    }
                }
            }

            BigInteger product = 1;
            foreach (var number in input)
            {
                BigInteger sum = 0;
                for (int i = 0; i < number.Length; i++)
                {
                    sum += (number[i] - '0') * (BigInteger)Math.Pow(8, i);
                }

                product *= sum;
            }

            Console.WriteLine(product);
        }
    }

    public class Task3
    {
        private static int rows;
        private static int cols;
        private static string[,] field;
        private static BigInteger snakeLength;
        private static bool hitTheRock = false;
        private static bool escaped = false;
        private static bool stuck = false;
        private static bool lost = false;
        private static bool starves = false;

        public static void Main()
        {
            string[] dimensions = Console.ReadLine().Split('x');
            rows = int.Parse(dimensions[0]);
            cols = int.Parse(dimensions[1]);
            field = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = row[j].ToString();
                }
            }

            string[] moves = Console.ReadLine().Split(',', ' ');
            int currentRow = 0;
            int currentCol = 4;
            snakeLength = 3;
            int count = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                count++;

                if (count % 5 == 0)
                {
                    snakeLength--;
                }

                if (snakeLength <= 0)
                {
                    starves = true;
                    break;
                }

                if (moves[i] == "w") 
                {
                    //up
                    currentRow--;
                    if (field[currentRow, currentCol] == "@")
                    {
                        snakeLength++;
                        field[currentRow, currentCol] = "0";
                    }
                    else if (field[currentRow, currentCol] == "%")
                    {
                        hitTheRock = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "e")
                    {
                        escaped = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "-")
                    {
                        continue;
                    }
                }
                else if (moves[i] == "s") 
                {
                    //down
                    currentRow++;
                    if (currentRow > rows - 1)
                    {
                        lost = true;
                    }

                    if (field[currentRow, currentCol] == "@")
                    {
                        snakeLength++;
                        field[currentRow, currentCol] = "0";
                    }
                    else if (field[currentRow, currentCol] == "%")
                    {
                        hitTheRock = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "e")
                    {
                        escaped = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "-")
                    {
                        continue;
                    }
                }                
                else if (moves[i] == "d") 
                {
                    //right
                    currentCol++;
                    if (currentCol > cols - 1)
                    {
                        currentCol = 0; //go to left end
                    }

                    if (field[currentRow, currentCol] == "@")
                    {
                        snakeLength++;
                        field[currentRow, currentCol] = "0";
                    }
                    else if (field[currentRow, currentCol] == "%")
                    {
                        hitTheRock = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "e")
                    {
                        escaped = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "-")
                    {
                        continue;
                    }
                }                
                else if (moves[i] == "a") 
                {
                    //left
                    currentCol--;
                    if (currentCol < 0)
                    {
                        //go to right end
                        currentCol = cols - 1; 
                    }

                    if (field[currentRow, currentCol] == "@")
                    {
                        snakeLength++;
                        field[currentRow, currentCol] = "0";
                    }
                    else if (field[currentRow, currentCol] == "%")
                    {
                        hitTheRock = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "e")
                    {
                        escaped = true;
                        break;
                    }
                    else if (field[currentRow, currentCol] == "-")
                    {
                        continue;
                    }
                }

                if (count == moves.Length)
                {
                    stuck = true;
                    break;
                }
            }

            if (hitTheRock)
            {
                Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", currentRow, currentCol);
            }
            else if (escaped)
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", snakeLength);
            }
            else if (stuck)
            {
                Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", currentRow, currentCol);
            }
            else if (lost)
            {
                Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", snakeLength);
            }
            else if (starves)
            {
                Console.WriteLine("Sneaky is going to starve at [{0},{1}]", currentRow, currentCol);
            }
        }
    }

    public class Task4
    {
        public static void Main()
        {
            //word to look for
            string keyword = Console.ReadLine();

            //number of lines of text
            int n = int.Parse(Console.ReadLine());

            var text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                text.Append(Console.ReadLine());
                text.Append(" ");
            }

            //split into sentences
            string[] sentences = Regex.Split(text.ToString(), @"(?<=[\.!\?])\s+");

            BigInteger sum = 0;
            string substring = string.Empty;
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                if (sentences[i].Contains(keyword))
                {
                    // if ends with !
                    if (sentences[i].Contains("!"))
                    {
                        //take text before keyword
                        substring = sentences[i].Substring(0, sentences[i].IndexOf(keyword)); // from 0 to keyword
                    }
                    else if (sentences[i].Contains("."))
                    {
                        // from end of keyword to end of sentence
                        substring = sentences[i].Substring(sentences[i].IndexOf(keyword) + keyword.Length);

                        // remove last .
                        substring = substring.Remove(substring.Length - 1);
                    }
                }
            }

            substring = Regex.Replace(substring, @"\s+", string.Empty);

            byte[] asciiValues = Encoding.ASCII.GetBytes(substring);
            foreach (byte b in asciiValues)
            {
                sum += b * keyword.Length;
            }

            Console.WriteLine(sum);
        }
    }
}
