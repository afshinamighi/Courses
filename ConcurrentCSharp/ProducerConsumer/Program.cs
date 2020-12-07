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

            Simulator simulator = new Simulator(10, 1000);
            // todo 1: uncomment this and check the result. Analyze the related code.
            //simulator.sequentialOneProducerOneConsumer();

            Console.ReadLine();

            // todo 2: uncomment this and check the result. Analyze the related code. Try with higher values for n.
            //int n = 100; 
            //simulator.concurrentOneProducerOneConsumer(n);
        }
    }
}
