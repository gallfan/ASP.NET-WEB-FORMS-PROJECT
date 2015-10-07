<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="WebProjectJFAD.Errors._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formdiv">
        <h3>Page Not Found</h3>
        <p>Sorry the page you have requested can not be found. Would you like to return to the home page?</p>
        <asp:HyperLink runat="server" NavigateUrl="~/Index.aspx" ID="hlHome" Text="Home" CssClass="btn btn-sm btn-info"></asp:HyperLink>
    </div>
</asp:Content>
