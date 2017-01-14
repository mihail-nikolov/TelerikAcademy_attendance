namespace DSA_efficiency_HW
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class CourseStudentsOperations
    {
        public static string[] fileReader(string fileName)
        {
            string[] fileContentArr = new string[] { };
            using (StreamReader sr = new StreamReader(fileName))
            {
                string fileContent = sr.ReadToEnd();
                fileContentArr = fileContent.Split('\n');
            }
            return fileContentArr;
        }

        public static SortedDictionary<string, List<Student>> GetCourseInfo(string[] fileInfoArr)
        {
            var courseStudentDict = new SortedDictionary<string, List<Student>>();
            foreach (var item in fileInfoArr)
            {
                string[] lineInfo = Regex.Split(item, @" \|\ ");
                var student = new Student(lineInfo[0].Trim(), lineInfo[1].Trim());
                if (courseStudentDict.ContainsKey(lineInfo[2].Trim()))
                {
                    courseStudentDict[lineInfo[2].Trim()].Add(student);
                }
                else
                {
                    courseStudentDict[lineInfo[2].Trim()] = new List<Student> { student };
                }
            }
            return courseStudentDict;
        }
        public static void PrintSorted(SortedDictionary<string, List<Student>> courseStudentDict)
        {
            foreach (var item in courseStudentDict)
            {
                var studentsInCourse = item.Value;
                var students = studentsInCourse.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).Select(st => st.ToString()).ToList();
                var studentsString = String.Join(", ", students);
                Console.WriteLine(item.Key + ": " + studentsString);
            }
        }
    }
}
