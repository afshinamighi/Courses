using Example;

namespace Example
{
    class ProcessBasics
    {
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Uncomment the methods to see the results of the examples
            Processes exampleProcesses = new Processes();
            exampleProcesses.printAllProcesses();
            exampleProcesses.terminateProcess();
            //exampleProcesses.printIdByName();
        }
    }
}