<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebProjectJFAD.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:100px">
        <div class="row">
            <!--LEFT SIDE PICTURE-->
            <div class="col-md-6">
                    <!--<img src="http://image.rakuten.co.jp/auc-saladabowl/cabinet/calvin-klein/purse/img57252923.jpg?_ex=128x128"
                        style="width: 450px; height: 450px; margin: 0 auto; margin-left:30px;" />-->
                <div>
                <asp:ImageButton runat="server" ID="imgProduct" style="width: 350px; height: 350px; margin: 0 auto; border:thin; border-color:black" />
                <div class="col-lg-4" style="margin-left:30px; margin-top:20px">
                    <asp:ImageButton OnClick="imgSmall1_Click" runat="server" ID="imgSmall1" style="width: 100px;  height: 100px; border:thick; border-color:black; margin-left: 0;"/>
                </div>
                <div class="col-lg-4" style="margin-top:20px"><asp:ImageButton runat="server" ID="imgSmall2" OnClick="imgSmall2_Click" style="width: 100px; height: 100px; border:thick; border-color:black; margin-left: 0;" /></div>
                    </div>
            </div>
            

            <!--RIGHT SIDE DETAILS-->
            <div class="col-md-6">
                <div class="col-md-2"></div>
                <div class="panel panel-default col-md-8">
                    <div class="panel-heading"><asp:Label Text="Product Name" Font-Size="Large" ID="lblProductTitle" runat="server" /></div>
                        <div class="panel-body">
                            <asp:Label runat="server" Text="" ID="lblProductInfo" /><br/><br/>
                            <div style="align-content:center">
                                <div style="float:left;">
                                    <asp:Label ID="Label1" runat="server" Text="Quantity :" />
                                    <asp:TextBox runat="server" Text="1" ID="txtQuantity" Width="25px" />
                                    
                                </div>
                                <div style="float:right; margin-top:10px">
                                    <asp:Button runat="server" Text="Add To Cart" ID="btnAddToCart" OnClick="btnAddToCart_Click" CssClass="btn btn-default" />
                                    <asp:Button runat="server" Text="Empty Cart" ID="btnEmptyCart" OnClick="btnEmptyCart_Click" CssClass="btn btn-default" />
                                </div>
                            </div>
                           <div class="well" style="margin-top:20px;float:left; width:100%; clear:both;"><asp:Label ID="Label2" Text="Details" runat="server" />
                                
                                <asp:BulletedList runat="server" ID="bltList"></asp:BulletedList>
                                    
                            </div>
                            <div style="float:right"><asp:Button runat="server" Text="Back" ID="btnBack" OnClick="btnBack_Click" CssClass="btn btn-default" /></div><br />
                            <div><!----></div>
                        </div>
                    
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
        <div class="col-md-6" style="color:red; margin-top:20px"><asp:Label runat="server" Text="" id="lblError" Font-Italic="true" /> <br />
            <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtQuantity" Font-Italic="true" ErrorMessage="* Make Sure a Number Under 20 is Entered in the Quantity Textbox" MinimumValue="0" MaximumValue="20" Type="Integer"></asp:RangeValidator>
        </div>
    </div>
</asp:Content>
