using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Lib;

namespace Bookstore_Importer
{
    class Importer
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList bookmarkList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookmarkNode in bookmarkList)
            {
                string author = bookmarkNode.GetChildTextOrDefault("author");
                string title = bookmarkNode.GetChildTextOrDefault("title");
                string isbn = bookmarkNode.GetChildTextOrDefault("isbn");
                string price = bookmarkNode.GetChildTextOrDefault("price");
                string website = bookmarkNode.GetChildTextOrDefault("web-site");

               
                
                BookstoreProcessor.AddToDatabase(author, title, isbn, price, website);
            }
        }
    }
}
