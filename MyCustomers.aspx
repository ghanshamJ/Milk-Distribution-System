<%@ Page Title="" Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="MyCustomers.aspx.cs" Inherits="Online_Milk_Management.MyCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<br />
<h4>My Customers: </h4>
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
  <th>Generate Bill</th>
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
                   
                %><td><a href="Transactions_Provider.aspx?cid=<%=a%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Transaction </b> </a></td><%
                 %><td><a href="Generate_Bill.aspx?cid=<%=k%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Genarate Bill </b> </a></td><%
                %><td><a href="Provider_PaymentDetails.aspx?cid=<%=k%>&tcode1=<%=no1%>&tcode2=<%=no2%>"><b>Payment Details </b> </a></td><%
          
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

</div>
</asp:Content>
