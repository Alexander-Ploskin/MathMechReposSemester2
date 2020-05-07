using Calculator.Statements;
using System;

namespace Calculator.States
{
    /// <summary>
    /// State of ready result 
    /// </summary>
    class JustCalculatedState : CalculatorState
    {
        public JustCalculatedState(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 10;

        /// <summary>
        /// Starts new calculation
        /// </summary>
        /// <param name="token">First digit of number1</param>
        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value = token.ToString();

        /// <summary>
        /// Changes sign of result 
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        /// <summary>
        /// Replaces number1 by sqrt of number1
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        /// <summary>
        /// Sets new operator
        /// </summary>
        /// <param name="token"></param>
        protected override void DoInCaseOfOperator(char token) => SetOperator(token);

        /// <summary>
        /// Starts new calculation
        /// </summary>
        /// <returns>First digit of number1 state</returns>
        public override CalculatorState Backspace()
        {
            calculator.Clear();
            return new FirstDigitOfNumber1State(calculator);
        }

    }
}
