using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryApi.Models
{
    public class BorrowedBook
    {
        public int ISBN { get; set; }
        public string title { get; set; }
        public int borrower { get; set; }
        int author { get; set; }

        public BorrowedBook(int pISBN, string pTitle, int pBorrower, int pAuthor)
        {
            this.ISBN = pISBN;
            this.title = pTitle;
            this.borrower = pBorrower;
            this.author = pAuthor;
        }

        public BorrowedBook(int pISBN, string pTitle, int pBorrower)
        {
            this.ISBN = pISBN;
            this.title = pTitle;
            this.borrower = pBorrower;
        }

        public BorrowedBook() { }
    }
}