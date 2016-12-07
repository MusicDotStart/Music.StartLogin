<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="master.css" rel="stylesheet" />
<head runat="server">
    <title></title>
</head>
<body>
    <ul>
        <li><a class="active" href="#home">Home</a></li>
        <li><a href="#news">News</a></li>
        <li><a href="#contact">Contact</a></li>
        <li><a href="Upload.aspx">Upload</a></li>
        <li style="float: right"><a href="#about">About</a></li>
    </ul>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="text-align: center">
                <form id="form1" runat="server">
                    <h1>Welcome, 
                        <asp:Label ID="lblUser" runat="server" Text="user"></asp:Label>
                    </h1>

                    <div>
                    </div>
                    <p>
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;


                    </p>

                    <br />
                   <audio controls style="height: 21px; width: 275px" runat="server" id="AudioPlayer" autoplay  >                  
   
                   </audio>

                    <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" OnClientClick="return false;" />
                    <asp:Button ID="btnNope" runat="server" Text="Nope" OnClick="btnNope_Click" />

                    </form>
            </td>
        </tr>

    </table>
    <script type="text/javascript" src="Play.js"></script>

 
</body>
</html>
