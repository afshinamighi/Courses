using System;
using System.Diagnostics;
using System.Threading;

namespace Examples
{
    class Program
    {
        static void MainThreadTermination()
        {
            int max = 1000;
            Console.WriteLine("Press a key to start a thread counting until {0} while the main thread terminates without joining ... ", max);
            Console.Read();
            new Thread(() => { for (int i = 0; i < max; i++) { Console.Write(" {0} ", i); Thread.Sleep(100); } }).Start();

            Thread.Sleep(1000);
            Console.WriteLine(" The main thread has terminated ... ");

            Environment.Exit(0); // what will happen if this exit call is commented?
        }

        static void GetProcessesByName(string procName)
        {
            Process[] procs = Process.GetProcesses();
            Process[] procsByNames = Process.GetProcessesByName(procName);

            foreach (Process p in procs)
            {
                if(p.ProcessName.Equals(procName))
                    Console.WriteLine("[All Procs] {0} id = {1}", p.ProcessName, p.Id);
            }
            foreach (Process c in procsByNames)
            {
                 Console.WriteLine("[By Name] {0} id = {1}", c.ProcessName, c.Id);
            }

        }

        static void KillByName(string procName)
        {
            Process[] procs = Process.GetProcessesByName(procName);

            foreach (Process p in procs)
            {
                Console.WriteLine("{0} process with id = {1} is going to be terminated", p.ProcessName, p.Id);
                p.Kill();
            }
        }
        static void Main(string[] args)
        {
            //Program.GetProcessesByName("Agenda");
            //Program.KillByName("Agenda");
            Program.MainThreadTermination();
        }


    }
}
