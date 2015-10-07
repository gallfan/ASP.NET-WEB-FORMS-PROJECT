<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebProjectJFAD.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin:100px 0 50px 0;">
        <div class="col-md-3" runat="server" id="div1"></div>
        <div class="col-md-8" runat="server" id="divCart">
            <%if(newCartList.Count>0 && newCartList!=null)
              {
                  decimal totalPrice = 0;
                  %>
            <div class="jumbotron">
            <%foreach (var p in newCartList)
              {
                  totalPrice += p.Price;
            %>
            
                <div class="container" style="border-bottom:2px solid grey; margin:15px">
                <div class="col-md-6"> <img src="<%= p.ImageUrl%>" style="width: 150px; height: 150px" /></div>
                    <div class="col-md-6">
                <h3>Name : <%= p.ProductName %></h3>
                <h3>Price : <%= String.Format("{0:c2}",p.Price) %></h3>
                
                <h3>Quantity : <%= Convert.ToInt32(p.Quantity) %></h3>
                        </div>
                    </div>
            
            <%} %>
                <div style="text-align:center;"><h3>Overall Price : <%= String.Format("{0:C2}",totalPrice) %></h3></div>
                </div>
                <div>

                <div style="float: left;">Credit Card Details :
                    <asp:TextBox runat="server" ID="txtCreditCard" placeholder="ie 1234123412341234" />
                    
                    
                </div>

                <div style="float: right;">
                    <asp:Button runat="server" Text="Make Purchase" ID="btnPurchase" OnClick="btnPurchase_Click" CssClass="btn btn-default" /></div>
            
                </div>
            <div>
                
            </div>

            <%} 
              else {%>
            <div class="jumbotron" style="text-align:center;"><h2>Your Shopping Cart is Currently Empty</h2></div>
            <%} %>

            
        </div>

            <div class="col-md-3" runat="server" id="div3"></div>
    <div class="col-md-9" style="color:red;margin-top:10px"><asp:RequiredFieldValidator ID="credCardRequiredFieldValidator" Font-Italic="true" runat="server" ErrorMessage="* Your Must Enter A Credit Card Number" ControlToValidate="txtCreditCard" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="credCardRegEx" runat="server" CssClass="validator" ErrorMessage="* Credit Card Must have 16 Digits"  ValidationExpression="^(\d{4}[- ]){3}\d{4}|\d{16}$" Display="Dynamic" ControlToValidate="txtCreditCard"/>
        <br />
        <asp:Label runat="server" Font-Italic="true" Text="" ID="lblError" /></div>
    </div>

</asp:Content>
