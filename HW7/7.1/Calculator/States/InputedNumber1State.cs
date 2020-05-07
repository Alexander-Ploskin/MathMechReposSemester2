using System;

namespace Calculator.States
{
    /// <summary>
    /// State of inputed number1
    /// </summary>
    class InputedNumber1State : CalculatorState
    {
        public InputedNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 4;

        /// <summary>
        /// Starts new calculation
        /// </summary>
        protected override void DoInCaseOfDigit(char token)
        {
            calculator.Clear();
            calculator.Number1.Value += token;
        }

        /// <summary>
        /// Changes sign of number1
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        /// <summary>
        /// Replace value of number1 by sqrt of number1
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        /// <summary>
        /// Sets new operator
        /// </summary>
        protected override void DoInCaseOfOperator(char token) => SetOperator(token);

        /// <summary>
        /// Do nothing
        /// </summary>
        public override CalculatorState Backspace() => this;

    }
}
