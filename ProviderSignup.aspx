<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="ProviderSignup.aspx.cs" Inherits="Online_Milk_Management.ProviderSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row centered-form">
  <div class="container">
        <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
        	<div class="panel panel-default">
        		<div class="panel-heading">
			    		<h3 class="panel-title">Provider Sign Up</h3>
			 			</div>
			 			<div class="panel-body">
			    		<form role="form">
			    			
			    					<div class="form-group">
			                           <asp:TextBox  runat="server" ID="txtDairy_name" class="form-control input-sm" 
                                            placeholder="Dairy / Company Name"></asp:TextBox>
			    					</div>
			    			
			    			

			    			<div class="form-group">
			    				 <asp:TextBox  runat="server" id="txtemail" class="form-control input-sm" 
                                     placeholder="Email Address"></asp:TextBox>
			    			</div>

			    			<div class="row">
			    				<div class="col-xs-6 col-sm-6 col-md-6">
			    					<div class="form-group">
			    						 <asp:TextBox  runat="server" id="txtpassword" class="form-control input-sm" 
                                             placeholder="Password" TextMode="Password"></asp:TextBox>
			    					</div>
			    				</div>
			    				<div class="col-xs-6 col-sm-6 col-md-6">
			    					<div class="form-group">
			    						 <asp:TextBox  runat="server" id="txtpassword_confirmation" 
                                             class="form-control input-sm" placeholder="Confirm Password" 
                                             TextMode="Password"></asp:TextBox>
			    					</div>
			    				</div>
			    			</div>
                            <asp:Label ID="lblErrormsg" ForeColor="red" Font-Bold=true runat=server
                    ></asp:Label>
                               <asp:Button ID="btnSignup" runat="server" Text="Signup" 
                                class="btn btn-info btn-block" onclick="btnSignup_Click" />
			    			
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
