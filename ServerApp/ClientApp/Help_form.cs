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
    public partial class Help_form : Form
    {
        public Help_form()
        {
            InitializeComponent();
            Info_box_interf.Visible = false;
            Info_box_mes.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }

        private void Help_form_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        

        private void registration_Click(object sender, EventArgs e)
        {
            Info_box_reg.Visible = true;
            Info_box_interf.Visible =false ;
            Info_box_mes.Visible = false;
        }

        private void interfaceElements_Click(object sender, EventArgs e)
        {
            Info_box_reg.Visible = false;
            Info_box_interf.Visible = true;
            Info_box_mes.Visible = false;
        }

        private void sendingMessages_Click(object sender, EventArgs e)
        {
            Info_box_reg.Visible = false;
            Info_box_interf.Visible = false;
            Info_box_mes.Visible = true;
        }
    }
}
