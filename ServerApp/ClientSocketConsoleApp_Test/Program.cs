using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ClientSocketConsoleApp_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SendMsg(8800);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }

        }

        static private void SendMsg(int port)
        {
            IPHostEntry iPHost = Dns.GetHostEntry("localhost");
            IPAddress iPAdr = iPHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, port);

            byte[] bytes = new byte[1024];

            Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(iPEndPoint);

            Console.WriteLine("Введиет сообщение ");
            string message = Console.ReadLine();

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            sender.Send(msg);
            int bytesRec = sender.Receive(bytes);

            Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

            if (message.IndexOf("€") == -1)
                SendMsg(port);

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
