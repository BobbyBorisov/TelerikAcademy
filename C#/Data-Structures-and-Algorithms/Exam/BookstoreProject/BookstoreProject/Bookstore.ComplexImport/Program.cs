using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Lib;

namespace Bookstore.ComplexImport
{
    
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList bookmarkList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookmarkNode in bookmarkList)
            {
                var authors = bookmarkNode.SelectNodes("authors");
                //string author = bookmarkNode.GetChildTextOrDefault("authors");
                string title = bookmarkNode.GetChildTextOrDefault("title");
                string isbn = bookmarkNode.GetChildTextOrDefault("isbn");
                string price = bookmarkNode.GetChildTextOrDefault("price");
                string website = bookmarkNode.GetChildTextOrDefault("web-site");
                
                
                var reviews = bookmarkNode.SelectSingleNode("reviews");
                List<ReviewInfo> reviewInfos = new List<ReviewInfo>();

                if (reviews != null)
                {
                    
                    foreach (XmlNode review in reviews)
                    {
                        ReviewInfo currentReviewInfo = new ReviewInfo();
                        currentReviewInfo.Text = review.InnerText.Trim();
                        var attr = review.Attributes;
                        foreach (XmlAttribute at in attr)
                        {
                            if (at.Name == "author")
                            {
                                currentReviewInfo.Author = at.Value;
                            }
                            if (at.Name == "date")
                            {
                                var parsedDate = DateTime.Parse(at.Value);
                                currentReviewInfo.CreatedOn = parsedDate;
                            }
                        }

                        reviewInfos.Add(currentReviewInfo);

                    }
                }
                BookstoreProcessor.AddToDbComplex(authors, title, isbn, price, website, reviewInfos);
            }
        }
    }
}
