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
    /// Interaction logic for EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
        private Car car;
        public EditCarWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            car = CurrentCar.GetInstance().Car;
            modelTextBox.Text = car.Name;
            serialNumTextBox.Text = car.SerialNum;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowsOpenHandler.OpenCarListWindow();
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string model = modelTextBox.Text;
            string serialNum = serialNumTextBox.Text;

            try
            {
                ProfileChangeHandler.SaveCarChange(car.Id, model, serialNum);
                WindowsOpenHandler.OpenCarListWindow();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сar info has not been changed\n" + ex.Message);
            }
        }
    }
}
