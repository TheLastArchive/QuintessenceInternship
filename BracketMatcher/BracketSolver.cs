using System;

namespace ExtraProject1
{
    class BracketMatcher
    {
        private Char valueToCheck;
        private Brackets brackets = new Brackets();
        private string pattern;

        public string Solve(string pattern)
        {
            this.pattern = pattern;
            while (this.pattern.Length != 0)
            {
                SetValueToCheck();
                if (!DoesBracketMatch(valueToCheck, this.pattern))
                {
                    //Add the value back to the end of the string for error checking
                    this.pattern += valueToCheck;
                    return CheckError();
                }
            }
            return "The string is correct.";
        }

        private void RemoveMatch(int index) 
            => pattern = pattern.Remove(index, 1);

        private void SetValueToCheck() 
        {
            valueToCheck = pattern[pattern.Length - 1];
            pattern = pattern.Remove(pattern.Length - 1, 1);
        }

        /**
        * Iterates through the remaining pattern to check if it has a corresponding 
        * bracket to valueToCheck
        * @return bool
        */
        private bool DoesBracketMatch(Char valueToCheck, string pattern) 
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (valueToCheck == brackets.GetCorrespondingBrackets()[pattern[i]])
                {
                    RemoveMatch(i); 
                    return true;
                }
            }
            return false;
        }

        private string CheckError()
        {
            if (pattern.Length == 1)
            {
                return string.Format(
                    "Error at end: {0}ing bracket '{1}' remains un{2}ed.", 
                    brackets.BracketType(pattern[0]), pattern[0], brackets.BracketTypeOpposite(pattern[0]));
            }
            return "error";
        }
    }
}