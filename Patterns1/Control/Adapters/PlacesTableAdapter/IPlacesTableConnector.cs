using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Adapters.PlacesTableAdapter
{
    public interface IPlacesTableConnector
    {
        void Update(Place place);
        void Delete(int id);
        void Insert(Place place);
        PlacesTable ReadDataFromDB();  
    }
}
