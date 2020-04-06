using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the expression in polish notation:");
            var expression = Console.ReadLine();
            var parser = new Parser();
            try
            {
                parser.ParseExpression(expression);
                Console.WriteLine("Parsed expression");
                parser.PrintParsedExpression();
                Console.WriteLine();
                Console.WriteLine($"Answer: {parser.CalculateParsedExpression()}");
            }
            catch (InvalidExpressionException)
            {
                Console.WriteLine("Not correct expression");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero!");
            }
            catch (NotParsedExpressionException)
            {
                Console.WriteLine("Not correct expression");
            }
        }
    }
}
