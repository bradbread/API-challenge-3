using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibaryApi.Models
{
    public class Author
    {
        int id { get; set; }
        string surname { get; set; }
        string firstName { get; set; }

        public Author(int pId, string pSurname, string pFirstName)
        {
            this.id = pId;
            this.surname = pSurname;
            this.firstName = pFirstName;
        }

        public Author() { }
    }
}