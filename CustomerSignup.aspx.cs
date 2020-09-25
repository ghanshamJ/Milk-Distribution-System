using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class CustomerSignup : System.Web.UI.Page
    {
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
             db.con.Open();
            string qry = "select email from customer where email=@em ";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@em", txtemail.Text);
            
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                
                
                db.con.Close();
                lblErrormsg.Text = "This Email-id already exists..";
                
                return;
            }
            else
            {
                db.rdr.Close();
                string uid = Application["userRegCounter"].ToString();
                Application["userRegCounter"] = int.Parse(uid) + 1;
                string insrt = "insert into customer values(@uid,@fname,@lname,@email,@password,'','','','','','')";
                db.cmd = new System.Data.SqlClient.SqlCommand(insrt,db.con);
                db.cmd.Parameters.AddWithValue("@uid",uid);
                db.cmd.Parameters.AddWithValue("@fname",txtfirst_name.Text);
                db.cmd.Parameters.AddWithValue("@lname", txtlast_name.Text);
                db.cmd.Parameters.AddWithValue("@email", txtemail.Text);
                db.cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                db.cmd.ExecuteScalar();
                //Response.Write("inserted");
                Session["c_id"]=uid;
                Response.Redirect("CompleteInfo_Customer.aspx");
               // Response.Redirect("CustomerHome.aspx");
                
            }
            db.con.Close();
        }
    }
}