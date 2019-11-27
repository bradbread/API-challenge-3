using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryApi.Models
{
    public class Borrower
    {
        public int id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string DOB { get; set; }

        public Borrower(int pId, string pSurname, string pFirstName, string pDateOfBirth)
        {
            this.id = pId;
            this.Surname = pSurname;
            this.Firstname = pFirstName;
            this.DOB = pDateOfBirth;
        }

        public Borrower() { }
    }
}