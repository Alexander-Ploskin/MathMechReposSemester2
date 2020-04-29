using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    /// <summary>
    /// State of fractional part of number2
    /// </summary>
    class FractionalPartOfNumber2State : CalculatorState
    {
        public FractionalPartOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 8;

        /// <summary>
        /// Adds new digit to number2
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        /// <summary>
        /// Changes sign of number2
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        /// <summary>
        /// Replace value of number1 by sqrt of number2
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number2.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        /// <summary>
        /// Calculates expression
        /// </summary>
        protected override void DoInCaseOfCalculate() => calculator.Calculate();

        /// <summary>
        /// Calculates expression and sets new operator
        /// </summary>
        /// <param name="token">new operator</param>
        protected override void DoInCaseOfOperator(char token)
        {
            calculator.Calculate();
            SetOperator(token);
        }

        /// <summary>
        /// Removes last digit of number2
        /// </summary>
        /// <returns>First digit afetr point of number2 state if number 2 has only one digit after point, else this</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number2.RemoveLastSymbol();
            if (calculator.Number2.Value[calculator.Number2.Value.Length - 1] == ',')
            {
                return new FirstDigitAfterPointOfNumber2State(calculator);
            }
            return this;
        }

    }
}
