using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*db.con.Open();

            string qry = "select email,password from customer where email=@em and password=@pass";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            //db.cmd.Parameters.AddWithValue("@em",);
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                Response.Write("yes");
            }
            else
            {
                Response.Write("no");
            }
            db.con.Close();
             * */
        }
    }
}