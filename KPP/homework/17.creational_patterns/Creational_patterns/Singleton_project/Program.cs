namespace Singleton_project
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            Sun theSun = Sun.SunInstance;
            theSun.Shine();
        }
    }
}
