using System;
using System.Linq;

namespace Calculator 
{
	class Calculator 
	{
		static int x;
		static int y;
		static string userOperation; 

		static void GetUserInput()
		{
			bool validInput = false;
			while (!validInput)
			{
				try 
				{
					Console.Write("Enter the first number: ");
					x = int.Parse(Console.ReadLine());
					Console.Write("Enter the second number: ");
					y = int.Parse(Console.ReadLine());
					Console.Write("Enter the operation (+, -, *, /): ");
					userOperation = Console.ReadLine();
					validInput = IsOperatorValid(userOperation);
				}
				catch (FormatException)
				{
					Console.Write("Invalid input");
				}
			}
		}
		
		static bool IsOperatorValid(string userOperation)
		{
			string[] operatorsArray = {"+", "-", "*", "/"};
			if (operatorsArray.Contains(userOperation)) return true;
			Console.WriteLine("Invalid operator");
			return false;
		}

		static void Calculate()
		{	
			int output;
			switch(userOperation)
			{
				case "+":
					output = x + y;
					break;
				case "-":
					output = x - y;
					break;
				case "*":
					output = x * y;
					break;
				case "/":
					Console.Write("The answer is " + Math.Round(((double) x / (double) y), 2));
					return;
				default:
					Console.Write("Invalid operator");
					return;
			}
			Console.Write("The answer is " + output);
		}

		static void Main(string[] args) 
		{	
			GetUserInput();
			Calculate();
		}
	}
}