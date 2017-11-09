using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Fonts;

namespace ClientApp_MF
{
    public partial class CheckIn_form : MetroForm
    {
        Chat_form chat_Form;
        public CheckIn_form()
        {
            InitializeComponent();
            chat_Form = new Chat_form();
        }

        private void checkin_button_Click(object sender, EventArgs e)
        {
            chat_Form.Show();
            this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }

        private void CheckIn_form_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
