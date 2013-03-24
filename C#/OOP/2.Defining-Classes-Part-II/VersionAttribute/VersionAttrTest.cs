using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_II__11_
{
    [Version("2.11")]
    class VersionAttrTest
    {
        static void Main() {
            Type type = typeof(VersionAttrTest);
            object[] allAttributes =
                 type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine(
                  "This class is written by {0}. ", attr.Name);
            }

        }
    }
}
