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


            bool flag = true;
            bool flag2 = false;

            int counter = 0;
            bool grum = false;
            int row = 0;
            int column = 0;
            const int maks = 35;

            do
            {
                if (flag)
                {
                    Console.WriteLine(Messages.WelcomeMessage + " " + Messages.HelpMessage);
                    Field.PrintMatrix(field);
                    flag = false;
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
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
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
                        grum = false;
                        flag = false;
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                tisinahod(field, bombs, row, column);
                                counter++;
                            }

                            if (maks == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                Field.PrintMatrix(field);
                            }
                        }
                        else
                        {
                            grum = true;
                        }

                        break;
                }

                if (grum)
                {
                    Field.PrintMatrix(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", counter);
                    string niknejm = Console.ReadLine();
                    Point t = new Point(niknejm, counter);
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
                    grum = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    Field.PrintMatrix(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Point points = new Point(imeee, counter);
                    champions.Add(points);
                    Rating.ViewRating(champions);
                    field = fields.CreatePlayingField();
                    bombs = Field.LayingBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine(Messages.MadeInBulgaria);
            Console.WriteLine(Messages.GoodBye);
        }
        

        private static void tisinahod(char[,] POLE, char[,] BOMBI, int RED, int KOLONA)
        {
            char kolkoBombi = kolko(BOMBI, RED, KOLONA);
            BOMBI[RED, KOLONA] = kolkoBombi;
            POLE[RED, KOLONA] = kolkoBombi;
        }

        

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = kolko(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char kolko(char[,] r, int rr, int rrr)
        {
            int brojkata = 0;
            int reds = r.GetLength(0);
            int kols = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rr + 1 < reds)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr + 1 < kols)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr + 1 < kols))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr + 1 < kols))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            return char.Parse(brojkata.ToString());
        }
    }
}