using Patterns1.Control.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParking.Entity.Tables;
using StockControl.Exceptions;
using System.Data;
using StockControl.Controllers;

namespace AutoParking.Control.Adapters.PlacedCarsTableAdapter
{
    public class PlacedCarsTableMySqlConnector : TableConnector, IPlacedCarsTableConnector
    {
        private static PlacedCarsTableMySqlConnector instance;
        private PlacedCarsTableMySqlConnector() : base()
        {

        }

        public static PlacedCarsTableMySqlConnector GetInstance()
        {
            if (instance == null)
                instance = new PlacedCarsTableMySqlConnector();

            return instance;
        }

        public void Delete(int id)
        {
            string querry = "Delete from placedcars where IdCar = '" + id + "';";

            try
            {
                Querry(querry);
            }
            catch
            {
                throw new DatabaseActionException("Error, cannot Delete car");
            }
        }

        public void Insert(PlacedCar placedCar)
        {
            string querry = "Insert into placedcars (IdCar, IdPlace) values ('" + placedCar.IdCar +
                         "', '" + placedCar.IdPlace + "');";
            try
            {
                Querry(querry);
            }
            catch
            {
                throw new DatabaseActionException("Error, cannot Insert car");
            }
        }

        public PlacedCarsTable ReadDataFromDB()
        {
            DataSet ds = SelectQuerry("Select * From placedcars");
            PlacedCarsTable pt = Converter.ToPlacedCarList(ds);

            return pt;
        }

        public void Update(PlacedCar placedCar)
        {
            throw new NotImplementedException();
        }
    }
}
