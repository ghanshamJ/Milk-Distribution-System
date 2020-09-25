using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Transactions_Provider : System.Web.UI.Page
    {
        public List<string> data;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConDb db = new ConDb();
            HttpContext ct = HttpContext.Current;
           // Response.Write(ct.Request["cid"]);
            long ss = ((long.Parse(ct.Request["cid"]) / long.Parse(ct.Request["tcode1"]))) / long.Parse(ct.Request["tcode2"]);
           // Response.Write("   " + ss);


            data = new List<string>();
            try
            {
                if (Session["p_id"].Equals("") || Session["p_id"].Equals(null))
                {
                    Response.Redirect("ProviderLogin.aspx");
                }
            }
            catch
            {
                Response.Redirect("ProviderLogin.aspx");
            }

           // string cid = ss;
            db.con.Open();
            string qry1 = "select first_name,last_name from customer where c_id=@cid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry1, db.con);
            db.cmd.Parameters.AddWithValue("@cid", ss.ToString());
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                lblDairyName.Text = db.rdr.GetString(0);
            }
            db.rdr.Close();
            db.con.Close();


            db.con.Open();
            string qry = "select dateTime,liter,rate_per_liter,amount from milk_transaction where c_id=@cid and p_id=@pid order by dateTime";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
            db.cmd.Parameters.AddWithValue("cid", ss.ToString());
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                data.Add(db.rdr.GetSqlDateTime(0).ToString().Substring(0, 10) + " " + db.rdr.GetString(1) + " " + db.rdr.GetString(2) + " " + db.rdr.GetString(3));
                /* data.Add(db.rdr.GetString(1));
                 data.Add(db.rdr.GetString(2));
                 data.Add(db.rdr.GetString(3));*/
            }
            db.rdr.Close();
            db.con.Close();

        }
    }
}