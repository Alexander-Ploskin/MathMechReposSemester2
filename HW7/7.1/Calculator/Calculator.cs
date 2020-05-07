using Calculator.Operators;
using Calculator.Statements;
using Calculator.States;
using System;

namespace Calculator
{
    /// <summary>
    /// FSM-Implementation of graphical calculator iterface 
    /// </summary>
    public class Calculator
    {
        public IOperator Operator { get; set; }
        public Number Number1 { get; }
        public Number Number2 { get; }

        public string ErrorMessage { get; set; } = "";

        private CalculatorState currentState;
        private StateTransitionTable stateTransitionTable;

        public Calculator()
        {
            Number1 = new Number();
            Number2 = new Number();
            Operator = new NullOperator();
            currentState = new FirstDigitOfNumber1State(this);
            stateTransitionTable = new StateTransitionTable(this);
        }

        /// <summary>
        /// Returns calculator to start of calculating
        /// </summary>
        public void Clear()
        {
            Operator = new NullOperator();
            Number1.Clear();
            Number2.Clear();
            ErrorMessage = "";
        }

        /// <summary>
        /// Current expression in calculator
        /// </summary>
        public string Expression { get => ErrorMessage + Number1.Value + Operator.Print() + Number2.Value; }

        /// <summary>
        /// Adds new symbol to calculator, ignores tokens, that calculator doesn't take  
        /// </summary>
        /// <param name="token">
        /// New symbol.
        /// Token = r means square root
        /// Token = s means sign
        /// Token = b means backspace
        /// Token = c means clear
        /// /// </param>
        public void Add(char token)
        {
            try
            {
                if (token == 'b')
                {
                    currentState = currentState.Backspace();
                    return;
                }
                currentState.Do(token);
                currentState = stateTransitionTable.DoTransition(currentState, token);
            }
            catch (ArgumentException)
            {
                return;
            }
            catch (DivideByZeroException)
            {
                Clear();
                ErrorMessage = "Divide by zero!";
                currentState = new ErrorMessageState(this);
            }
            catch (SqrtByNegativeNumberException)
            {
                Clear();
                ErrorMessage = "Sqrt by negative number!";
                currentState = new ErrorMessageState(this);
            }
        }

    }
}
