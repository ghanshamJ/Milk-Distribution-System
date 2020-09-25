using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Online_Milk_Management
{
    public partial class FindDairy : System.Web.UI.Page
    {
        ConDb cn = new ConDb();
        public List<string> providerId ;//= new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack)
             {
                providerId = new List<string>();
                string st="",dist="",cit="";
                cn.con.Open();
                string qry = "Select state,district, city_village from customer where c_id=@cid";
                cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
                try
                {
                    cn.cmd.Parameters.AddWithValue("@cid", Session["c_id"].ToString());
                }
                catch
                {
                    Response.Redirect("CustomerLogin.aspx");
                }
                cn.rdr = cn.cmd.ExecuteReader();
                if (cn.rdr.Read())
                {
                    st=cn.rdr.GetString(0);
                    dist=cn.rdr.GetString(1);
                    cit = cn.rdr.GetString(2);
 
                }
                cn.rdr.Close();
                

                string qry2 = "Select p_id from provider where state= @st and district=@ds and city_village=@cty";
                SqlCommand mycmd = new System.Data.SqlClient.SqlCommand(qry2, cn.con);
                mycmd.Parameters.AddWithValue("@st", st);
                mycmd.Parameters.AddWithValue("@ds", dist);
                mycmd.Parameters.AddWithValue("@cty", cit);
                SqlDataReader myrdr = mycmd.ExecuteReader();
                while (myrdr.Read())
                {
                    providerId.Add(myrdr.GetString(0));
                }
                myrdr.Close();
                mycmd.Cancel();
                cn.con.Close();
            }
        }
        
        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            providerId = new List<string>();
             cn.con.Open();
             string qry = "Select p_id from provider where state= @st and district=@ds and city_village=@cty";//'" + HiddenState.Value + "'";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
            cn.cmd.Parameters.AddWithValue("@st", HiddenState.Value);
            cn.cmd.Parameters.AddWithValue("@ds", HiddenDistrict.Value);
            cn.cmd.Parameters.AddWithValue("@cty", HiddenCity.Value);

            cn.rdr = cn.cmd.ExecuteReader();
            System.Web.UI.HtmlControls.HtmlGenericControl createDiv;
            //ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Hello World');", true);
            while (cn.rdr.Read())
            {
                providerId.Add(cn.rdr.GetString(0));
               /* createDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(125,125,125)");
                createDiv.Style.Add(HtmlTextWriterStyle.Color, "White");
                createDiv.Style.Add(HtmlTextWriterStyle.Height, "100px");
                createDiv.Style.Add(HtmlTextWriterStyle.Width, "400px");
                createDiv.InnerHtml = "<div> Dairy Name:  " + cn.rdr.GetString(3) + "<br> Address: " + cn.rdr.GetString(7) + "<a href='ProviderDetails.aspx?id=" + cn.rdr.GetString(0) + "'>Visit</a></div><br>";
                this.Controls.Add(createDiv);
                * */
            }
            cn.rdr.Close();
            cn.con.Close();
            HiddenState.Value = "";
            HiddenCity.Value = "";
            HiddenDistrict.Value = "";
        }
        public string[] Mydata(string s)
        {
            List<string> lst = new List<string>();
            cn.con.Open();
            string qry = "select * from provider where p_id=@pid";
            cn.cmd = new System.Data.SqlClient.SqlCommand(qry, cn.con);
            cn.cmd.Parameters.AddWithValue("@pid", s);

            cn.rdr = cn.cmd.ExecuteReader();
            if (cn.rdr.Read())
            {

                lst.Add(cn.rdr.GetString(3));
                lst.Add(cn.rdr.GetString(1));
                lst.Add(cn.rdr.GetString(8));
                lst.Add(cn.rdr.GetString(4));
                lst.Add(cn.rdr.GetString(5));
                lst.Add(cn.rdr.GetString(6));
                lst.Add(cn.rdr.GetString(7));
                lst.Add(cn.rdr.GetString(0));
            }
            cn.rdr.Close();
            cn.con.Close();
            return lst.ToArray();
        }
    }
}