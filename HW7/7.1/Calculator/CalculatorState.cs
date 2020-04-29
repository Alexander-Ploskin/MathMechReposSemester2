using Calculator.Operators;
using System;

namespace Calculator
{
    abstract class CalculatorState
    {
        protected Calculator calculator;

        public abstract int NumberInStateTransitionTable { get; }

        public void Do(char token)
        {
            if (char.IsDigit(token))
            {
                DoInCaseOfDigit(token);
                return;
            }
            
            if (GetTypeOfChar.IsOperator(token))
            {
                DoInCaseOfOperator(token);
                return;
            }

            switch (token)
            {
                case 's':
                    {
                        DoInCaseOfSign();
                        return;
                    }
                case 'r':
                    {
                        DoInCaseOfSqrt();
                        return;
                    }
                case '=':
                    {
                        DoInCaseOfCalculate();
                        return;
                    }
                case 'c':
                    {
                        calculator.Clear();
                        return;
                    }
                case ',':
                    {
                        DoInCaseOfPoint();
                        return;
                    }
            }

            throw new ArgumentException();
        }

        public abstract CalculatorState Backspace();

        protected void SetOperator(char token)
        {
            switch (token)
            {
                case '+':
                    {
                        calculator.Operator = new Addition(calculator);
                        return;
                    }
                case '-':
                    {
                        calculator.Operator = new Subtraction(calculator);
                        return;
                    }
                case '*':
                    {
                        calculator.Operator = new Multiplication(calculator);
                        return;
                    }
                case '/':
                    {
                        calculator.Operator = new Division(calculator);
                        return;
                    }
            }
        }

        protected abstract void DoInCaseOfDigit(char token);

        protected abstract void DoInCaseOfSign();

        protected abstract void DoInCaseOfSqrt();

        protected abstract void DoInCaseOfPoint();

        protected abstract void DoInCaseOfCalculate();

        protected abstract void DoInCaseOfOperator(char token);

    }
}
