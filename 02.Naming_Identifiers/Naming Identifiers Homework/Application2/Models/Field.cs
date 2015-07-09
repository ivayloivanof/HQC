namespace Mines.Models
{
    using System;
    using System.Collections.Generic;

    public class Field
    {
        private const char BoardCharStart = '?';
        private const int BoardRows = 5;
        private const int BoardColumns = 10;

        public static char[,] CreatePlayingField()
        {
            char[,] board = new char[BoardRows, BoardColumns];

            // scan matrix and print board
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = BoardCharStart;
                }
            }

            return board;
        }

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
    }
}
