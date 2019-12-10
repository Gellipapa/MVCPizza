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
        /// <summary>
        /// Megrendelo DATATABLE
        /// </summary>
        /// <returns></returns>
        public DataTable getMegrendeloDataTableFromList()
        {
            DataTable megrendeloDT = new DataTable();
            megrendeloDT.Columns.Add("azon", typeof(int));
            megrendeloDT.Columns.Add("nev", typeof(string));
            megrendeloDT.Columns.Add("cím", typeof(string));
            megrendeloDT.Columns.Add("ar", typeof(int));

            foreach (Megrendelo2 o in orders)
            {
                megrendeloDT.Rows.Add(o.getId(), o.getName(),o.getAddress() ,o.getPrice());
            }

            return megrendeloDT;
        }
        /// <summary>
        /// Kitölti a DATATABLET
        /// </summary>
        /// <param name="megrendelodt"></param>
        private void fillMegrendeloListFromDataTable(DataTable megrendelodt)
        {
            foreach (DataRow row in megrendelodt.Rows)
            {
                int azon = Convert.ToInt32(row[0]);
                string nev = row[1].ToString();
                string address = row[2].ToString();
                int ar = Convert.ToInt32(row[3]);
                Megrendelo2 m = new Megrendelo2(azon, nev,address, ar);
                orders.Add(m);
            }
        }

    }
}
