using Patterns1.Control.Handler;
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
using System.Windows.Shapes;

namespace Patterns1
{
    /// <summary>
    /// Interaction logic for RegistrationClientWindow.xaml
    /// </summary>
    public partial class RegistrationClientWindow : Window
    {
        public RegistrationClientWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            loginTextBox.Text = "";
            passportIdTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string passportId = passportIdTextBox.Text;
            string password = passwordTextBox.Text;
            try
            {
                RegistrationHandler.Registration(login, password, passportId);
                WindowsOpenHandler.OpenActionClientWindow();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, unsuccessful registration\n" + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenStartClientWindow();

            this.Close();
        }
    }
}
