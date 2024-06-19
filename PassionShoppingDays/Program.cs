namespace PassionShoppingDays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal shoppingMoney = decimal.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "mall.Enter")
            {
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            int purchases = 0;

            while (command != "mall.Exit")
            {
                foreach (char action in command)
                {
                    if (action >= 'A' && action <= 'Z')
                    {
                        decimal price = action * 0.5m;
                        if (shoppingMoney < price)
                        {
                            continue;
                        }
                        shoppingMoney -= price;
                        purchases++;
                    }
                    else if (action >= 'a' && action <= 'z')
                    {
                        decimal price = action * 0.3m;
                        if (shoppingMoney < price)
                        {
                            continue;
                        }
                        shoppingMoney -= price;
                        purchases++;
                    }
                    else if (action == '%')
                    {
                        shoppingMoney = shoppingMoney / 2;
                        purchases++;
                    }
                    else if (action == '*')
                    {
                        shoppingMoney += 10;
                    }
                    else
                    {
                        shoppingMoney -= action;
                        purchases++;
                    }
                }
                command = Console.ReadLine();
            }

            if (purchases <= 0)
            {
                Console.WriteLine("No purchases. Money left: {0:f2} lv.", shoppingMoney);
            }
            else
            {
                Console.WriteLine("{0} purchases. Money left: {1:f2} lv.", purchases, shoppingMoney);
            }
        }
    }
}
