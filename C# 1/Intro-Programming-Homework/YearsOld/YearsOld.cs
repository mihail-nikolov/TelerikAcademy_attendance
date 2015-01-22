using System;


namespace YearsOld
{
    class YearsOld
    {
        static void Main(string[] args)
        {
            int curDay;
            int curMonth;
            int curYear;
            int curAge;
            int plusTenAge;
            Console.Write("day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("year: ");
            int year = int.Parse(Console.ReadLine());
            string curTime = DateTime.Now.ToString("dd MM yyyy");
            string[] curTimeArr = curTime.Split(' ');
            curDay = int.Parse(curTimeArr[0]);
            curMonth = int.Parse(curTimeArr[1]);
            curYear = int.Parse(curTimeArr[2]);

            if ((month > curMonth) || ((month == curMonth) && (day < curDay)))
            {
                curAge = curYear - year - 1;
                plusTenAge = curAge + 10;
                Console.WriteLine("Your Current age is: " + curAge);
                Console.WriteLine("After 10 years you will be: " + plusTenAge);
            }
            else
            {
                curAge = curYear - year;
                plusTenAge = curAge + 10;
                Console.WriteLine("Your Current age is: " + curAge);
                Console.WriteLine("After 10 years you will be: " + plusTenAge);
            }
            
        }
    }
}
