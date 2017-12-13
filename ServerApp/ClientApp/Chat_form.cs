﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace ClientApp
{
    public partial class Chat_form : Form
    {
        /// <summary>
        /// Обработчик сообщения с сервера
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="e"></param>
        private void MessageEvevntHandler(object handler, MessageEventInfo e)
        {
            Action action = () =>
            {
                switch (e.message.GetMessageType)
                {
                    case MessageType.Message:
                        {
                            Chat_textBox.Text += e.message.GetUsername + ": " + e.message.GetMessage + Environment.NewLine;
                            break;
                        }
                    case MessageType.PrivateMessage:
                        {
                            Chat_textBox.Text += "Private from "+ e.message.GetUsername + ": " + e.message.GetMessage + Environment.NewLine;
                            break;
                        }
                    case MessageType.UserList:
                        {
                            string[] users = e.message.GetMessage.Split(new char[1] { ';' });

                            foreach (string user in users)
                                users_ListBox.Items.Add(user);

                            break;
                        }
                    case MessageType.UserConnect:
                        {
                            users_ListBox.Items.Add(e.message.GetUsername);
                            break;
                        }
                    case MessageType.UserDisconnect:
                        {
                            users_ListBox.Items.Remove(e.message.GetUsername);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                 
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void ServerErrorEventHandler(object handler, ServerErrorEventInfo e)
        {
            if (e.info != "Connection to server has been served") return;

            //я не понимаю что это но оно работает

            Action action = () =>
            {
                sendMessage_textBox.Clear();
                Chat_textBox.Clear();
                //
                users_ListBox.Items.Clear();
                //
                client = new Client();

                this.Hide();

            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        public Client client = new Client();

        public Chat_form()
        {
            
            InitializeComponent();

            client.MessageEvent += MessageEvevntHandler;
            Client.ServerErrorEvent += ServerErrorEventHandler;
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            client.SendMessage(sendMessage_textBox.Text);
        }   

        private void Chat_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void Chat_form_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }
        
        private void Top_Menu_Click(object sender, EventArgs e)
        {
            switch ((sender as ToolStripMenuItem).Name)
            {
                case "About":
                    {
                        AboutBox ab = new AboutBox();
                        ab.Show();
                        break;
                    }
                //case "Users_menu":
                //    {
                //        if (Width < 800)
                //        {
                //            users.Visible = !users.Visible;
                //            Animation();
                //        }
                //        break;
                //    }
                case "СhangeUser":
                    {
                        this.Hide();
                        Program.cf.Show();
                        break;
                    }
                case "Exit":
                    {
                        Application.Exit();
                        break;
                    }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }

        private void Animation()
        {
            double maxheight = Height * 0.6328;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Start();
            timer.Tick += new EventHandler((o, ev) =>
            {
                if (users_ListBox.Visible)
                {

                    if (users_ListBox.Height > maxheight)
                    {
                        System.Windows.Forms.Timer t = o as System.Windows.Forms.Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                    else users_ListBox.Height += (int)(maxheight * 0.09);
                }
                else
                {
                    users_ListBox.Height -= (int)(maxheight * 0.09);
                    if (users_ListBox.Height <= 0)
                    {
                        System.Windows.Forms.Timer t = o as System.Windows.Forms.Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                }
            });
        }
    }
}
