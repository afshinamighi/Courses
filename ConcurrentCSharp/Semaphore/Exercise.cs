using System;
using System.Threading;
using System.Collections.Generic;
using ProducerConsumer;
//using Solution;

namespace Exercise
{
    public class ProducerConsumerSimulator
    {
        public PCBuffer buffer;
        public Semaphore psem, csem;

        public int minTime { get; set; }
        public int maxTime { get; set; }

        public ProducerConsumerSimulator(int min, int max)
        {
            // todo 2: Check the buffer size and initial values of semaphores. Justify defined values.
            // Check it here: https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphore.-ctor?view=netcore-3.1

            buffer = new PCBuffer(2);
            psem = new Semaphore(1, 1);
            csem = new Semaphore(0, 1);
        }

        public void sequentialOneProducerOneConsumer()
        {
            int iterations = 100, pid = 1, cid = 1;
            Console.Out.WriteLine("[Sequential PC Simulator] is going to start ....");
            Producer p = new Producer(pid, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);
            Consumer c = new Consumer(cid, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);

            for (int i = 0; i < iterations; i++)
            {
                p.produce();
                c.consume();
            }
        }

        public void concurrentOneProducerOneConsumer()
        {
            int iterations = 100, pid = 1, cid = 1;

            Console.Out.WriteLine("[Concurrent PC Simulator] is going to start ....");
            Producer p = new Producer(pid, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);
            Consumer c = new Consumer(cid, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);

            Thread producerThread = new Thread(() => p.MultiProduce(iterations));
            Thread consumerThread = new Thread(() => c.MultiConsume(iterations));

            Thread.Sleep(100);

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

        }
        public void concurrentMultiProducerMultiConsumer()
        {
            int iterations = 100, num = 5;

            Console.Out.WriteLine("[Concurrent Multi PC Simulator] is going to start ....");
            Producer[] ps = new Producer[num];
            Consumer[] cs = new Consumer[num];
            LinkedList<Thread> threads = new LinkedList<Thread>();

            for (int i = 0; i < num; i++)
            {
                ps[i] = new Producer(i+1, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);
                cs[i] = new Consumer(i+1, this.minTime, this.maxTime, this.buffer, this.psem, this.csem);
            }

            for (int i = 0; i < num; i++)
            {
                threads.AddFirst(new Thread(ps[i].MultiProduce));
            }
            for (int i = 0; i < num; i++)
            {
                threads.AddFirst(new Thread(cs[i].MultiConsume));
            }

            foreach (Thread t in threads)
                t.Start(iterations);

            Thread.Sleep(100);

            foreach (Thread t in threads)
                t.Join();

            for (int i = 0; i < buffer.buffer.Length; i++)
                Console.WriteLine("[Buffer] {0} ", buffer.buffer[i]);

        }

    }
}
