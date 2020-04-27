using Calculator.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Statements
{
    class FirstDigitOfNumber2State : CalculatorState
    {
        public FirstDigitOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 5;

        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() =>  throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        public override CalculatorState Backspace()
        {
            calculator.Operator = null;
            return new InputedNumber1State(calculator);
        }

    }
}
