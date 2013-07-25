using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Lib
{
    public class ReviewInfo
    {
        public string Author { set; get; }
        public DateTime CreatedOn { set; get; }
        public string Text { set; get; }

        public ReviewInfo(string author, DateTime createdOn,string text)
        {
            this.Author = author;
            this.CreatedOn = createdOn;
            this.Text = text;
        }

        public ReviewInfo() { }
    }
}
