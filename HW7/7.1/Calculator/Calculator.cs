using System;
using System.Collections.Generic;
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
        private CalculatorStates statement = CalculatorStates.FirstDigitOfNumber1;

        public string Operation { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }

        private bool IsOperator(char token) => token == '+' || token == '-' || token == '*' || token == '/';

        private double Calculate()
        {
            switch (Operation[1])
            {
                case '+':
                    {
                        Operation = "";
                        return double.Parse(Number1) + double.Parse(Number2);
                    }
                case '-':
                    {
                        Operation = "";
                        return double.Parse(Number1) - double.Parse(Number2);
                    }
                case '*':
                    {
                        Operation = "";
                        return double.Parse(Number1) * double.Parse(Number2);
                    }
                case '/':
                    {
                        Operation = "";
                        return double.Parse(Number1) / double.Parse(Number2);
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        private enum CalculatorStates
        {
            FirstDigitOfNumber1,
            FloorOfNumber1,
            FirstDigitOfFractionalPartOfNumber1,
            FractionalPartOfNumber1,
            InputedNumber1,
            FirstDigitOfNumber2,
            FloorOfNumber2,
            FirstDigitOfFractionalPartOfNumber2,
            FractionalPartOfNumber2,
            InputedNumber2,
            AfterCalculation
        }


        public void Add(char token)
        {
            switch (statement)
            {
                case CalculatorStates.FirstDigitOfNumber1:
                    {
                        if (char.IsDigit(token))
                        {
                            Number1 += token;
                            statement = CalculatorStates.FloorOfNumber1;
                            return;
                        }

                        return;
                    }
                case CalculatorStates.FloorOfNumber1:
                    {
                        if (char.IsDigit(token))
                        {
                            Number1 += token;
                            return;
                        }

                        if (IsOperator(token))
                        {
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                            return;
                        }

                        switch (token)
                        {
                            case ',':
                                {
                                    Number1 += token;
                                    statement = CalculatorStates.FractionalPartOfNumber1;
                                    return;
                                }
                            case '√':
                                {
                                    Number1 = Math.Sqrt(double.Parse(Number1)).ToString();
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            case 'b':
                                {
                                    Number1 = Number1.Remove(Number1.Length - 1);
                                    if (Number1.Length == 0)
                                    {
                                        statement = CalculatorStates.FloorOfNumber1;
                                    }
                                    return;
                                }
                            case 's':
                                {
                                    if (Number1[0] != '-')
                                    {
                                        Number1 = "-" + Number1;
                                    }
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.FirstDigitOfFractionalPartOfNumber1:
                    {
                        if (char.IsDigit(token))
                        {
                            Number1 += token;
                            statement = CalculatorStates.FractionalPartOfNumber1;
                            return;
                        }

                        switch (token)
                        {
                            case 'b':
                                {
                                    Number1 = Number1.Remove(Number1.Length - 1);
                                    statement = CalculatorStates.FloorOfNumber1;
                                    return;
                                }
                            case 's':
                                {
                                    if (Number1[0] != '-')
                                    {
                                        Number1 = "-" + Number1;
                                    }
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.FractionalPartOfNumber1:
                    {
                        if (char.IsDigit(token))
                        {
                            Number1 += token;
                        }
                        if (IsOperator(token))
                        {
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                        }
                        switch (token)
                        {
                            case 'b':
                                {
                                    Number1 = Number1.Remove(Number1.Length - 1);
                                    if (Number1[Number1.Length - 1] == ',')
                                    {
                                        statement = CalculatorStates.FirstDigitOfFractionalPartOfNumber1;
                                    }
                                    return;
                                }
                            case 's':
                                {
                                    if (Number1[0] != '-')
                                    {
                                        Number1 = "-" + Number1;
                                    }
                                    return;
                                }
                            case '√':
                                {
                                    Number1 = Math.Sqrt(double.Parse(Number1)).ToString();
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.InputedNumber1:
                    {
                        if (IsOperator(token))
                        {

                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                        }

                        switch (token)
                        {

                            case 's':
                                {
                                    if (Number1[0] != '-')
                                    {
                                        Number1 = "-" + Number1;
                                    }
                                    return;
                                }
                            case '√':
                                {
                                    Number1 = Math.Sqrt(double.Parse(Number1)).ToString();
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }

                    }
                case CalculatorStates.FirstDigitOfNumber2:
                    {
                        if (char.IsDigit(token))
                        {
                            Number2 += token;
                            statement = CalculatorStates.FloorOfNumber2;
                            return;
                        }
                        if (token == 'b')
                        {
                            Operation = "";
                            statement = CalculatorStates.InputedNumber1;
                            return; 
                        }
                        return;
                    }
                case CalculatorStates.FloorOfNumber2:
                    {
                        if (char.IsDigit(token))
                        {
                            Number2 += token;
                            return;
                        }

                        if (IsOperator(token))
                        {
                            Number1 = Calculate().ToString();
                            Number2 = "";
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                        }

                        switch (token)
                        {
                            case ',':
                                {
                                    Number2 += token;
                                    statement = CalculatorStates.FirstDigitOfFractionalPartOfNumber2;
                                    return;
                                }
                            case '√':
                                {
                                    Number2 = Math.Sqrt(double.Parse(Number2)).ToString();
                                    statement = CalculatorStates.InputedNumber2;
                                    return;
                                }
                            case 'b':
                                {
                                    Number2 = Number2.Remove(Number2.Length - 1);
                                    if (Number2.Length == 0)
                                    {
                                        statement = CalculatorStates.FirstDigitOfNumber2;
                                    }
                                    return;
                                }
                            case 's':
                                {
                                    if (Number2[0] != '-')
                                    {
                                        Number2 = "-" + Number2;
                                    }
                                    return;
                                }
                            case '=':
                                {
                                    Number1 = Calculate().ToString();
                                    Operation = "";
                                    Number2 = "";
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.FirstDigitOfFractionalPartOfNumber2:
                    {
                        if (char.IsDigit(token))
                        {
                            Number2 += token;
                            statement = CalculatorStates.FractionalPartOfNumber2;
                            return;
                        }

                        switch (token)
                        {
                            case 'b':
                                {
                                    Number2 = Number2.Remove(Number2.Length - 1);
                                    statement = CalculatorStates.FloorOfNumber2;
                                    return;
                                }
                            case 's':
                                {
                                    if (Number2[0] != '-')
                                    {
                                        Number2 = "-" + Number2;
                                    }
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.FractionalPartOfNumber2:
                    {
                        if (char.IsDigit(token))
                        {
                            Number2 += token;
                        }
                        if (IsOperator(token))
                        {
                            Number1 = Calculate().ToString();
                            Number2 = "";
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                        }
                        switch (token)
                        {
                            case 'b':
                                {
                                    Number2 = Number2.Remove(Number2.Length - 1);
                                    if (Number2[Number2.Length - 1] == ',')
                                    {
                                        statement = CalculatorStates.FirstDigitOfFractionalPartOfNumber2;
                                    }
                                    return;
                                }
                            case 's':
                                {
                                    if (Number2[0] != '-')
                                    {
                                        Number2 = "-" + Number2;
                                    }
                                    return;
                                }
                            case '√':
                                {
                                    Number2 = Math.Sqrt(double.Parse(Number2)).ToString();
                                    statement = CalculatorStates.InputedNumber2;
                                    return;
                                }
                            case '=':
                                {
                                    Number1 = Calculate().ToString();
                                    Operation = "";
                                    Number2 = "";
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.InputedNumber2:
                    {
                        if (IsOperator(token))
                        {
                            Number1 = Calculate().ToString();
                            Number2 = "";
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                        }

                        switch (token)
                        {

                            case 's':
                                {
                                    if (Number2[0] != '-')
                                    {
                                        Number2 = "-" + Number2;
                                    }
                                    else
                                    {
                                        Number2.Remove(0, 1);
                                    }
                                    return;
                                }
                            case '√':
                                {
                                    Number2 = Math.Sqrt(double.Parse(Number2)).ToString();
                                    return;
                                }
                            case '=':
                                {
                                    Number1 = Calculate().ToString();
                                    Operation = "";
                                    Number2 = "";
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            default:
                                {
                                    return;
                                }
                        }
                    }
                case CalculatorStates.AfterCalculation:
                    {
                        if (char.IsDigit(token))
                        {
                            Number1 += token;
                            statement = CalculatorStates.FloorOfNumber1;
                            return;
                        }
                        if (IsOperator(token))
                        {
                            Operation = " " + token.ToString() + " ";
                            statement = CalculatorStates.FirstDigitOfNumber2;
                            return;
                        }
                        switch (token)
                        {
                            case 's':
                                {
                                    if (Number2[0] != '-')
                                    {
                                        Number2 = "-" + Number2;
                                    }
                                    else
                                    {
                                        Number2.Remove(0, 1);
                                    }
                                    return;
                                }
                            case '√':
                                {
                                    Number1 = Math.Sqrt(double.Parse(Number1)).ToString();
                                    statement = CalculatorStates.InputedNumber1;
                                    return;
                                }
                            default:
                                {
                                    return;
                                }

                        }
                    }
            }
        }

        public void Clear()
        {
            statement = 0;
            Number1 = "";
            Number2 = "";
            Operation = "";
        }

    }
}
