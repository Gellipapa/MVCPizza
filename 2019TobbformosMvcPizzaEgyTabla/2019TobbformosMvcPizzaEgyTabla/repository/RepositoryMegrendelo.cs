using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using TobbformosPizzaAlkalmazasEgyTabla.Model;

namespace TobbformosPizzaAlkalmazasEgyTabla.Repository
{
    partial class Repository
    {
        //megrendelo listája
        List<Megrendelo2> orders;

        //megrendelo get lista
        public List<Megrendelo2> getOrders()
        {
            return orders;
        }
        //megrendelo set lista
        public void setOrders(List<Megrendelo2>orders)
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
        /// <summary>
        /// Megrendeloket törli a listából
        /// </summary>
        /// <param name="id"></param>
        public void deleteMegrendeloFromList(int id)
        {
            Megrendelo2 m = orders.Find(x => x.getId() == id);
            if (m != null)
                orders.Remove(m);
            else
                throw new RepositoryExceptionCantDelete("A megrendelőt nem lehetett törölni.");
        }

        /// <summary>
        /// Megrendelőt add a listához
        /// </summary>
        /// <param name="ujPizza"></param>
        public void addMegrendeloToList(Megrendelo2 Ujmegrendelo)
        {
            try
            {
                orders.Add(Ujmegrendelo);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionCantAdd("A megrendelő hozzáadása nem sikerült");
            }
        }


        /// <summary>
        /// Frissiti a megrendelo listát
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modified"></param>
        public void updateMegrendeloInList(int id, Megrendelo2 modified)
        {
            Megrendelo2 m = orders.Find(x => x.getId() == id);
            if (m != null)
                m.update(modified);
            else
                throw new RepositoryExceptionCantModified("A megrendelő módosítása nem sikerült");
        }

        /// <summary>
        /// get id metodus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Megrendelo2 getMegrendelo(int id)
        {
            return orders.Find(x => x.getId() == id);
        }
        /// <summary>
        /// Következő id adása
        /// </summary>
        /// <returns></returns>
        public int getNextMegrendeloId()
        {
            if (orders.Count == 0)
                return 1;
            else
                return orders.Max(x => x.getId()) + 1;
        }




    }
}
