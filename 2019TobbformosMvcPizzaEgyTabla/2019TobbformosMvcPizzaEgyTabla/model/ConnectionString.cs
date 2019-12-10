using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
    class ConnectionString
    {

        public string ConnectionStringCreate()
        {
            return
               "SERVER=\"localhost\";"
               + "DATABASE=\"test\";"
               + "UID=\"root\";"
               + "PASSWORD=\"\";"
               + "PORT=\"3306\";";
        }

        public string getConnectionString()
        {
            return
                "SERVER=\"localhost\";"
                + "DATABASE=\"csarp\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
        }



    }
}
