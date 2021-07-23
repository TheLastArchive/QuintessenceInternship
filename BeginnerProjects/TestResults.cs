using System;

namespace TestResults 
{
	class TestResults 
	{
		static int testTotal;
		static int userScore;
		static double userPercentage;
		static string result = "fail";

		static void getUserInput()
		{
			try 
			{
				Console.Write("Enter the total score: ");
				testTotal = int.Parse(Console.ReadLine());
				Console.Write("Enter your score: ");
				userScore = int.Parse(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.Write("Invalid input");
				Environment.Exit(0);
			}
		}
		
		static double calculatePercentage()
		{	
			return (((double) userScore / (double) testTotal) * 100); 
		}

		static void displayResults()
		{
			if (userPercentage >= 50.0) result = "pass";
			Console.Write("You score is {0}% which is a {1}", Math.Round(userPercentage, 1), result);
		}

		static void Main(string[] args) 
		{	
			getUserInput();
			userPercentage = calculatePercentage();
			displayResults();
		}
	}
}