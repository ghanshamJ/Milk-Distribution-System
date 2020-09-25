using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace Online_Milk_Management
{
    public partial class PaymentGateway : System.Web.UI.Page
    {
        string providerID, customerID, amount_Pay, Transaction_ID;
        string DateTime_ = "2000-01-01 10:30:00.000";
        protected void Page_Load(object sender, EventArgs e)
        {
            amount_Pay = Request.QueryString["price"].ToString();
            providerID = Request.QueryString["pid"].ToString();
            customerID = Request.QueryString["cid"].ToString();
            DateTime_ = Request.QueryString["datetime"].ToString();
            Transaction_ID = Request.QueryString["tid"].ToString();
          //  Response.Write(amount_Pay + providerID + customerID+DateTime_);

            if (!IsPostBack)
            {
                lblAmount.Text = Request.QueryString["price"].ToString();
                Random random = new Random();
                txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
                txnid.Value = "Pay" + customerID + txnid.Value.ToString() + DateTime_;
               // Response.Write(txnid.Value.ToString());
            }
           
           
            Session["Transaction_ID"] = Transaction_ID;
            

           btnPayNow_Click();
        }

        protected void btnPayNow_Click()
        {
            Double amount = Convert.ToDouble(lblAmount.Text);
            String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + "Pay Milk" + "|" + "sham" + "|" + "sham@gmail.com" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
            //Response.Write(text);
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            hash.Value = hex;

            System.Collections.Hashtable data = new System.Collections.Hashtable();
            // adding values in gash table for data post
            data.Add("hash", hex.ToString());
            data.Add("txnid", txnid.Value);
            data.Add("key", key.Value);
            // string AmountForm = ;// eliminating trailing zeros

            data.Add("amount", amount);
            data.Add("firstname", "sham");//TextBox1.Text.Trim());
            data.Add("email", "sham@gmail.com");//TextBox2.Text.Trim());
            data.Add("phone", "1010101010");//TextBox3.Text.Trim());
            data.Add("productinfo", "Pay Milk");

            //data.Add("pid", providerID);
            //data.Add("cid", customerID);
           // data.Add("datetime", DateTime_);

            data.Add("udf1", "1");
            data.Add("udf2", "1");
            data.Add("udf3", "1");
            data.Add("udf4", "1");
            data.Add("udf5", "1");

            //data.Add("pid", providerID);
           // data.Add("cid", customerID);
           // data.Add("datetime", DateTime_);

            data.Add("surl", "http://localhost:33280/PaymentSuccess.aspx");
            data.Add("furl", "http://localhost:33280/PaymentFailure.aspx");

            data.Add("service_provider", "");


            string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
            Page.Controls.Add(new LiteralControl(strForm));


        }
        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }
    }
}