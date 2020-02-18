using System;

namespace Task5
{
    class Program
    {
        private static void BubbleSortOfColumns(int[,] matrix)
        {
            var numberOfColumns = matrix.GetLength(1);
            for (int i = 0; i < numberOfColumns; ++i)
            {
                for (int j = 0; j < numberOfColumns - i - 1; ++j)
                {
                    if (matrix[0, j] > matrix[0, j + 1])
                    {
                        for (int k = 0; k < matrix.GetLength(0); ++k)
                        {
                            var t = matrix[k, j];
                            matrix[k, j] = matrix[k, j + 1];
                            matrix[k, j + 1] = t;
                        }
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
                Console.WriteLine("");
            }
        }
        static void Main(string[] args)
        {
            int[,] testMatrix = { {1, -1, 0, 56, -3, -7, 5, 6, 12, -6 },
                                  {1,  2, 3, 4,   5,  6, 7, 8, 9,  10  } };

            BubbleSortOfColumns(testMatrix);
            printMatrix(testMatrix);
        }
    }
}
