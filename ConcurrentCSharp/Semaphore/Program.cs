using System;
using Exercise;

namespace Semaphores
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 10, max = 1000;

            ProducerConsumerSimulator pcSimulator = new ProducerConsumerSimulator(min,max);

            //todo 1: Uncomment the following statements, one at a time and check the behaviour of the program. 
            //pcSimulator.sequentialOneProducerOneConsumer();
            pcSimulator.concurrentOneProducerOneConsumer();
            //pcSimulator.concurrentMultiProducerMultiConsumer();

            Console.WriteLine("[END]");
        }
    }
}
