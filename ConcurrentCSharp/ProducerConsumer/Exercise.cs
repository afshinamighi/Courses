using System;
using System.Collections.Generic;
using System.Threading;

namespace Exercise
{
    class PCInformation
    {        public int dataValue { get; set; } }
    class Producer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private LinkedList<PCInformation> buffer;
        private Object mutex;

        public Producer(int min, int max, LinkedList<PCInformation> buf, Object mutex)
        {
            this.minTime = min;
            this.maxTime = max;
            this.buffer = buf;
            this.mutex = mutex;
        }
        public void produce()
        {
            Thread.Sleep(new Random().Next(minTime, maxTime));
            PCInformation data = new PCInformation();
            data.dataValue = new Random().Next();
            lock (this.mutex)
            {
                buffer.AddLast(data); // an item is added to the end of the list
                Console.Out.WriteLine("[Producer] {0} is inserted", data.dataValue.ToString());
            }
        }
        public void MultiProduce(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.produce();
            }
        }
    }
    class Consumer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private LinkedList<PCInformation> buffer;
        private Object mutex;

        public Consumer(int min, int max, LinkedList<PCInformation> buf, Object mutex)
        {
            this.minTime = min;
            this.maxTime = max;
            this.buffer = buf;
            this.mutex = mutex;
        }
        public void consume()
        {
            Thread.Sleep(new Random().Next(minTime, maxTime));
            PCInformation data;
            lock (this.mutex)
            {
                if (buffer.Count > 0)
                {
                    data = buffer.First.Value;
                    buffer.RemoveFirst(); // an item is removed from the beginning of the list
                    Console.Out.WriteLine("[Consumer] {0} is consumed", data.dataValue.ToString());
                }
                else
                {
                    Console.Out.WriteLine("[Consumer] EMPTY BUFFER");
                }
            }
        }
        public void MultiConsume(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.consume();
            }

        }
    }
    class Simulator
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

        public void sequentialOneProducerOneConsumer()
        {
            int iterations = 100;
            Console.Out.WriteLine("[SeqSimulator] is going to start ....");
            Producer p = new Producer(this.minTime, this.maxTime, this.buffer, this.mutexObj);
            Consumer c = new Consumer(this.minTime, this.maxTime, this.buffer, this.mutexObj);

            for (int i = 0; i < iterations; i++)
            {
                p.produce();
                c.consume();
            }

            checkBuffer();

        }

        public void concurrentOneProducerOneConsumer()
        {
            int iterations = 100;

            Console.Out.WriteLine("[SeqSimulator] is going to start ....");
            Producer p = new Producer(this.minTime, this.maxTime, this.buffer, this.mutexObj);
            Consumer c = new Consumer(this.minTime, this.maxTime, this.buffer, this.mutexObj);

            Thread producerThread = new Thread(() => p.MultiProduce(iterations));
            Thread consumerThread = new Thread(() => c.MultiConsume(iterations));

            Thread.Sleep(100);

            producerThread.Start();
            consumerThread.Start();

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
