using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApplication.Models
{
    public class Movie
    {
        public int Id { set; get; }

        [Required]
        public string Title { set; get; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { set; get; }


        public int GenreId { set; get; }
        
        [DataType("Genre")]
        public virtual Genre Genre { set; get; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { set; get; }

        [Required]
        public RatingType Rating { get; set; }

    }
}