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
    }
}
