using System;
using System.Diagnostics;
using System.Threading;
using Exercise;

/// <summary>
/// This example implements a concurrent version of finding and printing prime-numbers between two numbers.
/// </summary>

namespace Solution
{
    public class ConPrimeNumbers: PrimeNumbers
    {
        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="m"> is the minimum number</param>
        /// <param name="M"> is the maximum number</param>
        /// <param name="nt"> is the number of threads. For simplicity assume two.</param>
        public void runConcurrent(int m, int M)
        {
            int nt = 2; // number of devisions

            // Create nt number of threads, define their segments and start them. Join them all to have all the work done.
            Stopwatch sw = new Stopwatch();

            int numTs = nt;
            int s = (M - m) / nt;

            Thread[] ts = new Thread[numTs];
            // this loop divides numbers between m up to M to nt segments and each segment is given to a separate thread
            for (int i = 0; i < numTs; i++)
            {
                int l = m + s * i;
                int u = 0;
                if (i == numTs - 1)
                    u = M;
                else
                    u = m + s * (i + 1);

                ts[i] = new Thread(() => PrimeNumbers.printPrimes(l, u));
            }

            sw.Start();
            for (int i = 0; i < numTs; i++)
                ts[i].Start();

            // Here, the main thread can be busy with something else

            for (int i = 0; i < numTs; i++)
                ts[i].Join();

            sw.Stop();
            Console.WriteLine("Time for concurrent version with {0} threads is {1} msec,", nt, sw.ElapsedMilliseconds);
        }

    }
}
