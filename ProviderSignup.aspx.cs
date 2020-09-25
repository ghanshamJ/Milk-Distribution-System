using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class ProviderSignup : System.Web.UI.Page
    {
        ConDb db=new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            db.con.Open();
            string qry = "select email from provider where email=@em ";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@em", txtemail.Text);
            //db.cmd.Parameters.AddWithValue("@pass", "bb");
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
                string uid = Application["ProviderRegCounter"].ToString();
                Application["ProviderRegCounter"] = int.Parse(uid) + 1;
                string insrt = "insert into provider values(@uid,@email,@password,@dname,'','','','','')";
                db.cmd = new System.Data.SqlClient.SqlCommand(insrt,db.con);
                db.cmd.Parameters.AddWithValue("@uid",uid);
                db.cmd.Parameters.AddWithValue("@dname", txtDairy_name.Text);
                db.cmd.Parameters.AddWithValue("@email", txtemail.Text);
                db.cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                db.cmd.ExecuteScalar();
                Session["p_id"] = uid;

                Response.Redirect("CompleteInfo_Provider.aspx");
                
            }
            db.con.Close();
        }
     }
}