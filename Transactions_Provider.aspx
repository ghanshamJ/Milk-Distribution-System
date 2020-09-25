<%@ Page Title="" Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="Transactions_Provider.aspx.cs" Inherits="Online_Milk_Management.Transactions_Provider" %>
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
