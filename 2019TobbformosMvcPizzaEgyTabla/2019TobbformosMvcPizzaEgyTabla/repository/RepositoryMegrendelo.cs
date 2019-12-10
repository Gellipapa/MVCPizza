using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using TobbbformosPizzaAlkalmazasEgyTabla.Model;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class Repository
    {
        //megrendelo listája
        List<Pizza> orders;

        //megrendelo get lista
        public List<Pizza> getOrders()
        {
            return orders;
        }
        //megrendelo set lista
        public void setOrders(List<Pizza>orders)
        {
            this.orders = orders;
        }

    }
}
