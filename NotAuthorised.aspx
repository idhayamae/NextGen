<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotAuthorised.aspx.cs" Inherits="NotAuthorised" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblNotAuthorised" Text="You are not an authorised user to view this page."
            Font-Bold="true" ForeColor="Red" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblError" Text="Sorry!! Error Occurred." Font-Bold="true" ForeColor="Red"
            runat="server" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
