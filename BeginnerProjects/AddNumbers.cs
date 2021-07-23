using System;

namespace AddNumbers 
{    
    class AddNumbers 
    {
        static int x;
        static int y;

        static void GetUserInput() 
        {
            while (true)
            {
                try 
                {
                    Console.Write("Enter the first number: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Enter the second number: ");
                    y = int.Parse(Console.ReadLine());
                    return;
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        
        static int Add() { return x + y; }

        static void Main(string[] args) 
        {	
            GetUserInput();
            Console.Write("The total is " + Add());
        }
    }
}