using MySql.Data.MySqlClient;
using Patterns1.Control.Adapters;
using Patterns1.Control.Adapters.ClientsTableAdapter;
using StockControl.Controllers;
using StockControl.Exceptions;
using System;
using System.Data;

public class ClientsTableMySqlConnector : TableConnector, IClientsTableConnector
{
    private static ClientsTableMySqlConnector instance;
    
    private ClientsTableMySqlConnector() : base()
    {
        
    }

    public static ClientsTableMySqlConnector GetInstance()
    {
        if (instance == null)
            instance = new ClientsTableMySqlConnector();

        return instance;
    }

    
    public void Update(Client client)
    {
        string isBlock = (client.IsBlock) ? "1" : "0";
        string querry = "Update clients set Name = '" + client.Name +
                    "', PassportId = '" + client.PassportId +                    
                    "', Password = '" + client.Password +
                    "', IsBlock = '" + isBlock +
                    "' where Id = '" + client.Id + "';";
        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Update client");
        }
    }

    public void Delete(int id)
    {
        string querry = "Delete from clients where Id = '" + id + "';";

        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Delete client");
        }
    }

    public void Insert(Client client)
    {
        string isBlock = (client.IsBlock) ? "1" : "0";
        string date = client.RegistrationDate.ToString("yyyy-MM-dd");
        string querry = "Insert into clients (Id, Name, PassportId, RegistrationDate, Password, IsBlock) values ('" + client.Id +
                    "', '" + client.Name +
                    "', '" + client.PassportId +
                    "', '" + date +
                    "', '" + client.Password +
                    "', '" + isBlock + "');";
        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Insert client");
        }
        
    }

    public ClientsTable ReadDataFromDB()
    {        
        //ct.Clients = Init();
        DataSet ds = SelectQuerry("Select * From clients");
        ClientsTable ct = Converter.ToClientList(ds);

        return ct;
    }

    // only simulation, read from db
    //private Client[] Init()
    //{
    //    return new Client[]
    //    {
    //        new Client
    //        {
    //            Id = 1,
    //            Name = "Client1",
    //            PassportId = "h43h4u4",
    //            Password = "123",
    //            RegistrationDate = new System.DateTime(2016, 4, 2)
    //        },
    //        new Client
    //        {
    //            Id = 2,
    //            Name = "Client2",
    //            PassportId = "hrbthr4u4",
    //            Password = "1234",
    //            RegistrationDate = new System.DateTime(2016, 2, 2)
    //        },
    //        new Client
    //        {
    //            Id = 3,
    //            Name = "Client3",
    //            PassportId = "h43h4u4",
    //            Password = "12345",
    //            RegistrationDate = new System.DateTime(2016, 1, 2)
    //        }

    //    };
    //}
}