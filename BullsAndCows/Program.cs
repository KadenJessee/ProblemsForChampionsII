namespace BullsAndCows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guessNum = int.Parse(Console.ReadLine());
            int targetBulls = int.Parse(Console.ReadLine());
            int targetCows = int.Parse(Console.ReadLine());

            bool found = false;


            for (int digit1 = 1; digit1 <= 9; digit1++)
            {
                for (int digit2 = 1; digit2 <= 9; digit2++)
                {
                    for (int digit3 = 1; digit3 <= 9; digit3++) 
                    {
                        for (int digit4 = 1; digit4 <= 9; digit4++)
                        {
                            int guessDigit1 = (guessNum / 1000) % 10;
                            int guessDigit2 = (guessNum / 100) % 10;
                            int guessDigit3 = (guessNum / 10) % 10;
                            int guessDigit4 = (guessNum / 1) % 10;

                            int digitToCheck1 = digit1;
                            int digitToCheck2 = digit2;
                            int digitToCheck3 = digit3;
                            int digitToCheck4 = digit4;

                            int currBulls = 0;
                            int currCows = 0;

                            //counting bulls
                            if(digitToCheck1 == guessDigit1)
                            {
                                currBulls++;
                                guessDigit1 = -1;
                                digitToCheck1 = -2;
                            }
                            if (digitToCheck2 == guessDigit2)
                            {
                                currBulls++;
                                guessDigit2 = -1;
                                digitToCheck2 = -2;
                            }
                            if (digitToCheck3 == guessDigit3)
                            {
                                currBulls++;
                                guessDigit3 = -1;
                                digitToCheck3 = -2;
                            }
                            if (digitToCheck4 == guessDigit4)
                            {
                                currBulls++;
                                guessDigit4 = -1;
                                digitToCheck4 = -2;
                            }

                            //counting cows
                            if (digitToCheck1 == guessDigit2)
                            {
                                currCows++;
                                guessDigit2 = -1;
                            }
                            else if (digitToCheck1 == guessDigit3)
                            {
                                currCows++;
                                guessDigit3 = -1;
                            }
                            else if (digitToCheck1 == guessDigit4)
                            {
                                currCows++;
                                guessDigit4 = -1;
                            }
                            if (digitToCheck2 == guessDigit1)
                            {
                                currCows++;
                                guessDigit1 = -1;
                            }
                            else if (digitToCheck2 == guessDigit3)
                            {
                                currCows++;
                                guessDigit2 = -1;
                            }
                            else if (digitToCheck2 == guessDigit4) 
                            {
                                currCows++;
                                guessDigit4 = -1;
                            }
                            if(digitToCheck3 == guessDigit1)
                            {
                                currCows++;
                                guessDigit1 = -1;
                            }
                            else if( digitToCheck3 == guessDigit2)
                            {
                                currCows++;
                                guessDigit2 = -1;
                            }
                            else if(digitToCheck3 == guessDigit4)
                            {
                                currCows++;
                                guessDigit4 = -1;
                            }
                            if(digitToCheck4 == guessDigit1)
                            {
                                currCows++;
                                guessDigit1 = -1;
                            }
                            else if(digitToCheck4== guessDigit2)
                            {
                                currCows++;
                                guessDigit2 = -1;
                            }
                            else if(digitToCheck4 == guessDigit3)
                            {
                                currCows++;
                                guessDigit3 = -1;
                            }

                            if (currBulls == targetBulls && currCows == targetCows) 
                            {
                                if (found)
                                {
                                    Console.Write(" ");
                                }
                                Console.Write($"{digit1}{digit2}{digit3}{digit4}");
                                found = true;
                            }
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}
