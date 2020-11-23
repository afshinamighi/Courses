using System;
using System.Diagnostics;
using System.Threading;
using Exercise;
using Concurrent;
//using Solution;

/// <summary>
/// This example implements a concurrent version of finding and printing prime-numbers between two given numbers.
/// </summary>
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int min = 5, max = 1000000, step = 4;
            int tMax = 3; // if your code is flexible with the number of threads, assign up to 8 or 10.

            ConPrimeNumbers pn = new ConPrimeNumbers();

            pn.runSequential(min, max);

            for(int t = 2; t < tMax; t += step)
            {
                Thread.Sleep(2000);
                pn.runConcurrent(min, max, t);
            }


        }
    }
}
