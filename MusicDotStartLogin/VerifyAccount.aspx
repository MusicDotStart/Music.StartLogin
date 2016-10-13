<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyAccount.aspx.cs" Inherits="VerifyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="master.css" rel="stylesheet" />
    <title>Music.Start Verify</title>
</head>
<body>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="text-align: center">
		    <h1>
        Verify your account
    </h1>
    <p> Enter the 8 digit number from the email you recieved.</p>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbCode" runat="server" OnTextChanged="tbCode_TextChanged"></asp:TextBox>
        </div>
    <p>
        <asp:Button ID="btnVerify" runat="server" OnClick="btnVerify_Click" Text="Verify" />
        </p>
        </form>
                </td>
            </tr>
        
        </table>
    </body>
</html>
