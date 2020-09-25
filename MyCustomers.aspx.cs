using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class MyCustomers : System.Web.UI.Page
    {
         public List<string> cid = new List<string>();
         public List<string> Cid
        {
            get;
            set;
        }
        public ConDb db=new ConDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["p_id"].Equals("") || Session["p_id"].Equals(null))
                {
                    Response.Redirect("ProviderLogin.aspx");
                }
            }
            catch {
                Response.Redirect("ProviderLogin.aspx");
            }
            db.con.Open();
            string qry = "select c_id from myCustomers where p_id=@pid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@pid",Session["p_id"].ToString());
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                cid.Add(db.rdr.GetString(0));
            }
            db.rdr.Close();
            db.con.Close();

        }
        public string[] Mydata(string s)
        {
           List<string> lst = new List<string>();
           db.con.Open();
           string qry = "select * from customer where c_id=@cid";
           db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
           db.cmd.Parameters.AddWithValue("@cid", s);
           
           db.rdr = db.cmd.ExecuteReader();
           if (db.rdr.Read())
           {

               lst.Add(db.rdr.GetString(1)+" "+db.rdr.GetString(2));
               lst.Add(db.rdr.GetString(3));
               lst.Add(db.rdr.GetString(5));
               lst.Add(db.rdr.GetString(6));
               lst.Add(db.rdr.GetString(7));
               lst.Add(db.rdr.GetString(8));
               lst.Add(db.rdr.GetString(9));
               lst.Add(db.rdr.GetString(0));
           } 
            db.rdr.Close();
            db.con.Close();
            return lst.ToArray();
        }
    }
}