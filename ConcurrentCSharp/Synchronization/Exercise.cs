using System;
using System.Threading;

namespace Exercise
{
    public class SynchronizationExamples
    {
        /// <summary>
        /// Counts the counter multiple times up to the given limit.
        /// </summary>
        /// <param name="steps">specifies the number of counters.</param>
        /// <param name="limit">specifies the limit of the counter.</param>
        public void countMultipleTimes(int steps, int limit)
        {
            Counter counter = new Counter();
            for (int x = 0; x < steps; x++)
                counter.incrementUpTo(limit);

            Console.WriteLine("[Sequential counter] {0} times count, each up to {1}, expected result of the counter = {2}, value of the counter={3}", steps, limit, (steps * limit), counter.count);

        }

        /// <summary>
        /// Counts the counter multiple times concurrently.
        /// Note: Analyse and justify final results.
        /// </summary>
        /// <param name="steps">defines how many times the counter will count.</param>
        /// <param name="limit">Defines the limit of the counter in each step.</param>
        public void countMultipleTimesConc(int steps, int limit)
        {
            Counter counter = new Counter();
            Thread[] threads = new Thread[steps];

            for (int i = 0; i < steps; i++)
                threads[i] = new Thread(() => { counter.incrementUpTo(limit); });

            for (int i = 0; i < steps; i++)
                threads[i].Start();


            for (int i = 0; i < steps; i++)
                threads[i].Join();

            Console.WriteLine("[Concurrent counter] {0} times count, each up to {1}: expected result of the counter = {2}, value of the counter={3}", steps, limit, steps * limit, counter.count);
        }

        /// <summary>
        /// Counts a protected counter multiple times concurrently.
        /// Note: Analyse and justify final results.
        /// </summary>
        /// <param name="steps">defines how many times the counter will count.</param>
        /// <param name="limit">Defines the limit of the counter in each step.</param>
        public void countMultipleTimesConcTSafe(int steps, int limit)
        {
            Counter counter = new Counter();
            Thread[] threads = new Thread[steps];

            for (int i = 0; i < steps; i++)
                threads[i] = new Thread(() => { counter.incrementUpToThreadSafe(limit); });
            for (int i = 0; i < steps; i++)
                threads[i].Start();
            for (int i = 0; i < steps; i++)
                threads[i].Join();

            Console.WriteLine("[Thread Safe Concurrent counter] {0} times count, each up to {1}: expected result of the counter = {2}, value of the counter={3}", steps, limit, steps * limit, counter.count);
        }
    }
}
