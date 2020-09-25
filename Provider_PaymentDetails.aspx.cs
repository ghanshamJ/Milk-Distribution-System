using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Provider_PaymentDetails : System.Web.UI.Page
    {
      
        HttpContext ct = HttpContext.Current;
        ConDb db = new ConDb();
        public List<string> data;
        public string a, s;

        public string ProviderId="";
        public string CustomerId = "";
        public string DateTime_ = "";
        public string transaction_id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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

            string cid = ct.Request["cid"];
            db.con.Open();
            string qry1 = "select first_name,last_name from customer where c_id=@cid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry1, db.con);
            db.cmd.Parameters.AddWithValue("@cid", cid);
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                lblDairyName.Text = db.rdr.GetString(0) + " " + db.rdr.GetString(1);
            }
            db.rdr.Close();
            db.con.Close();


            db.con.Open();
            string qry = "select dateTime,totalAmount,totalMilk,status,p_id,c_id,transaction_id from Payment_Details where c_id=@cid and p_id=@pid order by dateTime";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
            db.cmd.Parameters.AddWithValue("@cid", cid);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                data.Add(db.rdr.GetSqlDateTime(0).ToString().Substring(0, 10) + " " + db.rdr.GetString(1) + " " + db.rdr.GetString(2) + " " + db.rdr.GetString(3));
                /* data.Add(db.rdr.GetString(1));
                 data.Add(db.rdr.GetString(2));
                 data.Add(db.rdr.GetString(3));*/
                ProviderId = db.rdr.GetString(4);
                CustomerId = db.rdr.GetString(5);
                DateTime_ = db.rdr.GetSqlDateTime(0).ToString();
                transaction_id = db.rdr.GetString(6).ToString();
            }
            db.rdr.Close();
            db.con.Close();

        }
    }
}