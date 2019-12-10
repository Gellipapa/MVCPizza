using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Model
{
    partial class Megrendelo2
    {
        /// <summary>
        /// Megrendelő INSERT IN DATABASE
        /// </summary>
        /// <returns></returns>
        public string getInsert()
        {
            return
            "INSERT INTO `pmegrendelo` (`id`, `name`, `address`, `price`)"
            + "VALUES('" +
            id +
            "', '" +
            getName() +
            "','" +
            getAddress() +
            "', '" +
            getPrice() +
            "');";
        }

        public string getUpdate(int id)
        {
            return
            //"UPDATE `ppizza` SET `pnev` = '" +
            //getName() +
            //"', `par` = '" +
            //getPrice() +
            //"' WHERE `ppizza`.`pazon` = " +
            //id;

            "UPDATE `pmegrendelo` SET `name` = '" +
                getName() +
                "', address ='" +
                getAddress() +
                "', price='"+
                getPrice()+
                "'WHERE pmegrendelo.id=" + id;
        }

        public static string getSQLCommandDeleteAllRecord()
        {
            return "DELETE FROM pmegrendelo";
        }

        public static string getSQLCommandGetAllRecord()
        {
            return "SELECT * FROM pmegrendelo";
        }
    }
}
