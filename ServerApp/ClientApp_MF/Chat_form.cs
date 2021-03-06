﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Fonts;

namespace ClientApp_MF
{
    public partial class Chat_form : MetroForm
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
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Start();
            timer.Tick += new EventHandler((o, ev) =>
            {
                if (users.Visible)
                {

                    if (users.Height > maxheight)
                    {
                        System.Windows.Forms.Timer t = o as System.Windows.Forms.Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                    else users.Height += (int)(maxheight * 0.09);
                }
                else
                {
                    users.Height -= (int)(maxheight * 0.09);
                    if (users.Height <= 0)
                    {
                        System.Windows.Forms.Timer t = o as System.Windows.Forms.Timer; // можно тут просто воспользоваться timer
                        t.Stop();
                    }
                }
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }

        private void Chat_form_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Top_Menu_Click(object sender, EventArgs e)
        {
            //почему не работает? в обычной версии все норм, если не решить, просто сделать обычные методы для кнопок
            switch ((sender as ToolStripMenuItem).Name)
            {
                case "About":
                    {
                        AboutBox ab = new AboutBox();
                        ab.Show();
                        break;
                    }
                case "Users_menu":
                    {
                        
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
