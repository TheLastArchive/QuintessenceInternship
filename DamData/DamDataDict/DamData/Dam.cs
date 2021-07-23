using System;
using System.Collections.Generic;

namespace DamData
{
    class Dam
    {
        public List<List<string>> damCapacities { set; get; }
        public string name { get; }
        public string maxCapacity { get; }
        public Dictionary<string, Dictionary<string, string>> damDataDictionary  { get; set; }
        public string[] headers { set; get; }
        public string[] storageUnits { set; get; }

        public Dam(string name, string maxCapacity, string[] headers, string[] storageUnits)
        {
            this.name = name.ToUpper();
            this.maxCapacity = maxCapacity;
            this.headers = headers;
            this.storageUnits = storageUnits;
        }

        public void CreateDamDataDictionary(string[] dates)
        {
            damDataDictionary = new Dictionary<string, Dictionary<string, string>>();
            for (int i = 0; i < dates.Length; i++)
                damDataDictionary.Add(dates[i].ToLower(), CreateDateDictionary(i));
        }

        private Dictionary<string, string> CreateDateDictionary(int index)
        {
            Dictionary<string, string> dateDict = new Dictionary<string, string>();
            List<string> capacitiesForDate = damCapacities[index];

            dateDict.Add("height", capacitiesForDate[0]);
            dateDict.Add("storage", capacitiesForDate[1]);
            dateDict.Add("current", capacitiesForDate[2]);
            dateDict.Add("lastYear", capacitiesForDate[3]);

            return dateDict;
        }
        public void PrintDam(string date)
        {
            string outputString = "";
            OutputLogger logOutput = new OutputLogger();
            try
            {
                Dictionary<string, string> dateDict = damDataDictionary[date.ToLower()];
                outputString += "\n" + name + " on " + date + "\n" +
                                "Max Capacity - " + maxCapacity + "Ml" + "\n" +
                                 headers[1] + "       - " + dateDict["height"] + storageUnits[0].Trim('(').Trim(')') + "\n" +
                                 headers[2] + "      - " + dateDict["storage"] + storageUnits[1].Trim('(').Trim(')') + "\n" +
                                 headers[3] + "      - " + dateDict["current"] + storageUnits[2] + "\n" +
                                 headers[4] + "    - " + dateDict["lastYear"] + storageUnits[3] + "\n";
                Console.WriteLine(outputString);
                logOutput.AppendToOutputLog(outputString);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No information found for date: " + date);
            }
        }

        public void PrintAllDamData()
        {
            foreach (var item in damDataDictionary)
                PrintDam(item.Key);
        }
    }
}
