using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TobbformosPizzaAlkalmazasEgyTabla.Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace TobbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class RepositoryDatabaseTableMegrendelo
    {
        /// <summary>
        /// Adatok feltöltése litából vagy adatbázisból
        /// </summary>
        /// <returns></returns>
        public List<Megrendelo2> getOrdersFromDatabaseTable()
        {
            List<Megrendelo2> orders = new List<Megrendelo2>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = Megrendelo2.getSQLCommandGetAllRecord();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr["name"].ToString();
                    string address = dr["address"].ToString();
                    bool goodResult = false;
                    int id = -1;
                    goodResult = int.TryParse(dr["id"].ToString(), out id);
                    if (goodResult)
                    {
                        int price = -1;
                        goodResult = int.TryParse(dr["price"].ToString(), out price);
                        if (goodResult)
                        {
                            Megrendelo2 m = new Megrendelo2(id, name,address, price);
                            orders.Add(m);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Megrendelők beolvasása az adatbázisból nem sikerült!");
            }
            return orders;
        }
        /// <summary>
        /// Megrendelo törlése az adatbázisból
        /// </summary>
        /// <param name="id"></param>
        public void deleteOrderFromDatabase(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "DELETE FROM pmegrendelo WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(id + " idéjű megrendelő törlése nem sikerült.");
                throw new RepositoryException("Sikertelen törlés az adatbázisból.");
            }
        }
        /// <summary>
        /// Frissiti a megrendelok tábla recordjait az adatbázisban
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modified"></param>
        public void updateMegrendeloInDatabase(int id, Megrendelo2 modified)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = modified.getUpdate(id);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(id + " idéjű megrendelő módosítása nem sikerült.");
                throw new RepositoryException("Sikertelen módosítás az adatbázisból.");
            }
        }
        /// <summary>
        /// Új megrendelő hozzáadása az adatbázisban
        /// </summary>
        /// <param name="ujMegrendelo"></param>
        public void insertMegrendeloToDatabase(Megrendelo2 ujMegrendelo)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = ujMegrendelo.getInsert();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                Debug.WriteLine(ujMegrendelo + " megrendelo beszúrása adatbázisba nem sikerült.");
                throw new RepositoryException("Sikertelen beszúrás az adatbázisból.");
            }
        }
    }
}
