using LibaryApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibaryApi.Controllers
{
    public class BorrowedController : ApiController
    {
        // GET: api/Borrowed
        public IEnumerable<BorrowedBook> Get()
        {
            List<BorrowedBook> output = new List<BorrowedBook>();
            LibDataSetTableAdapters.BooksBorrowedTableAdapter ta = new LibDataSetTableAdapters.BooksBorrowedTableAdapter();
            var dt = ta.GetData();

            try
            {
                var numRows = dt.Rows.Count;
                DataRow dr;

                for (int i = 0; i < numRows; i++)
                {
                    dr = dt.Rows[i];

                    output.Add(new BorrowedBook(Int32.Parse(dr["ISBN"].ToString()),
                        dr["Title"].ToString(),
                        Int32.Parse(dr["Borrower"].ToString())));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

    }
}
