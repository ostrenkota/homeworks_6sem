using System;
using SomeProject.Library.Server;

namespace SomeProject.TcpServer
{
    class EnteringPointServer
    {
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server(8888, 8889);

                server.TurnOnListener();

                //server.turnOffListener();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
