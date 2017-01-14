using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablesDictionariesSets
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = new double[] { 1, 2, 3, 2, 2.5, -5, 1, -5, 2, 3, 2.5 };
            var valuesOcc = GetValueOccurenceDouble(values);
            foreach (var item in valuesOcc)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }


            string[] elements = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var elementsDict = GetValueOccurenceString(elements);
            var oddElements = GetVOddElements(elementsDict);
            foreach (var item in oddElements)
            {
                Console.Write("{0} ", item);
            }


            string filepath = @"E:\my documents\telerik\2015\DSA\04.HashTables\HashTablesHomework\HashTablesDictionariesSets\words.txt";
            var words = ReadFromTextFile(filepath);
            var sortedWords = GetSortedValueOccurence(words);
            foreach (var word in sortedWords.OrderBy(key => key.Value))
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }

        static Dictionary<double, int> GetValueOccurenceDouble(double[] values)
        {
            var valuesDict = new Dictionary<double, int>();
            for (int i = 0; i < values.Length; i++)
            {
                double value = values[i];
                if (valuesDict.ContainsKey(value))
                {
                    valuesDict[value] += 1;
                }
                else
                {
                    valuesDict[value] = 1;
                }
            }

            return valuesDict;
        }

        static Dictionary<string, int> GetValueOccurenceString(string[] values)
        {
            var valuesDict = new Dictionary<string, int>();
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i];
                if (valuesDict.ContainsKey(value))
                {
                    valuesDict[value] += 1;
                }
                else
                {
                    valuesDict[value] = 1;
                }
            }

            return valuesDict;
        }

        static Dictionary<string, int> GetSortedValueOccurence(string[] values)
        {
            var valuesDict = new Dictionary<string, int>();
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i];
                if (valuesDict.ContainsKey(value.ToLower()))
                {
                    valuesDict[value.ToLower()] += 1;
                }
                else
                {
                    valuesDict[value.ToLower()] = 1;
                }
            }

            return valuesDict;
        }

        static List<string> GetVOddElements(Dictionary<string, int> values)
        {
            var oddValuesList = new List<string>();
            foreach (var item in values)
            {
                if (item.Value % 2 != 0)
                {
                    oddValuesList.Add(item.Key);
                }
            }

            return oddValuesList;
        }

        static string[] ReadFromTextFile(string filepath)
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(filepath, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            var words = readContents.Split(new char[] { ' ', ',', '.', '!', '?',  ';', ':', '-' });
            return words;
        }

    }
}
