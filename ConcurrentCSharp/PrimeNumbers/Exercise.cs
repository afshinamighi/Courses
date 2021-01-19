using System;
using System.Diagnostics;
using System.Threading;

namespace Exercise
{
    public class PrimeNumbers
    {
        public PrimeNumbers() { }

        public static void printPrimes(int lower, int upper)
        {
            Boolean isPrime = true;

            if (lower > upper)
            {
                Console.WriteLine("invalid inputs");
                return;
            }

            for (int n = lower; n <= upper; n++)
            {
                if (n % 1000 == 0) // This condition fakes an IO operation.
                    Thread.Sleep(100);

                isPrime = true; // assume n is a prime number

                for (int i = 2; i < n && isPrime; i++)
                    if (n % i == 0)
                        isPrime = false; // our assumption was not correct

                if (isPrime) 
                    Console.WriteLine("{0}",n); // report prime number if our assumption was correct
            }

        }

        public void runSequential(int m, int M)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            PrimeNumbers.printPrimes(m, M);
            sw.Stop();

            Console.WriteLine("Time for sequential version is {0} msec,", sw.ElapsedMilliseconds);
        }
    }
}
