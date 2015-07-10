namespace Mines.Models
{
    using System;
    using System.Collections.Generic;

    public class Field
    {
        private const char BoardCharStart = '?';
        private const int BoardRows = 5;
        private const int BoardColumns = 10;

        private char[,] board = new char[BoardRows, BoardColumns];

        public static char[,] LayingBombs()
        {
            char[,] board = new char[BoardRows, BoardColumns];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int kol = i2 / BoardColumns;
                int red = i2 % BoardColumns;
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = BoardColumns;
                }
                else
                {
                    red++;
                }

                board[kol, red - 1] = '*';
            }

            return board;
        }

        public static void PrintMatrix(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public char[,] CreatePlayingField()
        {
            // scan matrix and load start char in board
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    this.board[i, j] = BoardCharStart;
                }
            }

            return this.board;
        }
    }
}
