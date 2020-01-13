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
    /// Interaction logic for ActionClientWindow.xaml
    /// </summary>
    public partial class ActionClientWindow : Window
    {
        public ActionClientWindow()
        {
            InitializeComponent();
        }

        private void InputCarButton_Click(object sender, RoutedEventArgs e)
        {

            WindowsOpenHandler.OpenInputCarWindow();
            this.Close();
        }

        private void OutputCarButton_Click(object sender, RoutedEventArgs e)
        {
            if(FreeSpaceHandler.IsFree() == false)
            {
                MessageBox.Show("There is no available place");
                return;
            }

            WindowsOpenHandler.OpenOutputCarWindow();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenStartClientWindow();
            this.Close();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenProfileWindow();
            this.Close();
        }

        private void CarListButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenCarListWindow();
            this.Close();
        }
    }
}
