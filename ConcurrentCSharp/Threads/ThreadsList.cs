using System;
using System.Diagnostics;

namespace Exercise
{
    /// <summary>
    /// This class prints information about threads running within a process
    /// </summary>
    public class ThreadsList
    {
        // Prints basic information of the threads running within a process
        public void printThreads()
        {
            Console.WriteLine(" This method is going to print information of threads ... ");
            // Get the current process
            Process proc = Process.GetCurrentProcess();

            // Print the information of the process
            Console.WriteLine("process: {0},  id: {1}", proc.ProcessName, proc.Id);

            // Print basic information for each thread
            foreach (ProcessThread pt in proc.Threads)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine(" Thread: {0}, CPU time: {1}, Priority: {2}, Thread state: {3}", pt.Id, pt.TotalProcessorTime, pt.BasePriority, pt.ThreadState.ToString());
            }
        }

        public void runExample()
        {
            this.printThreads();
        }
    }
}
