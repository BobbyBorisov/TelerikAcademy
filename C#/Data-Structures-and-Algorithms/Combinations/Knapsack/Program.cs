using System;
using System.Collections.Generic;

namespace Knapsack
{


    public class Program
    {
        static void Main(string[] args)
        {

            Item beer = new Item("beer", 3, 2);
            Item vodka = new Item("vodka", 8, 12);
            Item cheese = new Item("cheese", 4, 5);
            Item nuts = new Item("nuts", 1, 4);
            Item ham = new Item("ham", 2, 3);
            Item whiskey = new Item("whiskey", 8, 13);

            List<Item> items = new List<Item>();
            items.Add(beer);
            items.Add(vodka);
            items.Add(cheese);
            items.Add(nuts);
            items.Add(ham);
            items.Add(whiskey);
            int BagCapacity = 15;

            //List<Item> items = new List<Item>();
            //var BagCapacity = int.Parse(Console.ReadLine());
            //int numOfItems = int.Parse(Console.ReadLine());

            //for (var i = 0; i < numOfItems; i++) 
            //{
            //    var line = Console.ReadLine().Split(' ');
            //    var currentItem = new Item(line[0], int.Parse(line[1]), int.Parse(line[2]));
            //    items.Add(currentItem);
            //}

            KnapSackProblem problem = new KnapSackProblem();

            int totalValueOfItems = 0;
            List<Item> itemsToBePacked = problem.FindItemsToPack(items, BagCapacity, out totalValueOfItems);

            Console.WriteLine(totalValueOfItems);
            foreach (var item in itemsToBePacked)
            {
                Console.WriteLine(item.ID);
            }
        }

    }
}


  
