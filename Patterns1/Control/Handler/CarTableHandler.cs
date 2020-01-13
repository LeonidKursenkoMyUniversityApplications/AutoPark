using Patterns1.Entity;
using Patterns1.Entity.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Control.Handler
{
    public class CarTableHandler
    {
        public static IEnumerable<Car> HasCarsForInput()
        {
            try
            {
                AutoParkingDb autoParkingDb = AutoParkingDb.GetInstance();
                Client client = SystemUser.GetInstance().Client;
                var cars = autoParkingDb.CarsTable.Data.FindAll(x => (x.IdClient == client.Id) &&
                            (autoParkingDb.PlacedCarsTable.Data.Exists(y => y.IdCar == x.Id) != true));
                if (cars.Count == 0)
                    throw new Exception("There is no available car for placing in the parking");
                return cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Car> HasCarsForOutput()
        {
            try
            {
                AutoParkingDb autoParkingDb = AutoParkingDb.GetInstance();
                Client client = SystemUser.GetInstance().Client;
                var cars = autoParkingDb.CarsTable.Data.FindAll(x => (x.IdClient == client.Id) &&
                            (autoParkingDb.PlacedCarsTable.Data.Exists(y => y.IdCar == x.Id) == true));
                if (cars.Count == 0)
                    throw new Exception("There is no car in the parking");
                return cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Car> HasCarsForEdit()
        {
            try
            {
                AutoParkingDb autoParkingDb = AutoParkingDb.GetInstance();
                Client client = SystemUser.GetInstance().Client;
                var cars = autoParkingDb.CarsTable.Data.FindAll(x => x.IdClient == client.Id);
                if (cars.Count == 0)
                    throw new Exception("There is no car in the parking");
                return cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
