using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Online_Milk_Management
{
    public class Global1 : System.Web.HttpApplication
    {
        ConDb db = new ConDb();
        protected void Application_Start(object sender, EventArgs e)
        {
           
            int cnt1=0,cnt2=0;
            db.con.Open();
            string qry = "select email from customer";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                cnt1++;
            }
           db.rdr.Close();

           Application["userRegCounter"] = 100002 +cnt1;

           string qry2 = "select email from provider";
           db.cmd = new System.Data.SqlClient.SqlCommand(qry2, db.con);
           db.rdr = db.cmd.ExecuteReader();
           while (db.rdr.Read())
           {
               cnt2++;
           }
           db.rdr.Close();
           Application["ProviderRegCounter"] = 2000000 +cnt2;
           db.con.Close();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}