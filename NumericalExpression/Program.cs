using System;

namespace NumericalExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal result = 0;
            int expressionOperator = '+';

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (symbol == '=')
                {
                    break;
                }

                if (symbol == '(')
                {
                    decimal innerResult = 0;
                    int innerOperator = '+';

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        char innerSymbol = input[j];
                        if (innerSymbol == ')')
                        {
                            i = j;
                            break;
                        }

                        if (innerSymbol == '+' || innerSymbol == '-' || innerSymbol == '/' || innerSymbol == '*')
                        {
                            innerOperator = innerSymbol;
                        }
                        else if (char.IsDigit(innerSymbol))
                        {
                            switch (innerOperator)
                            {
                                case '+':
                                    innerResult += innerSymbol - '0';
                                    break;
                                case '-':
                                    innerResult -= innerSymbol - '0';
                                    break;
                                case '*':
                                    innerResult *= innerSymbol - '0';
                                    break;
                                case '/':
                                    innerResult /= innerSymbol - '0';
                                    break;
                            }
                        }
                    }

                    switch (expressionOperator)
                    {
                        case '+':
                            result += innerResult;
                            break;
                        case '-':
                            result -= innerResult;
                            break;
                        case '*':
                            result *= innerResult;
                            break;
                        case '/':
                            result /= innerResult;
                            break;
                    }
                }

                if (char.IsDigit(symbol))
                {
                    switch (expressionOperator)
                    {
                        case '+':
                            result += symbol - '0';
                            break;
                        case '-':
                            result -= symbol - '0';
                            break;
                        case '*':
                            result *= symbol - '0';
                            break;
                        case '/':
                            result /= symbol - '0';
                            break;
                    }
                }
                else if (symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*')
                {
                    expressionOperator = symbol;
                }
            }

            Console.WriteLine("{0:f2}", result);
        }
    }
}
