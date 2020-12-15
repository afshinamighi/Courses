using System;
using System.Collections.Generic;
using System.Threading;

namespace Exercise
{
    public class PCInformation
    {   public int dataValue { get; set; } }

    public class Simulator
    {
        public LinkedList<PCInformation> buffer;
        public Object mutexObj;

        public int minTime { get; set; }
        public int maxTime { get; set; }

        public Simulator(int min, int max)
        {
            buffer = new LinkedList<PCInformation>();
            mutexObj = new object();
        }

        // one instance of producer and one instance of consumer are working sequentially
        public void sequentialOneProducerOneConsumer()
        {
            int iterations = 100;
            Console.Out.WriteLine("[Sequential Simulator] is going to start ....");
            Producer p = new Producer(this.minTime, this.maxTime, this.buffer, this.mutexObj);
            Consumer c = new Consumer(this.minTime, this.maxTime, this.buffer, this.mutexObj);

            for (int i = 0; i < iterations; i++)
            {
                p.produce();
                c.consume();
            }

            checkBuffer();

        }

        // one instance of producer and one instance of consumer are working concurrently: each can produce / consume multiple items
        public void concurrentOneProducerOneConsumer(int iterations)
        {

            Console.Out.WriteLine("[Concurrent Simulator] is going to start ....");
            Producer p = new Producer(this.minTime, this.maxTime, this.buffer, this.mutexObj);
            Consumer c = new Consumer(this.minTime, this.maxTime, this.buffer, this.mutexObj);

            Thread producerThread = new Thread(() => p.MultiProduce(iterations));
            Thread consumerThread = new Thread(() => c.MultiConsume(iterations));

            Thread.Sleep(100);

            producerThread.Start();
            consumerThread.Start();


            // producer and consumer are busy concurrently

            producerThread.Join();
            consumerThread.Join();

            checkBuffer();

        }

        public void checkBuffer()
        {
            Console.Out.WriteLine("[Simulator] Current number of remaining items in the buffer {0}", buffer.Count);
        }

    }
}
