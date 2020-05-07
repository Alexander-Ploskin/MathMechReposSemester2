namespace Calculator.Operators
{
    /// <summary>
    /// Implementation of multiplication for calculator
    /// </summary>
    public class Multiplication : IOperator
    {
        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of multiplication</returns>
        public double Calculate(double number1, double number2) => number1 * number2;

        /// <summary>
        /// Prints this 
        /// </summary>
        /// <returns>String with *</returns>
        public string Print() => " * ";

    }
}
