using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class MyProvider : System.Web.UI.Page
    {
        public List<string> cid = new List<string>();
        public List<string> Cid
        {
            get;
            set;
        }
        public ConDb db = new ConDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["c_id"].Equals("") || Session["c_id"].Equals(null))
                {
                    Response.Redirect("CustomerLogin.aspx");
                }
            }
            catch { Response.Redirect("CustomerLogin.aspx"); }
            db.con.Open();
            string qry = "select p_id from myCustomers where c_id=@cid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
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
            string qry = "select * from provider where p_id=@pid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@pid", s);

            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {

                lst.Add(db.rdr.GetString(3));
                lst.Add(db.rdr.GetString(1));
                lst.Add(db.rdr.GetString(8));
                lst.Add(db.rdr.GetString(4));
                lst.Add(db.rdr.GetString(5));
                lst.Add(db.rdr.GetString(6));
                lst.Add(db.rdr.GetString(7));
                lst.Add(db.rdr.GetString(0));
            }
            db.rdr.Close();
            db.con.Close();
            return lst.ToArray();
        }
    }
}