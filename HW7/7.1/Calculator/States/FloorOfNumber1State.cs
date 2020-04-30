using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Statements
{
    /// <summary>
    /// State of floor part of number1
    /// </summary>
    class FloorOfNumber1State : CalculatorState
    {
        public FloorOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 1;

        /// <summary>
        /// Adds digit to number1
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        /// <summary>
        /// Changes sign of number1
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        /// <summary>
        /// Replace value of number1 by sqrt of number1
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        /// <summary>
        /// Adds point to number1
        /// </summary>
        protected override void DoInCaseOfPoint() => calculator.Number1.Value += '.';

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        /// <summary>
        /// Sets new operator in calculator
        /// </summary>
        protected override void DoInCaseOfOperator(char token) => SetOperator(token);

        /// <summary>
        /// Removes last digit in number1
        /// </summary>
        /// <returns>First digit of number 1 state if number 1 has only one digit, else this</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number1.RemoveLastSymbol();
            if (calculator.Number1.Value.Length == 0)
            {
                return new FirstDigitOfNumber1State(calculator);
            }
            return this;
        }

    }
}
