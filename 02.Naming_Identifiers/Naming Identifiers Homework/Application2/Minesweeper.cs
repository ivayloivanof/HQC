namespace Mines
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class Minesweeper
    {
        private static void Main()
        {
            string command = string.Empty;
            List<Point> champions = new List<Point>(6);
            Field fields = new Field();

            char[,] field = fields.CreatePlayingField();
            char[,] bombs = Field.LayingBombs();

            bool startGame = true;
            bool startNewGame = false;
            bool endGame = false;

            int counter = 0;
            int row = 0;
            int column = 0;
            const int Max = 35;

            do
            {
                if (startGame)
                {
                    Console.WriteLine(Messages.WelcomeMessage + " " + Messages.HelpMessage);
                    Field.PrintMatrix(field);
                    startGame = false;
                }

                if (startNewGame)
                {
                    Console.WriteLine(Messages.Bravo);
                    Field.PrintMatrix(bombs);
                    Console.WriteLine(Messages.GiveYourName);
                    string name = Console.ReadLine();
                    Point points = new Point(name, counter);
                    champions.Add(points);
                    Rating.ViewRating(champions);

                    // create new field (board)
                    field = fields.CreatePlayingField();
                    bombs = Field.LayingBombs();
                    counter = 0;
                    startNewGame = false;
                    startGame = true;
                }

                if (endGame)
                {
                    Field.PrintMatrix(bombs);
                    Console.Write(Messages.EndGame, counter);
                    string name = Console.ReadLine();
                    Point t = new Point(name, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Point r1, Point r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Point r1, Point r2) => r2.Points.CompareTo(r1.Points));
                    Rating.ViewRating(champions);

                    field = fields.CreatePlayingField();
                    bombs = Field.LayingBombs();
                    counter = 0;
                    endGame = false;
                    startGame = true;
                }

                Console.Write(Messages.GiveRowAndColumn);
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    command = readLine.Trim();
                    if (command == "exit")
                    {
                        break;
                    }
                }

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && 
                        int.TryParse(command[2].ToString(), out column) && 
                        row <= field.GetLength(0) && 
                        column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating.ViewRating(champions);
                        break;
                    case "restart":
                        field = fields.CreatePlayingField();
                        bombs = Field.LayingBombs();
                        Field.PrintMatrix(field);
                        endGame = false;
                        startGame = false;
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                Move(field, bombs, row, column);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                startNewGame = true;
                            }
                            else
                            {
                                Field.PrintMatrix(field);
                            }
                        }
                        else
                        {
                            endGame = true;
                        }

                        break;
                }
            }
            while (command != "exit");
            Console.WriteLine(Messages.MadeInBulgaria);
            Console.WriteLine(Messages.GoodBye);
        }
        
        private static void Move(char[,] board, char[,] bombs, int row, int col)
        {
            char kolkoBombi = AgregationOfPiecesPoints(bombs, row, col);
            bombs[row, col] = kolkoBombi;
            board[row, col] = kolkoBombi;
        }
        
        private static char AgregationOfPiecesPoints(char[,] board, int row, int col)
        {
            int piece = 0;
            int rowAll = board.GetLength(0);
            int colAll = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    piece++;
                }
            }

            if (row + 1 < rowAll)
            {
                if (board[row + 1, col] == '*')
                {
                    piece++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    piece++;
                }
            }

            if (col + 1 < colAll)
            {
                if (board[row, col + 1] == '*')
                {
                    piece++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    piece++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < colAll))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    piece++;
                }
            }

            if ((row + 1 < rowAll) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    piece++;
                }
            }

            if ((row + 1 < rowAll) && (col + 1 < colAll))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    piece++;
                }
            }

            return char.Parse(piece.ToString());
        }
    }
}