using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeProject.Library.Server
{
    public class Server
    {
        static string rootDirectory = @"C:\Users\taisi\Documents\";
        static int maxConnectionsCount = 10;
        static int minConnectionsCount = 2;
        private int currentConnectionsCount = 0;
        private int filesCount = 0;
        private int messagesPort;
        private int filesPort;
        TcpListener serverTextListener;
        TcpListener serverFilesListener;

        public Server(int textPort, int filesPort)
        {
            serverTextListener = new TcpListener(IPAddress.Loopback, textPort);
            serverFilesListener = new TcpListener(IPAddress.Loopback, filesPort);
            messagesPort = textPort;
            this.filesPort = filesPort;
        }

        public bool TurnOffListener()
        {
            try
            {
                if (serverTextListener != null)
                    serverTextListener.Stop();
                if (serverFilesListener != null)
                    serverFilesListener.Stop();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn off listener: " + e.Message);
                return false;
            }
        }

        public void TurnOnListener()
        {
            ThreadPool.SetMaxThreads(maxConnectionsCount, maxConnectionsCount);
            ThreadPool.SetMinThreads(minConnectionsCount, minConnectionsCount);
            Console.WriteLine("Waiting for connections...");

            Task textListener = new Task(() =>
            {
                try
                {
                    if (serverTextListener != null)
                        serverTextListener.Start();
                    while (true)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(TextConnection), serverTextListener.AcceptTcpClient());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot turn on listener: " + e.Message);
                }
            });
            textListener.Start();

            Task filesListener = new Task(() =>
            {
                try
                {
                    if (serverFilesListener != null)
                        serverFilesListener.Start();
                    while (true)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(FileConnection), serverFilesListener.AcceptTcpClient());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot turn on listener: " + e.Message);
                }
            });
            filesListener.Start();

            textListener.Wait();
            filesListener.Wait();

        }

        async private void TextConnection(object client)
        {
            Interlocked.Increment(ref currentConnectionsCount);
            Console.WriteLine("New messages connection detected. Total connections count: {0}"
                , currentConnectionsCount);
            //  Console.WriteLine("Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            var tcpClient = (TcpClient)client;
            NetworkStream stream = tcpClient.GetStream();
            OperationResult result = await ReceiveMessageFromClient(tcpClient);
            if (result.Result == Result.Fail)
                Console.WriteLine("Unexpected error: " + result.Message);
            else
                Console.WriteLine("New message from client: " + result.Message);
            tcpClient.Close();

            Interlocked.Decrement(ref currentConnectionsCount);
        }

        async private void FileConnection(object client)
        {
            Interlocked.Increment(ref currentConnectionsCount);
            Console.WriteLine("New files connection detected. Total connections count: {0}"
                , currentConnectionsCount);
            // Console.WriteLine("Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            var tcpClient = (TcpClient)client;
            OperationResult result = await ReceiveFileFromClient(tcpClient);
            if (result.Result == Result.Fail)
                Console.WriteLine("Unexpected error: " + result.Message);
            else
                Console.WriteLine("New file from client: " + result.Message);
            tcpClient.Close();
            Interlocked.Decrement(ref currentConnectionsCount);
        }

        private async Task<OperationResult> ReceiveFileFromClient(TcpClient tcpClient)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                int bufferSize = 1024;
                byte[] buffer = null;

                string headerStr = "";
                string filename = "";
                int filesize = 0;


                byte[] header = new byte[bufferSize];

                stream.Read(header, 0, bufferSize);

                headerStr = Encoding.ASCII.GetString(header);

                int length = headerStr.IndexOf("\0");
                string cutted = headerStr.Substring(0, length);

                string[] splitted = cutted.Split(new string[] { "$" }, StringSplitOptions.None);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                foreach (string s in splitted)
                {
                    if (s.Contains(":"))
                    {
                        headers.Add(s.Substring(0, s.IndexOf(":")), s.Substring(s.IndexOf(":") + 1));
                    }

                }

                filesize = Int32.Parse(headers["Content-length"]);

                var date = DateTime.Now.ToString("yyyy-MM-dd");
                Directory.CreateDirectory(rootDirectory + date);
                filename = rootDirectory + date + "\\File" + filesCount.ToString() + headers["Extension"];

                int bufferCount = Convert.ToInt32(Math.Ceiling((double)filesize / (double)bufferSize));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    while (filesize > 0)
                    {
                        buffer = new byte[bufferSize];

                        int size = stream.Read(buffer, 0, bufferSize);

                        fs.Write(buffer, 0, size);

                        filesize -= size;
                    }
                }
                Interlocked.Increment(ref filesCount);

                SendMessageToClient("File was recived successfully", stream);
                stream.Close();
                return new OperationResult(Result.OK, "File was recived successfully");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        private async Task<OperationResult> ReceiveMessageFromClient(TcpClient tcpClient)
        {
            try
            {
                StringBuilder recievedMessage = new StringBuilder();

                byte[] data = new byte[256];
                NetworkStream stream = tcpClient.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                SendMessageToClient("Message was recived successfully", stream);
                stream.Close();

                return new OperationResult(Result.OK, recievedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        public OperationResult SendMessageToClient(string message, NetworkStream stream)
        {
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
    }
}