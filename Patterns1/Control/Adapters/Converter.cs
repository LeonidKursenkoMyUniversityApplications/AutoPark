using AutoParking.Entity.Tables;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Controllers
{
    public class Converter
    {
       
        public static AdministratorsTable ToAdministratorList(DataSet ds)
        {
            List<Administrator> list;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new Administrator
                    {
                        Id = dataRow.Field<int>("Id"),
                        Name = dataRow.Field<string>("Name"),
                        Password = dataRow.Field<string>("Password")
                    }).ToList();
            }
            catch
            {
                throw new DatabaseActionException("Cannot convert DataSet to List<Administrator>");
            }
            AdministratorsTable table = new AdministratorsTable();
            table.Data = list;
            return table;
        }

        public static ClientsTable ToClientList(DataSet ds)
        {
            List<Client> list;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new Client
                    {
                        Id = dataRow.Field<int>("Id"),
                        Name = dataRow.Field<string>("Name"),
                        PassportId = dataRow.Field<string>("PassportId"),
                        RegistrationDate = dataRow.Field<DateTime>("RegistrationDate"),
                        Password = dataRow.Field<string>("Password"),
                        IsBlock = dataRow.Field<bool>("IsBlock")
                    }).ToList();
            }
            catch
            {
                throw new DatabaseActionException("Cannot convert DataSet to List<Client>");
            }
            ClientsTable table = new ClientsTable();
            table.Data = list;
            return table;
        }

        public static PlacesTable ToPlaceList(DataSet ds)
        {
            List<Place> list;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new Place
                    {
                        Id = dataRow.Field<int>("Id"),
                        IsAvailable = dataRow.Field<bool>("IsAvailable")
                    }).ToList();
            }
            catch
            {
                throw new DatabaseActionException("Cannot convert DataSet to List<Place>");
            }
            PlacesTable table = new PlacesTable();
            table.Data = list;
            return table;
        }

        public static PlacedCarsTable ToPlacedCarList(DataSet ds)
        {
            List<PlacedCar> list;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new PlacedCar
                    {
                        IdCar = dataRow.Field<int>("IdCar"),
                        IdPlace = dataRow.Field<int>("IdPlace")
                    }).ToList();
            }
            catch
            {
                throw new DatabaseActionException("Cannot convert DataSet to List<PlacedCar>");
            }
            PlacedCarsTable table = new PlacedCarsTable();
            table.Data = list;
            return table;
        }

        public static CarsTable ToCarList(DataSet ds)
        {
            List<Car> list;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(
                    dataRow => new Car
                    {
                        Id = dataRow.Field<int>("Id"),
                        Name = dataRow.Field<string>("Name"),
                        SerialNum = dataRow.Field<string>("SerialNum"),                       
                        Date = dataRow.Field<DateTime>("Date"),                        
                        IdClient = dataRow.Field<int>("ClientsId")
                    }).ToList();
            }
            catch
            {
                throw new DatabaseActionException("Cannot convert DataSet to List<Car>");
            }
            CarsTable table = new CarsTable();
            table.Data = list;
            return table;
        }

    }
}
