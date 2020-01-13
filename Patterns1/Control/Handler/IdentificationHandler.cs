using Patterns1.Entity;
using Patterns1.Entity.Other;
using Patterns1.Exceptions;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Handler
{
    public class IdentificationHandler
    {
        public static void Identification(string name, string password)
        {
            Client client;
            var blockHandler = ClientBlockHandler.GetInstance();
            try
            {
                // Do identification
                client = AutoParkingDb.GetInstance().ClientsTable.Find(name, password);
                if (client == null)
                {
                    // auto increment of unsucceful attempts
                    blockHandler.Add(name);
                    throw new IdentificationException("Incorrect login or password");
                }
                else
                {
                    // successful identification                    
                    // set unsuccessful attempts to 0
                    blockHandler.Refresh(name);                   
                }
                if(client.IsBlock == true) throw new IdentificationException("Your account has been blocked");
                SystemUser.GetInstance().Client = client;
            }
            // Something is wrong
            catch(IdentificationException ex)
            {
                throw ex;
            }
            catch (DatabaseActionException ex)
            {
                throw ex;
            }
        }

        
    }
}
