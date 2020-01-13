using AutoParking.Control.Adapters.PlacedCarsTableAdapter;
using AutoParking.Entity.Tables;
using Patterns1.Control;
using Patterns1.Control.Adapters.CarsTableAdapter;
using Patterns1.Control.Adapters.ClientsTableAdapter;
using Patterns1.Control.Adapters.PlacesTableAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Entity
{
    public class AutoParkingDb
    {
        private static AutoParkingDb instance;
        public PlacesTable PlacesTable { get; set; }
        public PlacedCarsTable PlacedCarsTable { get; set; }

        public ClientsTable ClientsTable { get; set; }

        //public AdministratorsTable AdministratorsTable { get; set; }

        public CarsTable CarsTable { get; set; }

        private AutoParkingDb()
        {
            Init();
        }


        public static AutoParkingDb GetInstance()
        {
            if (instance == null)
                instance = new AutoParkingDb();
            instance.Init();
            return instance;
        }
       
        private void Init()
        {
            FillPlacesTable();
            FillPlacedCarsTable();
            FillClientsTable();
            FillCarsTable();
            //AdministratorsTable = new AdministratorsTable();
        }

        public void FillPlacesTable()
        {           
            // correct Polymorphism and Protected Variations using
            IPlacesTableConnector iPlacesTableConnector = PlacesTableMySqlConnector.GetInstance();
            PlacesTable = iPlacesTableConnector.ReadDataFromDB();
            PlacesTable.SetConnector(iPlacesTableConnector);      
        }

        public void FillPlacedCarsTable()
        {
            // correct Polymorphism and Protected Variations using
            IPlacedCarsTableConnector iPlacedCarsTableConnector = PlacedCarsTableMySqlConnector.GetInstance();
            PlacedCarsTable = iPlacedCarsTableConnector.ReadDataFromDB();
            PlacedCarsTable.SetConnector(iPlacedCarsTableConnector);
        }

        public void FillClientsTable()
        {            
            // correct Polymorphism and Protected Variations using
            IClientsTableConnector iClientsTableConnector = ClientsTableMySqlConnector.GetInstance();
            ClientsTable = iClientsTableConnector.ReadDataFromDB();
            ClientsTable.SetConnector(iClientsTableConnector);
        }

        public void FillCarsTable()
        {
            ICarsTableConnector iCarsTableConnector = CarsTableMySqlConnector.GetInstance();
            CarsTable = iCarsTableConnector.ReadDataFromDB();
            CarsTable.SetConnector(iCarsTableConnector);
        }

        //public IEnumerable<Car> GetCars()
        //{
        //    return CarsTable.Data;
        //}

        //public IEnumerable<Client> GetClients()
        //{
        //    return ClientsTable.Data;
        //}
    }
}
