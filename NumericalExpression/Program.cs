namespace NumericalExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int index = 0;
            decimal result = EvaluateExpression(input, ref index);
            Console.WriteLine("{0:f2}", result);
        }

        static decimal EvaluateExpression(string input, ref int index)
        {
            decimal result = 0;
            int expressionOperator = '+';

            while (index < input.Length)
            {
                char symbol = input[index];
                index++;

                if (symbol == '=')
                {
                    break;
                }

                if (symbol == '(')
                {
                    decimal innerResult = EvaluateExpression(input, ref index);

                    result = ApplyOperator(result, expressionOperator, innerResult);
                }
                else if (symbol == ')')
                {
                    break;
                }
                else if (char.IsDigit(symbol))
                {
                    decimal number = symbol - '0';
                    result = ApplyOperator(result, expressionOperator, number);
                }
                else if (IsOperator(symbol))
                {
                    expressionOperator = symbol;
                }
            }

            return result;
        }

        static decimal ApplyOperator(decimal result, int expressionOperator, decimal number)
        {
            switch (expressionOperator)
            {
                case '+':
                    return result + number;
                case '-':
                    return result - number;
                case '*':
                    return result * number;
                case '/':
                    return result / number;
                default:
                    throw new InvalidOperationException("Unsupported operator");
            }
        }

        static bool IsOperator(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }
    }
}
