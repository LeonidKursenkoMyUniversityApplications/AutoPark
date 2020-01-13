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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public Terminal Terminal { get; set; }
        public TestWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Car car = new Car()
            {
                Id = 2,
                Date = new DateTime(2016, 11, 29),
                Name = "car2",
                SerialNum = "sfg3354",
                IdClient = 2,
                IdPlace = 2
            };
            ControlCar controlCar = ControlCar.GetInstance(car);
            Terminal = Terminal.GetInstance(controlCar);
            controlCar.Terminal = Terminal;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Terminal.Run();
            label.Content = "All is ok";
        }
    }
}
