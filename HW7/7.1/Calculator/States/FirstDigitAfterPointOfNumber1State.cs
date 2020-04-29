using Calculator.Statements;
using System;

namespace Calculator.States
{
    /// <summary>
    /// State after point's input in number1 
    /// </summary>
    class FirstDigitAfterPointOfNumber1State : CalculatorState
    {
        public FirstDigitAfterPointOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 2;

        /// <summary>
        /// Adds new digit to number1
        /// </summary>
        /// <param name="token"></param>
        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        /// <summary>
        /// Changes sign of number1 
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        //Other cases doesn't have implementation

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        /// <summary>
        /// Removes point
        /// </summary>
        /// <returns>Floor of number1 state</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number1.RemoveLastSymbol();
            return new FloorOfNumber1State(calculator);
        }

    }
}
