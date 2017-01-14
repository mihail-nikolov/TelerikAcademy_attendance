namespace Matrix
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            int[] numbersToAdd = new int[] { 0, 2, 3, 4 };

            mycrawler.FillInTheMatrix(numbersToAdd);

            Console.WriteLine(mycrawler.GetCellNumber(2, 2));
            Console.WriteLine(mycrawler.PrintMatrix());
        }
    }
}
