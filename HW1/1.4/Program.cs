using System;

namespace Task4
{
    class Program
    {
        static void PrintMatrixSpiral(int[,] matrix)
        {
            int sizeOfMatrix = matrix.GetLength(0);
            int index1 = sizeOfMatrix / 2;
            int index2 = sizeOfMatrix / 2;
            int step = 1;

            while (true)
            {
                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[index2, index1]} ");
                    index1++;
                }

                if (index2 == sizeOfMatrix - 1)
                {
                    return;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[index2, index1]} ");
                    index2--;
                }

                step++;

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[index2, index1]} ");
                    index1--;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[index2, index1]} ");
                    index2++;
                }

                step++;
            }
        }
        static void Main(string[] args)
        {
            int[,] testMatrix = new int[5, 5] { { 17, 16, 15, 14, 13 },
                                                { 18, 5, 4, 3, 12 },
                                                { 19, 6, 1, 2, 11 },
                                                { 20, 7, 8, 9, 10 },
                                                { 21, 22, 23, 24, 25 } };

            PrintMatrixSpiral(testMatrix);
        }
    }
}
