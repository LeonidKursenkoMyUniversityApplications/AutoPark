using Patterns1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Handler
{
    public class ClientBlockHandler
    {
        private static ClientBlockHandler instance;

        public Dictionary<string, int> Clients { get; set; }

        private ClientBlockHandler()
        {
            Clients = new Dictionary<string, int>();
        }

        public static ClientBlockHandler GetInstance()
        {
            if(instance == null)
            {
                instance = new ClientBlockHandler();
            }
            return instance;
        }

        public void Add(string name)
        {
            KeyValuePair<string, int> client;
            try
            {
                client = Clients.First(x => x.Key == name);
            }
            catch
            {
                client = new KeyValuePair<string, int>(null, 0);
            }
            if (client.Key == null)
            {
                Clients.Add(name, 1);
            }
            else
            {
                Clients[name]++;
            }
            if(Clients[name] >= 3)
            {
                Block(name);
            }
        }

        private void Block(string name)
        {
            try
            {
                AutoParkingDb.GetInstance().ClientsTable.Update(name, true);
            }
            catch
            {
                // user not found
            }
        }

        public void Refresh(string name)
        {
            Clients.Remove(name);
        }
    }
}
