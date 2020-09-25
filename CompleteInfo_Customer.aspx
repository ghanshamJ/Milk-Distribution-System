<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CompleteInfo_Customer.aspx.cs" Inherits="Online_Milk_Management.CompleteInfo_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <script type="text/javascript" language="javascript">
       var myObj;
       function MyJSON() {
           var xmlhttp;
           xmlhttp = new XMLHttpRequest();
           xmlhttp.onreadystatechange = function () {
               if (this.readyState == 4 && this.status == 200) {
                   myObj = JSON.parse(this.responseText);
               }
           };
           xmlhttp.open("GET", "state.txt", true);
           xmlhttp.send();
       }
       $(function () {
           $("#spanenter").mouseover(function () {
               MyJSON();
               var x = document.getElementById("state");
               x.length = 1;
               for (var k = 0; k < myObj.State_nm.length; k++) {
                   var option = document.createElement("option");
                   option.text = myObj.State_nm[k];
                   option.value = k + 1;
                   x.add(option);
               }
               $("#spanenter").off("mouseover");
           });
       });
       function Changed(selected) {

           document.getElementById('<%=HiddenState.ClientID %>').value = selected.options[selected.selectedIndex].text;
           MyJSON();
           var y = selected.value;
           var x = document.getElementById("dist");
           x.length = 1;
           for (var i = 0; i < myObj.District[y].length; i++) {
               var option = document.createElement("option");
               option.text = myObj.District[y][i];
               x.add(option);
           }
       }

       function SearchClick() {
           /* alert("hello");
           var st = document.getElementById("state").value;
           var dis = document.getElementById("dist").value;

           //document.getElementById('<%=HiddenState.ClientID %>').value = st;
           // document.getElementById("HiddenDistrict").value = dis;
           alert(document.getElementById('<%=HiddenState.ClientID %>').value);
           */

       }
       function DistChanged(selected) {
           document.getElementById('<%=HiddenDistrict.ClientID %>').value = selected.options[selected.selectedIndex].text;
       }
       function CityVal() {
           document.getElementById('<%=HiddenCity.ClientID %>').value = document.getElementById("city").value;
       }
</script>
  <div class="row centered-form">
  <div class="container">
        <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
        	
			    				  <p id="spanenter">
                                    <br/>
                                    <select id="state" onmouseup="Changed(this)" class="form-control " onchange="Changed(this)">
                                    <option value=0>Select State</option>
     
                                    </select>
                                         <asp:HiddenField  ID="HiddenState" runat="server" />
                                    
                                    </p>
			    		
                         
			    				   <select id="dist" onchange="DistChanged(this)" class="form-control ">
                                    <option >Select District</option>
                                    </select><asp:HiddenField ID="HiddenDistrict" runat="server" />


                                  <br />
                                  <asp:TextBox ID="txtCityVillagge" class="form-control " runat="server" placeholder=" City "></asp:TextBox>
                                 <asp:HiddenField ID="HiddenCity" runat="server" />
   
                                  <br />
                                  <asp:TextBox ID="txtMobile" class="form-control " runat="server"  placeholder="Mobile No"></asp:TextBox>
                                  <br />
                                  <asp:TextBox ID="txtAddress" class="form-control " runat="server"  placeholder="Address"></asp:TextBox>
                                  <br />
                                  <strong>Gender</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:RadioButton ID="rdoMale" runat="server" Text="Male" GroupName="gender" />
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:RadioButton ID="rdoFeMale" runat="server" Text="Female" 
                                      GroupName="gender" />
                                  <br />



			    		
                            <asp:Label ID="lblErrormsg" ForeColor="red" Font-Bold=true runat=server ></asp:Label>
                              
                               <asp:Button ID="btnSignup" runat="server" Text="Update" 
                                class="btn btn-info btn-block" onclick="btnSignup_Click" />
			    			<br />
                            <br />
		
        </div>
        </div>
        </div>
        

</asp:Content>
