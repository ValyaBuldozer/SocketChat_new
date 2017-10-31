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
    public partial class CheckIn_form : Form
    {
        private void HandlerServerErrorEvent(object sender,ServerErrorEventInfo e)
        {
            MessageBox.Show(e.info, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        Chat_form chat_Form;

        public CheckIn_form()
        {
            InitializeComponent();
            chat_Form = new Chat_form();
            chat_Form.client.ServerErrorEvent += HandlerServerErrorEvent;
        }

        private void checkin_button_Click(object sender, EventArgs e)
        {
            chat_Form.client.ConnectToServer(login_textBox.Text, password_maskedTextBox.Text);
            //
            //
            this.Hide();
            Chat_form cf = new Chat_form();
            cf.ShowDialog();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
