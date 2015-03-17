using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    class Program
    {
        static void Main()
        {
            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(2, 2, 5);
            Console.WriteLine(point2.ToString());
            Console.WriteLine(point1.ToString());
            double distance = Calc3D.GetDistance(point1, point2);
            Console.WriteLine(distance);
            Console.WriteLine(Point3D.OPoint.ToString());
            Path myPath = new Path();
            myPath.AddPoint(point1);
            myPath.AddPoint(point2);
            PathStorage.Save(myPath, "file1.txt");
            Path newPath = PathStorage.Load("file1.txt");
            PathStorage.Save(myPath, "file3");

            GenericList<int> myArr = new GenericList<int>(4);
            myArr.Add(1);
            myArr.Add(2);
            foreach (var item in myArr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(myArr.ToString());
            myArr.Add(4);
            myArr.Add(15);
            myArr.Add(23);
            myArr.Insert(30, 5);
            myArr.Remove(2);
            Console.WriteLine(myArr.ToString());
            Console.WriteLine(myArr.Find(40));
            Console.WriteLine(myArr.ToString());
            Console.WriteLine(myArr.Count);
            GenericList<int> myArr1 = new GenericList<int>(4){1, 2, 3};
            foreach (var item in myArr1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(myArr.Min());
            Console.WriteLine(myArr.Max());
            Matrix<int> myMat1 = new Matrix<int>(2, 2);
            myMat1[0, 0] = 1;
            myMat1[0, 1] = 2;
            myMat1[1, 0] = 3;
            myMat1[1, 1] = 4;
            Matrix<int> myMat2 = new Matrix<int>(2, 2);
            myMat2[0, 0] = 1;
            myMat2[0, 1] = 2;
            myMat2[1, 0] = 3;
            myMat2[1, 1] = 4;
            var myMat3 = myMat1 + myMat2;
            for (int i = 0; i < myMat3.Rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < myMat3.Cols; j++)
                {
                    Console.Write(myMat3[i, j] + " ");
                }
            }
            Console.WriteLine();
            var myMatr4 = new Matrix<int>(2, 2);
            myMatr4[0, 0] = 1;
            myMatr4[0, 1] = 2;
            myMatr4[1, 0] = 3;
            myMatr4[1, 1] = 4;
            var myMatr5 = myMat1 * myMatr4;
            for (int i = 0; i < myMatr5.Rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < myMatr5.Cols; j++)
                {
                    Console.Write(myMatr5[i, j] + " ");
                }
            }
            SampleClass.Sample();
        }
    }
}
