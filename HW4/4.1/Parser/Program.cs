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
            parser.ParseExpression(expression);
            try
            {
                Console.WriteLine($"Answer: {parser.CalculateParsedException()}");
            }
            catch (NotCorrectOrNotParsedExpressionException)
            {
                Console.WriteLine("Not correct expression");
            }
        }
    }
}
