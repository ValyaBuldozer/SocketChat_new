using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ServerApp
{

    //ВСЕ УСТРЕЛО И НЕ ИСПОЛЬЗУЕТСЯ

    class ClientSocket
    {
         Queue<string> messageQueue = new Queue<string>();
        private Socket _socket;
        private string _username = null;

        public Socket GetSocket { get => _socket; }
        public string Username { get => _username; }

        public ClientSocket(MirrorEvent handler)
        {
            _socket = handler.Socket;
            handler.MirrorRecievedMessage += MessageEventHandler;
        }

        public event EventHandler<MessageEventArgs> RecievedMessage;

        private void RunRecievedMessage(MessageEventArgs e)
        {
            RecievedMessage?.Invoke(this, e);
        }

        public void MessageEventHandler(object sender, MessageEventArgs e)
        {
            string message = e.Username + ": " + e.Message;
            SendMessage(message);
        }

        /// <summary>
        /// Присваивает имени пользователя первое полученное от сокета сообщение
        /// </summary>
        /// <returns></returns>
        public bool GetName()
        {
            if (_username != null) return false;

            _username = GetMessage();
            return true;
        }

        /// <summary>
        /// Получает одиночное входящее сообщение от сокета
        /// </summary>
        /// <returns>Полученное сооббщение</returns>
        public string GetMessage()
        {
            string data = null;
            byte[] bytes = new byte[1024];
            int byteRec = _socket.Receive(bytes);

            data += Encoding.UTF8.GetString(bytes, 0, byteRec);

            return data;
        }

        /// <summary>
        /// Послать сообщение сокету
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void SendMessage(string message)
        {
            _socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void Listen()
        {
            if (_username == null) GetName();

            try
            {
                while (true)
                {
                    //Ждем сообщение от полльзователя и вызываем событие, чтобы оповестить
                    //другие потоки

                    string msg = GetMessage();
                    if (!(msg.IndexOf("<end>") > -1))
                    {
                        //messageQueue.Enqueue()
                        MessageEventArgs e = new MessageEventArgs(_username, msg);
                        RunRecievedMessage(e);
                    }
                    else
                        Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Close()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }
    }  

    class MessageEventArgs:EventArgs
        {
            private string _username;
            public string Username { get => _username; set => _username = value; }
            public string Message { get => _message; set => _message = value; }
            private string _message;

            public MessageEventArgs(string username,string message)
            {
                _username = username;
                _message = message;
            }
        }

    class MirrorEvent
    {
        Socket _socket;

        public Socket Socket { get => _socket; }

        public MirrorEvent(Socket socket)
        {
            _socket = socket;
        }

        public void SubscribeToEvent(ClientSocket clientSocket)
        {
            clientSocket.RecievedMessage += EventHandler;
        }

        public event EventHandler<MessageEventArgs> MirrorRecievedMessage;

        public void RunMirrorRecievedMessage(MessageEventArgs e)
        {
            MirrorRecievedMessage?.Invoke(this, e);
        }

        public void EventHandler(object sender,MessageEventArgs e)
        {
            RunMirrorRecievedMessage(e);
        }
    }


    class LocalSocketServer
    {

        public void Run()
        {
            IPHostEntry iPHost = Dns.GetHostEntry("localhost");
            IPAddress iPAdr = iPHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
            Socket sListener = new Socket(iPAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(iPEndPoint);
                sListener.Listen(10);

                while (true)
                {
                    Socket handler = sListener.Accept();
                    MirrorEvent mirrorEvent = new MirrorEvent(handler);
                    Thread clientTrhead = new Thread(new ParameterizedThreadStart(ClientThread));
                    clientTrhead.Start(mirrorEvent);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static private void ClientThread(object handler)
        {
            if (!(handler is MirrorEvent)) throw new Exception("typeerror");

            ClientSocket clientSocket = new ClientSocket(handler as MirrorEvent);
            (handler as MirrorEvent).SubscribeToEvent(clientSocket);

            clientSocket.Listen();

        }

        /// <summary>
        /// Событие-зеркало
        /// </summary>
        public event EventHandler<MessageEventArgs> MirrorRecievedMessage;

        public void RunMirrorRecievedMessage(MessageEventArgs e)
        {
            MirrorRecievedMessage?.Invoke(this, e);
        }
    }
}
