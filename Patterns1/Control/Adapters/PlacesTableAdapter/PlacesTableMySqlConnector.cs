using Patterns1.Control.Adapters;
using Patterns1.Control.Adapters.PlacesTableAdapter;
using StockControl.Controllers;
using StockControl.Exceptions;
using System.Data;

public class PlacesTableMySqlConnector : TableConnector, IPlacesTableConnector
{
    private static PlacesTableMySqlConnector instance;
    private PlacesTableMySqlConnector() : base()
    {

    }

    public static PlacesTableMySqlConnector GetInstance()
    {
        if (instance == null)
            instance = new PlacesTableMySqlConnector();

        return instance;
    }
    public void Update(Place place)
    {
        string isAvailable = (place.IsAvailable) ? "1" : "0";
        string querry = "Update places set IsAvailable = '" + isAvailable +                   
                    "' where Id = '" + place.Id + "';";
        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Update place");
        }
    }

    public void Delete(int id)
    {
        string querry = "Delete from places where Id = '" + id + "';";

        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Delete place");
        }
    }

    public void Insert(Place place)
    {
        string isAvailable = (place.IsAvailable) ? "1" : "0";
        string querry = "Insert into places (Id, IsAvailable) values ('" + place.Id +                    
                     "', '" + isAvailable + "');";
        try
        {
            Querry(querry);
        }
        catch
        {
            throw new DatabaseActionException("Error, cannot Insert place");
        }
    }

    public PlacesTable ReadDataFromDB()
    {
        
        DataSet ds = SelectQuerry("Select * From places");
        PlacesTable pt = Converter.ToPlaceList(ds);

        return pt;
    }

   
}