// File:    ClientsTable.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:23:16
// Purpose: Definition of Class ClientsTable

using Patterns1.Control.Adapters.ClientsTableAdapter;
using Patterns1.Exceptions;
using StockControl;
using StockControl.Exceptions;
using StockControl.Validates;
using System;
using System.Collections.Generic;
using System.Linq;

public class ClientsTable
{
   //private ClientTableConnector ClientTableConnector { get; set; }

    public List<Client> Data { get; set; }
    private IClientsTableConnector iClientsTableConnector;

    public void SetConnector(IClientsTableConnector iClientsConnector)
    {
        iClientsTableConnector = iClientsConnector;
    }

    public List<Client> GetClients()
    {
        return Data;
    }
   
   public void Insert(string name, string password, string passportId)
   {
        Client client = new Client();
        int id = Data.Max(x => x.Id) + 1;
        if (Data.Exists(x => x.Name == name) == true) throw new RegistrationException("This login is already exists");
        try
        {
            client.Id = id;            
            client.Name = ValidateField.ValidateString(name);
            client.PassportId = ValidateField.ValidateString(passportId);
            client.Password = ValidateField.ValidateString(password);
            client.RegistrationDate = DateTime.Now;
            client.IsBlock = false;
        }
        catch(InputException ex)
        {
            throw ex;
        }

        try
        {
            iClientsTableConnector.Insert(client);
        }
        catch(DatabaseActionException ex)
        {
            throw ex;
        }
   }
   
   public void Update(int oldId, string name, string password, string passportId)
   {
        Client client = Data.First(x => x.Id == oldId);
        if (Data.Exists(x => (x.Name == name) && (x.Id != oldId)) == true)
            throw new RegistrationException("This login is already exists");
        try
        {
            client.Name = ValidateField.ValidateString(name);
            client.PassportId = ValidateField.ValidateString(passportId);
            client.Password = ValidateField.ValidateString(password);
        }
        catch (InputException ex)
        {
            throw ex;
        }

        try
        {
            iClientsTableConnector.Update(client);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
   }

    public void Update(string name, bool isBlock)
    {
        try
        {
            name = ValidateField.ValidateString(name);            
        }
        catch (InputException ex)
        {
            throw ex;
        }
        Client client = Data.First(x => x.Name == name);
        if (client == null) throw new InputException("Unknown client");
        client.IsBlock = isBlock;

        try
        {
            iClientsTableConnector.Update(client);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
    }

    public void Delete(int id)
   {        
        try
        {
            iClientsTableConnector.Delete(id);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
    }

    public Client Find(string name, string password)
    {
        try
        {
            return Data.First(x => (x.Name == name) && (x.Password == password));
        }
        catch
        {
            return null;
        }
    }

}