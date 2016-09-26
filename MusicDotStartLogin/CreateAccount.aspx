<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="master.css" rel="stylesheet" />
    <title>Create Account</title>
    <style type="text/css">
        #Text3 {
            width: 298px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Create Account</h1>
    <p>  
        &nbsp;<asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>&nbsp; Username
        </p>
    <p>
        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp; Password (must be longer than 8 characters)</p>
    <p>
        &nbsp;<asp:TextBox ID="tbAddress" runat="server" Width="354px"></asp:TextBox>
&nbsp;Email address</p>
    <p>
        Once you submit, an email will be sent to your account.</p>
    <p>
        This email will contain an 8 digit number.</p>
    <p>
        Once you have recieved this email, log in and enter the number to verify your account.</p>
    <p>
        <asp:Button ID="btnCheck" runat="server" OnClick="checkUName" Text="Submit" />
        </p>
    </form>
    </body>
</html>
