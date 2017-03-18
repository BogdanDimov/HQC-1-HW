using System;
using System.Collections.Generic;
using Minesweeper.Core;
using Minesweeper.Models;

namespace Minesweeper
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            const int MAX_RESULT = 35;
            const int HIGHSCORES_NUMBER = 6;
            var command = string.Empty;
            var topResults = new List<Result>(HIGHSCORES_NUMBER);
            var currentRow = 0;
            var currentColumn = 0;
            char[,] playingField = Engine.GeneratePlayingField();
            char[,] minefield = Engine.GenerateMinefield();
            var points = 0;
            var hasSteppedOnMine = false;
            var showMainMenu = true;
            var hasWon = false;

            do
            {
                if (showMainMenu)
                {
                    Console.WriteLine("Let's play \"Minesweeper\"! Try your luck and uncover all free cells!" +
                    "\n\nType:\n -- 'top' to show the highscores list\n -- 'restart' to start a new game\n -- 'exit' to end the current game");
                    Engine.ShowField(playingField);
                    showMainMenu = false;
                }

                Console.Write("Input command or coordinates of your next move: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                    int.TryParse(command[2].ToString(), out currentColumn) &&
                        currentRow <= playingField.GetLength(0) && currentColumn <= playingField.GetLength(1))
                    {
                        command = "move";
                    }
                }

                switch (command)
                {
                    case "top":
                        Engine.ShowHighscores(topResults);
                        break;
                    case "restart":
                        playingField = Engine.GeneratePlayingField();
                        minefield = Engine.GenerateMinefield();
                        Engine.ShowField(playingField);
                        points = 0;
                        hasSteppedOnMine = false;
                        showMainMenu = false;
                        break;
                    case "exit":
                        Console.WriteLine("Thanks for playing \"Minesweeper\". Good bye!");
                        break;
                    case "move":
                        if (minefield[currentRow, currentColumn] != '*')
                        {
                            if (minefield[currentRow, currentColumn] == '-')
                            {
                                Engine.FillNumberOfNeighboringMines(playingField, minefield, currentRow, currentColumn);
                                points++;
                            }

                            if (points == MAX_RESULT)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                Engine.ShowField(playingField);
                            }
                        }
                        else
                        {
                            hasSteppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command.\n");
                        break;
                }

                if (hasSteppedOnMine)
                {
                    Engine.ShowField(minefield);
                    Console.Write("You stepped on a mine! Result: {0}\nEnter your nickname: ", points);
                    var nickname = Console.ReadLine();
                    var playerResult = new Result(nickname, points);

                    if (topResults.Count < 5)
                    {
                        topResults.Add(playerResult);
                    }
                    else
                    {
                        for (int i = 0; i < topResults.Count; i++)
                        {
                            if (topResults[i].Points < playerResult.Points)
                            {
                                topResults.Insert(i, playerResult);
                                topResults.RemoveAt(topResults.Count - 1);
                                break;
                            }
                        }
                    }

                    topResults.Sort((Result result1, Result result2) => result2.Name.CompareTo(result1.Name));
                    topResults.Sort((Result result1, Result result2) => result2.Points.CompareTo(result1.Points));
                    Engine.ShowHighscores(topResults);

                    // Reset the game.
                    playingField = Engine.GeneratePlayingField();
                    minefield = Engine.GenerateMinefield();
                    points = 0;
                    hasSteppedOnMine = false;
                    showMainMenu = true;
                }

                if (hasWon)
                {
                    Console.WriteLine("\nCongratulations! You uncovered all 35 cells without stepping on a mine!");
                    Engine.ShowField(minefield);
                    Console.WriteLine("Enter your nickname: ");
                    var nickname = Console.ReadLine();
                    var result = new Result(nickname, points);
                    topResults.Add(result);
                    Engine.ShowHighscores(topResults);

                    // Reset the game.
                    playingField = Engine.GeneratePlayingField();
                    minefield = Engine.GenerateMinefield();
                    points = 0;
                    hasWon = false;
                    showMainMenu = true;
                }
            }
            while (command != "exit");
        }
    }
}
