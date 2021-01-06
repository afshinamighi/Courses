using System;
using System.Threading;

/// <summary>
/// Buffer: is implemented as a two cells array. Assumed empty at the beginning.
/// Buffer::write(): writes a value at empty index and moves the index forward.
/// Buffer::read(): finds the index to read (next index after empty index, because it has only two cells) and reads the value.
/// Producer: only writes
/// Consumer: only reads
/// </summary>

// todo 4: Check methods Producer::produce() and Consumer::consume(). Using defined semaphores, protect shared memory.
namespace ProducerConsumer
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

            buffer[emptyIndex]++; // for simplicity we just increment the value at empty current empty index
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine("[Producer {0}] wrote {1} at index {2}", pid.ToString(), buffer[emptyIndex].ToString(), emptyIndex.ToString());
            Console.ForegroundColor = ConsoleColor.Black;

            emptyIndex = (emptyIndex + 1) % buffer.Length;


        }
        public int read(int cid)
        {
            int readIndex = (emptyIndex + buffer.Length - 1) % buffer.Length; // calculate which index must be read
            int result = buffer[readIndex]; // read the value at reading index
            Console.Out.WriteLine("[Consumer {0}] read {1} from index {2} ", cid.ToString(), result.ToString() , readIndex.ToString());
            return result;
        }
    }
    public class Producer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private int id { get; set; }
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
            //int data = new Random().Next();
            this.buffer.write(this.id); // we can ask buffer to write generated data
            
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
            int data = this.buffer.read(this.id);
        }
        public void MultiConsume(Object n)
        {
            int num = (int)n;
            for (int i = 0; i < num; i++)
                this.consume();
        }
    }
}
