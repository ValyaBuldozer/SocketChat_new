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
using ServerApp;

namespace ServerApp
{
    class Program
    {
        private static int userCount = 0;

        static void Main(string[] args)
        {
            Thread serverThread = new Thread(new ThreadStart(Server.Run));
            bool endFlag = true;
            //Server.GetDbContext.Database.Delete();
            //Server.GetDbContext.Users.RemoveRange(Server.GetDbContext.Users);
            //Server.GetDbContext.SaveChanges();

            while(endFlag)
            {
                Console.WriteLine("\nEnter command");

                switch (Console.ReadLine())
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

                            if(username.Length >12 || username == "" || username.Contains(' '))
                            {
                                Console.WriteLine("Incorrect username");
                                break;
                            }

                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();

                            if(password.Length > 36 || password.Length < 4 || password.Contains(' '))
                            {
                                Console.WriteLine("Incorrect password");
                                break;
                            }

                            Server.UsernamePasswaordDic.Add(username, new ClientInfo(username, password));
                            Server.GetDbContext.Users.Add(new User { Username = username,Password = password });
                            Server.GetDbContext.SaveChanges();

                            Console.WriteLine("Registration complited");
                            break;
                        }

                    case "users":
                        {
                            if (!serverThread.IsAlive)
                            {
                                Console.WriteLine("Run the server");
                                break;
                            }

                            foreach (var user in Server.UsernamePasswaordDic)
                            {
                                string s = user.Key;
                                if (user.Value.IsOnline)
                                    s += " " + "online";
                                else
                                    s += " " + "offline";
                                Console.WriteLine(s);
                            }

                            break;
                        }

                    case "clearhistory":
                        {
                            if (serverThread.IsAlive)
                            {
                                Console.WriteLine("Cannot execute this operation while server is running.");
                                break;
                            }
                            Server.GetDbContext.Messages.RemoveRange(Server.GetDbContext.Messages);
                            Server.GetDbContext.SaveChanges();
                            break;
                        }

                    case "clearusers":
                        {
                            if (serverThread.IsAlive)
                            {
                                Console.WriteLine("Cannot execute this operation while server is running.");
                                break;
                            }
                            Server.GetDbContext.Users.RemoveRange(Server.GetDbContext.Users);
                            Server.GetDbContext.SaveChanges();
                            break;
                        }

                    case "help":
                        {
                            Console.WriteLine("run - запустиь сервер");
                            Console.WriteLine("end - безопасное завершение работы сервера");
                            Console.WriteLine("register - зарегистрировать пользователя");
                            Console.WriteLine("users - посмотреть список пользователей");
                            Console.WriteLine("cleanhistory - очистить историю сообщений");
                            Console.WriteLine("cleanusers - очистиь список пользователей");
                            Console.WriteLine("help - помощь");

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

