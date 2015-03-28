using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public abstract class Animal
    {
        private string name;
        private char sex;
        private int age;

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public char Sex
        {
            get { return this.sex; }
            protected set
            {
                if (value != 'M' || value != 'F')
                {
                    throw new ArgumentException("only M - male or F - female");
                }
                this.sex = value; // animals cannot change their sex, unlike humans :D
            } 
        }
        public int Age
        {
            get { return this.age; }
            private set 
            {
                if (value < 0 || value > 300)
                {
                    throw new ArgumentException("age range [0; 300]");
                }
                this.age = value; 
            }
        }
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Animal(string name, char sex, int age)
            :this(name, age)
        {
            this.Sex = sex;
        }
        
        public static double CalcAverageAge(Animal[] arr)
        {
            double sum = 0;
            foreach (var animal in arr)
            {
                sum += animal.age;
            }
            return sum / (arr.Length);
        }
    }
}
