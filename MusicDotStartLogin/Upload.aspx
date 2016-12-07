<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="master.css" rel="stylesheet" />
<head runat="server">
    <title></title>
</head>
<body>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="text-align: center">
                <form id="form1" runat="server">
                    <div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:FileUpload ID="btnBrowse" runat="server" style="margin-left: 0px" Width="88px" />
                    <br />
                    <br />
                    <asp:ListBox ID="lbGenres" runat="server" Height="110px"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Label ID="lblStatus" runat="server" Text="No file selected" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                     <asp:Label ID="Label1" runat="server" Text="Track Name:" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" style="height: 26px" />
                </form>
            </td>
        </tr>

    </table>
</body>
</html>
