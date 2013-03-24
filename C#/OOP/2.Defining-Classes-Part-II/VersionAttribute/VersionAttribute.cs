using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_II__11_
{
    [AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = false)]
    class VersionAttribute: System.Attribute
    {
        public string Name { get; private set; }

        public VersionAttribute(string name) {
            this.Name = name;
        }
    }
}
