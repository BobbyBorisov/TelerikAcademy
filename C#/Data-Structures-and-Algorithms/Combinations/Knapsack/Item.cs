using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Item
    {
        public string ID;
        public int Weight;
        public int Price;
        public Item(string id, int weight, int value)
        {
            this.ID = id;
            this.Weight = weight;
            this.Price = value;
        }
        public override string ToString()
        {
            return "ID=" + ID + ",W=" + Weight + ",V=" + Price;
        }
    }
}
