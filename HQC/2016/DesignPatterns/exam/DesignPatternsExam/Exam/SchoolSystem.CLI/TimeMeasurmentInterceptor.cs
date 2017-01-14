using Ninject.Extensions.Interception;
using System;
using System.Diagnostics;

namespace SchoolSystem.Cli
{
    public class TimeMeasurmentInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string name = invocation.Request.Target.GetType().Name;
            string factoryName = name.Substring(0, name.Length - 5);
            Console.WriteLine($"Calling method of type {factoryName}...");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            invocation.Proceed();
            sw.Stop();

            var elapsed = sw.Elapsed.Milliseconds;
            Console.WriteLine($"Total execution time for method of type {factoryName} is {elapsed} milliseconds.");
        }
    }
}
