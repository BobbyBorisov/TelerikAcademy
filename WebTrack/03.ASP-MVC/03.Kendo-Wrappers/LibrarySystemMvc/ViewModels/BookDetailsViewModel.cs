using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.ViewModels
{
    public class BookDetailsViewModel
    {
        public string Title { set; get; }

        public string Description { set; get; }

        public string CategoryName { set; get; }

        public string AuthorName { set; get; }

        public string WebSite { set; get; }

        public string ISBN { set; get; }

    }
}