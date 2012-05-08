<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl1.ascx.cs" Inherits="WebForms.UserControl1" %>

<div>
    <asp:TextBox ID="txtName" runat="server" ValidateRequestMode="Disabled" />
    <asp:RequiredFieldValidator ID="foo" runat="server" ControlToValidate="txtName" ErrorMessage="Required!" />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</div>
