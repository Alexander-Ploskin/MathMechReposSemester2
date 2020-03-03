using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    class Calculator
    {
        private static int CreateInt(ref int index, string input)
        {
            string number = null; 

            while (Char.IsDigit(input[index]))
            {
                number += input[index];
                if (index == input.Length - 1)
                {
                    return int.Parse(number);
                }
                index++;
            }

            return int.Parse(number);
        }

        public static (int, bool) Calculate(string input, IStack calculatingStack)
        { 
            if (String.IsNullOrEmpty(input))
            {
                return (0, false);
            }

            for (int i = 0; i < input.Length; ++i)
            {
                bool doSomething = false;

                char currentToken = input[i];

                if (Char.IsDigit(currentToken))
                {
                    calculatingStack.Push(CreateInt(ref i, input));
                    continue;
                }

                if (currentToken == '-' && i != input.Length - 1 && char.IsDigit(input[i + 1]))
                {
                    i++;
                    calculatingStack.Push(-CreateInt(ref i, input));
                    continue;
                }

                if (currentToken == '+' || currentToken == '-' || currentToken == '*' || currentToken == '/')
                {
                    if (calculatingStack.Empty())
                    {
                        return (0, false);
                    }

                    int number2 = calculatingStack.Pop();

                    if (calculatingStack.Empty())
                    {
                        return (0, false);
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
                                    return (0, false);
                                }
                                number1 /= number2;
                                doSomething = true;
                                break;
                            }
                    }

                    if (!doSomething)
                    {
                        return (0, false);
                    }

                    calculatingStack.Push(number1);
                }
            }

            if (calculatingStack.Empty())
            {
                return (0, false);
            }

            int result = calculatingStack.Pop();

            if (!calculatingStack.Empty())
            {
                return (0, false);
            }

            return (result, true);
        }

    }
}