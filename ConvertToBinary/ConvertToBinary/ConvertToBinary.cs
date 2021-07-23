using System;
using System.Collections.Generic;

namespace ExtraProject
{
    class BinaryConverter
    {
        Matrix matrix;

        public BinaryConverter(Matrix matrix) => this.matrix = matrix;

        public string[,] LoopThroughAndConvert(string[,] matrix)
        {
            for (int column = 1; column < matrix.GetLength(1); column++)
            {
                if (!IsInputValid(matrix[0, column]))
                    continue;

                string binaryConversion = ConvertToBinary(matrix[0, column]);
                this.matrix.AddBinaryToMatrix(matrix, binaryConversion, column); 
            }
            return matrix;
        }

        public bool IsInputValid(string input)
        {
            int value;
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("'{0}' is not a valid input", input);
                return false;
            }
            if (0 > value || value > 255)
            {
                Console.WriteLine("'{0}' is out of range", value);
                return false;
            }
            return true;
        }

        public string ConvertToBinary(string stringNumber)
        {
            int[] multiplesOfTwo = {128, 64, 32, 16, 8, 4, 2, 1};
            int numberToCheck = int.Parse(stringNumber);
            string output = "";

            foreach (int number in multiplesOfTwo)
            {
                if (numberToCheck - number >= 0)
                {
                    numberToCheck -= number;
                    output += "1";
                }
                else
                    output += "0";
            }
            return output;
        }
    }
}