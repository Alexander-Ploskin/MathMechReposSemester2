using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class InputedNumber1State : CalculatorState
    {
        public InputedNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 4;

        protected override void DoInCaseOfDigit(char token) => throw new ArgumentException();

        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        public override CalculatorState Backspace() => this;

    }
}
