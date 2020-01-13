using Patterns1.Control.Adapters;
using Patterns1.Control.Adapters.CarsTableAdapter;
using StockControl.Controllers;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control
{
    public class CarsTableMySqlConnector : TableConnector, ICarsTableConnector
    {
        private static CarsTableMySqlConnector instance;

        private CarsTableMySqlConnector() : base()
        {

        }

        public static CarsTableMySqlConnector GetInstance()
        {
            if (instance == null)
                instance = new CarsTableMySqlConnector();

            return instance;
        }


        public void Update(Car car)
        {
            string date = car.Date.ToString("yyyy-MM-dd");
            string querry = "Update cars set Name = '" + car.Name +
                        "', SerialNum = '" + car.SerialNum +
                        "', Date = '" + date +
                        "', ClientsId = " + car.IdClient +
                        " where Id = " + car.Id + ";";
            try
            {
                Querry(querry);
            }
            catch
            {
                throw new DatabaseActionException("Error, cannot Update car");
            }
        }

        public void Delete(int id)
        {
            string querry = "Delete from cars where Id = '" + id + "';";

            try
            {
                Querry(querry);
            }
            catch
            {
                throw new DatabaseActionException("Error, cannot Delete car");
            }
        }

        public void Insert(Car car)
        {
            string date = car.Date.ToString("yyyy-MM-dd");
            string querry = "Insert into cars (Id, Name, SerialNum, Date, ClientsId) values (" + car.Id +
                        ", '" + car.Name +
                        "', '" + car.SerialNum +
                        "', '" + date +                        
                        "', " + car.IdClient + ");";
            try
            {
                Querry(querry);
            }
            catch
            {
                throw new DatabaseActionException("Error, cannot Insert car");
            }

        }

        public CarsTable ReadDataFromDB()
        {
            DataSet ds = SelectQuerry("Select * From cars");
            CarsTable ct = Converter.ToCarList(ds);

            return ct;
        }
    }
}
