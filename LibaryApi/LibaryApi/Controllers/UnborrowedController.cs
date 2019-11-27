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
    public class UnborrowedController : ApiController
    {
        // GET: api/Unborrowed
        public IEnumerable<Books> Get()
        {
            List<Books> output = new List<Books>();
            LibDataSetTableAdapters.BooksNotBorrowedTableAdapter ta = new LibDataSetTableAdapters.BooksNotBorrowedTableAdapter();
            var dt = ta.GetData();
            try
            {
                var numRows = dt.Rows.Count;
                DataRow dr;

                for (int i = 0; i < numRows; i++)
                {
                    dr = dt.Rows[i];

                    output.Add(new Books(Int32.Parse(dr["ISBN"].ToString()),
                        dr["Title"].ToString()));
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
