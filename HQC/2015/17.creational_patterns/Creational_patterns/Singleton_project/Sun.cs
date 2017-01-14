using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_project
{
    public sealed class Sun: IStar
    {
        private static volatile Sun sunInstance;
        private static object syncLock = new object();

        protected Sun() { }

        public static Sun SunInstance
        {
            get
            {
                if (sunInstance == null)
                {
                    lock(syncLock)
                    {
                         if (sunInstance == null)
                         {
                             sunInstance = new Sun();
                         }
                    }
                }
                return sunInstance;
            }
        }
        public void Shine()
        {
            Console.WriteLine("Sun is shining");
        } 
    }
}
