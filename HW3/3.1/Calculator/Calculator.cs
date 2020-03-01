using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private static int CreateInt(ref int index, string input)
        {
            string number = null; 

            while (Char.IsDigit(input[index]))
            {
                number += input[index];
                index++;
            }

            return int.Parse(number);
        }

        public static int Calculating(string input, ref bool isSuccessful)
        {
            if (String.IsNullOrEmpty(input))
            {
                isSuccessful = false;
                return 0;
            }

            IStack calculatingStack = new ListStack();

            for (int i = 0; i < input.Length; ++i)
            {
                bool doSomething = false;

                char currentToken = input[i];

                if (Char.IsDigit(currentToken))
                {
                    calculatingStack.Push(CreateInt(ref i, input));
                    continue;
                }

                if (i != input.Length - 1 && char.IsDigit(input[i + 1]))
                {
                    i++;
                    calculatingStack.Push(-CreateInt(ref i, input));
                    continue;
                }

                if (currentToken == '+' || currentToken == '-' || currentToken == '*' || currentToken == '/')
                {
                    if (calculatingStack.Empty())
                    {
                        isSuccessful = false;
                        return 0;
                    }

                    int number2 = calculatingStack.Pop();

                    if (calculatingStack.Empty())
                    {
                        isSuccessful = false;
                        return 0;
                    }

                    int number1 = calculatingStack.Pop();

                    switch (currentToken)
                    {
                        case '+':
                            {
                                number1 += number2;
                                doSomething = true;
                                break;
                            }
                        case '-':
                            {
                                number1 -= number2;
                                doSomething = true;
                                break;
                            }
                        case '*':
                            {
                                number1 *= number2;
                                doSomething = true;
                                break;
                            }
                        case '/':
                            {
                                if (number2 == 0)
                                {
                                    Console.WriteLine("Division by null!");
                                    isSuccessful = false;
                                    return 0;
                                }
                                number1 /= number2;
                                doSomething = true;
                                break;
                            }
                    }

                    if (!doSomething)
                    {
                        isSuccessful = false;
                        return 0;
                    }

                    calculatingStack.Push(number1);
                }
            }

            if (calculatingStack.Empty())
            {
                isSuccessful = false;
                return 0;
            }

            int result = calculatingStack.Pop();

            if (!calculatingStack.Empty())
            {
                isSuccessful = false;
                return 0;
            }

            return result;
        }

    }
}
