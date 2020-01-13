using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Adapters.ClientsTableAdapter
{
    public interface IClientsTableConnector
    {
        void Update(Client client);

        void Delete(int id);

        void Insert(Client client);

        ClientsTable ReadDataFromDB();
      
    }
}
