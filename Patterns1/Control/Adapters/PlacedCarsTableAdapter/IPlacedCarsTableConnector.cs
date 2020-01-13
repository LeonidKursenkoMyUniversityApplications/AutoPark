using AutoParking.Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Control.Adapters.PlacedCarsTableAdapter
{
    public interface IPlacedCarsTableConnector
    {
        void Update(PlacedCar placedCar);
        void Delete(int id);
        void Insert(PlacedCar placedCar);
        PlacedCarsTable ReadDataFromDB();
    }
}
