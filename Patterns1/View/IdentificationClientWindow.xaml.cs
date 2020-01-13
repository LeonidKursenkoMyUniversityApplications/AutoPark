using Patterns1.Control.Handler;
using Patterns1.Exceptions;
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
    /// Interaction logic for IdentificationClientWindow.xaml
    /// </summary>
    public partial class IdentificationClientWindow : Window
    {
        public IdentificationClientWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            try
            {
                IdentificationHandler.Identification(login, password);
                WindowsOpenHandler.OpenActionClientWindow();
                this.Close();
            }
            catch(IdentificationException ex)
            {
                MessageBox.Show("Identification error\n" + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenStartClientWindow();
            this.Close();
        }
    }
}
