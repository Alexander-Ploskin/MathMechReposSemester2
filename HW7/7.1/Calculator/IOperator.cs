namespace Calculator
{
    /// <summary>
    /// Interface of operators in calculator
    /// </summary>
    public interface IOperator
    {
        /// <summary>
        /// Calculates two number
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of operation with two numbers</returns>
        double Calculate(double number1, double number2);

        /// <summary>
        /// Prints operator
        /// </summary>
        /// <returns>Sting with this</returns>
        string Print();
    }
}
