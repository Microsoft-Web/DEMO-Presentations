<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms.Default" %>

<%@ Register Src="~/UserControl1.ascx" TagPrefix="uc1" TagName="UserControl1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:usercontrol1 runat="server" id="UserControl1" />
    </form>
</body>
</html>
