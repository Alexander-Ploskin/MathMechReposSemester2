using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the correct arithmetic expression in postfix notation:");
            string inputString = Console.ReadLine();
            bool isSuccessful = true;
            int result = Calculator.Calculating(inputString, ref isSuccessful);
            if (!isSuccessful)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine("Answer: {0}", result);
            }
        }
    }
}
