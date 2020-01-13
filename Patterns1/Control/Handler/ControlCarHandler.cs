using AutoParking.Control.Handler;
using AutoParking.Entity.Tables;
using Patterns1.Entity;
using Patterns1.Entity.Other;
using Patterns1.Exceptions;
using StockControl;
using StockControl.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Handler
{
    public class ControlCarHandler
    {
        private static ControlCarHandler instance;
        
        private CheckHandler check;

        private ControlCarHandler()
        {
            
        }

        public static ControlCarHandler GetInstance()
        {
            if (instance == null)
                instance = new ControlCarHandler();

            return instance;
        }

        public void InputCar(Car car, bool isCheck)
        {       
            check = CheckHandler.GetInstance(car);
            if(isCheck == true) check.DoCheck();
            //Car = car;
            try
            {
                OnInputCarUpdate(car);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void OutputCar(Car car, bool isCheck)
        {
            check = CheckHandler.GetInstance(car);
            if (isCheck == true)
            {
                if (check.MakeCheck() == true)
                {
                    try
                    {
                        check.DoCompare();
                    }
                    catch(CheckCarException ex)
                    {
                        throw ex;
                    }                
                }
            }
            try
            {
                OnOutputCarUpdate(car);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void OnInputCarUpdate(Car car)
        {
            try
            {
                AutoParkingDb aDb = AutoParkingDb.GetInstance();
                Place place = FreeSpaceHandler.FindFree();
                place.IsAvailable = false;
                var client = SystemUser.GetInstance().Client;

                LiftHandler.Lift();
                aDb.PlacesTable.Update(place);
                aDb.PlacedCarsTable.Insert(car, place);
                aDb.CarsTable.Update(car.Id, car.Name, car.SerialNum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void OnOutputCarUpdate(Car car)
        {
            try
            {
                AutoParkingDb aDb = AutoParkingDb.GetInstance();
                LiftHandler.Lift();
                PlacedCar placedCar = aDb.PlacedCarsTable.Data.First(x => x.IdCar == car.Id);
                Place place = aDb.PlacesTable.FindPlace(placedCar.IdPlace);
                place.IsAvailable = true;
                aDb.PlacesTable.Update(place);
                aDb.PlacedCarsTable.Delete(car.Id);
                aDb.CarsTable.Update(car.Id, car.Name, car.SerialNum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
