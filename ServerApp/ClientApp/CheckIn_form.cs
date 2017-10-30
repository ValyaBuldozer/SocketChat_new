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
        public CheckIn_form()
        {
            InitializeComponent();
        }

        private void checkin_button_Click(object sender, EventArgs e)
        {

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
