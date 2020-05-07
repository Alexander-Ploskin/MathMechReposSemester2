using System;

namespace Calculator.States
{
    /// <summary>
    /// State after point's input in number1 
    /// </summary>
    class FirstDigitAfterPointOfNumber2State : CalculatorState
    {
        public FirstDigitAfterPointOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 7;

        /// <summary>
        /// Adds new digit to number2 
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        /// <summary>
        /// Changes sign of number2
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        /// <summary>
        /// Removes point
        /// </summary>
        /// <returns>Floor of number2 state</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number2.RemoveLastSymbol();
            return new FloorOfNumber2State(calculator);
        }

    }
}
