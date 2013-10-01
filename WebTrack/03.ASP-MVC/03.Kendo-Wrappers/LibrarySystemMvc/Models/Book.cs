using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.Models
{
    public class Book
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Title { set; get; }

        public string Description { set; get; }

        public string ISBN { set; get; }

        public string WebSite { set; get; }

        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }

        [Required]
        public int AuthorId { set; get; }
        public virtual Author  Author { get; set; }
    }
}