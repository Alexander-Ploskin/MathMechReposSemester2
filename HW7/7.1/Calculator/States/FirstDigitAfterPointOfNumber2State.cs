using Calculator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class FirstDigitAfterPointOfNumber2State : CalculatorState
    {
        public FirstDigitAfterPointOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 7;

        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        public override CalculatorState Backspace()
        {
            calculator.Number2.RemoveLastSymbol();
            return new FloorOfNumber2State(calculator);
        }

    }
}
