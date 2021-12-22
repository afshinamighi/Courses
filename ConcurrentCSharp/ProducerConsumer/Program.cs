using Exercise;
using System;
using System.Threading;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int wt = 1000;

            Simulator simulator = new Simulator(10, wt);
            // todo 1: uncomment this and check the result. Analyze the related code.
            Console.Clear();
            Console.WriteLine("Sequential version ....");
            simulator.sequentialOneProducerOneConsumer();

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Concurrent (one producer one consumer) version ....");
            // todo 2: uncomment this and check the result. Analyze the related code. Try with higher values for n.
            int n = 100000; 
            simulator.concurrentOneProducerOneConsumer(n);
            // todo 3: Analyze the result of concurrentOneProducerOneConsumer(n). Is it working correctly? Is the program thread-safe? Analyse what could be the problem?
            // todo 4: Make the program thread-safe.

            // todo 5: uncomment the following code and analyze the execution and behaviour. Is the program safe?

            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine("Concurrent (multiple producer multiple consumer) version ....");
            //simulator.concurrentMultiProducerMultiConsumer(n,5);

        }
    }
}
