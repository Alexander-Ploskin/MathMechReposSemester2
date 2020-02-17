using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static int CalculatingOfFactotial(int number)
        {
            if (number < 2)
            {
                return 1;
            }

            return number * CalculatingOfFactotial(number - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Factorial of {number} is {CalculatingOfFactotial(number)}");
        }
    }
}
