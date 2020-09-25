<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Online_Milk_Management.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
body {font-family: Arial, Helvetica, sans-serif;}
* {box-sizing: border-box;}

input[type=text], select, textarea {
  width: 70%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  margin-top: 6px;
  margin-bottom: 16px;
  resize: vertical;
}

input[type=submit] {
  background-color: #4CAF50;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=submit]:hover {
  background-color: #45a049;
}

.container {
  border-radius: 5px;
  background-color: ;
  padding: 20px;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<!DOCTYPE html>
<html>

<body>

<h3>Contact Us</h3>

<div class="container">
  <form action="/action_page.php">
   
    <input type="text" id="fname" name="firstname" placeholder="Your name..">

 
    <input type="text" id="lname" name="lastname" placeholder="Your last name..">

   
    <textarea id="subject" name="subject" placeholder="Write something.." style="height:200px"></textarea>
    <br />

    <input type="submit" value="Submit">
  </form>
</div>




</asp:Content>
