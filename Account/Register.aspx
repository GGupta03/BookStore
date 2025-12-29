<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="BookStore.Account.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>User Registration</h2>

            <asp:Label Text="Full Name" runat="server" /><br />
            <asp:TextBox
                ID="txtName"
                runat="server" /><br />
            <br />

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
                ID="btnRegister"
                runat="server"
                Text="Register"
                OnClick="Register_Click" /><br />
            <br />
            <br />
            <br />
            <span>Already registered?
            <a href="Login.aspx">Login here</a>
            </span>
            <br />
            <asp:Label
                ID="lblMsg"
                runat="server" />

        </div>
    </form>
</body>
</html>
