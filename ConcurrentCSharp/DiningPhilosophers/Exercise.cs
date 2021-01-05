using System;
using System.Threading;

namespace Exercise
{
    public class Fork
    {
        private readonly Object using_lock = new object();
        public int id { get; set; }
        public int users { get; set; }
        public Fork(int id) { users = 0; this.id = id; }
        public void pick()
        {
            lock (using_lock)
            {
                users++;
                if (users > 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Fork {0}] Multiple users ... ", this.id);
                    Console.ResetColor();
                }
            }
        }
        public void release()
        {
            lock (using_lock)
            {
                users--;
                if (users < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Fork {0}] Negative users ... ", this.id);
                    Console.ResetColor();
                }
            }
        }
    }
    public class Philosopher
    {
        public Fork rightFork { get; set; }
        public Fork leftFork { get; set; }
        public int maxEatingTime = 100;
        public int number;
        public Philosopher(int n)
        {
            this.number = n;
        }
        public void eat()
        {
            Console.WriteLine("[{0} started eating ...]", number);
            Thread.Sleep(new Random().Next(1, maxEatingTime));
            Console.WriteLine("[{0} finished eating ...]", number);
        }
        // this method implement eating with only one resource: enough resources, therefore no deadlock should occur
        public void eatWithOneFork()
        {

            Console.WriteLine("[{0} waiting for fork {1} ...]", number, rightFork.id);
            lock (rightFork)
            {
                rightFork.pick();
                this.eat();
                rightFork.release();
            }
        }
        // todo: lock required resources (forks) in a correct order
        public virtual void eatWithTwoForks()
        {
            Console.WriteLine("[{0} waiting for right fork ...]", number);
            rightFork.pick();
            Console.WriteLine("[{0} picked right fork {1}, waiting for left fork {2} ...]", number, rightFork.id, leftFork.id);
            leftFork.pick();
            this.eat();
            leftFork.release();
            rightFork.release();
        }
        public void startEatingWithOneFork(Object it)
        {
            int iterations = (int)it;
            for (int i = 0; i < iterations; i++)
                this.eatWithOneFork();
        }

        public void startEatingWithTwoForks(Object it)
        {
            int iterations = (int)it;
            for (int i = 0; i < iterations; i++)
                this.eatWithTwoForks();
        }
    }
    public class Table
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
                forks[i] = new Fork(i + 1);
                philosophers[i] = new Philosopher(i+1);
            }
            int rightIndex = 0, leftIndex = 0;
            for (int i = 0; i < num; i++)
            {
                rightIndex = (i) % (num);
                leftIndex = ((i + num - 1) % (num));
                philosophers[i].rightFork = forks[rightIndex];
                philosophers[i].leftFork = forks[leftIndex];
                Console.WriteLine("Philosopher {0} sitting with right fork {1} left fork {2}", philosophers[i].number, philosophers[i].rightFork.id, philosophers[i].leftFork.id);
            }
        }
        public void startOneForkDining(int it)
        {
            for (int i = 0; i < threads.Length; i++)
                threads[i] = new Thread(philosophers[i].startEatingWithOneFork);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Start(it);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
        public void startTwoForksDining(int it)
        {
            for (int i = 0; i < threads.Length; i++)
                threads[i] = new Thread(philosophers[i].startEatingWithTwoForks);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Start(it);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
