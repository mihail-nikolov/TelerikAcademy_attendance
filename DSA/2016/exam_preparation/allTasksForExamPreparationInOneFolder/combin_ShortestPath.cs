namespace Problem3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static SortedSet<string> possibleDirections = new SortedSet<string>();
        private static char[] map;

        static void Main()
        {
            map = Console.ReadLine().ToCharArray();

            Find(0);
            Console.WriteLine(possibleDirections.Count);
            foreach (var direction in possibleDirections)
            {
                Console.WriteLine(direction.ToString());
            }
        }


        private static void Find(int position)
        {
            if (position == map.Length)
            {
                possibleDirections.Add(new string(map));
            }
            else if (map[position] != '*')
            {
                Find(position + 1);
            }
            else
            {
                map[position] = 'L';
                Find(position + 1);

                map[position] = 'R';
                Find(position + 1);

                map[position] = 'S';
                Find(position + 1);

                map[position] = '*';
            }
        }
    }
}
