using System;
using System.Threading.Tasks;

namespace MinimalOPCServer
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Optimax .Net Core OPC UA Minimal Server v1.0");

            var server = new MinimalOpcServer();
            Task.FromResult(server.Run());

            return (int)MinimalOpcServer.ExitCode;
        }
    }
}
