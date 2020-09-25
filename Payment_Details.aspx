<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Payment_Details.aspx.cs" Inherits="Online_Milk_Management.Payment_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
<br />
Dairy Name: <b><asp:Label ID="lblDairyName"  runat="server"></asp:Label></b>
<br />
<table class="table tab-content" border="1" >
<thead>
 <tr>
 <th>Date Time</th>
 <th>Total Amount</th>
 <th>Total Milk in Liters</th>
  <th>Status</th>
   
 </tr>
</thead>
<tbody>
  <%  foreach(string row in data) 
      {
          %><tr><%
          string[] col = row.Split(' ');
          int tmp = 0;
          double amount=0;
         
          foreach (string cell in col)
          {
              if (tmp == 1)
              {
                  amount = int.Parse(cell); 
              }
          
                %><td>
                <%
                if(tmp==3)
                {
                if(int.Parse(cell)==1)
                {
                %><font color="green"><%="Paid" %></font><%
                }
                else
                {
                 %><a href="PaymentGateway.aspx?price=<%=amount%>&pid=<%=ProviderId %>&cid=<%=CustomerId%>&datetime=<%=DateTime_ %>&tid=<%=transaction_id %>"><b><font color="blue"><%="Pay Now" %></b></a></font><%
                }
                }
                else
                {
                %><%=cell %><%
                }%>
                </td><%
              tmp++;
          }
            %></tr><%
             
      }%>
</tbody>
</table>
</div>

</asp:Content>
