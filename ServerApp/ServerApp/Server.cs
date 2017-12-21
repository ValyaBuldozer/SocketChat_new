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
        private Socket _socket;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username { get => _username; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get => _password; set => _password = value; }
        /// <summary>
        /// Состояние пользователя
        /// </summary>
        public bool IsOnline { get => _isOnline; set => _isOnline = value; }
        /// <summary>
        /// Сокет соединения с пользователем
        /// </summary>
        public Socket Socket { get => _socket; set => _socket = value; }

        public ClientInfo(string userame,string password="",bool isOnline=false)
        {
            _username = userame;
            _password = password;
            _isOnline = isOnline;
            _socket = null;
        }
    }

    class Server
    {
        private static Context context = new Context();

        public static Context GetDbContext { get => context; }

        private static Dictionary<string, ClientInfo> usersInfoDic 
            = new Dictionary<string, ClientInfo>();

        internal static Dictionary<string, ClientInfo> UsernamePasswaordDic
            { get => usersInfoDic; set => usersInfoDic = value; }

        private static List<Socket> socketList = new List<Socket>();

        private static List<Message> history = new List<Message>();


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
            foreach (KeyValuePair<string, ClientInfo> client in usersInfoDic)
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
                (handler as Socket).Receive(new byte[1024]);    //ждем подтверждения от клиента
                SendHistory(handler as Socket);     //houston we have a problem
                usersInfoDic[username].Socket = (handler as Socket);

                while (true)
                {
                    Message msg = GetMessage((handler as Socket));

                    if (msg.GetMessageType == MessageType.UserDisconnect) break;
                    if(msg.GetMessageType == MessageType.PrivateMessage)
                    {
                        if ((!usersInfoDic.ContainsKey(msg.GetRecipient)) || !usersInfoDic[msg.GetRecipient].IsOnline) break;
                        usersInfoDic[msg.GetRecipient].Socket.Send(Encoding.UTF8.GetBytes(msg.Serialize()));
                    }
                    else
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
                username = usernamePassword.GetUsername;
                string password = usernamePassword.GetMessage;

                try
                {
                    if (usersInfoDic[username].Password == password)
                    {
                        if (usersInfoDic[username].IsOnline)
                        {
                            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error,DateTime.Now,"server", "err_useronline")
                                .Serialize()));
                        }
                        else
                        {
                            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Message,DateTime.Now,"server", "success")
                                .Serialize()));
                            SendMessageToSockets(new Message(MessageType.UserConnect, DateTime.Now, username));
                            socketList.Add(socket);
                            usersInfoDic[username].IsOnline = true;
                            flag = false;
                            return username;
                        }
                    }
                    else
                        socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error, DateTime.Now, "server", "invalid_password")
                            .Serialize()));
                }
                catch(KeyNotFoundException ex)
                {
                    flag = true;
                    socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.Error, DateTime.Now, "server", "name_not_found")
                        .Serialize()));
                }
            }
            throw new SocketException();
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

            socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.UserList, DateTime.Now, "server",userList).Serialize()));
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

            Message ret = new Message(MessageType.Message, DateTime.Now);
            return ret.Deserialize(data);
        }

        /// <summary>
        /// Посылает историю сообщений пользователю (на каждой итерации ждем подтверждения)
        /// </summary>
        /// <param name="socket"></param>
        static public void SendHistory(Socket socket)
        {
            List<Message> sendList = new List<Message>();

            foreach(var msgJson in GetDbContext.Messages)
            {
                sendList.Add(new Message(MessageType.Message, DateTime.Now).Deserialize(msgJson.MessageJson));
            }
            sendList.AddRange(history);

            foreach(var msg in sendList)
            {
                msg.GetMessageType = MessageType.HistoryMessage;
                socket.Send(Encoding.UTF8.GetBytes(msg.Serialize()));
                socket.Receive(new byte[1024]);         //ждем подвтерждения от пользователя(зато без асинхрона)
            }
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

            if(message.GetMessageType == MessageType.Message) history.Add(message);
            if (history.Count == 15)
            {
                SyncDB(history,true);
                history.Clear();
            }
        }

        /// <summary>
        /// Закрыть обмен данными с клиентом и завершить текущий поток
        /// </summary>
        /// <param name="socket">Сокет клиента</param>
        /// <param name="username">Имя клиента</param>
        public static void CloseSocket(Socket socket,string username)
        {
            socketList.Remove(socket);

            if (usersInfoDic.ContainsKey(username))
            {
                usersInfoDic[username].IsOnline = false;
                usersInfoDic[username].Socket = null;
                SendMessageToSockets(new Message(MessageType.UserDisconnect, DateTime.Now, username));
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

        /// <summary>
        /// Добавляет значения в базу данных
        /// </summary>
        /// <param name="messageList">Список сообщеий</param>
        /// <param name="asyncFlag">Флаг, указывает будет ли сохраниение изменений выплняться асинхронно</param>
        public static void SyncDB(List<Message> messageList,bool asyncFlag)
        {
            foreach(var msg in messageList)
            {
                GetDbContext.Messages.Add(new DbMessage() { MessageJson = msg.Serialize() });
            }
            if (asyncFlag)
                GetDbContext.SaveChangesAsync();
            else
                GetDbContext.SaveChanges();
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

            SyncDB(history,false);
            //Thread.CurrentThread.Abort();
        }

    }
}
