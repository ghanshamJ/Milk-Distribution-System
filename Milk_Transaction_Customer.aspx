<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Milk_Transaction_Customer.aspx.cs" Inherits="Online_Milk_Management.Milk_Transaction_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<br />
<h4>Milk Transactions Detail</h4>
Dairy Name: <b><asp:Label ID="lblDairyName"  runat="server"></asp:Label></b>
<br />
<table class="table tab-content" border="1" >
<thead>
 <tr>
 <th>Date Time</th>
 <th>Liters</th>
 <th>Rate / Liter</th>
  <th>Amount</th>
  
 </tr>
</thead>
<tbody>
  <%  foreach(string row in data) 
      {
          %><tr><%
          string[] col = row.Split(' ');
          
          foreach (string cell in col)
          {
                %><td>
                <%=cell %>
                </td><%
          }
            %></tr><%
             
      }%>
</tbody>
</table>
</div>
  

</asp:Content>
