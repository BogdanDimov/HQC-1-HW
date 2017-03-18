using System;
using System.Collections.Generic;
using Minesweeper.Models;

namespace Minesweeper.Core
{
    internal class Engine
    {
        internal static void ShowHighscores(List<Result> topResults)
        {
            Console.WriteLine("\nHighscores:");
            if (topResults.Count > 0)
            {
                for (int i = 0; i < topResults.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} boxes",
                        i + 1,
                        topResults[i].Name,
                        topResults[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Highscore list is empty!\n");
            }
        }

        internal static void FillNumberOfNeighboringMines(
            char[,] playingField,
            char[,] minefield,
            int row,
            int col)
        {
            var minesCount = GetNumberOfNeighboringMinesForCurrentCell(minefield, row, col);
            minefield[row, col] = minesCount;
            playingField[row, col] = minesCount;
        }

        internal static void ShowField(char[,] field)
        {
            int numOfRows = field.GetLength(0);
            int numOfCols = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < numOfRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < numOfCols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        internal static char[,] GeneratePlayingField()
        {
            int rows = 5;
            int columns = 10;
            char[,] playingField = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playingField[i, j] = '?';
                }
            }

            return playingField;
        }

        internal static char[,] GenerateMinefield()
        {
            var rows = 5;
            var columns = 10;
            char[,] minefield = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    minefield[i, j] = '-';
                }
            }

            var numbers = new List<int>();
            while (numbers.Count < 15)
            {
                var rnd = new Random();
                int randNumber = rnd.Next(50);
                if (!numbers.Contains(randNumber))
                {
                    numbers.Add(randNumber);
                }
            }

            foreach (int number in numbers)
            {
                int row = number % columns;
                int column = number / columns;

                if (row == 0 && number != 0)
                {
                    row = columns;
                    column--;
                }
                else
                {
                    row++;
                }

                minefield[column, row - 1] = '*';
            }

            return minefield;
        }

        internal static void CalculateNumberOfNeighboringMinesForEachCell(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (board[i, j] != '*')
                    {
                        var minesCount = GetNumberOfNeighboringMinesForCurrentCell(board, i, j);
                        board[i, j] = minesCount;
                    }
                }
            }
        }

        internal static char GetNumberOfNeighboringMinesForCurrentCell(char[,] board, int row, int column)
        {
            int counter = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    counter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    counter++;
                }
            }

            if (column + 1 < cols)
            {
                if (board[row, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < cols))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < cols))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
