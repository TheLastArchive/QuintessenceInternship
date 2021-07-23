using System;
using System.Collections.Generic;

namespace DamData
{
    class HandleInput
    {

        private static string GetUserInput()
        {
            Console.Write("Enter command: ");
            return Console.ReadLine();
        }

        public void HandleUserInput(List<Dam> damObjects)
        {
            Validator validator = new Validator();
            Commands command = new Commands(damObjects);
            bool shouldContinue = true;

            do
            {
                string userInput = GetUserInput();
                if (!validator.IsCommandValid(userInput))
                    continue;
                shouldContinue = command.HandleCommand(userInput);
            } while (shouldContinue);
        }
    }
}
