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
using System.Data.Entity;

namespace ServerApp
{
    class Program
    {
        private static int userCount = 0;

        static void Main(string[] args)
        {
            Thread serverThread = new Thread(new ThreadStart(Server.Run));
            bool endFlag = true;

            while(endFlag)
            {
                Console.WriteLine("\nEnter comand");
                switch(Console.ReadLine())
                {
                    case "run":
                        {
                            if(serverThread.IsAlive)
                            {
                                Console.WriteLine("Server already running");
                                break;
                            }

                            Console.WriteLine("Wait...");
                            ReadUserPasDic();
                            serverThread.Start();
                            Console.WriteLine("Completed");
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
                               // WriteUserPasDic();
                                endFlag = false;
                                Server.End();
                            }
                            catch(ThreadAbortException)
                            {
                                break;
                            }
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

                            if(Server.UsernamePasswaordDic.ContainsKey(username) || username == "server")
                            {
                                Console.WriteLine("Username already taken");
                                break;
                            }

                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();

                            Server.UsernamePasswaordDic.Add(username, new ClientInfo(username, password));
                            Server.GetDbContext.Users.Add(new User { Username = username,Password = password });
                            Server.GetDbContext.SaveChanges();

                            Console.WriteLine("Registration complited");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Unknown command");
                            break;
                        }
                }
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        static void ReadUserPasDic()
        { 
            var userList = Server.GetDbContext.Users;

            foreach(var i in userList)
            {
                Server.UsernamePasswaordDic.Add(i.Username, new ClientInfo(i.Username, i.Password, false));
            }
        }
    }
}

