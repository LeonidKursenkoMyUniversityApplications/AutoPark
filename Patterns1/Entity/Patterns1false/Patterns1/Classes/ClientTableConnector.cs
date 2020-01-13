public class ClientTableConnector
{
    private static ClientTableConnector instance;
    private ClientTableConnector()
    {
       
    }

    public static ClientTableConnector GetInstance()
    {
        if (instance == null)
            instance = new ClientTableConnector();

        return instance;
    }
    public bool Update(Client client)
    {
        // not released
        return true;
    }

    public bool Delete(int id)
    {
        // not released
        return true;
    }

    public bool Insert(Client client)
    {
        // not released
        return true;
    }

    public ClientsTable ReadDataFromDB()
    {
        // not released
        ClientsTable ct = new ClientsTable();
        ct.Clients = new Client[] { new Client(), new Client() };
        return ct;
    }
}