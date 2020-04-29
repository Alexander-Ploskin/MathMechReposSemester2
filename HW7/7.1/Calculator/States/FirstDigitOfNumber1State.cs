using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Statements
{
    /// <summary>
    /// Start state of calculation
    /// </summary>
    class FirstDigitOfNumber1State : CalculatorState
    {
        public FirstDigitOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 0;

        /// <summary>
        /// Adds digit to number1
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        /// <summary>
        /// Changes sign of number1
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <returns>This</returns>
        public override CalculatorState Backspace() => this;

    }
}
