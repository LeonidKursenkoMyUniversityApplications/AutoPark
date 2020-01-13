// File:    CarsTable.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:37:48
// Purpose: Definition of Class CarsTable

using Patterns1.Control;
using Patterns1.Control.Adapters.CarsTableAdapter;
using StockControl;
using StockControl.Exceptions;
using StockControl.Validates;
using System;
using System.Collections.Generic;
using System.Linq;

public class CarsTable
{
  
    public List<Car> Data { get; set; }
    private ICarsTableConnector iCarsTableConnector;

    public void SetConnector(ICarsTableConnector iCarsConnector)
    {
        iCarsTableConnector = iCarsConnector;
    }
    
    public List<Car> GetCars()
    {
        return Data;
    }

    public void Insert(string name, string serialNum, Client client)
    {
        Car car = new Car();
        int id = Data.Max(x => x.Id) + 1;
        if (Data.Exists(x => x.SerialNum == serialNum) == true)
            throw new InputException("This serial number is already exists");
        try
        {
            car.Id = id;
            car.Name = ValidateField.ValidateString(name);
            car.SerialNum = ValidateField.ValidateString(serialNum);
            car.Date = DateTime.Now;
            car.IdClient = client.Id;
        }
        catch (InputException ex)
        {
            throw ex;
        }

        try
        {
            CarsTableMySqlConnector.GetInstance().Insert(car);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
    }

    public void Insert(Car car)
    {        
        try
        {
            iCarsTableConnector.Insert(car);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
    }

    public void Update(int oldId, string name, string serialNum)
    {
        Car car = Data.First(x => x.Id == oldId);
        if (Data.Exists(x => (x.SerialNum == serialNum) && (x.Id != oldId)) == true)
            throw new InputException("This serial number is already exists");
        try
        {
            car.Name = ValidateField.ValidateString(name);
            car.SerialNum = ValidateField.ValidateString(serialNum);
        }
        catch (InputException ex)
        {
            throw ex;
        }

        try
        {
            iCarsTableConnector.Update(car);
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
            iCarsTableConnector.Delete(id);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
    }
   
    //public CarsTable Find(string condition)
    //{
    //    throw new NotImplementedException();
    //}

}