using Calculator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class JustCalculatedState : CalculatorState
    {
        public JustCalculatedState(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 10;

        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value = token.ToString();

        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        public override CalculatorState Backspace()
        {
            calculator.Clear();
            return new FirstDigitOfNumber1State(calculator);
        }

    }
}
