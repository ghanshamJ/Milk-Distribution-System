using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class CompleteInfo_Customer : System.Web.UI.Page
    {
        string gen;
        ConDb cn = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["c_id"]);
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (rdoFeMale.Checked)
            {
                gen = "Female";
            }
            else if(rdoMale.Checked)
            {
                gen = "Male";
            }
            
            cn.con.Open();
            string qry = "update customer set state= @st , district=@ds , city_village=@cty,address=@add,mobile=@mob,gender=@gen where c_id=@cid";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
            cn.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
            cn.cmd.Parameters.AddWithValue("@st", HiddenState.Value);
            cn.cmd.Parameters.AddWithValue("@ds", HiddenDistrict.Value);
            cn.cmd.Parameters.AddWithValue("@cty", txtCityVillagge.Text);
            cn.cmd.Parameters.AddWithValue("@add", txtAddress.Text);
            cn.cmd.Parameters.AddWithValue("@mob", txtMobile.Text);
            cn.cmd.Parameters.AddWithValue("@gen", gen);
            cn.cmd.ExecuteNonQuery();
            cn.con.Close();
            Response.Redirect("CustomerHome.aspx");
        }
    }
}