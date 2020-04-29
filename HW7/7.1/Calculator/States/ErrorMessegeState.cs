using Calculator.Statements;
using System;

namespace Calculator.States
{
    /// <summary>
    /// State of error messege in calculator
    /// </summary>
    class ErrorMessegeState : CalculatorState
    {
        public ErrorMessegeState(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 11;

        /// <summary>
        /// Inputs new number
        /// </summary>
        protected override void DoInCaseOfDigit(char token)
        {
            calculator.ErrorMessege = "";
            calculator.Number1.Value += token;
        }

        /// <summary>
        /// Inputs sign of new number
        /// </summary>
        protected override void DoInCaseOfSign()
        {
            calculator.ErrorMessege = "";
            calculator.Number1.ChangeSign();
        }

        //Other cases doesn't have implementation

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        /// <summary>
        /// Returns calculator to start state
        /// </summary>
        /// <returns>New start state</returns>
        public override CalculatorState Backspace()
        {
            calculator.ErrorMessege = "";
            return new FirstDigitOfNumber1State(calculator);
        }

    }
}
