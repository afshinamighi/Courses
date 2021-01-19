using System;
using TaskExamples;
using System.Diagnostics;

namespace Asynchrounous
{
    class Program
    {
        static void ExampleTasks()
        {
            Console.WriteLine("First two (non-concurrent) tasks are going to be executed (ENTER to continue)");
            Console.ReadLine();

            new SynchronousTasks().PrintNewId();
            new SynchronousTasks().RunSomeTasks();

            Stopwatch sw = new Stopwatch();
            int result = 0;

            ConcurrentTasks ct = new ConcurrentTasks();
            Console.WriteLine("Now different ways of concurrent tasks are going to start, each will provide some performance measures");
            Console.WriteLine("First check the behaviour of each and then elapsed time for each will be printed (ENTER to continue)");
            Console.ReadLine();

            sw.Start();
            result = ct.InvokeAnInefficientAsyncTask().Result;
            sw.Stop();
            long elapsedInEfficientAsyncTask = sw.ElapsedMilliseconds;

            Console.WriteLine("Inefficient Async is finished (ENTER to continue)");
            Console.ReadLine();

            sw.Reset();
            sw.Start();
            result = ct.InvokeAnEfficientAsyncTask().Result;
            sw.Stop();
            long elapsedEfficientAsyncTask = sw.ElapsedMilliseconds;

            Console.WriteLine("Efficient Async is finished (ENTER to continue)");
            Console.ReadLine();

            sw.Reset();
            sw.Start();
            result = ct.InvokeMultithreadedTasks();
            sw.Stop();
            long elapsedMultithreadedTasks = sw.ElapsedMilliseconds;

            Console.WriteLine("Multithreaded tasks is finished ");
            Console.WriteLine("Elapsed time for InEfficientAsyncTasks = {0}", elapsedInEfficientAsyncTask);
            Console.WriteLine("Elapsed time for EfficientAsyncTasks = {0}", elapsedEfficientAsyncTask);
            Console.WriteLine("Elapsed time for MultithreadedTasks = {0}", elapsedMultithreadedTasks);


        }
        static void Main(string[] args)
        {
            Program.ExampleTasks();
        }
    }
}