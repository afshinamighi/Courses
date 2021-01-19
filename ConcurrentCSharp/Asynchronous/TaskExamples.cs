using System;
using System.Threading.Tasks;
using System.Threading;

namespace TaskExamples
{
    class Operations
    {
        // This is an example of mostly IO-bound operation
        public static void PrintConsole(int iteration, int wait_time)
        {
            for (int i = 0; i < iteration; i++)
            {
                Console.WriteLine("Task prints {0} ", i);
                Thread.Sleep(wait_time);
            }
        }

        // Finding prime numbers between two given nimbers: this is an example of mixed IO-bound and CPU-bound operation 
        public static int FindPrimes(int lower, int upper)
        {
            Boolean isPrime = true;
            int count = 0;

            if (lower > upper)
            {
                Console.WriteLine("invalid inputs");
                return -1;
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
                {
                    Console.WriteLine("{0} is a prime", n); // report prime number if our assumption was correct
                    count++;
                }
            }
            return count;
        }
    }
    class SynchronousTasks
    {
        public void RunSomeTasks()
        {
            // check: how a task can be created and executed.
            Task printingTask = Task.Run(() => { Console.WriteLine("\n A separate task is printing this ..."); });

            //check: how a task with a return values is created and how the result is captured.
            Task<string> taskWithStringResult = Task.Run(() => { return "\n Hello World from a task."; });
            Console.WriteLine("\n task with string result returns {0} ", taskWithStringResult.Result);

            // check: how an instance from Task with more computations is executed 
            Task<int> timeConsumingTask = Task.Run(() =>
            {
                // Assume a very heavy calculation is happening here ...
                int r = new Random().Next();
                Thread.Sleep(3000); // wait for a few seconds ...
                return r;
            });
            Console.WriteLine("\n task with a heavy calculation returns {0}", timeConsumingTask.Result);

        }

        // check: how a function can return a task with an int result
        public Task<int> GetNewId()
        {
            Task<int> newIdTask = new Task<int>(() => new Random().Next());
            return newIdTask;
        }

        // check: how a defined task is starting.
        public void PrintNewId()
        {
            var idTask = this.GetNewId();
            idTask.Start();
            // check: how the result of the task is used
            // Below the task will be called. The operation will block until the result is available.
            Console.WriteLine("A Task with New id = {0}",idTask.Result); 
        }
    }

    class ConcurrentTasks
    {
        int wait_time = 20, iterations = 1000, min_prime = 10, max_parime = 80000;

        // check: Why this is an inefficient design of asynchronous?
        public async Task<int> InvokeAnInefficientAsyncTask()
        {
            int c = 0;

            Task printTask = new Task(() => Operations.PrintConsole(iterations, wait_time)); // io bound 
            Console.WriteLine(" Now an Async task is going to be called ...");
            printTask.Start();

            await printTask;

            c = Operations.FindPrimes(min_prime, max_parime);  // mostly CPU bound task 

            Console.WriteLine(" All the tasks are ready here ...");
            return c;
        }

        public async Task<int> InvokeAnEfficientAsyncTask()
        {
            int c = 0;
            Task printTask = new Task(()=>Operations.PrintConsole(iterations,wait_time));
            Console.WriteLine(" Now an Async task is going to be called ...");
            printTask.Start();

            c = Operations.FindPrimes(min_prime, max_parime);

            // check: what will be the result if we do not await for printTask? Comment this line and check the output.

            await printTask;
            Console.WriteLine(" All the tasks are ready here ...");
            return c;
        }

        public int InvokeMultithreadedTasks()
        {
            int c = 0;
            Thread printingThread = new Thread(() => Operations.PrintConsole(iterations, wait_time));
            // check: how we get return value of a thread
            Thread primeNumThread = new Thread(()=> { c = Operations.FindPrimes(min_prime, max_parime); });

            printingThread.Start();
            primeNumThread.Start();

            printingThread.Join();
            primeNumThread.Join();

            return c;
        }
    }
}