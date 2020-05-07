using System;

namespace Task2
{
    class Program
    {
        private static int CalculatingOfFiboncci(int number)
        {
            if (number < 2)
            {
                return 1;
            }

            int[] buffer = new int[3] { 0, 1, 1 };

            for (int i = 0; i < number - 2; ++i)
            {
                buffer[0] = buffer[1];
                buffer[1] = buffer[2];
                buffer[2] = buffer[0] + buffer[1];
            }

            return buffer[2];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the natural number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"{number}th Fibonacci number is {CalculatingOfFiboncci(number)}");
        }
    }
}
