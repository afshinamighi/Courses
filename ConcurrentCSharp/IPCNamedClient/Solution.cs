using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using Exercise;

/*
 * This is an example representing how two processes can communicate through NamedPipe
 */

namespace Solution
{
    public class SolutionIPCNamedClient : IPCNamedClient
    {
            NamedPipeServerStream server;
            StreamReader serverReader;
            StreamWriter serverWriter;

            public SolutionIPCNamedClient(String pipeName)
            {
                server = new NamedPipeServerStream(pipeName);
            }

            public void prepareClient()
            {
                Console.WriteLine("Pipe Client is being executed ...");
                Console.WriteLine("[Client] Client will be waiting for the server");

                server.WaitForConnection();
                serverReader = new StreamReader(server);

                // The client needs a writer stream to write its processing result
                serverWriter = new StreamWriter(server);
            }

        public void communicate()
        {
            while (true)
            {
                String msg = serverReader.ReadLine();

                if (String.IsNullOrEmpty(msg))
                {
                    Console.WriteLine("[Client] Programs is being terminated.");
                    break;
                }
                else
                {
                    Console.WriteLine(msg);
                    String reverseMsg = String.Join("", msg.Reverse());
                    Console.WriteLine(reverseMsg);
                    serverWriter.WriteLine(reverseMsg);
                    serverWriter.Flush();
                }
            }
        }
    }

}
