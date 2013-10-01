using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystemMvc.Areas.Administrator.ViewModels
{
    public class BookAdminViewModel
    {
        public static Expression<Func<Book, BookAdminViewModel>> FromBook
        {
            get
            {
                return b => new BookAdminViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    AuthorName = b.Author.Name,
                    Author = new AuthorViewModel{
                        Id=b.Author.Id,
                        Name=b.Author.Name
                    },
                    CategoryName = b.Category.Name,
                    Category = new CategoryAdminViewModel
                    {
                        Id = b.Category.Id,
                        Name = b.Category.Name
                    },
                    ISBN = b.ISBN,
                    WebSite = b.WebSite
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public string ISBN { set; get; }


        [UIHint("_CategoryDropdown")]
        public CategoryAdminViewModel Category { set; get; }

        public string CategoryName { set; get; }

        [UIHint("_AuthorDropdown")]
        public AuthorViewModel Author { set; get; }

        public string AuthorName { set; get; }

        public string WebSite { set; get; }


    }
}