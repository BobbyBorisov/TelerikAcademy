using System;
using System.Linq;

namespace _11.DynamicDoubleLinkedList
{
    class DynamicDoubleLinkedListExample
    {
        static void Main()
        {
            var mylist = new DynamicDoubleLinkedList<int>();

            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(4);
            mylist.Add(5);
            mylist.RemoveByIndex(4);
            //mylist.RemoveByItem(2);
            //var found = mylist.IndexOf(4);
            //mylist.Insert(2, 69);
            //var newnode = mylist.GetElementByIndex(0);
            //var newArray = mylist.ToArray();
        }
    }
}
