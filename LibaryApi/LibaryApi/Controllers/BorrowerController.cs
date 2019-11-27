using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibaryApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace LibaryApi.Controllers
{
    public class BorrowerController : ApiController
    {
        // GET: api/Borrower
        public IEnumerable<Borrower> Get()
        {
            List<Borrower> output = new List<Borrower>();
            LibDataSetTableAdapters.BorrowerTableAdapter ta = new LibDataSetTableAdapters.BorrowerTableAdapter();
            var dt = ta.GetData();
            try
            {
                var numRows = dt.Rows.Count;
                DataRow dr;

                for (int i = 0; i < numRows; i++)
                {
                    dr = dt.Rows[i];

                    output.Add(new Borrower(Int32.Parse(dr["id"].ToString()),
                        dr["Surname"].ToString(), dr["Firstname"].ToString(),
                        dr["DOB"].ToString()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;

        }
        // GET: api/Borrower/5
        public BorrowerWBook Get(int id)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader rdr;
            BorrowerWBook output = new BorrowerWBook();
            conn = DBconnect.Connect();
            string qeury = "select* from Borrower Where id = " + id;
            string qeuryBook = "select * from books where borrower = " + id;

            try
            {
                conn.Open();

                cmd = new SqlCommand(qeury, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = new BorrowerWBook(Int32.Parse((rdr.GetValue(0).ToString())), Convert.ToString(rdr.GetValue(1)), 
                        Convert.ToString(rdr.GetValue(2)), rdr.GetValue(3).ToString());
                }
                rdr.Close();

                cmd.CommandText = qeuryBook;

                rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    output.books.Add(new Books(Int32.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(),
                        Int32.Parse(rdr.GetValue(2).ToString()), Int32.Parse(rdr.GetValue(3).ToString())));
                }
                
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return output;
        }


    }
}
