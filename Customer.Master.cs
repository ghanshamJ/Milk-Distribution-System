using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Customer : System.Web.UI.MasterPage
    {
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              if (Session["c_id"] == null)
                {
                   Response.Redirect("CustomerLogin.aspx");
                }
            }
            catch
            {
                Response.Redirect("CustomerLogin.aspx");
            }
         
                db.con.Open();
                string qry = "select email from customer where c_id=@cid";
                db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
                db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                db.rdr = db.cmd.ExecuteReader();
                if (db.rdr.Read())
                {
                    
                    lblUsername.Text = db.rdr.GetString(0);
                  
                 
                }
                db.con.Close();
            

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["c_id"] = null;
            Response.Redirect("CustomerLogin.aspx");
        }
    }
}