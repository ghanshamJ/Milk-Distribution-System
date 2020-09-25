<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Milk_Order.aspx.cs" Inherits="Online_Milk_Management.Milk_Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />Dairy Name:
   
   <b> <asp:Label ID="lblDairyName" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    </b>
     <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
     <br />
&nbsp;
    <asp:TextBox ID="txtLiters" runat="server" placeholder="Liters"></asp:TextBox>
    <asp:Button  class=" btn btn-primary" ID="btnOrder" runat="server" Text="Order" 
        onclick="btnOrder_Click" />
    &nbsp;<asp:Button  class=" btn btn-danger" ID="btnCancel" runat="server" 
        Text="Cancel" onclick="btnCancel_Click" />

    <br /><br />
    Change default quantity for daily Order<br />
    <asp:TextBox ID="txtDefault_qty" runat="server" placeholder="Liters"></asp:TextBox>
    <asp:Button  class=" btn btn-primary" ID="btnSetDefault" runat="server" 
        Text="Update" onclick="btnSetDefault_Click" Width="63px" />
    &nbsp;<asp:Button  class=" btn btn-danger" ID="btnCancelDefault" runat="server" Text="Cancel" />

    <br />

</asp:Content>
