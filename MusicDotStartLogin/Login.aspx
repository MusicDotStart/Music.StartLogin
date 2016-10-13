<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="master.css" rel="stylesheet" />
    <title></title>
</head>
<body style="height: 443px">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="text-align: center">
                    <h1>Login</h1>
                    <p>
                        <asp:TextBox ID="tbUserName" runat="server" value="Username" OnTextChanged="tbUserName_TextChanged1" onfocus="UserFocused(this)"></asp:TextBox>
                        &nbsp;
                    </p>
                    <p>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" value="password" onfocus="PasswordFocused(this)"></asp:TextBox>
                        &nbsp;
                    </p>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                    &nbsp;
        <p>
            &nbsp;
        </p>
                    <p>
                        Dont have an account?
                    </p>
                    <p>
                        Click here to create one.
                    </p>
                    <p>
                        <asp:Button ID="btnMakeAcct" runat="server" Text="Make Account" OnClick="btnMakeAcct_Click" />
                    </p>
                </td>
            </tr>
        </table>

    </form>
    <p>
        &nbsp;
    </p>
    <script type="text/javascript" src="Login.js"></script>
</body>
</html>
