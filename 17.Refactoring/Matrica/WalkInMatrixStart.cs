namespace WalkInMatrix
{
    using System;

    public class WalkInMatrixStart
    {
        public static void Main()
        {
            var step = 3;
            int[,] matrix = new int[step, step];
            int k = 1, i = 0, j = 0, dx = 1, dy = 1;

            while (true)
            { 
                matrix[i, j] = k;
                if (!ChangeMatrix.CheckingMatrix(matrix, i, j))
                {
                    break;
                }

                while (i + dx >= step || i + dx < 0 || j + dy >= step || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                {
                    ChangeMatrix.ChangeFieldOfMatrix(ref dx, ref dy);
                }

                i += dx; 
                j += dy; 
                k++;
            }

            for (var row = 0; row < step; row++)
            {
                for (var col = 0; col < step; col++)
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

                    while (i + dx >= step || i + dx < 0 || j + dy >= step || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        ChangeMatrix.ChangeFieldOfMatrix(ref dx, ref dy);
                    }

                    i += dx; 
                    j += dy; 
                    k++;
                }
            }

            for (var row = 0; row < step; row++)
            {
                for (var col = 0; col < step; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
