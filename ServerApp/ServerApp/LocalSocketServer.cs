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
    class LocalSocketServer
    {
        private class ClientSocket
        {
            private Socket _socket;
            private string _username=null;

            public Socket GetSocket { get => _socket; }
            public string Username { get => _username;}

            public event EventHandler<MessageEventArgs> RecievedMessage;

            private void RunRecievedMessage(MessageEventArgs e)
            {
                RecievedMessage?.Invoke(this, e);
            }

            public void MessageEventHandler(object sender,MessageEventArgs e)
            {
                string message = e.Username + ": " + e.Message;
                SendMessage(message);
            }

            public ClientSocket(Socket handler)
            {
                _socket = handler;
                this.RecievedMessage += MessageEventHandler;
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
                    while(true)
                    {
                        //Ждем сообщение от полльзователя и вызываем событие, чтобы оповестить
                        //другие потоки

                        string msg = GetMessage();
                        if (!(msg.IndexOf("<end>") > -1))
                        {
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
                    Thread clientTrhead = new Thread(new ParameterizedThreadStart(ClientThread));
                    clientTrhead.Start(handler);

                    //ClientThread(handler);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static private void ClientThread(object handler)
        {
            if (!(handler is Socket)) throw new Exception("typeerror");

            ClientSocket clientSocket = new ClientSocket(handler as Socket);

            clientSocket.Listen();

        }

        public class MessageEventArgs:EventArgs
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


        //private IPEndPoint _ipEndPoint;
        //static private int _clientCount=0;
        //private Socket _sListener;

        //public static int ClientCount { get => _clientCount; set { } }

        //public IPEndPoint IpEndPoint { get => _ipEndPoint; set { } }

        //public Socket SListener { get => _sListener; set { } }

        //public LocalSocketServer()
        //{
        //    IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        //    IPAddress ipAddr = ipHost.AddressList[0];
        //    _ipEndPoint = new IPEndPoint(ipAddr, 11000 + ClientCount);
        //    ClientCount++;
        //    _sListener = new Socket(ipAddr.AddressFamily,
        //        SocketType.Stream, ProtocolType.Tcp);
        //    _sListener.Bind(_ipEndPoint);
        //}

        //public Socket GetListenerSocket()
        //{
        //    IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        //    IPAddress ipAddr = ipHost.AddressList[0];
        //    IpEndPoint = new IPEndPoint(ipAddr, 11000+ClientCount);
        //    ClientCount++;
        //    Socket sListener = new Socket(ipAddr.AddressFamily,
        //        SocketType.Stream, ProtocolType.Tcp);

        //    return sListener;
        //}

    }
}
