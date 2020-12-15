using System;
using System.Threading;
using Exercise;

namespace Program
{
    class Synchronization
    {
        static void Main(string[] args)
        {
            int until = 10000, times = 10, wt = 2000;
            SynchronizationExamples examples = new SynchronizationExamples();
            Console.WriteLine("Example:" + examples.GetType().Name);

            Thread.Sleep(wt);
            // todo 1: uncomment this and check the final result.
            examples.countMultipleTimes(times,until);

            Thread.Sleep(wt);
            // todo 2: uncomment this and check the final result. Is the final result reliable? Try to experiment several times.
            // Why the result is different in various scenarios? Check the implementation.
            examples.countMultipleTimesConc(times, until);

            Thread.Sleep(wt);
            // todo 3: uncomment this and check the final result. Is this result reliable? Why? Check the implementation.
            //examples.countMultipleTimesConcTSafe(times, until);

        }
    }
}
