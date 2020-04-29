using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Implementation of addition for calculator
    /// </summary>
    public class Addition : IOperator
    {
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of addition</returns>
        public double Calculate(double number1, double number2) => number1 + number2;

        /// <summary>
        /// Prints this 
        /// </summary>
        /// <returns>String with +</returns>
        public string Print() => " + ";

    }
}
