using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnSignup.PostBackUrl = "CustomerHome.aspx";
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
          db.con.Open();
          string qry = "select c_id,email,password,state from customer where email=@em and password=@pass";
          db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
          db.cmd.Parameters.AddWithValue("@em", txtUname.Text);
          db.cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
          db.rdr = db.cmd.ExecuteReader();
          if (db.rdr.Read())
          {
              Session["c_id"] = db.rdr.GetString(0);
             if (db.rdr.GetString(3).Equals(null) || db.rdr.GetString(3).Equals(""))
              {
                Response.Redirect("CompleteInfo_Customer.aspx");
              }
              else
              {
                 
                  Response.Redirect("CustomerHome.aspx");
              }

             
          }
          else
          {
              lblErrormsg.Text = "Username or password not match";
          }
          db.con.Close();
           
        }
    }
}