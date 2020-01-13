using AutoParking.Control.Handler;
using AutoParking.Entity.Other;
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
    /// Interaction logic for CarListWindow.xaml
    /// </summary>
    public partial class CarListWindow : Window
    {
        public CarListWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            var cars = CarTableHandler.HasCarsForEdit();

            dataGrid.ItemsSource = cars;
            dataGrid.SelectedIndex = 0;
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentCar.GetInstance().Car = (Car)dataGrid.SelectedItem;
            WindowsOpenHandler.OpenEditCarWindow();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenActionClientWindow();
            this.Close();
        }
    }
}
