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

            //Устраняем последствия неправильного закрытия сервера
            foreach (KeyValuePair<string, ClientInfo> client in usernamePasswaordDic)
                client.Value.IsOnline = false;

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
                Thread.Sleep(200);
                SendUserList(handler as Socket);

                while (true)
                {
                    Message msg = GetMessage((handler as Socket));
                    if (msg.MessageType == MessageType.UserDisconnect) break;
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

        /// <summary>
        /// Посылает сообщение всем клиентам в сети
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessageToSockets(Message message)
        {
            foreach(Socket socket in socketList)
            {
                socket.Send(Encoding.UTF8.GetBytes(message.Serialize()));
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
                Message usernamePassword = GetMessage(socket);
                username = usernamePassword.Username;
                string password = usernamePassword.GetMessage;

                try
                {
                    if (usernamePasswaordDic[username].Password == password)
                    {
                        if (usernamePasswaordDic[username].IsOnline)
                        {
                            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error,"server", "err_useronline")
                                .Serialize()));
                        }
                        else
                        {
                            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Message,"server", "success")
                                .Serialize()));
                            SendMessageToSockets(new Message(MessageType.UserConnect, username));
                            socketList.Add(socket);
                            usernamePasswaordDic[username].IsOnline = true;
                            flag = false;
                        }
                    }
                    else
                        socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error,"server", "invalid_password")
                            .Serialize()));
                }
                catch(KeyNotFoundException ex)
                {
                    flag = true;
                    socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error,"server", "name_not_found")
                        .Serialize()));
                }
            }
            return username;
        }

        /// <summary>
        /// Послать сокету список пользователей онлайн
        /// </summary>
        /// <param name="socket">Сокет клиента</param>
        static public void SendUserList(Socket socket)
        {
            string userList = "";

            foreach (KeyValuePair<string, ClientInfo> client in UsernamePasswaordDic)
                if (client.Value.IsOnline)
                    userList += client.Key + ";";

            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.UserList,"server",userList).Serialize()));
        }

        /// <summary>
        /// Закрыть обмен данными с клиентом и завершить текущий поток
        /// </summary>
        /// <param name="socket">Сокет клиента</param>
        /// <param name="username">Имя клиента</param>
        public static void CloseSocket(Socket socket,string username)
        {
            socketList.Remove(socket);

            if (usernamePasswaordDic.ContainsKey(username))
            {
                usernamePasswaordDic[username].IsOnline = false;
                SendMessageToSockets(new Message(MessageType.UserDisconnect,username));
            }

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

    }
}
