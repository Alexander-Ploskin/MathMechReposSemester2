using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class InputedNumber2State : CalculatorState
    {
        public InputedNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 9;

        protected override void DoInCaseOfDigit(char token) => throw new ArgumentException();

        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number2.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => calculator.Calculate();

        protected override void DoInCaseOfOperator(char token)
        {
            calculator.Calculate();
            base.DoInCaseOfOperator(token);
        }

        public override CalculatorState Backspace() => this;

    }
}
