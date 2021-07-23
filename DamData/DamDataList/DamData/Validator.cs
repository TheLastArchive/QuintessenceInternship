using System;
using System.Linq;

namespace DamData
{
    class Validator
    {
        public bool IsDateValid(string date)
        {
            string[] splitDate = date.Split(' ', '/', '-');
            if (splitDate.Length != 3)
            {
                Console.WriteLine("Invalid date format (dd-MM-yyyy)");
                return false;
            }
                                              //yyyy MM dd
            string dateToParse = String.Format("{0} {1} {2}", splitDate[2], splitDate[1], splitDate[0]);
            if (!DateTime.TryParse(dateToParse, out _))
            {
                Console.WriteLine("Invalid date format (dd-MM-yyyy)");
                return false;
            }

            return true;
        }

        public bool IsCommandValid(string command)
        {
            string[] commandArray = command.Split(new[] { ',' }, 3);

            if (commandArray[0].ToLower().Trim() == "printdam" && commandArray.Length != 3)
            {
                Console.WriteLine("Invalid number of arguments for PrintDam");
                return false;
            }

            if (commandArray[0].ToLower().Trim() == "printdam" && commandArray.Length == 3)
                return IsDateValid(commandArray[2].Trim());

            return true;

        }


    }
}

