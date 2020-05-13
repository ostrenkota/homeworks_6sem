using System;
using System.Windows.Forms;
using SomeProject.Library.Client;
using SomeProject.Library;

namespace SomeProject.TcpClient
{
    public partial class ClientMainWindow : Form
    {
        private Client client;
        private static int messagesPort = 8888;
        private static int filesPort = 8889;
        public ClientMainWindow()
        {
            InitializeComponent();
            client = new Client(messagesPort, filesPort);
        }

        private void OnMsgBtnClick(object sender, EventArgs e)
        {
            OperationResult res = client.SendMessageToServer(textBox.Text);
            if (res.Result == Result.OK)
            {
                textBox.Text = "";
                labelRes.Text = "Message was sent succefully!";
                richTextBox1.Text = res.Message;
            }
            else
            {
                labelRes.Text = "Cannot send the message to the server.";
            }
            timer.Interval = 2000;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            labelRes.Text = "";
            richTextBox1.Text = "";
            timer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperationResult res = client.SendFileToServer(textBox1.Text);
            if (res.Result == Result.OK)
            {
                textBox.Text = "";
                labelRes.Text = "File was sent succefully!";
                richTextBox1.Text = res.Message;
            }
            else
            {
                labelRes.Text = "Cannot send the file to the server.";
            }
            timer.Interval = 2000;
            timer.Start();
        }
    }
}
