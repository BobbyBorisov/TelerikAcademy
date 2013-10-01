using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApplication.Models
{
    public class Genre
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }

        public virtual ICollection<Movie> Movies { set; get; }
    }
}