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
       /// <summary>
       /// lista létrehozása
       /// </summary>
        List<Pizza> pizzas;

        public List<Pizza> getPizzas()
        {
            return pizzas;
        }

        public void setPizzas(List<Pizza> pizzas)
        {
            this.pizzas = pizzas;
        }


        /// <summary>
        /// Listából a pizzákat Datatablebe rendezzi
        /// </summary>
        /// <returns></returns>
        public DataTable getPizzaDataTableFromList()
        {
            DataTable pizzaDT = new DataTable();
            pizzaDT.Columns.Add("azon", typeof(int));
            pizzaDT.Columns.Add("nev", typeof(string));
            pizzaDT.Columns.Add("ar", typeof(int));
            foreach (Pizza p in pizzas)
            {
                pizzaDT.Rows.Add(p.getId(), p.getNeme(), p.getPrice());
            }
            return pizzaDT;
        }
        /// <summary>
        /// Feltölt a pizzák listáját a datatablebe
        /// </summary>
        /// <param name="pizzadt"></param>
        private void fillPizzaListFromDataTable(DataTable pizzadt)
        {
            foreach (DataRow row in pizzadt.Rows)
            {
                int azon = Convert.ToInt32(row[0]);
                string nev = row[1].ToString();
                int ar = Convert.ToInt32(row[2]);
                Pizza p = new Pizza(azon, nev, ar);
                pizzas.Add(p);
            }
        }
        /// <summary>
        /// Pizzát töröl a listából ID alapján
        /// </summary>
        /// <param name="id"></param>
        public void deletePizzaFromList(int id)
        {
            Pizza p = pizzas.Find(x => x.getId() == id);
            if (p != null)
                pizzas.Remove(p);
            else
                throw new RepositoryExceptionCantDelete("A pizzát nem lehetett törölni.");
        }
        /// <summary>
        /// Frissiti a pizák listáját ID alapján
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modified"></param>
        public void updatePizzaInList(int id,Pizza modified)
        {
            Pizza p = pizzas.Find(x => x.getId() == id);
            if (p != null)
                p.update(modified);
            else
                throw new RepositoryExceptionCantModified("A pizza módosítása nem sikerült");
        }
        /// <summary>
        /// Új pizza hozzáadása 
        /// </summary>
        /// <param name="ujPizza"></param>
        public void addPizzaToList(Pizza ujPizza)
        {
            try
            {
                pizzas.Add(ujPizza);
            }
            catch (Exception e)
            {
                throw new RepositoryExceptionCantAdd("A pizza hozzáadása nem sikerült");
            }
        }
        /// <summary>
        /// Pizzáknak ID get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pizza getPizza(int id)
        {
            return pizzas.Find(x => x.getId() == id);
        }
        /// <summary>
        /// A pizzák listából következő ID adja
        /// </summary>
        /// <returns></returns>
        public int getNextPizzaId()
        {
            if (pizzas.Count == 0)
                return 1;
            else
                return pizzas.Max(x => x.getId()) + 1;
        }
    }
}
