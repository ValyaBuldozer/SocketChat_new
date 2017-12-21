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

        public Client client = new Client();

        private DateTime currentTime;
        private string currentUser;
        private int messageCount;

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
                try
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
                                users_ListBox.Items.Add("Всем");
                                string[] users = e.GetMessage.GetMessage.Split(new char[1] { ';' });

                                foreach (string user in users)
                                    if (user != "") users_ListBox.Items.Add(user);     //фиксик починил баг

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
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("Unknown error", "Error", MessageBoxButtons.OK);
                    CloseConnection();
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
                CloseConnection();

            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }       

        private void AddMessage(Message message,Socket server)
        {
            if (currentTime.ToShortDateString() != message.GetTime.ToShortDateString())
            {
                Chat_textBox.AppendText("                          " + message.GetTime.ToShortDateString() + Environment.NewLine,
                    Color.LightSlateGray, FontStyle.Italic);
                currentUser = null;     //скинем чтобы написал
            }

            if (currentUser != message.GetUsername || messageCount == 10)
            {
                Chat_textBox.AppendText("" + message.GetUsername, Color.DarkBlue, FontStyle.Regular);
                Chat_textBox.AppendText("    " + message.GetTime.ToShortTimeString() + Environment.NewLine,
                    Color.LightGray, FontStyle.Regular);
                messageCount = 0;
            }


            if (message.GetMessageType == MessageType.PrivateMessage)
            {
                Chat_textBox.AppendText("   " + message.GetMessage + Environment.NewLine, Color.Firebrick, FontStyle.Bold);                
            }
            else
            {
                Chat_textBox.AppendText("   " + message.GetMessage + Environment.NewLine, Color.Black, FontStyle.Regular);               
            }

            currentTime = message.GetTime;
            currentUser = message.GetUsername;
            messageCount++;

            if (message.GetMessageType == MessageType.HistoryMessage)
                server.Send(Encoding.UTF8.GetBytes(
                    new Message(MessageType.Message, DateTime.Now).Serialize()));   //посылаем подтверждение DON'T TOUCH

        }

        public void CloseConnection()
        {
            users_ListBox.Items.Clear();
            Chat_textBox.Clear();
            sendMessage_textBox.Clear();

            currentTime = new DateTime();
            currentUser = "";

            try
            {
                client.ConnectionFlag = false;
                client.Socket.Send(Encoding.UTF8.GetBytes(new Message(MessageType.UserDisconnect, DateTime.Now).Serialize()));
                //client.Socket.Shutdown(SocketShutdown.Both);
                //client.Socket.Close();
                client.ListenThread.Abort();
            }
            catch(NullReferenceException) { }
            catch(SocketException) { }

            this.Hide();
            if(help!=null) help.Close();
            if(about!=null) about.Close();
            Program.cf.Show();
        }

        public Chat_form()
        {
            
            InitializeComponent();
            this.KeyPreview = true;

            client.MessageEvent += MessageEvevntHandler;
            Client.ServerErrorEvent += ServerErrorEventHandler;

            //users_ListBox.Items.Add("Всем");
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
                AddMessage(new Message(MessageType.PrivateMessage, DateTime.Now, "Private to " + users_ListBox.SelectedItem.ToString(),
                    sendMessage_textBox.Text, users_ListBox.SelectedItem.ToString()),client.Socket);
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
            this.Opacity = 0;
            timer.Start();
            this.Text = "Chat " + client.Username;
        }

        public Help_form help;
        AboutBox about;
        private void Top_Menu_Click(object sender, EventArgs e)
        {
            switch ((sender as ToolStripMenuItem).Name)
            {
                case "About":
                    {
                        about = new AboutBox();
                        about.ShowDialog();
                        break;
                    }
                case "Help":
                    {
                        if ((help == null) || (help.IsDisposed))
                        {
                            help = new Help_form();
                            help.Show();
                        }
                        break;
                    }
                case "СhangeUser":
                    {
                        CloseConnection();
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
                e.Handled = true;
                Send();
            }

          
        }

        private void Chat_form_Load(object sender, EventArgs e)
        {
            this.Text += " " + client.Username;
        }

        private void Chat_textBox_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            Chat_textBox.SelectionStart = Chat_textBox.Text.Length;
            // scroll it automatically
            Chat_textBox.ScrollToCaret();
        }


       
        private void Chat_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if ((help == null) || (help.IsDisposed))
                {
                    help = new Help_form();
                    help.Show();
                }
            }
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, FontStyle font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            Font currentFont = box.SelectionFont;
            box.SelectionFont = new Font(currentFont, font);
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
