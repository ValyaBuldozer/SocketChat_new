using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;

namespace ServerApp
{
    /// <summary>
    /// Информация о клиенте
    /// </summary>
    class ClientInfo
    {
        private string _username;
        private string _password;
        private bool _isOnline;

        public string Username { get => _username; }
        public string Password { get => _password; set => _password = value; }
        public bool IsOnline { get => _isOnline; set => _isOnline = value; }

        public ClientInfo(string userame,string password="",bool isOnline=false)
        {
            _username = userame;
            _password = password;
            _isOnline = isOnline;
        }
    }

    class Server
    {
        private static Dictionary<string, ClientInfo> usernamePasswaordDic 
            = new Dictionary<string, ClientInfo>();

        internal static Dictionary<string, ClientInfo> UsernamePasswaordDic
            { get => usernamePasswaordDic; set => usernamePasswaordDic = value; }

        private static List<Socket> socketList = new List<Socket>();


        /// <summary>
        /// Запуск сервера
        /// </summary>
        static public void Run()
        {
            IPHostEntry iPHost = Dns.GetHostEntry("localhost");
            IPAddress iPAdr = iPHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
            Socket sListener 
                = new Socket(iPAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(iPEndPoint);
                sListener.Listen(10);
                while (true)
                {
                    Socket handler = sListener.Accept();                    
                    Thread clientTrhead = new Thread(new ParameterizedThreadStart(ClientThread));
                    clientTrhead.Start(handler);

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        /// <summary>
        /// Метод для потока клиента
        /// </summary>
        /// <param name="handler">Сокет клиента</param>
        static public void ClientThread(object handler)
        {
            if (!(handler is Socket)) throw new FormatException();

            string username = "";

            try
            {
                username = GetNamePassword((handler as Socket));

                while (true)
                {
                    string msg = username + ": " + GetMessage((handler as Socket));
                    if (msg.Contains("<end>")) break;
                    SendMessageToSockets(msg);
                }

            }
            catch(SocketException)
            {
                CloseSocket((handler as Socket), username);
            }

            CloseSocket((handler as Socket), username);
        }

        /// <summary>
        /// Получить сообщение от сокета клиента
        /// </summary>
        /// <param name="socket">Cокет</param>
        /// <returns>Сообщение</returns>
        static public string GetMessage(Socket socket)
        {
            string data = null;
            byte[] bytes = new byte[1024];
            int byteRec = socket.Receive(bytes);

            data += Encoding.UTF8.GetString(bytes, 0, byteRec);

            return data;

        }

        /// <summary>
        /// Посылает сообщение всем клиентам в сети
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessageToSockets(string message)
        {
            foreach(Socket socket in socketList)
            {
                socket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        /// <summary>
        /// Верификация клиента,
        /// </summary>
        /// <param name="socket">Сокет</param>
        /// <returns>Имя подтвержденного клиента</returns>
        static public string GetNamePassword(Socket socket)
        {
            string username = "";
            bool flag = true; 

            while (flag)
            {
                username = GetMessage(socket);
                string password = GetMessage(socket);

                try
                {
                    if (usernamePasswaordDic[username].Password == password)
                    {
                        if (usernamePasswaordDic[username].IsOnline)
                        {
                            socket.Send(Encoding.UTF8.GetBytes("<err_useronline>"));
                        }
                        else
                        {
                            socket.Send(Encoding.UTF8.GetBytes("<success>"));
                            socketList.Add(socket);
                            usernamePasswaordDic[username].IsOnline = true;
                            flag = false;
                        }
                    }
                    else
                        socket.Send(Encoding.UTF8.GetBytes("<invalid_password>"));
                }
                catch(KeyNotFoundException ex)
                {
                    flag = true;
                    socket.Send(Encoding.UTF8.GetBytes("<name_not_found>"));
                }
            }
            return username;
        }

        /// <summary>
        /// Закрыть обмен данными с клиентом и завершить текущий поток
        /// </summary>
        /// <param name="socket">Сокет клиента</param>
        /// <param name="username">Имя клиента</param>
        public static void CloseSocket(Socket socket,string username)
        {
            if (usernamePasswaordDic.ContainsKey(username))
                usernamePasswaordDic[username].IsOnline = false;

            socketList.Remove(socket);

            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Thread.CurrentThread.Abort();
            }
            catch(ObjectDisposedException)
            {
                Thread.CurrentThread.Abort();
            }
        }

        /// <summary>
        /// Завершение работы сервера и закрытие потока
        /// </summary>
        public static void End()
        {
            foreach(Socket socket in socketList)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            //Thread.CurrentThread.Abort();
        }
    }
}
