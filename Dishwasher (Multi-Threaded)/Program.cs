using System;

namespace Dishwasher
{
    class Program
    {
        static int numberOfPlates;
        static int rackCapacity;
        static int maxWasherTime;
        static int maxDryerTime;

        private static void GetUserInput()
        {
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write("Enter the amount of plates: ");
                    numberOfPlates = int.Parse(Console.ReadLine());
                    Console.Write("Enter the maximum rack capacity: ");
                    rackCapacity = int.Parse(Console.ReadLine());
                    Console.Write("Enter the maximum washer time: ");
                    maxWasherTime = int.Parse(Console.ReadLine());
                    Console.Write("Enter the maximum dryer time: ");
                    maxDryerTime = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, please enter whole numbers only.");
                    continue;
                }
                validInput = IsInputValid();
            }
        }

        private static bool IsInputValid()
        {
            if (numberOfPlates <= 0 ||
                rackCapacity <= 0 ||
                maxWasherTime <= 0 ||
                maxDryerTime <= 0)
            {
                Console.WriteLine("Please enter a value greater than 0.");
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            GetUserInput();
            ThreadHandler threadHandler = new ThreadHandler(numberOfPlates, rackCapacity, maxWasherTime, maxDryerTime);
            threadHandler.CreateAndRunWasherAndDryerThreads();

            Console.WriteLine("Press enter to close");
            Console.ReadLine();
        }
    }
}
