public class PlacesTableConnector
{
    private static PlacesTableConnector instance;
    private PlacesTableConnector()
    {

    }

    public static PlacesTableConnector GetInstance()
    {
        if (instance == null)
            instance = new PlacesTableConnector();

        return instance;
    }
    public bool Update(Place place)
    {
        // not released
        return true;
    }

    public bool Delete(int id)
    {
        // not released
        return true;
    }

    public bool Insert(Place place)
    {
        // not released
        return true;
    }

    public PlacesTable ReadDataFromDB()
    {
        // not released
        PlacesTable pt = new PlacesTable();
        pt.Data = new Place[]  { new Place(), new Place()};
        return pt;
    }
}