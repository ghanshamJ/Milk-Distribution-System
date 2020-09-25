using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Milk_Order : System.Web.UI.Page
    {
         HttpContext ct = HttpContext.Current;
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblDateTime.Text = DateTime.Now.ToShortDateString();

            try
            {
                if (Session["c_id"].Equals("") || Session["c_id"].Equals(null))
                {
                    Response.Redirect("CustomerLogin.aspx");
                }
            }
            catch
            {
                Response.Redirect("CustomerLogin.aspx");
            }

            string pid = ct.Request["pid"];
            db.con.Open();
            string qry1 = "select dairy_name from provider where p_id=@pid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry1, db.con);
            db.cmd.Parameters.AddWithValue("@pid", pid);
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                lblDairyName.Text = db.rdr.GetString(0);
            }
            db.rdr.Close();
            db.con.Close();
        }
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string pid = ct.Request["pid"];
            bool flag = false;
            db.con.Open();
            ///////////////////////////////////work pending
            string qry5 = "select p_id,c_id from milk_Transaction  where p_id=@pid and c_id=@cid and  dateTime>=@date";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry5, db.con);
            db.cmd.Parameters.AddWithValue("@pid", pid);
            db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
            db.cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0,10));
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
                flag = true;
            }
             db.rdr.Close();

             if (!flag)
             {
                 string qry3 = "insert into milk_Transaction values(@pid,@cid,@dt,@ltr,@rate,@amt)";
                 db.cmd = new System.Data.SqlClient.SqlCommand(qry3, db.con);
                 db.cmd.Parameters.AddWithValue("@pid", pid);
                 db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                 db.cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                 db.cmd.Parameters.AddWithValue("@ltr", txtLiters.Text);
                 db.cmd.Parameters.AddWithValue("@rate", "50");
                 string amt = (50 * double.Parse(txtLiters.Text)).ToString();
                 db.cmd.Parameters.AddWithValue("@amt", amt);
                 db.cmd.ExecuteNonQuery();
                 lblMessage.Text = "Order Added";
             }
             else
             {
                 string qry3 = "update  milk_Transaction set p_id=@pid,c_id=@cid,dateTime=@dt,liter=@ltr,rate_per_liter=@rate,amount=@amt where p_id=@pid and c_id=@cid and dateTime>=@date";
                 db.cmd = new System.Data.SqlClient.SqlCommand(qry3, db.con);
                 db.cmd.Parameters.AddWithValue("@pid", pid);
                 db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                 db.cmd.Parameters.AddWithValue("@dt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                 db.cmd.Parameters.AddWithValue("@ltr", txtLiters.Text);
                 db.cmd.Parameters.AddWithValue("@rate", "50");
                 string amt = (50 * double.Parse(txtLiters.Text)).ToString();
                 db.cmd.Parameters.AddWithValue("@amt", amt);
                 db.cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 10));
           
                 db.cmd.ExecuteNonQuery();
                 lblMessage.Text = "Order Updated";
             }
            db.con.Close();
        }

        protected void btnSetDefault_Click(object sender, EventArgs e)
        {
            string pid = ct.Request["pid"];
            bool flag = false;
            db.con.Open();
            string qry5 = "select p_id,c_id from milk_default_qty  where p_id=@pid and c_id=@cid";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry5, db.con);
            db.cmd.Parameters.AddWithValue("@pid", pid);
            db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());

            db.rdr = db.cmd.ExecuteReader();
            if(db.rdr.Read())
            {
                flag = true;
            }

            db.rdr.Close();

            if (!flag)
            {
                string qry6 = "insert into milk_default_qty values(@cid,@pid,@ltr)";
                db.cmd = new System.Data.SqlClient.SqlCommand(qry6, db.con);
                db.cmd.Parameters.AddWithValue("@pid", pid);
                db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                db.cmd.Parameters.AddWithValue("@ltr", txtDefault_qty.Text);
                db.cmd.ExecuteNonQuery();
                lblMessage.Text = "Default Quantity Updated";
                db.rdr.Close();
            }
            else
            {
                string qry7 = "update  milk_default_qty set c_id=@cid,p_id=@pid,milk_qty=@ltr where p_id=@pid and c_id=@cid";
                db.cmd = new System.Data.SqlClient.SqlCommand(qry7, db.con);
                db.cmd.Parameters.AddWithValue("@pid", pid);
                db.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                db.cmd.Parameters.AddWithValue("@ltr", txtDefault_qty.Text);
                db.cmd.ExecuteNonQuery();
                lblMessage.Text = "Default Quantity Updated";
                db.rdr.Close();
            }
        
            db.con.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}