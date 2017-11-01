using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ClientApp
{
    public partial class Chat_form : Form
    {
        public Client client = new Client();

        public Chat_form()
        {
            ;
            InitializeComponent();

            client.MessageEvent += MessageEvevntHandler;
            Client.ServerErrorEvent += ServerErrorEventHandler;
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            client.SendMessage(sendMessage_textBox.Text);
        }

        

       

        

       



        private void MessageEvevntHandler(object handler, MessageEventInfo e)
        {
            //я не понимаю что это но оно работает
            Action action = () => this.Chat_textBox.Text += e.message + Environment.NewLine;

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
                users.Items.Clear();
                //
                client = new Client();

                this.Hide();

            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
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
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Start();
            timer.Tick += new EventHandler((o, ev) =>
            {
                if (users.Visible)
                {

                    if (users.Height > maxheight)
                    {
                        Timer t = o as Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                    else users.Height += (int)(maxheight * 0.09);
                }
                else
                {
                    users.Height -= (int)(maxheight * 0.09);
                    if (users.Height <= 0)
                    {
                        Timer t = o as Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                }
            });
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
                case "Isers_menu":
                    {
                        if (Width < 800)
                        {
                            users.Visible = !users.Visible;
                            Animation();
                        }
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
    }
}
