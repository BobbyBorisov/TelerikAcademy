using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.Models
{
    public class Category
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { set; get; }

        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}