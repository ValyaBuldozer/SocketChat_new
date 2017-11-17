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
        public MessageEventInfo(Message message)
        {
            this.message = message;
        }

        public Message message;
    }

    public class Client
    {
        public static event EventHandler<ServerErrorEventInfo> ServerErrorEvent;
        public event EventHandler<MessageEventInfo> MessageEvent;

        public static void ServerErrorEventRun(ServerErrorEventInfo e)
        {
            EventHandler<ServerErrorEventInfo> handler = ServerErrorEvent;
            handler(null, e);
        }
        public virtual void MessageEventRun(MessageEventInfo e)
        {
            EventHandler<MessageEventInfo> handler = MessageEvent;
            handler(this, e);
        }

        private Socket socket;
        private static bool _connectionFlag=false;
        private string _username;

        public static bool ConnectionFlag { get => _connectionFlag;  }
        public string Username { get => _username; }

        public Client()
        {
            _username = null;
            _connectionFlag = false;
        }

        public bool ConnectToServer(string username,string password)
        {
            try
            {
                IPHostEntry iPHost = Dns.GetHostEntry("localhost");
                IPAddress iPAdr = iPHost.AddressList[0];
                IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
                Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream,
                    ProtocolType.Tcp);

                sender.Connect(iPEndPoint);

                if (!Werification(sender, username, password))
                    return false;

                socket = sender;
                _connectionFlag = true;
                _username = username;

                Thread listenThread = new Thread(new ParameterizedThreadStart(Listen));
                listenThread.Start(this);

                return true;
            }
            catch (SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("no connection with server"));
                return false;
            }
        }

        public bool Werification(Socket socket,string username,string password)
        {
            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Message,username,password).Serialize()));

            Message answer = GetMessage(socket);

            if ( answer.GetMessage == "success" ) return true;

            switch (answer.GetMessage)
            { 
                case "name_not_found":
                    ServerErrorEventRun(new ServerErrorEventInfo("User is not regitred"));
                    return false;

                case "invalid_password":
                    ServerErrorEventRun(new ServerErrorEventInfo("Invalid password"));
                    return false;

                case "err_useronline":
                    ServerErrorEventRun(new ServerErrorEventInfo("User is online"));
                    return false;

                default:
                    ServerErrorEventRun(new ServerErrorEventInfo("Unknown error"));
                    return false;
            }
        }

        static public Message GetMessage(Socket socket)
        {
            byte[] bytes = new byte[1024];
            int byteRec = socket.Receive(bytes);

            string data = Encoding.UTF8.GetString(bytes, 0, byteRec);

            if (data.Contains("\0"))
                data = data.Remove(data.IndexOf('\0'));

            Message ret = new Message(MessageType.Message);
            return ret.Deserialize(data);
        }

        static public void Listen(object clientObject)
        {
            try
            {
                //Chat_form.ExitEvent += ExitEventHandler;

                while (_connectionFlag)
                {
                    Message message = GetMessage((clientObject as Client).socket);

                    (clientObject as Client).MessageEventRun(new MessageEventInfo(message));
                }
                
                (clientObject as Client).socket.Shutdown(SocketShutdown.Both);
                (clientObject as Client).socket.Close();
            }
            catch(SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("Connection to server has been served"));
            }
            catch (ObjectDisposedException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("Unknown error"));
            }
        }

        public void SendMessage(string message)
        {
            if (!_connectionFlag) return;
            if (message == null || message == "") return;

            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Message,_username,message).Serialize()));

        }

        public static void ExitEventHandler(object handler,ServerErrorEventInfo e)
        {
            try
            {
                Action action = () =>
                 {
                     //socket.Shutdown(SocketShutdown.Both);
                     //socket.Close();
                     
                     Thread.CurrentThread.Abort();
                 };

                action();
            }
            catch(ObjectDisposedException)
            {
                Thread.CurrentThread.Abort();
            }
        }
    }
}
