// File:    PlacesTable.cs
// Author:  Леонид
// Created: 23 октября 2016 г. 13:37:56
// Purpose: Definition of Class PlacesTable

//using Patterns1.Classes;
using System;

public class PlacesTable
{
   //private PlacesTableConnector PlacesTableConnector { get; set; }

   public Place[] Data { get; set; }
   
   public void Insert(Place place)
   {
        PlacesTableConnector.GetInstance().Insert(place);
   }
   
   public void Update(Place place)
   {
        PlacesTableConnector.GetInstance().Update(place);
   }
   
   public void Delete(int id)
   {
        PlacesTableConnector.GetInstance().Delete(id);
   }
   
   public PlacesTable Find(string condition)
   {
      throw new NotImplementedException();
   }

    public Place FindPlace(int id)
    {
        return new Place();//throw new NotImplementedException();
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