namespace WalkInMatrix
{
    using System;

    public class WalkInMatrix
    {
        public static void Main()
        {
            int number = 3;
            int[,] matrix = new int[number, number];
            int k = 1, i = 0, j = 0, dx = 1, dy = 1;

            while (true)
            { 
                matrix[i, j] = k;
                if (!ChangeMatrix.CheckingMatrix(matrix, i, j))
                {
                    break;
                }

                while (i + dx >= number || i + dx < 0 || j + dy >= number || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                {
                    ChangeMatrix.ChangeFieldOfMatrix(ref dx, ref dy);
                }

                i += dx; 
                j += dy; 
                k++;
            }

            for (var row = 0; row < number; row++)
            {
                for (var col = 0; col < number; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            ChangeMatrix.FindCell(matrix, out i, out j);

            if (i != 0 && j != 0)
            {
                dx = 1; 
                dy = 1;

                while (true)
                {
                    matrix[i, j] = k;
                    if (!ChangeMatrix.CheckingMatrix(matrix, i, j))
                    {
                        break;
                    }

                    while (i + dx >= number || i + dx < 0 || j + dy >= number || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        ChangeMatrix.ChangeFieldOfMatrix(ref dx, ref dy);
                    }

                    i += dx; 
                    j += dy; 
                    k++;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
