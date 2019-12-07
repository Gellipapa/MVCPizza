using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobbbformosPizzaAlkalmazasEgyTabla.model
{
    class Megrendelo
    {
        private int id;
        private string name;
        private string address;
        private int price;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="price"></param>
        public Megrendelo(int id,string name,string address,int price)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Price = price;
        }
        /// <summary>
        /// GETTEREK ÉS SETTEREK
        /// </summary>
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int Price { get => price; set => price = value; }

        /// <summary>
        /// String paraméterű konstruktor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Megrendelo(int id, string name,string address, string price)
        {
            this.id = id;
            if (!isValidName(name))
                throw new ModelMegrendeloNotValidNameException("A megrendelő neve nem megfelelő!");

            if (!isValidName(address))
                throw new ModelMegrendeloNotValidNameException("A megrendelő címe nem megfelelő!");

            if (!isValidPrice(price))
                throw new ModelMegrendeloNotValidPriceException("A megrendelt pizza ára nem megfelelő!");
            this.name = name;
            this.price = Convert.ToInt32(price);
        }
        /// <summary>
        /// Price string validálás metódus
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private bool isValidPrice(string price)
        {
            int eredmeny = 0;
            if (int.TryParse(price, out eredmeny))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Name és Adress validálása
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool isValidName(string name)
        {
            if (name == string.Empty)
                return false;
            if (!char.IsUpper(name.ElementAt(0)))
                return false;
            for (int i = 1; i < name.Length; i = i + 1)
                if (
                    !char.IsLetter(name.ElementAt(i))
                        &&
                    (!char.IsWhiteSpace(name.ElementAt(i)))

                    )
                    return false;
            return true;
        }
        /// <summary>
        /// Frissitési metódus
        /// </summary>
        /// <param name="modified"></param>
        public void update(Megrendelo modified)
        {
            this.name = modified.name;
            this.address = modified.address;
            this.price = modified.price;
        }
    }
}
