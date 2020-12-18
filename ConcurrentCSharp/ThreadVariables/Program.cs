using System;
using Examples;

namespace ThreadVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleLocals examples = new ExampleLocals();
            examples.multiRun(50, 1000);
            Console.WriteLine("[End]");
        }
    }
}
