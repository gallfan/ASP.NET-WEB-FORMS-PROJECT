<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebProjectJFAD.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/carousel.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carousel-example-generic" class="carousel slide" style="margin-top:50px;">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            <li data-target="#carousel-example-generic" data-slide-to="3"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <img src="Images/HomeSlider/02.jpg" />
                <div class="carousel-caption">
                    <h3>Welcome</h3>
                    <p>Have a look around. You won't be disappointed</p>
                </div>
            </div>
            <div class="item">
                <img src="Images/HomeSlider/01.jpg" />
                <div class="carousel-caption">
                    <h3>Designer Watches</h3>
                    <p>Take a look at our range of Leisure and Smart Designer Watches</p>
                </div>
            </div>
            <div class="item">
                <img src="Images/HomeSlider/03.jpg" />
                <div class="carousel-caption">
                    <h3>Need a Belt?</h3>
                    <p>We stock a wide range of trouser and jeans belts</p>
                </div>
            </div>
            <div class="item">
                <img src="Images/HomeSlider/04.jpg" />
                <div class="carousel-caption">
                    <h3>In need of new Designer Glasses?</h3>
                    <p>Check out our new range of Designer Glasses and Sunglasses</p>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
    </div>

    <div class="container">
        <div class="row" style="margin-bottom:20px;">
             <div class="col-md-4">
                <article class="Links" style="background-image:url(Images/Winter.jpg);">
                    <div class="hover">
                        <h4>Winter Collection</h4>
                        <p>Don't miss out on the new Winter Collection</p>
                        <p><a href="#" class="btn btn-info btn-sm">Winter Collection</a></p>
                    </div>
                </article>
            </div>
            <div class="col-md-4">
                <article class="Links" style="background-image:url(Images/model.png);">
                    <div class="hover">
                        <h4>About Us</h4>
                        <p>See what this company is all about.</p>
                        <p><a href="#" class="btn btn-info btn-sm">Learn More</a></p>
                    </div>
                </article>
            </div>
            <div class="col-md-4">
                <article class="Links" style="background-image:url(Images/Belt.jpg);">
                    <div class="hover">
                        <h4>Shop Now</h4>
                        <p>We have a wide range of products available. See Here!</p>
                        <p><a href="~/Products.aspx" class="btn btn-info btn-sm">Shop</a></p>
                    </div>
                </article>
            </div>
        </div>
        <div class="row" runat="server" id="RandomProducts">
            <%--<div class="col-md-4">
                <article class="Links" style="background-image:url(Images/Wallet.jpg);">
                    <div class="hover">
                        <h4>Wallets</h4>
                        <p>See our classy range of quality wallets here.</p>
                        <p><a href="#" class="btn btn-info btn-sm">Wallets</a></p>
                    </div>
                </article>
            </div>
            <div class="col-sm-4">
                <article class="Links" style="background-image:url(Images/CuffLinks.jpg);">
                    <div class="hover">
                        <h4>Cuff Links</h4>
                        <p>Check out our range of new Cuff Links.</p>
                        <p><a href="#" class="btn btn-info btn-sm">Cuff Links</a></p>
                    </div>
                </article>
            </div>
            <div class="col-sm-4">
                <article class="Links" style="background-image:url(Images/Bag.jpg);">
                    <div class="hover">
                        <h4>Bags</h4>
                        <p>We stock a range Messanger Bags. See Here!</p>
                        <p><a href="#" class="btn btn-info btn-sm">Bags</a></p>
                    </div>
                </article>
            </div>--%>
        </div>
    </div>
</asp:Content>
