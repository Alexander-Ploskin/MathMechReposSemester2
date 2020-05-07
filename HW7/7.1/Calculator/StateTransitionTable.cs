using Calculator.Statements;
using Calculator.States;
using System;
using System.IO;

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
            LoadStateTransitionTable();
        }

        private Calculator calculator;

        private const int numberOfStates = 12;
        private const int numberOfRecievedSymbols = 7;

        /// <summary>
        /// State transition table
        /// </summary>
        private int[,] table = new int[numberOfStates, numberOfRecievedSymbols];

        /// <summary>
        /// Loads state transition table from the file
        /// </summary>
        private void LoadStateTransitionTable()
        {
            var path = Environment.CurrentDirectory.Clone() as string;
            int i = 0;
            while (path.Substring(i, 3) != "7.1")
            {
                i++;
            }
            path = path.Remove(i + 3);
            path += @"\Calculator\FSM Table.txt";

            using (var sr = new StreamReader(path))
            {
                int numberOfCurrentColumn = 0;

                sr.ReadLine();
                for (int numberOfCurrentRow = 0; numberOfCurrentRow < numberOfStates; ++numberOfCurrentRow)
                {
                    sr.Read();
                    string buffer = "";

                    string token = char.ConvertFromUtf32(sr.Read());

                    while (!sr.EndOfStream && token != "\n")
                    {
                        token = char.ConvertFromUtf32(sr.Read());

                        if (token == " ")
                        {
                            if (buffer != "")
                            {
                                table[numberOfCurrentRow, numberOfCurrentColumn] = int.Parse(buffer);
                                buffer = "";
                                numberOfCurrentColumn++;
                            }
                            continue;
                        }

                        buffer += token;
                    }

                    table[numberOfCurrentRow, numberOfCurrentColumn] = int.Parse(buffer);
                    numberOfCurrentColumn = 0;
                }
            }
        }

        /// <summary>
        /// Gets number of token in table
        /// </summary>
        /// <param name="token">Input token</param>
        /// <returns>Number of column of input token in table</returns>
        private int GetNumberOfCharInTable(char token)
        {
            if (char.IsDigit(token))
            {
                return 0;
            }
            if (RecogniserOfChar.IsOperator(token))
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
                case 11: return new ErrorMessageState(calculator);
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
            => CreateNewStateByNumber(table[currentState.NumberInStateTransitionTable, GetNumberOfCharInTable(token)]);

    }
}
