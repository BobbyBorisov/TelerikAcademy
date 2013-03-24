using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenericList
{
    public class GenericList<T> 
        where T:IComparable<T>
    {
        T[] array;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public GenericList(int aCapacity)
        {
            array = new T[aCapacity];
            Console.WriteLine("Creating array with length={0}", array.Length);
            Count = 0;
            Capacity = aCapacity;
        }

        public void Add(T element)
        {
            array[Count] = element;
            Count++;
            if (Count == Capacity)
            {
                this.AutoGrow();
            }

        }

        public void Add(params T[] elements)
        {
    
            for (int i = 0; i < elements.Length; i++)
            {
                this.Add(elements[i]);
            }
            
        }

        public void Remove(int index)
        {
           /* for (int i = Count - 1; i > index; i--)
            {
                array[i - 1] = array[i];
            }
            Count--;
            */
            var arrayList = array.ToList();
            arrayList.RemoveAt(index);
            T[] newarray = arrayList.ToArray();
            this.array = (T[])newarray.Clone();
            Count--;
        }

        public void AutoGrow()
        {    
            var temp = (T[])this.array.Clone();
            Capacity = Capacity * 2;
            this.array = new T[Capacity];
            Array.Copy(temp, this.array, temp.Length);
        }

        public void Insert(T element, int index)
        {

           //TODO Check for index value
            if((index<0) || (index>this.array.Length-1))
                throw new ArgumentException(String.Format("Index {0} does not exist", index));
            if (Count == Capacity)
            {
                this.AutoGrow();
            }
            
           // for (int i = Count; i > index; i--)
           // {
           //     array[i] = array[i-1];
           // }
           // array[index] = element;
           // Count++;
                       
            var arrayList = this.array.ToList();
            arrayList.Insert(index, element);
            T[] temp = arrayList.ToArray();
            this.array = (T[])temp.Clone();
            this.Count++;
            
        }

        public int FindByValue(int value)
        {
            int index = Array.IndexOf(array, value);
            return index;
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length - 1);
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index > this.array.Length))
                    throw new ArgumentException(String.Format("Index {0} does not exist", index));
                return this.array[index];
            }
            set
            {
                if ((index < 0) || (index > this.array.Length-1))
                    throw new ArgumentException(String.Format("Index {0} does not exist", index));
                Console.WriteLine("here");
                this.array[index] = value;
            }
        }

        public int Min<T>() where T: IComparable<T>
        {
            int min_index = 0;
            for (int i = 0; i < array.Length; i++) {
                if (this.array[min_index].CompareTo(this.array[i]) >= 1) {
                    min_index = i;
                }
            }
            
            return min_index;
        }

        public int Max<T>() where T : IComparable<T>
        {
            int max_index = 0;
            for (int i = 0; i < array.Length; i++){
                if (this.array[max_index].CompareTo(this.array[i]) <= -1) {
                    max_index = i;
                }
            }

            return max_index;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.array.Length; i++)
            {
                sb.AppendLine("array[" + i + "]=" + array[i]);
            }
            return sb.ToString();
        }
        
        public  string ToStringForTesting()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++) {
                sb.Append(array[i] + " ");
            }
            return sb.ToString();
        }        
    }

    public class GenericTest
    {

        static void Main()
        {
            int[] arr = new int[5];
            Console.WriteLine(arr.Length);

            GenericList<int> intlist = new GenericList<int>(2);
            Console.WriteLine(intlist.Count);
            Console.WriteLine(intlist.Capacity);
            intlist.Add(5, 1, 2, 3);
            Console.WriteLine(intlist.ToString());
            intlist.Remove(0);
            intlist[5] = 8;
            Console.WriteLine(intlist.ToString());
        }
    }
}
