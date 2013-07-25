using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Lib;

namespace Bookstore.SimpleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("../../simple-query.xml");
            //xmlDoc.Load("../../another-simple-query.xml");
            xmlDoc.Load("../../query-with-author-only.xml");
            string title = xmlDoc.GetChildTextOrDefault("/query/title");
            string author = xmlDoc.GetChildTextOrDefault("/query/author");
            string isbn = xmlDoc.GetChildTextOrDefault("/query/isbn");

             List<SimpleQueryInfo> bookInfoList = BookstoreProcessor.FindByAuthorTitleOrISBN(title,author,isbn);
            
             if (bookInfoList.Count > 0)
             {
                 foreach (var book in bookInfoList)
                 {
                     Console.WriteLine("{0} --> {1} reviews", book.Title,book.ReviewsCount);
                 }
             }
             else
             {
                 Console.WriteLine("Nothing found");
             }
        }
    }
}
