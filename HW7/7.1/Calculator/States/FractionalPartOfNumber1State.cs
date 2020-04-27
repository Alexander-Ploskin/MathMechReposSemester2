﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.States
{
    class FractionalPartOfNumber1State : CalculatorState
    {
        public FractionalPartOfNumber1State(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 3;

        protected override void DoInCaseOfDigit(char token) => calculator.Number1.Value += token;

        protected override void DoInCaseOfSign() => calculator.Number1.ChangeSign();

        protected override void DoInCaseOfSqrt() => calculator.Number1.CalculateSqrt();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        public override CalculatorState Backspace()
        {
            calculator.Number1.RemoveLastSymbol();
            if (calculator.Number1.Value[calculator.Number1.Value.Length - 1] == ',')
            {
                return new FirstDigitAfterPointOfNumber1State(calculator);
            }
            return this;
        }

    }
}
