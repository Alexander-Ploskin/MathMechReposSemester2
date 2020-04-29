﻿using Calculator.Statements;
using System;

namespace Calculator.States
{
    class ErrorMessegeState : CalculatorState
    {
        public ErrorMessegeState(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public override int NumberInStateTransitionTable { get; } = 11;

        protected override void DoInCaseOfDigit(char token)
        {
            calculator.ErrorMessege = "";
            calculator.Number1.Value += token;
        }

        protected override void DoInCaseOfSign()
        {
            calculator.ErrorMessege = "";
            calculator.Number1.ChangeSign();
        }

        protected override void DoInCaseOfSqrt() => throw new ArgumentException();

        protected override void DoInCaseOfPoint() => throw new ArgumentException();

        protected override void DoInCaseOfCalculate() => throw new ArgumentException();

        protected override void DoInCaseOfOperator(char token) => throw new ArgumentException();

        public override CalculatorState Backspace()
        {
            calculator.ErrorMessege = "";
            return new FirstDigitOfNumber1State(calculator);
        }

    }
}
