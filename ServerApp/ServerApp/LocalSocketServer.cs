using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerApp
{
    class LocalSocketServer
    {
        private class ClientSocket
        {
            private string _userName;
            private int _userPort;

            public string UserName { get => _userName; set { } }

            public int UserPort { get => _userPort; set { } }


        }

        private IPEndPoint _ipEndPoint;
        static private int _clientCount=0;
        private Socket _sListener;

        public static int ClientCount { get => _clientCount; set { } }

        public IPEndPoint IpEndPoint { get => _ipEndPoint; set { } }

        public Socket SListener { get => _sListener; set { } }

        public LocalSocketServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            _ipEndPoint = new IPEndPoint(ipAddr, 11000 + ClientCount);
            ClientCount++;
            _sListener = new Socket(ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            _sListener.Bind(_ipEndPoint);
        }

        public Socket GetListenerSocket()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IpEndPoint = new IPEndPoint(ipAddr, 11000+ClientCount);
            ClientCount++;
            Socket sListener = new Socket(ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            return sListener;
        }

    }
}
