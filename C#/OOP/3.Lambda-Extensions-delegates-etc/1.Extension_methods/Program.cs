using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



public static class Extensions
{
    public static string ToString<T>(this IEnumerable<T> enumeration)
    {
        StringBuilder result = new StringBuilder();
        result.Append("[ ");
        foreach (var item in enumeration)
        {
            result.Append(item.ToString());
            result.Append(" ");
        }
        result.Append("]");
        return result.ToString();
    }


    //TODO Extension method for StringBuilder OK
    public static StringBuilder Substring(this StringBuilder sb, int index, int length)
    {
        string sub = sb.ToString();
        sub = sub.Substring(index, length);
        Console.WriteLine("in my extension method");
        return new StringBuilder(sub);
    }

    //TODO Extension method Sum() for IEnumerable<T> OK
    public static T Sum<T>(this IEnumerable<T> enumer)
    {
        var result = default(T);
        foreach (var element in enumer)
        {
            result += (dynamic)element;
        }
        return result;
    }

    //TODO Extension method Product() for IEnumerable<T> OK
    public static T Product<T>(this IEnumerable<T> enumer)
    {
        var result = default(T);
        foreach (var element in enumer)
        {
            result *= (dynamic)element;
        }
        return result;
    }

    //TODO Extension method Min() for IEnumerable<T> OK
    public static T Min<T>(this IEnumerable<T> enumer)
        where T : IComparable<T>
    {
        T min = enumer.ElementAt(0);
        foreach (T element in enumer)
        {
            if (min.CompareTo(element) >= 1)
            {
                min = element;
            }
            else continue;
        }
        return min;
    }

    public static T Average<T>(this IEnumerable<T> enumer)
    {
        dynamic result = 0;


        foreach (T element in enumer)
        {
            result += (dynamic)element;
        }
        return result / enumer.Count();
    }

    //TODO to write extended methods for product,min,max,average  OK

}

class ExtensionMethods
{
    static void Main()
    {


        //using substring for stringbuilder
        StringBuilder sb = new StringBuilder();
        sb.Append("alabala");
        sb = sb.Substring(3, 4);
        Console.WriteLine(sb.ToString());

        StringBuilder ha = new StringBuilder();
        ha.Append("12345");
        ha = ha.Substring(0, 3);
        Console.WriteLine(ha.ToString());

        List<int> intlist = new List<int>();
        intlist.Add(1);
        intlist.Add(2);
        var sumoflist = intlist.Sum();
        Console.WriteLine("the sum is {0}", sumoflist);
    }
}
