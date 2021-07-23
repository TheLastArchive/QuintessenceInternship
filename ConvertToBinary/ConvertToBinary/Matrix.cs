using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraProject
{
    class Matrix
    {
        string[,] matrix;

        public Matrix(int rowLength) => matrix = new string[9, rowLength + 1];
       
        public string[,] GetMatrix() => matrix;

        public string[,] SetFirstRowAndColumn(string[,] outputMatrix, string[] userInputArray)
        {
            outputMatrix = SetFirstRow(outputMatrix, userInputArray);
            outputMatrix = SetFirstColumn(outputMatrix);
            return outputMatrix;
        }

        public string[,] SetFirstRow(string[,] outputMatrix, string[] userInputArray)
        {
            outputMatrix[0, 0] = "   ";

            for (int i = 0; i < userInputArray.Length; i++)
                outputMatrix[0, i + 1] = userInputArray[i];
            return outputMatrix;
        }

        public string[,] SetFirstColumn(string[,] outputMatrix)
        {
            string[] multiplesOfTwo = { "128", " 64", " 32", " 16", "  8", "  4", "  2", "  1" };

            for (int i = 0; i < 8; i++)
                outputMatrix[i + 1, 0] = multiplesOfTwo[i];
            return outputMatrix;
        }

        public string[,] AddBinaryToMatrix(string[,] matrix, string binary, int columnIndex)
        {
            for (int i = 0; i < binary.Length; i++)
                matrix[i + 1, columnIndex] = Char.ToString(binary[i]);
            return matrix;
        }

        public void PrintGrid(string[,] matrix)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == null)
                        Console.Write(" - ");
                    else
                        Console.Write(" {0} ", matrix[row, column]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
