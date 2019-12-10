using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Model
{
    partial class Megrendelo2
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
        public Megrendelo2(int id, string name, string address, int price)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.price = price;

        }
        /// <summary>
        /// string konstruktor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="price"></param>
        public Megrendelo2(int id, string name,string address, string price)
        {
            this.id = id;
            if (!isValidName(name))
                throw new ModelMegrendeloNotValidNameException("A megrendelő neve nem megfelelő!");

            if (!isValidAddress(address))
                throw new ModelMegrendeloNotValidAddressException("A megrendelő címe nem megfelelő!");

            if (!isValidPrice(price))
                throw new ModelMegrendeloNotValidPriceException("A megrendelt pizza ára nem megfelelő!");
            this.name = name;
            this.address = address;
            this.price = Convert.ToInt32(price);
        }
        /// <summary>
        /// frissiti a modosítást
        /// </summary>
        /// <param name="modified"></param>
        public void update(Megrendelo2 modified)
        {
            this.name = modified.getName();
            this.address = modified.getAddress();
            this.price = modified.getPrice();
        }
        /// <summary>
        /// Price validálás
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
        /// Name validálás
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
        /// Address validálás
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool isValidAddress(string address)
        {
            if (address == string.Empty)
                return false;
            if (!char.IsUpper(address.ElementAt(0)))
                return false;
            for (int i = 1; i < address.Length; i = i + 1)
                if (
                    !char.IsLetter(address.ElementAt(i))
                        &&
                    (!char.IsWhiteSpace(address.ElementAt(i)))

                    )
                    return false;
            return true;
        }
        /// <summary>
        /// GETTEREK és SETTEREK
        /// </summary>
        /// <param name="id"></param>
        public void setID(int id)
        {
            this.id = id;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }

        public string getAddress()
        {
            return address;
        }
        public int getPrice()
        {
            return price;
        }


    }
}
