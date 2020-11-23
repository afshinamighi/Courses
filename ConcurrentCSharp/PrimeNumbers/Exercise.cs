using System;
using System.Diagnostics;
using System.Threading;

namespace Exercise
{
    public class PrimeNumbers
    {
        public PrimeNumbers() { }

        public static void printPrimes(int m, int M)
        {
            Boolean isPrime = true;

            if (m > M)
            {
                Console.WriteLine("invalid inputs");
                return;
            }

            for (int n = m; n <= M; n++)
            {
                if (n % 1000 == 0) // This condition fakes IO operations.
                    Thread.Sleep(200);

                for (int i = 2; i < n && isPrime; i++)
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }

                if (!isPrime)
                    isPrime = true;
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
