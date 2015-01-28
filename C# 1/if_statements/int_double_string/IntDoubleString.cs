using System;


namespace int_double_string
{
    class IntDoubleString
    {
        static void Main()
        {
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            Console.Write("your choice: ");
            string userChouce = Console.ReadLine();
            switch (userChouce)
            {
                case "1":
                case "2": 
                    Console.Write("enter number: ");
                    double num = double.Parse(Console.ReadLine()) + 1;
                    Console.WriteLine(num);
                    break;
                case "3": 
                    Console.Write("enter a string: ");
                    string choice = Console.ReadLine() + "*";
                    Console.WriteLine(choice);
                    break;
                default: Console.WriteLine("wrong choice!"); break;
            }
        }
    }
}
