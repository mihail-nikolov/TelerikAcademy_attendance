using System;


class Money
{
    static void Main(string[] args)
    {
        //Console.Write("N = ");
        double N = double.Parse(Console.ReadLine());
        //Console.Write("S = ");
        double S = double.Parse(Console.ReadLine());
       // Console.Write("P = ");
        double P = double.Parse(Console.ReadLine());

        double sheetInRealm = 400;
        double sheetsCount = N * S;
        double realmCount = sheetsCount / sheetInRealm;
        double savedMoney = realmCount * P;
        Console.WriteLine("{0:F3}", savedMoney);
    }
}

