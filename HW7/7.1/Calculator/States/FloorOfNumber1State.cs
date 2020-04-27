using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Statements
{
    class FloorOfNumber1State : CalculatorState
    {
        public FloorOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 1;

        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => calculator.Number1.Value += ',';

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

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
