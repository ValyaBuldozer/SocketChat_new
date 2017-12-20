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
        public MessageEventInfo(Message message,Socket serverSocket)
        {
            this.message = message;
            this.serverSocket = serverSocket;
        }

        private Message message;
        private Socket serverSocket;

        public Message GetMessage { get => message; }
        public Socket GetServerSocket { get => serverSocket; }
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

        private Socket _socket;
        private bool _connectionFlag = false;
        private string _username;
        private Thread listenThread;

        public bool ConnectionFlag { get => _connectionFlag; set => _connectionFlag = value; }
        public string Username { get => _username; }
        public Socket Socket { get => _socket; }
        public Thread ListenThread { get => listenThread; set => listenThread = value; }

        public Client()
        {
            _username = null;
            _connectionFlag = false;
        }

        /// <summary>
        /// Метод подключения к серверу
        /// </summary>
        /// <param name="username">Имя пользвателя</param>
        /// <param name="password">Пароль</param>
        /// <returns>true - при успешной процедуре верификации, false - если верификация не пройдена</returns>
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

                _socket = sender;
                _connectionFlag = true;
                _username = username;

                if (listenThread != null)
                    listenThread.Abort();

                listenThread = new Thread(new ParameterizedThreadStart(Listen));
                listenThread.Start(this);

                return true;
            }
            catch (SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("no connection with server"));
                return false;
            }
        }

        /// <summary>
        /// Процедура верификации пользователя
        /// </summary>
        /// <param name="socket">Сокет соединения с сервером</param>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Успех\провал</returns>
        public bool Werification(Socket socket,string username,string password)
        {
            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Message,DateTime.Now,username,password).Serialize()));

            Message answer = GetMessage(socket);

            if ( answer.GetMessage == "success" ) return true;

            switch (answer.GetMessage)
            { 
                case "name_not_found":
                    ServerErrorEventRun(new ServerErrorEventInfo("User is not registered "));
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

        /// <summary>
        /// Получить сообщение от сервера
        /// </summary>
        /// <param name="socket">Сокет соединения с сервером</param>
        /// <returns>Полученное сообщение</returns>
        static public Message GetMessage(Socket socket)
        {
            byte[] bytes = new byte[1024];
            int byteRec = socket.Receive(bytes);

            string data = Encoding.UTF8.GetString(bytes, 0, byteRec);

            if (data.Contains("\0"))
                data = data.Remove(data.IndexOf('\0'));

            Message ret = new Message(MessageType.Message,DateTime.Now);
            return ret.Deserialize(data);
        }

        /// <summary>
        /// Метод прослушивания сокета сервера
        /// </summary>
        /// <param name="clientObject">Текущий экземпляр класса Client</param>
        static public void Listen(object clientObject)
        {
            try
            {
                //Chat_form.ExitEvent += ExitEventHandler;

                while ((clientObject as Client)._connectionFlag)
                {
                    Message message = GetMessage((clientObject as Client).Socket);

                    (clientObject as Client).MessageEventRun(new MessageEventInfo(message,(clientObject as Client).Socket));
                }
                
                (clientObject as Client).Socket.Shutdown(SocketShutdown.Both);
                (clientObject as Client).Socket.Close();
            }
            catch(SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("Connection to server has been served"));
            }
            catch (ObjectDisposedException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("Unknown error"));
            }
            catch(ThreadAbortException)
            {
                if ((clientObject as Client).Socket != null)
                {
                    (clientObject as Client).Socket.Shutdown(SocketShutdown.Both);
                    (clientObject as Client).Socket.Close();
                }
            }
        }

        /// <summary>
        /// Послать сообщение серверу
        /// </summary>
        /// <param name="message">Текуст сообщения</param>
        public void SendMessage(string message,string Recipient)
        {
            if (!_connectionFlag) return;
            if (message == null || message == "") return;

            if(Recipient == null)
                Socket.Send(Encoding.UTF8.GetBytes(
                    new Message(MessageType.Message, DateTime.Now, _username, message).Serialize()));
            else
                Socket.Send(Encoding.UTF8.GetBytes(
                    new Message(MessageType.PrivateMessage, DateTime.Now, _username, message, Recipient).Serialize()));

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
