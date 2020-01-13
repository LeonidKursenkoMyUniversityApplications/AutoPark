using AutoParking.Control.Handler;
using Patterns1.Control.Handler;
using Patterns1.Entity.Other;
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

namespace AutoParking.View
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        Client client;
        public ProfileWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            client = SystemUser.GetInstance().Client;
            loginTextBox.Text = client.Name;
            passportIdTextBox.Text = client.PassportId;
            passwordTextBox.Text = client.Password;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string passportId = passportIdTextBox.Text;
            string password = passwordTextBox.Text;
            try
            {
                ProfileChangeHandler.SaveChange(client.Id, login, password, passportId);
                WindowsOpenHandler.OpenActionClientWindow();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, unsuccessful data change\n" + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenActionClientWindow();

            this.Close();
        }
    }
}
