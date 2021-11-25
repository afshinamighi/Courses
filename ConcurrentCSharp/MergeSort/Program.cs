using System;
using System.Threading;
using Exercise;
//using Solution;

namespace Program
{
    class MergeSort
    {

        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 4, 11, 20, 8, 2, 98, 90, 16, 3 , 100, 83, 24, 18, 33, 44, 76 };

            
            SequentialMergeSort mergeSort = new SequentialMergeSort(arr);

            mergeSort.printContent("\n Before the sequential merge-sort \n");
            mergeSort.sortSeq(0, arr.Length - 1);
            mergeSort.printContent("\n After the sequential merge-sort \n");

            // uncomment this only if the solution is available
            //Console.WriteLine("\n Now concurrent sort will be running ...\n");
            //SolutionConcurrentMergeSort concMergeSort = new SolutionConcurrentMergeSort();
            //concMergeSort.sortCon(arr);

        }
    }
}
