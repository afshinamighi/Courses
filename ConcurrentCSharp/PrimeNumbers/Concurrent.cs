using System;
using System.Diagnostics;
using System.Threading;
using Exercise;

namespace Concurrent
{
    public class ConPrimeNumbers : PrimeNumbers
    {
        public ConPrimeNumbers()
        {
        }
        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="m"> is the minimum number</param>
        /// <param name="M"> is the maximum number</param>
        /// <param name="nt"> is the number of threads. For simplicity assume two.</param>
        public void runConcurrent(int m, int M, int nt)
        {
            // Todo 1: Create nt (lets assume nt=2) number of threads, define their segments and start them. Join them all to have all the work done.
        }

    }
}
