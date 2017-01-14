namespace Problem2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {
        //private static Dictionary<int, int> tasksDict = new Dictionary<int, int>();

        public static void Main(string[] args)
        {
            int numOfTasks = int.Parse(Console.ReadLine());
            var tasksCharrArray = Console.ReadLine().Split(' ');

            List<List<int>> taskList = new List<List<int>>();
            for (int i = 0; i < numOfTasks; i++)
            {
                int depTask = int.Parse(Console.ReadLine());
                if (depTask == 0)
                {
                    taskList.Add(new List<int> { int.Parse(tasksCharrArray[i]), -1});
                }
                else
                {
                    taskList.Add(new List<int> { int.Parse(tasksCharrArray[i]), i + 1 });
                }
                
            }

            for (int i = 0; i < taskList.Count; i++)
            {
                var minAndDependToArr = taskList[i].ToArray();
                string joinedArr = string.Join(", ", minAndDependToArr.Select(x => x.ToString()));
                Console.WriteLine("{0} -> {1}",i+1, joinedArr);
            }
            
           // int result = Solve(tasksDict);
           // Console.WriteLine(result);
        }

        
        private void fillInTheDict(int[] tasks, int[] taskDependencies)
        {

        } 


        private static int Solve(Dictionary<int, int> tasksDict)
        {
            throw new NotImplementedException();
        }
    }
}
