using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ClientApp
{
    public class ServerErrorEventInfo:EventArgs
    {
        public ServerErrorEventInfo(string info)
        {
            this.info = info;
        }
        public string info;
    }

    public class MessageEventInfo : EventArgs
    {
        public MessageEventInfo(string message)
        {
            this.message = message;
        }

        public string message;
    }

    public class Client
    {
        public event EventHandler<ServerErrorEventInfo> ServerErrorEvent;
        public event EventHandler<MessageEventInfo> MessageEvent;

        public virtual void ServerErrorEventRun(ServerErrorEventInfo e)
        {
            EventHandler<ServerErrorEventInfo> handler = ServerErrorEvent;
            handler(this, e);
        }
        public virtual void MessageEventRun(MessageEventInfo e)
        {
            EventHandler<MessageEventInfo> handler = MessageEvent;
            handler(this, e);
        }

        private Socket socket;
        private bool _connectionFlag=false;

        public bool ConnectionFlag { get => _connectionFlag;  }

        public void ConnectToServer(string username,string password)
        {
            try
            {
                IPHostEntry iPHost = Dns.GetHostEntry("localhost");
                IPAddress iPAdr = iPHost.AddressList[0];
                IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
                Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream,
                    ProtocolType.Tcp);

                sender.Connect(iPEndPoint);

                while (!Werification(sender, username, password)) ;

                socket = sender;
                _connectionFlag = true;

                Thread listenThread = new Thread(new ParameterizedThreadStart(Listen));
                listenThread.Start(this);

                
            }
            catch (SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("no connection with server"));
            }
        }

        public bool Werification(Socket socket,string username,string password)
        {
            Thread.Sleep(1000);
            socket.Send(Encoding.UTF8.GetBytes(username));
            Thread.Sleep(1000);
            socket.Send(Encoding.UTF8.GetBytes(username));

            string answer = GetMessage(socket);

            switch (answer)
            {
                case "<success>":
                    return true;

                case "<name_not_found>":
                    ServerErrorEventRun(new ServerErrorEventInfo("User is not regitred"));
                    return false;

                case "<invalid_password>":
                    ServerErrorEventRun(new ServerErrorEventInfo("Invalid password"));
                    return false;

                case "<err_useronline>":
                    ServerErrorEventRun(new ServerErrorEventInfo("User is online"));
                    return false;

                default:
                    ServerErrorEventRun(new ServerErrorEventInfo("Unknown error"));
                    return false;
            }
        }

        public string GetMessage(Socket socket)
        {
            byte[] bytes = new byte[1024];
            int bytesRec = socket.Receive(bytes);
            return Encoding.UTF8.GetString(bytes);
        }

        static public void Listen(object clientObject)
        {
            while(true)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = (clientObject as Client).socket.Receive(bytes);
                (clientObject as Client).MessageEventRun(
                    new MessageEventInfo(Encoding.UTF8.GetString(bytes)));
            }
        }
    }
}
