using System;
using System.Threading;
using System.Collections.Generic;

namespace Exercise
{
    public class Producer
    {
        private int minTime { get; set; }
        private int maxTime { get; set; }
        private LinkedList<PCInformation> buffer;
        private Object mutex;
        private int item = 0;

        public Producer(int min, int max, LinkedList<PCInformation> buf, Object mutex)
        {
            this.minTime = min;
            this.maxTime = max;
            this.buffer = buf;
            this.mutex = mutex;
            this.item = 1;
        }
        public void produce()
        {
            // each producer will wait for a while (randomly) before producing items
            Thread.Sleep(new Random().Next(minTime, maxTime));

            PCInformation data = new PCInformation();
            data.dataValue = this.item++; // or a random value like:  new Random().Next();
            buffer.AddLast(data); // an item is added to the end of the list
            Console.Out.WriteLine("[Producer] {0} is inserted", data.dataValue.ToString());
        }

        // as soons as there is a chance, num of items will be produced
        public void MultiProduce(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.produce();
            }
        }
    }
}
