using System;

namespace Calculator.Operators
{
    /// <summary>
    /// Implementation of division for calculator
    /// </summary>
    public class Division : IOperator
    {
        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of division</returns>
        public double Calculate(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException();
            }
            return number1 / number2;
        }

        /// <summary>
        /// Prints this 
        /// </summary>
        /// <returns>String with /</returns>
        public string Print() => " / ";

    }
}
