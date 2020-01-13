// File:    PlacesTable.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:37:56
// Purpose: Definition of Class PlacesTable

//using Patterns1.Classes;
using Patterns1.Control.Adapters.PlacesTableAdapter;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

public class PlacesTable
{
   //private PlacesTableConnector PlacesTableConnector { get; set; }

    public List<Place> Data { get; set; }
    private IPlacesTableConnector iPlacesTableConnector;

    public void SetConnector(IPlacesTableConnector iPlacesConnector)
    {
        iPlacesTableConnector = iPlacesConnector;
    }

    public List<Place> GetPlaces()
    {
        return Data;
    }

    public void Insert()
   {
        Place place = new Place();
        int id = Data.Max(x => x.Id) + 1;        
        place.Id = id;            
        place.IsAvailable = true;        

        try
        {
            iPlacesTableConnector.Insert(place);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }
   }
   
   public void Update(int oldId, bool isAvailable)
   {
        Place place = Data.First(x => x.Id == oldId);
        place.IsAvailable = isAvailable;   
        try
        {
            Update(place);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }       
   }

    public void Update(Place place)
    {        
        try
        {
            iPlacesTableConnector.Update(place);
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
            iPlacesTableConnector.Delete(id);
        }
        catch (DatabaseActionException ex)
        {
            throw ex;
        }        
   }
  
    public Place FindPlace(int id)
    {
        var place = Data.First(x => x.Id == id);
        return place;
    }

    public bool IsFree()
    {
        foreach (var place in Data)
        {
            if (place.IsAvailable == true) return true;
        }
        return false;
    }

    public Place FindFreePlace()
    {
        foreach (var place in Data)
        {
            if (place.IsAvailable == true) return place;
        }
        return null;
    }
}