using Calculator.Operators;
using Calculator.Statements;
using Calculator.States;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Calculator
{
    public class Calculator
    {
        public IOperator Operator { get; set; }
        public Number Number1 { get; }
        public Number Number2 { get; }

        public string ErrorMessege { get; set; }

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

        public void Clear()
        {
            Operator = new NullOperator();
            Number1.Clear();
            Number2.Clear();
            ErrorMessege = "";
        }

        public string Expression
        {
            get
            {
                if (ErrorMessege != "")
                {
                    return ErrorMessege;
                }
                return Number1.Value + Operator.Print() + Number2.Value;
            }
        }

        public void Calculate()
        {
            Number1.Value = Operator.Calculate().ToString();
            Number2.Value = "";
            Operator = null;
        }

        public void Add(char token)
        {
            try
            {
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
