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
    public partial class Window_form : Form
    {
        Client c;
        public Window_form()
        {
            InitializeComponent();
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            c = new Client(input_text.Text);
            c.Launching();
            window_chat.Text += input_text.Text + "\r\n";
        }
    }
}
