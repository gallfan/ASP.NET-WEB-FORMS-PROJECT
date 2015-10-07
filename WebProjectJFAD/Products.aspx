<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebProjectJFAD.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:50px;">
    <asp:Label ID="label1" runat="server"></asp:Label>
        <%--<asp:Button runat="server" ID="btnClick" Text="All Products" OnClick="btnClick_Click" />
        <asp:Button runat="server" ID="lowClick" Text="Price Low To High" OnClick="lowClick_Click" />
        <asp:Button runat="server" ID="HighClick" Text="Price High to Low" OnClick="HighClick_Click"  />
        <asp:Button runat="server" ID="Quantity" Text="Quantity" onclick="Quantity_Click" />--%>
       <div class="container" style="margin-top:30px;">
        <asp:DropDownList  id="dropDownSort" runat="server" >
        <asp:ListItem  Value="0">All products</asp:ListItem>
        <asp:ListItem Value="1">Price Low-High</asp:ListItem>
        <asp:ListItem Value="2">Price High-Low</asp:ListItem>
        <asp:ListItem Value="3">Quantity</asp:ListItem>
        
        </asp:DropDownList>
        <asp:Button ID="btnSort" Text="Sort" onclick="btnSort_Click" runat="server"/>
           </div>
<p><asp:label id="mess" runat="server"/></p>

    <div class="jumbotron" style="margin:100px;width:900px">
     
    
    <% foreach (var p in products)
       {
             
            %> <!-- loop through the list -->

  <ul style="display:inline-block;width:250px;height:300px;list-style-type:none;border-style:solid;">
    <li>
        
        <p><%= p.ProductName %></p>
        <p>€<%= p.Price %></p>
        <p><%= p.Stock %></p>
        <img src="<%= p.MainProductImage %>" width="150";height="150";/>
        <br />
        <asp:HyperLink ID="details" runat="server" Text="Details" NavigateUrl="ProductDetails.aspx?ProductId=1" />
      
    </li>
    </ul>
            <% 
         }
      %>

</div>
</div>
</asp:Content>
