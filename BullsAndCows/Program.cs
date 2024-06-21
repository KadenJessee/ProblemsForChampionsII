namespace BullsAndCows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string guessNum = Console.ReadLine();
            int targetBulls = int.Parse(Console.ReadLine());
            int targetCows = int.Parse(Console.ReadLine());

            List<string> results = new List<string>();
            GenerateCombinations(new char[guessNum.Length], 0, results, guessNum.Length);

            bool found = false;

            foreach (var combination in results)
            {
                var (currBulls, currCows) = CalculateBullsAndCows(guessNum, combination);

                if (currBulls == targetBulls && currCows == targetCows)
                {
                    if (found)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(combination);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }

        static void GenerateCombinations(char[] current, int index, List<string> results, int length)
        {
            if (index == length)
            {
                results.Add(new string(current));
                return;
            }

            for (char digit = '1'; digit <= '9'; digit++)
            {
                current[index] = digit;
                GenerateCombinations(current, index + 1, results, length);
            }
        }

        static (int bulls, int cows) CalculateBullsAndCows(string guess, string combination)
        {
            int bulls = 0, cows = 0;
            bool[] guessUsed = new bool[guess.Length];
            bool[] combinationUsed = new bool[combination.Length];

            // Count bulls
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == combination[i])
                {
                    bulls++;
                    guessUsed[i] = true;
                    combinationUsed[i] = true;
                }
            }

            // Count cows
            for (int i = 0; i < guess.Length; i++)
            {
                if (!guessUsed[i])
                {
                    for (int j = 0; j < combination.Length; j++)
                    {
                        if (!combinationUsed[j] && guess[i] == combination[j])
                        {
                            cows++;
                            combinationUsed[j] = true;
                            break;
                        }
                    }
                }
            }

            return (bulls, cows);
        }
    }
}
