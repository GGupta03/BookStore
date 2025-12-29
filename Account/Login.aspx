<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="BookStore.Account.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>User Login</h2>

            <asp:Label Text="Email" runat="server" /><br />
            <asp:TextBox
                ID="txtEmail"
                runat="server" /><br />
            <br />

            <asp:Label Text="Password" runat="server" /><br />
            <asp:TextBox
                ID="txtPassword"
                runat="server"
                TextMode="Password" /><br />
            <br />

            <asp:Button
                ID="btnLogin"
                runat="server"
                Text="Login"
                OnClick="Login_Click" /><br />
            <br />
            <br />
            <br />
            <span>Don’t have an account?
            <a href="Register.aspx">Register here</a>
            </span>
            <br />
            <asp:Label
                ID="lblMsg"
                runat="server"
                ForeColor="Red" />

        </div>
    </form>
</body>
</html>
