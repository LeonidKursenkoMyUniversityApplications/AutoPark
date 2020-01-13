// File:    ClientsTable.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:23:16
// Purpose: Definition of Class ClientsTable

//using Patterns1.Classes;
using System;

public class ClientsTable
{
   //private ClientTableConnector ClientTableConnector { get; set; }

   public Client[] Clients { get; set; }

   public Client[] GetClients()
    {
        return Clients;
    }
   
   public bool Insert(Client client)
   {
        return ClientTableConnector.GetInstance().Insert(client);
   }
   
   public bool Update(Client client)
   {
        return ClientTableConnector.GetInstance().Update(client);
   }
   
   public bool Delete(int id)
   {
        return ClientTableConnector.GetInstance().Delete(id);
   }
   
   public ClientsTable Find(string condition)
   {
      throw new NotImplementedException();
   }

}