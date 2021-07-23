using System;

namespace ExtraProject
{
    class MainClass
    {
        static string GetUserInput()
        {
            Console.Write("Enter whole numbers from 1 up to 255, separated by spaces: ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string userInput = GetUserInput();
            string[] userInputArray = userInput.Trim().Split(' ');

            Matrix matrix = new Matrix(userInputArray.Length);
            BinaryConverter binaryConverter = new BinaryConverter(matrix);

            string[,] outputMatrix = matrix.GetMatrix();
            outputMatrix = matrix.SetFirstRowAndColumn(outputMatrix, userInputArray);
            outputMatrix = binaryConverter.LoopThroughAndConvert(outputMatrix);
            matrix.PrintGrid(outputMatrix);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
