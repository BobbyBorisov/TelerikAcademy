using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.BitArray
{
    class BitArray64: IEnumerable<int>
    {
        public ulong Number { get; set; }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public override bool Equals(object obj)
        {
            var other = obj as BitArray64;
            if (other == null)
                return false;
            if(!Object.Equals(this.Number,other.Number))
                return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<64;i++)
            {
                sb.AppendLine("long[" + i + "]= " + this[i]);
            }
            return sb.ToString();
        }

        public int this[int index] {
            get {
                return (int)((this.Number >> index) & 1);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++) 
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return BitArray64.Equals(bitArray1, bitArray2);
        }

        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !(BitArray64.Equals(bitArray1, bitArray2));
        }
    }
}
