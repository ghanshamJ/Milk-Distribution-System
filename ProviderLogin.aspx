<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="ProviderLogin.aspx.cs" Inherits="Online_Milk_Management.ProviderLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



         <div class="row centered-form">
  <div class="container">
        <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
        	<div class="panel panel-default">
        		<div class="panel-heading">
			    		<h4 class="panel-title">Provider Login</h4>
			 			</div>
			 			<div class="panel-body">
			    		<form role="form">
			    			
			    				
			    					<div class="form-group">
			                           
                                    <asp:TextBox ID="txtUname" runat="server" class="form-control input-sm"  placeholder="Email/Username"></asp:TextBox>
			    					</div>
			    			<div class="form-group">
			    				  <asp:TextBox TextMode="Password" ID="txtPassword" class="form-control input-sm" runat="server" placeholder="Password"></asp:TextBox>
			    			</div>

                            <asp:Label ID="lblErrormsg" ForeColor="red" Font-Bold=true runat=server></asp:Label> 
			    	
                               <asp:Button ID="btnSignup" runat="server" Text="Login" 
                                class="btn btn-info btn-block" onclick="btnSignup_Click" />
                     <asp:LinkButton ID="lnkForgot" runat="server">Forgot Password ?</asp:LinkButton>
			    		<p>

<br />
<br />
			    		</form>
			    	</div>
	    		</div>
    		</div>
    	</div>
    </div>
        </div>

</asp:Content>
