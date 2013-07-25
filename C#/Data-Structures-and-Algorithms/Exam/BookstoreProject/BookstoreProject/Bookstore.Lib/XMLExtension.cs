using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bookstore.Lib
{
    public static class XMLExtension
    {
        public static string GetChildTextOrDefault(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
