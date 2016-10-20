<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <link href="master.css" rel="stylesheet" />
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome,  <asp:Label ID="lblUser" runat="server" Text="user"></asp:Label>
        </h1>

    <div>

    </div>
        <p>
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
        </p>
    </form>
</body>
</html>
