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
    public class CategoriesAdminController : AdminController
    {
        private ApplicationDbContext Data { set; get; }
        public CategoriesAdminController()
        {
            this.Data = new ApplicationDbContext();
        }
        //
        // GET: /Administrator/CategoryAdmin/
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAll()
        {
            var allCat = this.Data.Categories.Select(x => new CategoryAdminViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(allCat, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request) {
            var categories = this.Data.Categories.Select(x=> new CategoryAdminViewModel(){
                 Id=x.Id,
                 Name=x.Name
            });

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategories([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel category)
        {
            var existingCategory = this.Data.Categories.Find(category.Id);

            if (existingCategory != null && ModelState.IsValid)
            {
                existingCategory.Name = category.Name;

                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel category)
        {
            Category categoryFromDb = this.Data.Categories.Find(category.Id);

            foreach (var book in categoryFromDb.Books.ToList())
            {
                this.Data.Books.Remove(book);
            }

            this.Data.Categories.Remove(categoryFromDb);
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}