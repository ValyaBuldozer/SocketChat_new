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
        Client c;
        public Chat_form()
        {
            InitializeComponent();
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            c = new Client(input_text.Text);
            c.Launching();
            window_chat.Text += input_text.Text + "\r\n";
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}
