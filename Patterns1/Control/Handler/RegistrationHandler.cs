using Patterns1.Entity;
using Patterns1.Entity.Other;
using Patterns1.Exceptions;
using StockControl;
using StockControl.Exceptions;
using StockControl.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Handler
{
    public class RegistrationHandler
    {
        public static void Registration(string name, string password, string passportId)
        {            
            try
            {
                // Do Registration
                AutoParkingDb.GetInstance().ClientsTable.Insert(name, password, passportId);
            }
            // Something is wrong
            catch (RegistrationException ex)
            {
                throw ex;
            }
            catch (DatabaseActionException ex)
            {
                throw ex;
            }
            SystemUser.GetInstance().Client = AutoParkingDb.GetInstance().ClientsTable.Find(name, password);
        }

        public static void CarRegistration(string model, string serialNum)
        {
            Car car = new Car();
            try
            {
                car.Name = ValidateField.ValidateString(model);
                car.SerialNum = ValidateField.ValidateString(serialNum);
            }
            catch (InputException ex)
            {
                throw ex;
            }

            try
            {
                AutoParkingDb aDb = AutoParkingDb.GetInstance();                
                var client = SystemUser.GetInstance().Client;                
                aDb.CarsTable.Insert(car.Name, car.SerialNum, client);
            }
            catch (DatabaseActionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
