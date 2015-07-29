namespace WalkInMatrix
{
    public static class ChangeMatrix
    {
        private static int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static void ChangeFieldOfMatrix(ref int dx, ref int dy)
        { 
            var cd = 0;

            for (var count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0]; 
                dy = dirY[0]; 
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        public static bool CheckingMatrix(int[,] arr, int x, int y)
        {
            for (var i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (var i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (var row = 0; row < arr.GetLength(0); row++)
            {
                for (var col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        x = row; 
                        y = col; 
                        return;
                    }
                }
            }
        }
    }
}
