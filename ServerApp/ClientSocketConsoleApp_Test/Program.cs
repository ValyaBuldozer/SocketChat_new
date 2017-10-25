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
                IPHostEntry iPHost = Dns.GetHostEntry("localhost");
                IPAddress iPAdr = iPHost.AddressList[0];
                IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
                Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream,
                    ProtocolType.Tcp);

                sender.Connect(iPEndPoint);

                Console.WriteLine("Введите имя ");
                SendMessage(sender);

                Thread listenerThread = new Thread(new ParameterizedThreadStart(Listen));
                listenerThread.Start(sender);

                while (true)
                    SendMessage(sender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                Console.ReadLine();
            }
            Console.ReadKey();
        }


        static private void SendMessage(Socket sender)
        {
            string message = Console.ReadLine();
            byte[] msg = Encoding.UTF8.GetBytes(message);

            sender.Send(msg);
        }

        static public void Listen(object listenerO)
        {
            Socket listener = (listenerO as Socket);

            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = listener.Receive(bytes);
                Console.WriteLine("\nОтвет от сервера: {0}\n\n",
                    Encoding.UTF8.GetString(bytes, 0, bytesRec));
            }
        }

        //static private void SendMsg(int port)
        //{
        //    IPHostEntry iPHost = Dns.GetHostEntry("localhost");
        //    IPAddress iPAdr = iPHost.AddressList[0];
        //    IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, port);

        //    byte[] bytes = new byte[1024];

        //    Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        //    sender.Connect(iPEndPoint);

        //    Console.WriteLine("Введиет сообщение ");
        //    string message = Console.ReadLine();

        //    Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
        //    byte[] msg = Encoding.UTF8.GetBytes(message);

        //    sender.Send(msg);
        //    //int bytesRec = sender.Receive(bytes);

        //    Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

        //    if (message.IndexOf("<end>") == -1)
        //        SendMsg(port);

        //    sender.Shutdown(SocketShutdown.Both);
        //    sender.Close();
        //}
    }
}
