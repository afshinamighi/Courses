using System;
using System.Diagnostics;
using Exercise;
using System.Threading;

namespace Solution
{
    public class SolutionProcessCreation: ProcessCreation
    {
        public override void createProcess()
        {
            // First define your process
            ProcessStartInfo prInfo = new ProcessStartInfo();
            prInfo.FileName = "../../../../Processes/bin/Debug/netcoreapp3.0/Processes"; // This is an executable program.
            prInfo.CreateNoWindow = false; // This means start the process in a new window
            prInfo.UseShellExecute = false;

            try
            {
                // Start the defined process
                using (Process pr = Process.Start(prInfo))
                {
                    Thread.Sleep(100);
                    Console.WriteLine("I can be busy here doing something else ... ");

                    pr.WaitForExit(); // Parent process waits here to have the child finished.
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}
