using Calculator.Operators;
using Calculator.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Statements
{
    /// <summary>
    /// State of inputed number1 and operator
    /// </summary>
    class FirstDigitOfNumber2State : CalculatorState
    {
        public FirstDigitOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 5;

        /// <summary>
        /// Adds new digit to number2
        /// </summary>
        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        /// <summary>
        /// Changes sign of number2
        /// </summary>
        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        //Other cases doesn't have implementation

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() =>  throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        /// <summary>
        /// Removes operator or sign if in was inputed
        /// </summary>
        /// <returns>Inputed number1 state or this</returns>
        public override CalculatorState Backspace()
        {
            if (calculator.Number2.Value.Length != 0)
            {
                calculator.Number2.RemoveLastSymbol();
                return this;
            }
            calculator.Operator = new NullOperator();
            return new InputedNumber1State(calculator);
        }

    }
}
