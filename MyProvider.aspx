<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="MyProvider.aspx.cs" Inherits="Online_Milk_Management.MyProvider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<h4>My Providers:</h4>
<div class="container">
<table class="table tab-content" border="1" >
<thead>
 <tr>
 <th>Name</th>
 <th>Email</th>
 <th>Contact</th>
  <th>State</th>
   <th>District</th>
 <th>City</th>
  <th>Address</th>
  <th>Transactions</th>
  <th>Order Now</th>
  <th>Payment Details</th>
 </tr>
</thead>

<tbody>
   <%  
    foreach(string s in cid)
      {
   %>
   <tr>
    <%
          int i = 0;
        foreach (string k in Mydata(s))
       {
           i++;
           if (i == 8)
           {
               Random rnd = new Random();
               int no1 = rnd.Next(1000,9999);
               int no2 = rnd.Next(1000, 9999);
               long a = (long.Parse(k) * no1)*no2;
                   
                %><td><a href="Milk_Transaction_Customer.aspx?pid=<%=k%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Milk Transaction </b> </a></td><%
                %><td><a href="Milk_Order.aspx?pid=<%=k%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Order Now </b> </a></td><%
                 %><td><a href="Payment_Details.aspx?pid=<%=k%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Payment Details </b> </a></td><%
           
            }
          
           else
           {
                %><td><%=k%></td><%
           }
       }
       %></tr><%
   }
   %>
</tbody>
</table>

</asp:Content>
