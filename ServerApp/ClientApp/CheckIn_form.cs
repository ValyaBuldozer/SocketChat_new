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

        Chat_form chat_Form;

        public CheckIn_form()
        {
            InitializeComponent();
            this.KeyPreview = true;
            chat_Form = new Chat_form();
            Client.ServerErrorEvent += HandlerServerErrorEvent;
            login_textBox.Text = null;
            password_maskedTextBox.Text = null;
        }

        private void Check_In()
        {
            
            if (!chat_Form.client.ConnectToServer(login_textBox.Text, password_maskedTextBox.Text))
                return;

            chat_Form.Show();

            this.Hide();
        }


        private void checkin_button_Click(object sender, EventArgs e)
        {
            Check_In();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void HandlerServerErrorEvent(object sender,ServerErrorEventInfo e)
        {
            if (e.info == "Connection to server has been served")
            {
                Action action = () => this.Show();

                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }

            MessageBox.Show(e.info, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CheckIn_form_Shown(object sender, EventArgs e)
        {
            
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }
        
        private void help_button_Click(object sender, EventArgs e)
        {
            if  ((chat_Form.help == null) || (chat_Form.help.IsDisposed))
            {
                chat_Form.help = new Help_form();
                chat_Form.help.Show();
            }
        }

        
        private void CheckIn_form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        if ((chat_Form.help == null) || (chat_Form.help.IsDisposed))
                        {
                            chat_Form.help = new Help_form();
                            chat_Form.help.Show();
                        }
                        break;
                    }
                case Keys.Enter:
                    {
                        e.Handled = true;
                        if (checkin_button.Enabled)
                        {
                            Check_In();
                        }
                        break;
                    }
            }
           
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if ((login_textBox.Text != "" && login_textBox.Text != null) &&
                (password_maskedTextBox.Text != "" && password_maskedTextBox.Text != null))
                checkin_button.Enabled = true;
            else
            {
                checkin_button.Enabled = false;
            }
        }
        
    }
}
