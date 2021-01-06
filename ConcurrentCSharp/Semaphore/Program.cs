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

            //todo 1: Uncomment the following statement and analyze the behaviour of the program. 
            //pcSimulator.sequentialOneProducerOneConsumer();
            //todo 3: Uncomment the following statement and analyze the behaviour of the program. 
            pcSimulator.concurrentOneProducerOneConsumer();
            //todo 5: Uncomment the following statement and analyze the behaviour of the program. 
            //pcSimulator.concurrentMultiProducerMultiConsumer();

            Console.WriteLine("[END]");
        }
    }
}
