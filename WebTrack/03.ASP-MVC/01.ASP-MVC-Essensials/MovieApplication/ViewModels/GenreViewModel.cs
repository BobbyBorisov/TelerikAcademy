using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieApplication.Areas.Administrator.ViewModels
{
    public class GenreViewModel
    {
        public static Expression<Func<Genre, GenreViewModel>> FromGenre
        {
            get
            {
                return genre => new GenreViewModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}