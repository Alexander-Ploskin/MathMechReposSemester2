using Calculator.Operators;
using Calculator.Statements;
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
    class Calculator
    {
        public IOperator Operator { get; set; }
        public Number Number1 { get; }
        public Number Number2 { get; }

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
        }

        public string Expression
        {
            get
            {
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
                currentState = new FirstDigitOfNumber1State(this);
            }
        }

    }
}
