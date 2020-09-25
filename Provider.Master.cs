using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Provider : System.Web.UI.MasterPage
    {
        ConDb db=new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["p_id"] ==null)
                {
                    Response.Redirect("ProviderLogin.aspx");
                }
            }
            catch
            {
                Response.Redirect("ProviderLogin.aspx");
            }
            
            {
                db.con.Open();
                string qry = "select email from provider where p_id=@pid";
                db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
                db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
                db.rdr = db.cmd.ExecuteReader();
                if (db.rdr.Read())
                {
                    
                    lblUsername.Text = db.rdr.GetString(0);
                   

                }
                db.rdr.Close();
                db.con.Close();
            }
         
        
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["p_id"] = null;
            Response.Redirect("ProviderLogin.aspx");
        }
    }
}
         