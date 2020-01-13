using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Adapters.CarsTableAdapter
{
    public interface ICarsTableConnector
    {
        void Update(Car car);

        void Delete(int id);

        void Insert(Car car);

        CarsTable ReadDataFromDB();
    }
}
