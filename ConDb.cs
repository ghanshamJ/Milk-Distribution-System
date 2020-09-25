using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Online_Milk_Management
{
      
    public class ConDb
    {
       public  SqlConnection con;
       public  SqlDataReader rdr,rdr2;
       public  SqlCommand cmd;
        public ConDb()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=localhost\SQLEXPRESS2;Initial Catalog=Db_MilkApp;Integrated Security=True;User Instance=True";
        }

    }
}