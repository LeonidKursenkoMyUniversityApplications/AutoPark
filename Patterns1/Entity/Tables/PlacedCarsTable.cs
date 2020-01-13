using AutoParking.Control.Adapters.PlacedCarsTableAdapter;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Entity.Tables
{
    public class PlacedCarsTable
    {
        public List<PlacedCar> Data { get; set; }

        private IPlacedCarsTableConnector iPlacedCarsTableConnector;

        public void SetConnector(IPlacedCarsTableConnector iPlacedCarsConnector)
        {
            iPlacedCarsTableConnector = iPlacedCarsConnector;
        }

        public void Insert(Car car, Place place)
        {
            PlacedCar placedCar = new PlacedCar();
            
            placedCar.IdCar = car.Id;
            placedCar.IdPlace = place.Id;

            try
            {
                iPlacedCarsTableConnector.Insert(placedCar);
            }
            catch (DatabaseActionException ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                iPlacedCarsTableConnector.Delete(id);
            }
            catch (DatabaseActionException ex)
            {
                throw ex;
            }
        }
    }
}
