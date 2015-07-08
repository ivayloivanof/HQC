using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            double[,] matrixOne = new double[,] { { 1, 3 }, { 5, 7 } };
            double[,] matrixTwo = new double[,] { { 4, 2 }, { 1, 5 } };
            var r = MultiplyMatrix(matrixOne, matrixTwo);

            for (int ii = 0; ii < r.GetLength(0); ii++)
            {
                for (int jj = 0; jj < r.GetLength(1); jj++)
                {
                    Console.Write(r[ii, jj] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MultiplyMatrix(double[,] matrixOne, double[,] matrixTwo)
        {
            if (matrixOne.GetLength(1) != matrixTwo.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var matrixOneRowCount = matrixOne.GetLength(1);
            var newMatrix = new double[matrixOne.GetLength(0), matrixTwo.GetLength(1)];

            for (int row = 0; row < newMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < newMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < matrixOneRowCount; i++)
                    {
                        newMatrix[row, col] += matrixOne[row, i] * matrixTwo[i, col];   
                    }
                }
            }
                
            return newMatrix;
        }
    }
}