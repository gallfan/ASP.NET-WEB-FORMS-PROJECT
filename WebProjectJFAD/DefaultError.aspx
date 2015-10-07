<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultError.aspx.cs" Inherits="WebProjectJFAD.Errors.DefaultError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formdiv">
        <h3>An Error Has Occurred</h3>
        <p>An unexpected error has occured on our website. Sorry for the inconvience. Would you like to return to the home page?</p>
        <asp:HyperLink runat="server" NavigateUrl="~/Index.aspx" ID="hlHome" Text="Home" CssClass="btn btn-sm btn-info"></asp:HyperLink>
    </div>
</asp:Content>
