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

        private Operator CurrentParent = null;

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
                    root = WhichOperator(token);
                    break;
                }
                catch (NotOperatorException)
                {
                    continue;
                }
            }

            while (index < expression.Length)
            {
                char token = expression[index];
                if (Char.IsDigit(token))
                {
                    int number = CreateNumber(expression, ref index);
                }
            }
        }
    }
}
