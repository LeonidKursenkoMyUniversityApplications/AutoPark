// File:    Terminal.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 17:54:01
// Purpose: Definition of Class Terminal
//using Patterns1.Classes;
using System;

public class Terminal
{
    private static Terminal instance;
    public PlacesTable PlacesTable { get; set; }

    public ClientsTable ClientsTable { get; set; }

    public AdministratorsTable AdministratorsTable { get; set; }

    public ControlCar ControlCar { get; private set; }

    public CarsTable CarsTable { get; set; }

    //public Car Car {get; set;}

    private Terminal()
    {
        PlacesTable = new PlacesTable();
        ClientsTable = new ClientsTable();
        AdministratorsTable = new AdministratorsTable();        
        CarsTable = new CarsTable();
    }

    public static Terminal GetInstance(ControlCar controlCar)
    {
        if (instance == null)
            instance = new Terminal()
            {
                //ControlCar = ControlCar.GetInstance(null)
                ControlCar = controlCar
            };

        return instance;
    }
    #region Misha and Vitalik
    public void FillPlacesTable()
    {
        PlacesTable = PlacesTableConnector.GetInstance().ReadDataFromDB();
    }

    public void FillClientTable()
    {
        ClientsTable = ClientTableConnector.GetInstance().ReadDataFromDB();
    }

    // not correct
    public bool IsFree2()
    {
        foreach (var place in PlacesTable.Data)
        {
            if (place.IsAvailable == true) return true;
        }
        return false;
    }

    // correct
    public bool IsFree()
    {
        return PlacesTable.IsFree();
    }

    // not correct
    public Place FindFree2()
    {
        foreach (var place in PlacesTable.Data)
        {
            if (place.IsAvailable == true) return place;
        }
        return null;
    }

    // correct
    public Place FindFree()
    {
        return PlacesTable.FindFreePlace();
    }
    #endregion

    public void Run()
    {
        FillPlacesTable();
        FillClientTable();
        ControlCar.InputCar();
        ControlCar.OutputCar();
    }

    public void OnInputCarUpdate()
    {
        PlacesTable.Update(FindFree());
        CarsTable.Insert(ControlCar.Car);
    }

    public void OnOutputCarUpdate()
    {
        PlacesTable.Update(PlacesTable.FindPlace(ControlCar.Car.IdPlace));
        CarsTable.Delete(ControlCar.Car.Id);
    }

   
   
    public bool Registration(Client client)
    {
        return ClientsTable.Insert(client);
    }
   
    public bool Identification(Client client)
    {
        FillClientTable();
        for (int i = 0; i < ClientsTable.GetClients().Length; i++)
        {
            if (ClientsTable.GetClients()[i].Password == client.Password)
            {
                return true;
            }
        }
        return false;
    }



    #region not released
    public void Exit()
    {
        throw new NotImplementedException();
    }

    #endregion
}