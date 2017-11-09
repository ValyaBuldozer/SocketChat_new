using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Fonts;

namespace ClientApp_MF
{
    public partial class Chat_form : MetroForm
    {
        public Chat_form()
        {
            InitializeComponent();
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
