using System;
using System.Collections.Generic;

namespace DamData
{
    class Program
    {

        static Dictionary<string, Dam> damObjects;

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading file...");
            ExcelFileReader fileReader = new ExcelFileReader();
            fileReader.OpenAndReadFile();

            Console.WriteLine("Organising and storing data...");
            DataStorer dataStorer = new DataStorer(fileReader.GetExcelFileContents());
            dataStorer.SplitAndStoreData();
            damObjects = dataStorer.damObjectsDict;

            Console.WriteLine("Ready");
            HandleInput handleInput = new HandleInput();
            handleInput.HandleUserInput(damObjects);

            Console.WriteLine("Instrumentation Count: " + OperatorCounter.opCounter);

            Console.ReadLine();
        }
}
}
