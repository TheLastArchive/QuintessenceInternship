using System;

namespace UserName 
{
	class UserName 
	{
		string username;

		void GetUsername()
		{
			Console.Write("What is your name?: ");
			username = Console.ReadLine();
		}
		
		void GreetUser()
		{
			Console.Write("Hello " + username); 
		}

		static void Main(string[] args) 
		{	
			GetUsername();
			GreetUser();
		}
	}
}