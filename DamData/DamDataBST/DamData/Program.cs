using System;
using System.Collections.Generic;

namespace DamData
{
    class Program
    {

        static BinaryTree damObjectsTree;

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading file...");
            ExcelFileReader fileReader = new ExcelFileReader();
            fileReader.OpenAndReadFile();

            Console.WriteLine("Organising and storing data...");
            DataStorer dataStorer = new DataStorer(fileReader.GetExcelFileContents());
            dataStorer.SplitAndStoreData();
            damObjectsTree = dataStorer.damObjectsTree;

            Console.WriteLine("Ready");
            HandleInput handleInput = new HandleInput();
            handleInput.HandleUserInput(damObjectsTree);

            Console.WriteLine("Instrumentation Count: " + OperatorCounter.opCounter);

            Console.ReadLine();
        }
    }
}
