using Kendo.Mvc.UI;
using LibrarySystemMvc.Models;
using LibrarySystemMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemMvc.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext data = new ApplicationDbContext();
        public ActionResult Index()
        {
            var result = this.data.Categories.Include("Books").ToList().Select(x => new TreeViewItemModel
            {
                Text = x.Name,
                Items = x.Books.Select(y => new TreeViewItemModel
                {
                    Id=y.Id.ToString(),
                    Text = y.Title
                    
                }).ToList()

            });

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult BookDetails(int id)
        {
            var book = this.data.Books.FirstOrDefault(x=>x.Id==id);

            var bookvm = new BookDetailsViewModel()
            {
                Title=book.Title,
                Description=book.Description,
                ISBN=book.ISBN,
                AuthorName=book.Author.Name,
                CategoryName=book.Category.Name,
                WebSite=book.WebSite
            };


            return View(bookvm);
        }



        public JsonResult GetAutoCompleteData(string text)
        {
            var selectedBooks = this.data.Books
               .Where(x => x.Title.ToLower().Contains(text.ToLower()))
               .Select(ShortBookViewModel.FromBook);

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string titleSearch)
        {
            var result = this.data.Books.AsQueryable();

            if (!string.IsNullOrEmpty(titleSearch))
            {
                result = result.Where(x => x.Title.ToLower().Contains(titleSearch.ToLower()));
            }

            var endResult = result.Select(x => new ShortBookViewModel()
            {
                Id=x.Id,
                Title=x.Title,
                AuthorName=x.Author.Name,
                CategoryName=x.Category.Name
            });

            return View("Search",endResult);
        }
    }
}