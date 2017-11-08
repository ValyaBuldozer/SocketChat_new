using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace ClientApp_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Chat_form_wpf chat_form;

        private void HandlerServerErrorEvent(object sender, ServerErrorEventInfo e)
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

       
        public MainWindow()
        {
            InitializeComponent();
            chat_form = new Chat_form_wpf();
            Client.ServerErrorEvent += HandlerServerErrorEvent;
        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {

            if (!chat_form.client.ConnectToServer(login.Text, password.Text))
                return;

            
            chat_form.Show();
            this.Hide();
            
        }
    }
}
