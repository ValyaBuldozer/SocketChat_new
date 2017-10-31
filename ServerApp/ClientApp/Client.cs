using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ClientApp
{
    public class ServerErrorEventInfo:EventArgs
    {
        public ServerErrorEventInfo(string info)
        {
            this.info = info;
        }
        public string info;
    }

    public class Client
    {
        public event EventHandler<ServerErrorEventInfo> ServerErrorEvent;

        public virtual void ServerErrorEventRun(ServerErrorEventInfo e)
        {
            EventHandler<ServerErrorEventInfo> handler = ServerErrorEvent;
            handler(this, e);
        }

        public void ConnectToServer(string username,string password)
        {
            try
            {
                IPHostEntry iPHost = Dns.GetHostEntry("localhost");
                IPAddress iPAdr = iPHost.AddressList[0];
                IPEndPoint iPEndPoint = new IPEndPoint(iPAdr, 8800);
                Socket sender = new Socket(iPAdr.AddressFamily, SocketType.Stream,
                    ProtocolType.Tcp);

                sender.Connect(iPEndPoint);


            }
            catch (SocketException)
            {
                ServerErrorEventRun(new ServerErrorEventInfo("no connection"));
            }
        }
    }
}
