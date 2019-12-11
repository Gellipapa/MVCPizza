using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TobbformosPizzaAlkalmazasEgyTabla.Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using _2019TobbformosMvcPizzaEgyTabla.model;

namespace TobbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class RepositoryDatabaseTableMegrendelo
    {
       private readonly string connectionStringCreate;
        private readonly string connectionString;

        /// <summary>
        /// Konstruktor - kezdőértékadások
        /// </summary>
        public RepositoryDatabaseTableMegrendelo()
        {
            ConnectionString conn = new ConnectionString();
            connectionStringCreate = conn.ConnectionStringCreate();
            connectionString = conn.getConnectionString();
        }

        /// <summary>
        /// megrendelő tábla létrehozzása
        /// </summary>
        public void createTableMegrendelo()
        {
            string queryUSE = "USE csarp;";
            string queryCreateTable =
                "CREATE TABLE `pmegrendelo` ( " +
                "   `id` int(3) NOT NULL DEFAULT '0', " +
                "   `name` varchar(15) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', " +
                "   `address` varchar(15) COLLATE latin2_hungarian_ci NOT NULL DEFAULT '', "+
                "   `price` int(4) NOT NULL DEFAULT '0' " +
            ")ENGINE = InnoDB; ";
            string queryPrimaryKey =
                "ALTER TABLE `pmegrendelo`  ADD PRIMARY KEY(`id`); ";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmdUSE = new MySqlCommand(queryUSE, connection);
                cmdUSE.ExecuteNonQuery();
                MySqlCommand cmdCreateTable = new MySqlCommand(queryCreateTable, connection);
                cmdCreateTable.ExecuteNonQuery();
                MySqlCommand cmdPrimaryKey = new MySqlCommand(queryPrimaryKey, connection);
                cmdPrimaryKey.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla lérehozása sikertelen.");
            }
        }

        /// <summary>
        /// megrendelo tabla törlése
        /// </summary>
        public void deleteTableMegrendelo()
        {
            string query =
                "USE csarp; " +
                "DROP TABLE pmegrendelo;";

            MySqlConnection connection =
                new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new RepositoryException("Tábla törlése nem sikerült.");
            }
        }
    }
}
