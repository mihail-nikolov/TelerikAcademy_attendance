using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. Sequence n matrix

    We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
    Write a program that finds the longest sequence of equal strings in the matrix.
*/
namespace _3.SequenceOfNMatrix
{
    class SequenceOfNMatrix
    {
        static bool isDiagCase(string[,] matrix, int row, int col)
        {
            if ((row + 1 == matrix.GetLength(0)) || (col + 1 == matrix.GetLength(1)))
            {
                return false;
            }
            if (matrix[row, col] == matrix[row + 1, col + 1])
            {
                return true;
            }
            return false;
        }
        static bool isRowCase(string[,] matrix, int row, int col)
        {
            if (col + 1 == matrix.GetLength(1))
            {
                return false;
            }
            if (matrix[row, col] == matrix[row, col + 1])
            {
                return true;
            }
            return false;
        }
        static bool isColCase(string[,] matrix, int row, int col)
        {
            if (row + 1 == matrix.GetLength(0))
            {
                return false;
            }
            if (matrix[row, col] == matrix[row+1, col])
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            /*
             *                     {"s", "qq", "s"},
                                   {"pp", "pp", "s"},
                                   {"pp", "qq", "s"},
             
                                    {"ha", "fifi", "ho", "hi"},
                                   {"fo", "ha", "hi", "xx"},
                                   {"xxx", "ho", "ha", "xx"}
              */
            string[,] matrix = {
                                   {"s", "qq", "s"},
                                   {"pp", "pp", "s"},
                                   {"pp", "qq", "s"}
                               };
            Dictionary<string, int> strings = new Dictionary<string, int>();
            List<string> stringsList = new List<string> { };
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!strings.ContainsKey(matrix[row, col]))
                    {
                        stringsList.Add(matrix[row, col]);
                        strings.Add(matrix[row, col], 0);
                    }
                }
            }
            for (int i = 0; i < stringsList.Count; i++ )
            {
                int diagCounter = 1;
                int diagMAXCounter = 1;
                int rowCounter = 1;
                int rowMAXCounter = 1;
                int colCounter = 1;
                int colMAXCounter = 1;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == stringsList[i])
                        {
                            bool answerDiag = isDiagCase(matrix, row, col);
                            if (answerDiag)
                            {
                                diagCounter++;
                                if (diagCounter > diagMAXCounter)
                                {
                                    diagMAXCounter = diagCounter;
                                }
                            }
                            else
                            {
                                if (diagCounter > diagMAXCounter)
                                {
                                    diagMAXCounter = diagCounter;
                                }
                                diagCounter = 1;
                            }
                            bool answerRow = isRowCase(matrix, row, col);
                            if (answerRow)
                            {
                                rowCounter++;
                                if (rowCounter > rowMAXCounter)
                                {
                                    rowMAXCounter = rowCounter;
                                }
                            }
                            else
                            {
                                if (rowCounter > rowMAXCounter)
                                {
                                    rowMAXCounter = rowCounter;
                                }
                                rowCounter = 1;
                            }
                            bool answerCol = isColCase(matrix, row, col);
                            if (answerCol)
                            {
                                colCounter++;
                                if (colCounter > colMAXCounter)
                                {
                                    colMAXCounter = colCounter;
                                }
                            }
                            else
                            {
                                if (colCounter > colMAXCounter)
                                {
                                    colMAXCounter = colCounter;
                                }
                                colCounter = 1;
                            }
                        }
                    }
                    
                }
                int theMaxCount = (Math.Max(Math.Max(diagMAXCounter, rowMAXCounter), colMAXCounter));
                if (theMaxCount > strings[stringsList[i]])
                {
                    strings[stringsList[i]] = theMaxCount;
                }
            }
            foreach (KeyValuePair<string, int> kvp in strings)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }
            int theMaxValue = 0;
            string theMaxValueString = "";
            foreach (KeyValuePair<string, int> kvp in strings)
            {
                if (kvp.Value > theMaxValue)
                {
                    theMaxValue = kvp.Value;
                    theMaxValueString = kvp.Key;
                }
            }
            Console.WriteLine("theMaxValueString = {0}, theMaxValue = {1}",theMaxValueString, theMaxValue);
        }
    }
}
