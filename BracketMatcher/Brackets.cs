using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtraProject1
{
    class Brackets 
    {
        private Dictionary<Char, Char> correspondingBrackets = new Dictionary<Char, Char> 
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
            {'<', '>'},
            {'>', '<'},
            {']', '['},
            {'}', '{'},
            {')', '('}
        };

        public Dictionary<Char, Char> GetCorrespondingBrackets() 
            => correspondingBrackets;

        public string BracketType(Char bracket)
        {
            Char[] openBrackets = {'<', '{', '[', '('};

            if (openBrackets.Contains(bracket)) { return "open"; }
            return "clos";
        }

        public string BracketTypeOpposite(Char bracket)
        {
            Char[] openBrackets = {'<', '{', '[', '('};

            if (openBrackets.Contains(bracket)) { return "clos"; }
            return "open";
        }
    }
}