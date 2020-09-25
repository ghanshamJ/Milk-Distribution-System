using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {

        ConDb db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ConDb();
            if (Session["Transaction_ID"] == null)
            {
                Response.Redirect("CustomerHome.aspx");
            }
            if (!IsPostBack)
            {
                db.con.Open();
                string qry1 = "update Payment_Details set transaction_id=@tnxid,paymentDate=@PymDate,status='1' where transaction_id=@Transaction_ID ";
                db.cmd = new System.Data.SqlClient.SqlCommand(qry1, db.con);

                db.cmd.Parameters.AddWithValue("@tnxid", Request.Form["txnid"]);
                db.cmd.Parameters.AddWithValue("@Transaction_ID", Session["Transaction_ID"].ToString());
                db.cmd.Parameters.AddWithValue("@PymDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));


                db.cmd.ExecuteNonQuery();
                Label1.Text = "Transaction ID :" + Request.Form["txnid"] + " has been successfully Completed of Rs." + Request.Form["amount"];


                db.con.Close();
                Session["Transaction_ID"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }

    }
}