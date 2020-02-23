using System;

namespace Task4
{
    class Program
    {
        static void PrintMatrixSpiral(int[,] matrix)
        {
            int sizeOfMatrix = matrix.GetLength(0);
            int abscissa = sizeOfMatrix / 2;
            int ordinate = sizeOfMatrix / 2;
            int step = 1;

            while (true)
            {
                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[ordinate, abscissa]} ");
                    abscissa++;
                }

                if (ordinate == sizeOfMatrix - 1)
                {
                    return;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[ordinate, abscissa]} ");
                    ordinate--;
                }

                step++;

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[ordinate, abscissa]} ");
                    abscissa--;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[ordinate, abscissa]} ");
                    ordinate++;
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
