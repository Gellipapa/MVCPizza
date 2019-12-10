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
        /// Feltölti teszt adatokkal az adatbázis megrendelo tábláját
        /// </summary>
        public void fillOrdersWithTestDataFromSQLCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                string query =
                    "INSERT INTO `pmegrendelo` (`id`, `name`,`address`,`par`) VALUES " +
                            " (1, 'Jancsi','Budapest',1500), " +
                            " (2, 'Maris','Kalocsa',1100), " +
                            " (3, 'Károly','Szeged',1800), " +
                            " (4, 'Béla','Baja' ,1450), " +
                            " (5, 'Anna','Debrecen' ,990); ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tesztadatok feltöltése sikertelen.");
            }
        }
    }
}
