using AutoParking.Control.Handler;
using Patterns1.Control.Handler;
using Patterns1.Entity;
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

namespace Patterns1
{
    /// <summary>
    /// Interaction logic for OutputCarWindow.xaml
    /// </summary>
    public partial class OutputCarWindow : Window
    {
        public OutputCarWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            var cars = CarTableHandler.HasCarsForOutput();

            dataGrid.ItemsSource = cars;
            dataGrid.SelectedIndex = 0;
        }
        

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            carCheckBox.IsEnabled = true;
            var car = (Car)dataGrid.SelectedItem;
            if(CheckHandler.IsCheck(car) == false)
            {
                carCheckBox.IsEnabled = false;
                carCheckBox.IsChecked = false;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = (bool)carCheckBox.IsChecked;
            var controlCarHandler = ControlCarHandler.GetInstance();
            var car = (Car)dataGrid.SelectedItem;
            try
            {
                controlCarHandler.OutputCar(car, isCheck);
                WindowsOpenHandler.OpenActionClientWindow();
                this.Close();
            }
            catch (Exception ex)
            {
                string clientMessage = "Сar has not been taken from the parking lot\n" + ex.Message;
                MessageBox.Show(clientMessage +
                    "\nPlease wait, the administrator will come soon");
                AdminHandler.Send(clientMessage);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenActionClientWindow();

            this.Close();
        }

       
    }
}
