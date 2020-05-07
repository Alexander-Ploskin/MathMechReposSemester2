namespace Calculator
{
    /// <summary>
    /// Includes methods for distinction of chars
    /// </summary>
    static class RecogniserOfChar
    {
        /// <summary>
        /// Checks, is char operator
        /// </summary>
        /// <param name="token">Input char</param>
        /// <returns>True if token is operator, else false</returns>
        public static bool IsOperator(char token) => token == '*' || token == '+' || token == '-' || token == '/';

    }
}
