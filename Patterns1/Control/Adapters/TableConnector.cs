using MySql.Data.MySqlClient;
using StockControl.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Control.Adapters
{
    public abstract class TableConnector
    {
        // connection string parametres
        protected string server;
        protected string port;
        protected string user;
        protected string password;
        protected string database;
        protected string connString;
        protected string charset;

        public TableConnector()
        {
            server = "localhost";
            port = "3306";
            user = "leo";
            password = "12op43HJ";
            database = "autoparking";
            charset = "utf8";
            connString = "server = " + server +
                "; user = " + user +
                "; database = " + database +
                "; port = " + port +
                "; password =" + password +
                "; charset =" + charset;
        }

        // Запит типу Select до бази даних
        protected DataSet SelectQuerry(string querry)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch
            {
                throw new DatabaseActionException("Виникла помилка при звернненні до БД");
            }
            conn.Close();
            return ds;
        }

        protected void Querry(string querry)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(querry, conn);

                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
            }
            catch
            {
                throw new DatabaseActionException("Виникла помилка при редагуанні запису з  БД");
            }
            conn.Close();
        }
    }
}
