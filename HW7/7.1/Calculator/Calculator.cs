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

        public string ErrorMessege { get; set; } = "";

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
        /// Returns calculator to start state
        /// </summary>
        public void Clear()
        {
            Operator = new NullOperator();
            Number1.Clear();
            Number2.Clear();
            ErrorMessege = "";
        }

        /// <summary>
        /// Current expression in calculator
        /// </summary>
        public string Expression { get => ErrorMessege + Number1.Value + Operator.Print() + Number2.Value; }

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
                ErrorMessege = "Divide by zero!";
                currentState = new ErrorMessegeState(this);
            }
            catch (SqrtByNegativeNumberException)
            {
                Clear();
                ErrorMessege = "Sqrt by negative number!";
                currentState = new ErrorMessegeState(this);
            }
        }

    }
}
