using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryApi.Models
{
    public class Books
    {
        public int ISBN { get; set; }
        public string title { get; set; }
        int borrower { get; set; }
        int author { get; set; }

        public Books(int pISBN, string pTitle, int pBorrower, int pAuthor)
        {
            this.ISBN = pISBN;
            this.title = pTitle;
            this.borrower = pBorrower;
            this.author = pAuthor;
        }

        public Books(int pISBN, string pTitle)
        {
            this.ISBN = pISBN;
            this.title = pTitle;
        }

        public Books() { }
    }
}