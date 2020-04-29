using Calculator.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Implementation of lack of operator in calculator
    /// </summary>
    public class NullOperator : IOperator
    {
        /// <summary>
        /// Doesn't calculate
        /// </summary>
        public double Calculate(double number1, double number2) => throw new NotImplementedException();

        /// <summary>
        /// Prints empty
        /// </summary>
        /// <returns>Empty string</returns>
        public string Print() => "";

    }
}
