<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="FindDairy.aspx.cs" Inherits="Online_Milk_Management.FindDairy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <script type="text/javascript" language="javascript">
    var myObj;
    function MyJSON() 
    {
     var xmlhttp;
     xmlhttp = new XMLHttpRequest();
     xmlhttp.onreadystatechange = function ()
      {
         if (this.readyState == 4 && this.status == 200)
          {
            myObj = JSON.parse(this.responseText);
          }
      };
      xmlhttp.open("GET", "state.txt", true);
      xmlhttp.send();
    }
    $(function ()
     {
        $("#spanenter").mouseover(function () 
        {
            MyJSON();
            var x = document.getElementById("state");
            x.length = 1;
            for (var k = 0; k < myObj.State_nm.length; k++)
            {
                var option = document.createElement("option");
                option.text = myObj.State_nm[k];
                option.value = k+1;
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
         for (var i = 0; i < myObj.District[y].length; i++)
          {
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
     function DistChanged(selected)
     {
       document.getElementById('<%=HiddenDistrict.ClientID %>').value = selected.options[selected.selectedIndex].text;
   }
   function CityVal() 
   {
       document.getElementById('<%=HiddenCity.ClientID %>').value = document.getElementById("city").value;
   }
</script>
  <div class="row centered-form">
  <div class="container">
        <div class="col-xs-12 col-sm-8 col-md-4 col-sm-offset-2 col-md-offset-4">
        	
    <p>
      <h4>Find Dairy</h4>
         <p id="spanenter">
        <br/>
        <select id="state" onmouseup="Changed(this)" onchange="Changed(this)" class="form-control ">
        <option value=0>Select State</option>
     
        </select>
             <asp:HiddenField  ID="HiddenState" runat="server" />
       
        </p>
    
        </p>
   
            <select id="dist" onchange="DistChanged(this)" class="form-control ">
        <option >Select District</option>
        </select><asp:HiddenField ID="HiddenDistrict" runat="server" />
  <br />
    <p>
        <input id="city" placeholder="City" type="text"  class="form-control " onkeyup="CityVal()" onblur="CityVal()" /><asp:HiddenField ID="HiddenCity" runat="server" />
    </p>
    <p>
        <asp:Button ID="btnSearch" runat="server" Text="Search"   class="form-control btn btn-primary "
            onclientclick="SearchClick()" onclick="btnSearch_Click1" />
    </p>
    <p>
    </p>
   </div>
   </div>
   </div>
  
   <div class="container">
<table class="table tab-content" border="1" >
<thead>
 <tr>
 <th>Name</th>
 <th>Email</th>
 <th>Contact</th>
  <th>State</th>
   <th>District</th>
 <th>City</th>
  <th>Address</th>
  <th>Visit</th>

 </tr>
</thead>

<tbody>
   <%  
       foreach (string s in providerId)
      {
   %>
   <tr>

    <%
          int i = 0;
        foreach (string k in Mydata(s))
       {
           i++;
           if (i == 8)
           {
               Random rnd = new Random();
               int no1 = rnd.Next(1000,9999);
               int no2 = rnd.Next(1000, 9999);
               
;                   
                %><td><a href="ProviderDetails.aspx?cid=<%=k%>"><b>Visit </b> </a></td><%
           }
          
           else
           {
                %><td><%=k%></td><%
           }
       }
       %></tr><%
   }
   %>
</tbody>
</table>
</div>
</asp:Content>
