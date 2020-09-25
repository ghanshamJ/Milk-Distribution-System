using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class ProviderLogin : System.Web.UI.Page
    {
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            db.con.Open();
            string qry = "select p_id,email,password,state from provider where email=@em and password=@pass";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@em", txtUname.Text);
            db.cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                Session["p_id"] = db.rdr.GetString(0);
                if (db.rdr.GetString(3).Equals("") || db.rdr.GetString(3).Equals(null))
                {
                    
                    Response.Redirect("CompleteInfo_Provider.aspx");
                }
                else
                {

                    Response.Redirect("ProviderHome.aspx");
                }
            }
            else
            {
                lblErrormsg.Text = "The username or password not match..";
            }
            db.con.Close();
        }
    }
}