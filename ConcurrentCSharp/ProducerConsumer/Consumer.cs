using System;
using System.Threading;
using System.Collections.Generic;


namespace Exercise
{
    public class Consumer
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
            // each consumer waits for a period of time (randomly) before its consume action
            Thread.Sleep(new Random().Next(minTime, maxTime));

            PCInformation data;

            if (buffer.Count > 0)
            {
                data = buffer.First.Value;
                buffer.RemoveFirst(); // an item is removed from the beginning of the list
                Console.Out.WriteLine("[Consumer] {0} is consumed", data.dataValue.ToString());
            }
            else
                Console.Out.WriteLine("[Consumer] EMPTY BUFFER");
        }

        // as soon as there is a chance, num of items will be consumed
        public void MultiConsume(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.consume();
            }

        }
    }
}
