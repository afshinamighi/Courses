using System;
using System.IO;
using System.IO.Pipes;

namespace Exercise
{
    public class IPCNamedServer
    {
        public virtual void ipcServerCommunicate()
        {
            Console.WriteLine("Pipe Server is being executed ...");
            Console.WriteLine("[Server] Enter a message to be reversed by the client (press ENTER to exit)");

            //Client
            var client = new NamedPipeClientStream("PipesOfConcurrency");
            client.Connect();

            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                String input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                    break;
                else
                {
                    writer.WriteLine(input);
                    writer.Flush();
                }
            }
        }
    }
}