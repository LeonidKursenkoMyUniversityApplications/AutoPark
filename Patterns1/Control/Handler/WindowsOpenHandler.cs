using AutoParking.Control.Handler;
using AutoParking.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Patterns1.Control.Handler
{
    public class WindowsOpenHandler
    {
        public static void OpenStartClientWindow()
        {
            StartClientWindow startClientWindow = new StartClientWindow();
            startClientWindow.Show();
        }
        public static void OpenIdentificationClientWindow()
        {
            IdentificationClientWindow identificationClientWindow = new IdentificationClientWindow();
            identificationClientWindow.Show();
        }

        public static void OpenRegistrationClientWindow()
        {
            RegistrationClientWindow registrationClientWindow = new RegistrationClientWindow();
            registrationClientWindow.Show();
        }

        public static void OpenActionClientWindow()
        {
            ActionClientWindow actionClientWindow = new ActionClientWindow();
            actionClientWindow.Show();
        }

        public static void OpenInputCarWindow()
        {
            IEnumerable<Car> cars;
            try
            {
                cars = CarTableHandler.HasCarsForInput();
                InputCarWindow();
            }
            // if empty list (no available registred car)
            catch
            {
                OpenAddCarWindow();
            }            
            
        }

        private static void InputCarWindow()
        {
            InputCarWindow inputCarWindow = new InputCarWindow();
            inputCarWindow.Show();
        }

        public static void OpenOutputCarWindow()
        {
            try
            {
                CarTableHandler.HasCarsForOutput();
                OutputCarWindow outputCarWindow = new OutputCarWindow();
                outputCarWindow.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                OpenActionClientWindow();
            }
            
        }

        public static void OpenProfileWindow()
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
        }

        public static void OpenAddCarWindow()
        {
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.Show();
        }

        public static void OpenCarListWindow()
        {            
            try
            {
                CarTableHandler.HasCarsForEdit();
                CarListWindow carListWindow = new CarListWindow();
                carListWindow.Show();
            }
            catch
            {
                
                MessageBox.Show("There is no car");
                OpenActionClientWindow();
            }
        }

        public static void OpenEditCarWindow()
        {
            EditCarWindow carListWindow = new EditCarWindow();
            carListWindow.Show();
        }
    }
}
