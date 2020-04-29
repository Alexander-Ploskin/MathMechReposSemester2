using Calculator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    /// <summary>
    /// State of floor part of number2
    /// </summary>
    class FloorOfNumber2State : CalculatorState
    {
        public FloorOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 6;

        /// <summary>
        /// Adds new digit to number2
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        /// <summary>
        /// Changes sign of number2
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        /// <summary>
        /// Replace value of number2 by sqrt of number2
        /// </summary>
        protected override void DoInCaseOfSqrt() => calculator.Number2.CalculateSqrt();

        /// <summary>
        /// Adds point to number 2
        /// </summary>
        protected override void DoInCaseOfPoint() => calculator.Number2.Value += ',';

        /// <summary>
        /// Calculates expression in calculator
        /// </summary>
        protected override void DoInCaseOfCalculate() => calculator.Calculate();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        protected override void DoInCaseOfOperator(char token)
        {
            calculator.Calculate();
            SetOperator(token);
        }

        /// <summary>
        /// Removes last digit in number2 
        /// </summary>
        /// <returns>First digit of number 2 state if number 2 has only one digit, else this</returns>
        public override CalculatorState Backspace()
        {
            calculator.Number2.RemoveLastSymbol();
            if (calculator.Number2.Value.Length == 0)
            {
                return new FirstDigitOfNumber2State(calculator);
            }
            return this;
        }

    }
}
