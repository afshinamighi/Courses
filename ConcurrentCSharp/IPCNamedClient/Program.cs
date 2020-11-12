using Exercise;
//using Solution;


namespace Program
{
    class IPCClient
    {
        static void Main(string[] args)
        {
            new IPCNamedClient().ipcClientCommunicate();

             //SolutionIPCNamedClient client = new SolutionIPCNamedClient("MessageReversePipe");
             //client.prepareClient();
             //client.communicate();
            

        }
    }
}
