using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class FloorOfNumber2State : CalculatorState
    {
        public FloorOfNumber2State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 6;

        protected override void DoInCaseOfDigit(char token) => calculator.Number2.Value += token;

        protected override void DoInCaseOfSign() => calculator.Number2.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number2.CalculateSqrt();

        protected override void DoInCaseOfPoint() => calculator.Number2.Value += ',';

        protected override void DoInCaseOfCalculate() => calculator.Calculate();

        protected override void DoInCaseOfOperator(char token)
        {
            calculator.Calculate();
            base.DoInCaseOfOperator(token);
        }

        public override CalculatorState Backspace()
        {
            calculator.Number2.RemoveLastSymbol();
            if (calculator.Number2.Value.Length == 0)
            {
                return new FirstDigitAfterPointOfNumber2State(calculator);
            }
            return this;
        }

    }
}
