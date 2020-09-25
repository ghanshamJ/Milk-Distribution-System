using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Milk_Management
{
    public partial class Orders : System.Web.UI.Page
    {
        ConDb db;
        public List<string> cid = new List<string>();
        double totalLiters;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ConDb();
            String datetime = "2000-01-01 10:30:00.000";

            db.con.Open();

            //DateTime start1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 10));
            //DateTime start1 = DateTime.Parse("12-07-2019 23:20:24");

            //DECLARE @today date = GETDATE();
            string Date= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 10);

            string qry3 = "SELECT first_name,last_name,address,liter from  customer join milk_Transaction on customer.c_id=milk_Transaction.c_id WHERE  dateTime >= DATEADD(DAY, -1, @today) AND dateTime <  @today and p_id=@pid";

           // string qry3 = "select first_name,last_name,address,liter from customer join milk_Transaction on customer.c_id=milk_Transaction.c_id where p_id=@pid ";
            db.cmd = new System.Data.SqlClient.SqlCommand(qry3, db.con);
           // db.cmd.Parameters.AddWithValue("@cid", cid);

            db.cmd.Parameters.AddWithValue("@today", Date);
             db.cmd.Parameters.AddWithValue("@pid", Session["p_id"].ToString());

            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {


                cid.Add(db.rdr.GetString(0) + " " + db.rdr.GetString(1) + "$" + db.rdr.GetString(2)+"$"+db.rdr.GetString(3));
                //cid.Add(db.rdr.GetString(1));
                //cid.Add(db.rdr.GetString(2));
                //cid.Add(db.rdr.GetString(3));
                totalLiters +=double.Parse( db.rdr.GetString(3));
                
            }
            lblTotalliter.Text = totalLiters.ToString();
            lblDate.Text = DateTime.Now.ToShortDateString();
            db.rdr.Close();
            db.con.Close();

        }
    }
}