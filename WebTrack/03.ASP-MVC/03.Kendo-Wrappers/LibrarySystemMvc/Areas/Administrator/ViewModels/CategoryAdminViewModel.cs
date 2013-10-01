using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystemMvc.Areas.Administrator.ViewModels
{
    public class CategoryAdminViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryAdminViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryAdminViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

    }
}