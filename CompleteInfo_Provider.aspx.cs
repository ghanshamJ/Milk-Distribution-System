using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class CompleteInfo_Provider : System.Web.UI.Page
    {
       
        ConDb cn = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
           // Response.Write(Session["p_id"]);
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
          

            cn.con.Open();
            string qry = "update provider set state= @st , district=@ds , city_village=@cty,address=@add,contact=@mob where p_id=@pid";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
            cn.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
            cn.cmd.Parameters.AddWithValue("@st", HiddenState.Value);
            cn.cmd.Parameters.AddWithValue("@ds", HiddenDistrict.Value);
            cn.cmd.Parameters.AddWithValue("@cty", txtCityVillagge.Text);
            cn.cmd.Parameters.AddWithValue("@add", txtAddress.Text);
            cn.cmd.Parameters.AddWithValue("@mob", txtMobile.Text);
           
            cn.cmd.ExecuteNonQuery();
            cn.con.Close();
            Response.Redirect("ProviderHome.aspx");
        }
    }
}