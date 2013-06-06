using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTable
{
    public class HashTable<T,V>
    {
        private LinkedList<KeyValuePair<T,V>>[] table;
        private float loadFactor;
        private int initialCapacity;

        public HashTable(int capacity, int loadFactor) 
        {
            this.loadFactor = loadFactor;
            this.table = new LinkedList<KeyValuePair<T, V>>[capacity];  
        }

        public void Add(T key, T value) 
        {
        
        }

        public V Find(T key) 
        {
        
        }

        public void Remove(T key) 
        {
        
        }

        public void Clear() 
        {
        
        }
    }
}
