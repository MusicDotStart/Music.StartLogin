<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="master.css" rel="stylesheet" />
    <title></title>
</head>    
<body style="height: 443px">
    <form id="form1" runat="server">
        <h1>Login</h1>
        <p>
            <asp:TextBox ID="tbUserName" runat="server" OnTextChanged="tbUserName_TextChanged"></asp:TextBox>
        &nbsp;Username</p>
        <p>
            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp; Password</p>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p>
        &nbsp;</p>
    <p>
        Dont have an account?</p>
        <p>
            Click here to create one.</p>
        <p>
        <asp:Button ID="btnMakeAcct" runat="server"  Text="Make Account" OnClick="btnMakeAcct_Click"/>
        </p>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
