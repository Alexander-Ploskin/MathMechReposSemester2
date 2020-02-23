using System;

namespace Task5
{
    class Program
    {

        private static void SwapOfColumns(int[,] matrix, int index1, int index2)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                var t = matrix[i, index2];
                matrix[i, index2] = matrix[i, index1];
                matrix[i, index1] = t;
            }
        }

        private static void BubbleSortOfColumns(int[,] matrix)
        {
            var numberOfColumns = matrix.GetLength(1);
            for (int i = 0; i < numberOfColumns; ++i)
            {
                for (int j = 0; j < numberOfColumns - i - 1; ++j)
                {
                    if (matrix[0, j] > matrix[0, j + 1])
                    {
                        SwapOfColumns(matrix, j, j + 1);
                    }
                }
            }
        }

        private static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void Main(string[] args)
        {
            int[,] testMatrix = { {1, -1, 0, 56, -3, -7, 5, 6, 12, -6 },
                                  {1,  2, 3, 4,   5,  6, 7, 8, 9,  10  } };

            BubbleSortOfColumns(testMatrix);
            printMatrix(testMatrix);
        }
    }
}
