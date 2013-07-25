using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Data;
using System.Xml;

namespace Bookstore.Lib
{
    public static class BookstoreProcessor
    {
        public static void AddToDatabase(string author, string title, string isbn, string price, string website)
        {
            using (BookstoreDBEntities bookstoreContext = new BookstoreDBEntities()) 
            {
                Book book = new Book();
                var authorToCheck = CreateOrLoadAuthor(bookstoreContext, author);
                book.Authors.Add(authorToCheck);

                book.Title = title;
                book.ISBN = isbn;
                
                if (price == null)
                {
                    book.Price = null;
                }
                else 
                {
                    var convertedPrice = decimal.Parse(price, System.Globalization.CultureInfo.InvariantCulture);
                    book.Price = convertedPrice;
                }
                
                book.URL = website;

                bookstoreContext.Books.Add(book);
                bookstoreContext.SaveChanges();
            }
        }

        public static void AddToDbComplex(XmlNodeList authors, string title, string isbn, string price, string website, List<ReviewInfo> reviews) 
        {
            using (BookstoreDBEntities bookstoreContext = new BookstoreDBEntities())
            {
                Book book = new Book();
                foreach (XmlNode author in authors)
                {
                    var authorToCheck = CreateOrLoadAuthor(bookstoreContext, author.InnerText);
                    book.Authors.Add(authorToCheck);
                }

                book.Title = title;
                book.ISBN = isbn;

                if (price == null)
                {
                    book.Price = null;
                }
                else
                {
                    var convertedPrice = decimal.Parse(price, System.Globalization.CultureInfo.InvariantCulture);
                    book.Price = convertedPrice;
                }

                book.URL = website;

                if (reviews != null)
                {
                    foreach (var review in reviews)
                    {
                        Review currentReview = new Review();
                        if (review.Author == null)
                        {
                            currentReview.AuthorId = null;
                        }
                        else
                        {
                            var currentReviewAuthor = CreateOrLoadAuthor(bookstoreContext, review.Author);
                            currentReview.AuthorId = currentReviewAuthor.AuthorId;
                        }

                        currentReview.Text = review.Text;

                        //GetAuthorId(bookstoreContext, review.Author);
                        if (review.CreatedOn == null) 
                        {
                            currentReview.CreatedOn = DateTime.Now;
                        }
                        currentReview.CreatedOn = review.CreatedOn;

                        book.Reviews.Add(currentReview);

                        bookstoreContext.SaveChanges();
                    }
                }
                

                bookstoreContext.Books.Add(book);
                bookstoreContext.SaveChanges();


            }
        }

        //private static int GetAuthorId(BookstoreDBEntities context, string name) 
        //{
        //    var authorid = context.Authors.Where(x => x.Name == name).Select(x => x.AuthorId).First();
        //    return authorid;
        //}

        private static Author CreateOrLoadAuthor(
            BookstoreDBEntities context, string author)
        {
            Author existingUser =
                (from u in context.Authors
                 where u.Name.ToLower() == author.ToLower()
                 select u).FirstOrDefault();
            if (existingUser != null)
            {
                return existingUser;
            }

            Author newUser = new Author();
            newUser.Name = author;
            context.Authors.Add(newUser);
            context.SaveChanges();

            return newUser;
        }

        
        public static List<SimpleQueryInfo> FindByAuthorTitleOrISBN(string title,string author, string isbn ) 
        {
            using (BookstoreDBEntities bookstoreContext = new BookstoreDBEntities())
            {
                var query = bookstoreContext.Books
                    .Include("Authors").AsQueryable();

                if(title!=null)
                {
                    query = query.Where(x=>x.Title==title);
                }

                if (author != null) 
                {
                    query = query.Where(b => b.Authors.Any(t => t.Name == author));
                }

                if (isbn != null)
                {
                    query = query.Where(b => b.ISBN==isbn);
                }

                query = query.OrderBy(x => x.Title);

                var queryWithSelection = query.Select(x => new SimpleQueryInfo(){ Title = x.Title,ReviewsCount=x.Reviews.Count });
                return queryWithSelection.ToList();
            }
        }

        public static List<Review> FindReviewByPeriod(DateTime startDate, DateTime endDate) 
        {
            BookstoreDBEntities bookstoreContext = new BookstoreDBEntities();
            
                var query = bookstoreContext.Reviews
                    .Include("Author")
                    .Where(x => startDate <= x.CreatedOn && x.CreatedOn <= endDate)
                    .OrderBy(x => x.CreatedOn)
                    .OrderBy(x => x.Text)
                    .ToList();

                return query;
            
        }

        public static List<Review> FindReviewByAuthor(string author) 
        {
            BookstoreDBEntities bookstoreContext = new BookstoreDBEntities();
            
                var query = bookstoreContext.Reviews
                    .Include("Author")
                    .Where(x => x.Author.Name == author)
                    .OrderBy(x => x.CreatedOn)
                    .ThenBy(x => x.Text)
                    .ToList();

                return query;
            
          
        }
    }
}
