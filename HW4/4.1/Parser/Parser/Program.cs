using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the expression in polish notation:");
            var expression = Console.ReadLine();

            try
            {
                var expressionTree = Parser.ParseExpression(expression);
                Console.WriteLine("Parsed expression");
                expressionTree.PrintExpression();
                Console.WriteLine();
                Console.WriteLine($"Answer: {expressionTree.CalculateExpression()}");
            }
            catch (InvalidExpressionException)
            {
                Console.WriteLine("Not correct expression");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero!");
            }
            catch (NotCorrectExpressionException)
            {
                Console.WriteLine("Not correct expression");
            }
        }

    }
}
