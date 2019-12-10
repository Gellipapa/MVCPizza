using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TobbformosPizzaAlkalmazasEgyTabla.Model;

namespace TobbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class Repository
    {
        public Repository()
        {
            pizzas = new List<Pizza>();
            orders = new List<Megrendelo2>();
        }        
    }
}
