using System;
using System.Threading;

namespace Exercise
{
    /// <summary>
    /// This class presents how threads can be created and started.
    /// </summary>
    class ThreadCreation
    {
        private static void printCounts()
        {
            int c = 0, limit = 1000;
            for (c = 0; c < limit; c++)
                Console.Write("{0},", c);
        }

        private static void printChars(int n, char c)
        {
            // This method will print n copy of a given character
            for (int i = 0; i < n; i++)
                Console.Write("{0},", c);
        }

        /// <summary>
        /// Creates one thread: This example presents: 
        ///  - how to define a task, 
        ///  - how to create a thread, 
        ///  - how to start the execution of a thread.
        /// </summary>
        public void createOneThread()
        {
            Console.WriteLine("Press a key to start a counting thread ... ");
            Console.Read();
            // We create an instaince of Thread, with a given task
            // Note: Here the given task is defined using a (static) method.
            Thread tOne = new Thread(printCounts);

            // Check the next statement to see how to pass a task using a lambda expression.
            //Thread tOne = new Thread(() => { for (int c = 0; c < 1000; c++) Console.Write("{0},", c); });

            // Here we start the thread to perform the task
            tOne.Start();
            Console.WriteLine(" The main thread is going to terminate ... ");

        }

        /// <summary>
        /// Creates two Threads: This example shows:
        /// - creation of two threads.
        /// - the output result when threads are interleaved.
        /// </summary>
        public void createTwoXYThreads()
        {
            Console.WriteLine("Press a key to start two threads printing separate characters ... ");
            Console.Read();
            // Check: given tasks will be overlapped ... expect interleaved prints. Discuss why?
            Thread tOne = new Thread(() => { for (int i = 0; i < 10000; i++) Console.Write("X"); });
            Thread tTwo = new Thread(() => { for (int i = 0; i < 10000; i++) Console.Write("Y"); });

            tOne.Start();
            tTwo.Start();
            //h here we have two thrads running at the same time
            Console.WriteLine(" The main thread has terminated ... ");

        }

        /// <summary>
        /// Creates multiple threads: this example shows:
        /// - creation of multiple threads to be running in parallel.
        /// - passing parameters to the task.
        /// - check the output. Can you predict the pattern of interleaving?
        /// </summary>
        public void createMultipleThreads()
        {
            Console.WriteLine("Press a key to start multiple threads printing separate characters ... ");
            Console.Read();

            int num = 500;
            char[] chars = { 'A', 'B', 'C', 'D', 'E' };
            Thread[] threads = new Thread[chars.Length];

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                threads[i] = new Thread(() => ThreadCreation.printChars(num, c));
            }

            for (int i = 0; i < chars.Length; i++)
            {
                Console.WriteLine("{0}", threads[i].ThreadState);
                threads[i].Start();
                Console.WriteLine("{0}", threads[i].ThreadState);
                // Uncomment this to see the change of the states for each thread and its output separately
                // otherwise the results of the threads will be interleaved
                //Console.Read();
            }


            // Here the main thread waits for all to finish
            for (int i = 0; i < chars.Length; i++)
                threads[i].Join();

            Console.WriteLine(" The main thread has terminated ... ");

        }

        public void runExample()
        {
            Console.WriteLine(" This is an example where one / multiple threads will be running with independent tasks ");

            // todo 2.1: uncomment (only one at the time) the following statements to see the behaviour of the program

            //this.createOneThread();

            this.createTwoXYThreads();
            //this.createMultipleThreads();
        }
    }
}
