<%@ Page Title="" Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="Provider_PaymentDetails.aspx.cs" Inherits="Online_Milk_Management.Provider_PaymentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
<br />
Customer Name: <b><asp:Label ID="lblDairyName"  runat="server"></asp:Label></b>
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
            
                %><td>
                <%
                if(tmp==3)
                {
                if(int.Parse(cell)==1)
                {
                %><font color="green"><b><%="Paid" %></b></font><%
                }
                else
                {
                 %><font color="red"><b><%="Unpaid" %></b></font><%
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
