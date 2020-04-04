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
            while (index < expression.Length && Char.IsDigit(expression[index]))
            {
                number += expression[index];
                index++;
            }
            return int.Parse(number);
        }

        /// <summary>
        /// Create IOperator object by token
        /// </summary>
        /// <param name="token">Symbol of operator, that you want to create</param>
        /// <exception cref="NotOperatorException">Throws if token isn't operator</exception>
        /// <returns>New operator</returns>
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

        /// <summary>
        /// Calculeate expression by built tree
        /// </summary>
        /// <returns>Result of expression</returns>
        public int CalculateParsedException()
        {
            if (root == null)
            {
                throw new NotCorrectOrNotParsedExpressionException();
            }

            return root.Calculate();
        }

        /// <summary>
        /// Build tree of arithmetic expression
        /// </summary>
        /// <param name="expression">Input expression</param>
        public void ParseExpression(string expression)
        {
            int index = 0;

            while (index < expression.Length)  //Itinialize root of tree
            {
                char token = expression[index];

                if (Char.IsDigit(token))
                { 
                    root = new Number(CreateNumber(expression, ref index));
                    return;
                }

                try
                {
                    currentParent = WhichOperator(token);
                    root = currentParent;
                    index++;
                    break;
                }
                catch (NotOperatorException)
                {
                    index++;
                    continue;
                }
            }

            while (index < expression.Length)   //Parse the rest of expression
            {
                char token = expression[index];

                if (Char.IsDigit(token))
                {
                    var number = new Number(CreateNumber(expression, ref index));
                    try
                    {
                        currentParent.AddChildAndMove(number);
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
                            throw new Exception("Invalid expression");
                        }
                    }
                }

                try
                {
                    var lastParent = currentParent;
                    currentParent = currentParent.AddChildAndMove(WhichOperator(token));
                    currentParent.parent = lastParent;
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
