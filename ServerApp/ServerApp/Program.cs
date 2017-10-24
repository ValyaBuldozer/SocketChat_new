using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Socket sListener = LocalSocketServer.GetSocket(8800);
            //List<LocalSocketServer> clientSocketList = new List<LocalSocketServer>();

            IPHostEntry iPHost = Dns.GetHostEntry("localhost");
            IPAddress iPAdr = iPHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
            Socket sListener = new Socket(iPAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(iPEndPoint);
                sListener.Listen(10);

                while(true)
                {
                    Socket handler = sListener.Accept();
                    Thread clientTrhead = new Thread(new ParameterizedThreadStart(ClientThread));
                    clientTrhead.Start(handler);
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

            while (true)
            {

                Socket clientSokcet = (handler as Socket);
                string data = null;
                byte[] bytes = new byte[1024];
                int byteRec = clientSokcet.Receive(bytes);

                data += Encoding.UTF8.GetString(bytes, 0, byteRec);

                Console.WriteLine("Text:"+data);

                string reply = ("Message is recieved, length: " + data.Length.ToString());
                byte[] replyMsg = Encoding.UTF8.GetBytes(reply);
                clientSokcet.Send(replyMsg);

                if(data.IndexOf("€")>-1)
                {
                    Console.WriteLine("Соедениение закрыто");
                    clientSokcet.Shutdown(SocketShutdown.Both);
                    clientSokcet.Close();
                }

            }

            
            
        }
    }
}

