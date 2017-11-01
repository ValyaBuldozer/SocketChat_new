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
            InitializeComponent();
            client.MessageEvent += MessageEvevntHandler;
            Client.ServerErrorEvent += ServerErrorEventHandler;
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            client.SendMessage(sendMessage_textBox.Text);
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void changeUser_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.cf.Show();
        }



        private void MessageEvevntHandler(object handler,MessageEventInfo e)
        {
            //я не понимаю что это но оно работает
            Action action = () => this.Chat_textBox.Text+=e.message+Environment.NewLine;

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private  void ServerErrorEventHandler(object handler,ServerErrorEventInfo e)
        {
            if (e.info != "Connection to server has been served") return;

            //я не понимаю что это но оно работает

            Action action = () =>
            {
                sendMessage_textBox.Clear();
                Chat_textBox.Clear();
                users_textBox.Clear();
                client = new Client();

                this.Hide();

            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

    }
}
