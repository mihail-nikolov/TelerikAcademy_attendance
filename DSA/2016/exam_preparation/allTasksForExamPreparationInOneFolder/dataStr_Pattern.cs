using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern
{
    class MainClass
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 10)
            {
                throw new ArgumentException("");
            }

            string figure = DrawFigure(n);

            // Your solution goes here
            Console.WriteLine(figure);

            // comment before submitting
            //Svg.WriteToFile("output.svg", figure);
        }

        public static string DrawFigure(int n)
        {
            if (n == 1)
            {
                return "urd";
            }
            string lastFigure = DrawFigure(n - 1);
            string newFigure = Rotate("right", lastFigure) + "u" + lastFigure + "r" + lastFigure + "d" + Rotate("left", lastFigure);
            return newFigure;
        }

        public static string Rotate(string direction, string figure)
        {
            StringBuilder newFigure = new StringBuilder();
            Dictionary<char, char> directionChanger;

            if (direction == "right")
            {
                directionChanger = new Dictionary<char, char>
                {
                    { 'u','r'},{ 'r','u'}, { 'd','l'}, { 'l','d'}
                };
            }
            else if (direction == "left")
            {
                directionChanger = new Dictionary<char, char>
                {
                    { 'u','l'},{ 'l','u'}, { 'r','d'}, { 'd','r'},
                };
            }
            else
            {
                throw new ArgumentException("wrong direction");
            }

            for (int i = 0; i < figure.Length; i++)
            {
                newFigure.Append(directionChanger[figure[i]]);
            }   
            return newFigure.ToString().TrimEnd();
        }
    }
}
