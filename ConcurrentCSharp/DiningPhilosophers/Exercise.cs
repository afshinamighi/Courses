using System;
using System.Threading;

namespace Exercise
{
    class Fork
    {

    }
    class Philosopher
    {
        public Fork rightFork { get; set; }
        public Fork leftFork { get; set; }
        // Hint: After finishing other todos, experiment with different values: smaller and larger numbers.
        //  Higher max time, higher probability of late deadlock
        public int maxTime = 200;
        public int number;
        public Philosopher(int n)
        {
            number = n;
        }
        public void eat()
        {
            //todo: In this version, eating is happening without locking shared resources: forks. Lock one right fork, then lock one left fork to have safe eating...
            Console.WriteLine("[{0} waiting for the right fork ...]", number);
            Console.WriteLine("[{0} waiting for the left fork ...]", number);
            Console.WriteLine("[{0} started eating ...]", number);
            Thread.Sleep(new Random().Next(10, maxTime));
            Console.WriteLine("[{0} finished eating ...]", number);
        }

        public void startEating(Object it)
        {
            Thread.Sleep(new Random().Next(10, maxTime));
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
            int rightIndex = 0, leftIndex = 0;
            for (int i = 0; i < num; i++)
            {
                rightIndex = (i) % (num);
                leftIndex = ((i + num - 1) % (num));
                philosophers[i].rightFork = forks[rightIndex];
                Console.WriteLine("[Philosopher {0}] got right fork {1}", i, rightIndex);
                philosophers[i].leftFork = forks[leftIndex];
                Console.WriteLine("[Philosopher {0}] got left fork {1}", i, leftIndex);
            }
        }
        public void startConcurrentDining(int it)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                //todo: create the threads
            }
            for (int i = 0; i < threads.Length; i++)
            {
                //todo: start the threads
            }
            for (int i = 0; i < threads.Length; i++)
            {
                //todo: join to the threads
            }
        }
    }
}