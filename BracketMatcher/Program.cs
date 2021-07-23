using System;

namespace ExtraProject1
{
    class Program
    {
        static string GetUserInput()
        {
            Console.Write("Enter a string to test: ");
            return Console.ReadLine().Trim(' ');
        }

        private static bool IsValidPattern(string pattern)
        {
            Brackets brackets = new Brackets();
            foreach (Char item in pattern)
            {
                if (!brackets.GetCorrespondingBrackets().ContainsKey(item))
                {
                    Console.WriteLine("Invalid input");
                    return false;
                }
            }
            return true;
        }

        static void Main()
        {
            string pattern;
            BracketMatcher matcher = new BracketMatcher();
            do { pattern = GetUserInput(); } while (!IsValidPattern(pattern));
            Console.WriteLine(matcher.Solve(pattern));

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
