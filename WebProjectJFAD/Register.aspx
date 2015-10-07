<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebProjectJFAD.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="margin-top:50px; margin-bottom:50px;">
    
    <div style="margin-top:50px;" class="container" >
        <div class="row">
            <div class="col-lg-6">
            <h3>Personal Details</h3>
            <!--Email-->
            <div class="form-group">
                <label class="col-lg-3 control-label">Email Address </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                </div>       
            </div>
            <!-- Email Confirm -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Confirm Email</label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtEmailConfirm" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_EmailConfirm" ControlToValidate="txtEmailConfirm" runat="server" ErrorMessage="Email Confirm Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator_Email_Confirm" runat="server" ControlToValidate="txtEmailConfirm" ControlToCompare="txtEmail" ErrorMessage="Emails do not match." Display="Dynamic" TabIndex="1" />
                </div>
            </div>
            <!-- First Name -->
            <div class="form-group">
                <label class="col-lg-3 control-label">First Name </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_FirstName" ControlToValidate="txtFirstName" runat="server" ErrorMessage="First Name Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!-- Last Name -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Last Name </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_LastName" ControlToValidate="txtLastName" runat="server" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            </div>
            
            <div class="col-lg-6">
            <h3>Address</h3>
            <!-- Address1 -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Address 1 </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Country" ControlToValidate="txtAddress1" runat="server" ErrorMessage="Address Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!-- Address2 -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Address 2 </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Address" ControlToValidate="txtAddress2" runat="server" ErrorMessage="Address Required"></asp:RequiredFieldValidator>
                </div> 
            </div>
            <!-- Town/City -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Town/City </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_City" ControlToValidate="txtCity" runat="server" ErrorMessage="Town/City Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!-- County -->
            <div class="form-group">
                <label class="col-lg-3 control-label">County </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtCounty" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCity" runat="server" ErrorMessage="County Required"></asp:RequiredFieldValidator>
                </div>
            </div> 
            </div>
       </div><!-- End Row -->         
</div>
        <div class="container">
        <div class="row">
            <div class="col-lg-6">
            <h3>Contact</h3>
            <!-- Telephone -->
            <div class="form-group">
                <label class="col-lg-3  control-label">Telephone </label>
                <div class="col-lg-9">
                    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                </div>
            </div>
            <!-- Mobile 
            <div class="form-group">
                <label class="col-sm-6 col-xs-4 col-md-2 control-label">Mobile </label><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            </div>-->
            </div>

            <div class="col-lg-6">
            <h3>Password</h3>
            <!-- Password -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Password </label>
                <div class="col-lg-9">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!-- Confirm Password -->
            <div class="form-group">
                <label class="col-lg-3 control-label">Confirm Password </label>
                <div class="col-lg-9">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPasswordConfirm" runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPasswordConfirm" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." />
                </div>
            </div>
            </div>
        </div>
        </div>
            
    <!-- Buttons -->
        <div class="container">
            <asp:Button ID="btnRegister" Cssclass="btn btn-info"  runat="server" CausesValidation="true" Text="Register" OnClick="btnRegister_Click"/>
            <asp:Button ID="btnCancel" Cssclass="btn btn-info" runat="server" CausesValidation="false" Text="Back" OnClick="btnCancel_Click" />
        </div>

    <!------------------------------------------------- Modal -------------------------------------------------------->

<div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="myModalLabel">Success</h3>
            </div>
            <div class="modal-body">

                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label><br />
                <asp:Label ID="Label3" runat="server">Thank you for signing up, please return to the main page and sign in.</asp:Label>
                
            </div>
            <div class="modal-footer">
                <asp:Button ID="ButtonHome" Cssclass="btn btn-info"  runat="server" CausesValidation="false" Text="Register" OnClick="btnCancel_Click"/>
                
            </div>
        </div>
    </div>
</div>

<div id="myModal1" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h3 id="H1">Error</h3>
            </div>
            <div class="modal-body">

                <asp:Label ID="Label4" runat="server"></asp:Label>
                <asp:Label ID="Label6" runat="server">Please try another name</asp:Label>
                
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button1" Cssclass="btn btn-info"  runat="server" CausesValidation="false" Text="Register" OnClick="btnCancel_Click"/>
                
            </div>
        </div>
    </div>
</div>
<!---------------------------------------------------------------------------------------------------------------->
</div>


</asp:Content>

