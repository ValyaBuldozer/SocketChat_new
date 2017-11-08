using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread serverThread = new Thread(new ThreadStart(Server.Run));
            bool endFlag = true;

            while(endFlag)
            {
                Console.WriteLine("\n Enter comand");
                switch(Console.ReadLine())
                {
                    case "run":
                        {
                            if(serverThread.IsAlive)
                            {
                                Console.WriteLine("Server already running");
                                break;
                            }

                            ReadUserPasDic();
                            serverThread.Start();
                            break;
                        }

                    case "end":
                        {
                            if(!serverThread.IsAlive)
                            {
                                Console.WriteLine("Server is not running");
                                break;
                            }
                            try
                            {
                                WriteUserPasDic();
                                endFlag = false;
                                Server.End();
                            }
                            catch(ThreadAbortException)
                            {
                                break;
                            }
                            break;
                        }

                    case "save":
                        {
                            if (serverThread.IsAlive)
                                WriteUserPasDic();
                            else
                                Console.WriteLine("Run the server before trying to save");

                            break;
                        }

                    case "register":
                        {
                            if(!serverThread.IsAlive)
                            {
                                Console.WriteLine("Run the server before trying to register");
                                break;
                            }

                            Console.WriteLine("Enter username");
                            string username = Console.ReadLine();

                            if(Server.UsernamePasswaordDic.ContainsKey(username))
                            {
                                Console.WriteLine("Username already taken");
                                break;
                            }

                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();

                            Server.UsernamePasswaordDic.Add(username, new ClientInfo(username, password));
                            Console.WriteLine("Registration complited");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Unknown comand");
                            break;
                        }
                }
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        static void ReadUserPasDic()
        {
            FileStream fileStream =
                new FileStream("NamePassswordDic.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);

            Server.UsernamePasswaordDic = 
                JsonConvert.DeserializeObject<Dictionary<string, ClientInfo>>(reader.ReadToEnd());

            reader.Close();
        }

        static void WriteUserPasDic() => File.WriteAllText("NamePassswordDic.txt",
                JsonConvert.SerializeObject(Server.UsernamePasswaordDic));
    }
}

