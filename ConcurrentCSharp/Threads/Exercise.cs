using System;
using System.Threading;
using System.Diagnostics;


namespace Exercise
{
    public class ExamplesThreadBasics
    {
        /// <summary>
        /// This class prints information about threads running within a process
        /// </summary>
        public class ThreadsList
        {
            // Prints basic information of the threads running within a process
            public void printThreads()
            {
                Console.WriteLine(" This method is going to print information of threads ... ");
                // Get the current process
                Process proc = System.Diagnostics.Process.GetCurrentProcess();

                // Print the information of the process
                Console.WriteLine("process: {0},  id: {1}", proc.ProcessName, proc.Id);

                // Print basic information for each thread
                foreach (ProcessThread pt in proc.Threads)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine(" Thread: {0}, CPU time: {1}, Priority: {2}, Thread state: {3}", pt.Id, pt.TotalProcessorTime, pt.BasePriority, pt.ThreadState.ToString());
                }
            }

            public void runExample()
            {
                this.printThreads();
            }
        }
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
                Thread tOne = new Thread(() => { for (int i = 0; i < 1000; i++) Console.Write("X"); });
                Thread tTwo = new Thread(() => { for (int i = 0; i < 1000; i++) Console.Write("Y"); });

                tOne.Start();
                tTwo.Start();
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
                // todo 1: uncomment the following statements to see the behaviour of the program (only one at the time)
                //this.createOneThread();
                //this.createTwoXYThreads();
                //this.createMultipleThreads();
            }
        }

        /// <summary>
        /// Class <c>Counter</c> models a simple sequential counter which increments its state.
        /// </summary>
        public class Counter
        {
            public string Name { get; set; }
            public int State { get; set; }

            public Counter(string n)
            {
                this.Name = n;
                this.State = 0;
            }

            /// <summary>
            /// Counts (increments by one) this instance.
            /// </summary>
            /// <returns>The State.</returns>
            public int count()
            {
                this.State++;
                return this.State;
            }

            /// <summary>
            /// Counts up to a certain number.
            /// </summary>
            public void countUntil()
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(this.Name + this.count().ToString());
                }
            }
        }
        /// <summary>
        /// - puting a thread in sleep
        /// - joining threads
        /// </summary>
        public class ThreadsJoin
        {
            public int WT { get; set; }

            public ThreadsJoin(int t)
            {
                this.WT = t;  // The amount of the time that the thread will sleep
            }

            public void runTasks()
            {

                /// We instantiate two objects from the counter.
                Counter c_A = new Counter("A");
                Counter c_B = new Counter("B");

                /// We create two threads of execution. Each has a task to count until a certain number.
                Thread t_A = new Thread(c_A.countUntil);
                Thread t_B = new Thread(c_B.countUntil);

                Console.WriteLine("Thread id is:" + t_A.ManagedThreadId.ToString());
                Console.WriteLine("Thread id is:" + t_B.ManagedThreadId.ToString());
                // wait for a short period
                Thread.Sleep(WT);

                /// We start both threads here.
                t_A.Start();
                t_B.Start();

                // wait for a short period
                Thread.Sleep(WT);

                /// The main thread waits here for both threads to join.
                t_A.Join();
                t_B.Join();

                Console.WriteLine("Both counter threads joined to the main thread.");
            }

            public void runExample()
            {
                Console.WriteLine("This example represents how two counting threads will join to the main thread after finishing their tasks");
                this.runTasks();
            }
        }

        public void runExamples()
        {
            ThreadsList tl = new ThreadsList();
            // todo 2: uncomment this and check the execution
            //tl.runExample();

            ThreadCreation tc = new ThreadCreation();
            // todo 3: uncomment this and check the execution
            //tc.runExample();

            ThreadsJoin tj = new ThreadsJoin(2000);
            // todo 4: uncomment this and check the execution 
            //tj.runExample();
        }
    }
}
