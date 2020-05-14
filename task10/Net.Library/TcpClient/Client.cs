using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace SomeProject.Library.Client
{
    public class Client
    {
        private int messagesPort;
        private int filesPort;

        public Client(int messagesPort, int filesPort)
        {
            this.messagesPort = messagesPort;
            this.filesPort = filesPort;
        }

        /// <summary>
        /// Receiving a message from the server
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private OperationResult ReceiveMessageFromServer(NetworkStream stream)
        {
            try
            {
                StringBuilder recievedMessage = new StringBuilder();
                byte[] data = new byte[256];

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                return new OperationResult(Result.OK, recievedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.ToString());
            }
        }


        /// <summary>
        /// Sending a message to the server
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public OperationResult SendMessageToServer(string message)
        {
            try
            {
                TcpClient tcpMessagesClient = new TcpClient("127.0.0.1", messagesPort);
                NetworkStream stream = tcpMessagesClient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                OperationResult serverOperation = ReceiveMessageFromServer(stream);

                stream.Close();
                tcpMessagesClient.Close();
                return new OperationResult(Result.OK, serverOperation.Message);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }


        /// <summary>
        /// Sending a file to the server
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public OperationResult SendFileToServer(string path)
        {
            try
            {
                int bufferSize = 1024;
                byte[] buffer = null;
                FileInfo file = new FileInfo(path);
                TcpClient tcpFilesClient = new TcpClient("127.0.0.1", filesPort);
                tcpFilesClient.SendTimeout = 600000;
                tcpFilesClient.ReceiveTimeout = 600000;

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    int bufferCount = Convert.ToInt32(Math.Ceiling((double)fs.Length / (double)bufferSize));

                    string headerStr = "Content-length:" + fs.Length.ToString() + "$Extension:" + file.Extension;
                    byte[] header = new byte[bufferSize];
                    Array.Copy(Encoding.ASCII.GetBytes(headerStr), header, Encoding.ASCII.GetBytes(headerStr).Length);


                    tcpFilesClient.Client.Send(header);

                    for (int i = 0; i < bufferCount; i++)
                    {
                        buffer = new byte[bufferSize];
                        int size = fs.Read(buffer, 0, bufferSize);

                        tcpFilesClient.Client.Send(buffer, size, SocketFlags.Partial);

                    }
                }
                var stream = tcpFilesClient.GetStream();
                OperationResult serverOperation = ReceiveMessageFromServer(stream);
                tcpFilesClient.Client.Close();
                stream.Close();
                return new OperationResult(Result.OK, serverOperation.Message);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
    }
}
