using Calculator.Statements;
using Calculator.States;
using System;

namespace Calculator
{
    /// <summary>
    /// Class that makes transitions between states of calculator
    /// </summary>
    class StateTransitionTable
    {
        public StateTransitionTable(Calculator calculator)
        {
            this.calculator = calculator;
        }

        private Calculator calculator;

        /// <summary>
        /// State transition table
        /// </summary>
        private int[,] table = new int[12, 7]
        {
           { 1, -1, 0,  -1, -1,  0, -1},
           { 1, 5, 1, 4, -1,  0, 2 },
           { 3, -1, 2, -1, -1,  0, -1 },
           { 3, 5, 3, 4, -1,  0, -1 },
           { 1, 5, 4, 4, -1,  0, -1 },
           { 6, -1, 5, -1, -1,  0, -1 },
           { 6, 5, 6, 9, 10, 0, 7 },
           { 8, -1, 7, -1, -1,  0, -1 },
           { 8, 5, 8, 9, 10, 0, -1 },
           { 6, 5, 9, 9, 10, 0, -1 },
           { 1, 5, 10, 4, -1,  0, -1 },
           { 1, -1, 0,  -1, -1,  0, -1 }
        };

        /// <summary>
        /// Gets number of token in table
        /// </summary>
        /// <param name="token">Input token</param>
        /// <returns>Number of column of input token in table</returns>
        private int GetNumberOfCharInTabble(char token)
        {
            if (char.IsDigit(token))
            {
                return 0;
            }
            if (GetTypeOfChar.IsOperator(token))
            {
                return 1;
            }
            switch (token)
            {
                case 's':
                    {
                        return 2;
                    }
                case 'r':
                    {
                        return 3;
                    }
                case '=':
                    {
                        return 4;
                    }
                case 'c':
                    {
                        return 5;
                    }
                case '.':
                    {
                        return 6;
                    }
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Creates new calculator state by its number in table
        /// </summary>
        /// <param name="number">Number in table</param>
        /// <returns>New state</returns>
        private CalculatorState CreateNewStateByNumber(int number)
        {
            switch (number)
            {
                case 0: return new FirstDigitOfNumber1State(calculator);
                case 1: return new FloorOfNumber1State(calculator);
                case 2: return new FirstDigitAfterPointOfNumber1State(calculator);
                case 3: return new FractionalPartOfNumber1State(calculator);
                case 4: return new InputedNumber1State(calculator);
                case 5: return new FirstDigitOfNumber2State(calculator);
                case 6: return new FloorOfNumber2State(calculator);
                case 7: return new FirstDigitAfterPointOfNumber2State(calculator);
                case 8: return new FractionalPartOfNumber2State(calculator);
                case 9: return new InputedNumber2State(calculator);
                case 10: return new JustCalculatedState(calculator);
                case 11: return new ErrorMessegeState(calculator);
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Does transition by current state and input token
        /// </summary>
        /// <param name="currentState">Current state of calculator</param>
        /// <param name="token">Input token</param>
        /// <returns>New state</returns>
        public CalculatorState DoTransition(CalculatorState currentState, char token)
            => CreateNewStateByNumber(table[currentState.NumberInStateTransitionTable, GetNumberOfCharInTabble(token)]);

    }
}
