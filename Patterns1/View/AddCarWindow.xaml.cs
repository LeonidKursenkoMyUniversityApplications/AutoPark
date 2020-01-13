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

namespace AutoParking.View
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            modelTextBox.Text = "";
            serialNumTextBox.Text = "";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string model = modelTextBox.Text;
            string serialNum = serialNumTextBox.Text;
            
            try
            {
                RegistrationHandler.CarRegistration(model, serialNum);
                WindowsOpenHandler.OpenInputCarWindow();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сar info has not been saved\n" + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenActionClientWindow();

            this.Close();
        }
    }
}
