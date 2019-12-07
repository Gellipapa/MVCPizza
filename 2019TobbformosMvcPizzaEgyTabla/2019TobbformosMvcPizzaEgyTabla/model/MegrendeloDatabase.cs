using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
     class MegrendeloDatabase
    {

        public string getInsert()
        {
            return
                "INSERT INTO `ppizza` (`pazon`, `pnev`, `par`) " +
                "VALUES ('" +
                 id+
                "', '" +
                getName() +
                "', '" +
                getPrice() +
                "');";
        }


    }
}
