using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class ProviderDetails : System.Web.UI.Page
    {
        ConDb cn = new ConDb();
        HttpContext c = HttpContext.Current;
        string pid = "";
          

        protected void Page_Load(object sender, EventArgs e)
        {
             pid = c.Request["cid"];

            cn.con.Open();
            string qry = "Select * from provider where p_id='" + pid + "'";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry,cn.con);
            cn.rdr = cn.cmd.ExecuteReader();
            if (cn.rdr.Read())
            {
                lblAddress.Text = cn.rdr.GetString(7);
                lblCityVillage.Text = cn.rdr.GetString(6);
                lblContact.Text = cn.rdr.GetString(8);
                lblDistrict.Text = cn.rdr.GetString(5);
                lblState.Text = cn.rdr.GetString(4);
                lblName.Text = cn.rdr.GetString(3);
            }
            cn.rdr.Close();
            cn.con.Close();
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            cn.con.Open();


            string qry = "Select p_id from myCustomers where c_id='" + Session["c_id"].ToString() + "' and p_id='"+pid+"' ";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
            cn.rdr = cn.cmd.ExecuteReader();
            if (cn.rdr.Read())
            {
                lblMessage.Text = " This Provider is already selected ";
                cn.rdr.Close();
            }
                
            else
            {
                cn.rdr.Close();
                string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string qry2 = "insert into myCustomers values(@pid,@cid,@datetime)";
                cn.cmd = new System.Data.SqlClient.SqlCommand(qry2, cn.con);
                cn.cmd.Parameters.AddWithValue("@pid", pid);
                cn.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                cn.cmd.Parameters.AddWithValue("@datetime", dt);
                try
                {
                    cn.cmd.ExecuteNonQuery();
                    lblMessage.Text = " You joined This Provider";
                }
                catch
                {
                    lblMessage.Text = " Error occured";
                } 
            }
            cn.con.Close();
        }
    }
}