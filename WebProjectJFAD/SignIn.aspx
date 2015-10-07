<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebProjectJFAD.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal formdiv">
        <h3>Sign In</h3>
        <div class="form-group">
            <label for="Username" class="col-sm-4 control-label">Username:</label>
            <div class="col-sm-8">
                <asp:TextBox runat="server" CssClass="form-control" name="Username" Placeholder="Username" ID="txtUsername1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername1" ValidationGroup="Signin" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revUsername1" ValidationGroup="Signin" runat="server" ControlToValidate="txtUsername1" ErrorMessage="Username length must be between 2 and 50 characters" ValidationExpression="^.{2,50}.*$" ForeColor="Red" Display="Dynamic" />
            </div>
        </div>

        <div class="form-group">
            <label for="Password" class="col-sm-4 control-label">Password:</label>
            <div class="col-sm-8">
                <asp:TextBox runat="server" CssClass="form-control" name="Password" ID="txtPassword1" TextMode="Password" Placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword1" ValidationGroup="Signin" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPassword1" ValidationGroup="Signin" runat="server" ControlToValidate="txtPassword1" ErrorMessage="Password length must be between 2 and 50 characters" ValidationExpression="^.{2,50}.*$" ForeColor="Red" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-8">
                <label>
                    <asp:CheckBox ID="chkRemember1" name="Remember" runat="server" />
                    Remember Me</label>
            </div>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="text-align:center;">
            <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx" Text="Not Registered? Click here to register"></asp:HyperLink>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="text-align:center;">
            <asp:Label class="text-center" runat="server" ID="lblError" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button runat="server" CssClass="btn btn-info btn-sm col-sm-offset-10" ValidationGroup="Signin" Text="Sign In" ID="btnSignIn1" OnClick="btnSignIn_Click" />
    </div>
</asp:Content>
