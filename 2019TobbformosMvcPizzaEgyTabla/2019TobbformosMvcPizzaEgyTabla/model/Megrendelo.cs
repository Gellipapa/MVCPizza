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
        //KONSTRUKTOR
        public Megrendelo(int id,string name,string address,int price)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Price = price;
        
        }
        //GETTEREK ÉS A SETTEREK
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int Price { get => price; set => price = value; }

        public Megrendelo(int id, string name,string address, string price)
        {
            this.id = id;
            if (!isValidName(name))
                throw new ModelMegrendeloNotValidNameException("A megrendelő neve nem megfelelő!");
            if (!isValidName(address))
                throw new ModelMegrendeloNotValidAddressException("A megrendelő címe nem megfelelő formátumú.");
            if (!isValidPrice(price))
                throw new ModelMegrendeloNotValidPriceException("A megrendelt pizza ára nem megfelelő!");
            this.name = name;
            this.address = address;
            this.price = Convert.ToInt32(price);
        }

        /// <summary>
        /// Name és Address string vizsgálata
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
        /// Price string vizsgálata
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
    }
}
