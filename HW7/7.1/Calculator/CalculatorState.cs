using Calculator.Operators;
using System;

namespace Calculator
{
    /// <summary>
    /// General class of all states
    /// </summary>
    abstract class CalculatorState
    {
        protected Calculator calculator;

        public abstract int NumberInStateTransitionTable { get; }

        /// <summary>
        /// Do something with calculator in case of token
        /// </summary>
        /// <param name="token">Input token</param>
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
                case '.':
                    {
                        DoInCaseOfPoint();
                        return;
                    }
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Removes one symbol from calculator
        /// </summary>
        /// <returns>State after removing</returns>
        public abstract CalculatorState Backspace();

        /// <summary>
        /// Sets new operator in calculator
        /// </summary>
        /// <param name="token">New operator</param>
        protected void SetOperator(char token)
        {
            switch (token)
            {
                case '+':
                    {
                        calculator.Operator = new Addition();
                        return;
                    }
                case '-':
                    {
                        calculator.Operator = new Subtraction();
                        return;
                    }
                case '*':
                    {
                        calculator.Operator = new Multiplication();
                        return;
                    }
                case '/':
                    {
                        calculator.Operator = new Division();
                        return;
                    }
            }
        }

        /// <summary>
        /// Calculates expression
        /// </summary>
        public void Calculate()
        {
            calculator.Number1.Value = calculator.Operator.Calculate(double.Parse(calculator.Number1.Value), double.Parse(calculator.Number2.Value)).ToString();
            calculator.Number2.Value = "";
            calculator.Operator = new NullOperator();
        }

        /// <summary>
        /// Something, that calculator does in case of input token is digit
        /// </summary>
        /// <param name="token"></param>
        protected abstract void DoInCaseOfDigit(char token);

        protected abstract void DoInCaseOfSign();

        protected abstract void DoInCaseOfSqrt();

        protected abstract void DoInCaseOfPoint();

        protected abstract void DoInCaseOfCalculate();

        protected abstract void DoInCaseOfOperator(char token);

    }
}
