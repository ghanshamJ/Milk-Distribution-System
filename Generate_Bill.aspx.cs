using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Generate_Bill : System.Web.UI.Page
    {
        String cid;
        double totalAmount=0;
        double liter = 0;
        ConDb db = new ConDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            cid = Request.QueryString["cid"].ToString();
            //Response.Write(cid);
            try
            {
                if (Session["p_id"].Equals("") || Session["p_id"].Equals(null))
                {
                    Response.Redirect("ProviderLogin.aspx");
                }
            }
            catch { Response.Redirect("ProviderLogin.aspx"); }

            String datetime ="2000-01-01 10:30:00.000";

            db.con.Open();

            //DateTime start1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 10));
            //DateTime start1 = DateTime.Parse("12-07-2019 23:20:24");

            string qry3 = "select dateTime from Payment_Details A where p_id=@pid and c_id=@cid order by dateTime desc";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry3, db.con);
            db.cmd.Parameters.AddWithValue("@cid", cid);
            db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
            
            db.rdr = db.cmd.ExecuteReader();
            if (db.rdr.Read())
            {
               
                datetime = db.rdr.GetSqlDateTime(0).ToString();
               // Response.Write("Last date ===" + datetime);
            }

            db.rdr.Close();
            db.con.Close();


            db.con.Open();
            string qry = "select amount,liter from milk_Transaction A where p_id=@pid and c_id=@cid and (A.dateTime >= @ddtt and A.dateTime < @date)";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry, db.con);
            db.cmd.Parameters.AddWithValue("@cid", cid);
            db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
            db.cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0,10));
            db.cmd.Parameters.AddWithValue("@ddtt",  DateTime.Parse(datetime.Substring(0,10)));
            
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {
                totalAmount +=double.Parse(db.rdr.GetString(0));
                liter += double.Parse(db.rdr.GetString(1));
            } 
            db.rdr.Close();
            db.con.Close();


          
            if (totalAmount <= 0)
            {
                
                Label1.Text = "you already Generated Bill...";
            }
            else
            {
                db.con.Open();
                string ins = "insert into Payment_Details values(@pid,@cid,@datetime,@amount,@toatal_milk,@transaction_id,@status,@pymtDate)";
                db.cmd = new System.Data.SqlClient.SqlCommand(ins, db.con);
                db.cmd.Parameters.AddWithValue("@cid", cid);
                db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());
                db.cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                db.cmd.Parameters.AddWithValue("@amount", totalAmount.ToString());
                db.cmd.Parameters.AddWithValue("@toatal_milk", liter.ToString());
                string mytid = cid + Session["p_id"].ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                db.cmd.Parameters.AddWithValue("@transaction_id", mytid);
                db.cmd.Parameters.AddWithValue("@pymtDate", "");
                db.cmd.Parameters.AddWithValue("@status", "0");
                db.cmd.ExecuteNonQuery();
             
                 Label1.Text = "Bill Generated..."; 
                db.rdr.Close();
                db.con.Close();
            }

        }
    }
}