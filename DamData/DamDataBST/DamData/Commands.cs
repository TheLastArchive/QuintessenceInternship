using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DamData
{
    class Commands
    {
        BinaryTree damObjectsTree;

        public Commands(BinaryTree damObjects) => damObjectsTree = damObjects;

        public bool HandleCommand(string command)
        {
            string[] commandArray = command.Split(new[] { ',' }, 3);
            
            switch (commandArray[0].ToLower().Trim())
            {
                case "printalldams":
                    return PrintAllDams();
                case "printdam":
                    return PrintDam(commandArray[1].Trim(), commandArray[2].Trim());
                case "help":
                    return HelpCommand();
                case "clearlog":
                    return ClearLog();
                case "test":
                    return TestCommand();
                case "exit":
                    return false;
                default:
                    Console.WriteLine("Invalid command");
                    return true;
            }
        }

        private bool HelpCommand()
        {
            Console.WriteLine("\nAvailable commands are: \n" +
                              "Help                                       - Displays a list of all available commands \n" +
                              "PrintDam, {Dam name}, {Date (dd MM yyyy)}  - Get Data for listed dam on the listed date\n" +
                              "PrintAllDams                               - Print all the info for all the dams\n" +
                              "ClearLog                                   - Clears any data stored in the OutputLog file\n" +
                              "Test                                       - Runs a quick test and returns execution time\n" +  
                              "Exit                                       - Ends the program\n");

            return true;
        }

        private bool PrintAllDams()
        {
            List<Dam> damList = damObjectsTree.TraverseTree();
            foreach (Dam dam in damList)
                dam.PrintAllDamData();
            return true;
        }

        private bool PrintDam(string damName, string date)
        {
            Dam dam = damObjectsTree.Get(damName);
            if (dam == null)
                Console.WriteLine(damName + " not found");
            else
                dam.PrintDam(FormatDate(date));
            return true;
        }

        private string FormatDate(string date)
        {
            string[] splitDate = date.Split(' ', '/', '-');
            string dateToParse = String.Format("{0} {1} {2}", splitDate[2], splitDate[1], splitDate[0]);
            DateTime dt = DateTime.Parse(dateToParse);
            return dt.ToString("dd-MMM-yy");
        }

        private bool ClearLog()
        {
            OutputLogger logOutput = new OutputLogger();
            logOutput.ClearOutputLogFile();
            Console.WriteLine("OutputLog.txt has been cleared");
            return true;
        }

        private bool TestCommand()
        {
            string testCommand1 = "printdam, wemmershoek, 1 jan 12";
            string testCommand2 = "printdam, wemmershoek, 29 feb 12";
            string testCommand3 = "printdam, de villiers, 30 jan 12";
            string testCommand4 = "printdam, land-en zeezicht, 29 feb 12";
            string testCommand5 = "printdam";
            Validator validator = new Validator();
            Stopwatch timer = new Stopwatch();

            timer.Start();
            validator.IsCommandValid(testCommand1);
            HandleCommand(testCommand1);
            validator.IsCommandValid(testCommand2);
            HandleCommand(testCommand2);
            validator.IsCommandValid(testCommand3);
            HandleCommand(testCommand3);
            validator.IsCommandValid(testCommand4);
            HandleCommand(testCommand4);
            validator.IsCommandValid(testCommand5);
            timer.Stop();
            Console.WriteLine("BST execution time: " + timer.Elapsed);

            return true;
        }
    }
}
