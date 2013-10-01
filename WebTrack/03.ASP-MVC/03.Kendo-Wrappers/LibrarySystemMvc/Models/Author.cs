using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.Models
{
    public class Author
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public virtual ICollection<Book> Books { set; get; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    }
}