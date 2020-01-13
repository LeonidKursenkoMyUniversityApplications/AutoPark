using Patterns1.Control.Handler;
using Patterns1.Entity;
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
    /// Interaction logic for StartClientWindow.xaml
    /// </summary>
    public partial class StartClientWindow : Window
    {
        private AutoParkingDb autoParkingDb;
        public StartClientWindow()
        {
            InitializeComponent();
            Init();
            autoParkingDb = AutoParkingDb.GetInstance();
            
        }

        private void Init()
        {       
            IsFreePlacesLabel.Content = FreeSpaceHandler.Result();
        }

        private void IdentificationButton_Click(object sender, RoutedEventArgs e)
        {            
            WindowsOpenHandler.OpenIdentificationClientWindow();

            this.Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {            
            WindowsOpenHandler.OpenRegistrationClientWindow();

            this.Close();
        }

       

        private void Window_Activated(object sender, EventArgs e)
        {
            Init();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
  
        }
    }
}
