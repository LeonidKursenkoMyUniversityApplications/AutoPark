using Patterns1.Entity;
using Patterns1.Entity.Other;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Control.Handler
{
    public class ProfileChangeHandler
    {
        public static void SaveChange(int id, string name, string password, string passportId)
        {
            try
            {
                // Do Registration
                AutoParkingDb.GetInstance().ClientsTable.Update(id, name, password, passportId);
            }
            // Something is wrong
            catch (Exception ex)
            {
                throw ex;
            }            
            SystemUser.GetInstance().Client = AutoParkingDb.GetInstance().ClientsTable.Find(name, password);
        }

        public static void SaveCarChange(int id, string model, string serialNum)
        {
            try
            {
                // Do Registration
                AutoParkingDb.GetInstance().CarsTable.Update(id, model, serialNum);
            }
            // Something is wrong
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
