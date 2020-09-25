<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ProviderDetails.aspx.cs" Inherits="Online_Milk_Management.ProviderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
  <h2>&nbsp;</h2>
  <table class="table table-dark">
    <thead>
      <tr>
        <th colspan="3">
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
          </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>State</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>District</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblDistrict" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>City</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblCityVillage" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>Address</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>Contact</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblContact" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
    </tbody>
  </table>


    <br />
    <asp:Button class=" btn btn-primary" ID="btnJoin" runat="server" Text="Join" 
        onclick="btnJoin_Click" />


    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>


</div>

 
</asp:Content>
