using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Parser
    {
        private INodeOfParserTree root = null;

        private Operator currentParent = null;

        private int CreateNumber(string expression, ref int index)
        {
            string number = "";
            while (Char.IsDigit(expression[index]) && index < expression.Length)
            {
                number += expression[index];
                index++;
            }
            return int.Parse(number);
        }

        private Operator WhichOperator(char token)
        {
            if (token == '+')
            {
                return new Addition();
            }
            if (token == '-')
            {
                return new Subtraction();
            }
            if (token == '*')
            {
                return new Multiplication();
            }
            if (token == '/')
            {
                return new Division();
            }

            throw new NotOperatorException();
        }

        public void ParseExpression(string expression)
        {
            int index = 0;

            while (index < expression.Length)
            {
                char token = expression[index];

                if (Char.IsDigit(token))
                { 
                    root = new Number(CreateNumber(expression, ref index));
                    break;
                }

                try
                {
                    currentParent = WhichOperator(token);
                    root = currentParent;
                    break;
                }
                catch (NotOperatorException)
                {
                    index++;
                    continue;
                }
            }

            while (index < expression.Length)
            {
                char token = expression[index];

                if (Char.IsDigit(token))
                {
                    var number = new Number(CreateNumber(expression, ref index));
                    try
                    {
                        currentParent.AddChildAndMove(number);
                        continue;
                    }
                    catch (FullNodeException)
                    {
                        try
                        {
                            currentParent = currentParent.parent;
                            continue;
                        }
                        catch (NullParentException)
                        {
                            break;
                        }
                    }
                }

                try
                {
                    currentParent = currentParent.AddChildAndMove(WhichOperator(token));
                    index++;
                    continue;
                }
                catch (NotOperatorException)
                {
                    index++;
                    continue;
                }
                catch (FullNodeException)
                {
                    try
                    {
                        currentParent = currentParent.parent;
                        continue;
                    }
                    catch (NullParentException)
                    {
                        break;
                    }
                }

            }
        }

    }
}
