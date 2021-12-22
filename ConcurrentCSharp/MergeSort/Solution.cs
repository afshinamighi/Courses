using System;
using System.Threading;
using Exercise;

namespace Solution
{
    public class SolutionConcurrentMergeSort: ConcurrentMergeSort
    {
        // Implements concurrent version of MergeSort.
        public override void sortCon(int[] d)
        {
            // Todo 1: Instantiate an object of mergeSort.
            SequentialMergeSort mergeSort = new SequentialMergeSort(d);

            mergeSort.printContent();

            // Todo 2: Divide the main array into two pieces: left and right. Where is the middle?
            int midPos = d.Length / 2;

            // Todo 3: Give the tasks. Each thread sorts one piece independent from the other.
            Thread leftSort = new Thread(() => mergeSort.sortSeq(0,midPos));
            Thread rightSort = new Thread(() => mergeSort.sortSeq(midPos+1, d.Length-1));

            // Todo 4: Start the threads.
            leftSort.Start();
            rightSort.Start();

            // Todo 5: Join to the working threads.
            leftSort.Join();
            rightSort.Join();

            // Todo 6: Merge the results to create the complete sorted array. Then print the content
            mergeSort.merge(0,midPos,d.Length-1);
            mergeSort.printContent();
        }

    }
}
