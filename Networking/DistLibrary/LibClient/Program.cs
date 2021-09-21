using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using LibClient;
//using LibClientSolution;


// NOTE: THIS FILE MUST NOT CHANGE

namespace LibClientSimulator
{
    public class InputData
    {
        public string BookName { get; set; }
    }
    public class TestCases
    {
        public SimpleClient client;
        public string outcome;
    }
    public class ClientsSimulator
    {
        private SimpleClient client;
        private List<InputData> inputDataList;
        private TestCases[] tests;
        private string inputFile = @"LibInput.json";
        //private string inputFile = @"../../../LibInput.json";

        public ClientsSimulator()
        {
            int id = 0;
            try
            {
                string inputContent = File.ReadAllText(inputFile);
                this.inputDataList = JsonSerializer.Deserialize<List<InputData>>(inputContent);
                tests = new TestCases[this.inputDataList.Count];

                foreach (InputData d in this.inputDataList)
                {
                    //each client has an id and a book to request
                    tests[id] = new TestCases();
                    tests[id].client = new SimpleClient(id, d.BookName);
                    id++;
                }
            }catch (Exception e) { Console.Out.WriteLine("[ClientSimulator] Exception: {0}", e.Message); }
        }

        public void startSimulation()
        {
            int numCases = tests.Length;
            for (int i = 0; i < numCases; i++)
            {
                Console.Out.WriteLine("\n *********** \n");
                tests[i].outcome = tests[i].client.start();
                tests[i].client.delay();
            }
            //this is the ending user
            new SimpleClient(-1, "").start();
        }

        public void printOutput()
        {
            Console.Out.WriteLine("\n ***************    Final Output       *********** \n");
            for (int i = 0; i < tests.Length; i++)
                Console.WriteLine("{0} : {1}", tests[i].client.user_id,tests[i].outcome);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            ClientsSimulator simulator = new ClientsSimulator();
            simulator.startSimulation();
            simulator.printOutput();
        }
    }
}
