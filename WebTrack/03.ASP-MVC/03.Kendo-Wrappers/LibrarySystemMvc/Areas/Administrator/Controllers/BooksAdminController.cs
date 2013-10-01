using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystemMvc.Areas.Administrator.ViewModels;
using LibrarySystemMvc.Controllers;
using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemMvc.Areas.Administrator.Controllers
{
    public class BooksAdminController : AdminController
    {

        public BooksAdminController()
        {
            this.Data = new ApplicationDbContext();
        }
        public ApplicationDbContext Data { set; get; }
        //
        // GET: /Administrator/Books/
        public ActionResult Index()
        {
            //ViewData["categories"] = Data.Categories.Select(CategoryAdminViewModel.FromCategory);
            //ViewData["authors"] = Data.Authors.Select(AuthorViewModel.FromAuthor);
            
            
            //ViewData["categories"] = this.Data
            //    .Categories
            //    .Select(x => new CategoryAdminViewModel
            //    {
            //        Id = x.Id,
            //        Name = x.Name
            //    })
            //    ;

            //ViewData["authors"] = this.Data
            //    .Authors
            //    .Select(x => new AuthorViewModel
            //    {
            //        Id = x.Id,
            //        Name = x.Name
            //    })
            //    ;

            return View();
        }
        public JsonResult CreateBook([DataSourceRequest] DataSourceRequest request, BookAdminViewModel book)
        {
            //BookAdminViewModel book = new BookAdminViewModel();
            if (book.Category == null)
            {
                var firstCategory = this.Data.Categories.First();
                book.Category = new CategoryAdminViewModel()
                {
                    Id = firstCategory.Id,
                    Name = firstCategory.Name
                };

            }

            if (book.Author == null)
            {
                var firstAuthor = this.Data.Authors.First();
                book.Author = new AuthorViewModel()
                {
                    Id = firstAuthor.Id,
                    Name = firstAuthor.Name
                };

            }

            if (book != null && ModelState.IsValid)
            {
                var dbBook = new Book()
                {
                    Title = book.Title,
                    Description=book.Description,
                    Author = this.Data.Authors.Find(book.Author.Id),
                    Category = this.Data.Categories.Find(book.Category.Id),
                    ISBN = book.ISBN,
                    WebSite = book.WebSite

                };
                book.AuthorName = dbBook.Author.Name;
                book.CategoryName = dbBook.Category.Name;

                this.Data.Books.Add(dbBook);
                this.Data.SaveChanges();
            }
            return Json(new[] { book }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ReadBooks([DataSourceRequest] DataSourceRequest request)
        {
            var books = this.Data.Books.Select(BookAdminViewModel.FromBook);

            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBook([DataSourceRequest] DataSourceRequest request, BookAdminViewModel book)
        {
            var existingBook = this.Data.Books.Find(book.Id);

            if (existingBook != null && ModelState.IsValid)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = this.Data.Authors.Find(book.Author.Id);
                existingBook.Category = this.Data.Categories.Find(book.Category.Id);

                this.Data.SaveChanges();
                book.CategoryName = existingBook.Category.Name;
                book.AuthorName = existingBook.Author.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest] DataSourceRequest request, BookAdminViewModel book)
        {
            var bookToRemove = this.Data.Books.Find(book.Id);

            this.Data.Books.Remove(bookToRemove);
            this.Data.SaveChanges();

            return Json(new[] { book }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


	}
}