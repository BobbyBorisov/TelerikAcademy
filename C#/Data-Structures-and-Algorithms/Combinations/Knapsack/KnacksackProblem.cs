using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class KnapSackProblem
    {

        public List<Item> FindItemsToPack(List<Item> items, int capacity, out int totalValue)
        {

            int[,] price = new int[items.Count + 1, capacity + 1];
            bool[,] keep = new bool[items.Count + 1, capacity + 1];

            for (int i = 1; i <= items.Count; i++)
            {
                Item currentItem = items[i - 1];
                for (int space = 1; space <= capacity; space++)
                {
                    if (space >= currentItem.Weight)
                    {
                        int remainingSpace = space - currentItem.Weight;
                        int remainingSpaceValue = 0;
                        if (remainingSpace > 0)
                        {
                            remainingSpaceValue = price[i - 1, remainingSpace];
                        }
                        int currentItemTotalValue = currentItem.Price + remainingSpaceValue;
                        if (currentItemTotalValue > price[i - 1, space])
                        {
                            keep[i, space] = true;
                            price[i, space] = currentItemTotalValue;
                        }
                        else
                        {
                            keep[i, space] = false;
                            price[i, space] = price[i - 1, space];
                        }
                    }
                }
            }

            List<Item> itemsToBePacked = new List<Item>();

            int remainSpace = capacity;
            int item = items.Count;
            while (item > 0)
            {
                bool toBePacked = keep[item, remainSpace];
                if (toBePacked)
                {
                    itemsToBePacked.Add(items[item - 1]);
                    remainSpace = remainSpace - items[item - 1].Weight;
                }
                item--;
            }

            totalValue = price[items.Count, capacity];
            return itemsToBePacked;
        }
    }
}
