using System;
using System.Threading;
/// <summary>
/// The semaphore of the producer is initialized with 1 (so the first producer thread will have a chance to fill the first cell) and
/// the consumer is initialized with 0 (so the first consumer thread has to wait, because nothing is produced yet)
/// </summary>
namespace Solution
{
    public class PCBuffer
    {
        public int[] buffer;
        public int emptyIndex { get; set; }

        public PCBuffer(int size)
        {
            buffer = new int[size];
            emptyIndex = 0;
        }
        public void write(int pid)
        {
            buffer[emptyIndex]++;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine("[Producer {0}] wrote {1} at index {2}", pid.ToString(), buffer[emptyIndex].ToString(), emptyIndex.ToString());
            Console.ForegroundColor = ConsoleColor.Black;

            emptyIndex = (emptyIndex + 1) % buffer.Length;
        }
        public int read(int cid)
        {
            int readIndex = (emptyIndex + buffer.Length - 1) % buffer.Length;
            int result = buffer[readIndex];
            Console.Out.WriteLine("[Consumer {0}] read {1} from index {2} ", cid.ToString(), result.ToString(), readIndex.ToString());
            return result;
        }
    }

    public class Producer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private int id {get; set; }
        private PCBuffer buffer;
        private Semaphore producerSemaphore, consumerSemaphore;

        public Producer(int id, int min, int max, PCBuffer buf, Semaphore psem, Semaphore csem)
        {
            this.id = id;
            this.minTime = min;
            this.maxTime = max;
            this.buffer = buf;
            this.producerSemaphore = psem;
            this.consumerSemaphore = csem;
        }
        public void produce()
        {
            Thread.Sleep(new Random().Next(minTime, maxTime));

            producerSemaphore.WaitOne();
            this.buffer.write(this.id);
            consumerSemaphore.Release();
        }
        public void MultiProduce(Object n)
        {
            int num = (int)n;
            for (int i = 0; i < num; i++)
                this.produce();
        }
    }
    public class Consumer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private int id { get; set; }
        private PCBuffer buffer;
        private Semaphore producerSemaphore, consumerSemaphore;

        public Consumer(int id, int min, int max, PCBuffer buf, Semaphore psem, Semaphore csem)
        {
            this.id = id;
            this.minTime = min;
            this.maxTime = max;
            this.buffer = buf;
            this.producerSemaphore = psem;
            this.consumerSemaphore = csem;
        }
        public void consume()
        {
            Thread.Sleep(new Random().Next(minTime, maxTime));

            consumerSemaphore.WaitOne();
            int data = this.buffer.read(this.id);
            producerSemaphore.Release();
        }
        public void MultiConsume(Object n)
        {
            int num = (int)n;
            for (int i = 0; i < num; i++)
                this.consume();
        }
    }
}
