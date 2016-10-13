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

<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="text-align: center">
			    <h1>Create Account</h1>
    <p>  
        <asp:TextBox ID="tbUserName" runat="server" value ="Username" onfocus="UserFocused(this)"></asp:TextBox></p>
    <p>
        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" value="password" onfocus="PasswordFocused(this)"></asp:TextBox></p>
        <p>
            <asp:TextBox ID="tbAddress" runat="server" Width="354px" value="Email Address" onfocus="AddressFocused(this)"></asp:TextBox>
        </p>
    <p>
        Once you submit, an email will be sent to your account.</p>
    <p>
        This email will contain an 8 digit number.</p>
    <p>
        Once you have recieved this email, log in and enter the number to verify your account.</p>
    <p>
        <asp:Button ID="btnCheck" runat="server" OnClick="checkUName" Text="Submit" />
        </p>
                </td>
            </tr>
        </table>
    </form>
        <script type="text/javascript" src="Login.js"></script>
    </body>
</html>
