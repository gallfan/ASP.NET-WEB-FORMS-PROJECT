<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OrderComplete.aspx.cs" Inherits="WebProjectJFAD.OrderComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formdiv">
        <h3>Congratulations</h3>
        <p>Your Order was Successful</p>
        <asp:HyperLink runat="server" NavigateUrl="~/Index.aspx" ID="hlHome" Text="Home" CssClass="btn btn-sm btn-info"></asp:HyperLink>
    </div>
</asp:Content>
