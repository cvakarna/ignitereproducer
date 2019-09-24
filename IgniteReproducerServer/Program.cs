using IgniteReproducerServer.Server;
using System;
using System.Threading;

namespace IgniteReproducerServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IgniteServer server = new IgniteServer();
                server.StartServerAsync().GetAwaiter().GetResult();
                //Create Cache
                server.CreateCacheAsync("college-code-123").GetAwaiter().GetResult();//for this we use thick client
                Thread.Sleep(Timeout.Infinite);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
           

        }
    }
}
