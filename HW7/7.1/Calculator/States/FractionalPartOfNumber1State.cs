using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    /// <summary>
    /// State of fractional part of number1
    /// </summary>
    class FractionalPartOfNumber1State : CalculatorState
    {
        public FractionalPartOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 3;

        /// <summary>
        /// Adds new digit of number1
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

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        /// <summary>
        /// Sets new operator 
        /// </summary>
        protected override void DoInCaseOfOperator(char token) => SetOperator(token);

        /// <summary>
        /// Removes last digit of number1
        /// </summary>
        /// <returns>First digit after point of number 1 if number 1 has only one digit after point, else this</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number1.RemoveLastSymbol();
            if (calculator.Number1.Value[calculator.Number1.Value.Length - 1] == ',')
            {
                return new FirstDigitAfterPointOfNumber1State(calculator);
            }
            return this;
        }

    }
}
