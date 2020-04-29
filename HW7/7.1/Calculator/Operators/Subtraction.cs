using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Implementation of subtraction for calculator
    /// </summary>
    public class Subtraction : IOperator
    {
        /// <summary>
        /// Subtracts second number by first
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of subtraction</returns>
        public double Calculate(double number1, double number2) => number1 - number2;

        /// <summary>
        /// Prints this 
        /// </summary>
        /// <returns>String with -</returns>
        public string Print() => " - ";

    }
}
