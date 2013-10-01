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
    public class AuthorsAdminController : AdminController
    {
        private ApplicationDbContext Data { set; get; }
        public AuthorsAdminController()
        {
            this.Data = new ApplicationDbContext();
        }
        //
        // GET: /Administrator/CategoryAdmin/
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAllAuthors()
        {
            var allCat = this.Data.Authors.Select(x => new AuthorViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(allCat, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateAuthor([DataSourceRequest] DataSourceRequest request, AuthorViewModel author)
        {
            if (author != null && ModelState.IsValid)
            {
                var dbAuthor = new Author()
                {
                   Name=author.Name
                };

                this.Data.Authors.Add(dbAuthor);
                this.Data.SaveChanges();
            }
            return Json(new[] { author }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ReadAuthors([DataSourceRequest] DataSourceRequest request) {
            var authors = this.Data.Authors.Select(x=> new AuthorViewModel(){
                 Id=x.Id,
                 Name=x.Name
            });

            return Json(authors.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateAuthor([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel author)
        {
            var existingAuthor = this.Data.Authors.Find(author.Id);

            if (existingAuthor != null && ModelState.IsValid)
            {
                existingAuthor.Name = author.Name;

                this.Data.SaveChanges();
            }

            return Json(new[] { author }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyAuthor([DataSourceRequest] DataSourceRequest request, AuthorViewModel author)
        {
            Author authorsFromDb = this.Data.Authors.Find(author.Id);

            foreach (var book in authorsFromDb.Books.ToList())
            {
                this.Data.Books.Remove(book);
            }

            this.Data.Authors.Remove(authorsFromDb);
            this.Data.SaveChanges();

            return Json(new[] { author }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}