using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Lib;
using Bookstore.Data;

namespace Bookstore.ComplexSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "../../search-result-review-queries.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ProcessSearchQueries(writer);

                writer.WriteEndDocument();
            }	
        }

        private static void ProcessSearchQueries(XmlTextWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../review-queries.xml");
            
            foreach (XmlNode query in xmlDoc.SelectNodes("/review-queries/query"))
            {
                string author = query.GetChildTextOrDefault("author");
                string startDate = query.GetChildTextOrDefault("start-date");
                string endDate = query.GetChildTextOrDefault("end-date");

                
                    if (query.Attributes["type"].Value == "by-period")
                    {
                        DateTime parsedStartDate = DateTime.Parse(startDate);
                        DateTime parsedEndDate = DateTime.Parse(endDate);
                        var reviewByPeriod = BookstoreProcessor.FindReviewByPeriod(parsedStartDate, parsedEndDate);
                        //var ordered = xads.OrderBy(x => x.Text);
                        WriteBookmarks(writer, reviewByPeriod);
                    }
                    else 
                    {
                        var reviewByAuthor = BookstoreProcessor.FindReviewByAuthor(author);
                        WriteBookmarks(writer, reviewByAuthor);
                    }
            }
        }

        private static void WriteBookmarks(XmlTextWriter writer, IList<Review> reviews)
        {
            writer.WriteStartElement("result-set");

            
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                if (review.CreatedOn != null)
                {
                    writer.WriteElementString("date", review.CreatedOn.ToString());
                }
                if (review.Text != null)
                {
                    writer.WriteElementString("content", review.Text);
                }

                writer.WriteStartElement("book");
                if (review.Book.Title != null) 
                {
                    writer.WriteElementString("title", review.CreatedOn.ToString());
                }
                if (review.Book.Authors.Count > 0)
                {
                    string authors = string.Join(", ",
                        review.Book.Authors.Select(t => t.Name).OrderBy(t => t));
                    writer.WriteElementString("author", authors);
                }
                if (review.Book.ISBN != null)
                {
                    writer.WriteElementString("isbn", review.Text);
                }

                if (review.Book.URL != null)
                {
                    writer.WriteElementString("url", review.Text);
                }
                writer.WriteEndElement();
                
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
