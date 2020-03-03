using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator works with integer only! Enter the correct arithmetic expression in postfix notation :");
            string inputString = Console.ReadLine();
            Console.WriteLine("If you prefer ListStack enter 1, else if you prefer ArrayStack enter 2: ");
            string choose = Console.ReadLine();
            while (choose != "1" && choose != "2")
            {
                Console.WriteLine("Enter 1 or 2!");
                choose = Console.ReadLine();
            }

            IStack stackForCalculator = new ArrayStack();

            if (choose == "1")
            {
                stackForCalculator = new ListStack();
            }

            (int result, bool isSuccessful) = Calculator.Calculate(inputString, stackForCalculator);
            if (!isSuccessful)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"Answer: {result}");
            }
        }
    }
}
