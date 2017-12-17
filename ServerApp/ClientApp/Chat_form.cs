using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;

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
            //don't ask, don't touch
            Action action = () =>
            {
                switch (e.GetMessage.GetMessageType)
                {
                    case MessageType.Message:
                    case MessageType.PrivateMessage:
                    case MessageType.HistoryMessage:
                        {
                            AddMessage(e.GetMessage, e.GetServerSocket);
                            break;
                        }
                    case MessageType.UserList:
                        {
                            string[] users = e.GetMessage.GetMessage.Split(new char[1] { ';' });

                            foreach (string user in users)
                                if(user!="") users_ListBox.Items.Add(user);     //фиксик починил баг

                            e.GetServerSocket.Send(Encoding.UTF8.GetBytes(
                               new Message(MessageType.Message, DateTime.Now).Serialize()));   //посылаем подтверждение

                            break;
                        }
                    case MessageType.UserConnect:
                        {
                            users_ListBox.Items.Add(e.GetMessage.GetUsername);
                            break;
                        }
                    case MessageType.UserDisconnect:
                        {
                            users_ListBox.Items.Remove(e.GetMessage.GetUsername);
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

            //don't ask, don't touch

            Action action = () =>
            {
                sendMessage_textBox.Clear();
                Chat_textBox.Clear();
                //
                users_ListBox.Items.Clear();
                
                client = new Client();

                this.Hide();

            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void AddMessage(Message message,Socket server)
        {
            if(message.GetMessageType == MessageType.PrivateMessage)
                Chat_textBox.Text += message.GetTime.ToShortTimeString() + " " + "Private from " + message.GetUsername + ": "
                                + message.GetMessage + Environment.NewLine;
            else
                Chat_textBox.Text += message.GetTime.ToShortTimeString() + "   " + message.GetUsername
                                + ": " + message.GetMessage + Environment.NewLine;

            if(message.GetMessageType == MessageType.HistoryMessage)
                server.Send(Encoding.UTF8.GetBytes(
                    new Message(MessageType.Message, DateTime.Now).Serialize()));   //посылаем подтверждение DON'T TOUCH

        }

        public Client client = new Client();

        public Chat_form()
        {
            
            InitializeComponent();

            client.MessageEvent += MessageEvevntHandler;
            Client.ServerErrorEvent += ServerErrorEventHandler;

            users_ListBox.Items.Add("Всем");
        }
        private void Send()
        {
            if (sendMessage_textBox.Text == "" || sendMessage_textBox.Text == null) return;

            if (users_ListBox.SelectedItem == null || users_ListBox.SelectedIndex == 0)     //не приватное сообщение
                client.SendMessage(sendMessage_textBox.Text, null);
            else                                                                            //приватное сообщение
            {
                client.SendMessage(sendMessage_textBox.Text, users_ListBox.SelectedItem.ToString());

                //сами ручками его отобразим
                Chat_textBox.Text += DateTime.Now.ToShortTimeString() + " " + "Private to " + users_ListBox.SelectedItem.ToString()
                    + ": " + sendMessage_textBox.Text + Environment.NewLine;
            }

            sendMessage_textBox.Text = "";
        }
        private void send_button_Click(object sender, EventArgs e)
        {
            Send();
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
                case "Help":
                    {
                        Help_form help = new Help_form();
                        help.Show();
                        break;
                    }
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

        

        private void sendMessage_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                Send();
            }
        }

        private void Chat_form_Load(object sender, EventArgs e)
        {
            this.Text += " " + client.Username;
        }
    }
}
