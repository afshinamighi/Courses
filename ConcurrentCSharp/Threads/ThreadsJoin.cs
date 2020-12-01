using System;
using System.Threading;

namespace Exercise
{
    /// <summary>
    /// Class <c>Counter</c> models a simple sequential counter which increments its state.
    /// </summary>
    public class Counter
    {
        public string Name { get; set; }
        public int State { get; set; }

        public Counter(string n)
        {
            this.Name = n;
            this.State = 0;
        }

        /// <summary>
        /// Counts (increments by one) this instance.
        /// </summary>
        /// <returns>The State.</returns>
        public int count()
        {
            this.State++;
            return this.State;
        }

        /// <summary>
        /// Counts up to a certain number.
        /// </summary>
        public void countUntil()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(this.Name + this.count().ToString());
            }
        }
    }


    /// <summary>
    /// - puting a thread in sleep
    /// - joining threads
    /// </summary>
    public class ThreadsJoin
    {
        public int WT { get; set; }

        public ThreadsJoin(int t)
        {
            this.WT = t;  // The amount of the time that the thread will sleep
        }

        public void runTasks()
        {

            /// We instantiate two objects from the counter.
            Counter c_A = new Counter("A");
            Counter c_B = new Counter("B");

            /// We create two threads of execution. Each has a task to count until a certain number.
            Thread t_A = new Thread(c_A.countUntil);
            Thread t_B = new Thread(c_B.countUntil);

            Console.WriteLine("Thread id is:" + t_A.ManagedThreadId.ToString());
            Console.WriteLine("Thread id is:" + t_B.ManagedThreadId.ToString());
            // wait for a short period
            Thread.Sleep(WT);

            /// We start both threads here.
            t_A.Start();
            t_B.Start();

            // wait for a short period
            Thread.Sleep(WT);

            /// The main thread waits here for both threads to join.
            t_A.Join();
            t_B.Join();

            Console.WriteLine("Both counter threads joined to the main thread.");
        }

        public void runExample()
        {
            Console.WriteLine("This example represents how two counting threads will join to the main thread after finishing their tasks");
            this.runTasks();
        }
    }
}
