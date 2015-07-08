namespace Matrix
{
    using System;

    public class MatrixMultuply
    {
        public static void Main()
        {
            double[,] matrixOne = { { 1, 3 }, { 5, 7 } };
            double[,] matrixTwo = { { 4, 2 }, { 1, 5 } };
            try
            {
                var multipliedMatrix = MultiplyingMatrix(matrixOne, matrixTwo);

                PrintMatrix(multipliedMatrix);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultiplyingMatrix(double[,] matrixOne, double[,] matrixTwo)
        {
            if (matrixOne.GetLength(1) != matrixTwo.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var matrixOneColLength = matrixOne.GetLength(1);
            var newMatrix = new double[matrixOne.GetLength(0), matrixTwo.GetLength(1)];

            for (int row = 0; row < newMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < newMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < matrixOneColLength; i++)
                    {
                        newMatrix[row, col] += matrixOne[row, i] * matrixTwo[i, col];   
                    }
                }
            }
                
            return newMatrix;
        }
    }
}