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
    class Server
    {
        static Dictionary<string, string> usernamePasswaordDic = new Dictionary<string, string>
        {
            {"name1","password1" },
            {"name2","password2" },
            {"name3","password3" },
            {"name4","password4" },
        };

        static List<Socket> socketList = new List<Socket>();

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
                    socketList.Add(handler);
                    Thread clientTrhead = new Thread(new ParameterizedThreadStart(ClientThread));
                    clientTrhead.Start(handler);

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        static public void ClientThread(object handler)
        {
            if (!(handler is Socket)) throw new FormatException();

            string username = GetNamePassword((handler as Socket));

            while(true)
            {
                string msg = username+": "+GetMessage((handler as Socket));
                if (msg.Contains("<end>")) break;
                SendMessageToSockets(msg);
            }

            (handler as Socket).Shutdown(SocketShutdown.Both);
            (handler as Socket).Close();
        }

        static public string GetMessage(Socket socket)
        {
            try
            {
                string data = null;
                byte[] bytes = new byte[1024];
                int byteRec = socket.Receive(bytes);

                data += Encoding.UTF8.GetString(bytes, 0, byteRec);

                return data;
            }
            catch(SocketException ex)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return null;
            }
        }

        static public void SendMessageToSockets(string message)
        {
            foreach(Socket socket in socketList)
            {
                socket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        static public string GetNamePassword(Socket handler)
        {
            string username = "";
            bool flag = true;       //внимание! говнокод

            while (flag)
            {
                username = GetMessage(handler);
                string password = GetMessage(handler);

                try
                {
                    if (usernamePasswaordDic[username] == password)
                    {
                        handler.Send(Encoding.UTF8.GetBytes("<success>"));
                        flag = false;
                    }
                    else
                        handler.Send(Encoding.UTF8.GetBytes("<fail>"));
                }
                catch(KeyNotFoundException ex)
                {
                    flag = true;
                    handler.Send(Encoding.UTF8.GetBytes("<name_not_found>"));
                }
            }
            return username;
        }
    }
}
