using System;

namespace Calculator.States
{
    /// <summary>
    /// State of inputed number2
    /// </summary>
    class InputedNumber2State : CalculatorState
    {
        public InputedNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 9;

        /// <summary>
        /// Starts input of new number2
        /// </summary>
        /// <param name="token">First digit of new number2</param>
        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value = token.ToString();

        /// <summary>
        /// Changes sign of number2
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        /// <summary>
        /// Replaces number2 by sqrt of number2
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number2.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        /// <summary>
        /// Calculates expression
        /// </summary>
        protected override void DoInCaseOfCalculate() => Calculate();

        /// <summary>
        /// Calculates expression and sets new operator
        /// </summary>
        /// <param name="token">New operator</param>
        protected override void DoInCaseOfOperator(char token)
        {
            Calculate();
            SetOperator(token);
        }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <returns>This</returns>
        public override CalculatorState Backspace() => this;

    }
}
