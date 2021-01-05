using System;

namespace Exercise
{
    // Read the code of this class carefully: using the code try to analyze shared memory, critical section, data race.  
    public class Counter
    {
        private readonly Object mutex = new Object();

        public int count { get; set; }

        public Counter() { count = 0; }

        public void incrementThreadSafe()
        {
            lock (mutex) { // lock occures here

                this.count++;
                // more tasks 

            } // unlock happens here
        }

        public void incrementUpTo(int n)
        {
            for (int i = 0; i < n; i++)
                this.increment();
        }

        public void reset() { this.count = 0; }

        /// <summary>
        /// Increments the counter by one: it is not thread safe.
        /// </summary>
        public void increment() {
            this.count++; // this.count = this.count + 1;
        }

        /// <summary>
        /// Increments the counter using a lock to be thread safe.
        /// </summary>
        public void incrementUpToThreadSafe(int n)
        {
            for (int i = 0; i < n; i++)
                this.incrementThreadSafe();
        }
    }
}
