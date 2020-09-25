<%@ Page Title="" Language="C#" MasterPageFile="~/Provider.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Online_Milk_Management.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<br />
<h3>Order For the Day:</h3>
    Date:
    <asp:Label ID="lblDate" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp; Total Liters:<asp:Label ID="lblTotalliter" runat="server" 
        style="font-weight: 700" Text="Label"></asp:Label>

<table class="table tab-content" border="1" >
<thead>
 <tr>
 <th>Name</th>
 <th>Address</th>
 <th>Liters</th>
</thead>

<tbody>
    <%  
    foreach(string s in cid)
      {
          string[] arr = s.Split('$');
       %>
       <tr>
        <%
         int i = 0;
       foreach (string k in arr)
       {
        %><td><%=k %></td><%   
       }
       %></tr><%
   }
   %>
</tbody>
</table>

</div>

</asp:Content>
