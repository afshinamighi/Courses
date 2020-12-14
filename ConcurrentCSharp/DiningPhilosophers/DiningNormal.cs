using System;
using System.Threading;

namespace DiningNormal
{
    class Fork
    {

    }
    class Philosopher
    {
        public Fork fork { get; set; }
        public int maxEatingTime = 1000;
        public int number;
        public Philosopher(int n)
        {
            number = n;
        }
        // this method implement eating with only one resource: enough resources, therefore no deadlock should occur
        public void eat()
        {

            Console.WriteLine("[{0} waiting for the fork ...]", number);
            lock (fork)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("[{0} started eating ...]", number);
                Thread.Sleep(new Random().Next(10, maxEatingTime));
                Console.WriteLine("[{0} finished eating ...]", number);
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void startEating(Object it)
        {
            int iterations = (int)it;
            for (int i = 0; i < iterations; i++)
                this.eat();
        }
    }
    class Table
    {
        public Fork[] forks;
        public Philosopher[] philosophers;
        public Thread[] threads;
        public Table(int num)
        {
            forks = new Fork[num];
            philosophers = new Philosopher[num];
            threads = new Thread[num];

            for (int i = 0; i < num; i++)
            {
                forks[i] = new Fork();
                philosophers[i] = new Philosopher(i);
            }
            for (int i = 0; i < num; i++)
                philosophers[i % num].fork = forks[(i + 1) % num];
        }
        public void startSequentialDining(int it)
        {
            for (int i = 0; i < it; i++)
                philosophers[i % philosophers.Length].eat();
        }
        public void startConcurrentDining(int it)
        {
            for (int i = 0; i < threads.Length; i++)
                threads[i] = new Thread(philosophers[i].startEating);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Start(it);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
