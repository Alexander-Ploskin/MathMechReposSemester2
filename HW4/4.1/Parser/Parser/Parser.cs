using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Parser of arithmetic expressions
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Create number by consecutive characters
        /// </summary>
        /// <param name="expression">Expression, with those symbols</param>
        /// <param name="index">Index of first symbol</param>
        /// <returns>Number</returns>
        private static int CreateNumber(string expression, ref int index)
        {
            string number = "";
            while (index < expression.Length && Char.IsDigit(expression[index]))
            {
                number += expression[index];
                index++;
            }

            index--;
            return int.Parse(number);
        }

        /// <summary>
        /// Create IOperator object by token
        /// </summary>
        /// <param name="token">Symbol of operator, that you want to create</param>
        /// <exception cref="NotOperatorException">Throws if token isn't operator</exception>
        /// <returns>New operator</returns>
        private static Operator WhichOperator(char token)
            => token switch
            { 
                '+' => new Addition(),
                '-' => new Subtraction(),
                '*' => new Multiplication(),
                '/' => new Division(),
                _ => throw new NotOperatorException(),
            };

        /// <summary>
        /// Build tree of arithmetic expression
        /// </summary>
        /// <exception cref="InvalidExpressionException">Throws if expression isn't correct</exception>
        /// <param name="expression">Input expression</param>
        public static ExpressionTree ParseExpression(string expression)
        {
            var tree = new ExpressionTree();
            Operator currentParent = null;
            int index = 0;

            while (index < expression.Length)  //Itinialize root of tree
            {
                char token = expression[index];

                if (Char.IsDigit(token))
                { 
                    tree.root = new Number(CreateNumber(expression, ref index));
                    if (index != expression.Length - 1)
                    {
                        throw new InvalidExpressionException();
                    }
                    return tree;
                }

                try
                {
                    currentParent = WhichOperator(token);
                    tree.root = currentParent;
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
                            throw new InvalidExpressionException();
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

            if (!tree.Allright())
            {
                throw new InvalidExpressionException();
            }

            return tree;
        }

    }
}
